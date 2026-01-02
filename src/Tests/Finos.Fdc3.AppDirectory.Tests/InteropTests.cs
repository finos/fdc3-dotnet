/*
 * SPDX-License-Identifier: Apache-2.0
 * Copyright FINOS FDC3 contributors - see NOTICE file
 */

using System.Collections.Generic;
using Xunit;

namespace Finos.Fdc3.AppDirectory.Tests;

public class InteropTests
{
    [Fact]
    public void Interop_Properties_CanBeSetAndGet()
    {
        // Arrange
        var interop = new Interop();
        var intents = new Intents
        {
            ListensFor = new Dictionary<string, IntentMetadata>
            {
                { "ViewChart", new IntentMetadata("ViewChart", "View Chart", new[] { "fdc3.instrument" }) }
            }
        };
        var userChannels = new UserChannels
        {
            Broadcasts = new[] { "fdc3.instrument" },
            ListensFor = new[] { "fdc3.contact" }
        };
        var appChannels = new[]
        {
            new AppChannel("channel1") { Description = "First Channel" },
            new AppChannel("channel2") { Description = "Second Channel" }
        };

        // Act
        interop.Intents = intents;
        interop.UserChannels = userChannels;
        interop.AppChannels = appChannels;

        // Assert
        Assert.Equal(intents, interop.Intents);
        Assert.Equal(userChannels, interop.UserChannels);
        Assert.Equal(appChannels, interop.AppChannels);
    }

    [Fact]
    public void Interop_Properties_CanBeNull()
    {
        // Arrange & Act
        var interop = new Interop();

        // Assert
        Assert.Null(interop.Intents);
        Assert.Null(interop.UserChannels);
        Assert.Null(interop.AppChannels);
    }

    [Fact]
    public void Interop_Properties_CanBeEmpty()
    {
        // Arrange
        var interop = new Interop();
        var emptyIntents = new Intents();
        var emptyUserChannels = new UserChannels();
        var emptyAppChannels = new List<AppChannel>();

        // Act
        interop.Intents = emptyIntents;
        interop.UserChannels = emptyUserChannels;
        interop.AppChannels = emptyAppChannels;

        // Assert
        Assert.NotNull(interop.Intents);
        Assert.NotNull(interop.UserChannels);
        Assert.NotNull(interop.AppChannels);
        Assert.Empty(interop.AppChannels);
    }
}
