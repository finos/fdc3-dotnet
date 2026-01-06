/*
 * SPDX-License-Identifier: Apache-2.0
 * Copyright FINOS FDC3 contributors - see NOTICE file
 */

using System;

namespace Finos.Fdc3.AppDirectory
{
    /// <summary>
    /// App virtualized via Citrix.
    /// </summary>
    public class CitrixAppDetails
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CitrixAppDetails"/> class.
        /// </summary>
        /// <param name="alias">The alias</param>
        /// <param name="arguments">The arguments</param>
        /// <exception cref="ArgumentNullException">Exception if the alias is null</exception>
        public CitrixAppDetails(string alias, string? arguments)
        {
            Alias = alias ?? throw new ArgumentNullException(nameof(alias));
            Arguments = arguments;
        }

        /// <summary>
        /// The Citrix alias / name of the virtual app (passed to the Citrix SelfService qlaunch parameter).
        /// </summary>
        public string Alias { get; set; }

        /// <summary>
        /// Arguments that must be passed on the command line to launch the app in the expected configuration.
        /// </summary>
        public string? Arguments { get; set; }
    }
}
