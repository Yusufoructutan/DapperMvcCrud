using DapperMVC.Models;
using EntityLayer;
using EntityLayer.SqlQuery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DapperMVC.Controllers
{
    public class HomeController : Controller
    {
      


        // GET: Home
        public ActionResult Index()
        {
            return RedirectToAction("CreateEmployee");
           // return View();
        }


        #region Employee Partial


        public ActionResult _partialEmployeeList()
        {

            return View(GetEmployee());
        }

        [HttpGet]
        public ActionResult CreateEmployee() { 
        
                
            return View(); 
            
        }
        [HttpPost]
        public ActionResult CreateEmployee(Employee model)
        {
            model.DateOfBirth = Convert.ToDateTime(model.DateOfBirth.ToShortDateString());
            model.StartDate=DateTime.Now;

            MvcDbHelper.Repository.Insert(QueryWarehouse.Employee.Insert, model);
            return View();

        }



        #endregion


        #region Employee Crud

        public List<Employee> GetEmployee()
        {

            var employeeResult = MvcDbHelper.Repository.GetAll<Employee>(QueryWarehouse.Employee.GetAll).ToList();
            return employeeResult;


        } 
        #endregion


    }
}