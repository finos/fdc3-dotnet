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

using System.Text.Json;
using System.Text.Json.Serialization;

namespace MorganStanley.Fdc3.Json.Serialization
{
    public static class Fdc3JsonSerializerOptions
    {
        public static JsonSerializerOptions Create()
        {
            return new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.IgnoreCycles,
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
                Converters =
                {
                   new JsonStringEnumConverter(new Fdc3CamelCaseNamingPolicy()),
                   new Fdc3AppConverter(),
                   new RecipientJsonConverter()
                },
                PropertyNamingPolicy = new Fdc3CamelCaseNamingPolicy()
            };
        }
    }
}
