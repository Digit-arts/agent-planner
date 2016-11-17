using System;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;
using AgentPlanner.Entities.Resources;
using AgentPlanner.Entities.User;
using AgentPlanner.Services;

namespace AgentPlanner.Web.Models
{
    public static class Utility
    {
        private static Claim GetLoggedinUserClaim(IPrincipal user)
        {
            var claim = ((ClaimsIdentity)user.Identity).Claims.ToArray();
            return claim.FirstOrDefault(x => x.Type.Equals("UserId"));
        }
        public static bool IsUserLoggedIn()
        {
            if (HttpContext.Current == null) return false;
            return GetLoggedinUserClaim(HttpContext.Current.User) != null;
        }
        public static Guid GetLoggedInUserId(IPrincipal user)
        {
            var claim = GetLoggedinUserClaim(user);
            if (claim == null) return Guid.Empty;
            return Guid.Parse(claim.Value);
        }

        public static User GetLoggedInUser()
        {
            var user = new UserService().Get(GetLoggedInUserId(HttpContext.Current.User));
            return user;
        }

        public static string UploadFullPath => HttpContext.Current.Server.MapPath(UploadRelativePath);

        public static string UploadRelativePath => "~/Uploads/";

        public static void CreateDirectory(string relativePath)
        {
            Directory.CreateDirectory(HttpContext.Current.Server.MapPath(relativePath));
        }

        public static void DeleteDirectory(string relativePath)
        {
            if (Directory.Exists(HttpContext.Current.Server.MapPath(relativePath)))
            {
                Directory.Delete(HttpContext.Current.Server.MapPath(relativePath),true);
            }
        }

        public static void DeleteFileRelative(string relativePath)
        {
            if (File.Exists(HttpContext.Current.Server.MapPath(relativePath)))
            {
                File.Delete(HttpContext.Current.Server.MapPath(relativePath));
            }
        }

        public static void DeleteFile(string fullPath)
        {
            if (File.Exists(fullPath))
            {
                File.Delete(fullPath);
            }
        }

        public static string SiteUrl => ConfigurationManager.AppSettings["SiteUrl"];

        public static string GetResourceUrl(Resource resource)
        {
            return SiteUrl + $"api/resource/{resource.Id}/{resource.ResourceName}";
        }
    }
}