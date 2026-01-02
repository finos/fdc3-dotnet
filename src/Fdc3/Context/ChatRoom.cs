/*
 * SPDX-License-Identifier: Apache-2.0
 * Copyright FINOS FDC3 contributors - see NOTICE file
 */

namespace Finos.Fdc3.Context
{
    public class ChatRoom : Context, IContext, IRecipient
    {
        public ChatRoom(object id, string providerName, string? url = null, string? name = null)
            : base(ContextTypes.ChatRoom, id, name)
        {
            this.ProviderName = providerName;
            this.Url = url;
        }

        public string ProviderName { get; set;  }
        public string? Url { get; set; }
    }
}
