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

namespace Finos.Fdc3.Context
{
    public class Action : Context, IContext
    {
        public Action(string title, IContext context, string? intent, IAppIdentifier? app = null, object? id = null, string? name = null)
            : base(ContextTypes.Action, id, name)
        {
            this.Title = title;
            this.Context = context;
            this.Intent = intent;
            this.App = app;
        }

        public string Title { get; private set; }
        public IContext Context { get; private set; }
        public string? Intent { get; private set; }
        public IAppIdentifier? App { get; private set; }

    }
}
