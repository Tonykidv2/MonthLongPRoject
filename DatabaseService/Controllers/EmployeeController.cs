using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EFDatabase.TBL;
using WebApplication1.Model;
using System.Web.Http.Description;
using System.Web.Http.Cors;

namespace DatabaseService.Controllers
{
    [Route("api/Employee/")]
    [EnableCors(origins: "*", headers:"*", methods:"*")]
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
        [Route("api/employee/{id}")]
        public EmployeeModel Get(int id)
        {
            Employee emp = dbContext.Employees.Find(id);
            EmployeeModel empModel = new EmployeeModel()
            {
                ID = id,
                Name = emp.Name,
                Email = emp.Email,
                PhoneNumber = emp.PhoneNumber,
                Age = emp.Age,
                DOB = emp.DateofBirth,
                state = new StateModel() { ID = emp.State1.StateID, state = emp.State1.Name },
                isMale = emp.IsMale
            };

            List<Education> edu = emp.Educations.ToList();
            foreach (var item in edu)
            {
                empModel.edu.Add(new EducationModel()
                {
                    eduType = item.Name,
                    ID = item.EducationID
                });
            }
            return empModel;
        }

        [HttpGet]
        [Route("api/employee/GetAll")]
        public HttpResponseMessage GetAll()
        {
            //return Request.CreateResponse(HttpStatusCode.OK, dbContext.Employees);
            List<EmployeeModel> empMList = new List<EmployeeModel>();
            try
            {
                List<Employee> empList = dbContext.Employees.ToList();

                for (int i = 0; i < empList.Count; i++)
                {
                    EmployeeModel Mod = new EmployeeModel();
                    Mod.Age = empList[i].Age;
                    Mod.DOB = empList[i].DateofBirth;
                    Mod.Email = empList[i].Email;
                    Mod.ID = empList[i].EmployeeID;
                    Mod.isMale = empList[i].IsMale;
                    Mod.Name = empList[i].Name;
                    Mod.PhoneNumber = empList[i].PhoneNumber;
                    Mod.state = new StateModel() { ID = empList[i].State1.StateID, state = empList[i].State1.Name };

                    empMList.Add(Mod);
                }

                return Request.CreateResponse(HttpStatusCode.OK, empMList);
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.Conflict, empMList);
            }

        }


        // POST api/<controller>
        [HttpPost]
        public bool Post([FromBody]EmployeeModel value)
        {
            bool check = ModelState.IsValid;
            if (!check)
                return false;
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
                foreach (var item in value.edu)
                {
                    emp.Educations.Add(dbContext.Educations.Find(item.ID));
                }
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
        [Route("api/employee/{id}")]
        public bool Put(int id, [FromBody]EmployeeModel value)
        {
            bool check = ModelState.IsValid;
            if (!check)
                return false;
            try
            {
                Employee TobeUpdated = dbContext.Employees.Find(value.ID);

                if(TobeUpdated != null)
                {
                    TobeUpdated.Age = value.Age;
                    TobeUpdated.DateofBirth = value.DOB;
                    TobeUpdated.State = value.state.ID;
                    TobeUpdated.State1 = dbContext.States.Find(value.state.ID);
                    TobeUpdated.Email = value.Email;
                    TobeUpdated.IsMale = value.isMale;
                    TobeUpdated.Name = value.Name;
                    TobeUpdated.PhoneNumber = value.PhoneNumber;
                    TobeUpdated.Educations.Clear();
                    foreach (var item in value.edu)
                    {
                        TobeUpdated.Educations.Add(dbContext.Educations.Find(item.ID));
                    }
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
        [Route("api/employee/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                Employee TobeDeleted = dbContext.Employees.Find(id);
                if (TobeDeleted != null)
                {
                    dbContext.Employees.Remove(TobeDeleted);
                    dbContext.SaveChanges();

                    return Request.CreateResponse(HttpStatusCode.OK, "Entry Delete");
                }
                else
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Nothing Deleted");

            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.Conflict, "Error");
            }
        }

        [HttpOptions]
        public HttpResponseMessage Options(int id)
        {
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}