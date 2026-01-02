/*
 * SPDX-License-Identifier: Apache-2.0
 * Copyright FINOS FDC3 contributors - see NOTICE file
 */

using Finos.Fdc3.Context;
using System;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace Finos.Fdc3.Json.Serialization
{
    internal class RecipientJsonConverter : JsonConverter<IRecipient>
    {
        public override bool CanConvert(Type typeToConvert)
        {
            return typeToConvert == typeof(IRecipient);
        }

        public override IRecipient? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            Utf8JsonReader readerClone = reader;

            Type? targetType = null;
            var jsonObject = JsonNode.Parse(ref readerClone);
            if (jsonObject == null)
            {
                throw new JsonException();
            }

            string? contextType = jsonObject["type"]?.ToString();
            if (contextType == ContextTypes.Contact)
            {
                targetType = typeof(Contact);
            }
            else if (contextType == ContextTypes.ContactList)
            {
                targetType = typeof(ContactList);
            }

            if (targetType == null)
            {
                return null;
            }

            return JsonSerializer.Deserialize(ref reader, targetType, options) as IRecipient;
        }

        public override void Write(Utf8JsonWriter writer, IRecipient value, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }
    }
}
