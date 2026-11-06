/*
 * SPDX-License-Identifier: Apache-2.0
 * Copyright FINOS FDC3 contributors - see NOTICE file
 */

using Finos.Fdc3.Context;
using Xunit;

namespace Finos.Fdc3.Tests.Context;

public class PaymentPartyTests
{
    [Fact]
    public void PaymentParty_Name_SetAndGet()
    {
        var party = new PaymentParty { Name = "Acme Corp" };
        Assert.Equal("Acme Corp", party.Name);
    }

    [Fact]
    public void PaymentParty_Account_SetAndGet()
    {
        var party = new PaymentParty { Account = "GB33BUKB20201555555555" };
        Assert.Equal("GB33BUKB20201555555555", party.Account);
    }

    [Fact]
    public void PaymentParty_Agent_SetAndGet()
    {
        var party = new PaymentParty { Agent = "AGENT001" };
        Assert.Equal("AGENT001", party.Agent);
    }

    [Fact]
    public void PaymentParty_AllProperties_SetAndGet()
    {
        var party = new PaymentParty
        {
            Name = "Acme Corp",
            Account = "GB33BUKB20201555555555",
            Agent = "AGENT001"
        };

        Assert.Equal("Acme Corp", party.Name);
        Assert.Equal("GB33BUKB20201555555555", party.Account);
        Assert.Equal("AGENT001", party.Agent);
    }

    [Fact]
    public void PaymentParty_Null_Properties()
    {
        var party = new PaymentParty();
        
        Assert.Null(party.Name);
        Assert.Null(party.Account);
        Assert.Null(party.Agent);
    }

    [Fact]
    public void PaymentParty_SetToNull()
    {
        var party = new PaymentParty
        {
            Name = "Acme Corp",
            Account = "GB33BUKB20201555555555",
            Agent = "AGENT001"
        };

        party.Name = null;
        party.Account = null;
        party.Agent = null;

        Assert.Null(party.Name);
        Assert.Null(party.Account);
        Assert.Null(party.Agent);
    }
}
