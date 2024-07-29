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
    public class Message : Context, IContext
    {
        public Message(MessageText text, object? id = null, string? name = null)
            : base(ContextTypes.Message, id, name)
        {
            this.Text = text;
        }

        public MessageText Text { get; set; }
    }

    public class MessageText
    {
        public string? TextPlain { get; set; }
        public string? TextMarkdown { get; set; }
    }
}
