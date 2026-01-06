/*
 * SPDX-License-Identifier: Apache-2.0
 * Copyright FINOS FDC3 contributors - see NOTICE file
 */

using System.Runtime.Serialization;

namespace Finos.Fdc3.AppDirectory
{
    /// <summary>
    /// The exception that is thrown by <see cref="IAppDirectory.GetApp"/> when the app is not found.
    /// </summary>
    public class AppNotFoundException : AppDirectoryException
    {
        public AppNotFoundException(string appId) : base($"The app with id '{appId}' was not found in the App Directory")
        {
        }

        public AppNotFoundException() : base("The app was not found in the App Directory") { }
        protected AppNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
