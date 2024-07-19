
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

namespace Finos.Fdc3.AppDirectory.Tests
{
    public partial class DeserializationTest
    {
        protected void ValidateApp(Fdc3App app)
        {
            Assert.Equal("my-application", app!.AppId);
#pragma warning disable CS0618 // Type or member is obsolete
            Assert.Equal("my-application", app.Name);
#pragma warning restore CS0618 // Type or member is obsolete
            Assert.Equal("My Application", app.Title);
            Assert.Equal("An example application that uses FDC3 and fully describes itself in an AppD record.", app.Description);
            Assert.Equal("1.0.0", app.Version);
            Assert.Equal("My example application definition", app.ToolTip);
            Assert.Equal("en-US", app.Lang);
            Assert.Equal("fdc3@finos.org", app.ContactEmail);
            Assert.Equal("fdc3-maintainers@finos.org", app.SupportEmail);
            Assert.Equal("http://example.domain.com/", app.MoreInfo);
            Assert.Equal("Example App, Inc.", app.Publisher);
            Assert.Equal(AppType.Web, app.Type);
            Assert.Equal(3, app.Categories!.Count()!);
            Assert.Contains("market data", app.Categories!);
            Assert.Contains("research", app.Categories!);
            Assert.Contains("news", app.Categories!);
            Assert.Single(app.Icons!);
            Assert.Equal("http://example.domain.com/assets/my-app-icon.png", app.Icons!.First().Src);
            Assert.Equal("256x256", app.Icons!.First().Size);
            Assert.Equal("image/png", app.Icons!.First().Type);
            Assert.Equal(2, app.Screenshots!.Count());
            Assert.Equal("http://example.domain.com/assets/my-app-screenshot-1.png", app.Screenshots!.First().Src);
            Assert.Equal("The first screenshot of my example app", app.Screenshots!.First().Label);
            Assert.Equal("image/png", app.Screenshots!.First().Type);
            Assert.Equal("800x600", app.Screenshots!.First().Size);
            Assert.IsType<WebAppDetails>(app.Details);
            Assert.Equal("http://example.domain.com/app.html", ((WebAppDetails)app.Details).Url);
            Assert.Contains("Finsemble", app.HostManifests!.Keys);
            Assert.Contains("Glue42", app.HostManifests.Keys);
            Assert.Contains("Web App Manifest", app.HostManifests.Keys);
            Assert.Contains("ViewChart", app.Interop!.Intents!.ListensFor!.Keys);
            Assert.Contains("myApp.GetPrice", app.Interop.Intents.ListensFor.Keys);
            Assert.Contains("fdc3.instrument", app.Interop!.Intents!.ListensFor!["myApp.GetPrice"].Contexts!);
#pragma warning disable CS0618 // Type or member is obsolete
            Assert.Equal("Get Price", app.Interop!.Intents!.ListensFor!["myApp.GetPrice"].DisplayName);
#pragma warning restore CS0618 // Type or member is obsolete
            Assert.Equal("myApp.quote", app.Interop!.Intents!.ListensFor!["myApp.GetPrice"].ResultType);
            Assert.Equal("ViewChart", app.Interop!.Intents!.ListensFor!["ViewChart"].Name);
            Assert.Equal("myApp.GetPrice", app.Interop!.Intents!.ListensFor!["myApp.GetPrice"].Name);
            Assert.Contains("ViewOrders", app.Interop.Intents.Raises!.Keys);
            Assert.Contains("fdc3.instrument", app.Interop.Intents.Raises!["ViewOrders"]);
            Assert.Contains("StartEmail", app.Interop.Intents.Raises.Keys);
            Assert.Equal(2, app.Interop.UserChannels!.Broadcasts!.Count()!);
            Assert.Equal(2, app.Interop.UserChannels!.ListensFor!.Count()!);
            Assert.Contains("fdc3.instrument", app.Interop!.UserChannels!.Broadcasts!);
            Assert.Contains("fdc3.organization", app.Interop!.UserChannels!.ListensFor!);
            Assert.Single(app.Interop.AppChannels!);
            Assert.Equal("myApp.quotes,", app.Interop!.AppChannels!.First().Name);
            Assert.Contains("myApp.quote", app.Interop.AppChannels!.First().Broadcasts!);
            Assert.Contains("fdc3.instrument", app.Interop.AppChannels!.First().ListensFor!);
            Assert.Contains("fr-FR", app.LocalizedVersions!.Keys);
        }
    }
}
