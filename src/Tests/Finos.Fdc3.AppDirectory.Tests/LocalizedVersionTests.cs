/*
 * SPDX-License-Identifier: Apache-2.0
 * Copyright FINOS FDC3 contributors - see NOTICE file
 */

using Xunit;

namespace Finos.Fdc3.AppDirectory.Tests;

public class LocalizedVersionTests
{
    [Fact]
    public void LocalizedVersion_Properties_CanBeSetAndGet()
    {
        // Arrange
        var version = new LocalizedVersion();
        var title = "Localized Title";
        var description = "Localized Description";

        // Act
        version.Title = title;
        version.Description = description;

        // Assert
        Assert.Equal(title, version.Title);
        Assert.Equal(description, version.Description);
    }

    [Fact]
    public void LocalizedVersion_Properties_CanBeNull()
    {
        // Arrange & Act
        var version = new LocalizedVersion();

        // Assert
        Assert.Null(version.Title);
        Assert.Null(version.Description);
    }
}
