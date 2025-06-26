using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
//using MVC_4._6_for_learning.Models; // Make sure this is correct based on your project structure

namespace MVC_4._6_for_learning.Controllers
{
    public class EMPController : Controller
    {
        // GET: EMP
        public ActionResult Index()
        {
            using (LibraryDBEntities db = new LibraryDBEntities())
            {
                List<Employee> empList = db.Employees.ToList();
                return View(empList);
            }
        }

        [HttpPost]
        public JsonResult Insertemp(Employee emp)
        {
            if (emp != null)
            {
                using (LibraryDBEntities db = new LibraryDBEntities())
                {
                    db.Employees.Add(emp);
                    db.SaveChanges();
                }
            }

            return Json(emp, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult EmpUpdate(Employee emp)
        {


            using (LibraryDBEntities db = new LibraryDBEntities())
            {

                Employee empUpdate = (from x in db.Employees where x.Id == emp.Id select x).FirstOrDefault();
                empUpdate.Empname = emp.Empname;
                empUpdate.Email = emp.Email;
                empUpdate.Salary = emp.Salary;
                empUpdate.Age = emp.Age;

                db.SaveChanges();

                return new EmptyResult();
            }
        }
    }
}
