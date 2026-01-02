/*
 * SPDX-License-Identifier: Apache-2.0
 * Copyright FINOS FDC3 contributors - see NOTICE file
 */

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace Finos.Fdc3.NewtonsoftJson.Serialization
{
    public class Fdc3JsonSerializerSettings : JsonSerializerSettings
    {
        public Fdc3JsonSerializerSettings()
        {
            this.TypeNameHandling = TypeNameHandling.None;
            this.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            this.DefaultValueHandling = DefaultValueHandling.Populate;
            this.NullValueHandling = NullValueHandling.Ignore;
            this.ContractResolver = new DefaultContractResolver()
            {
                NamingStrategy = new Fdc3CamelCaseNamingStrategy()
            };
            this.Converters = new JsonConverter[]
            {
                new StringEnumConverter(new CamelCaseNamingStrategy()), 
                new RecipientJsonConverter(), 
                new Fdc3AppConverter(), 
                new IntentsConverter()
            };
        }
    }
}