using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using AgentPlanner.DataAccess;
using AgentPlanner.Repositories.Contarct;

namespace AgentPlanner.Repositories
{
    public class SiteRepository : BaseRepository<Site, int>
    {
        public override int Add(Site model)
        {
            model.CreatedDate = DateTime.UtcNow;
            Db.Sites.Add(model);
            SaveChanges();
            return model.Id;
        }

        public override int Update(Site model)
        {
            var dbSite = Get(model.Id);

            dbSite.ClientId = model.ClientId;
            //dbSite.SideCode = model.SideCode;
            dbSite.Name = model.Name;
            dbSite.Address = model.Address;
            dbSite.Address2 = model.Address2;
            dbSite.ZipCode = model.ZipCode;
            dbSite.City = model.City;
            dbSite.ContactName = model.ContactName;
            dbSite.ContactPhoneNumber = model.ContactPhoneNumber;
            dbSite.EmailAddress = model.EmailAddress;
            dbSite.Comments = model.Comments;
            dbSite.IsActive = model.IsActive;

            dbSite.ModificationDate = DateTime.UtcNow;


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

        public override Site Get(int id)
        {
            return GetIQueryable().FirstOrDefault(x => x.Id == id);
        }

        public bool IsCodeExisting(string siteCode)
        {
            return GetIQueryable().Any(x => x.SideCode.Equals(siteCode));
        }

        public IEnumerable<Site> GetSites(int pageSize, int skipSize)
        {
            return GetIQueryable()
                .AsNoTracking()
                .Skip(() => skipSize)
                .Take(() => pageSize)
                .ToArray();
        }

        public IEnumerable<Site> GetSites(int clientId)
        {
            return GetIQueryable()
                .AsNoTracking()
                .Where(x => x.ClientId.Equals(clientId))
                .ToArray();
        } 

        public int Count()
        {
            return GetIQueryable().Count();
        }

        private IQueryable<Site> GetIQueryable()
        {
            return Db.Sites.Where(x => !x.IsDeleted).OrderByDescending(x => x.Name);
        }
    }
}