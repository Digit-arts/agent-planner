namespace AgentPlanner.Entities.Exceptions
{
    public class SiteCodeDuplicateException : BaseExpection
    {
         public SiteCodeDuplicateException() : base("Site code duplicate detected.") { }
    }
}