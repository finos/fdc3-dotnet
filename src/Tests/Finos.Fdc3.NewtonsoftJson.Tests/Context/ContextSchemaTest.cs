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
using Finos.Fdc3.NewtonsoftJson.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using System.Reflection;

namespace Finos.Fdc3.NewtonsoftJson.Tests.Context;

public abstract class ContextSchemaTest
{
    protected JSchema? Schema { get; private set; }
    protected string SchemaUrl { get; private set; }
    protected JsonSerializerSettings SerializerSettings { get; }

    public ContextSchemaTest(string schemaUrl)
    {
        this.SerializerSettings = new Fdc3JsonSerializerSettings();
        this.SchemaUrl = schemaUrl;
    }

    protected async Task<string> ValidateSchema(IContext context)
    {
        this.Schema = JSchema.Parse(await (await new HttpClient().GetAsync(this.SchemaUrl)).Content.ReadAsStringAsync(), new JSchemaUrlResolver());

        string serializedContext = JsonConvert.SerializeObject(context, this.SerializerSettings);
        JToken json = JToken.Parse(serializedContext);
        IList<string> errorMessages;
        bool isValid = json.IsValid(this.Schema, out errorMessages);
        Assert.True(isValid, String.Join(",", errorMessages.ToArray<string>()));
        return serializedContext;
    }

    protected T? Deserialize<T>(string resourcePath) where T : class, IContext
    {
        var assembly = Assembly.GetExecutingAssembly();
        using (Stream? stream = assembly.GetManifestResourceStream(resourcePath))
        {
            if (stream != null)
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    return JsonConvert.DeserializeObject<T>(reader.ReadToEnd(), this.SerializerSettings);
                }
            }
        }

        return null;
    }
}