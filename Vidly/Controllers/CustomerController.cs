using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            var customers = GetCustmores();
            
            return View(customers);
        }

        private IEnumerable<Custmore> GetCustmores()
        {
            var customerList = new List<Custmore>
            {
                new Custmore{ Id = 1, Name= "Jhon Smith" },
                new Custmore{ Id = 2, Name = "Marry Williams"}
            };
            return customerList;
        }

        public ActionResult Details(int id)
        {
            var customer = GetCustmores().Where(c => c.Id == id).SingleOrDefault();
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }


    }
}