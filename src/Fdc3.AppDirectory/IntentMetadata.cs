/*
 * SPDX-License-Identifier: Apache-2.0
 * Copyright FINOS FDC3 contributors - see NOTICE file
 */

using System;
using System.Collections.Generic;

namespace Finos.Fdc3.AppDirectory
{
    /// <summary>
    /// Implementation of <see cref="IIntentMetadata"/>
    /// </summary>
    public class IntentMetadata : IIntentMetadata
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IntentMetadata"/> class.
        /// </summary>
        /// <param name="name">The name</param>
        /// <param name="displayName">The displayName</param>
        /// <param name="contexts">The contexts</param>
        /// <exception cref="ArgumentNullException">Exception contexts is null</exception>
        public IntentMetadata(string name, string displayName, IEnumerable<string> contexts)
        {
            Name = name;
#pragma warning disable CS0618 // Type or member is obsolete
            DisplayName = displayName;
#pragma warning restore CS0618 // Type or member is obsolete
            Contexts = contexts ?? throw new ArgumentNullException(nameof(contexts));
        }

        /// <summary>
        /// Definition of an intent that an app listens for
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// An optional display name for the intent that may be used in UI instead of the name.
        /// </summary>
        [Obsolete("Use the intent name for display as display name may vary for each application as it is defined in the app's AppD record.")]
        public string? DisplayName { get; set; }

        /// <summary>
        /// A comma separated list of the types of contexts the intent offered by the application
        /// can process, where the first part of the context type is the namespace e.g."fdc3.contact,
        /// org.symphony.contact"
        /// </summary>
        public IEnumerable<string> Contexts { get; set; }

        /// <summary>
        /// An optional type for output returned by the application, if any, when resolving this intent.
        /// May indicate a context type by type name (e.g. "fdc3.instrument"), a channel (e.g. "channel")
        /// or a combination that indicates a channel that returns a particular
        /// context type (e.g. "channel<fdc3.instrument>").
        /// </summary>
        public string? ResultType { get; set; }

        /// <summary>
        /// Custom configuration for the intent that may be required for a particular desktop agent.
        /// </summary>
        public object? CustomConfig { get; set; }
    }
}
