/*
 * SPDX-License-Identifier: Apache-2.0
 * Copyright FINOS FDC3 contributors - see NOTICE file
 */

using Newtonsoft.Json.Serialization;

namespace Finos.Fdc3.NewtonsoftJson.Serialization
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
                case "TextPlain":
                    return "text/plain";
                case "TextMarkdown":
                    return "text/markdown";

                default:
                    return base.GetPropertyName(name, hasSpecifiedName);
            }
        }
    }

}