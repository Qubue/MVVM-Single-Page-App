using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvvmData;

namespace MVVM_Single_Page_App.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            TrainingProductViewModel vm = new TrainingProductViewModel();

            vm.HandleRequest();
            return View(vm);
        }
        [HttpPost]
        public ActionResult Index(TrainingProductViewModel vm)
        {
            vm.HandleRequest();
            ModelState.Clear();
            return View(vm);
        }
    }
}