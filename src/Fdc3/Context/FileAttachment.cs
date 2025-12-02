/*
 * SPDX-License-Identifier: Apache-2.0
 * Copyright FINOS FDC3 contributors - see NOTICE file
 */

namespace Finos.Fdc3.Context
{
    public class FileAttachment : Context, IContext
    {
        public FileAttachment(FileAttachmentData data, object? id = null, string? name = null)
            : base(ContextTypes.FileAttachment, id, name)
        {
            this.Data = data;
        }

        public FileAttachmentData Data { get; set; }
    }

    public class FileAttachmentData
    {
        public FileAttachmentData(string dataUri, string name)
        {
            this.DataUri = dataUri;
            this.Name = name;
        }

        public string DataUri { get; set; }
        public string Name { get; set; }
    }    
}
