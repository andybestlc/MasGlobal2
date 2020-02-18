using MasGlobal.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace MasGlobal.Domain.Contracts
{
    public interface IEmployeeDomain
    {

        IEnumerable<EmployeeDto> GetAllEmployees();

        EmployeeDto GetEmployee(int id);

    }
}
