using EczaneOtomasyon.Models;
using EczaneOtomasyon.Models.Arac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EczaneOtomasyon.Controllers
{
    [UserAuthorize]

    public class EczaneController : Controller
    {
        EczaneDB db = new EczaneDB();

        // GET: Eczane
        public ActionResult Index()
        {
            return View(db.TBLKullanici.Where(x=> x.KullaniciTip== "Hasta").ToList());
        }
        public ActionResult HastaAra()
        {
            return View();
        }
        public ActionResult Recete(int KID)
        {
            return View(db.TBLKullanici.Where(x=> x.KID==KID).SingleOrDefault());
        }
        public ActionResult ReceteIsle(int rctID,int KID)
        {
            TBLRecete r = db.TBLRecete.Where(x=> x.RctID==rctID).SingleOrDefault();
            r.Durum = "İşlendi";
            db.SaveChanges();
            return Redirect("/Eczane/Recete?KID=" + KID);
        }
        public ActionResult _adSoyad()
        {
            ViewBag.AdSoyad = Session["AdSoyad"].ToString();
            return PartialView();
        }
        public ActionResult Ilaclar()
        {
            return View(db.TBLIlaclar.ToList());
        }
    }
}