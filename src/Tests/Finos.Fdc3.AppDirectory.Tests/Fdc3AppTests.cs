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

using System;
using Xunit;

namespace Finos.Fdc3.AppDirectory.Tests;

public class Fdc3AppTests
{
    [Fact]
    public void Fdc3App_Constructor_SetsProperties()
    {
        // Arrange
        var appId = "test-app";
        var name = "Test App";
        var type = AppType.Web;
        var details = new WebAppDetails("https://example.com");

        // Act
#pragma warning disable CS0618 // Type or member is obsolete
        var app = new Fdc3App(appId, name, type, details);

        // Assert
        Assert.Equal(appId, app.AppId);
        Assert.Equal(name, app.Name);
#pragma warning restore CS0618 // Type or member is obsolete
        Assert.Equal(type, app.Type);
        Assert.Equal(details, app.Details);
    }

    [Fact]
    public void Fdc3App_Constructor_WithNullAppId_ThrowsArgumentNullException()
    {
        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => new Fdc3App(
            null!,
            "Test App",
            AppType.Web,
            new WebAppDetails("https://example.com")));
    }

    [Fact]
    public void Fdc3App_Constructor_WithNullName_ThrowsArgumentNullException()
    {
        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => new Fdc3App(
            "test-app",
            null!,
            AppType.Web,
            new WebAppDetails("https://example.com")));
    }

    [Fact]
    public void Fdc3App_Constructor_WithNullDetails_ThrowsArgumentNullException()
    {
        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => new Fdc3App(
            "test-app",
            "Test App",
            AppType.Web,
            null!));
    }

    [Fact]
    public void Fdc3App_GenericConstructor_SetsProperties()
    {
        // Arrange
        var appId = "test-app";
        var name = "Test App";
        var type = AppType.Web;
        var details = new WebAppDetails("https://example.com");

        // Act
#pragma warning disable CS0618 // Type or member is obsolete
        var app = new Fdc3App<WebAppDetails>(appId, name, type, details);

        // Assert
        Assert.Equal(appId, app.AppId);
        Assert.Equal(name, app.Name);
#pragma warning restore CS0618 // Type or member is obsolete
        Assert.Equal(type, app.Type);
        Assert.Equal(details, app.Details);
    }

    [Fact]
    public void Fdc3App_GenericConstructor_WithWrongDetailsType_ThrowsInvalidCastException()
    {
        // Arrange
        var appId = "test-app";
        var name = "Test App";
        var type = AppType.Web;
        var details = new NativeAppDetails(@"C:\app.exe", null);

        // Act & Assert
        var baseApp = new Fdc3App(appId, name, type, details);
        Assert.Throws<InvalidCastException>(() => _ = (WebAppDetails)baseApp.Details);
    }
}
