/*
 * SPDX-License-Identifier: Apache-2.0
 * Copyright FINOS FDC3 contributors - see NOTICE file
 */

namespace Finos.Fdc3.Context
{
    public class Organization : Context<OrganizationID>, IContext
    {
        public Organization(OrganizationID? id = null, string? name = null)
            : base(ContextTypes.Organization, id, name)
        {
        }

        object? IContext<object>.ID => base.ID;
    }

    public class OrganizationID
    {
        public string? FDS_ID { get; set; }
        public string? LEI { get; set; }
        public string? PERMID { get; set; }
    }
}
