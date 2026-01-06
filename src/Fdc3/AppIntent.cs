/*
 * SPDX-License-Identifier: Apache-2.0
 * Copyright FINOS FDC3 contributors - see NOTICE file
 */

using System;
using System.Collections.Generic;

namespace Finos.Fdc3
{
    public class AppIntent : IAppIntent
    {
        /// <summary>
        /// An interface that relates an intent to apps
        /// </summary>
        public AppIntent(IIntentMetadata intent, IEnumerable<IAppMetadata> apps)
        {
            this.Intent = intent ?? throw new ArgumentNullException(nameof(intent));
            this.Apps = apps ?? throw new ArgumentNullException(nameof(apps));
        }

        public IIntentMetadata Intent { get; }

        public IEnumerable<IAppMetadata> Apps { get; }
    }
}
