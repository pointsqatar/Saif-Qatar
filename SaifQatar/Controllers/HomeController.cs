using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SaifRepository;
using DataAccessLayer;

namespace SaifQatar.Controllers
{
    [HandleError(View = "~/Views/Error/Errorpage.cshtml")]
    [OutputCache(Duration = 10, VaryByParam = "none")]
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            List<HomeCarousel> result;
            if (HttpContext.Cache["HomeCarousel"] == null)
            {
                var menuRepository = new MenuRepository();
                result = menuRepository.GetCarousel();
                HttpContext.Cache["HomeCarousel"] = result;
            }
            else
            {
                result = (List<HomeCarousel>)HttpContext.Cache["HomeCarousel"];
            }
            return View(result);
        }

        public ActionResult AboutUs()
        {
            return View();
        }

        public ActionResult Products()
        {
            return View();
        }

        public ActionResult Events()
        {
            return View();
        }

        public ActionResult Services()
        {
            return View();
        }

        public ActionResult Downloads()
        {
            return View();
        }

        public ActionResult Gallery()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
    }
}