using AgentPlanner.BindingModels.Site;

namespace AgentPlanner.BindingModels.Mappers
{
    public static class SiteBindingModelMapper
    {
        public static Entities.Client.Site ToDto(this SiteBindingModel site)
        {
            return new Entities.Client.Site
            {
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
                SiteEmployeeTypes = site.SiteEmployeeTypes.ToDtos()
                
            };
        }
    }
}