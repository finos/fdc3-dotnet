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

namespace Finos.Fdc3.Json.Serialization
{
    public static class Fdc3JsonSerializerOptions
    {
        public static JsonSerializerOptions Create()
        {
            var options = CreateWithoutConverters();
            options.Converters.Add(new JsonStringEnumConverter(new Fdc3CamelCaseNamingPolicy()));
            options.Converters.Add(new Fdc3AppConverter());
            options.Converters.Add(new RecipientJsonConverter());
            options.Converters.Add(new IntentsConverter());
            return options;
        }

        internal static JsonSerializerOptions CreateWithoutConverters()
        {
            return new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.IgnoreCycles,
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
                PropertyNamingPolicy = new Fdc3CamelCaseNamingPolicy()
            };
        }
    }
}
