using System;
using System.Linq;
using medidata.localeCloud.api.pub.client.csharp;

namespace clientCSharpTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new Client();

            TryLogin(client);

            var locales = client.GetAvailableLocales();

            var en_us = locales.Single(l => l.Name.Equals("en-us", StringComparison.InvariantCultureIgnoreCase));

            var ja = locales.Single(l => l.Name.Equals("ja", StringComparison.InvariantCultureIgnoreCase));

            client.CreateApp("TestApp", en_us.Name, "Release1", true);

            var app = client.GetApp("TestApp");

            var release = client.GetRelease(app.Name, "Release1");

            client.CreateTokenForRelease(app.Name, release.Name, "Token1");

            var token1 = client.GetToken(app.Name, release.Name, "Token1");

            client.UpdateTranslation(app.Name, release.Name, en_us.Name, token1.Name, "Text1 - EN-US");

            var translations = client.GetTranslations(app.Name, release.Name, en_us.Name);

            Console.WriteLine(string.Format("EN-US: {0}={1}", token1.Name, translations[token1.Name]));

            client.CreateCommentForToken(app.Name, release.Name, token1.Name, "Going to add Japanases to app");

            var comments = client.GetCommentsForToken(app.Name, release.Name, token1.Name);
            foreach (var comment in comments)
            {
                Console.WriteLine(string.Format("Comment: {0}", comment.Text));
            }

            client.AddLocaleForApp(app.Name, ja.Name);

            client.UpdateTranslation(app.Name, release.Name, ja.Name, token1.Name, "Text1 - JA");

            var translations2 = client.GetTranslations(app.Name, release.Name, en_us.Name);

            Console.WriteLine(string.Format("EN-US: {0}={1}", token1.Name, translations2[token1.Name]));

            var translations_ja = client.GetTranslations(app.Name, release.Name, ja.Name);

            Console.WriteLine(string.Format("JA: {0}={1}", token1.Name, translations_ja[token1.Name]));

            foreach (var comment in comments)
            {
                Console.WriteLine(string.Format("Comment: {0}", comment.Text));
            }



            Console.WriteLine("Successfuly created test311 user and TestApp application.");

            Console.ReadLine();
        }

        static void TryLogin(Client client)
        {
            try
            {
                client.Login("test311", "P@$$w0rd!");
            }
            catch (Exception)
            {
                var create = client.CreateUser("Test", "Test", "test@test.com", "test311", "P@$$w0rd!");

                var login = client.Login("test311", "P@$$w0rd!");
            }
        }
    }
}
