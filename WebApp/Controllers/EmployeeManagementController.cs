using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Controllers
{
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
        public ActionResult ShowStates()
        {
            return PartialView("ShowAllStates");
        }


    }
}