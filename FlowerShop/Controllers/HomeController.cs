using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FlowerShop.Models;
using FlowerShop.Models.CombineModel;
using FlowerShop.Models.ViewModel;



namespace FlowerShop.Controllers
{
    public class HomeController : Controller
    {
            

        


        public ActionResult Index()
        {
            return View();
        }

        

        public ActionResult WeddingBouquets()// display data of bouquets(only name & image)
        {
            using (var db = new FlowerContext())
            {
                var bouquets= db.Bouquets.ToList();
                return View(bouquets);
            }       
        }

        public ActionResult BouquetDetails(BouquetView bouquetview) // display data of bouquets
        {
            return View(bouquetview);
        }

        [HttpGet]
        public ActionResult SingleFlower()
        {
            using(var dbContext = new FlowerContext())
            {
                
                var flowers  = dbContext.Flowers.ToList();
                return View(flowers);
            }

        }

        [HttpGet]
        public ActionResult AddFlower(AddFlowerToCart addflowertocart)
        {
            var sessionList = Session["cart"] as List<AddFlowerToCart>;
            if (sessionList != null && sessionList.Any())
            {
                sessionList.Add(addflowertocart);
                Session["cart"] = sessionList;
            }
            else
            {
                Session["cart"] = new List<AddFlowerToCart> { addflowertocart };
                
            }
            
            return RedirectToAction("SingleFlower", addflowertocart);

        }

        public ActionResult ShoppingCart()
        {
            var orderedflower = Session["cart"] as List<AddFlowerToCart>;
            return View("AddFlower", orderedflower);

        }

        public ActionResult Delete(AddFlowerToCart addflowertocart)
        {
            var sessionList = Session["cart"] as List<AddFlowerToCart>;
            if (sessionList == null)
            {
                return View("AddFlower");

            }
            else
            {

                sessionList.Remove(sessionList.FirstOrDefault(x => x.Name.Equals(addflowertocart.Name, StringComparison.InvariantCultureIgnoreCase)));
                Session["cart"] = sessionList;
                return View("AddFlower", sessionList);
            }

            
        }

        public ActionResult FlowerDetails(FlowerView flowerview)
        {
            return View(flowerview);


        }
    }
}