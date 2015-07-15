using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Proyect1.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Proyect1.Controllers
{
    public class Products_TransController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Products_Trans
        public ActionResult Index()
        {
            //db.Products.ToList()
            var products = (from p in db.Products where p.Status.Equals("Activo") orderby p.Id select p).ToList();
            return View(products);
        }
        
        // GET: Products_Trans/Details/5
        public ActionResult Details(int? id)
        {
            
           // Products products = db.Products.Find(id);
            Products products = db.Products.Include(s => s.Files).SingleOrDefault(s => s.Id == id);
            
            return View(products);
        }
        public ActionResult Details2(int? id)
        {

            // Products products = db.Products.Find(id);
            Products products = db.Products.Include(s => s.Files).SingleOrDefault(s => s.Id == id);

            return View(products);
        }
        public ActionResult Details3(int? id)
        {

            // Products products = db.Products.Find(id);
            Products products = db.Products.Include(s => s.Files).SingleOrDefault(s => s.Id == id);

            return View(products);
        }
        public ActionResult ComeBack(int? id) {

            return RedirectToAction("StartTransaction", "Transactions", new { id });
        }
        public ActionResult ComeBacks(int? id)
        {

            return RedirectToAction("In", "Transactions");
        }
        public ActionResult ComeBacks1(int? id)
        {

            return RedirectToAction("Out", "Transactions");
        }
        // GET: Products_Trans/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Products_Trans/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,IdUser,ProductName,Description,Status,RegisterDate")] Products products)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(products);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(products);
        }
       
        // GET: Products_Trans/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Products products = db.Products.Find(id);
            products.Status = "Entransaccion";
            db.SaveChanges();
            if (products == null)
            {
                return HttpNotFound();
            }
            return RedirectToAction("Index","Transaction");
        }

        // POST: Products_Trans/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,IdUser,ProductName,Description,Status,RegisterDate")] Products products)
        {
            if (ModelState.IsValid)
            {
               
                db.Entry(products).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(products);
        }

        // GET: Products_Trans/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Products products = db.Products.Find(id);
            if (products == null)
            {
                return HttpNotFound();
            }
            return View(products);
        }

        // POST: Products_Trans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Products products = db.Products.Find(id);
            db.Products.Remove(products);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
