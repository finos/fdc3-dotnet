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

using System;
using System.Collections.Generic;
using Xunit;

namespace Finos.Fdc3.AppDirectory.Tests;

public class IntentMetadataTests
{
    [Fact]
    public void IntentMetadata_Constructor_SetsProperties()
    {
        // Arrange
        var name = "ViewChart";
        var displayName = "View Chart";
        var contexts = new[] { "fdc3.instrument", "fdc3.position" };

        // Act
#pragma warning disable CS0618 // Type or member is obsolete
        var metadata = new IntentMetadata(name, displayName, contexts);

        // Assert
        Assert.Equal(name, metadata.Name);
        Assert.Equal(displayName, metadata.DisplayName);
#pragma warning restore CS0618 // Type or member is obsolete
        Assert.Equal(contexts, metadata.Contexts);
    }

    [Fact]
    public void IntentMetadata_Constructor_WithNullContexts_ThrowsArgumentNullException()
    {
        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => new IntentMetadata("ViewChart", "View Chart", null!));
    }

    [Fact]
    public void IntentMetadata_Constructor_WithEmptyContexts_Succeeds()
    {
        // Arrange & Act
        var metadata = new IntentMetadata("ViewChart", "View Chart", Array.Empty<string>());

        // Assert
        Assert.NotNull(metadata.Contexts);
        Assert.Empty(metadata.Contexts);
    }
}
