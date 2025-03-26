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

public class AppDetailsTests
{
    [Fact]
    public void WebAppDetails_Constructor_SetsProperties()
    {
        // Arrange
        var url = "https://example.com";

        // Act
        var details = new WebAppDetails(url);

        // Assert
        Assert.Equal(url, details.Url);
    }

    [Fact]
    public void NativeAppDetails_Constructor_SetsProperties()
    {
        // Arrange
        var path = @"C:\Program Files\App\app.exe";
        var arguments = "--start";

        // Act
        var details = new NativeAppDetails(path, arguments);

        // Assert
        Assert.Equal(path, details.Path);
        Assert.Equal(arguments, details.Arguments);
    }

    [Fact]
    public void OnlineNativeAppDetails_Constructor_SetsProperties()
    {
        // Arrange
        var url = "https://example.com";

        // Act
        var details = new OnlineNativeAppDetails(url);

        // Assert
        Assert.Equal(url, details.Url);
    }

    [Fact]
    public void CitrixAppDetails_Constructor_SetsProperties()
    {
        // Arrange
        var alias = "citrix-app-alias";
        var arguments = "--start";

        // Act
        var details = new CitrixAppDetails(alias, arguments);

        // Assert
        Assert.Equal(alias, details.Alias);
        Assert.Equal(arguments, details.Arguments);
    }

    [Fact]
    public void WebAppDetails_Constructor_WithNullUrl_ThrowsArgumentNullException()
    {
        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => new WebAppDetails(null!));
    }

    [Fact]
    public void NativeAppDetails_Constructor_WithNullPath_ThrowsArgumentNullException()
    {
        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => new NativeAppDetails(null!, null));
    }

    [Fact]
    public void CitrixAppDetails_Constructor_WithNullAlias_ThrowsArgumentNullException()
    {
        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => new CitrixAppDetails(null!, null));
    }
}
