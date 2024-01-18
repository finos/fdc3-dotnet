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

public class IconTests
{
    [Fact]
    public void Icon_NullSrc_ThrowsArgumentNullException()
    {
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
        Assert.Throws<ArgumentNullException>(() => new Icon(null));
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
    }

    [Fact]
    public void Icon_DefaultParams_AllNull()
    {
        IIcon icon = new Icon("src");
        Assert.Null(icon.Size);
        Assert.Null(icon.Type);
    }

    [Fact]
    public void Icon_PropertiesMatchParams()
    {
        IIcon icon = new Icon("src", "size", "type");
        Assert.Same("src", icon.Src);
        Assert.Same("size", icon.Size);
        Assert.Same("type", icon.Type);
    }
}