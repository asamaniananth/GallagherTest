using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Elmah;
using MVCTest.Data.BusinessLogic;
using MVCTest.Data.DAL;
using MVCTest.Data.ViewModels;

namespace MVCTest.Controllers
{
    public class HomeController : Controller
    {
        AssessmentCodeBehindBusinessLogic ctxAdmin = new AssessmentCodeBehindBusinessLogic();

        public ActionResult Index()
        {
            IRepository csvRepository = new CsvRepository(); 
            IRepository dbRepository = new SqlRepository();

            var model = new HomePageViewModel();
            model.FromCSV = csvRepository.GetAllAsViewModels(Server.MapPath("~/App_Data/employees.csv"));
            model.FromDB = dbRepository.GetAllAsViewModels(null);

            return View(model);
        }

        public ActionResult GetEmployeeDetailsById(long id)
        {

            var result = ctxAdmin.GetEmployeeById(id);
            return View(result);
        }

        public ActionResult CreateEmployee()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddEmployee(EmployeeViewModel employee)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    ctxAdmin.AddItem(employee);
                }
                catch (Exception ex)
                {
                    ErrorSignal.FromCurrentContext().Raise(ex);
                }
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult UpdateEmployee(EmployeeViewModel employee)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    ctxAdmin.UpdateItem(employee);
                }
                catch (Exception ex)
                {
                    ErrorSignal.FromCurrentContext().Raise(ex);
                }
            }
            return RedirectToAction("Index", "Home");
        }

        public ActionResult EditEmployeeById(long id)
        {
            var result = ctxAdmin.GetEmployeeById(id);
            return View(result);
        }

        public ActionResult DeleteEmployeeById(int id)
        {
            if (id >= 0)
            {
                ctxAdmin.DeleteItemById(id);
            }
            return RedirectToAction("Index", "Home");
        }

    }
}
