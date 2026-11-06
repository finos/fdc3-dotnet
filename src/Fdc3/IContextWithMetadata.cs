/*
 * SPDX-License-Identifier: Apache-2.0
 * Copyright FINOS FDC3 contributors - see NOTICE file
 */

using Finos.Fdc3.Context;

namespace Finos.Fdc3
{
    /// <summary>
    /// Wrapper interface combining a context with its metadata.
    /// Used to return context and metadata together from channel operations.
    /// </summary>
    public interface IContextWithMetadata
    {
        /// <summary>
        /// The context object.
        /// </summary>
        IContext Context { get; }

        /// <summary>
        /// The metadata associated with the context.
        /// </summary>
        IContextMetadata Metadata { get; }
    }

    /// <summary>
    /// Concrete implementation of IContextWithMetadata.
    /// </summary>
    public class ContextWithMetadata : IContextWithMetadata
    {
        public ContextWithMetadata(IContext context, IContextMetadata metadata)
        {
            this.Context = context ?? throw new System.ArgumentNullException(nameof(context));
            this.Metadata = metadata ?? throw new System.ArgumentNullException(nameof(metadata));
        }

        public IContext Context { get; }

        public IContextMetadata Metadata { get; }
    }
}
