using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ATKManager.Controllers
{
    public class ATKAdminController : Controller
    {
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Cort()
        {
            return View();
        }


    }
}
