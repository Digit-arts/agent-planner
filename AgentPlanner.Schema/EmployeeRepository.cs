using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using AgentPlanner.DataAccess;
using AgentPlanner.Repositories.Contarct;

namespace AgentPlanner.Repositories
{
    public class EmployeeRepository : BaseRepository<Employee, int>
    {
        public override int Add(Employee model)
        {
            model.CreatedDate = DateTime.UtcNow;
            model.IsDeleted = false;
            Db.Employees.Add(model);
            SaveChanges();
            return model.Id;
        }

        public override int Update(Employee model)
        {
            var dbEmployee = Get(model.Id);

            //dbEmployee.EmployeeCode = model.EmployeeCode;
            dbEmployee.FirstName = model.FirstName;
            dbEmployee.LastName = model.LastName;
            dbEmployee.Address = model.Address;
            dbEmployee.Address2 = model.Address;
            dbEmployee.ZipCode = model.ZipCode;
            dbEmployee.City = model.City;
            dbEmployee.PhoneNumber = model.PhoneNumber;
            dbEmployee.EmailAddress = model.EmailAddress;
            dbEmployee.PhotoResouceId = model.PhotoResouceId;
            dbEmployee.DateOfBirth = model.DateOfBirth;
            dbEmployee.Comments = model.Comments;
            dbEmployee.IsActive = model.IsActive;
            dbEmployee.ModificationDate = DateTime.UtcNow;

            SaveChanges();
            return model.Id;
        }

        public override int Remove(int id)
        {
            var employee = Get(id);

            employee.IsDeleted = true;
            employee.DeletedDate = DateTime.UtcNow;

            return SaveChanges();
        }

        public override Employee Get(int id)
        {
            return GetIQueryable().FirstOrDefault(x => x.Id.Equals(id));
        }
        
        public bool IsCodeExisting(string employeeCode)
        {
            return GetIQueryable().Any(x => x.EmployeeCode.Equals(employeeCode));
        }

        public IEnumerable<Employee> GetEmployees(int pageSize, int skipSize)
        {
            return GetIQueryable()
                .AsNoTracking()
                .Skip(() => skipSize)
                .Take(() => pageSize)
                .ToArray();
        }


        public IEnumerable<Employee> SearchTerm(string searchTerm, int employeeTypeId)
        {
            return
                GetIQueryable()
                    .Where(
                        x =>
                            (x.EmailAddress.Contains(searchTerm) || x.EmployeeCode.Contains(searchTerm) ||
                            x.FirstName.Contains(searchTerm) || x.LastName.Contains(searchTerm)) && x.EmployeeTypeId == employeeTypeId);
        }


        public int Count()
        {
            return GetIQueryable().Count();
        }

        private IQueryable<Employee> GetIQueryable()
        {
            return Db.Employees.Where(x => !x.IsDeleted).OrderByDescending(x => x.FirstName);
        } 
    }
}