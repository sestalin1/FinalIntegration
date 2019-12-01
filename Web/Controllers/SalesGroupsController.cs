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
    public class SalesGroupsController : Controller
    {
        private WebContext db = new WebContext();

        // GET: SalesGroups
        public ActionResult Index()
        {
            WebServiceFA ws = new WebServiceFA();
            
            var rs = ws.SalesGroups();
            
            return View(rs);
        }

        // GET: SalesGroups/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalesGroups salesGroups = db.SalesGroups.Find(id);
            if (salesGroups == null)
            {
                return HttpNotFound();
            }
            return View(salesGroups);
        }

        // GET: SalesGroups/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SalesGroups/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,description,inactive")] SalesGroups salesGroups)
        {
            if (ModelState.IsValid)
            {
                db.SalesGroups.Add(salesGroups);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(salesGroups);
        }

        // GET: SalesGroups/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalesGroups salesGroups = db.SalesGroups.Find(id);
            if (salesGroups == null)
            {
                return HttpNotFound();
            }
            return View(salesGroups);
        }

        // POST: SalesGroups/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,description,inactive")] SalesGroups salesGroups)
        {
            if (ModelState.IsValid)
            {
                db.Entry(salesGroups).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(salesGroups);
        }

        // GET: SalesGroups/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalesGroups salesGroups = db.SalesGroups.Find(id);
            if (salesGroups == null)
            {
                return HttpNotFound();
            }
            return View(salesGroups);
        }

        // POST: SalesGroups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SalesGroups salesGroups = db.SalesGroups.Find(id);
            db.SalesGroups.Remove(salesGroups);
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
