using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Model
{
    public class EmployeeModel
    {

        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        public int PhoneNumber { get; set; }
        public int Age { get; set; }
        public DateTime DOB { get; set; }
        public StateModel state { get; set; }
        [Required]
        public bool isMale { get; set; }

    }
}
