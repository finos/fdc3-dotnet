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

using Xunit;

namespace Finos.Fdc3.AppDirectory.Tests;

public class LocalizedVersionTests
{
    [Fact]
    public void LocalizedVersion_Properties_CanBeSetAndGet()
    {
        // Arrange
        var version = new LocalizedVersion();
        var title = "Localized Title";
        var description = "Localized Description";

        // Act
        version.Title = title;
        version.Description = description;

        // Assert
        Assert.Equal(title, version.Title);
        Assert.Equal(description, version.Description);
    }

    [Fact]
    public void LocalizedVersion_Properties_CanBeNull()
    {
        // Arrange & Act
        var version = new LocalizedVersion();

        // Assert
        Assert.Null(version.Title);
        Assert.Null(version.Description);
    }
}
