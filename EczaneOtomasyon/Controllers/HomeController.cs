using EczaneOtomasyon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EczaneOtomasyon.Controllers
{
    public class HomeController : Controller
    {
        EczaneDB db = new EczaneDB();
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(string TC,string Sifre)
        {
            string yol="/Hekim/Index/";
            TBLKullanici k = db.TBLKullanici.Where(x => x.TC == TC && x.Sifre == Sifre).SingleOrDefault();
            if (k!=null)
            {
                Session["KullaniciID"] = k.KID;
                Session["KulTip"] = k.KullaniciTip;
                Session["AdSoyad"] = k.AdSoyad;
                if (k.KullaniciTip=="Hekim")
                {
                    yol = "/Hekim/Index/";
                }
                else if(k.KullaniciTip== "Eczacı")
                {
                    yol = "/Eczane/Index/";
                }
                else
                {
                    yol = "/Hasta/Index/";
                }
            }
            return Redirect(yol);
        }
        public ActionResult CikisYap()
        {
            Session.Abandon();
            return Redirect("/Home/Index/");
        }
        public ActionResult Mesaj(string msj)
        {
            ViewBag.msj = msj;
            return View();
        }
        public ActionResult DoktorEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DoktorEkle(TBLKullanici d)
        {
            TBLKullanici dr = new TBLKullanici();
            dr.TC = d.TC;
            dr.Sifre=d.Sifre;
            dr.KullaniciTip = "Hekim";
            dr.AdSoyad = d.AdSoyad;
            dr.Cinsiyet = d.Cinsiyet;
            dr.KullaniciKat = d.KullaniciKat;
            db.TBLKullanici.Add(dr);
            db.SaveChanges();
            return Redirect("/Home/Mesaj?msj= "+d.AdSoyad+" İsminde Hekim Başarıyla Eklendi");
        }
        public ActionResult EczaciEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult EczaciEkle(TBLKullanici e)
        {
            TBLKullanici ec = new TBLKullanici();
            ec.TC = e.TC;
            ec.Sifre = e.Sifre;
            ec.KullaniciTip = "Eczacı";
            ec.AdSoyad = e.AdSoyad;
            ec.Cinsiyet = e.Cinsiyet;
            ec.KullaniciKat = "Yok";
            db.TBLKullanici.Add(ec);
            db.SaveChanges();
            return Redirect("/Home/Mesaj?msj= " + e.AdSoyad + " İsminde Eczacı Başarıyla Eklendi");
        }
    }
}