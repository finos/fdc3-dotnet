/*
 * SPDX-License-Identifier: Apache-2.0
 * Copyright FINOS FDC3 contributors - see NOTICE file
 */

using Finos.Fdc3.Context;

namespace Finos.Fdc3.NewtonsoftJson.Tests.Context;

public class NothingTests : ContextSchemaTest
{
    public NothingTests()
        : base("https://fdc3.finos.org/schemas/2.2/context/nothing.schema.json")
    {
    }

    [Fact]
    public async Task Nothing_SerializedJsonMatchesSchema()
    {
        Nothing nothing = new Nothing();

        await this.ValidateSchema(nothing);
    }
}