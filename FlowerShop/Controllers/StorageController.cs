using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FlowerShop.Models;
using System.Data;
using System.Data.Entity;
using System.IO;
using FlowerShop.Models.CombineModel;
using FlowerShop.Models.ViewModel;

namespace FlowerShop.Controllers
{
    public class StorageController : Controller
    {
        // GET: Storage


        [HttpGet]
        public ActionResult StoreFlower()
        {

            return View();
        }

        [HttpPost]
        public ActionResult StoreFlower(Flower flower, HttpPostedFileBase file)
        {
            using (var stream = new MemoryStream())
            {
                file.InputStream.CopyTo(stream);
                flower.Image = stream.ToArray();
            }
            using (var db = new FlowerContext())
            {
                db.Flowers.Add(flower);
                db.SaveChanges();
            }
            return RedirectToAction("SingleFlower", "Home");
        }




        [HttpGet]
        public ActionResult StoreBouquet()
        {

            return View();
        }
        [HttpPost]
        public ActionResult StoreBouquet(Bouquet bouquet, HttpPostedFileBase file) /*Save bouquet details and convert image to array*/
        {
            using (var stream = new MemoryStream())
            {
                file.InputStream.CopyTo(stream);
                bouquet.BouquetImage = stream.ToArray();

            }

            using (var db = new FlowerContext())
            {
                db.Bouquets.Add(bouquet);
                db.SaveChanges();
            }

            return RedirectToAction("WeddingBouquets", "Home");

        }


        [HttpGet]
        public ActionResult StoreOrder()
        {
            return View();
        }
           
        [HttpPost]
        public ActionResult StoreBouquetOrder(BouquetView bouquetview) /*Save Customer Bouquet Order*/
        {

            Customer customer = new Customer();
            customer.CustomerName = bouquetview.CustomerName;
            customer.Telephone = bouquetview.Telephone;
            customer.Address = bouquetview.Address;
            customer.Email = bouquetview.Email;
            customer.DeliveryDate = bouquetview.DeliveryDate;

            OrderBouquet orderbouquet = new OrderBouquet();
            orderbouquet.FlowerForBouquet = bouquetview.FlowerForBouquet;


            using (var db = new FlowerContext())
            {
                var bouquet = db.Bouquets.FirstOrDefault(b => b.BouquetName.Equals(bouquetview.BouquetName, StringComparison.InvariantCultureIgnoreCase));
                orderbouquet.BouquetId = bouquet.Id;
                orderbouquet.CustomerId = customer.Id;
                db.Customers.Add(customer);
                db.OrderBouquets.Add(orderbouquet);
                db.SaveChanges();
            }



            return RedirectToAction("CustomerList", "Storage");
        }

        
        //[HttpPost]
        //public ActionResult StoreFlowerOrder(FlowerView flowerview)
        //{

        //    Customer customer = new Customer();
        //    customer.CustomerName = flowerview.CustomerName;
        //    customer.Telephone = flowerview.Telephone;
        //    customer.Address = flowerview.Address;
        //    customer.Email = flowerview.Email;
        //    customer.DeliveryDate = flowerview.DeliveryDate;

        //    OrderFlower orderflower = new OrderFlower();

        //    using (var db = new FlowerContext())
        //    {
        //        var flower = db.Flowers.FirstOrDefault(m => m.Name.Equals(flowerview.Name, StringComparison.InvariantCultureIgnoreCase));
        //        orderflower.CustomerId = customer.Id;
        //        orderflower.FlowerId = flower.Id;
        //        db.Customers.Add(customer);
        //        db.OrderFlowers.Add(orderflower);
        //        db.SaveChanges();

        //    }

        //    return null;
        //}


        public ActionResult CustomerList() /* customer list table in admin page*/
        {

            using (var db = new FlowerContext())
            {
                var customer = db.Customers.ToList().OrderBy(c => c.DeliveryDate);
                return View(customer);

            }

        }

        [HttpGet]
        public ActionResult CustomerOrderDetails(string Name) /* customer list table in admin page*/
        {
            var customerorderview = new CustomerView();

            using (var db = new FlowerContext())
            {

                var customerorderdetails =  db.Customers.Where(m => m.CustomerName.Equals(Name, StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault();
                var customerorderbouquets = db.OrderBouquets.Include(x => x.Bouquet).Where(m => m.CustomerId.Equals(customerorderdetails.Id)).ToList();
                var customerorderflowers = db.OrderFlowers.Where(m => m.CustomerId.Equals(customerorderdetails.Id)).ToList();
                customerorderview.CustomerName = customerorderdetails.CustomerName;
                customerorderview.Address = customerorderdetails.Address;
                customerorderview.Email = customerorderdetails.Email;
                customerorderview.Telephone = customerorderdetails.Telephone;

                customerorderview.OrderBouquet = customerorderbouquets.ToList();
                customerorderview.OrderFlower = customerorderflowers.ToList();

            }
            return View(customerorderview);



        }

    }


}