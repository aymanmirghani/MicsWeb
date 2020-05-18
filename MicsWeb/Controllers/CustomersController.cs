using MicsWeb.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Helpers;
using System.Web.Http;
using System.Web.Mvc;

namespace MicsWeb.Controllers
{
    public class CustomersController : Controller
    {
        public JsonResult Index()
        {
            MicsEntities context = new MicsEntities();
            {
                var r = new JsonResult { Data = null };
               
                string result = "No data found";
                var data = context.CustomerViews;
                if(data != null)
                {
                    var cusList = new List<CustomerView>();
                    foreach(var c in data)
                    {
                        cusList.Add(c);
                        //break;
                    }
                    r = new JsonResult { Data = cusList, JsonRequestBehavior=JsonRequestBehavior.AllowGet };
                    r.RecursionLimit = Int32.MaxValue;
                    r.ContentType = "Application/Json";
                    //result = JsonConvert.SerializeObject(cusList,
                    //Formatting.Indented,
                    //new JsonSerializerSettings()
                    //{
                    //    ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                    //});
                    return Json(r, JsonRequestBehavior.AllowGet);
                }
                return null;
            }
            
        } 
    }
}
