/*
 * Morgan Stanley makes this available to you under the Apache License,
 * Version 2.0 (the "License"). You may obtain a copy of the License at
 *
 *      http://www.apache.org/licenses/LICENSE-2.0.
 *
 * See the NOTICE file distributed with this work for additional information
 * regarding copyright ownership. Unless required by applicable law or agreed
 * to in writing, software distributed under the License is distributed on an
 * "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express
 * or implied. See the License for the specific language governing permissions
 * and limitations under the License.
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
