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

namespace MorganStanley.Fdc3.Tests;

public class AppMetadataTests
{
    [Fact]
    public void AppMetadata_NullAppId_ThrowsArgumentNullException()
    {
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
        Assert.Throws<ArgumentNullException>(() => new AppMetadata(null));
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
    }

    [Fact]
    public void AppMetaData_Defaults_PropertiesMatchParams()
    {
        IAppMetadata metadata = new AppMetadata("appid");
        Assert.Same("appid", metadata.AppId);
        Assert.Null(metadata.InstanceId);
        Assert.Null(metadata.Name);
        Assert.Null(metadata.Version);
        Assert.Null(metadata.Title);
        Assert.Null(metadata.Tooltip);
        Assert.Null(metadata.Description);
        Assert.True(metadata.Icons != null && metadata.Icons.Count() == 0);
        Assert.True(metadata.Screenshots != null && metadata.Screenshots.Count() == 0);
        Assert.Null(metadata.ResultType);
    }

    [Fact]
    public void AppMetaData_PropertiesMatchParams()
    {
        IIcon[] icons = { new Icon("src")  };
        IImage[] images = { new Image("src") };
        IAppMetadata metadata = new AppMetadata("appid", "instance", "name", "version", "title", "tooltip", "description", icons, images, "resulttype");
        Assert.Same("appid", metadata.AppId);
        Assert.Same("instance", metadata.InstanceId);
        Assert.Same("name", metadata.Name);
        Assert.Same("version", metadata.Version);
        Assert.Same("title", metadata.Title);
        Assert.Same("tooltip", metadata.Tooltip);
        Assert.Same("description", metadata.Description);
        Assert.Same(icons, metadata.Icons);
        Assert.Same(images, metadata.Screenshots);
        Assert.Same("resulttype", metadata.ResultType);
    }
}