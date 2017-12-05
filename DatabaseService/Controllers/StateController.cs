using EFDatabase.TBL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.Model;

namespace DatabaseService.Controllers
{
    
    [Route("api/State/")]
    public class StateController : ApiController
    {
        EmployeeManagementContext dbContext = new EmployeeManagementContext();
        // GET api/<controller>
        [HttpGet]
        public string Get()
        {
            return "State API Running";
        }

        // GET api/<controller>/5
        [HttpGet]
        public StateModel Get(int id)
        {
            try
            {
                State sta = dbContext.States.Find(id);
                StateModel stm = new StateModel()
                {
                    ID = id,
                    state = sta.Name,
                    
                };
                for (int i = 0; i < sta.Employees.Count; i++)
                {
                    EmployeeController empCon = new EmployeeController();
                    EmployeeModel EmpMod = empCon.Get(sta.Employees.ToList()[i].EmployeeID);
                    stm.employees.Add(EmpMod);
                }
                return stm;
            }
            catch
            {
                return null;
            }
            
        }

        // POST api/<controller>
        public void Post([FromBody]StateModel value)
        {

        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}