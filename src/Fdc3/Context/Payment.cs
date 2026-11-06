/*
 * SPDX-License-Identifier: Apache-2.0
 * Copyright FINOS FDC3 contributors - see NOTICE file
 */

using System;
using System.Collections.Generic;

namespace Finos.Fdc3.Context
{
    /// <summary>
    /// Represents an institutional payment instruction, mapping to ISO 20022 pacs.008 (FIToFICustomerCreditTransfer).
    /// This type defines routing and settlement details including amount, currency, debtor, creditor, and optional network routing information.
    /// </summary>
    public class Payment : Context<PaymentID>, IContext
    {
        public Payment(
            PaymentID? id = null,
            string? name = null,
            decimal? amount = null,
            string? currency = null,
            PaymentParty? debtor = null,
            PaymentParty? creditor = null,
            Dictionary<string, string>? networkRouting = null)
            : base(ContextTypes.Payment, id, name)
        {
            this.Amount = amount;
            this.Currency = currency;
            this.Debtor = debtor;
            this.Creditor = creditor;
            this.NetworkRouting = networkRouting;
        }

        /// <summary>
        /// The exact numerical value of the payment.
        /// </summary>
        public decimal? Amount { get; set; }

        /// <summary>
        /// The ISO 4217 currency code or standard asset identifier (e.g., 'USD', 'EUR', 'GBP').
        /// </summary>
        public string? Currency { get; set; }

        /// <summary>
        /// The originating party initiating the payment.
        /// </summary>
        public PaymentParty? Debtor { get; set; }

        /// <summary>
        /// The receiving party for the payment.
        /// </summary>
        public PaymentParty? Creditor { get; set; }

        /// <summary>
        /// Optional parameters for payment routing and settlement execution, such as clearing system identifiers,
        /// rail routing codes, or network-specific execution parameters.
        /// </summary>
        public Dictionary<string, string>? NetworkRouting { get; set; }

        object? IContext<object>.ID => base.ID;
    }

    /// <summary>
    /// Represents payment identifiers that refer to the payment in an OMS, EMS, or Settlement network (e.g., UETR, TransactionHash).
    /// </summary>
    public class PaymentID
    {
        /// <summary>
        /// Universal Execution Transaction Reference (ISO 20022 standard identifier for payments).
        /// </summary>
        public string? UETR { get; set; }

        /// <summary>
        /// Transaction hash or any other transaction identifier in settlement networks.
        /// </summary>
        public string? TransactionHash { get; set; }
    }

    /// <summary>
    /// Represents a party in a payment transaction (debtor or creditor).
    /// </summary>
    public class PaymentParty
    {
        /// <summary>
        /// The name of the party.
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// The account identifier for the party (required).
        /// </summary>
        public string? Account { get; set; }

        /// <summary>
        /// The agent or financial institution code for the party.
        /// </summary>
        public string? Agent { get; set; }
    }
}
