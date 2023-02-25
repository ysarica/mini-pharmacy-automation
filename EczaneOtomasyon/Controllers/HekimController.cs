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

    public class HekimController : Controller
    {
        EczaneDB db = new EczaneDB();

        // GET: Hekim
        public ActionResult Index()
        {
            int DoktorID = Convert.ToInt32(Session["KullaniciID"].ToString());

            ViewBag.HastaSayi = db.TBLKullanici.Where(x => x.KullaniciTip == "Hasta").Count();
            ViewBag.IlacSayi = db.TBLIlaclar.Count();
            ViewBag.ReceteHasta = db.TBLRecete.Where(x => x.DoktorID == DoktorID).Count();
            ViewBag.DoktorSayi= db.TBLKullanici.Where(x => x.KullaniciTip == "Doktor").Count();
            return View();
        }
        public ActionResult ReceteKullanici()
        {
            return View(db.TBLKullanici.Where(x => x.KullaniciTip == "Hasta").ToList());
        }
        public ActionResult ReceteYaz(int KID)
        {
            ViewBag.KID = KID.ToString();
            int DoktorID = Convert.ToInt32(Session["KullaniciID"].ToString());
            Session["HastaID"] = KID.ToString();
            int iRecSonID = 0;
            try
            {
                iRecSonID = db.TBLRecete.Where(x => x.HastaID == KID).Max(x => x.RctID);
            }
            catch
            {
            }
            if (iRecSonID != 0)
            {
                TBLRecete r = db.TBLRecete.Where(x => x.RctID == iRecSonID).SingleOrDefault();
                if (r.Durum == "Onaylanmadı")
                {
                    Session["RecID"] = iRecSonID.ToString();
                }
                else
                {
                    TBLRecete rec = new TBLRecete();
                    rec.DoktorID = DoktorID;//Üye Girişi Yapıldıktan Sonra Sessiondan Alınacak
                    rec.HastaID = KID;
                    rec.Durum = "Onaylanmadı";
                    rec.ReceteAciklama = "Belirtilmedi";
                    rec.Tarih = DateTime.Now.ToShortDateString() + "-" + DateTime.Now.ToShortTimeString();
                    db.TBLRecete.Add(rec);
                    db.SaveChanges();
                    int RecSonID = db.TBLRecete.Where(x => x.HastaID == KID).Max(x => x.RctID);
                    Session["RecID"] = RecSonID.ToString();
                }
            }
            else
            {
                TBLRecete rec = new TBLRecete();
                rec.DoktorID = DoktorID;//Üye Girişi Yapıldıktan Sonra Sessiondan Alınacak
                rec.HastaID = KID;
                rec.Durum = "Onaylanmadı";
                rec.ReceteAciklama = "Belirtilmedi";
                rec.Tarih = DateTime.Now.ToShortDateString() + "-" + DateTime.Now.ToShortTimeString();
                db.TBLRecete.Add(rec);
                db.SaveChanges();
                int RecSonID = db.TBLRecete.Where(x => x.HastaID == KID).Max(x => x.RctID);
                Session["RecID"] = RecSonID.ToString();
            }

            return View();
        }
        public ActionResult _rIlacEkle(int gIlacID, int gAdet)
        {
            if (gIlacID != 0)
            {
                TBLReceteIlac ilac = new TBLReceteIlac();
                ilac.IlacID = gIlacID;
                ilac.Adet = gAdet;
                ilac.ReceteID = Convert.ToInt32(Session["RecID"]);
                db.TBLReceteIlac.Add(ilac);
                db.SaveChanges();
            }

            return Redirect("/Hekim/ReceteYaz?KID=" + Session["HastaID"]);
        }
        public ActionResult _RilacSil(int IlacID)
        {
            TBLReceteIlac r = db.TBLReceteIlac.Where(x => x.RIlacID == IlacID).SingleOrDefault();
            db.TBLReceteIlac.Remove(r);
            db.SaveChanges();
            return Redirect("/Hekim/ReceteYaz?KID=" + Session["HastaID"]);
        }
        public ActionResult _RHastaEkle(TBLKullanici k)
        {
            TBLKullanici h = new TBLKullanici();
            h.AdSoyad = k.AdSoyad;
            h.TC = k.TC;
            h.Cinsiyet = k.Cinsiyet;
            h.KullaniciTip = "Hasta";
            h.Sifre = k.TC;
            h.KullaniciKat = (0).ToString();
            db.TBLKullanici.Add(h);
            db.SaveChanges();
            return Redirect("/Hekim/ReceteKUllanici/");
        }
        public ActionResult ReceteOnay()
        {
            int ReceteID = Convert.ToInt32(Session["RecID"]);
            TBLRecete r = db.TBLRecete.Where(x => x.RctID == ReceteID).SingleOrDefault();
            r.Durum = "Onaylandı";
            db.SaveChanges();
            return View(db.TBLRecete.Where(x => x.RctID == ReceteID).SingleOrDefault());
        }
        public ActionResult Ilaclar()
        {
            int DoktorID = Convert.ToInt32(Session["KullaniciID"].ToString());
            TBLKullanici k = db.TBLKullanici.Where(x => x.KID == DoktorID).SingleOrDefault();
            return View(db.TBLIlaclar.Where(x => x.IlacKategori == k.KullaniciKat).ToList());
        }
        public ActionResult _IlacEkle(TBLIlaclar i)
        {
            int DoktorID = Convert.ToInt32(Session["KullaniciID"].ToString());
            TBLKullanici k = db.TBLKullanici.Where(x => x.KID == DoktorID).SingleOrDefault();
            TBLIlaclar il = new TBLIlaclar();
            il.IlacAdi = i.IlacAdi;
            il.IlacKategori = k.KullaniciKat;
            db.TBLIlaclar.Add(il);
            db.SaveChanges();
            return Redirect("/Hekim/Ilaclar/");
        }
        public ActionResult IlacSil(int IlacID)
        {
            TBLIlaclar i = db.TBLIlaclar.Where(x => x.IID == IlacID).SingleOrDefault();
            db.TBLIlaclar.Remove(i);
            db.SaveChanges();
            return Redirect("/Hekim/Ilaclar/");
        }
        public ActionResult Hastalar()
        {
            return View(db.TBLKullanici.Where(x => x.KullaniciTip == "Hasta").ToList());
        }
        public ActionResult _HastaEkle(TBLKullanici k)
        {
            TBLKullanici h = new TBLKullanici();
            h.AdSoyad = k.AdSoyad;
            h.TC = k.TC;
            h.Cinsiyet = k.Cinsiyet;
            h.KullaniciTip = "Hasta";
            h.Sifre = k.TC;
            h.KullaniciKat = (0).ToString();
            db.TBLKullanici.Add(h);
            db.SaveChanges();
            return Redirect("/Hekim/Hastalar/");
        }
        public ActionResult _HastaSil(int HastaID)
        {
            TBLKullanici h = db.TBLKullanici.Where(x => x.KID == HastaID).SingleOrDefault();
            db.TBLKullanici.Remove(h);
            db.SaveChanges();
            return Redirect("/Hekim/Hastalar/");
        }
        public ActionResult HastaDetay(int HastaID)
        {
            return View(db.TBLKullanici.Where(x => x.KID == HastaID).SingleOrDefault());
        }
        public ActionResult Receteler()
        {
            int DoktorID = Convert.ToInt32(Session["KullaniciID"].ToString());

            return View(db.TBLRecete.Where(x => x.DoktorID == DoktorID).ToList());
        }
        public ActionResult Profil()
        {
            int DoktorID = Convert.ToInt32(Session["KullaniciID"].ToString());
            return View(db.TBLKullanici.Where(x=> x.KID==DoktorID).SingleOrDefault());
        }
        [HttpPost]
        public ActionResult Profil(TBLKullanici k)
        {
            int DoktorID = Convert.ToInt32(Session["KullaniciID"].ToString());
            TBLKullanici ku = db.TBLKullanici.Where(x => x.KID == DoktorID).SingleOrDefault() ;
            ku.AdSoyad = k.AdSoyad;
            ku.TC = k.TC;
            ku.Sifre = k.Sifre;
            db.SaveChanges();
            return Redirect("/Hekim/Profil/");
        }
        public ActionResult _adSoyad()
        {
            ViewBag.AdSoyad = Session["AdSoyad"].ToString();
            return PartialView();
        }
    }
}