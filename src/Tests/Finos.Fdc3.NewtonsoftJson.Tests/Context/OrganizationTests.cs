/*
 * SPDX-License-Identifier: Apache-2.0
 * Copyright FINOS FDC3 contributors - see NOTICE file
 */

using Finos.Fdc3.Context;

namespace Finos.Fdc3.NewtonsoftJson.Tests.Context;

public class OrganizationTests : ContextSchemaTest
{
    public OrganizationTests()
        : base("https://fdc3.finos.org/schemas/2.2/context/organization.schema.json")
    {
    }

    [Fact]
    public async Task Organization_SerializedJsonMatchesSchema()
    {
        Organization organization = new Organization(new OrganizationID() { FDS_ID = "fds_id", LEI = "lei", PERMID = "permid" }, "organization");

        await this.ValidateSchema(organization);
    }
}