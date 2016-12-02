using System;
using System.Data.Entity;
using System.Linq;
using AgentPlanner.DataAccess;
using AgentPlanner.Repositories.Contarct;

namespace AgentPlanner.Repositories
{
    public class AssignmentRepository : BaseRepository<Assignment, int>
    {
        public override int Add(Assignment model)
        {
            Db.Assignments.Add(model);
            SaveChanges();
            return model.Id;
        }

        public override int Update(Assignment model)
        {
            var assignment = Get(model.Id);

            assignment.ContractId = model.ContractId;
            assignment.EmployeeId = model.EmployeeId;
            assignment.AssignmentTypeId = model.AssignmentTypeId;
            assignment.StartDateTime = model.StartDateTime;
            assignment.EndDateTime = model.EndDateTime;
            assignment.TotalHolidayHours = model.TotalHolidayHours;
            assignment.TotalNightTimeHours = model.TotalNightTimeHours;
            assignment.TotalRegularTimeHours = model.TotalRegularTimeHours;
            assignment.TotalWeekEndHours = model.TotalWeekEndHours;
            assignment.HolidayHoursRate = model.HolidayHoursRate;
            assignment.NightTimeHoursRate = model.NightTimeHoursRate;
            assignment.WeekHoursRate = model.WeekHoursRate;
            assignment.RegularHoursRate = model.RegularHoursRate;

            return SaveChanges();
        }

        public override int Remove(int id)
        {
            var assignment = Get(id);

            assignment.IsDeleted = true;

            return SaveChanges();
        }

        public override Assignment Get(int id)
        {
            return GetIQueryable().FirstOrDefault(x => x.Id.Equals(id));
        }

        public Assignment[] GetAssignments(int pageSize, int skipSize)
        {
            return GetIQueryable()
                .AsNoTracking()
                .Skip(() => skipSize)
                .Take(() => pageSize)
                .ToArray();
        }


        public Assignment[] GetAssignmentsByDate(DateTime startDate, DateTime endDate)
        {
            return GetIQueryable().Where(x => x.StartDateTime >= startDate && x.EndDateTime <= endDate ).ToArray();
        }


        public Assignment[] GetByContractId(int contractId,int pageSize, int skipSize)
        {
            return GetIQueryable().Where(x=>x.ContractId== contractId)
                .AsNoTracking()
                .Skip(() => skipSize)
                .Take(() => pageSize)
                .ToArray();
        }
        public int Count()
        {
            return GetIQueryable().Count();
        }

        public int Count(int contractId)
        {
            return GetIQueryable().Count(x=>x.ContractId == contractId);
        }

        public Assignment[] GetAssignmentsByEmployeeId(int employeeId, DateTime startDate, DateTime endDate)
        {
            return GetIQueryable().Where(x => x.EmployeeId.Equals(employeeId) && (x.StartDateTime >= startDate && x.EndDateTime <= endDate)).ToArray();
        }

        public Assignment[] GetAssignmentsByContractId(int contractId, DateTime startDate, DateTime endDate)
        {
            return GetIQueryable().Where(x => x.ContractId.Equals(contractId) && (x.StartDateTime >= startDate && x.EndDateTime <= endDate)).ToArray();
        }

        public Assignment[] GetAssignmentsByContractId(int contractId)
        {
            return GetIQueryable().Where(x => x.ContractId.Equals(contractId)).ToArray();
        }

        public Assignment[] GetAssignmentsByAssignmentTypeId(int assignmentTypeId)
        {
            return GetIQueryable().Where(x => x.AssignmentTypeId == assignmentTypeId).ToArray();
        }

        private IQueryable<Assignment> GetIQueryable()
        {
            return Db.Assignments.Where(x => !x.IsDeleted).OrderBy(x=>x.ContractId);
        }
    }
}