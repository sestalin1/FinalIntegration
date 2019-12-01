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
    public class DimensionTagsController : Controller
    {
        private WebContext db = new WebContext();

        // GET: DimensionTags
        public ActionResult Index()
        {
            return View(db.DimensionTags.ToList());
        }

        // GET: DimensionTags/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DimensionTag dimensionTag = db.DimensionTags.Find(id);
            if (dimensionTag == null)
            {
                return HttpNotFound();
            }
            return View(dimensionTag);
        }

        // GET: DimensionTags/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DimensionTags/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,type,name,description,inactive")] DimensionTag dimensionTag)
        {
            if (ModelState.IsValid)
            {
                //db.DimensionTags.Add(dimensionTag);
                //db.SaveChanges();
                WebServiceFA ws = new WebServiceFA();
                ws.InsertDimensionTag(dimensionTag);
                return RedirectToAction("Create");
            }

            return View(dimensionTag);
        }

        // GET: DimensionTags/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DimensionTag dimensionTag = db.DimensionTags.Find(id);
            if (dimensionTag == null)
            {
                return HttpNotFound();
            }
            return View(dimensionTag);
        }

        // POST: DimensionTags/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,type,name,description,inactive")] DimensionTag dimensionTag)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dimensionTag).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dimensionTag);
        }

        // GET: DimensionTags/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DimensionTag dimensionTag = db.DimensionTags.Find(id);
            if (dimensionTag == null)
            {
                return HttpNotFound();
            }
            return View(dimensionTag);
        }

        // POST: DimensionTags/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DimensionTag dimensionTag = db.DimensionTags.Find(id);
            db.DimensionTags.Remove(dimensionTag);
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
