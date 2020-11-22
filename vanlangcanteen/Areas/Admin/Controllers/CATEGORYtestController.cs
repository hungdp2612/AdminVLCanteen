using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using vanlangcanteen.Models;

namespace vanlangcanteen.Areas.Admin.Controllers
{
    public class CATEGORYtestController : Controller
    {
        QUANLYCANTEENEntities model = new QUANLYCANTEENEntities();
        // GET: Admin/CATEGORY
        public ActionResult Index()
        {
            var category = model.CATEGORies.OrderByDescending(x => x.ID).ToList();
            return View(category);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(CATEGORY c)
        {
            var category = new CATEGORY();
            category.CATEGORY_CODE = c.CATEGORY_CODE;
            category.CATEGORY_NAME = c.CATEGORY_NAME;
            category.IMAGE_URL = c.IMAGE_URL;
            category.STATUS = c.STATUS;
            model.CATEGORies.Add(category);
            model.SaveChanges();
            Session["Success"] = true;
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var category = model.CATEGORies.FirstOrDefault(x => x.ID == id);
            return View(category);
        }
        [HttpPost]
        public ActionResult Edit(int id, CATEGORY c)
        {
            var category = model.CATEGORies.FirstOrDefault(x => x.ID == id);
            category.CATEGORY_CODE = c.CATEGORY_CODE;
            category.CATEGORY_NAME = c.CATEGORY_NAME;
            category.IMAGE_URL = c.IMAGE_URL;
            category.STATUS = c.STATUS;
            model.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var category = model.CATEGORies.FirstOrDefault(x => x.ID == id);
            return View(category);
        }
        [HttpPost]
        public ActionResult DeleteConfirm(int id, CATEGORY c)
        {
            var category = model.CATEGORies.FirstOrDefault(x => x.ID == id);
            model.CATEGORies.Remove(category);
            model.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            var category = model.CATEGORies.FirstOrDefault(x => x.ID == id);
            return View(category);
        }
    }
}