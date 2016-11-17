using AgentPlanner.BindingModels.Client;

namespace AgentPlanner.BindingModels.Mappers
{
    public static class ClientBindingModelMapper
    {
        public static Entities.Client.Client ToDto(this ClientBindingModel client)
        {
            return new Entities.Client.Client
            {
                ClientCode = client.ClientCode,
                Name = client.Name,
                Address = client.Address,
                Address2 = client.Address2,
                ZipCode = client.ZipCode,
                City = client.City,
                VatNumber = client.VatNumber,
                ContactName = client.ContactName,
                ContactPhoneNumber = client.ContactPhoneNumber,
                EmailAddress = client.EmailAddress,
                PaymentMethodId = client.PaymentMethodId,
                Comments = client.Comments,
                IsActive = client.IsActive
            };
        }
    }
}