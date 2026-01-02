/*
 * SPDX-License-Identifier: Apache-2.0
 * Copyright FINOS FDC3 contributors - see NOTICE file
 */

namespace Finos.Fdc3.Context
{
    public class Message : Context, IContext
    {
        public Message(MessageText? text, object? id = null, string? name = null)
            : base(ContextTypes.Message, id, name)
        {
            this.Text = text;
        }

        public MessageText? Text { get; set; }
    }

    public class MessageText
    {
        public string? TextPlain { get; set; }
        public string? TextMarkdown { get; set; }
    }
}
