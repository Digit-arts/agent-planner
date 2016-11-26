using System;
using System.Linq;
using AgentPlanner.DataAccess;
using AgentPlanner.Repositories.Contarct;

namespace AgentPlanner.Repositories
{
    public class EmployeeTypeRepository : BaseRepository<EmployeeType, int>
    {
        public override int Add(EmployeeType model)
        {
            throw new NotImplementedException();
        }

        public override int Update(EmployeeType model)
        {
            throw new NotImplementedException();
        }

        public override int Remove(int id)
        {
            throw new NotImplementedException();
        }

        public override EmployeeType Get(int id)
        {
            throw new NotImplementedException();
        }
        public EmployeeType[] GetAllEmployeeTypes()
        {
            return GetIQueryable().ToArray();
        }
        private IQueryable<EmployeeType> GetIQueryable()
        {
            return Db.EmployeeTypes;
        }
    }
}