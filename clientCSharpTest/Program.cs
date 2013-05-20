using System;
using medidata.localeCloud.api.pub.client.csharp;

namespace clientCSharpTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new Client();

            TryLogin(client);

            client.CreateApp("TestApp", "en-us", "Release1", true);

            var apps = client.GetApps();



            Console.WriteLine("Successfuly created test311 user and TestApp application.");
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
