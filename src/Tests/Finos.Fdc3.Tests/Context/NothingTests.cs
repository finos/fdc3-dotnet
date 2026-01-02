/*
 * SPDX-License-Identifier: Apache-2.0
 * Copyright FINOS FDC3 contributors - see NOTICE file
 */

using Finos.Fdc3.Context;

namespace Finos.Fdc3.Tests.Context;

public class NothingTests
{
    [Fact]
    public void Nothing_ContextTypeDefined()
    {
        Nothing nothing = new Nothing();
        Assert.Same(ContextTypes.Nothing, nothing.Type);
    }
}