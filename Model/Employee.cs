using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using MasGlobal.Model;

namespace MasGLobal.Model
{
    public class Employee
    {


        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }

        public int salary { get; set; }

        public int salaryId { get; set; }

        public   SalaryType SalaryType { get; set; }


    }
}
