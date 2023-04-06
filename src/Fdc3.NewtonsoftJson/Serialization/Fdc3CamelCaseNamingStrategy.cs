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

using Newtonsoft.Json.Serialization;

namespace MorganStanley.Fdc3.NewtonsoftJson.Serialization
{
    public class Fdc3CamelCaseNamingStrategy : CamelCaseNamingStrategy
    {
        public override string GetPropertyName(string name, bool hasSpecifiedName)
        {
            switch (name)
            {
                case "CURRENCY_ISOCODE":
                case "ISOALPHA2":
                case "ISOALPHA3":
                case "COUNTRY_ISOALPHA2":
                case "COUNTRY_ISOALPHA3":
                case "FDS_ID":
                case "BBG":
                case "CUSIP":
                case "FIGI":
                case "ISIN":
                case "PERMID":
                case "RIC":
                case "SEDOL":
                case "LEI":
                    return name;

                default:
                    return base.GetPropertyName(name, hasSpecifiedName);
            }
        }
    }

}