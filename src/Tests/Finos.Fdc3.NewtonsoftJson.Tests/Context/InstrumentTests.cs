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

using Finos.Fdc3.Context;

namespace Finos.Fdc3.NewtonsoftJson.Tests.Context;

public class InstrumentTests : ContextSchemaTest
{
    public InstrumentTests()
        : base("https://fdc3.finos.org/schemas/2.0/instrument.schema.json")
    {
    }

    [Fact]
    public async void Instrument_SerializedJsonMatchesSchema()
    {
        Instrument instrument = new Instrument(
            new InstrumentID
            {
                BBG = "BBG",
                CUSIP = "CUSIP",
                FDS_ID = "FDS_ID",
                FIGI = "FIGI",
                ISIN = "ISIN",
                PERMID = "PERMID",
                RIC = "RIC",
                SEDOL = "SEDOL",
                Ticker = "TICKER"
            }, "Instrument");

        await this.ValidateSchema(instrument);
    }
}