/*
 * Morgan Stanley makes this available to you under the Apache License,
 * Version 2.0 (the "License"). You may obtain a copy of the License at
 *
 *      http://www.apache.org/licenses/LICENSE-2.0.
 *
 * See the NOTICE file distributed with this work for additional information
 * regarding copyright ownership. Unless required by applicable law or agreed
 * to in writing, software distributed under the License is distributed on an
 * "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express
 * or implied. See the License for the specific language governing permissions
 * and limitations under the License.
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
