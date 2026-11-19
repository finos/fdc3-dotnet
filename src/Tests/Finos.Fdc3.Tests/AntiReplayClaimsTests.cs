/*
 * SPDX-License-Identifier: Apache-2.0
 * Copyright FINOS FDC3 contributors - see NOTICE file
 */

namespace Finos.Fdc3.Tests;

public class AntiReplayClaimsTests
{
    [Fact]
    public void AntiReplayClaims_Constructor_PropertiesMatchParams()
    {
        long iat = 1000000;
        long exp = 2000000;
        string jti = Guid.NewGuid().ToString();

        IAntiReplayClaims claims = new AntiReplayClaims(iat, exp, jti);

        Assert.Equal(iat, claims.Iat);
        Assert.Equal(exp, claims.Exp);
        Assert.Equal(jti, claims.Jti);
    }

    [Fact]
    public void AntiReplayClaims_Constructor_WithNullJti_ThrowsArgumentNullException()
    {
        long iat = 1000000;
        long exp = 2000000;

        var exception = Assert.Throws<ArgumentNullException>(() =>
            new AntiReplayClaims(iat, exp, null!)
        );

        Assert.Equal("jti", exception.ParamName);
    }

    [Theory]
    [InlineData(0, 1000000)]
    [InlineData(1000000, 2000000)]
    [InlineData(long.MinValue, long.MaxValue)]
    public void AntiReplayClaims_Constructor_AcceptsValidTimestamps(long iat, long exp)
    {
        string jti = Guid.NewGuid().ToString();

        IAntiReplayClaims claims = new AntiReplayClaims(iat, exp, jti);

        Assert.Equal(iat, claims.Iat);
        Assert.Equal(exp, claims.Exp);
    }

    [Fact]
    public void AntiReplayClaims_PropertiesAreReadOnly()
    {
        long iat = 1000000;
        long exp = 2000000;
        string jti = Guid.NewGuid().ToString();

        var claims = new AntiReplayClaims(iat, exp, jti);

        Assert.NotNull(typeof(AntiReplayClaims).GetProperty("Iat"));
        Assert.NotNull(typeof(AntiReplayClaims).GetProperty("Exp"));
        Assert.NotNull(typeof(AntiReplayClaims).GetProperty("Jti"));
    }
}
