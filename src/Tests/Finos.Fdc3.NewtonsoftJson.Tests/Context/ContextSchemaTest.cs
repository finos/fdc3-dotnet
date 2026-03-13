/*
 * SPDX-License-Identifier: Apache-2.0
 * Copyright FINOS FDC3 contributors - see NOTICE file
 */

using Finos.Fdc3.Context;
using Finos.Fdc3.NewtonsoftJson.Serialization;
using Json.Schema;
using Newtonsoft.Json;
using System.Reflection;
using System.Text.Json.Nodes;

namespace Finos.Fdc3.NewtonsoftJson.Tests.Context;

public abstract class ContextSchemaTest
{
    protected JsonSchema? Schema { get; private set; }
    protected string SchemaUrl { get; private set; }
    protected JsonSerializerSettings SerializerSettings { get; }

    public ContextSchemaTest(string schemaUrl)
    {
        this.SerializerSettings = new Fdc3JsonSerializerSettings();
        this.SchemaUrl = schemaUrl;
    }

    protected async Task<string> ValidateSchema(IContext context)
    {
        SchemaRegistry.Global.Fetch = uri =>
        {
            using var client = new HttpClient();
            var text = client.GetStringAsync(uri).GetAwaiter().GetResult();
            return JsonSchema.FromText(text);
        };

        string schemaText = await (await new HttpClient().GetAsync(this.SchemaUrl)).Content.ReadAsStringAsync();
        this.Schema = JsonSchema.FromText(schemaText);

        string serializedContext = JsonConvert.SerializeObject(context, this.SerializerSettings);
        var instanceJson = JsonNode.Parse(serializedContext);

        var options = new EvaluationOptions { OutputFormat = OutputFormat.List };
        var results = this.Schema.Evaluate(instanceJson, options);

        if (!results.IsValid)
        {
            var errorMessages = results.Details?
                .Where(d => d.Errors != null)
                .SelectMany(d => d.Errors!.Values)
                .ToArray() ?? Array.Empty<string>();
            Assert.True(results.IsValid, String.Join(",", errorMessages));
        }

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