using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Model
{
    public class EmployeeModel
    {
        public EmployeeModel()
        {
            edu = new List<EducationModel>();
        }

        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [Phone]
        public string PhoneNumber { get; set; }
        public int Age { get; set; }
        [Required]
        public DateTime DOB { get; set; }
        public StateModel state { get; set; }
        [Required]
        public bool isMale { get; set; }
        public List<EducationModel> edu { get; set; }

    }
}
