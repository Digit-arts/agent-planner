using System;
using System.Collections.Generic;
using System.Linq;
using AgentPlanner.Entities.Employee;
using AgentPlanner.Entities.Enums;
using AgentPlanner.Entities.Exceptions;
using AgentPlanner.Entities.Mappers;
using AgentPlanner.Repositories;

namespace AgentPlanner.Services
{
    public class AssignmentService
    {
        private readonly AssignmentRepository _assignmentRepository;
        private readonly EmployeeService _employeeService;
        private readonly ContractService _contractService;
        private readonly AssignmentTypeService _assignmentTypeService;
        private readonly SiteService _siteService;
        private readonly PublicHolidayService _publicHolidayService;

        public AssignmentService()
        {
            _assignmentRepository = new AssignmentRepository();
            _employeeService = new EmployeeService();
            _contractService = new ContractService();
            _assignmentTypeService = new AssignmentTypeService();
            _siteService = new SiteService();
            _publicHolidayService = new PublicHolidayService();
        }

        public Assignment GetAssignment(int assignmentId)
        {
            return _assignmentRepository.Get(assignmentId).ToDto();
        }

        public int AddAssignment(Assignment assignment)
        {
            var contract = _contractService.Get(assignment.ContractId);

            if (assignment.StartDateTime < contract.StartDate || assignment.EndDateTime > contract.EndDate)
                throw new ContractAssignmentDateException();

            return _assignmentRepository.Add(assignment.ToDbo());
        }

        public int UpdateAssignment(int assignmentId, Assignment assignment)
        {
            assignment.Id = assignmentId;
            return _assignmentRepository.Update(assignment.ToDbo());
        }

        public int DeleteAssignment(int assignmentId)
        {
            return _assignmentRepository.Remove(assignmentId);
        }

        public Assignment[] GetPaginatedAssignments(int pageSize, int page = 1)
        {
            var resultsToSkip = (page - 1) * pageSize;

            return _assignmentRepository.GetAssignments(pageSize, resultsToSkip).ToDtos();
        }
        public Assignment[] GetByContractId(int contractId, int pageSize, int page = 1)
        {
            var resultsToSkip = (page - 1) * pageSize;

            var assignment = _assignmentRepository.GetByContractId(contractId, pageSize, resultsToSkip).ToDtos();
            foreach (var a in assignment)
            {
                a.Employee = _employeeService.GetEmployee(a.EmployeeId);
                a.Contract = _contractService.Get(a.ContractId);
                a.AssignmentType = _assignmentTypeService.Get(a.AssignmentTypeId);
            }
            return assignment;
        }
        public int GetTotalAssignmentsCount()
        {
            return _assignmentRepository.Count();
        }

        public int GetTotalAssignmentsCount(int contractId)
        {
            return _assignmentRepository.Count(contractId);
        }


        public Assignment[] GetAssignmentsByDates(DateTime startDate, DateTime endDate)
        {
            return _assignmentRepository.GetAssignmentsByDate(startDate, endDate).ToDtos();
        }

        public Assignment[] GetAssignmentsByEmployeeId(int employeeId, DateTime startDate, DateTime endDate)
        {
            return _assignmentRepository.GetAssignmentsByEmployeeId(employeeId, startDate.Date, endDate.Date).ToDtos();
        }

        public Assignment[] GetAssignmentsByContractId(int contractId, DateTime startDate, DateTime endDate)
        {
            return _assignmentRepository.GetAssignmentsByContractId(contractId, startDate.Date, endDate.Date).ToDtos();
        }

        public Assignment[] GetAssignmentsByContractId(int contractId)
        {
            return _assignmentRepository.GetAssignmentsByContractId(contractId).ToDtos();
        }

        public Assignment[] GetAssignmentsByClientId(int clientId, DateTime startDate, DateTime endDate)
        {
            var clientSiteIds = _siteService.GetSitesByClient(clientId).Select(x => x.Id).ToArray();
            var clientSitesContrats = _contractService.GetContractsForSites(clientSiteIds);

            var clientAssignments = new List<Assignment>();

            foreach (var contrat in clientSitesContrats)
            {
                clientAssignments.AddRange(_assignmentRepository.GetAssignmentsByContractId(contrat.Id, startDate, endDate).ToDtos());
            }
            return clientAssignments.ToArray();
        }

