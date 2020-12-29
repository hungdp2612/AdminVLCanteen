using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using vanlangcanteen.Models;
using vanlangcanteen.Areas.Admin.Middleware;

namespace vanlangcanteen.Areas.Admin.Controllers
{
    [LoginVerification]
    public class ORDERsController : Controller
    {
        private QUANLYCANTEENEntities model = new QUANLYCANTEENEntities();
        // GET: Admin/ORDERs
        public ActionResult Index()
        {
            var order = model.ORDERs.OrderByDescending(x => x.ID).ToList();
            return View(order);
        }
        public ActionResult Print(int id)
        {
            var printData = model.ORDERs.FirstOrDefault(x => x.ID == id);
            return View(printData);
        }
    }
}