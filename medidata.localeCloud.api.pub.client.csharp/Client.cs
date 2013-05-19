using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using medidata.localeCloud.api.pub.dtos;
using medidata.localeCloud.api.pub.dtos.models;
using ServiceStack.ServiceClient.Web;

namespace medidata.localeCloud.api.pub.client.csharp
{
    public class Client
    {
        ServiceClientBase m_client;

        public Client()
            : this("http://localhost/api") { }

        public Client(string baseUri)
        {
            m_client = new JsonServiceClient(baseUri);
        }

        public List<App> GetApps()
        {
            return m_client.Get(new Apps());
        }
    }
}
