/*
 * SPDX-License-Identifier: Apache-2.0
 * Copyright FINOS FDC3 contributors - see NOTICE file
 */

namespace Finos.Fdc3.Context
{
    public class Contact : Context<ContactID>, IContext, IRecipient
    {
        public Contact(ContactID? id = null, string? name = null)
            : base(ContextTypes.Contact, id, name)
        {
        }

        object? IContext<object>.ID => base.ID;
    }

    public class ContactID
    {
        public string? Email { get; set; }

        public string? FDS_ID { get; set; }
    }
}
