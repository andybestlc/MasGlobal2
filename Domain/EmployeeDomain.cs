using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;
using AutoMapper;
using MasGlobal.Dto;
using MasGlobal.Domain.Contracts;
using MasGlobal.Dto;
using MasGLobal.Model;
using Persistance.Interface;
using Persistance.Repositories;

namespace MasGlobal.Domain
{
    public class EmployeeDomain : IEmployeeDomain
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public EmployeeDomain(IMapper mapper, IEmployeeRepository employeeRepository)
        {
                _employeeRepository = employeeRepository;
                _mapper = mapper;
      
        }

        public IEnumerable<EmployeeDto> GetAllEmployees()
        {
           var employees = _employeeRepository.GetEmployees();

           foreach (var employee in employees)
           {
               employee.salary = setsalary(employee.salaryId, employee.salary);
           }
           return _mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeDto>>(employees);
        }

        public EmployeeDto GetEmployee(int id)
        {
            var employee = _employeeRepository.GetEmployeeById(id);

            if (employee == null)
            {
                return (EmployeeDto) null;
            }

            employee.salary = setsalary(employee.salaryId, employee.salary);
            return _mapper.Map<EmployeeDto>(employee);
        }

        private int setsalary(int salaryTpe, int salary)
        {
            var newsalary = salary;

            if (salaryTpe == 1) // is hourly salary
            {
                newsalary = 120 * salary * 12;
            }
            else if (salaryTpe == 2) //Is monthly salary
            {
                newsalary = salary * 12;
            }
            return newsalary;
        }
    }
}
