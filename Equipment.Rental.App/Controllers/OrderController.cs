using System;
using System.Collections.Generic;
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

        [HttpGet]
        public JsonResult GetAllEquipments()
        {
            var list  = new List<Models.Equipment> {
                new Models.Equipment{
                    Id = 1,
                    Name = "test",
                    Surname  = "test"

                },
                new Models.Equipment{
                    Id = 2,
                    Name = "elgun",
                    Surname  = "elgun"

                },
                new Models.Equipment{
                    Id = 3,
                    Name = "mirza",
                    Surname  = "mirza"

                }
            };
            return Json(list,"application/json",Encoding.UTF8,JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult AddToCart(int id,int rentDays)
        {
            var list = new List<Models.Equipment> {
                new Models.Equipment{
                    Id = 1,
                    Name = "test",
                    Surname  = "test"
                },
                new Models.Equipment{
                    Id = 2,
                    Name = "elgun",
                    Surname  = "elgun"
                },
                new Models.Equipment{
                    Id = 3,
                    Name = "mirza",
                    Surname  = "mirza"
                }
            };
            return Json(list, "application/json", Encoding.UTF8, JsonRequestBehavior.AllowGet);
        }
    }
}