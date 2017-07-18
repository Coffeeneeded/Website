using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TVCommon.Models;
using TVCommon.ViewModels;

namespace TVWeb.Controllers
{
    [Produces("application/json")]
    [Route("api/Article")]
    public class ArticleController : Controller
    {
        [HttpGet]
        public IActionResult Get()
        {
            return null;
        }
        [HttpGet("{month}/{year}")]
        public IEnumerable<Artigo> Get(int month, int year)
        {
            IEnumerable<Artigo> retorno = null;


            return retorno;
        }
        [HttpGet("{year}")]
        public IEnumerable<Artigo> Get(int year)
        {
            IEnumerable<Artigo> retorno = null;


            return retorno;
        }
        [HttpGet("{tittle}", Name = "GetArtigo")]
        public IActionResult Get(string tittle)
        {
            Artigo retorno = new Artigo();


            return new ObjectResult(retorno);
        }

        [HttpPost("Create")]
        public IActionResult Create([FromBody] CreateArtigoViewMmodel obj)
        {

            return CreatedAtRoute("GetArtigo", new { tittle = obj.Artigo.Titulo });
            //return CreatedAtRoute("GetArtigo", new { tittle = obj.Titulo }, obj);
        }
        [HttpGet("Create")]
        public IActionResult Create()
        {

            return View();
        }
    }
}