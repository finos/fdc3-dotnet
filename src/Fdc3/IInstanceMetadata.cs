/*
 * SPDX-License-Identifier: Apache-2.0
 * Copyright FINOS FDC3 contributors - see NOTICE file
 */

using System.Collections.Generic;

namespace Finos.Fdc3
{
    /// <summary>
    /// Runtime instance metadata for an application, such as window/tab information,
    /// or other application-specific runtime state.
    /// </summary>
    public interface IInstanceMetadata
    {
        /// <summary>
        /// Application-specific metadata that can be used to identify runtime instances or state.
        /// </summary>
        IDictionary<string, object>? Metadata { get; }
    }

    /// <summary>
    /// Concrete implementation of IInstanceMetadata.
    /// </summary>
    public class InstanceMetadata : IInstanceMetadata
    {
        public InstanceMetadata(IDictionary<string, object>? metadata = null)
        {
            this.Metadata = metadata;
        }

        public IDictionary<string, object>? Metadata { get; }
    }
}
