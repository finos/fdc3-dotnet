﻿
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

using MorganStanley.Fdc3.Json.Serialization;
using System.Text.Json;

namespace MorganStanley.Fdc3.AppDirectory.Tests
{
    public partial class DeserializationTest
    {
        [Fact]
        public void AppDAppDeserializationTest_SystemTextJson()
        {
            string jsonString = File.ReadAllText("TestJsons\\SampleAppForInterop.json");

#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            Fdc3App app = JsonSerializer.Deserialize<Fdc3App>(jsonString, Fdc3JsonSerializerOptions.Create());
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

            ValidateApp(app!);
        }
    }
}
