/*
 * SPDX-License-Identifier: Apache-2.0
 * Copyright FINOS FDC3 contributors - see NOTICE file
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
