/*
 * SPDX-License-Identifier: Apache-2.0
 * Copyright FINOS FDC3 contributors - see NOTICE file
 */

using Finos.Fdc3.Context;

namespace Finos.Fdc3.Tests.Context;

public class OrganizationTests
{
    [Fact]
    public void Organization_PropertiesMatchParams()
    {
        Organization organization = new Organization(new OrganizationID() { FDS_ID = "fdc_id", LEI = "lei", PERMID = "permid" }, "organization");

        Assert.Same("fdc_id", organization?.ID?.FDS_ID);
        Assert.Same("organization", organization?.Name);
        Assert.Same(ContextTypes.Organization, organization?.Type);
    }
}