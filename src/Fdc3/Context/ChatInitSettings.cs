/*
 * SPDX-License-Identifier: Apache-2.0
 * Copyright FINOS FDC3 contributors - see NOTICE file
 */

namespace Finos.Fdc3.Context
{
    public class ChatInitSettings : Context, IContext
    {
        public ChatInitSettings(ContactList? members = null, Message? message = null, string? chatName = null, ChatInitSettingsOptions? options = null, object? id = null, string? name = null)
            : base(ContextTypes.ChatInitSettings, id, name)
        {
            this.Members = members;
            this.Message = message;
            this.ChatName = chatName;
            this.Options = options;
        }

        public string? ChatName { get; set; }
        public Message? Message { get; set; }
        public ContactList? Members { get; set; }
        public ChatInitSettingsOptions? Options { get; set; }

        object? IContext<object>.ID => base.ID;
    }

    public class ChatInitSettingsOptions
    {
        public bool? GroupRecipients { get; set; }
        public bool? IsPublic { get; set; }
        public bool? AllowHistoryBrowsing { get; set; }
        public bool? AllowMessageCopy { get; set; }
        public bool? AllowAddUser { get; set; }
    }
}
