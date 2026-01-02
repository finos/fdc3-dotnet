/*
 * SPDX-License-Identifier: Apache-2.0
 * Copyright FINOS FDC3 contributors - see NOTICE file
 */

namespace Finos.Fdc3
{
    /// <summary>
    ///  Metadata relating to a context or intent and context received through the `AddContextListener` and `AddIntentListener` functions.
    ///  
    /// Introduced in FDC3 2.0 and may be refined by further changes outside the normal FDC3 versioning policy.
    /// </summary>
    public class ContextMetadata : IContextMetadata
    {
        public ContextMetadata()
        {
        }

        public ContextMetadata(IAppIdentifier? source = null) : this()
        {
            this.Source = source;
        }

        /// <summary>
        /// Identifier for the app instance that sent the context and/or intent.
        /// </summary>
        public IAppIdentifier? Source { get; }
    }
}
