using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControlProductividadCIISA.Models.Login
{
    public class PermissionsAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var MySession = HttpContext.Current.Session;
 
           if (Convert.ToInt32(MySession["UserRolID"]) == 1)
            {
                filterContext.Result = new RedirectResult(string.Format("/Administrador"));
            }else
            {
                filterContext.Result = new RedirectResult(string.Format("/Analista"));
            }
        }
    }
}