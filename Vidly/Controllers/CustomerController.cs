using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using System.Data.Entity;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomerController : Controller
    {
        private ApplicationDbContext _context;

        public CustomerController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Customer
        public ActionResult Index()
        {
            var customers = _context.Custmores.Include(c => c.MembershipType).ToList();

            return View(customers);
        }

        public ActionResult Details(int id)
        {
            var customer = _context.Custmores.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);

            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        public ActionResult CustomerForm()
        {
            var membershipType = _context.MembershipTypes.ToList();

            var newCustomer = new CustomerFormViewModel
            {
                MembershipTypes = membershipType
            };

           
            return View(newCustomer);
        }

        [HttpPost]
        public ActionResult Save(Custmore custmore)
        {
            if (custmore.Id == 0)
                _context.Custmores.Add(custmore);
            else
            {
                var customerInDb = _context.Custmores.Single(c => c.Id == custmore.Id);
                customerInDb.Name = custmore.Name;
                customerInDb.Birthdate = custmore.Birthdate;
                customerInDb.IsSubscribedToNewsLetter = custmore.IsSubscribedToNewsLetter;
                customerInDb.MembershipTypeId = custmore.MembershipTypeId;
            }
            
            
            _context.SaveChanges();

            return RedirectToAction("Index", "Customer");
        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Custmores.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            var viewModel = new CustomerFormViewModel
            {
                Custmore = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };

            return View("CustomerForm", viewModel);
        }
    }
}