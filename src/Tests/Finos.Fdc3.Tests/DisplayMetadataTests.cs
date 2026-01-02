/*
 * SPDX-License-Identifier: Apache-2.0
 * Copyright FINOS FDC3 contributors - see NOTICE file
 */

namespace Finos.Fdc3.Tests;

public class DisplayMetadataTests
{
    [Fact]
    public void DisplayMetadata_NoParams_NullProperties()
    {
        IDisplayMetadata metadata = new DisplayMetadata();
        Assert.Null(metadata.Name);
        Assert.Null(metadata.Color);
        Assert.Null(metadata.Glyph);
    }

    [Fact]
    public void DisplayMetadata_PropartiesMatchParams()
    {
        IDisplayMetadata metadata = new DisplayMetadata("name", "color", "glyph");
        Assert.Same("name", metadata.Name);
        Assert.Same("color", metadata.Color);
        Assert.Same("glyph", metadata.Glyph);
    }
}