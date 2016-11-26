using System.Collections.Generic;
using System.Linq;
using AgentPlanner.Entities.Client;

namespace AgentPlanner.Entities.Mappers
{
    public static class SiteMapper
    {
        public static Site ToDto(this DataAccess.Site site)
        {
            if (site == null) return null;

            return new Site
            {
                Id = site.Id,
                SideCode = site.SideCode,
                ClientId = site.ClientId,
                Name = site.Name,
                Address = site.Address,
                Address2 = site.Address2,
                ZipCode = site.ZipCode,
                City = site.City,
                ContactName = site.ContactName,
                ContactPhoneNumber = site.ContactPhoneNumber,
                EmailAddress = site.EmailAddress,
                Comments = site.Comments,
                IsActive = site.IsActive,
                CreatedDate = site.CreatedDate,
                ModificationDate = site.ModificationDate,
                Client = site.Client.ToDto()
            };
        }

        public static Site[] ToDtos(this IEnumerable<DataAccess.Site> sites)
        {
            return sites.Select(x => x.ToDto()).ToArray();
        }

        public static DataAccess.Site ToDbo(this Site site)
        {
            return new DataAccess.Site
            {
                Id = site.Id,
                SideCode = site.SideCode,
                ClientId = site.ClientId,
                Name = site.Name,
                Address = site.Address,
                Address2 = site.Address2,
                ZipCode = site.ZipCode,
                City = site.City,
                ContactName = site.ContactName,
                ContactPhoneNumber = site.ContactPhoneNumber,
                EmailAddress = site.EmailAddress,
                Comments = site.Comments,
                IsActive = site.IsActive,
                CreatedDate = site.CreatedDate,
                ModificationDate = site.ModificationDate
            };
        }

        public static DataAccess.Site[] ToDbos(this IEnumerable<Site> sites)
        {
            return sites.Select(x => x.ToDbo()).ToArray();
        }

    }
}