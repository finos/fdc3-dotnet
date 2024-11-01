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

public class TimeRangeTests
{
    [Fact]
    public void TimeRange_PropertiesMatchParams()
    {
        string startTime = DateTime.Now.ToString("o");
        string endTime = DateTime.Now.ToString("o");

        TimeRange timeRange = new TimeRange(
            startTime,
            endTime,
            null,
            "timerange");

        Assert.Same(startTime, timeRange.StartTime);
        Assert.Same(endTime, timeRange.EndTime);
        Assert.Same("timerange", timeRange.Name);
        Assert.Same(ContextTypes.TimeRange, timeRange.Type);
    }
}