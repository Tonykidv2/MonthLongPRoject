using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EFDatabase.TBL;
using WebApplication1.Model;

namespace DatabaseService.Controllers
{
    [Route("api/Employee/")]
    
    public class EmployeeController : ApiController
    {
        EmployeeManagementContext dbContext = new EmployeeManagementContext();
        // GET api/<controller>
        [HttpGet]
        public string Get()
        {
            return "Employee API Running";
        }

        // GET api/<controller>/5
        [HttpGet]
        public EmployeeModel Get(int id)
        {
            Employee emp = dbContext.Employees.Single(p => p.EmployeeID == id);
            EmployeeModel empModel = new EmployeeModel()
            {
                ID = id,
                Name = emp.Name,
                Email = emp.Email,
                PhoneNumber = (int)emp.PhoneNumber,
                Age = emp.Age,
                DOB = emp.DateofBirth,
                state = new StateModel() { ID = emp.State1.StateID, state = emp.State1.Name }
            };
            return empModel;
        }

        // POST api/<controller>
        [HttpPost]
        public bool Post([FromBody]EmployeeModel value)
        {
            try
            {
                Employee emp = new Employee()
                {
                    Name = value.Name,
                    PhoneNumber = value.PhoneNumber,
                    Email = value.Email,
                    DateofBirth = value.DOB,
                    IsMale = value.isMale,
                    Age = value.Age,
                    State = value.state.ID,
                    State1 = dbContext.States.Single(p => p.StateID == value.state.ID)
                };
                dbContext.Employees.Add(emp);
                dbContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        // PUT api/<controller>/5
        [HttpPut]
        public bool Put(int id, [FromBody]EmployeeModel value)
        {
            try
            {
                Employee TobeUpdated = dbContext.Employees.Find(value.ID);

                if(TobeUpdated != null)
                {
                    TobeUpdated.Age = value.Age;
                    TobeUpdated.DateofBirth = value.DOB;
                    TobeUpdated.State = value.state.ID;
                    TobeUpdated.State1 = dbContext.States.Single(s => s.StateID == value.state.ID);
                    TobeUpdated.Email = value.Email;
                    TobeUpdated.IsMale = value.isMale;
                    TobeUpdated.Name = TobeUpdated.Name;
                    TobeUpdated.PhoneNumber = value.PhoneNumber;

                    dbContext.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
            return false;
        }

        // DELETE api/<controller>/5
        [HttpDelete]
        public string Delete(int id)
        {
            try
            {
                Employee TobeDeleted = dbContext.Employees.Find(id);
                if (TobeDeleted != null)
                {
                    dbContext.Employees.Remove(TobeDeleted);
                    dbContext.SaveChanges();

                    return "Entry Deleted";
                }
                else
                    return "Nothing Deleted";

            }
            catch
            {
                return "Error";
            }
        }
    }
}