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
            return View();
        }

        #region Employee Partial

        public ActionResult _partialEmployeeList()
        {
            var employees = GetEmployee();
            return PartialView(employees); 
        }

        [HttpGet]
        public ActionResult CreateEmployee()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateEmployee(Employee model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    model.DateOfBirth = Convert.ToDateTime(model.DateOfBirth.ToShortDateString());
                    model.StartDate = DateTime.Now;

                    MvcDbHelper.Repository.Insert(QueryWarehouse.Employee.Insert, model);
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    // Hata işlemleri, örneğin kullanıcıya hata mesajı gösterme
                    ModelState.AddModelError(string.Empty, "Kayıt işlemi sırasında bir hata oluştu.");
                }
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult DeleteEmployee(int id)
        {
            try
            {
                var employee = new Employee { Id = id };
                MvcDbHelper.Repository.Delete<Employee>(QueryWarehouse.Employee.Delete, employee);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                // Hata işlemleri, örneğin kullanıcıya hata mesajı gösterme
                ModelState.AddModelError(string.Empty, "Silme işlemi sırasında bir hata oluştu.");
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public ActionResult DetailsEmployee(int id)
        {
            var employee = MvcDbHelper.Repository.GetById<Employee>(QueryWarehouse.Employee.GetByID, new { Id = id }).FirstOrDefault();
            return View(employee);
        }

        [HttpGet]
        public ActionResult UpdateEmployee(int id)
        {
            var employee = MvcDbHelper.Repository.GetById<Employee>(QueryWarehouse.Employee.GetByID, new { Id = id }).FirstOrDefault();
            return View(employee);
        }

        [HttpPost]
        public ActionResult UpdateEmployee(int Id,Employee model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    MvcDbHelper.Repository.Update(QueryWarehouse.Employee.Update, model);
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    // Hata işlemleri, örneğin kullanıcıya hata mesajı gösterme
                    ModelState.AddModelError(string.Empty, "Güncelleme işlemi sırasında bir hata oluştu.");
                }
            }
            return View(model);
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
