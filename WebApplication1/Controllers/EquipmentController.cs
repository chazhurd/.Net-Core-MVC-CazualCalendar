using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using static DataLibrary.BusinessLogic.RentProcessor;


namespace WebApplication1.Controllers
{
    public class EquipmentController:Controller
    {
        public ActionResult Rent()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Rent(Renter model)
        {
            if (ModelState.IsValid)
            {
                int recordsCreated = CreateRent(model.FirstName, model.LastName, model.Email, model.Item);
                   return RedirectToAction("Index", "Home", new { status = "RentRequested" });
            }
            return View();
        }
    }
}