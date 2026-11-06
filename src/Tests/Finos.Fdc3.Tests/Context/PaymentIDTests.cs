/*
 * SPDX-License-Identifier: Apache-2.0
 * Copyright FINOS FDC3 contributors - see NOTICE file
 */

using System.Collections.Generic;
using Finos.Fdc3.Context;
using Xunit;

namespace Finos.Fdc3.Tests.Context;

public class PaymentIDTests
{
    [Fact]
    public void PaymentID_UETR_SetAndGet()
    {
        var paymentId = new PaymentID { UETR = "123e4567-e89b-12d3-a456-426614174000" };
        Assert.Equal("123e4567-e89b-12d3-a456-426614174000", paymentId.UETR);
    }

    [Fact]
    public void PaymentID_UETR_SetToNull_RemovesKey()
    {
        var paymentId = new PaymentID { UETR = "123e4567-e89b-12d3-a456-426614174000" };
        paymentId.UETR = null;
        Assert.Null(paymentId.UETR);
        Assert.False(paymentId.ContainsKey("UETR"));
    }

    [Fact]
    public void PaymentID_TransactionHash_SetAndGet()
    {
        var paymentId = new PaymentID { TransactionHash = "hash123" };
        Assert.Equal("hash123", paymentId.TransactionHash);
    }

    [Fact]
    public void PaymentID_TransactionHash_SetToNull_RemovesKey()
    {
        var paymentId = new PaymentID { TransactionHash = "hash123" };
        paymentId.TransactionHash = null;
        Assert.Null(paymentId.TransactionHash);
        Assert.False(paymentId.ContainsKey("TransactionHash"));
    }

    [Fact]
    public void PaymentID_BothProperties_SetAndGet()
    {
        var paymentId = new PaymentID
        {
            UETR = "123e4567-e89b-12d3-a456-426614174000",
            TransactionHash = "hash123"
        };
        
        Assert.Equal("123e4567-e89b-12d3-a456-426614174000", paymentId.UETR);
        Assert.Equal("hash123", paymentId.TransactionHash);
        Assert.Equal(2, paymentId.Count);
    }

    [Fact]
    public void PaymentID_GetNull_ReturnsNull()
    {
        var paymentId = new PaymentID();
        Assert.Null(paymentId.UETR);
        Assert.Null(paymentId.TransactionHash);
    }
}
