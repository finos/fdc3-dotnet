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

using Finos.Fdc3.Context;

namespace Finos.Fdc3.Tests.Context;

public class MessageTests
{
    [Fact]
    public void Message_PropertiesMatchParams()
    {
        Message message = new Message(new MessageText() { TextPlain = "textplain", TextMarkdown = "textmarkdown" });

        Assert.Same("textplain", message.Text?.TextPlain);
        Assert.Same("textmarkdown", message.Text?.TextMarkdown);
        Assert.Same(ContextTypes.Message, message?.Type);
    }
}