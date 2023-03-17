using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebTruyenChu.Models;


namespace WebTruyenChu.Areas.Admin.Controllers
{
    public class theloaisController : Controller
    {
        private TruyenChuContext db = new TruyenChuContext();

        // GET: Admin/theloais
        public ActionResult Index()
        {
            var db = new TruyenChuContext();
            List<theloai> theloais = db.theloais.ToList();

            return View(theloais);
        }
        //Detail
        //[HttpGet]
        //public ActionResult Detail(int id)
        //{
        //    var db = new TruyenChuContext();
        //    var result = db.theloais.Where(n => n.matheloai == id).SingleOrDefault();
        //    string values = string.Empty;

        //    values = JsonConvert.SerializeObject(result, Formatting.Indented, new JsonSerializerSettings
        //    {
        //        ReferenceLoopHandling = ReferenceLoopHandling.Ignore
        //    });
        //    return Json(values, JsonRequestBehavior.AllowGet);
        //}

        //Create
        [HttpPost]
        public ActionResult Create(theloai theloai)
        {
           
            if (ModelState.IsValid)
            {
                var db = new TruyenChuContext();
                db.theloais.Add(theloai);
                db.SaveChanges();

                return RedirectToAction("Index", "theloais");
            }

            return View("Index");
        }
        //Edit
        [HttpGet]
        public JsonResult GetTheLoaiById(int id)
        {
            var db = new TruyenChuContext();
            var result = db.theloais.Where(n => n.matheloai == id).SingleOrDefault();
            string values = string.Empty;

            values = JsonConvert.SerializeObject(result, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return Json(values, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult Update(theloai theloai)
        {
            var db = new TruyenChuContext();
            try
            {
                var entity = db.theloais.Where(n => n.matheloai == theloai.matheloai).FirstOrDefault();
                if (entity!=null)
                {
                    entity.tentheloai = theloai.tentheloai;
                    entity.tenurl = theloai.tenurl;

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
                var entity = db.theloais.Where(n => n.matheloai == id).FirstOrDefault();
                if (entity != null)
                {
                    db.theloais.Remove(entity);

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
