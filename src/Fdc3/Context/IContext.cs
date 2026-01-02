/*
 * SPDX-License-Identifier: Apache-2.0
 * Copyright FINOS FDC3 contributors - see NOTICE file
 */

namespace Finos.Fdc3.Context
{
    public interface IDynamicContext
    {
        dynamic? Native { get; set; }
    }

    public interface IContext<out T>: IIntentResult, IDynamicContext where T : class
    {
        T? ID { get; }

        string? Name { get; }

        string Type { get; }
    }

    public interface IContext : IContext<object>
    {
    }
}
