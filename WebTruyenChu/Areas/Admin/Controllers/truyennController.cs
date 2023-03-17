using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebTruyenChu.Models;
using Newtonsoft.Json;
using PagedList;

namespace WebTruyenChu.Areas.Admin.Controllers
{
    public class truyennController : Controller
    {
        private TruyenChuContext db = new TruyenChuContext();

        // GET: Admin/theloais
        public ActionResult Index(int? page)
        {
            if (page == null)
            {
                page = 1;
            }
            int pageSize = 20;
            int pageNum = page ?? 11;
            var db = new TruyenChuContext();
            List<truyen> truyens = db.truyens.ToList();

            return View(truyens.ToPagedList(pageNum,pageSize));
        }

        //Create
        [HttpPost]
        public ActionResult Create(truyen truyen)
        {

            if (ModelState.IsValid)
            {
                var db = new TruyenChuContext();
                truyen.ngaydangtruyen = DateTime.Now;
                db.truyens.Add(truyen);
                db.SaveChanges();

                return RedirectToAction("Index", "truyenn");
            }

            return View("Index");
        }
        //Edit
        [HttpGet]
        public JsonResult GetTruyenById(int id)
        {
            var db = new TruyenChuContext();
            var result = db.truyens.Where(n => n.matruyen == id).SingleOrDefault();
            string values = string.Empty;

            values = JsonConvert.SerializeObject(result, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return Json(values, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult Update(truyen truyen)
        {
            var db = new TruyenChuContext();
            try
            {
                var entity = db.truyens.Where(n => n.matruyen == truyen.matruyen).FirstOrDefault();
                if (entity != null)
                {
                    entity.matheloai = truyen.matheloai;
                    entity.tentruyen = truyen.tentruyen;
                    entity.hinh = truyen.hinh;
                    entity.tacgia = truyen.tacgia;
                    entity.mota = truyen.mota;
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
                var entity = db.truyens.Where(n => n.matruyen == id).FirstOrDefault();
                if (entity != null)
                {
                    db.truyens.Remove(entity);

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

        public string ProcessUpload(HttpPostedFileBase file)
        {
            if (file == null)
            {
                return "";
            }
            file.SaveAs(Server.MapPath("~/Content/img/" + file.FileName));
            return "/Content/img/" + file.FileName;
        }
    }
}