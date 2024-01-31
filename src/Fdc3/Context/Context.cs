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

namespace Finos.Fdc3.Context
{
    public class Context<T> : IContext<T> where T : class
    {
        public Context(string type, T? id = null, string? name = null)
        {
            this.Type = type ?? throw new ArgumentNullException(nameof(type));
            this.ID = id;
            this.Name = name;
        }

        public T? ID { get; }

        public string? Name { get; }

        public string Type { get; }

        dynamic? IDynamicContext.Native { get; set; }
    }

    public class Context : Context<object>, IContext
    {
        public Context(string type, object? id = null, string? name = null) : base(type, id, name)
        {
        }
    }
}
