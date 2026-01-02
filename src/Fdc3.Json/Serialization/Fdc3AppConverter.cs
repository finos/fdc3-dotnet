/*
 * SPDX-License-Identifier: Apache-2.0
 * Copyright FINOS FDC3 contributors - see NOTICE file
 */

using Finos.Fdc3.AppDirectory;
using System;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace Finos.Fdc3.Json.Serialization
{
    internal class Fdc3AppConverter : JsonConverter<Fdc3App>
    {
        public override bool CanConvert(Type typeToConvert)
        {
            return typeToConvert == typeof(Fdc3App);
        }

        public override Fdc3App? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            Utf8JsonReader readerClone = reader;

            var jsonObject = JsonNode.Parse(ref readerClone);
            if (jsonObject != null && Enum.TryParse(jsonObject["type"]?.ToString(), true, out AppType appType))
            {
                switch (appType)
                {
                    case AppType.Web:
                        return JsonSerializer.Deserialize<Fdc3App<WebAppDetails>>(ref reader, options);
                    case AppType.Citrix:
                        return JsonSerializer.Deserialize<Fdc3App<CitrixAppDetails>>(ref reader, options);
                    case AppType.Native:
                        return JsonSerializer.Deserialize<Fdc3App<NativeAppDetails>>(ref reader, options);
                    case AppType.OnlineNative:
                        return JsonSerializer.Deserialize<Fdc3App<OnlineNativeAppDetails>>(ref reader, options);
                    case AppType.Other:
                        return JsonSerializer.Deserialize<Fdc3App<object>>(ref reader, options);
                }
            }

            throw new InvalidOperationException("Unknown AppType. Possible values are: web, native, citrix, onlineNative, other");
        }

        public override void Write(Utf8JsonWriter writer, Fdc3App value, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }
    }
}
