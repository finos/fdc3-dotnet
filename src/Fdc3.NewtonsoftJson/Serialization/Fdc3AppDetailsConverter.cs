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

using MorganStanley.Fdc3.AppDirectory;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;


namespace MorganStanley.Fdc3.NewtonsoftJson.Serialization
{
    public class Fdc3AppDetailsConverter : JsonConverter<IAppDetails>
    {
        public override IAppDetails? ReadJson(JsonReader reader, Type objectType, IAppDetails? existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var jsonObject = JObject.Load(reader);

            if (jsonObject.ContainsKey("path"))
            {
                return JsonConvert.DeserializeObject<NativeAppDetails>(jsonObject.ToString());
            }
            else if (jsonObject.ContainsKey("alias"))
            {
                return JsonConvert.DeserializeObject<CitrixAppDetails>(jsonObject.ToString());
            }
            else if (jsonObject.ContainsKey("url"))
            {
                return JsonConvert.DeserializeObject<WebAppDetails>(jsonObject.ToString());
            }
            else
            {
                throw new InvalidOperationException("Unknown AppDetails structure");
            }
        }

        public override void WriteJson(JsonWriter writer, IAppDetails? value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override bool CanRead => true;
        public override bool CanWrite => false;
    }
}
