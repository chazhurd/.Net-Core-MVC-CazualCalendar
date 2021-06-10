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
                    item.ImgUrl, 
                    item.Price);
                ItemAdded();
            }
            return View();
        }
        [HttpGet]
        public ActionResult Edit(string Id)
        {
            ViewData["edited"] = false;
            var data = LoadSpecificItem(Id);
            List<ItemModel> items = new List<ItemModel>();
            foreach (var row in data)
            {
                items.Add(new ItemModel
                {
                    ItemName = row.ItemName,
                    Quantity = row.Quantity,
                    ImgUrl = row.ImgUrl,
                    ItemId = row.ItemId,
                    Price = row.Price
                });

            }

            return View(items[0]);
        }
        [HttpPost]
        public ActionResult Edit(ItemModel item)
        {
            ViewData["edited"] = true;

            if (ModelState.IsValid)
            {
                try
                {
                    int recordsCreated = UpdateSpecificItem(item.ItemId,
                        item.ItemName,
                        item.Quantity,
                        item.ImgUrl,
                        item.Price);
                    return View();
                }
                catch
                {
                    return View("Error");

                }
            }
            return View("Error");


        }
        public ActionResult Details(string id)
        {
            ViewBag.Title = "Details";
            ViewData["Admin"] = true;
            var data = LoadSpecificItem(id);

            List<ItemModel> items = new List<ItemModel>();
            foreach (var row in data)
            {
                items.Add(new ItemModel
                {
                    ItemId = row.ItemId,
                    ItemName = row.ItemName,
                    Quantity = row.Quantity,
                    ImgUrl = row.ImgUrl,
                    Price = row.Price
                });


            }
            return View(items);

        }
        public ActionResult ViewItems()
        {
            ViewData["Admin"] = true;
            var data = LoadItems();
            List<ItemModel> items = new List<ItemModel>();
            foreach (var row in data)
            {
                items.Add(new ItemModel
                {
                    ItemName = row.ItemName,
                    Quantity = row.Quantity,
                    ImgUrl = row.ImgUrl,
                    ItemId = row.ItemId,
                    Price = row.Price
                });


            }
            return View(items);

        }

        public ActionResult ViewSpecific(string ttry)
        {

            var spec = ttry;
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

        public ActionResult checkUp()
        {

            var spec = Request.QueryString["specifity"].ToString();
            var data = LoadSpecificItem(spec);

            List<ItemModel> items = new List<ItemModel>();
            foreach (var row in data)
            {
                items.Add(new ItemModel
                {
                    ItemId = row.ItemId,
                    ItemName = row.ItemName,
                    Quantity = row.Quantity,
                    ImgUrl = row.ImgUrl
                });


            }
            return View(items);
        }

        public void AddToCart(string id)
        {


            //adding data to session
            //assuming the method below will return list of Products

            var products = LoadSpecificItem(id);

            //Store the products to a session

            Session["products"] = products;


            var inputted = Session["products"] as List<ItemModel>;
            Console.Write(inputted);

            //To get what you have stored to a session

            //var products = Session["products"] as List<ItemModel>;

            //to clear the session value

            //Session["products"] = null;
            //return View();

        
        }

        public ActionResult CheckOut()
        {
            return View();
        }

    }
}