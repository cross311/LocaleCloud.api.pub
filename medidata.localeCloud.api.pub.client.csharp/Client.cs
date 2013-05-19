using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using medidata.localeCloud.api.pub.dtos;
using medidata.localeCloud.api.pub.dtos.models;
using ServiceStack.Common.ServiceClient.Web;
using ServiceStack.ServiceClient.Web;

namespace medidata.localeCloud.api.pub.client.csharp
{
    public class Client
    {
        ServiceClientBase m_client;

        public Client()
            : this("http://localhost:51260/localecloud/api/") { }

        public Client(string baseUri)
        {
            m_client = new JsonServiceClient(baseUri);
        }

        #region User
        public RegistrationResponse CreateUser(string firstName, string lastName, string email, string username, string password)
        {
            return m_client.Post(new Registration
            {
                AutoLogin = false,
                DisplayName = string.Format("{0}, {1}", lastName, firstName),
                Email = email,
                FirstName = firstName,
                LastName = lastName,
                Password = password,
                UserName = username
            });
        }

        public AuthResponse Login(string username, string password)
        {
            return m_client.Post(new Auth
            {
                UserName = username,
                Password = password,
                RememberMe = true,
                provider = "credentials"
            });
        }
        #endregion
        #region App
        public List<App> GetApps()
        {
            return m_client.Get(new Apps());
        }

        public void CreateApp(string name, string baseLocale, string startReleaseName, bool allowAutoCreate)
        {
            m_client.Put(new SaveApp
            {
                AppName = name,
                AllowAutoCreate = allowAutoCreate,
                BaseLocale = baseLocale,
                StartReleaseName = startReleaseName
            });
        }
        #endregion
        #region Permission
        public void GivePermission(string app, string username, PermissionType permission)
        {
            m_client.Put(new ModifyPermissions
            {
                AppName = app,
                PermissionType = permission,
                Username = username
            });
        }
        #endregion
    }
}
