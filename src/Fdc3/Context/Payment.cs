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
    /// Per FDC3 specification, id, amount, currency, debtor, and creditor are required.
    /// </summary>
    public class Payment : Context<PaymentID>, IContext
    {
        public Payment(
            PaymentID id,
            decimal amount,
            string currency,
            PaymentParty debtor,
            PaymentParty creditor,
            string? name = null,
            Dictionary<string, string>? networkRouting = null)
            : base(ContextTypes.Payment, id ?? throw new ArgumentNullException(nameof(id)), name)
        {
            this.Amount = amount;
            this.Currency = currency ?? throw new ArgumentNullException(nameof(currency));
            this.Debtor = debtor ?? throw new ArgumentNullException(nameof(debtor));
            this.Creditor = creditor ?? throw new ArgumentNullException(nameof(creditor));
            this.NetworkRouting = networkRouting;
        }

        /// <summary>
        /// The exact numerical value of the payment. Required per FDC3 specification.
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// The ISO 4217 currency code or standard asset identifier (e.g., 'USD', 'EUR', 'GBP'). Required per FDC3 specification.
        /// </summary>
        public string Currency { get; set; }

        /// <summary>
        /// The originating party initiating the payment. Required per FDC3 specification.
        /// </summary>
        public PaymentParty Debtor { get; set; }

        /// <summary>
        /// The receiving party for the payment. Required per FDC3 specification.
        /// </summary>
        public PaymentParty Creditor { get; set; }

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
    public class PaymentID : Dictionary<string, string>
    {
        /// <summary>
        /// Universal Execution Transaction Reference (ISO 20022 standard identifier for payments).
        /// </summary>
        public string? UETR
        {
            get => TryGetValue(nameof(UETR), out var value) ? value : null;
            set
            {
                if (value == null)
                    Remove(nameof(UETR));
                else
                    this[nameof(UETR)] = value;
            }
        }

        /// <summary>
        /// Transaction hash or any other transaction identifier in settlement networks.
        /// </summary>
        public string? TransactionHash
        {
            get => TryGetValue(nameof(TransactionHash), out var value) ? value : null;
            set
            {
                if (value == null)
                    Remove(nameof(TransactionHash));
                else
                    this[nameof(TransactionHash)] = value;
            }
        }
    }

    /// <summary>
    /// Represents a party in a payment transaction (debtor or creditor).
    /// Per FDC3 specification, the Account identifier is required.
    /// </summary>
    public class PaymentParty
    {
        public PaymentParty(string account, string? name = null, string? agent = null)
        {
            this.Account = account ?? throw new ArgumentNullException(nameof(account));
            this.Name = name;
            this.Agent = agent;
        }

        /// <summary>
        /// The name of the party.
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// The account identifier for the party. Required per FDC3 specification.
        /// </summary>
        public string Account { get; set; }

        /// <summary>
        /// The agent or financial institution code for the party.
        /// </summary>
        public string? Agent { get; set; }
    }
}
