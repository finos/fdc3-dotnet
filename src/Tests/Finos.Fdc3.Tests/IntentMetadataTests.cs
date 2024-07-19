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

namespace Finos.Fdc3.Tests;

public class IntentMetadataTests
{
    [Fact]
    public void IntentMetadata_NullName_ArgumentNullException()
    {
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
#pragma warning disable CS0612 // Type or member is obsolete
        Assert.Throws<ArgumentNullException>(() => new IntentMetadata(null, "displayname"));
#pragma warning restore CS0612 // Type or member is obsolete
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
    }

    [Fact]
    public void IntentMetadata_PropertiesMatchParamsFromCtor1()
    {
        IIntentMetadata metadata = new IntentMetadata("name");
        Assert.Same("name", metadata.Name);
#pragma warning disable CS0618 // Type or member is obsolete
        Assert.Null(metadata.DisplayName);
#pragma warning restore CS0618 // Type or member is obsolete
    }


    [Fact]
    public void IntentMetadata_PropertiesMatchParamsFromCtor2()
    {
#pragma warning disable CS0612 // Type or member is obsolete
        IIntentMetadata metadata = new IntentMetadata("name", "displayname");
#pragma warning restore CS0612 // Type or member is obsolete
        Assert.Same("name", metadata.Name);
#pragma warning disable CS0618 // Type or member is obsolete
        Assert.Same("displayname", metadata.DisplayName);
#pragma warning restore CS0618 // Type or member is obsolete
    }
}