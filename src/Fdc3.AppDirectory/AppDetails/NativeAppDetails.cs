/*
 * SPDX-License-Identifier: Apache-2.0
 * Copyright FINOS FDC3 contributors - see NOTICE file
 */

using System;

namespace Finos.Fdc3.AppDirectory
{
    /// <summary>
    /// Native application pre-installed on a device and launch via a filesystem path.
    /// </summary>
    public class NativeAppDetails
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NativeAppDetails"/> class.
        /// </summary>
        /// <param name="path">The path</param>
        /// <param name="arguments">The arguments</param>
        /// <exception cref="ArgumentNullException">Exception if the path is null</exception>
        public NativeAppDetails(string path, string? arguments)
        {
            Path = path ?? throw new ArgumentNullException(nameof(path));
            Arguments = arguments;
        }
        /// <summary>
        /// The path on disk from which the application is launched.
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// Arguments that must be passed on the command line to launch the app in the expected configuration.
        /// </summary>
        public string? Arguments { get; set; }
    }
}
