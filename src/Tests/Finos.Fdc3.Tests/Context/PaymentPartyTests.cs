/*
 * SPDX-License-Identifier: Apache-2.0
 * Copyright FINOS FDC3 contributors - see NOTICE file
 */

using System;
using Finos.Fdc3.Context;
using Xunit;

namespace Finos.Fdc3.Tests.Context;

public class PaymentPartyTests
{
    [Fact]
    public void PaymentParty_Account_Required()
    {
        // Act & Assert
        var party = new PaymentParty("GB33BUKB20201555555555");
        Assert.Equal("GB33BUKB20201555555555", party.Account);
    }

    [Fact]
    public void PaymentParty_AllProperties_SetViaConstructor()
    {
        // Act
        var party = new PaymentParty("GB33BUKB20201555555555", "Acme Corp", "AGENT001");

        // Assert
        Assert.Equal("Acme Corp", party.Name);
        Assert.Equal("GB33BUKB20201555555555", party.Account);
        Assert.Equal("AGENT001", party.Agent);
    }

    [Fact]
    public void PaymentParty_OptionalProperties_CanBeNull()
    {
        // Act
        var party = new PaymentParty("GB33BUKB20201555555555", null, null);

        // Assert
        Assert.Null(party.Name);
        Assert.Equal("GB33BUKB20201555555555", party.Account);
        Assert.Null(party.Agent);
    }

    [Fact]
    public void PaymentParty_Properties_CanBeModifiedAfterConstruction()
    {
        // Arrange
        var party = new PaymentParty("GB33BUKB20201555555555");

        // Act
        party.Name = "Acme Corp";
        party.Agent = "AGENT001";

        // Assert
        Assert.Equal("Acme Corp", party.Name);
        Assert.Equal("GB33BUKB20201555555555", party.Account);
        Assert.Equal("AGENT001", party.Agent);
    }

    [Fact]
    public void PaymentParty_Properties_CanBeSetToNull()
    {
        // Arrange
        var party = new PaymentParty("GB33BUKB20201555555555", "Acme Corp", "AGENT001");

        // Act
        party.Name = null;
        party.Agent = null;

        // Assert
        Assert.Null(party.Name);
        Assert.Equal("GB33BUKB20201555555555", party.Account);
        Assert.Null(party.Agent);
    }

    [Fact]
    public void PaymentParty_ThrowsOnNullAccount()
    {
        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => new PaymentParty(null));
    }
}
