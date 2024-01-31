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

public class ChartTests
{
    [Fact]
    public void Chart_PropertiesMatchParams()
    {
        Instrument instrument = new Instrument(new InstrumentID { Ticker = "TICKER" });
        TimeRange timeRange = new TimeRange(DateTime.Now.ToString("o"), DateTime.Now.ToString("o"));
        var otherConfig = new { A = "Foo", B = "Bar" };
        Chart chart = new Chart(new Instrument[] { instrument }, timeRange, otherConfig, ChartStyle.Line, null, "chart");

        Assert.Same("TICKER", chart?.Instruments?.First<Instrument>()?.ID?.Ticker);
        Assert.Same(timeRange, chart?.Range);
        Assert.Same(otherConfig, chart?.OtherConfig);
        Assert.Same(ChartStyle.Line, chart?.Style);
        Assert.Same("chart", chart?.Name);
        Assert.Same(ContextTypes.Chart, chart?.Type);
    }
}