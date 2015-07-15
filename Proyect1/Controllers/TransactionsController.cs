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
    public class TransactionsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Transactions
        public ActionResult Index(string search)
        {
            var products = (from p in db.Products where p.Status.Equals("Activo") orderby p.Id select p).ToList();
            if (!String.IsNullOrEmpty(search))
            {
                products = (from p in db.Products where p.Status.Equals("Activo") && p.ProductName.Contains(search) select p).ToList();
            } 
            return View(products);
        }
        public ActionResult StartTransaction(int id) {
            if (User.Identity.IsAuthenticated)
            {
                var idu = User.Identity.GetUserId();
                List<Products> fundList = (from p in db.Products where p.IdUser.Equals(idu) && p.Status.Equals("Activo") select p).ToList();
                ViewBag.Products = fundList;
               Products product =  db.Products.Find(id);
                ViewBag.Product = product;
                return View();
            }

            return RedirectToAction("Login","Account");
        }

        public ActionResult Out(){


            var id = User.Identity.GetUserId();

            var transacciones = (from t in db.Transactions from p in db.Products where t.Status.Equals("Pendiente") && t.ProductOfInterest.Equals(p.Id) && p.IdUser.Equals(id) select t).ToList();
           

            //var transaccion = (from t in db.Transactions where t.Status.Equals("Pediente") select t).ToList();

            //List<Transactions> transacciones = new List<Transactions>();
            //foreach (var item in transaccion)
            //{
            //    Products products = new Products();
            //    products = (Products)(from p in db.Products where p.Id == item.FeacturedProduct select p);
            //    if (products.IdUser == id)
            //    {
            //        transacciones.Add(item);
            //    }

            //}
            ViewBag.Transacciones = transacciones;
            return View();
        }
        public ActionResult In() {
            var id = User.Identity.GetUserId();
            //&& t.FeacturedProduct == p.Id && p.IdUser == id

            List<Transactions> transacciones = (from t in db.Transactions from p in db.Products where t.Status.Equals("Pendiente") && t.FeacturedProduct.Equals(p.Id) && p.IdUser.Equals(id) select t).ToList();

            //List<Transactions> transacciones = new List<Transactions>();
            //foreach (var item in transaccion)
            //{
            //    Products products = new Products();
            //    products = (Products)(from p in db.Products where p.Id == item.ProductOfInterest select p);
            //    if (products.IdUser == id)
            //    {
            //        transacciones.Add(item);
            //    }
                
            //}
            ViewBag.Transacciones = transacciones;
            return View();
        }
        public ActionResult Complete(int Id)
        {
            string cambio = "Cambiado";
            Transactions transaction = db.Transactions.Find(Id);
            Products product1 = db.Products.Find(transaction.FeacturedProduct);
            Products product2 = db.Products.Find(transaction.ProductOfInterest);
            var idUser1 = product1.IdUser;
            var idUser2 = product2.IdUser;
            product1.Status = cambio;
            product1.IdUser = idUser2;
           
            product2.Status = cambio;
            product2.IdUser = idUser1;
            transaction.Status = "Completado";
            db.SaveChanges();
            return RedirectToAction("In");

        }
        public ActionResult Cancel(int id) {
            string cambio = "Activo";
            Transactions transaction = db.Transactions.Find(id);
            Products product1 = db.Products.Find(transaction.FeacturedProduct);
            Products product2 = db.Products.Find(transaction.ProductOfInterest);
            
            product1.Status = cambio;
          

            product2.Status = cambio;
            transaction.Status = "Cancelado";
            db.SaveChanges();
           
            return RedirectToAction("Out");
        }
        // GET: Transactions/Details/5
        public ActionResult Details(int? id)
        {

            return RedirectToAction("Details", "Products_Trans", new { id});
        }
        public ActionResult Details2(int? id) {

            return RedirectToAction("Details2", "Products_Trans", new { id });
        
        }
        public ActionResult Details3(int? id)
        {

            return RedirectToAction("Details3", "Products_Trans", new { id });

        }

        // GET: Transactions/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        // POST: Transactions/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
      
        public ActionResult Create(int Id,int Id2)
        {
            
            Transactions transaction = new Transactions();
            transaction.FeacturedProduct = Id;
            transaction.ProductOfInterest = Id2;
            transaction.Status = "Pendiente";
            transaction.Date = @DateTime.Now;
            Products product1 = db.Products.Find(Id);
            product1.Status = "Entransacion";
            Products product2 = db.Products.Find(Id2);
            product2.Status = "Entransacion";
            db.Transactions.Add(transaction);
            db.SaveChanges();
            return RedirectToAction("Index");
           
        }

        // GET: Transactions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transactions transactions = db.Transactions.Find(id);
            transactions.Status = "Pendiente";
            db.SaveChanges();
            if (transactions == null)
            {
                return HttpNotFound();
            }
            return RedirectToAction("Index","Products_Trans");
        }

        // POST: Transactions/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FeacturedProduct,ProductOfInterest,Date,Status")] Transactions transactions)
        {
            if (ModelState.IsValid)
            {
                db.Entry(transactions).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(transactions);
        }

        // GET: Transactions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transactions transactions = db.Transactions.Find(id);
            if (transactions == null)
            {
                return HttpNotFound();
            }
            return View(transactions);
        }

        // POST: Transactions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Transactions transactions = db.Transactions.Find(id);
            db.Transactions.Remove(transactions);
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
