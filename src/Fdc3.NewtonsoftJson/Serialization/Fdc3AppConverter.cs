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
    public class Fdc3AppConverter : JsonConverter
    {
        public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
        {
            var jsonObject = JObject.Load(reader);

            if (Enum.TryParse(jsonObject["type"]?.ToString(), true, out AppType appType))
            {
                switch (appType)
                {
                    case AppType.Web:
                        return serializer.Deserialize<Fdc3App<WebAppDetails>>(jsonObject.CreateReader());
                    case AppType.Citrix:
                        return serializer.Deserialize<Fdc3App<CitrixAppDetails>>(jsonObject.CreateReader());
                    case AppType.Native:
                        return serializer.Deserialize<Fdc3App<NativeAppDetails>>(jsonObject.CreateReader());
                    case AppType.OnlineNative:
                        return serializer.Deserialize<Fdc3App<OnlineNativeAppDetails>>(jsonObject.CreateReader());
                    case AppType.Other:
                        return serializer.Deserialize<Fdc3App<object>>(jsonObject.CreateReader());
                }
            }

            throw new InvalidOperationException("Unknown AppType. Possible values are: web, native, citrix, onlineNative, other");
        }

        public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Fdc3App);
        }

        public override bool CanRead => true;
        public override bool CanWrite => false;
    }
}
