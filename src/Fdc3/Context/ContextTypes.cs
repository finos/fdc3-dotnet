/*
 * Morgan Stanley makes this available to you under the Apache License,
 * Version 2.0 (the "License"). You may obtain a copy of the License at
 *
 *      http://www.apache.org/licenses/LICENSE-2.0.
 *
 * See the NOTICE file distributed with this work for additional information
 * regarding copyright ownership. Unless required by applicable law or agreed
 * to in writing, software distributed under the License is distributed on an
 * "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express
 * or implied. See the License for the specific language governing permissions
 * and limitations under the License.
 */

using System;
using System.Collections.Generic;

namespace MorganStanley.Fdc3.Context
{
    public static class ContextTypes
    {
        public static readonly string Chart = "fdc3.chart";
        public static readonly string ChatInitSettings = "fdc3.chat.initSettings";
        public static readonly string Contact = "fdc3.contact";
        public static readonly string ContactList = "fdc3.contactList";
        public static readonly string Country = "fdc3.country";
        public static readonly string Currency = "fdc3.currency";
        public static readonly string Email = "fdc3.email";
        public static readonly string Instrument = "fdc3.instrument";
        public static readonly string InstrumentList = "fdc3.instrumentList";
        public static readonly string Nothing = "fdc3.nothing";
        public static readonly string Organization = "fdc3.organization";
        public static readonly string Portfolio = "fdc3.portfolio";
        public static readonly string Position = "fdc3.position";
        public static readonly string TimeRange = "fdc3.timerange";
        public static readonly string Valuation = "fdc3.valuation";

        public static IDictionary<string, Type> Map = new Dictionary<string, Type>()
        {
            {  ContextTypes.Chart, typeof(Chart) },
            {  ContextTypes.ChatInitSettings, typeof(ChatInitSettings) },
            {  ContextTypes.Contact, typeof(Contact) },
            {  ContextTypes.ContactList, typeof(ContactList) },
            {  ContextTypes.Country, typeof(Country) },
            {  ContextTypes.Currency, typeof(Currency) },
            {  ContextTypes.Email, typeof(Email) },
            {  ContextTypes.Instrument, typeof(Instrument) },
            {  ContextTypes.InstrumentList, typeof(InstrumentList) },
            {  ContextTypes.Nothing, typeof(Nothing) },
            {  ContextTypes.Organization, typeof(Organization) },
            {  ContextTypes.Portfolio, typeof(Portfolio) },
            {  ContextTypes.Position, typeof(Position) },
            {  ContextTypes.TimeRange, typeof(TimeRange) },
            {  ContextTypes.Valuation, typeof(Valuation) },
        };

        public static Type GetType(string contextType)
        {
            return ContextTypes.Map.TryGetValue(contextType, out Type typeMapping)
                ? typeMapping
                : typeof(Context);
        }
    }
}
