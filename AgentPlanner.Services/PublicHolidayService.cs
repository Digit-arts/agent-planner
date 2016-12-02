using System;
using System.Linq;
using AgentPlanner.Entities.Billing;
using AgentPlanner.Entities.Mappers;
using AgentPlanner.Repositories;

namespace AgentPlanner.Services
{
    public class PublicHolidayService
    {
        private readonly PublicHolidayRepository _publicHolidayRepository;

        public PublicHolidayService()
        {
            _publicHolidayRepository = new PublicHolidayRepository();
        }

        public PublicHoliday GetPublicHoliday(byte id)
        {
            return _publicHolidayRepository.Get(id).ToDto();
        }

        public PublicHoliday[] GetAllPublicHolidays()
        {
            return _publicHolidayRepository.GetAll().ToDtos();
        }

        public bool IsHoliday(DateTime date)
        {
            return _publicHolidayRepository.IsHoliday(date);
        }

        public bool IsHoliday(DateTime[] dates)
        {
            bool result = false;

            foreach (var date in dates)
            {
                result = IsHoliday(date);
                if(result) break;
            }

            return result;
        }

        public int GetHolidaysCount(DateTime[] dates)
        {
            return dates.Count(IsHoliday);
        }
    }
}