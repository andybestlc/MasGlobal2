using System;
using System.Collections.Generic;
using System.Text;
using MasGLobal.Model;

namespace MasGlobal.Model
{
    public class SalaryType
    {
  
            public int Id { get; set; }

            public string Name { get; set; }

            public ICollection<Employee> Employee { get; set; }

    }
}
