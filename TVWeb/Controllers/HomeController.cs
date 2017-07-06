using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TVService.Contracts;

namespace ThiagoVivas.Controllers
{
    public class HomeController : Controller
    {
        public readonly IArticleService _service;
        public HomeController(IArticleService service)
        {
            this._service = service;
        }
        public IActionResult Index()
        {
            var x = this._service.Get();
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
