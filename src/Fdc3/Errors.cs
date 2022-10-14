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

namespace MorganStanley.Fdc3
{
    public static class OpenError
    {
        public static readonly string AppNotFound = "AppNotFound";
        public static readonly string ErrorOnLaunch = "ErrorOnLaunch";
        public static readonly string AppTimeout = "AppTimeout";
        public static readonly string ResolverUnavailable = "ResolverUnavailable";
    }

    public static class ResolveError
    {
        public static readonly string NoAppsFound = "NoAppsFound";
        public static readonly string ResolverUnavailable = "ResolverUnavailable";
        public static readonly string ResolverTimeout = "ResolverTimeout";
        public static readonly string UserCancelled = "UserCancelledResolution";
        public static readonly string TargetAppUnavailable = "TargetAppUnavailable";
        public static readonly string TargetInstanceUnavailable = "TargetInstanceUnavailable";
        public static readonly string IntentDeliveryFailed = "IntentDeliveryFailed";
    }

    public static class ResultError
    {
        public static readonly string NoResultReturned = "NoResultReturned";
        public static readonly string IntentHandlerRejected = "IntentHandlerRejected";
    }

    public static class ChannelError
    {
        public static readonly string NoChannelFound = "NoChannelFound";
        public static readonly string AccessDenied = "AccessDenied";
        public static readonly string CreationFailed = "CreationFailed";
    }
}
