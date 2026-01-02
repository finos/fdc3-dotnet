/*
 * SPDX-License-Identifier: Apache-2.0
 * Copyright FINOS FDC3 contributors - see NOTICE file
 */

namespace Finos.Fdc3
{
    public static class OpenError
    {
        public static readonly string AppNotFound = nameof(AppNotFound);
        public static readonly string ErrorOnLaunch = nameof(ErrorOnLaunch);
        public static readonly string AppTimeout = nameof(AppTimeout);
        public static readonly string ResolverUnavailable = nameof(ResolverUnavailable);
        public static readonly string MalformedContext = nameof(MalformedContext);
    }

    public static class ResolveError
    {
        public static readonly string NoAppsFound = nameof(NoAppsFound);
        public static readonly string ResolverUnavailable = nameof(ResolverUnavailable);
        public static readonly string ResolverTimeout = nameof(ResolverTimeout);
        public static readonly string UserCancelledResolution = nameof(UserCancelledResolution);
        public static readonly string TargetAppUnavailable = nameof(TargetAppUnavailable);
        public static readonly string TargetInstanceUnavailable = nameof(TargetInstanceUnavailable);
        public static readonly string IntentDeliveryFailed = nameof(IntentDeliveryFailed);
        public static readonly string MalformedContext = nameof(MalformedContext);
    }

    public static class ResultError
    {
        public static readonly string NoResultReturned = nameof(NoResultReturned);
        public static readonly string IntentHandlerRejected = nameof(IntentHandlerRejected);
    }

    public static class ChannelError
    {
        public static readonly string NoChannelFound = nameof(NoChannelFound);
        public static readonly string AccessDenied = nameof(AccessDenied);
        public static readonly string CreationFailed = nameof(CreationFailed);
        public static readonly string MalformedContext = nameof(MalformedContext);
    }
}
