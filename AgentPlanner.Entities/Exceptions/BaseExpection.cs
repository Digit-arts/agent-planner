using System;

namespace AgentPlanner.Entities.Exceptions
{
    public class BaseExpection : Exception
    {
        public BaseExpection(string error)
            :base($"AgentPlanner exception: {error}")
        {
            
        }
    }
}
