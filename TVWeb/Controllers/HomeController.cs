using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TVService.Contracts;
using Microsoft.Extensions.Caching.Distributed;
using TVCommon.ViewModels;
using Newtonsoft.Json;

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
            List<CreateArtigoViewMmodel> lstReturn = this._service.GetArtigos().OrderByDescending(x => x.Artigo.DataPublicacao).ToList();
         
            return View(lstReturn);
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
