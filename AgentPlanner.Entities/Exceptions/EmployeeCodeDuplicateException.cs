namespace AgentPlanner.Entities.Exceptions
{
    public class EmployeeCodeDuplicateException : BaseExpection
    {
         public EmployeeCodeDuplicateException() : base("Employee code duplicate detected.") { }
    }
}