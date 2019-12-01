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
    public class SalesAreasController : Controller
    {
        private WebContext db = new WebContext();

        // GET: SalesAreas
        public ActionResult Index()
        {
            WebServiceFA ws = new WebServiceFA();
            var rs = ws.SalesAreas();
            return View(rs);
        }

        // GET: SalesAreas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalesAreas salesAreas = db.SalesAreas.Find(id);
            if (salesAreas == null)
            {
                return HttpNotFound();
            }
            return View(salesAreas);
        }

        // GET: SalesAreas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SalesAreas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "area_code,description,inactive")] SalesAreas salesAreas)
        {
            if (ModelState.IsValid)
            {
                db.SalesAreas.Add(salesAreas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(salesAreas);
        }

        // GET: SalesAreas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalesAreas salesAreas = db.SalesAreas.Find(id);
            if (salesAreas == null)
            {
                return HttpNotFound();
            }
            return View(salesAreas);
        }

        // POST: SalesAreas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "area_code,description,inactive")] SalesAreas salesAreas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(salesAreas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(salesAreas);
        }

        // GET: SalesAreas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalesAreas salesAreas = db.SalesAreas.Find(id);
            if (salesAreas == null)
            {
                return HttpNotFound();
            }
            return View(salesAreas);
        }

        // POST: SalesAreas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SalesAreas salesAreas = db.SalesAreas.Find(id);
            db.SalesAreas.Remove(salesAreas);
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
