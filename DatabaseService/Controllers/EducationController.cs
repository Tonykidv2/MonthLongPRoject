using EFDatabase.TBL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using WebApplication1.Model;

namespace DatabaseService.Controllers
{
    [Route("api/Education/")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class EducationController : ApiController
    {
        EmployeeManagementContext dbContext = new EmployeeManagementContext();

        // GET api/<controller>
        [HttpGet]
        public HttpResponseMessage Get()
        {
            return Request.CreateResponse(HttpStatusCode.Found, "Education API running");
        }

        [HttpGet]
        [Route("api/education/getall")]
        public HttpResponseMessage GetAll()
        {
            List<EducationModel> eduMList = new List<EducationModel>();
            List<Education> eduList = dbContext.Educations.ToList();

            EmployeeController empCon = new EmployeeController();
            for (int i = 0; i < eduList.Count; i++)
            {
                EducationModel Mod = new EducationModel()
                {
                    eduType = eduList[i].Name,
                    ID = eduList[i].EducationID
                };
                //for (int z = 0; z < eduList[i].Employees.Count; z++)
                //{
                //    EmployeeModel empMod = empCon.Get(eduList[i].Employees.ToList()[z].EmployeeID);
                //    Mod.employees.Add(empMod);
                //}
                eduMList.Add(Mod);
            }
            return Request.CreateResponse(HttpStatusCode.OK, eduMList);
        }

        // GET api/<controller>/5
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            EducationModel retr = null;
            try
            {
                Education edu = dbContext.Educations.Find(id);
                if(edu != null)
                {
                    EducationModel eduM = new EducationModel()
                    {
                        eduType = edu.Name,
                        ID = edu.EducationID,

                    };
                    EmployeeController empCon = new EmployeeController();
                    for (int i = 0; i < edu.Employees.Count; i++)
                    {
                        EmployeeModel empMod = empCon.Get(edu.Employees.ToList()[i].EmployeeID);
                        eduM.employees.Add(empMod);
                    }
                    return Request.CreateResponse(HttpStatusCode.OK, eduM);
                }
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.Conflict, retr);
            }
            
            return Request.CreateResponse(HttpStatusCode.NotFound, retr);
        }

        // POST api/<controller>
        [HttpPost]
        public HttpResponseMessage Post([FromBody]EducationModel value)
        {
            try
            {
                Education edu = new Education()
                {
                    Name = value.eduType,
                };
                dbContext.Educations.Add(edu);
                return Request.CreateResponse(HttpStatusCode.OK, true);
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.NotModified, false);
            }
        }

        // PUT api/<controller>/5
        [HttpPut]
        public HttpResponseMessage Put(int id, [FromBody]EducationModel value)
        {
            try
            {
                Education ToBeUpdated = dbContext.Educations.Find(id);
                if(ToBeUpdated != null)
                {
                    ToBeUpdated.Name = value.eduType;
                    ToBeUpdated.Employees.Clear();
                    EmployeeController empCon = new EmployeeController();
                    for (int i = 0; i < value.employees.Count; i++)
                    {
                        Employee emp = dbContext.Employees.Find(value.employees[i].ID);
                        ToBeUpdated.Employees.Add(emp);
                    }
                    return Request.CreateResponse(HttpStatusCode.OK, true);
                }
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, false);
            }

            return Request.CreateResponse(HttpStatusCode.NotModified, false);
        }

        // DELETE api/<controller>/5
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                Education TobeDeleted = dbContext.Educations.Find(id);
                if(TobeDeleted != null)
                {
                    dbContext.Educations.Remove(TobeDeleted);
                    return Request.CreateResponse(HttpStatusCode.OK, true);
                }
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.Conflict, false);
            }
            return Request.CreateResponse(HttpStatusCode.NotModified, false);
        }
    }
}