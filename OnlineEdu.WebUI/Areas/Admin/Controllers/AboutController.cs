﻿using Microsoft.AspNetCore.Mvc;

namespace OnlineEdu.WebUI.Areas.Admin.Controllers
{
    public class AboutController : Controller
    {
        [Route("[area]/[controller]/[action]/{id?}")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
