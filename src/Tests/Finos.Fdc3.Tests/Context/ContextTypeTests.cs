/*
 * SPDX-License-Identifier: Apache-2.0
 * Copyright FINOS FDC3 contributors - see NOTICE file
 */

using Finos.Fdc3.Context;
using Xunit;

namespace Finos.Fdc3.Tests.Context;

public class ContextTypeTests
{
    [Fact]
    public void Nothing_ReturnsNothingInstance()
    {
        // Act
        var nothing = ContextType.Nothing;

        // Assert
        Assert.NotNull(nothing);
        Assert.IsType<Nothing>(nothing);
        Assert.Equal("fdc3.nothing", nothing.Type);
    }
}