        public double CalculateRegularTimeHours(Assignment assignment)
        {
            // Regular hours are from 00:00 i-e 12:00 AM to 8PM evening
            // so a person can work a total of 20 regula hrs.
            if (assignment.StartDateTime.Date == assignment.EndDateTime.Date)
            {
                // weekend function should handle this logic
                if (IsWeekend(assignment.StartDateTime)) return 0;

                // public holiday function should handle this logic
                if (_publicHolidayService.IsHoliday(assignment.StartDateTime)) return 0;

                var totalRegularHours = (assignment.EndDateTime - assignment.StartDateTime).TotalHours;
                if (totalRegularHours > 20) return 20;
                return totalRegularHours;
            }
            else
            {
                // iterate over each day and calculate regular hours.
                var startDate = assignment.StartDateTime.Date;
                var totalRegularHours = 0d;
                for (var i = 1; startDate <= assignment.EndDateTime.Date; startDate = startDate.AddDays(i))
                {
                    // weekend function should handle this logic
                    if (IsWeekend(startDate)) continue;

                    // public holiday function should handle this logic
                    if (_publicHolidayService.IsHoliday(startDate)) continue;

                    if (startDate.Date == assignment.EndDateTime.Date)
                    {
                        var hrs = (assignment.EndDateTime - assignment.StartDateTime.AddDays(i - 1)).TotalHours;
                        if (hrs > 20)
                        {
                            totalRegularHours += 20;
                        }
                        else
                        {
                            totalRegularHours += hrs;
                        }
                    }
                    else
                    {
                        totalRegularHours += 20;
                    }
                }
                return totalRegularHours;
            }
            //var daysSpan = assignment.EndDateTime - assignment.StartDateTime;
            //var numberOfDays = daysSpan.TotalDays;

            //var timeSpan = assignment.EndDateTime.TimeOfDay - assignment.StartDateTime.TimeOfDay;
            //var timePerDay = timeSpan.TotalHours;

            //if (timePerDay >= 8)
            //{
            //    return numberOfDays * 8;
            //}
            //return numberOfDays * timePerDay;
        }

        public double CalculateNightTimeHours(Assignment assignment)
        {
            if (assignment.StartDateTime.Date == assignment.EndDateTime.Date)
            {
                // weekendNightHours function should handle this logic
                if (IsWeekend(assignment.EndDateTime)) return 0;

                // public holiday function should handle this logic
                if (_publicHolidayService.IsHoliday(assignment.StartDateTime)) return 0;

                var totalHours = (assignment.EndDateTime - assignment.StartDateTime).TotalHours;
                if (totalHours > 20) return totalHours - 20;
                return 0;
            }
            
            // iterate over each day and calculate night hours.
            var startDate = assignment.StartDateTime.Date;
            var endHour = assignment.EndDateTime.Hour;
            var totalNightHours = 0d;

            for (var i = 1; startDate <= assignment.EndDateTime.Date; startDate = startDate.AddDays(i))
            {
                // weekendNightHours function should handle this logic
                if (IsWeekend(startDate)) continue;

                // public holiday function should handle this logic
                if (_publicHolidayService.IsHoliday(assignment.StartDateTime)) return 0;

                if (endHour > 20) totalNightHours += endHour - 20;
            }
            return totalNightHours;
        }

        public double CalculateNightTimeWeekendHours(Assignment assignment)
        {
            // pending confirmation from client
            throw new NotImplementedException();
        }

        public double CalculateHolidayHours(Assignment assignment)
        {
            var totalHolidayHours = 0d;
            var startDate = assignment.StartDateTime.Date;

            for (var i = 1; startDate <= assignment.EndDateTime.Date; startDate = startDate.AddDays(i))
            {
                if (_publicHolidayService.IsHoliday(startDate) && !IsWeekend(startDate))
                {
                    totalHolidayHours += (assignment.StartDateTime - assignment.EndDateTime).TotalHours;
                }
            }

            return totalHolidayHours;
        }



        public double CalculateWeekEndHours(Assignment assignment)
        {
            var startDate = assignment.StartDateTime.Date;
            var totalRegularHours = 0d;
            for (var i = 1; startDate <= assignment.EndDateTime.Date; startDate = startDate.AddDays(i))
            {
                if (!IsWeekend(startDate)) continue;
                if (startDate.Date == assignment.EndDateTime.Date)
                {
                    var hrs = (assignment.EndDateTime - assignment.StartDateTime.AddDays(i - 1)).TotalHours;
                    if (hrs > 20)
                    {
                        totalRegularHours += 20;
                    }
                    else
                    {
                        totalRegularHours += hrs;
                    }
                }
                else
                {
                    totalRegularHours += 20;
                }
            }
            return totalRegularHours;
        }

        public double AddPercentageIncreaseInRate(double regularRate, RateIncrease type)
        {
            var config = new BillingRateConfigurationService().GetBillingRateConfiguration();
            switch (type)
            {
                case RateIncrease.Night:
                    return (regularRate * (double)config.NightTimePercentageIncrease) + regularRate;
                case RateIncrease.Holiday:
                    return (regularRate * (double)config.HolidayPercentageIncrease) + regularRate;
                case RateIncrease.Weekend:
                    return (regularRate * (double)config.WeekendPercentageIncrease) + regularRate;
                default:
                    throw new Exception("AddPercentageIncreaseInRate");
            }

        }


        private static List<DateTime> GetAllDatesInAssignmentRange(Assignment assignment)
        {
            var allDatesInRange = new List<DateTime>();

            for (var date = assignment.StartDateTime; date <= assignment.EndDateTime; date = date.AddDays(1))
                allDatesInRange.Add(date);
            return allDatesInRange;
        }

        private bool IsWeekend(DateTime date)
        {
            return date.DayOfWeek == DayOfWeek.Sunday;
        }
    }
}