/*
 * SPDX-License-Identifier: Apache-2.0
 * Copyright FINOS FDC3 contributors - see NOTICE file
 */

namespace Finos.Fdc3.Context
{
    public class Email : Context, IContext
    {
        public Email(IRecipient recipients, string? subject = null, string? textBody = null, object? id = null, string? name = null)
            : base(ContextTypes.Email, id, name)
        {
            this.Recipients = recipients;
            this.Subject = subject;
            this.TextBody = textBody;
        }

        public IRecipient Recipients { get; set; }
        public string? Subject { get; set; }
        public string? TextBody { get; set; }

        object? IContext<object>.ID => base.ID;
    }
}
