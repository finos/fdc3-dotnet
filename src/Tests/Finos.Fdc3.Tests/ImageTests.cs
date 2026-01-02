/*
 * SPDX-License-Identifier: Apache-2.0
 * Copyright FINOS FDC3 contributors - see NOTICE file
 */

namespace Finos.Fdc3.Tests;

public class ImageTests
{
    [Fact]
    public void Image_NullSrc_ThrowsArgumentNullException()
    {
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
        Assert.Throws<ArgumentNullException>(() => new Image(null));
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
    }

    [Fact]
    public void Image_DefaultParams_AllNull()
    {
        IImage image = new Image("src");
        Assert.Null(image.Size);
        Assert.Null(image.Type);
        Assert.Null(image.Label);
    }

    [Fact]
    public void Image_PropertiesMatchParams()
    {
        IImage image = new Image("src", "size", "type", "label");
        Assert.Same("src", image.Src);
        Assert.Same("size", image.Size);
        Assert.Same("type", image.Type);
        Assert.Same("label", image.Label);
    }
}