using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TVCommon.Models;
using TVCommon.ViewModels;
using TVService.Contracts;

namespace TVWeb.Controllers
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
        public IEnumerable<Artigo> Get()
        {
            return this._service.GetArtigos();
        }
        [HttpGet("{month}/{year}")]
        public IEnumerable<Artigo> Get(int month, int year)
        {
            IEnumerable<Artigo> retorno = this._service.GetArtigos(year, month);

            return retorno;
        }
        [HttpGet("{year}")]
        public IEnumerable<Artigo> Get(int year)
        {
            IEnumerable<Artigo> retorno = this._service.GetArtigos(year);

            return retorno;
        }
        [HttpGet("{tittle}", Name = "GetArtigo")]
        public IActionResult Get(string tittle)
        {
            Artigo retorno = this._service.GetArtigo(tittle);

            return new ObjectResult(retorno);
        }

        [HttpPost("Create")]
        public IActionResult Create([FromBody] CreateArtigoViewMmodel obj)
        {
            return CreatedAtRoute("GetArtigo", new { tittle = obj.Artigo.Titulo });
        }
        [HttpGet("Create")]
        public IActionResult Create()
        {
            return View();
        }
    }
}