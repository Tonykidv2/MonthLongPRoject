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
        public HttpResponseMessage Get()
        {
            return Request.CreateResponse(HttpStatusCode.Found, "State API Running");
        }

        [HttpGet]
        [Route("api/State/GetAll")]
        public HttpResponseMessage GetAll()
        {
            List<StateModel> staMList = new List<StateModel>();
            List<State> staList = dbContext.States.ToList();

            EmployeeController empCon = new EmployeeController();
            for (int i = 0; i < staList.Count; i++)
            {
                StateModel Mod = new StateModel()
                {
                    state = staList[i].Name,
                    ID = staList[i].StateID
                };
                for (int z = 0; z < staList[i].Employees.Count; z++)
                {
                    EmployeeModel empMod = empCon.Get(staList[i].Employees.ToList()[z].EmployeeID);
                    Mod.employees.Add(empMod);
                }
                staMList.Add(Mod);
            }
            return Request.CreateResponse(HttpStatusCode.OK, staMList);
        }

        // GET api/<controller>/5
        [HttpGet]
        public HttpResponseMessage Get(int id)
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
                return Request.CreateResponse(HttpStatusCode.OK, stm);
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.Conflict);
            }
            
        }

        // POST api/<controller>
        [HttpPost]
        public HttpResponseMessage Post([FromBody]StateModel value)
        { 
            try
            {
                State sta = new State()
                {
                    Name = value.state
                };
                dbContext.States.Add(sta);
                dbContext.SaveChanges();

                return Request.CreateResponse(HttpStatusCode.OK, true);
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.Conflict, false);
            }
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {

        }

        [HttpDelete]
        // DELETE api/<controller>/5
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                State sta = dbContext.States.Find(id);
                dbContext.States.Remove(sta);
                dbContext.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK, true);
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.Conflict, false);
            }
        }

        [HttpDelete]
        // DELETE api/<controller>/5
        public HttpResponseMessage Delete(string value)
        {
            try
            {
                State sta = dbContext.States.Single(p =>p.Name == value);
                dbContext.States.Remove(sta);
                dbContext.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK, true);
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.Conflict, false);
            }
        }
    }
}