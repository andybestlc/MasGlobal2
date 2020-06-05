using System;

namespace MasGlobal.Dto
{
    //employee class
    public class EmployeeDto
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public int Salary { get; set; }

        public SalaryTypeDto SalaryType { get; set; }

    }
}
