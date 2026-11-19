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
    /// Serialized as a flat key-value record (not a nested object).
    /// </summary>
    public interface IInstanceMetadata : IDictionary<string, object>
    {
    }

    /// <summary>
    /// Concrete implementation of IInstanceMetadata as a dictionary of instance properties.
    /// </summary>
    public class InstanceMetadata : Dictionary<string, object>, IInstanceMetadata
    {
        public InstanceMetadata()
        {
        }

        public InstanceMetadata(IDictionary<string, object>? metadata)
        {
            if (metadata != null)
            {
                foreach (var kvp in metadata)
                {
                    this[kvp.Key] = kvp.Value;
                }
            }
        }
    }
}
