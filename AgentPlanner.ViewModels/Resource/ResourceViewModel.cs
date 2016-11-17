using System;

namespace AgentPlanner.ViewModels.Resource
{
    public class ResourceViewModel
    {
        public int Id { get; set; }
        public string ResourceName { get; set; }
        public string ResourceType { get; set; }
        public string ResourceExtenstion { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Url { get; set; }
    }
}
