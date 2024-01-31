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
    public class Email : Context, IContext
    {
        public Email(IRecipient recipients, string? subject = null, string? textBody = null, object? id = null, string? name = null)
            : base(ContextTypes.Email, id, name)
        {
            this.Recipients = recipients;
            this.Subject = subject;
            this.TextBody = textBody;
        }

        public IRecipient Recipients { get; set; }
        public string? Subject { get; set; }
        public string? TextBody { get; set; }

        object? IContext<object>.ID => base.ID;
    }
}
