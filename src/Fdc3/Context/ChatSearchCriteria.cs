/*
 * SPDX-License-Identifier: Apache-2.0
 * Copyright FINOS FDC3 contributors - see NOTICE file
 */

using System.Collections;

namespace Finos.Fdc3.Context
{
    public class ChatSearchCriteria : Context, IContext
    {
        public ChatSearchCriteria(IEnumerable criteria, object? id = null, string? name = null)
            : base(ContextTypes.ChatSearchCriteria, id, name)
        {
            this.Criteria = criteria;
        }

        public IEnumerable Criteria { get; set;  }
    }
}
