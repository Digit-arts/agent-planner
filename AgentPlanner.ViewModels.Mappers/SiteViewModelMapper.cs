using System.Collections.Generic;
using System.Linq;
using AgentPlanner.ViewModels.Site;

namespace AgentPlanner.ViewModels.Mappers
{
    public static class SiteViewModelMapper
    {
        public static SiteViewModel ToVm(this Entities.Client.Site site)
        {
            if (site == null) return null;

            return new SiteViewModel
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
                Client = site.Client.ToVm()
            };
        }

        public static SiteViewModel[] ToVms(this IEnumerable<Entities.Client.Site> sites)
        {
            return sites.Select(x => x.ToVm()).ToArray();
        }
    }
}