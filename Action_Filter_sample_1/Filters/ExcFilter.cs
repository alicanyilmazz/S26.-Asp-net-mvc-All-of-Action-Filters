using Action_Filter_sample_1.Models;
using Action_Filter_sample_1.Models.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Action_Filter_sample_1.Filters
{
    public class ExcFilter : FilterAttribute, IExceptionFilter
    {
        DatabaseContext db = new DatabaseContext();
        public void OnException(ExceptionContext filterContext)
        {

            string user_name = string.Empty;

            if(filterContext.HttpContext.Session["login"]!=null)
            {
                user_name = (filterContext.HttpContext.Session["login"] as User).User_username;
            }
             
            db.db_context_Log.Add(new Models.Log()
            {
                Log_username =user_name,
                Log_Actionname = filterContext.RouteData.Values["action"].ToString(),
                Log_Controllername = filterContext.RouteData.Values["controller"].ToString(),
                Log_Date = DateTime.Now,
                Log_Information ="Error : "+filterContext.Exception.Message //sql den direkt "Error" kelimesi gecenleri ver deyip sorgulayabiliriz.
            });

            db.SaveChanges();



            filterContext.ExceptionHandled = true; //hatayı bizim yöneteceğimizi belirtmemiz için true yapıldı.
            filterContext.Controller.TempData["error"] = filterContext.Exception;
            filterContext.Result = new RedirectResult("/Login/Error");
        }
    }
}