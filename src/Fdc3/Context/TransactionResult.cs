/*
 * SPDX-License-Identifier: Apache-2.0
 * Copyright FINOS FDC3 contributors - see NOTICE file
 */

namespace Finos.Fdc3.Context
{
    public class TransactionResult : Context, IContext
    {
        public TransactionResult(string status, IContext? context = null, string? message = null, object? id = null, string? name = null)
            : base(ContextTypes.TransactionResult, id, name)
        {
            this.Status = status;
            this.Context = context;
            this.Message = message;
        }

        public string Status { get; set; }
        public IContext? Context;
        public string? Message {  get; set; }
    }
}
