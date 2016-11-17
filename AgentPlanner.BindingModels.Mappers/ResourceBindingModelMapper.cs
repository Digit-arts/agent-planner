using AgentPlanner.BindingModels.Resources;
using AgentPlanner.Entities.Resources;

namespace AgentPlanner.BindingModels.Mappers
{
    public static class ResourceBindingModelMapper
    {
        public static Resource ToDto(this ResourceBindingModel resource)
        {
            return new Resource
            {
                ResourceExtenstion = resource.ResourceExtenstion,
                ResourceName = resource.ResourceName,
                ResourcePath = resource.ResourcePath,
                ResourceType = resource.ResourceType
            };
        }
    }
}
