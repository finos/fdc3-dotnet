/*
 * SPDX-License-Identifier: Apache-2.0
 * Copyright FINOS FDC3 contributors - see NOTICE file
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
