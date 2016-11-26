using System.Collections.Generic;
using System.Linq;
using AgentPlanner.ViewModels.Client;

namespace AgentPlanner.ViewModels.Mappers
{
    public static class ClientViewModelMapper
    {
        public static ClientViewModel ToVm(this Entities.Client.Client client)
        {
            if (client == null) return null;

            return new ClientViewModel
            {
                Id = client.Id,
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
                IsActive = client.IsActive,
                CreatedDate = client.CreatedDate,
                ModificationDate = client.ModificationDate,
                HourlyRate=client.HourlyRate,
                PaymentMethod = client.PaymentMethod.ToVm()
            };
        }


        public static ClientViewModel[] ToVms(this IEnumerable<Entities.Client.Client> clients)
        {
            return clients.Select(x => x.ToVm()).ToArray();
        }

    }
}