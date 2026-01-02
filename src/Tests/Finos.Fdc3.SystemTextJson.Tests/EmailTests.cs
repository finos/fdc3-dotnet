/*
 * SPDX-License-Identifier: Apache-2.0
 * Copyright FINOS FDC3 contributors - see NOTICE file
 */

using Finos.Fdc3.Context;
using Finos.Fdc3.Json.Serialization;
using System.Reflection;
using System.Text.Json;

namespace Finos.Fdc3.SystemTextJson.Tests
{
    public class EmailTests
    {
        [Fact]
        public void Email_Contact_DeserializedJsonMatchesProperties()
        {
            Email? email = Deserialize<Email>("Finos.Fdc3.SystemTextJson.Tests.Examples.email-contact.json");
            Assert.NotNull(email);
            Contact? contact = email?.Recipients as Contact;
            Assert.Equal("email@test.com", contact?.ID?.Email);
            Assert.Equal("fds_id", contact?.ID?.FDS_ID);
            Assert.Equal("subject", email?.Subject);
            Assert.Equal("body", email?.TextBody);
            Assert.Equal("email", email?.Name);
        }

        [Fact]
        public void Email_ContactList_DeserializedJsonMatchesProperties()
        {
            Email? email = Deserialize<Email>("Finos.Fdc3.SystemTextJson.Tests.Examples.email-contactList.json");
            Assert.NotNull(email);
            ContactList? contactList = email?.Recipients as ContactList;
            Contact? contact = contactList?.Contacts?.First<Contact>();
            Assert.Equal("email@test.com", contact?.ID?.Email);
            Assert.Equal("fds_id", contact?.ID?.FDS_ID);
            Assert.Equal("subject", email?.Subject);
            Assert.Equal("body", email?.TextBody);
            Assert.Equal("email", email?.Name);
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
                        return JsonSerializer.Deserialize<T>(reader.ReadToEnd(), Fdc3JsonSerializerOptions.Create());
                    }
                }
            }

            return null;
        }
    }
}
