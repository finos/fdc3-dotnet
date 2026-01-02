/*
 * SPDX-License-Identifier: Apache-2.0
 * Copyright FINOS FDC3 contributors - see NOTICE file
 */

using Finos.Fdc3.AppDirectory;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Finos.Fdc3.Json.Serialization
{
    public class IntentsConverter : JsonConverter<Intents>
    {
        public override Intents? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var result = JsonSerializer.Deserialize<Intents>(ref reader, Fdc3JsonSerializerOptions.CreateWithoutConverters());
            if (result?.ListensFor != null)
            {
                foreach (var intentName in result.ListensFor.Keys)
                {
                    result.ListensFor[intentName].Name = intentName;
                }
            }

            return result;
        }

        public override void Write(Utf8JsonWriter writer, Intents value, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }
    }
}
