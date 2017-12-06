using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Model
{
    public class StateModel
    {
        public StateModel()
        {
            employees = new List<EmployeeModel>();
        }
        public int ID { get; set; }
        [Required]
        public string state { get; set; }
        public List<EmployeeModel> employees { get; set; }
    }
}
