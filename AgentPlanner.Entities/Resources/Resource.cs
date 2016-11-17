using System;

namespace AgentPlanner.Entities.Resources
{
    public class Resource
    {
        public int Id { get; set; }
        public string ResourceName { get; set; }
        public string ResourcePath { get; set; }
        public string ResourceType { get; set; }
        public string ResourceExtenstion { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
