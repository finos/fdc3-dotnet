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

namespace MorganStanley.Fdc3.Context
{
    public class Valuation : Context, IContext
    {
        public Valuation(string currencyCode, float? price = null, float? value = null, string? expiryTime = null, string? valuationTime = null, object? id = null, string? name = null)
            : base(ContextTypes.Valuation, id, name)
        {
            this.CURRENCY_ISOCODE = currencyCode;
            this.Price = Price;
            this.Value = Value;
        }

        public string CURRENCY_ISOCODE { get; set; }
        public string? ExpiryTime { get; set; }
        public float? Price { get; set; }
        public string? ValuationTime { get; set; }
        public float? Value { get; set; }
    }
}
