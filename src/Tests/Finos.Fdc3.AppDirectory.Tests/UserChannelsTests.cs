/*
 * SPDX-License-Identifier: Apache-2.0
 * Copyright FINOS FDC3 contributors - see NOTICE file
 */

using System.Collections.Generic;
using Xunit;

namespace Finos.Fdc3.AppDirectory.Tests;

public class UserChannelsTests
{
    [Fact]
    public void UserChannels_Properties_CanBeSetAndGet()
    {
        // Arrange
        var channels = new UserChannels();
        var broadcasts = new[] { "fdc3.instrument", "fdc3.position" };
        var listensFor = new[] { "fdc3.contact", "fdc3.organization" };

        // Act
        channels.Broadcasts = broadcasts;
        channels.ListensFor = listensFor;

        // Assert
        Assert.Equal(broadcasts, channels.Broadcasts);
        Assert.Equal(listensFor, channels.ListensFor);
    }

    [Fact]
    public void UserChannels_Properties_CanBeNull()
    {
        // Arrange & Act
        var channels = new UserChannels();

        // Assert
        Assert.Null(channels.Broadcasts);
        Assert.Null(channels.ListensFor);
    }

    [Fact]
    public void UserChannels_Properties_CanBeEmpty()
    {
        // Arrange
        var channels = new UserChannels();
        var emptyList = new List<string>();

        // Act
        channels.Broadcasts = emptyList;
        channels.ListensFor = emptyList;

        // Assert
        Assert.Empty(channels.Broadcasts);
        Assert.Empty(channels.ListensFor);
    }
}
