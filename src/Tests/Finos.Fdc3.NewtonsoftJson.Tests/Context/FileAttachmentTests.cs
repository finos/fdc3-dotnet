/*
 * SPDX-License-Identifier: Apache-2.0
 * Copyright FINOS FDC3 contributors - see NOTICE file
 */

using Finos.Fdc3.Context;

namespace Finos.Fdc3.NewtonsoftJson.Tests.Context;

public class FileAttachmentTests : ContextSchemaTest
{
    public FileAttachmentTests()
        : base("https://fdc3.finos.org/schemas/2.2/context/fileAttachment.schema.json")
    {
    }

    [Fact]
    public async Task FileAttachment_SerializedJsonMatchesSchema()
    {
        FileAttachment attachment = new FileAttachment(new FileAttachmentData("data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAAgAAAAIAQMAAAD+wSzIAAAABlBMVEX///+/v7+jQ3Y5AAAADklEQVQI12P4AIX8EAgALgAD/aNpbtEAAAAASUVORK5CYII", "name"));
        string json = await this.ValidateSchema(attachment);
    }
}