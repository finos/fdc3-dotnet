/*
 * SPDX-License-Identifier: Apache-2.0
 * Copyright FINOS FDC3 contributors - see NOTICE file
 */

namespace Finos.Fdc3.Context
{
    public class ChatMessage : Context, IContext, IRecipient
    {
        public ChatMessage(ChatRoom chatRoom, Message message, object? id = null, string? name = null)
            : base(ContextTypes.ChatMessage, id, name)
        {
            this.ChatRoom = chatRoom;
            this.Message = message;
        }

        public ChatRoom ChatRoom { get; set; }
        public Message Message { get; set; }
    }
}
