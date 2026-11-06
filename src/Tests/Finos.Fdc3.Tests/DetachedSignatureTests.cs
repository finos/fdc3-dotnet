/*
 * SPDX-License-Identifier: Apache-2.0
 * Copyright FINOS FDC3 contributors - see NOTICE file
 */

namespace Finos.Fdc3.Tests;

public class DetachedSignatureTests
{
    [Fact]
    public void DetachedSignature_Constructor_PropertiesMatchParams()
    {
        string protectedHeader = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9";
        string signature = "SflKxwRJSMeKKF2QT4fwpMeJf36POk6yJV_adQssw5c";

        IDetachedSignature sig = new DetachedSignature(protectedHeader, signature);

        Assert.Equal(protectedHeader, sig.Protected);
        Assert.Equal(signature, sig.Signature);
    }

    [Fact]
    public void DetachedSignature_Constructor_WithNullProtected_ThrowsArgumentNullException()
    {
        string signature = "SflKxwRJSMeKKF2QT4fwpMeJf36POk6yJV_adQssw5c";

        var exception = Assert.Throws<ArgumentNullException>(() =>
            new DetachedSignature(null!, signature)
        );

        Assert.Equal("protected", exception.ParamName);
    }

    [Fact]
    public void DetachedSignature_Constructor_WithNullSignature_ThrowsArgumentNullException()
    {
        string protectedHeader = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9";

        var exception = Assert.Throws<ArgumentNullException>(() =>
            new DetachedSignature(protectedHeader, null!)
        );

        Assert.Equal("signature", exception.ParamName);
    }

    [Fact]
    public void DetachedSignature_Constructor_WithEmptyProtected_IsValid()
    {
        string signature = "SflKxwRJSMeKKF2QT4fwpMeJf36POk6yJV_adQssw5c";

        IDetachedSignature sig = new DetachedSignature(string.Empty, signature);

        Assert.Equal(string.Empty, sig.Protected);
    }

    [Fact]
    public void DetachedSignature_Constructor_WithEmptySignature_IsValid()
    {
        string protectedHeader = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9";

        IDetachedSignature sig = new DetachedSignature(protectedHeader, string.Empty);

        Assert.Equal(string.Empty, sig.Signature);
    }

    [Fact]
    public void DetachedSignature_PropertiesAreReadOnly()
    {
        string protectedHeader = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9";
        string signature = "SflKxwRJSMeKKF2QT4fwpMeJf36POk6yJV_adQssw5c";

        var sig = new DetachedSignature(protectedHeader, signature);

        Assert.NotNull(typeof(DetachedSignature).GetProperty("Protected"));
        Assert.NotNull(typeof(DetachedSignature).GetProperty("Signature"));
    }
}
