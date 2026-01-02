/*
 * SPDX-License-Identifier: Apache-2.0
 * Copyright FINOS FDC3 contributors - see NOTICE file
 */

using System;

namespace Finos.Fdc3.AppDirectory
{
    /// <summary>
    /// Web application launched via a URL.
    /// </summary>
    public class WebAppDetails
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WebAppDetails"/> class.
        /// </summary>
        /// <param name="url">The url</param>
        /// <exception cref="ArgumentNullException">Exception if the url is null</exception>
        public WebAppDetails(string url) 
        {
            Url = url ?? throw new ArgumentNullException(nameof(url));
        }

        /// <summary>
        /// <summary>
        /// Application start URL.
        /// </summary>
        public string Url { get; set; }
    }
}
