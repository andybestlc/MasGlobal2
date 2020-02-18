using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using MasGlobal.Domain;
using MasGlobal.Domain.Contracts;
using MasGlobal.Dto;
using MasGlobal.Model;
using MasGLobal.Model;
using Moq;
using Moq.Language;
using NUnit.Framework;
using Persistance.Interface;


namespace Test
{
    [TestFixture]
    public class EmployeeDomainTests
    {

        private Mock<IEmployeeRepository> _employeeRepository;
        private IEmployeeDomain _employeeDomain;
        private Mock<IMapper> _mapper;

        [SetUp]
        public void Setup()
        {

           _employeeRepository = new Mock<IEmployeeRepository>();
           _mapper = new Mock<IMapper>();
            _employeeDomain = new EmployeeDomain(_mapper.Object,_employeeRepository.Object);
        }

        [Test]
        public void Get_Employee_ReturnEmployeeDto()
        {
            //arrange
            var employee = new Employee()
            {
                Id = 1,
                Name = "a",
                salary = 1,
                SalaryType = new SalaryType() { Id = 1, Name = "b" }
            };

          _employeeRepository.Setup(c => c.GetEmployeeById(employee.Id)).Returns(employee);

          _mapper.Setup(m => m.Map<EmployeeDto>(employee)).Returns(new EmployeeDto()
          {
              Id = employee.Id,
              Name = employee.Name,
              Salary = 120 * employee.salary * 12
          });
          //act
            var result = _employeeDomain.GetEmployee(employee.Id);
            
          //assert
            Assert.That(result,Is.InstanceOf<EmployeeDto>());

        }
    }
}
