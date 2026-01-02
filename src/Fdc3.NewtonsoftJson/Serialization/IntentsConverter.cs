/*
 * SPDX-License-Identifier: Apache-2.0
 * Copyright FINOS FDC3 contributors - see NOTICE file
 */

using Finos.Fdc3.AppDirectory;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace Finos.Fdc3.NewtonsoftJson.Serialization
{
    public class IntentsConverter : JsonConverter<Intents>
    {
        public override bool CanWrite => false;

        public override Intents? ReadJson(JsonReader reader, Type objectType, Intents? existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
            {
                return null;
            }

            var obj = JObject.Load(reader);
            var result = obj.ToObject(typeof(Intents)) as Intents;

            if (result?.ListensFor != null)
            {
                foreach (var intentName in result.ListensFor.Keys)
                {
                    result.ListensFor[intentName].Name = intentName;
                }
            }

            return result;
        }

        public override void WriteJson(JsonWriter writer, Intents? value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
