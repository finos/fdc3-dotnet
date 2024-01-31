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
