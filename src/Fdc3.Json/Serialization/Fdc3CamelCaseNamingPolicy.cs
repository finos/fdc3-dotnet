/*
 * SPDX-License-Identifier: Apache-2.0
 * Copyright FINOS FDC3 contributors - see NOTICE file
 */

using System.Text.Json;

namespace Finos.Fdc3.Json.Serialization
{
    internal class Fdc3CamelCaseNamingPolicy : JsonNamingPolicy
    {
        public override string ConvertName(string name)
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
                    return CamelCase.ConvertName(name);
            }
        }
    }
}
