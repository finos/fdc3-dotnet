/*
 * SPDX-License-Identifier: Apache-2.0
 * Copyright FINOS FDC3 contributors - see NOTICE file
 */

using System.Collections.Generic;
using Finos.Fdc3.Context;
using Xunit;

namespace Finos.Fdc3.Tests.Context;

public class PaymentTests
{
    [Fact]
    public void Payment_PropertiesMatchParams()
    {
        // Arrange
        var paymentId = new PaymentID() { UETR = "123e4567-e89b-12d3-a456-426614174000" };
        var debtor = new PaymentParty() { Name = "Acme Corp", Account = "GB33BUKB20201555555555", Agent = "AGENT001" };
        var creditor = new PaymentParty() { Name = "Global Treasury Ltd", Account = "US33CHAS021000021", Agent = "AGENT002" };
        var networkRouting = new Dictionary<string, string>() { { "rail", "RTGS" }, { "clearingSystem", "SWIFT" } };

        // Act
        var payment = new Payment(
            id: paymentId,
            name: "ISO 20022 pacs.008 Settlement",
            amount: 150000.00m,
            currency: "USD",
            debtor: debtor,
            creditor: creditor,
            networkRouting: networkRouting);

        // Assert
        Assert.Equal("123e4567-e89b-12d3-a456-426614174000", payment?.ID?.UETR);
        Assert.Equal("ISO 20022 pacs.008 Settlement", payment?.Name);
        Assert.Equal(150000.00m, payment?.Amount);
        Assert.Equal("USD", payment?.Currency);
        Assert.Equal("Acme Corp", payment?.Debtor?.Name);
        Assert.Equal("GB33BUKB20201555555555", payment?.Debtor?.Account);
        Assert.Equal("AGENT001", payment?.Debtor?.Agent);
        Assert.Equal("Global Treasury Ltd", payment?.Creditor?.Name);
        Assert.Equal("US33CHAS021000021", payment?.Creditor?.Account);
        Assert.Equal("AGENT002", payment?.Creditor?.Agent);
        Assert.Equal(ContextTypes.Payment, payment?.Type);
        Assert.NotNull(payment?.NetworkRouting);
        Assert.Equal("RTGS", payment?.NetworkRouting?["rail"]);
        Assert.Equal("SWIFT", payment?.NetworkRouting?["clearingSystem"]);
    }

    [Fact]
    public void Payment_CanBeCreatedWithMinimalProperties()
    {
        // Arrange
        var paymentId = new PaymentID() { UETR = "123e4567-e89b-12d3-a456-426614174000" };
        var debtor = new PaymentParty() { Account = "GB33BUKB20201555555555" };
        var creditor = new PaymentParty() { Account = "US33CHAS021000021" };

        // Act
        var payment = new Payment(
            id: paymentId,
            amount: 1000.00m,
            currency: "EUR",
            debtor: debtor,
            creditor: creditor);

        // Assert
        Assert.Equal("123e4567-e89b-12d3-a456-426614174000", payment?.ID?.UETR);
        Assert.Null(payment?.Name);
        Assert.Equal(1000.00m, payment?.Amount);
        Assert.Equal("EUR", payment?.Currency);
        Assert.Equal("GB33BUKB20201555555555", payment?.Debtor?.Account);
        Assert.Null(payment?.Debtor?.Name);
        Assert.Null(payment?.Debtor?.Agent);
        Assert.Equal("US33CHAS021000021", payment?.Creditor?.Account);
        Assert.Equal(ContextTypes.Payment, payment?.Type);
    }

    [Fact]
    public void Payment_TypeIsCorrect()
    {
        // Act
        var payment = new Payment();

        // Assert
        Assert.Equal(ContextTypes.Payment, payment?.Type);
        Assert.Equal("fdc3.payment", payment?.Type);
    }

    [Fact]
    public void PaymentID_SupportsMultipleIdentifiers()
    {
        // Act
        var paymentId = new PaymentID()
        {
            UETR = "123e4567-e89b-12d3-a456-426614174000",
            TransactionHash = "hash-value-12345"
        };

        // Assert
        Assert.Equal("123e4567-e89b-12d3-a456-426614174000", paymentId.UETR);
        Assert.Equal("hash-value-12345", paymentId.TransactionHash);
    }

    [Fact]
    public void PaymentParty_CanBeCreatedWithJustAccount()
    {
        // Act
        var party = new PaymentParty() { Account = "GB33BUKB20201555555555" };

        // Assert
        Assert.Equal("GB33BUKB20201555555555", party.Account);
        Assert.Null(party.Name);
        Assert.Null(party.Agent);
    }

    [Fact]
    public void Payment_CanBeCreatedWithoutId()
    {
        // Act
        var payment = new Payment(amount: 500.00m, currency: "GBP");

        // Assert
        Assert.Null(payment?.ID);
        Assert.Equal(500.00m, payment?.Amount);
        Assert.Equal("GBP", payment?.Currency);
        Assert.Equal(ContextTypes.Payment, payment?.Type);
    }

    [Fact]
    public void Payment_NetworkRouting_CanBeSetAndRetrieved()
    {
        // Arrange
        var payment = new Payment(amount: 1000.00m, currency: "USD");
        var networkRouting = new Dictionary<string, string> { { "rail", "RTGS" } };

        // Act
        payment.NetworkRouting = networkRouting;

        // Assert
        Assert.NotNull(payment.NetworkRouting);
        Assert.Equal("RTGS", payment.NetworkRouting["rail"]);
    }

    [Fact]
    public void Payment_NetworkRouting_CanBeNull()
    {
        // Arrange
        var payment = new Payment(amount: 1000.00m, currency: "USD");
        payment.NetworkRouting = new Dictionary<string, string> { { "rail", "RTGS" } };

        // Act
        payment.NetworkRouting = null;

        // Assert
        Assert.Null(payment.NetworkRouting);
    }

    [Fact]
    public void ContextTypes_PaymentMapsCorrectly()
    {
        // Act
        var type = ContextTypes.GetType(ContextTypes.Payment);

        // Assert
        Assert.Equal(typeof(Payment), type);
    }

    [Fact]
    public void Payment_AsIContextOfObject_ID_ReturnsPaymentID()
    {
        // Arrange
        var paymentId = new PaymentID { UETR = "123e4567-e89b-12d3-a456-426614174000" };
        var payment = new Payment(id: paymentId, amount: 1000.00m, currency: "USD");

        // Act
        IContext<object> contextOfObject = payment;
        var id = contextOfObject.ID;

        // Assert
        Assert.NotNull(id);
        Assert.IsType<PaymentID>(id);
        Assert.Equal(paymentId, id);
    }

    [Fact]
    public void Payment_AsIContextOfObject_ID_WithNullID()
    {
        // Arrange
        var payment = new Payment(amount: 1000.00m, currency: "USD");

        // Act
        IContext<object> contextOfObject = payment;
        var id = contextOfObject.ID;

        // Assert
        Assert.Null(id);
    }
}
