using System;
using System.Linq;
using AgentPlanner.DataAccess;
using AgentPlanner.Repositories.Contarct;

namespace AgentPlanner.Repositories
{
    public class ResourceRepository : BaseRepository<Resource, int>
    {
        public override int Add(Resource model)
        {
            model.CreatedDate = DateTime.UtcNow;
            Db.Resources.Add(model);
            SaveChanges();
            return model.Id;
        }

        public override int Update(Resource model)
        {
            throw new NotImplementedException();
        }

        public override int Remove(int id)
        {
            throw new NotImplementedException();
        }

        public override Resource Get(int id)
        {
            return GetIQueryable().FirstOrDefault(x => x.Id == id);
        }

        private IQueryable<Resource> GetIQueryable()
        {
            return Db.Resources;
        }
    }
}
