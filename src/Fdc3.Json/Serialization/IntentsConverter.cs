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
