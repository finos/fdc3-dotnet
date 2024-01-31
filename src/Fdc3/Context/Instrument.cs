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

namespace Finos.Fdc3.Context
{
    public class Instrument : Context<InstrumentID>, IContext
    {
        public Instrument(InstrumentID? id = null, string? name = null)
            : base(ContextTypes.Instrument, id, name)
        {
        }

        object? IContext<object>.ID => base.ID;
    }

    public class InstrumentID
    {
        public string? BBG { get; set; }
        public string? CUSIP { get; set; }
        public string? FDS_ID { get; set; }
        public string? FIGI { get; set; }
        public string? ISIN { get; set; }
        public string? PERMID { get; set; }
        public string? RIC { get; set; }
        public string? SEDOL { get; set; }
        public string? Ticker { get; set; }
    }
}
