using ContactDetail.DataAccesslayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactDetail.Controllers
{
    public class ContactDetailController : Controller
    {
        private readonly IContactFormRepository _contactForm;
        private readonly String _Configure;
        // GET: ContactDetailController
        public ContactDetailController(IContactFormRepository contactForm, IConfiguration configure)
        {
            _contactForm = contactForm;
            _Configure = configure.GetConnectionString("DbConnection");
        }
        public ActionResult Index()
        {
            try
            {
                var list =_contactForm.GetAllContact();
                return View("List", list);
            }
            catch (Exception ex)
            {
                return View("Errror");
            }

           
        }

        // GET: ContactDetailController/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                var all = _contactForm.GetByNumber(id);
                return View("Details", all);
            }
            catch (Exception ex)
            {
                return View();
            }
            
        }

        // GET: ContactDetailController/Create
        public ActionResult Create()
        {
            var get = new ContactForm();
            return View("Create", get);
        }

        // POST: ContactDetailController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ContactForm contact)
        {
            try
            {
                _contactForm.ContactInsert(contact);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }

        // GET: ContactDetailController/Edit/5
        public ActionResult Edit(int id)
        {
            var res = _contactForm.GetByNumber(id);
            return View("Edit", res);
        }

        // POST: ContactDetailController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ContactForm contact)
        {
            try
            {
                _contactForm.ContactUpdate(id, contact);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View("Error");
            }
        }

        // GET: ContactDetailController/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                var delete = _contactForm.GetByNumber(id);
                return View("Delete", delete);
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }

        // POST: ContactDetailController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteRec(int EmployeeID)
        {
            try
            {
                _contactForm.ContactDelete(EmployeeID);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View("Errror");
            }
        }
    }
}
