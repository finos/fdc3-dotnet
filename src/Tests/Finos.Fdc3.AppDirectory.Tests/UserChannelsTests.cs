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
using Xunit;

namespace Finos.Fdc3.AppDirectory.Tests;

public class UserChannelsTests
{
    [Fact]
    public void UserChannels_Properties_CanBeSetAndGet()
    {
        // Arrange
        var channels = new UserChannels();
        var broadcasts = new[] { "fdc3.instrument", "fdc3.position" };
        var listensFor = new[] { "fdc3.contact", "fdc3.organization" };

        // Act
        channels.Broadcasts = broadcasts;
        channels.ListensFor = listensFor;

        // Assert
        Assert.Equal(broadcasts, channels.Broadcasts);
        Assert.Equal(listensFor, channels.ListensFor);
    }

    [Fact]
    public void UserChannels_Properties_CanBeNull()
    {
        // Arrange & Act
        var channels = new UserChannels();

        // Assert
        Assert.Null(channels.Broadcasts);
        Assert.Null(channels.ListensFor);
    }

    [Fact]
    public void UserChannels_Properties_CanBeEmpty()
    {
        // Arrange
        var channels = new UserChannels();
        var emptyList = new List<string>();

        // Act
        channels.Broadcasts = emptyList;
        channels.ListensFor = emptyList;

        // Assert
        Assert.Empty(channels.Broadcasts);
        Assert.Empty(channels.ListensFor);
    }
}
