/*
 * SPDX-License-Identifier: Apache-2.0
 * Copyright FINOS FDC3 contributors - see NOTICE file
 */

using System;
using Xunit;

namespace Finos.Fdc3.AppDirectory.Tests;

public class AppChannelTests
{
    [Fact]
    public void AppChannel_Constructor_SetsProperties()
    {
        // Arrange
        var id = "testChannel";

        // Act
        var channel = new AppChannel(id);

        // Assert
        Assert.Equal(id, channel.ID);
        Assert.Null(channel.Description);
        Assert.Null(channel.Broadcasts);
    }

    [Fact]
    public void AppChannel_Constructor_WithNullId_ThrowsArgumentNullException()
    {
        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => new AppChannel(null!));
    }
}
