using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using HomeWork_22.Models;
using Microsoft.AspNetCore.Authorization;

namespace HomeWork_22.Controllers
{
    public class PhoneBookController : Controller
    {
        private IPhoneBookRepository repository;

        public PhoneBookController(IPhoneBookRepository repo)
        {
            repository = repo;
        }

        //[Authorize]
        public IActionResult Index()
        {
            return View(repository.PhoneBooks);
        }
        [HttpPost]
        public RedirectToActionResult DeleteRecord(int id)
        {
            repository.DeleteRecord(id);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public RedirectToActionResult AddRecord(string LastName, string FirstName, string ThreeName, string NumberPhone,
            string Address, string Description)
        {
            PhoneBook phoneBook = new PhoneBook();
            phoneBook.FirstName = FirstName;
            phoneBook.LastName = LastName;
            phoneBook.ThreeName = ThreeName;
            phoneBook.NumberPhone = NumberPhone;
            phoneBook.Address = Address;
            phoneBook.Description = Description;
            repository.SaveRecord(phoneBook);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public RedirectToActionResult EditRecord(int id, string LastName, string FirstName, string ThreeName, string NumberPhone,
            string Address, string Description)
        {
            PhoneBook phoneBook = new PhoneBook();
            phoneBook.PhoneBookID = id;
            phoneBook.FirstName = FirstName;
            phoneBook.LastName = LastName;
            phoneBook.ThreeName = ThreeName;
            phoneBook.NumberPhone = NumberPhone;
            phoneBook.Address = Address;
            phoneBook.Description = Description;
            repository.SaveRecord(phoneBook);
            return RedirectToAction("Index");
        }
    }
}
