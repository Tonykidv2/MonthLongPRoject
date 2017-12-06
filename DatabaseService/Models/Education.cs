using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Model
{
    public class EducationModel
    {
        public EducationModel()
        {
            employees = new List<EmployeeModel>();
        }
        public int ID { get; set; }
        public string eduType { get; set; }
        public List<EmployeeModel> employees { get; set; }
    }
}
