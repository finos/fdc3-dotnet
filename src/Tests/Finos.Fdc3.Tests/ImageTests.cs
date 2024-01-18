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

public class ImageTests
{
    [Fact]
    public void Image_NullSrc_ThrowsArgumentNullException()
    {
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
        Assert.Throws<ArgumentNullException>(() => new Image(null));
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
    }

    [Fact]
    public void Image_DefaultParams_AllNull()
    {
        IImage image = new Image("src");
        Assert.Null(image.Size);
        Assert.Null(image.Type);
        Assert.Null(image.Label);
    }

    [Fact]
    public void Image_PropertiesMatchParams()
    {
        IImage image = new Image("src", "size", "type", "label");
        Assert.Same("src", image.Src);
        Assert.Same("size", image.Size);
        Assert.Same("type", image.Type);
        Assert.Same("label", image.Label);
    }
}