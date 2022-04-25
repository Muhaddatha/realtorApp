using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCRealtorApp.Models;

namespace MVCRealtorApp.Controllers
{
    public class HouseController : Controller
    {

        bool isRealtorLoggedIn = false;
        // GET: House
        public ActionResult Index()
        {
            using(DbModels dbModels = new DbModels())
            {
                return View(dbModels.Houses.ToList());
            }
   
        }

        // GET: House/Details/5
        public ActionResult Details(int id)
        {
            using(DbModels dbModels = new DbModels())
            {
                return View(dbModels.Houses.Where(x => x.Id == id).FirstOrDefault());
            }

        }

        public ActionResult DetailsCustomer(int id)
        {
            using (DbModels dbModels = new DbModels())
            {
                return View(dbModels.Houses.Where(x => x.Id == id).FirstOrDefault());
            }
        }

        // GET: House/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: House/Create
        [HttpPost]
        public ActionResult Create(House house)
        {
            try
            {
                // TODO: Add insert logic here
                using(DbModels dbModels = new DbModels())
                {
                    dbModels.Houses.Add(house);
                    dbModels.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: House/Edit/5
        public ActionResult Edit(int id)
        {
            using (DbModels dbModels = new DbModels())
            {
                return View(dbModels.Houses.Where(x => x.Id == id).FirstOrDefault());
            }
        }

        // POST: House/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, House house)
        {
            try
            {
                // TODO: Add update logic here
                using(DbModels dbModels = new DbModels())
                {
                    dbModels.Entry(house).State = EntityState.Modified;
                    dbModels.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: House/Delete/5
        public ActionResult Delete(int id)
        {
            using (DbModels dbModels = new DbModels())
            {
                return View(dbModels.Houses.Where(x => x.Id == id).FirstOrDefault());
            }
        }

        // POST: House/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                using(DbModels dbModels = new DbModels())
                {
                    House house = dbModels.Houses.Where(x => x.Id == id).FirstOrDefault();
                    dbModels.Houses.Remove(house);
                    dbModels.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        public ActionResult IndexCustomer()
        {
            using (DbModels dbModels = new DbModels())
            {
                return View(dbModels.Houses.ToList());
            }
        }


        public ActionResult ContactRealtor(int id)
        {
            using (DbModels dbModels = new DbModels())
            {
                return View(dbModels.Houses.Where(x => x.Id == id).FirstOrDefault());
            }
        }


        public ActionResult Login(string username, string password)
        {
            return View();

            if (username == "realtor" && password == "pa$$w0rd")
            {
                isRealtorLoggedIn = true;
                return RedirectToAction("Index");
            }
            else
            {
                isRealtorLoggedIn = false;
                return RedirectToAction("IndexCustomer");
            }

           
        }


        public ActionResult Search()
        {
            float price = 200000;
            try
            {
                // TODO: Add delete logic here
                using (DbModels dbModels = new DbModels())
                {
                    List<House> houseList = dbModels.Houses.Where(x => x.Price <= price).ToList();
                    return View(houseList);
                }
            }
            catch
            {
                return RedirectToAction("IndexCustomer");
            }
        }
    }
}
