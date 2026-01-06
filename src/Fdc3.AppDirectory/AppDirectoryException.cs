/*
 * SPDX-License-Identifier: Apache-2.0
 * Copyright FINOS FDC3 contributors - see NOTICE file
 */

using System;
using System.Runtime.Serialization;

namespace Finos.Fdc3.AppDirectory
{
    /// <summary>
    /// Base class for exceptions thrown by <see cref="IAppDirectory"/> implementations
    /// </summary>
    public class AppDirectoryException : Exception
    {
        public AppDirectoryException() { }
        protected AppDirectoryException(SerializationInfo info, StreamingContext context) : base(info, context) { }
        public AppDirectoryException(string message) : base(message) { }
        public AppDirectoryException(string message, Exception innerException) : base(message, innerException) { }
    }
}
