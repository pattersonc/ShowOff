using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShowOff.Core.Data;
using ShowOff.Core.Model;
using ShowOff.Core.Repository;

namespace ShowOff.Controllers
{
    public class SetupController : Controller
    {
        //
        // GET: /Setup/

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ActionName("Index")]
        public string Setup()
        {
            
            SetupHelper.ResetDatabase();
            SetupHelper.ExecuteMigrations(Server);
            SetupHelper.AddDefaultData();

            return "Setup complete";
        }
    }
}
