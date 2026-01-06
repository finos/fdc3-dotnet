/*
 * SPDX-License-Identifier: Apache-2.0
 * Copyright FINOS FDC3 contributors - see NOTICE file
 */

using System.Threading.Tasks;

namespace Finos.Fdc3
{
    public interface IListener
    {
        /// <summary>
        /// Unsubscribe the listener object.
        /// </summary>
        Task Unsubscribe();
    }
}
