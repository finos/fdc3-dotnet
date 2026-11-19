/*
 * SPDX-License-Identifier: Apache-2.0
 * Copyright FINOS FDC3 contributors - see NOTICE file
 */

namespace Finos.Fdc3.Tests;

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

    [Fact]
    public void AppMetaData_WithInstanceMetadata()
    {
        var instanceMeta = new InstanceMetadata(new Dictionary<string, object> { { "windowId", "123" } });
        IAppMetadata metadata = new AppMetadata("appid", "instance-id", instanceMetadata: instanceMeta);
        
        Assert.NotNull(metadata.InstanceMetadata);
        Assert.Same(instanceMeta, metadata.InstanceMetadata);
    }

    [Fact]
    public void AppMetaData_WithInstanceMetadata_NoInstanceId_ThrowsArgumentException()
    {
        var instanceMeta = new InstanceMetadata(new Dictionary<string, object> { { "windowId", "123" } });
        
        ArgumentException ex = Assert.Throws<ArgumentException>(() => 
            new AppMetadata("appid", instanceMetadata: instanceMeta));
        
        Assert.Contains("InstanceMetadata cannot be set when InstanceId is null", ex.Message);
        Assert.Equal("instanceMetadata", ex.ParamName);
    }

    [Fact]
    public void AppMetaData_WithNullInstanceMetadata()
    {
        IAppMetadata metadata = new AppMetadata("appid", instanceMetadata: null);
        
        Assert.Null(metadata.InstanceMetadata);
    }

    [Fact]
    public void AppMetaData_AllParametersIncludingInstanceMetadata()
    {
        IIcon[] icons = { new Icon("src") };
        IImage[] images = { new Image("src") };
        var instanceMeta = new InstanceMetadata(new Dictionary<string, object> { { "key", "value" } });
        
        IAppMetadata metadata = new AppMetadata("appid", "instance", "name", "version", "title", "tooltip", 
            "description", icons, images, "resulttype", instanceMeta);
        
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
        Assert.Same(instanceMeta, metadata.InstanceMetadata);
    }
}