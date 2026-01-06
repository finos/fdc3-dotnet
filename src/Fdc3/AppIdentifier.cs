/*
 * SPDX-License-Identifier: Apache-2.0
 * Copyright FINOS FDC3 contributors - see NOTICE file
 */

using System;

namespace Finos.Fdc3
{
    /// <summary>
    /// Identifies an application, or instance of an application, and is used to target FDC3 API calls,
    /// such as `fdc3.open` or `fdc3.raiseIntent` at specific applications or application instances.
    /// 
    /// Will always include at least an `AppId` property, which uniquely identifies a specific app.
    /// 
    /// If the `InstanceId` property is set, then the `AppIdentifier` object represents a specific instance
    /// of the application that may be addressed using that Id.
    /// </summary>
    public class AppIdentifier : IAppIdentifier
    {
        public AppIdentifier(string appId, string? instanceId = null)
        {
            this.AppId = appId ?? throw new ArgumentNullException(nameof(appId));
            this.InstanceId = instanceId;
        }

        /// <summary>
        /// The unique application identifier located within a specific application directory instance. An example of an appId might be 'app@sub.root'.
        /// </summary>
        public string AppId { get; }

        /// <summary>
        /// An optional instance identifier, indicating that this object represents a specific instance of the application described.
        /// </summary>
        public string? InstanceId { get; }
    }
}
