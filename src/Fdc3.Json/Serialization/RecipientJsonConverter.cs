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

using MorganStanley.Fdc3.Context;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace MorganStanley.Fdc3.Json.Serialization
{
    public  class RecipientJsonConverter : JsonConverter
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
