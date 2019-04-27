using Action_Filter_sample_1.Models;
using Action_Filter_sample_1.Models.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Action_Filter_sample_1.Filters
{
    public class ResFilter : FilterAttribute, IResultFilter
    {
        DatabaseContext db = new DatabaseContext();

        public void OnResultExecuted(ResultExecutedContext filterContext) // (ed) View calistiktan sonra
        {
            db.db_context_Log.Add(new Models.Log()
            {
                Log_username = (filterContext.HttpContext.Session["login"] as User).User_username,
                Log_Actionname = filterContext.RouteData.Values["action"].ToString(),
                Log_Controllername = filterContext.RouteData.Values["controller"].ToString(),
                Log_Date = DateTime.Now,
                Log_Information = "OnResultExecuted"
            });

            db.SaveChanges();
        }

        public void OnResultExecuting(ResultExecutingContext filterContext) // (ing) View calismadan önce
        {
            db.db_context_Log.Add(new Models.Log()
            {
                Log_username = (filterContext.HttpContext.Session["login"] as User).User_username,
                Log_Actionname = filterContext.RouteData.Values["action"].ToString(),
                Log_Controllername = filterContext.RouteData.Values["controller"].ToString(),
                Log_Date = DateTime.Now,
                Log_Information = "OnResultExecuting"
            });

            db.SaveChanges();
        }
    }
}