using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using WebTruyenChu.Models;

namespace WebTruyenChu.Controllers
{
    public class HomeController : Controller
    {
        TruyenChuContext truyenChuContext = new TruyenChuContext();
        HomeModel homeModel = new HomeModel();

        public ActionResult Index()
        {
            homeModel.theloais = truyenChuContext.theloais.ToList();
            homeModel.truyens = truyenChuContext.truyens.ToList();
            homeModel.chuongs = truyenChuContext.chuongs.ToList();
            return View(homeModel);
        }
        public ActionResult OurBlog()
        {
            homeModel.theloais = truyenChuContext.theloais.ToList();
            homeModel.truyens = truyenChuContext.truyens.ToList();
            homeModel.chuongs = truyenChuContext.chuongs.ToList();
            return View(homeModel);
        }
        public JsonResult Search()
        {
            var db = truyenChuContext;
            List<truyen> allsearch = db.truyens.ToList();
            string value = string.Empty;
            value = JsonConvert.SerializeObject(allsearch, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return Json(value, JsonRequestBehavior.AllowGet);
        }

        public ActionResult MenuPartial()
        {
            homeModel.theloais = truyenChuContext.theloais.ToList();
            homeModel.truyens = truyenChuContext.truyens.ToList();
            homeModel.chuongs = truyenChuContext.chuongs.ToList();
            return PartialView(homeModel);
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}