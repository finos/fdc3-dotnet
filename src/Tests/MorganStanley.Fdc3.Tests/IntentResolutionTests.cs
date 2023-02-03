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

namespace MorganStanley.Fdc3.Tests;

public class IntentResolutionTests
{
    [Fact]
    public void IntentResolution_NullSource_ArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() => new MockIntentResolution(null, "intent", "version"));
    }

    [Fact]
    public void IntentResolution_NullIntent_ArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() => new MockIntentResolution(new AppMetadata("appid"), null, "version"));
    }

    [Fact]
    public void IntentResolution_NullVersion_NullVersion()
    {
        Assert.Null(new MockIntentResolution(new AppMetadata("appid"), "intent").Version);
    }

    [Fact]
    public void IntentResolution_PropertiesMatchParams()
    {
        IAppMetadata appMetadata = new AppMetadata("appid");
        IntentResolution intentResolution = new MockIntentResolution(appMetadata, "intent", "version");
        Assert.Same(appMetadata, intentResolution.Source);
        Assert.Same("intent", intentResolution.Intent);
        Assert.Same("version", intentResolution.Version);
    }

    public class MockIntentResolution : IntentResolution
    {
        public MockIntentResolution(IAppMetadata source, string intent, string? version = null)
            : base(source, intent, version)
        {
        }

        public override Task<IIntentResult> GetResult()
        {
            throw new NotImplementedException();
        }
    }
}