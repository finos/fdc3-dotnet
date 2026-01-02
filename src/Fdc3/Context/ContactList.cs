/*
 * SPDX-License-Identifier: Apache-2.0
 * Copyright FINOS FDC3 contributors - see NOTICE file
 */

using System.Collections.Generic;
using System.Linq;

namespace Finos.Fdc3.Context
{
    public class ContactList : Context, IRecipient
    {
        public ContactList(IEnumerable<Contact>? contacts = null, string? name = null, object? id = null)
            : base(ContextTypes.ContactList, id, name)
        {
            this.Contacts = contacts ?? Enumerable.Empty<Contact>();
        }

        public IEnumerable<Contact> Contacts { get; }
    }
}
