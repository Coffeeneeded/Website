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
        private IDistributedCache _cache;
        public HomeController(IArticleService service, IDistributedCache cache)
        {
            this._service = service;
            this._cache = cache;
        }
        public IActionResult Index()
        {
            //List<CreateArtigoViewMmodel> lstReturn = this._service.GetArtigos().OrderByDescending(x => x.Artigo.DataPublicacao).ToList();
            List<CreateArtigoViewMmodel> lstReturn = JsonConvert.DeserializeObject<List<CreateArtigoViewMmodel>>(_cache.GetString("List_CreateArtigoViewMmodel") ?? "");
            if (lstReturn == null)
            {
                lstReturn = this._service.GetArtigos().OrderByDescending(x => x.Artigo.DataPublicacao).ToList();

                _cache.SetString("List_CreateArtigoViewMmodel", JsonConvert.SerializeObject(lstReturn, Formatting.None, new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                }));
            }
            return View(lstReturn);
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
