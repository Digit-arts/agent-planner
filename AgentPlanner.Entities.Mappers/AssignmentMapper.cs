﻿using System.Collections.Generic;
using System.Linq;
using AgentPlanner.Entities.Employee;
using AgentPlanner.Entities.Enums;

namespace AgentPlanner.Entities.Mappers
{
    public static class AssignmentMapper
    {
        public static Assignment ToDto(this DataAccess.Assignment assignment)
        {
            if (assignment == null) return null;

            return new Assignment {
                Id = assignment.Id,
                AssignmentTypeId = (AssignmentTypes)assignment.AssignmentTypeId,
                ContractId = assignment.ContractId,
                EmployeeId = assignment.EmployeeId,
                StartDateTime = assignment.StartDateTime,
                EndDateTime = assignment.EndDateTime,
                Employee = assignment.Employee.ToDto(),
                AssignmentType = assignment.AssignmentType.ToDto()
            };
        }

        public static Assignment[] ToDtos(this IEnumerable<DataAccess.Assignment> assignments)
        {
            return assignments.Select(x => x.ToDto()).ToArray();
        }

        public static DataAccess.Assignment ToDbo(this Assignment assignment)
        {
            return new DataAccess.Assignment
            {
                Id = assignment.Id,
                AssignmentTypeId =(byte) assignment.AssignmentTypeId,
                ContractId = assignment.ContractId,
                EmployeeId = assignment.EmployeeId,
                StartDateTime = assignment.StartDateTime,
                EndDateTime = assignment.EndDateTime
            };
        }
    }
}
