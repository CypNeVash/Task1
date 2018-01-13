using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Task1.Models.Exeption
{
    [AttributeUsage(System.AttributeTargets.All)]
    public class ErrorPathExeptionFilter : FilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            
        }
    }
}