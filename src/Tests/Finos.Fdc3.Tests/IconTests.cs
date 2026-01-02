/*
 * SPDX-License-Identifier: Apache-2.0
 * Copyright FINOS FDC3 contributors - see NOTICE file
 */

namespace Finos.Fdc3.Tests;

public class IconTests
{
    [Fact]
    public void Icon_NullSrc_ThrowsArgumentNullException()
    {
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
        Assert.Throws<ArgumentNullException>(() => new Icon(null));
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
    }

    [Fact]
    public void Icon_DefaultParams_AllNull()
    {
        IIcon icon = new Icon("src");
        Assert.Null(icon.Size);
        Assert.Null(icon.Type);
    }

    [Fact]
    public void Icon_PropertiesMatchParams()
    {
        IIcon icon = new Icon("src", "size", "type");
        Assert.Same("src", icon.Src);
        Assert.Same("size", icon.Size);
        Assert.Same("type", icon.Type);
    }
}