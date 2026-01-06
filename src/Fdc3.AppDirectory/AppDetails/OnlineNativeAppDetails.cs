/*
 * SPDX-License-Identifier: Apache-2.0
 * Copyright FINOS FDC3 contributors - see NOTICE file
 */

using System;

namespace Finos.Fdc3.AppDirectory
{
    /// <summary>
    /// Native app that have an online launcher, e.g. online ClickOnce app deployments.
    /// </summary>
    public class OnlineNativeAppDetails
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OnlineNativeAppDetails"/> class.
        /// </summary>
        /// <param name="url">The url</param>
        /// <exception cref="ArgumentNullException">Exception if the url is null</exception>
        public OnlineNativeAppDetails(string url)
        {
            Url = url ?? throw new ArgumentNullException(nameof(url));
        }
        /// <summary>
        /// Application URL.
        /// </summary>
        public string Url { get; set; }
    }
}
