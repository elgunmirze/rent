using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Equipment.Rental.App.Controllers
{
    public class OrderController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public string GetApiUrl()
        {
            return ConfigurationManager.AppSettings["ApiUrl"].ToString();
        }
    }
}