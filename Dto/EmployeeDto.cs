using System;

namespace MasGlobal.Dto
{
    public class EmployeeDto
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public int Salary { get; set; }

        public SalaryTypeDto SalaryType { get; set; }

    }
}
