using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebTruyenChu.Models;

namespace WebTruyenChu.Areas.Admin.Controllers
{
    public class chuonggController : Controller
    {
        // GET: Admin/chuongs
        private TruyenChuContext db = new TruyenChuContext();

        // GET: Admin/theloais
        public ActionResult Index()
        {
            var db = new TruyenChuContext();
            List<chuong> chuongs = db.chuongs.ToList();

            return View(chuongs);
        }

        //Create
        [HttpPost]
        public ActionResult Create(chuong chuong)
        {

            if (ModelState.IsValid)
            {
                var db = new TruyenChuContext();
                chuong.ngaydangchuong = DateTime.Now;
                db.chuongs.Add(chuong);
                db.SaveChanges();

                return RedirectToAction("Index", "chuongg");
            }

            return View("Index");
        }
        //Edit
        [HttpGet]
        public JsonResult GetChuongById(int id)
        {
            var db = new TruyenChuContext();
            var result = db.chuongs.Where(n => n.machuong == id).SingleOrDefault();
            string values = string.Empty;

            values = JsonConvert.SerializeObject(result, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return Json(values, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult Update(chuong chuong)
        {
            var db = new TruyenChuContext();
            try
            {
                var entity = db.chuongs.Where(n => n.machuong == chuong.machuong).FirstOrDefault();
                if (entity != null)
                {
                    entity.machuong = chuong.machuong;
                    entity.matruyen = chuong.matruyen;
                    entity.tenchuong = chuong.tenchuong;
                    entity.noidungchuong = chuong.noidungchuong;
                    entity.ngaydangchuong = chuong.ngaydangchuong;
                    //entity.ngaydangtruyen = DateTime.Now;

                    db.SaveChanges();

                    return Json(new
                    {
                        status = true
                    });
                }
                else
                {
                    return Json(new
                    {
                        status = false
                    });
                }
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    status = false,
                    message = ex
                });
            }
        }
        [HttpPost]
        public JsonResult Delete(int id)
        {
            var db = new TruyenChuContext();
            try
            {
                var entity = db.chuongs.Where(n => n.machuong == id).FirstOrDefault();
                if (entity != null)
                {
                    db.chuongs.Remove(entity);

                    db.SaveChanges();

                    return Json(new
                    {
                        status = true
                    });
                }
                else
                {
                    return Json(new
                    {
                        status = false
                    });
                }
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    status = false,
                    message = ex
                });
            }
        }
    }
}