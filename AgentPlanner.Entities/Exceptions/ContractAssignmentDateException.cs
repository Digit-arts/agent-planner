namespace AgentPlanner.Entities.Exceptions
{
    public class ContractAssignmentDateException : BaseExpection
    {
        public ContractAssignmentDateException() : base("Assignment date is inconsistent with contract dates.") { }
    }
}