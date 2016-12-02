namespace AgentPlanner.Entities.Exceptions
{
    public class InvoiceAlreadyCreatedException : BaseExpection
    {
        public InvoiceAlreadyCreatedException() : base("Invoice already created") { }
    }
}