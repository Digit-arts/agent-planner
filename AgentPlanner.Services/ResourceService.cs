using AgentPlanner.Entities.Mappers;
using AgentPlanner.Entities.Resources;
using AgentPlanner.Repositories;

namespace AgentPlanner.Services
{
    public class ResourceService
    {
        private readonly ResourceRepository _resourceRepository;

        public ResourceService()
        {
            _resourceRepository = new ResourceRepository();
        }

        public Resource AddResource(Resource resource)
        {
            var id =  _resourceRepository.Add(resource.ToDbo());
            return _resourceRepository.Get(id).ToDto();
        }

        public Resource Get(int resourceId)
        {
            return _resourceRepository.Get(resourceId).ToDto();
        }
    }
}
