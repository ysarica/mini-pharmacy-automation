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

    public class HastaController : Controller
    {
        EczaneDB db = new EczaneDB();

        // GET: Hasta
        public ActionResult Index()
        {
            int HastaID = Convert.ToInt32(Session["KullaniciID"].ToString());

            return View(db.TBLKullanici.Where(x=> x.KID==HastaID).SingleOrDefault());
        }
        public ActionResult _adSoyad()
        {
            ViewBag.AdSoyad = Session["AdSoyad"].ToString();
            return PartialView();
        }
    }
}