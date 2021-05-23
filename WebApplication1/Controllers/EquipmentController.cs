using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using static DataLibrary.BusinessLogic.RentProcessor;
using static DataLibrary.BusinessLogic.ItemProcessor;
using DataLibrary.BusinessLogic;

namespace WebApplication1.Controllers
{
    public class EquipmentController : Controller
    {
        public ActionResult Rent()
        {
            ViewData["Requested"] = false;
            return View();
        }
        public ActionResult Rented()
        {
            ViewData["Requested"] = true;
            return View("Rent");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Rent(Renter model)
        {
            if (ModelState.IsValid)
            {
                int recordsCreated = CreateRent(model.FirstName, model.LastName, model.Email, model.Item);
                Rented();
            }
            return View();
        }

        public ActionResult ViewRenters()
        {
            var data = LoadRenters();
            List<Renter> renters = new List<Renter>();
            foreach (var row in data)
            {
                renters.Add(new Renter
                {
                    FirstName = row.FirstName,
                    LastName = row.LastName,
                    Email = row.Email,
                    Item = row.Item
                });


            }
            return View(renters);

        }
        public ActionResult ItemAdded()
        {
            ViewBag.Message = "Add An Item";
            ViewData["Added"] = true;
            return View("AddItem");
        }
        public ActionResult AddItem()
        {
            ViewBag.Message = "Add An Item";
            ViewData["Added"] = false;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddItem(ItemModel item)
        {
            if (ModelState.IsValid)
            {
                int recordsCreated = CreateItem(item.ItemId,
                    item.ItemName,
                    item.Quantity,
                    item.ImgUrl);
                ItemAdded();
            }
            return View();
        }
        public ActionResult ViewItems()
        {
            var data = LoadItems();
            List<ItemModel> items = new List<ItemModel>();
            foreach (var row in data)
            {
                items.Add(new ItemModel
                {
                    ItemName = row.ItemName,
                    Quantity = row.Quantity,
                    ImgUrl = row.ImgUrl,
                    ItemId = row.ItemId
                });


            }
            return View(items);

        }
        [HttpGet]
        public ActionResult ViewSpecific(string specificity)
        {
            var spec = specificity;
            var data = LoadSpecificItem(spec);

            List<ItemModel> items = new List<ItemModel>();
            foreach (var row in data)
            {
                items.Add(new ItemModel
                {
                    ItemName = row.ItemName,
                    Quantity = row.Quantity,
                    ImgUrl = row.ImgUrl,
                    ItemId = row.ItemId
                });


            }
            return View(items);
        }



    }
}