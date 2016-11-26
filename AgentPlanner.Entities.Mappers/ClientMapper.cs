using System.Collections.Generic;
using System.Linq;

namespace AgentPlanner.Entities.Mappers
{
    public static class ClientMapper
    {
        public static Client.Client ToDto(this DataAccess.Client client)
        {
            if (client == null) return null;

            return new Client.Client
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
                PaymentMethod = client.PaymentMethod.ToDto()
            };
        }


        public static Client.Client[] ToDtos(this IEnumerable<DataAccess.Client> clients)
        {
            return clients.Select(x => x.ToDto()).ToArray();
        }


        public static DataAccess.Client ToDbo(this Client.Client client)
        {
            return new DataAccess.Client
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
                HourlyRate = client.HourlyRate,
                ModificationDate = client.ModificationDate
            };
        }



    }
}