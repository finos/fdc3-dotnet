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

namespace Finos.Fdc3.Tests.Context;

public class InstrumentTests
{
    [Fact]
    public void Instrument_PropertiesMatchParams()
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

        Assert.Same("BBG", instrument?.ID?.BBG);
        Assert.Same("CUSIP", instrument?.ID?.CUSIP);
        Assert.Same("FDS_ID", instrument?.ID?.FDS_ID);
        Assert.Same("FIGI", instrument?.ID?.FIGI);
        Assert.Same("ISIN", instrument?.ID?.ISIN);
        Assert.Same("PERMID", instrument?.ID?.PERMID);
        Assert.Same("RIC", instrument?.ID?.RIC);
        Assert.Same("SEDOL", instrument?.ID?.SEDOL);
        Assert.Same("TICKER", instrument?.ID?.Ticker);
        Assert.Same("Instrument", instrument?.Name);
        Assert.Same(ContextTypes.Instrument, instrument?.Type);
    }
}