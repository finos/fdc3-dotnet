/*
 * SPDX-License-Identifier: Apache-2.0
 * Copyright FINOS FDC3 contributors - see NOTICE file
 */

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Finos.Fdc3.AppDirectory
{
    /// <summary>
    /// Interface definition for the AppDirectory.
    /// </summary>
    public interface IAppDirectory
    {
        /// <summary>
        /// Returns a list of all applications from the AppDirectory.
        /// </summary>
        /// <returns>List of applications.</returns>
        Task<IEnumerable<Fdc3App>> GetApps();

        /// <summary>
        /// Returns an application by appId from the AppDirectory.
        /// </summary>
        /// <param name="appId">Application identifier</param>
        /// <returns>The application</returns>
        /// <exception cref="AppNotFoundException">The app was not found</exception>
        Task<Fdc3App> GetApp(string appId);
    }
}
