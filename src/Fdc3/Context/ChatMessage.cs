﻿/*
 * Morgan Stanley makes this available to you under the Apache License,
 * Version 2.0 (the "License"). You may obtain a copy of the License at
 *
 *      http://www.apache.org/licenses/LICENSE-2.0.
 *
 * See the NOTICE file distributed with this work for additional information
 * regarding copyright ownership. Unless required by applicable law or agreed
 * to in writing, software distributed under the License is distributed on an
 * "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express
 * or implied. See the License for the specific language governing permissions
 * and limitations under the License.
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
