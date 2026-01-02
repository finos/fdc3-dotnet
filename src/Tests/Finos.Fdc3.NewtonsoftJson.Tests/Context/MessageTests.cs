/*
 * SPDX-License-Identifier: Apache-2.0
 * Copyright FINOS FDC3 contributors - see NOTICE file
 */

using Finos.Fdc3.Context;

namespace Finos.Fdc3.NewtonsoftJson.Tests.Context;

public class MessageTests : ContextSchemaTest
{
    public MessageTests()
        : base("https://fdc3.finos.org/schemas/2.2/context/message.schema.json")
    {
    }

    [Fact]
    public async Task Message_SerializedJsonMatchesSchema()
    {
        Message message = new Message(new MessageText() { TextPlain = "textplain", TextMarkdown = "textmarkdown" });
        string json = await this.ValidateSchema(message);
    }
}