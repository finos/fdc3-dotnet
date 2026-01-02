/*
 * SPDX-License-Identifier: Apache-2.0
 * Copyright FINOS FDC3 contributors - see NOTICE file
 */

namespace Finos.Fdc3.Context
{
    public class Action : Context, IContext
    {
        public Action(string title, IContext context, string? intent, IAppIdentifier? app = null, string? action = null, string? channelId = null, object? id = null, string? name = null)
            : base(ContextTypes.Action, id, name)
        {
            this.Title = title;
            this.Context = context;
            this.Intent = intent;
            this.App = app;
            this.ActionType = action;
            this.ChannelId = channelId;
        }

        public string Title { get; private set; }
        public IContext Context { get; private set; }
        public string? Intent { get; private set; }
        public IAppIdentifier? App { get; private set; }
        public string? ActionType { get; private set; }
        public string? ChannelId { get; private set; }

    }
}
