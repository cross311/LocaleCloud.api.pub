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

        public void UpdateApp(string name, string baseLocale, bool allowAutoCreate)
        {
            m_client.Post(new SaveApp
            {
                AppName = name,
                AllowAutoCreate = allowAutoCreate,
                BaseLocale = baseLocale
            });
        }
        #endregion
        #region Release
        public List<Release> GetReleasesForApp(string app)
        {
            return m_client.Get(new Releases
            {
                AppName = app
            });
        }

        public Release GetRelease(string app, string name)
        {
            return m_client.Get(new Releases
            {
                AppName = app,
                ReleaseName = name
            }).Single();
        }

        public void CreateRelease(string app, string name, int order = 0)
        {
            m_client.Put(new UpdateRelease
            {
                AppName = app,
                ReleaseName = name,
                Order = order
            });
        }

        public void ReorderRelease(string app, string name, int order)
        {
            m_client.Post(new UpdateRelease
            {
                AppName = app,
                ReleaseName = name,
                Order = order
            });
        }

        public void DeleteRelease(string app, string name)
        {
            m_client.Delete(new UpdateRelease
            {
                AppName = app,
                ReleaseName = name
            });
        }
        #endregion
        #region Locale
        public List<Locale> GetAvailableLocales()
        {
            return m_client.Get(new Locales());
        }

        public List<Locale> GetLocalesForApp(string app)
        {
            return m_client.Get(new Locales
                {
                    AppName = app
                });
        }

        public List<Locale> GetLocalesForUser(string username)
        {
            return m_client.Get(new Locales
            {
                Username = username
            });
        }

        public void AddLocaleForApp(string app, string locale)
        {
            m_client.Put(new UpdateLocaleSupport
            {
                AppName = app,
                Locale = locale
            });
        }

        public void AddLocaleForUser(string username, string locale)
        {
            m_client.Put(new UpdateLocaleSupport
            {
                Username = username,
                Locale = locale
            });
        }

        public void RemoveLocaleForApp(string app, string locale)
        {
            m_client.Delete(new UpdateLocaleSupport
            {
                AppName = app,
                Locale = locale
            });
        }

        public void RemoveLocaleForUser(string username, string locale)
        {
            m_client.Delete(new UpdateLocaleSupport
            {
                Username = username,
                Locale = locale
            });
        }
        #endregion
        #region Permission

        public List<Permission> GetMyPermissions()
        {
            return m_client.Get(new Permissions());
        }

        public List<Permission> GetUsersPermissions(string username)
        {
            return m_client.Get(new Permissions
                {
                    Username = username
                });
        }

        public List<Permission> GetUsersPermissionsForApp(string username, string app)
        {
            return m_client.Get(new Permissions
            {
                Username = username,
                AppName = app
            });
        }

        public void GivePermission(string app, string username, PermissionType permission)
        {
            m_client.Put(new ModifyPermissions
            {
                AppName = app,
                PermissionType = permission,
                Username = username
            });
        }

        public void RevokePermission(string app, string username, PermissionType permission)
        {
            m_client.Delete(new ModifyPermissions
            {
                AppName = app,
                PermissionType = permission,
                Username = username
            });
        }
        #endregion
        #region Token
        public Token GetToken(string app, string release, string name)
        {
            return m_client.Get(new TokenDetails
            {
                AppName = app,
                ReleaseName = release,
                TokenName = name
            });
        }

        public void CreateTokenForRelease(string app, string release, string name)
        {
            m_client.Put(new TokenDetails
            {
                AppName = app,
                ReleaseName = release,
                TokenName = name
            });
        }

        public void DeleteTokenForRelease(string app, string release, string name)
        {
            m_client.Delete(new TokenDetails
            {
                AppName = app,
                ReleaseName = release,
                TokenName = name
            });
        }
        #endregion
        #region Translation
        public Dictionary<string, string> GetTranslations(string app, string release, string locale)
        {
            return m_client.Get(new Tokens
            {
                AppName = app,
                ReleaseName = release,
                Locale = locale
            });
        }

        public void UpdateTranslation(string app, string release, string locale, string token, string translation)
        {
            m_client.Put(new UpdateTranslation
            {
                AppName = app,
                ReleaseName = release,
                Locale = locale,
                TokenName = token,
                Translation = translation
            });
        }

        public void UpdateTranslations(string app, string release, string locale, Dictionary<string,string> tokenTranslationUpdates)
        {
            m_client.Put(new UpdateTranslation
            {
                AppName = app,
                ReleaseName = release,
                Locale = locale,
                Translations = tokenTranslationUpdates
            });
        }
        #endregion
        #region TranslationTask
        public List<TranslationTask> GetUnassignedTranslationTasks(List<string> localeFilter = null)
        {
            return m_client.Get(new TranslationTasks
            {
                Locales = localeFilter
            });
        }

        public List<TranslationTask> GetUnassignedTranslationTasksForApp(string app, List<string> localeFilter = null)
        {
            return m_client.Get(new TranslationTasks
            {
                AppName = app,
                Locales = localeFilter
            });
        }

        public List<TranslationTask> GetAssignedTranslationTasks(string username, List<string> localeFilter = null)
        {
            return m_client.Get(new TranslationTasks
            {
                Username = username,
                Locales = localeFilter
            });
        }

        public List<TranslationTask> GetAssignedTranslationTasksForApp(string username, string app, List<string> localeFilter = null)
        {
            return m_client.Get(new TranslationTasks
            {
                Username = username,
                AppName = app,
                Locales = localeFilter
            });
        }

        public void AssignTranslationTask(long id, string username)
        {
            m_client.Put(new ModifyTranslationTaskAssignment
            {
                TaskId = id,
                Username = username
            });
        }

        public void UnassignTranslationTask(long id)
        {
            m_client.Delete(new ModifyTranslationTaskAssignment
            {
                TaskId = id
            });
        }
        #endregion
        #region Comment
        public List<Comment> GetCommentsForToken(string app, string release, string token)
        {
            return m_client.Get(new Comments
            {
                AppName = app,
                ReleaseName = release,
                TokenName = token
            });
        }

        public void CreateCommentForToken(string app, string release, string token, string text)
        {
            m_client.Put(new CreateComment
            {
                AppName = app,
                ReleaseName = release,
                TokenName = token,
                Text = text
            });
        }

        public void UpdateComment(long id, string text)
        {
            m_client.Post(new ModifyComment
            {
                CommentId = id,
                Text = text
            });
        }

        public void DeleteComment(long id, string text)
        {
            m_client.Delete(new ModifyComment
            {
                CommentId = id,
                Text = text
            });
        }
        #endregion
    }
}
