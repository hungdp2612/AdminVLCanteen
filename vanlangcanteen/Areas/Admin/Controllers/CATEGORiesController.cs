using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using vanlangcanteen.Models;
using vanlangcanteen.Areas.Admin.Middleware;
using System.Transactions;

namespace vanlangcanteen.Areas.Admin.Controllers
{
    [LoginVerification]
    public class CATEGORiesController : Controller
    {
        private QUANLYCANTEENEntities db = new QUANLYCANTEENEntities();
        private const string PICTURE_PATH = "~/Upload/Categories/";
        // GET: Admin/CATEGORies
        public ActionResult Index()
        {
            var product = db.CATEGORies.ToList().OrderByDescending(x => x.ID).ToList();
            return View(product);
        }

        // GET: Admin/CATEGORies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CATEGORY cATEGORY = db.CATEGORies.Find(id);
            if (cATEGORY == null)
            {
                return HttpNotFound();
            }
            return View(cATEGORY);
        }

        public ActionResult Picture(int id)
        {
            var path = Server.MapPath(PICTURE_PATH);
            return File(path + id, "images");
        }
        [HttpGet]
        // GET: Admin/CATEGORies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/CATEGORies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,CATEGORY_CODE,CATEGORY_NAME,IMAGE_URL,STATUS")] CATEGORY cATEGORY, HttpPostedFileBase picture)
        {
            var product = new CATEGORY();
            if(picture != null)
            {
                using(var scope = new TransactionScope())
                {
                    product.CATEGORY_CODE = cATEGORY.CATEGORY_CODE;
                    product.CATEGORY_NAME = cATEGORY.CATEGORY_NAME;
                    product.STATUS = cATEGORY.STATUS;
                    db.CATEGORies.Add(product);
                    db.SaveChanges();

                    var path = Server.MapPath(PICTURE_PATH);
                    picture.SaveAs(path + product.ID);
                    scope.Complete();
                }
            }
            else
            {
                ModelState.AddModelError("", "Picture not found!");
            }
            return RedirectToAction("Index");
        }

        // GET: Admin/CATEGORies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CATEGORY cATEGORY = db.CATEGORies.Find(id);
            if (cATEGORY == null)
            {
                return HttpNotFound();
            }
            return View(cATEGORY);
        }

        // POST: Admin/CATEGORies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CATEGORY cATEGORY, HttpPostedFileBase picture)
        {
            var product = db.CATEGORies.FirstOrDefault(x => x.ID == id);
            if (ModelState.IsValid)
            {
                using (var scope = new TransactionScope())
                {
                    db.Entry(cATEGORY).State = EntityState.Modified;
                    db.SaveChanges();

                    if (picture != null)
                    {
                        var path = Server.MapPath(PICTURE_PATH);
                        picture.SaveAs(path + cATEGORY.ID);
                    }

                    scope.Complete();
                    return RedirectToAction("Index");

                }
            }
            return View(cATEGORY);
        }

        // GET: Admin/CATEGORies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CATEGORY cATEGORY = db.CATEGORies.Find(id);
            if (cATEGORY == null)
            {
                return HttpNotFound();
            }
            return View(cATEGORY);
        }

        // POST: Admin/CATEGORies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CATEGORY cATEGORY = db.CATEGORies.Find(id);
            db.CATEGORies.Remove(cATEGORY);

            var path = Server.MapPath(PICTURE_PATH);
            System.IO.File.Delete(path + id);

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
