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

using MorganStanley.Fdc3.Context;

namespace MorganStanley.Fdc3.Tests;

public class CurrencyTests : ContextSchemaTest
{
    public CurrencyTests()
        : base("https://fdc3.finos.org/schemas/2.0/currency.schema.json")
    {
    }

    [Fact]
    public async void Currency_SerializedJsonMatchesSchema()
    {
        Currency currency = new Currency(new CurrencyID() { CURRENCY_ISOCODE = "AAA" }, "currency");

        await this.ValidateSchema(currency);
    }
}