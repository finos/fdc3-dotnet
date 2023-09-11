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

using System.Collections.Generic;

namespace MorganStanley.Fdc3.AppDirectory
{
    /// <summary>
    /// Defines an application retrieved from an FDC3 App Directory, which can then be launched.
    /// Launching typically means running for a user on a desktop. The details around 'launching' including
    /// who or what might do it, and how the launch action is initiated are discussed elsewhere in the FDC3
    /// App Directory spec.
    /// </summary>
    public class Fdc3App
    {
        /// <summary>
        /// The unique application identifier located within a specific application directory instance.
        /// </summary>
        public string? AppId { get; set; }

        /// <summary>
        /// The name of the application. The name should be unique within an FDC3 App Directory instance.
        /// The exception to the uniqueness constraint is that an App Directory can hold definitions
        /// for multiple versions of the same app. The same appName could occur in other directories.
        /// We are not currently specifying app name conventions in the document.
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// The technology type that is used to launch and run the application.
        /// Each application type implies a particular set of launch details. The supported types include:
        /// <list type="bullet">
        /// <item>
        /// web: Web applications launched via a URL
        /// </item>
        /// <item>
        /// native: Native applications pre-installed on a device and launch via a filesystem path
        /// </item>
        /// <item>
        /// citrix: Apps virtualized via Citrix
        /// </item>
        /// <item>
        /// onlineNative: Native apps that have an online launcher, e.g.online ClickOnce app deployments.
        /// </item>
        /// <item>
        /// other: Used to represent apps that do not conform to or cannot be launched via the other types,
        /// and are likely to be defined solely by a hostManifest.
        /// </item>
        /// </list>
        /// FDC3 Desktop Agents MUST support at least the web application type and MAY support any or all of the other types.
        /// </summary>
        public string? Type { get; set; }

        /// <summary>
        /// <see cref="IAppDetails"/>
        /// </summary>
        public IAppDetails? Details { get; set; }

        /// <summary>
        /// Version of the application. This allows multiple app versions to be defined using the same app name.
        /// This can be a triplet but can also include things like 1.2.5 (BETA)
        /// </summary>
        public string? Version { get; set; }

        /// <summary>
        /// Optional title for the application, if missing use appName, typically used in a launcher UI.
        /// </summary>
        public string? Title { get; set; }

        /// <summary>
        /// Optional tooltip description e.g. for a launcher
        /// </summary>
        public string? ToolTip { get; set; }

        /// <summary>
        /// Description of the application. This will typically be a 1-2 paragraph style blurb about the application.
        /// </summary>
        public string? Description { get; set; }

        /// <summary>	
        /// An array of string categories that describe the application.These are meant as a hint to catalogs or stores
        /// listing FDC3-enabled apps and it is expected that these will make a best effort to find appropriate categories (or category)
        /// under which to list the app.AppD record authors are encouraged to use lower-case and, where possible,
        /// to select categories from the following list: allocations, analytics, charts, chat,communication,
        /// compliance, crm, developer tools, events, execution management, file sharing, market data, news
        /// networking, office apps, order management, other, portfolio management, presentation, pricing
        /// productivity, research, risk, screen sharing, security, spreadsheet, trade cost analysis
        /// trading system, training, travel, video, visualization, weather
        /// </summary>
        public IEnumerable<string>? Categories { get; set; }

        /// <summary>
        /// A language tag that specifies the primary language of both the application and its AppD entry, as defined by IETF RFC 5646.
        /// </summary>
        public string? Lang { get; set; }

        /// <summary>
        /// Holds Icons used for the application, a Launcher may be able to use multiple Icon sizes or there may be a 'button' Icon
        /// </summary>
        public IEnumerable<Icon>? Icons { get; set; }

        /// <summary>
        /// Array of images to show the user when they are looking at app description. Each image can have an optional description/tooltip
        /// </summary>
        public IEnumerable<Image>? Screenshots { get; set; }

        /// <summary>
        /// Optional e-mail to receive queries about the application
        /// </summary>
        public string? ContactEmail { get; set; }

        /// <summary>
        /// Optional e-mail to receive support requests for the application
        /// </summary>
        public string? SupportEmail { get; set; }

        /// <summary>
        /// Optional URL that provides more information about the application
        /// </summary>
        public string? MoreInfo { get; set; }

        /// <summary>
        /// The name of the company that owns the application. The publisher has control over their namespace/app/signature.
        /// </summary>
        public string? Publisher { get; set; }

        /// <summary>
        /// An optional set of name value pairs that can be used to deliver custom data from an App Directory to a launcher.
        /// </summary>
        public Dictionary<string, string>? CustomConfig { get; set; }

        /// <summary>
        /// <see cref="HostManifests"/>
        /// </summary>
        public Dictionary<string, object>? HostManifests { get; set; }

        /// <summary>
        /// <see cref="Interop"/>
        /// </summary>
        public Interop? Interop { get; set; }

        /// <summary>
        /// Provides localized alternatives to any field of the AppD record, which may also refer to an alternative
        /// version of the application that is also localized (e.g. by providing customConfig or an alternative URL).
        /// The keys to this object should be language tags as defined by IETF RFC 5646, e.g. en, en-GB or fr-FR.
        /// </summary>
        public Dictionary<string, LocalizedVersion>? LocalizedVersions { get; set; }
    }
}
