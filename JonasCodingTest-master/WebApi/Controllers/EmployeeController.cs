using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Mvc;
using BusinessLayer.Model.Models;
using Microsoft.Practices.EnterpriseLibrary.Logging;

namespace WebApi.Controllers
{
    public class EmployeeController : Controller
    {
       
       
        public ActionResult Employee()
        {
            WriteLog("---Started Employee Method----");
            try
            {
                EmployeeData employee = new EmployeeData
                {
                    EmployeeCode = "E101",
                    EmployeeName = "Kavita",
                    CompanyName = "AbCCompany",
                    OccupationName = "Sr Developer",
                    EmployeeStatus = "Active",
                    EmailAddress = "kavitatengse@gmail.com"

                };
                ViewBag.Message = employee;
            }
            catch (Exception ex)
            {
                WriteLog("---Exception Occured Employee Method ----" + ex.Message);
            }
           
           
            return View();
        }

        public void WriteLog(string logMessage)
        {
            LogEntry logEntry = new LogEntry();
            logEntry.EventId = 100;
            logEntry.Priority = 2;
            logEntry.Message = logMessage;
            Logger.Write(logEntry);
        }
    }
}