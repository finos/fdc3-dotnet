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

using Finos.Fdc3.Context;

namespace Finos.Fdc3.Tests.Context;

public class ValuationTests
{
    [Fact]
    public void Valuation_PropertiesMatchParams()
    {
        string expiryTime = DateTime.Now.ToString("o");
        string valuationTime = DateTime.Now.ToString("o");
        var valuation = new Valuation("AAA", 1, 2, expiryTime, valuationTime, null, "valuation");
        Assert.Same("AAA", valuation.CURRENCY_ISOCODE);
        Assert.Equal(1, valuation.Price);
        Assert.Equal(2, valuation.Value);
        Assert.Same(expiryTime, valuation.ExpiryTime);
        Assert.Same(valuationTime, valuation.ValuationTime);
        Assert.Same("valuation", valuation.Name);
        Assert.Same(ContextTypes.Valuation, valuation.Type);
    }
}