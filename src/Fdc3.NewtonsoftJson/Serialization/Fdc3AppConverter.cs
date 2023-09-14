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
    public class Fdc3AppConverter : JsonConverter<Fdc3App>
    {
        public override Fdc3App? ReadJson(JsonReader reader, Type objectType, Fdc3App? existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var jsonObject = JObject.Load(reader);

            var appType = ParseAppType(jsonObject["type"]?.ToString());

                switch (appType)
                {
                    case AppType.Web:
                        return JsonConvert.DeserializeObject<Fdc3App<WebAppDetails>>(jsonObject.ToString());
                    case AppType.Citrix:
                        return JsonConvert.DeserializeObject<Fdc3App<CitrixAppDetails>>(jsonObject.ToString());
                     case AppType.Native:
                        return JsonConvert.DeserializeObject<Fdc3App<NativeAppDetails>>(jsonObject.ToString());
                    case AppType.OnlineNative:
                        return JsonConvert.DeserializeObject<Fdc3App<OnlineNativeAppDetails>>(jsonObject.ToString());
                    default:
                        var app = new Fdc3App();
                        app.Type = appType;
                        serializer.Populate(jsonObject.CreateReader(), app);
                        return app;
            }
        }

        public override void WriteJson(JsonWriter writer, Fdc3App? value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override bool CanRead => true;
        public override bool CanWrite => false;

        private AppType ParseAppType(string? type)
        {
            if (type != null)
            {
                foreach (AppType appType in Enum.GetValues(typeof(AppType))) 
                {
                    if (string.Equals(type, appType.ToString(), StringComparison.OrdinalIgnoreCase))
                    {
                        return appType;
                    }
                }
            }

            return AppType.Other;
        }
    }
}
