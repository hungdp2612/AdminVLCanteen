using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using vanlangcanteen.Models;

namespace vanlangcanteen.Areas.Admin.Controllers
{
    public class FOODtestController : Controller
    {
        QUANLYCANTEENEntities model = new QUANLYCANTEENEntities();
        // GET: Admin/FOOD
        public ActionResult Index()
        {
            var food = model.FOODs.OrderByDescending(x => x.ID).ToList();
            return View(food);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(FOOD f)
        {
            var food = new FOOD();
            food.FOOD_CODE = f.FOOD_CODE;
            food.FOOD_NAME = f.FOOD_NAME;
            food.DESCRIPTION = f.DESCRIPTION;
            food.PRICE = f.PRICE;
            food.IMAGE_URL = f.IMAGE_URL;
            food.STATUS = f.STATUS;
            model.FOODs.Add(food);
            model.SaveChanges();
            Session["Success"] = true;
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var food = model.FOODs.FirstOrDefault(x => x.ID == id);
            return View(food);
        }
        [HttpPost]
        public ActionResult Edit(int id, FOOD f)
        {
            var food = model.FOODs.FirstOrDefault(x => x.ID == id);
            food.FOOD_CODE = f.FOOD_CODE;
            food.FOOD_NAME = f.FOOD_NAME;
            food.DESCRIPTION = f.DESCRIPTION;
            food.PRICE = f.PRICE;
            food.IMAGE_URL = f.IMAGE_URL;
            food.STATUS = f.STATUS;
            model.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var food = model.FOODs.FirstOrDefault(x => x.ID == id);
            return View(food);
        }

        [HttpPost]
        public ActionResult DeleteConfirm(int id)
        {
            var food = model.FOODs.FirstOrDefault(x => x.ID == id);
            model.FOODs.Remove(food);
            model.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            var food = model.FOODs.FirstOrDefault(x => x.ID == id);
            return View(food);
        }

    }
}