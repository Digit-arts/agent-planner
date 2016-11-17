namespace AgentPlanner.Entities.Exceptions
{
    public class InvalidEmailOrPasswordException: BaseExpection
    {
        public InvalidEmailOrPasswordException()
            :base("Invalid email/password")
        {
            
        }
    }
}
