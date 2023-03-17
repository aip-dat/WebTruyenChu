using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using WebTruyenChu.Models;
using PagedList;

namespace WebTruyenChu.Controllers
{
    //test commit comit 2?
    public class truyensController : Controller
    {
        private TruyenChuContext db = new TruyenChuContext();

        // GET: truyens
        public ActionResult Index()
        {
            var truyens = db.truyens.Include(t => t.theloai);
            return View(truyens.ToList());
        }
        public ActionResult TruyenTheLoai(int? page,int? matheloai)
        {
            ViewBag.matheloai = matheloai;
            if (page == null) page = 1;
            var list = (from s in db.truyens select s).Where(n => n.matheloai == matheloai).OrderBy(m => m.ngaydangtruyen);


            int pageSize = 6;
            int pageNum = page ?? 6;
            return View(list.ToPagedList(pageNum, pageSize));
        }
        public ActionResult TruyenAll(int? page)
        {
            if (page == null) page = 1;
            var list = (from s in db.truyens select s).OrderBy(n=>n.ngaydangtruyen);


            int pageSize = 6;
            int pageNum = page ?? 6;
            return View(list.ToPagedList(pageNum, pageSize));
        }

        //public ActionResult TruyenDetails(int? matruyen)
        //{
        //    chuong chap = new chuong();
        //    theloai spec = new theloai();
        //    truyen story = new truyen();
        //    HomeModel list = new HomeModel();
        //    if (matruyen == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    list.truyens = db.truyens.Where(n => n.matruyen == matruyen).ToList();
        //    list.theloais = db.theloais.ToList();
        //    list.chuongs = db.chuongs.Where(n => n.matruyen == matruyen).ToList();
        //    if (list.truyens.ToList().Count() == 0)
        //    {
        //        return HttpNotFound();
        //    }
        //    story = list.truyens.First();
        //    spec = list.theloais.FirstOrDefault(n => n.matheloai == story.matheloai);
        //    chap = list.chuongs.OrderBy(n => n.machuong).First();

        //    ViewBag.chuong1 = chap;
        //    ViewBag.truyen = story;
        //    ViewBag.theloaitruyen = spec;

        //    return View(list);
        //}
        public ActionResult TruyenDetails(int? matruyen)
        {
            chuongtruyen ct = new chuongtruyen();
            chuong chap = new chuong();
            theloai spec = new theloai();
            truyen story = new truyen();
            HomeModel list = new HomeModel();
            if (matruyen == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            list.truyens = db.truyens.Where(n => n.matruyen == matruyen).ToList();
            list.theloais = db.theloais.ToList();
            list.chuongs = db.chuongs.Where(n => n.matruyen == matruyen).ToList();
            if (list.truyens.ToList().Count() == 0)
            {
                return HttpNotFound();
            }

            story = list.truyens.First();
            spec = list.theloais.FirstOrDefault(n => n.matheloai == story.matheloai);
            if (list.chuongs.ToList().Count() == 0)
            {
                return HttpNotFound();
            }
            chap = list.chuongs.OrderBy(n => n.machuong).First();



            ct.matruyen = story.matruyen;
            ct.tentheloai = spec.tentheloai;
            ct.tentruyen = story.tentruyen;
            ct.hinh = story.hinh;
            ct.ngaydangtruyen = story.ngaydangtruyen;
            ct.tacgia = story.tacgia;
            ct.mota = story.mota;
            ct.mchuong = list.chuongs;
            //ViewBag.truyen = story;
            //ViewBag.theloaitruyen = spec;
            ViewBag.chuong1 = chap;

            return View(ct);
        }

        // GET: truyens/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            truyen truyen = db.truyens.Find(id);
            if (truyen == null)
            {
                return HttpNotFound();
            }
            return View(truyen);
        }

        // GET: truyens/Create
        public ActionResult Create()
        {
            ViewBag.matheloai = new SelectList(db.theloais, "matheloai", "tentheloai");
            return View();
        }

        // POST: truyens/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "matruyen,matheloai,tentruyen,hinh,tacgia,mota,ngaydangtruyen")] truyen truyen)
        {
            if (ModelState.IsValid)
            {
                db.truyens.Add(truyen);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.matheloai = new SelectList(db.theloais, "matheloai", "tentheloai", truyen.matheloai);
            return View(truyen);
        }

        // GET: truyens/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            truyen truyen = db.truyens.Find(id);
            if (truyen == null)
            {
                return HttpNotFound();
            }
            ViewBag.matheloai = new SelectList(db.theloais, "matheloai", "tentheloai", truyen.matheloai);
            return View(truyen);
        }

        // POST: truyens/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "matruyen,matheloai,tentruyen,hinh,tacgia,mota,ngaydangtruyen")] truyen truyen)
        {
            if (ModelState.IsValid)
            {
                db.Entry(truyen).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.matheloai = new SelectList(db.theloais, "matheloai", "tentheloai", truyen.matheloai);
            return View(truyen);
        }

        // GET: truyens/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            truyen truyen = db.truyens.Find(id);
            if (truyen == null)
            {
                return HttpNotFound();
            }
            return View(truyen);
        }

        // POST: truyens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            truyen truyen = db.truyens.Find(id);
            db.truyens.Remove(truyen);
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
