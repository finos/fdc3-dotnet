/*
 * SPDX-License-Identifier: Apache-2.0
 * Copyright FINOS FDC3 contributors - see NOTICE file
 */

using Finos.Fdc3.Context;

namespace Finos.Fdc3.Tests.Context;

public class MessageTests
{
    [Fact]
    public void Message_PropertiesMatchParams()
    {
        Message message = new Message(new MessageText() { TextPlain = "textplain", TextMarkdown = "textmarkdown" });

        Assert.Same("textplain", message.Text?.TextPlain);
        Assert.Same("textmarkdown", message.Text?.TextMarkdown);
        Assert.Same(ContextTypes.Message, message?.Type);
    }
}