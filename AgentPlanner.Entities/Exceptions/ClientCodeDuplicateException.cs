namespace AgentPlanner.Entities.Exceptions
{
    public class ClientCodeDuplicateException : BaseExpection
    {
         public ClientCodeDuplicateException() : base("Client code duplicate detected.") { }
    }
}