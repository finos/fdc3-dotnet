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
