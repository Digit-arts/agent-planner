using System;
using System.Linq;
using AgentPlanner.DataAccess;
using AgentPlanner.Repositories.Contarct;

namespace AgentPlanner.Repositories
{
    public class PublicHolidayRepository : BaseRepository<PublicHoliday, byte>
    {
        public override byte Add(PublicHoliday model)
        {
            throw new NotImplementedException();
        }

        public override byte Update(PublicHoliday model)
        {
            throw new NotImplementedException();
        }

        public override int Remove(byte id)
        {
            throw new NotImplementedException();
        }

        public override PublicHoliday Get(byte id)
        {
            return GetIQueryable().FirstOrDefault(x => x.Id == id);
        }

        public PublicHoliday[] GetAll()
        {
            return GetIQueryable().ToArray();
        }

        public bool IsHoliday(DateTime date)
        {
            return GetIQueryable().Any(x => x.HolidayDate.Day == date.Day && x.HolidayDate.Month == date.Month);
        }

        private IQueryable<PublicHoliday> GetIQueryable()
        {
            return Db.PublicHolidays.AsQueryable();
        }
    }
}