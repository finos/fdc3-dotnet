/*
 * SPDX-License-Identifier: Apache-2.0
 * Copyright FINOS FDC3 contributors - see NOTICE file
 */

using System;

namespace Finos.Fdc3
{
    /// <summary>
    /// Metadata relating to the FDC3 Desktop Agent implementation and its provider.
    /// </summary>
    public class ImplementationMetadata : IImplementationMetadata
    {
        public ImplementationMetadata(string fdc3Version, string provider, string providerVersion, OptionalDesktopAgentFeatures optionalFeatures, IAppMetadata appMetadata)
        {
            this.Fdc3Version = fdc3Version ?? throw new ArgumentNullException(nameof(fdc3Version));
            this.Provider = provider ?? throw new ArgumentNullException(nameof(provider));
            this.ProviderVersion = providerVersion ?? throw new ArgumentNullException(nameof(providerVersion));
            this.OptionalFeatures = optionalFeatures ?? throw new ArgumentNullException(nameof(optionalFeatures));
            this.AppMetadata = appMetadata ?? throw new ArgumentNullException(nameof(appMetadata));
        }

        /// <summary>
        ///  The version number of the FDC3 specification that the implementation provides.
        ///  The string must be a numeric semver version, e.g. 1.2 or 1.2.1.
        /// </summary>
        public string Fdc3Version { get; }

        /// <summary>
        /// The name of the provider of the FDC3 Desktop Agent Implementation (e.g. Finsemble, Glue42, OpenFin etc.).
        /// </summary>
        public string Provider { get; }

        /// <summary>
        /// The version of the provider of the FDC3 Desktop Agent Implementation (e.g. 5.3.0).
        /// </summary>
        public string ProviderVersion { get; }

        public OptionalDesktopAgentFeatures OptionalFeatures { get; }

        public IAppMetadata AppMetadata { get; }
    }
}
