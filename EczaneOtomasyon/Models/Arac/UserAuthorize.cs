using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EczaneOtomasyon.Models.Arac
{
    public class UserAuthorize : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            EczaneDB db = new EczaneDB();

            if (httpContext.Session["KullaniciID"] != null && httpContext.Session["KulTip"].ToString()!=null)
            {
                
                //if (httpContext.Session["KulTip"].ToString()== "Hekim")
                //{
                //    httpContext.Response.Redirect("/Hekim/Index");
                //}
                //else if(httpContext.Session["KulTip"].ToString() == "Eczacı")
                //{
                //    httpContext.Response.Redirect("/Eczane/Index");
                //}
                //else
                //{
                //    httpContext.Response.Redirect("/Hasta/Index");
                //}
                return true;
            }
            else
            {
                httpContext.Response.Redirect("/Home/Index/");
                return false;
            }

        }
    }
}