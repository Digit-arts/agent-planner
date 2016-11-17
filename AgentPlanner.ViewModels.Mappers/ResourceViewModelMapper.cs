using AgentPlanner.ViewModels.Resource;

namespace AgentPlanner.ViewModels.Mappers
{
    public static class ResourceViewModelMapper
    {
        public static ResourceViewModel ToVm(this Entities.Resources.Resource resource, string siteUrl)
        {
            if (resource == null) return null;
            return new ResourceViewModel
            {
                Id = resource.Id,
                ResourceName = resource.ResourceName,
                ResourceType = resource.ResourceType,
                ResourceExtenstion = resource.ResourceExtenstion,
                CreatedDate = resource.CreatedDate,
                Url = $"{siteUrl}api/resource/{resource.Id}/{resource.ResourceName}"
            };
        }
    }
}
