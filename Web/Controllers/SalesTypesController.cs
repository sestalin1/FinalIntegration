using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WS.Models;
using Web.Models;
using WS;

namespace Web.Controllers
{
    public class SalesTypesController : Controller
    {
        private WebContext db = new WebContext();

        // GET: SalesTypes
        public ActionResult Index()
        {
            return View(db.SalesTypes.ToList());
        }

        // GET: SalesTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalesType salesType = db.SalesTypes.Find(id);
            if (salesType == null)
            {
                return HttpNotFound();
            }
            return View(salesType);
        }

        // GET: SalesTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SalesTypes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,sales_type,tax_included,factor,inactive")] SalesType salesType)
        {
            if (ModelState.IsValid)
            {
                //db.SalesTypes.Add(salesType);
                //db.SaveChanges();
                WebServiceFA ws = new WebServiceFA();
                ws.InsertSalesType(salesType);
                return RedirectToAction("Create");
            }

            return View(salesType);
        }

        // GET: SalesTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalesType salesType = db.SalesTypes.Find(id);
            if (salesType == null)
            {
                return HttpNotFound();
            }
            return View(salesType);
        }

        // POST: SalesTypes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,sales_type,tax_included,factor,inactive")] SalesType salesType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(salesType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(salesType);
        }

        // GET: SalesTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalesType salesType = db.SalesTypes.Find(id);
            if (salesType == null)
            {
                return HttpNotFound();
            }
            return View(salesType);
        }

        // POST: SalesTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SalesType salesType = db.SalesTypes.Find(id);
            db.SalesTypes.Remove(salesType);
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
