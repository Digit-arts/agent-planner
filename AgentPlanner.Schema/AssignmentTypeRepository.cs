using System;
using System.Linq;
using AgentPlanner.DataAccess;
using AgentPlanner.Repositories.Contarct;

namespace AgentPlanner.Repositories
{
    public class AssignmentTypeRepository : BaseRepository<AssignmentType, byte>
    {
        public override byte Add(AssignmentType model)
        {
            throw new NotImplementedException();
        }

        public override byte Update(AssignmentType model)
        {
            throw new NotImplementedException();
        }

        public override int Remove(byte id)
        {
            throw new NotImplementedException();
        }

        public override AssignmentType Get(byte id)
        {
            return GetIQueryable().FirstOrDefault(x => x.Id == id);
        }
        public AssignmentType[] GetAllAssignmentTypes()
        {
            return GetIQueryable().ToArray();
        }
        private IQueryable<AssignmentType> GetIQueryable()
        {
            return Db.AssignmentTypes;
        }
    }
}
