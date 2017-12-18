using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Cors;
using System.Web.Mvc;

namespace WebApp.Controllers
{
    //[EnableCors("*", "*", "*")]
    public class EmployeeManagementController : Controller
    {
        // GET: EmployeeManagement
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ShowEmployees()
        {
            return PartialView("ShowAllEmployees");
        }
        public ActionResult ShowingEmployee()
        {
            return PartialView("ShowEmployee");
        }

        public ActionResult ShowStates()
        {
            return PartialView("ShowAllStates");
        }

        public ActionResult DEmployee()
        {
            return PartialView("DeleteEmployee");
        }
        
        public ActionResult EEmployee()
        {
            return PartialView("EditEmployee");
        }
    }
}