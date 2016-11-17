using AgentPlanner.DataAccess;

namespace AgentPlanner.Entities.Mappers
{
    public static class ResourceMapper
    {
        public static Resource ToDbo(this Resources.Resource resource)
        {
            return new Resource
            {
                Id = resource.Id,
                CreatedDate = resource.CreatedDate,
                ResourceExtenstion = resource.ResourceExtenstion,
                ResourceName = resource.ResourceName,
                ResourcePath = resource.ResourcePath,
                ResourceType = resource.ResourceType
            };
        }

        public static Resources.Resource ToDto(this Resource resource)
        {
            if (resource == null) return null;
            return new Resources.Resource
            {
                Id = resource.Id,
                CreatedDate = resource.CreatedDate,
                ResourceExtenstion = resource.ResourceExtenstion,
                ResourceName = resource.ResourceName,
                ResourcePath = resource.ResourcePath,
                ResourceType = resource.ResourceType
            };
        }
    }
}
