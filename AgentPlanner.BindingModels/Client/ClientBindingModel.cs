namespace AgentPlanner.BindingModels.Client
{
    public class ClientBindingModel
    {
        public string ClientCode { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Address2 { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string VatNumber { get; set; }
        public string ContactName { get; set; }
        public string ContactPhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public byte PaymentMethodId { get; set; }
        public string Comments { get; set; }
        public bool IsActive { get; set; }
        public double HourlyRate { get; set; }
    }
}