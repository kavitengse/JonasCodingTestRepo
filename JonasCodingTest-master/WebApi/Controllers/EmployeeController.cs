using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Mvc;
using BusinessLayer.Model.Models;

namespace WebApi.Controllers
{
    public class EmployeeController : Controller
    {
       
        public EmployeeController()
        {
           
        }
        [System.Web.Http.HttpPost]
        public ActionResult EmployeeView()
        {
            EmployeeData employee = new EmployeeData
            {
                EmployeeCode = "E101",
                EmployeeName = "Kavita",
                EmailAddress = "Toronto",
                CompanyName = "AbCCompany"

            };

            ViewData["Message"] = employee;
            return View(employee);
        }
    }
}