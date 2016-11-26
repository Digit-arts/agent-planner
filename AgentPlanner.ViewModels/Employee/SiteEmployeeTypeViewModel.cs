using AgentPlanner.ViewModels.Site;

namespace AgentPlanner.ViewModels.Employee
{
    public class SiteEmployeeTypeViewModel
    {
        public int Id { get; set; }
        public int SiteId { get; set; }
        public byte EmployeeTypeId { get; set; }

        public EmployeeTypeViewModel EmployeeTypeViewModel { get; set; }
        public SiteViewModel SiteViewModel { get; set; }
    }
}