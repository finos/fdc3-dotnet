/*
 * SPDX-License-Identifier: Apache-2.0
 * Copyright FINOS FDC3 contributors - see NOTICE file
 */

using Finos.Fdc3.Context;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace Finos.Fdc3.NewtonsoftJson.Serialization
{
    public class RecipientJsonConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(IRecipient);
        }

        public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
            {
                return null;
            }

            Type? targetType = null;
            JObject obj = JObject.Load(reader);

            string? contextType = obj["type"]?.ToString();
            if (contextType == ContextTypes.Contact)
            {
                targetType = typeof(Contact);
            }
            else if (contextType == ContextTypes.ContactList)
            {
                targetType = typeof(ContactList);
            }

            return (targetType != null)
                ? obj.ToObject(targetType, serializer) :
                null;
        }

        public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override bool CanRead => true;
        public override bool CanWrite => false;
    }
}
