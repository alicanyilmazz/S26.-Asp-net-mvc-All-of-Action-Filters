using Action_Filter_sample_1.Models;
using Action_Filter_sample_1.Models.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Action_Filter_sample_1.Filters
{
    public class ActFilter : FilterAttribute, IActionFilter
    {
        DatabaseContext db = new DatabaseContext();
        public void OnActionExecuted(ActionExecutedContext filterContext) // (ed) Action calistiktan sonra
        {
            db.db_context_Log.Add(new Models.Log()
            {
                Log_username =(filterContext.HttpContext.Session["login"] as User).User_username,
                Log_Actionname =filterContext.ActionDescriptor.ActionName,
                Log_Controllername =filterContext.ActionDescriptor.ControllerDescriptor.ControllerName,
                Log_Date = DateTime.Now,
                Log_Information = "OnActionExecuted"
            });

            db.SaveChanges();
        }

        public void OnActionExecuting(ActionExecutingContext filterContext) //(ing) Action calismadan önce
        {
            db.db_context_Log.Add(new Models.Log() //bu kısımların asenkron programlanmalı hız acısından ve 2.bir log veritabanına kayıt yapılmadı database şişmesin diye.
            {
                Log_username = (filterContext.HttpContext.Session["login"] as User).User_username,
                Log_Actionname = filterContext.ActionDescriptor.ActionName,
                Log_Controllername = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName,
                Log_Date = DateTime.Now,
                Log_Information = "OnActionExecuting"
            });

            db.SaveChanges(); 
        }
    }
}