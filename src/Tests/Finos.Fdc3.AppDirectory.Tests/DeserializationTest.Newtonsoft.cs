/*
 * SPDX-License-Identifier: Apache-2.0
 * Copyright FINOS FDC3 contributors - see NOTICE file
 */

using Finos.Fdc3.NewtonsoftJson.Serialization;
using Newtonsoft.Json;

namespace Finos.Fdc3.AppDirectory.Tests
{
    public partial class DeserializationTest
    {
        [Fact]
        public void AppDAppDeserializationTest_Newtonsoft()
        {
            string jsonString = File.ReadAllText("TestJsons\\SampleAppForInterop.json");

#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            Fdc3App app = JsonConvert.DeserializeObject<Fdc3App>(jsonString, new Fdc3JsonSerializerSettings());
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

            ValidateApp(app!);
        }
    }
}