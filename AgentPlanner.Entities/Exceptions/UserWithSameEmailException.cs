namespace AgentPlanner.Entities.Exceptions
{
    public class UserWithSameEmailException:BaseExpection
    {
        public UserWithSameEmailException()
            :base("User with same email already exists")
        {
            
        }
    }
}
