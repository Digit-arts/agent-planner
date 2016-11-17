using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using AgentPlanner.DataAccess;
using AgentPlanner.Repositories.Contarct;

namespace AgentPlanner.Repositories
{
    public class ClientRepository : BaseRepository<Client, int>
    {
        public override int Add(Client model)
        {
            model.CreatedDate = DateTime.UtcNow;
            model.IsDeleted = false;
            Db.Clients.Add(model);
            SaveChanges();
            return model.Id;
        }

        public override int Update(Client model)
        {
            var dbClient = Get(model.Id);

            //dbClient.ClientCode = model.ClientCode;
            dbClient.Name = model.Name;
            dbClient.Address = model.Address;
            dbClient.Address2 = model.Address2;
            dbClient.ZipCode = model.ZipCode;
            dbClient.City = model.City;
            dbClient.ContactPhoneNumber = model.ContactPhoneNumber;
            dbClient.VatNumber = model.VatNumber;
            dbClient.ContactName = model.ContactName;
            dbClient.EmailAddress = model.EmailAddress;
            dbClient.PaymentMethodId = model.PaymentMethodId;
            dbClient.Comments = model.Comments;
            dbClient.IsActive = model.IsActive;

            dbClient.ModificationDate = DateTime.UtcNow;

            SaveChanges();
            return model.Id;
        }

        public override int Remove(int id)
        {
            var client = Get(id);

            client.IsDeleted = true;
            client.DeletedDate = DateTime.UtcNow;

            return SaveChanges();
        }

        public override Client Get(int id)
        {
            return GetIQueryable().FirstOrDefault(x => x.Id == id);
        }

        public bool IsCodeExisting(string clientCode)
        {
            return GetIQueryable().Any(x => x.ClientCode.Equals(clientCode));
        }

        public IEnumerable<Client> SearchTerm(string searchTerm)
        {
            return
                GetIQueryable()
                    .Where(
                        x =>
                            x.EmailAddress.Contains(searchTerm) || x.ClientCode.Contains(searchTerm) ||
                            x.Name.Contains(searchTerm));
        }
        public IEnumerable<Client> GetClients(int pageSize, int skipSize)
        {
            return GetIQueryable()
                .AsNoTracking()
                .Skip(() => skipSize)
                .Take(() => pageSize)
                .ToArray();
        }

        public int Count()
        {
            return GetIQueryable().Count();
        }

        private IQueryable<Client> GetIQueryable()
        {
            return Db.Clients.Where(x => !x.IsDeleted).OrderByDescending(x => x.Name);
        }
    }
}