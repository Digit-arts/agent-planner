using AgentPlanner.Entities.Client;

namespace AgentPlanner.Entities.Employee
{
    public class SiteEmployeeType
    {
        public int Id { get; set; }
        public int SiteId { get; set; }
        public byte EmployeeTypeId { get; set; }

        public EmployeeType EmployeeType { get; set; }
        public Site Site { get; set; }
    }
}