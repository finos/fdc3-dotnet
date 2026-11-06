/*
 * SPDX-License-Identifier: Apache-2.0
 * Copyright FINOS FDC3 contributors - see NOTICE file
 */

using System;
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
        var debtor = new PaymentParty("GB33BUKB20201555555555", "Acme Corp", "AGENT001");
        var creditor = new PaymentParty("US33CHAS021000021", "Global Treasury Ltd", "AGENT002");
        var networkRouting = new Dictionary<string, string>() { { "rail", "RTGS" }, { "clearingSystem", "SWIFT" } };

        // Act
        var payment = new Payment(
            id: paymentId,
            amount: 150000.00m,
            currency: "USD",
            debtor: debtor,
            creditor: creditor,
            name: "ISO 20022 pacs.008 Settlement",
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
        var debtor = new PaymentParty("GB33BUKB20201555555555");
        var creditor = new PaymentParty("US33CHAS021000021");

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
    public void Payment_ThrowsOnNullRequiredFields()
    {
        // Arrange
        var debtor = new PaymentParty("GB33BUKB20201555555555");
        var creditor = new PaymentParty("US33CHAS021000021");

        // Act & Assert - null id throws
        Assert.Throws<ArgumentNullException>(() => 
            new Payment(null, 1000m, "USD", debtor, creditor));

        // Act & Assert - null currency throws
        Assert.Throws<ArgumentNullException>(() => 
            new Payment(new PaymentID(), 1000m, null, debtor, creditor));

        // Act & Assert - null debtor throws
        Assert.Throws<ArgumentNullException>(() => 
            new Payment(new PaymentID(), 1000m, "USD", null, creditor));

        // Act & Assert - null creditor throws
        Assert.Throws<ArgumentNullException>(() => 
            new Payment(new PaymentID(), 1000m, "USD", debtor, null));
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
    public void PaymentParty_RequiresAccount()
    {
        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => new PaymentParty(null));
    }

    [Fact]
    public void Payment_NetworkRouting_CanBeSetAndRetrieved()
    {
        // Arrange
        var debtor = new PaymentParty("GB33BUKB20201555555555");
        var creditor = new PaymentParty("US33CHAS021000021");
        var payment = new Payment(new PaymentID(), 1000.00m, "USD", debtor, creditor);
        var networkRouting = new Dictionary<string, string> { { "rail", "RTGS" } };

        // Act
        payment.NetworkRouting = networkRouting;

        // Assert
        Assert.NotNull(payment.NetworkRouting);
        Assert.Equal("RTGS", payment.NetworkRouting["rail"]);
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
        var debtor = new PaymentParty("GB33BUKB20201555555555");
        var creditor = new PaymentParty("US33CHAS021000021");
        var payment = new Payment(id: paymentId, amount: 1000.00m, currency: "USD", debtor: debtor, creditor: creditor);

        // Act
        IContext<object> contextOfObject = payment;
        var id = contextOfObject.ID;

        // Assert
        Assert.NotNull(id);
        Assert.IsType<PaymentID>(id);
        Assert.Equal(paymentId, id);
    }
}
