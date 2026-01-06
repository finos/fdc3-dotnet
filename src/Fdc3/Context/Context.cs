/*
 * SPDX-License-Identifier: Apache-2.0
 * Copyright FINOS FDC3 contributors - see NOTICE file
 */

using System;

namespace Finos.Fdc3.Context
{
    public class Context<T> : IContext<T> where T : class
    {
        public Context(string type, T? id = null, string? name = null)
        {
            this.Type = type ?? throw new ArgumentNullException(nameof(type));
            this.ID = id;
            this.Name = name;
        }

        public T? ID { get; }

        public string? Name { get; }

        public string Type { get; }

        dynamic? IDynamicContext.Native { get; set; }
    }

    public class Context : Context<object>, IContext
    {
        public Context(string type, object? id = null, string? name = null) : base(type, id, name)
        {
        }
    }
}
