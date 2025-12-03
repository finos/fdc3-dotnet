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

public class ActionTests
{
    [Fact]
    public void Action_PropertiesMatchParams()
    {
        Instrument instrument = new Instrument(new InstrumentID { Ticker = "TICKER" });
        Fdc3.Context.Action action = new Fdc3.Context.Action("title", instrument, "ViewInstrument", new AppIdentifier("appid", "instanceid"));

        Assert.Same("title", action.Title);
        Assert.Equal(instrument, action.Context);
        Assert.Same("TICKER", (action.Context as Instrument)?.ID?.Ticker);
        Assert.Same("appid", action.App?.AppId);
        Assert.Same("instanceid", action.App?.InstanceId);
        
    }

    [Fact]
    public void Action_BroadcastActionProperties()
    {
        Instrument instrument = new Instrument(new InstrumentID { Ticker = "TICKER" });
        Fdc3.Context.Action action = new Fdc3.Context.Action(
            "Broadcast to Channel", 
            instrument, 
            null, 
            null,
            ActionTypes.Broadcast, 
            "Channel 1"
        );

        Assert.Equal("Broadcast to Channel", action.Title);
        Assert.Equal(instrument, action.Context);
        Assert.Equal(ActionTypes.Broadcast, action.ActionType);
        Assert.Equal("Channel 1", action.ChannelId);
        Assert.Null(action.Intent);
        Assert.Null(action.App);
    }

    [Fact]
    public void Action_RaiseIntentActionProperties()
    {
        Instrument instrument = new Instrument(new InstrumentID { Ticker = "TICKER" });
        Fdc3.Context.Action action = new Fdc3.Context.Action(
            "Raise Intent", 
            instrument, 
            "ViewChart",
            new AppIdentifier("chartApp"),
            ActionTypes.RaiseIntent
        );

        Assert.Equal("Raise Intent", action.Title);
        Assert.Equal(instrument, action.Context);
        Assert.Equal(ActionTypes.RaiseIntent, action.ActionType);
        Assert.Equal("ViewChart", action.Intent);
        Assert.Equal("chartApp", action.App?.AppId);
        Assert.Null(action.ChannelId);
    }
}