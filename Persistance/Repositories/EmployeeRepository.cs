using Persistance.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MasGLobal.Model;
using Microsoft.EntityFrameworkCore;

namespace Persistance.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext appDbContext;

        public EmployeeRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
       
        Employee IEmployeeRepository.GetEmployeeById(int id)
        {
            return appDbContext.Employees.Include(o => o.SalaryType).FirstOrDefault(r => r.Id == id);
        }

        public IEnumerable<Employee> GetEmployees()
        {
            return appDbContext.Employees.Include(o =>o.SalaryType);
        }

        public Employee Add(Employee employee)
        {
           // employee.Id = this.GetEmployees().Max(e => e.Id) + 1;
            appDbContext.Employees.Add(employee);
            appDbContext.SaveChanges();
            return employee;
        }

        public Employee Update(Employee employee)
        {
            var changeEmployee = this.appDbContext.Attach(employee);
            changeEmployee.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            appDbContext.SaveChanges();
            return employee;
        }

        public void Delete(Employee employee)
        {
            appDbContext.Employees.Remove(employee);
            appDbContext.SaveChanges();
        }
    }
}
