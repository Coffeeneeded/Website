using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TVCommon.ViewModels;
using TVService.Contracts;

namespace TVInterface.Controllers
{
    [Produces("application/json")]
    [Route("api/Article")]

    public class ArticleController : Controller
    {

        public readonly IArticleService _service;

        public ArticleController(IArticleService service)
        {
            this._service = service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return View(this._service.GetArtigos().OrderByDescending(x => x.Artigo.DataPublicacao));

        }

        [HttpPost]
        public IActionResult Post()
        {
            //var x = _service.CreateArtigo(obj);
            return CreatedAtRoute("GetArticle", new { Tittle = "teste" });
        }


        [HttpPost]
        public IActionResult Post(CreateArtigoViewMmodel obj)
        {
            var x = _service.CreateArtigo(obj);
            return CreatedAtRoute("GetArticle", new { Tittle = obj.Artigo.Titulo });
        }
        [HttpGet("/api/Article/{year}/{month}")]
        public IActionResult Get(int year, int month)
        {
            var retorno = this._service.GetArtigos(year, month);

            return View("Get", retorno);
        }
        [HttpGet("/api/Article/{year:int}")]
        public IActionResult GetByYear(int Year)
        {
            var retorno = this._service.GetArtigos(Year);

            return View("Get", retorno);
        }
        [HttpGet("/api/Article/{Tittle}")]
        public IActionResult GetArticle(string Tittle)
        {
            int ano = 0;
            if (int.TryParse(Tittle, out ano))
                return RedirectToAction("GetByYear", new { Year = ano });

            CreateArtigoViewMmodel retorno = this._service.GetArtigo(Tittle.Replace('-', ' '));

            return View(retorno);
        }
        [Produces("application/json")]
        [HttpPost("Create"), Consumes("application/json")]
        //public IActionResult Create([FromBody] CreateArtigoViewMmodel obj)
        public IActionResult Create([FromBody] CreateArtigoViewMmodel obj)
        {
            //texto do artigo tem q vir em formato html
            var x = _service.CreateArtigo(obj);
            return CreatedAtRoute("GetArticle", new { tittle = obj.Artigo.Titulo });
        }
        [HttpGet("Create")]
        public IActionResult Create()
        {
            return View();
        }
        [HttpGet("Tag/{tag}")]
        public IActionResult GetTag(string tag)
        {
            return View(this._service.GetArtigoPorTag(tag).OrderByDescending(x => x.Artigo.DataPublicacao));
        }
    }
}