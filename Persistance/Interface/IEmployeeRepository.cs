using System;
using System.Collections.Generic;
using System.Text;
using MasGLobal.Model;

namespace Persistance.Interface
{
    public interface IEmployeeRepository
    {
        Employee GetEmployeeById(int id);

        IEnumerable<Employee> GetEmployees();

        Employee Add(Employee e);

        Employee Update(Employee employee);

        void Delete(Employee employee);
    }
}
