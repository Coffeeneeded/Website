using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TVCommon.Models;
using TVCommon.ViewModels;
using TVRepository.Interface;
using TVService.Contracts;

namespace TVService
{
    public class ArticleService : IArticleService
    {
        private  IArticlesDAL dependency;
        public ArticleService(IArticlesDAL _dependency)
        {
            this.dependency = _dependency;
        }

        public long CreateArtigo(CreateArtigoViewMmodel obj)
        {
            long retorno = 0;
            try
            {
                retorno = dependency.CreateArtigo(obj.Artigo);
                if (retorno > 0)
                {
                    List<Tag> lstTag = new List<Tag>();
                    List<ArtigoTag> lstArtigoTag = new List<ArtigoTag>();
                    ArtigoTag objArtigoTag;
                    Tag objTag;



                    foreach (var item in obj.Tags.Split())
                    {
                        objTag = new Tag();

                        objTag.Nome = item;
                        lstTag.Add(objTag);
                    }

                    long[] tagsId = this.CreateTags(lstTag);


                    foreach (long idTag in tagsId)
                    {
                        objArtigoTag = new ArtigoTag();

                        objArtigoTag.IdArtigo = retorno;
                        objArtigoTag.IdTag = idTag;

                        lstArtigoTag.Add(objArtigoTag);
                    }

                    this.CreateArtigoTag(lstArtigoTag);

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return retorno;
        }

        public long[] CreateArtigoTag(List<ArtigoTag> objs)
        {
            return dependency.CreateArtigoTag(objs);
        }

        public long CreateArtigoTag(ArtigoTag obj)
        {
            return dependency.CreateArtigoTag(obj);
        }

        public long CreateAutor(Autor obj)
        {
            return dependency.CreateAutor(obj);
        }

        public long[] CreateImagens(List<Imagem> objs)
        {
            return dependency.CreateImagens(objs);
        }

        public long[] CreateRedeSociaisPessooa(List<RedeSocialPessoa> objs)
        {
            return dependency.CreateRedeSociaisPessooa(objs);
        }

        public long CreateRedeSocial(RedeSocial obj)
        {
            return dependency.CreateRedeSocial(obj);
        }

        public long[] CreateTags(List<Tag> objs)
        {
            return dependency.CreateTags(objs);
        }

        public string Get()
        {
            return "teste";
        }

        public CreateArtigoViewMmodel GetArtigo(string titulo)
        {
            CreateArtigoViewMmodel retorno = new CreateArtigoViewMmodel();
            List<Tag> lstTag = new List<Tag>();

            retorno.Artigo = dependency.GetArtigo(titulo);
            if (retorno.Artigo != null)
            {
                List<long> lstIdTags = dependency.GetArtigoTagPorArtigo(retorno.Artigo.IdArtigo).Select(x => x.IdTag).ToList();

                lstIdTags.ForEach(x => lstTag.Add(dependency.GetTag(x)));
                lstTag.ForEach(x => retorno.Tags += x.Nome + " ");
            }
            return retorno;
        }

        public CreateArtigoViewMmodel GetArtigo(long id)
        {
            CreateArtigoViewMmodel retorno = new CreateArtigoViewMmodel();
            List<Tag> lstTag = new List<Tag>();
            

            retorno.Tags = "A B C";
            retorno.Artigo = dependency.GetArtigo(id);
            //List<long> lstIdTags = dependency.GetArtigoTagPorArtigo(retorno.Artigo.IdArtigo).Select(x => x.IdTag).ToList();

            //lstIdTags.ForEach(x => lstTag.Add(dependency.GetTag(x)));
            //lstTag.ForEach(x => retorno.Tags += x.Nome + " ");

            return retorno;
        }
        //public string GetTagPorArtigoId(long artigoId)
        //{
        //    string retorno = string.Empty;
        //    var tags = this.dependency.GetTag()
        //}

        public CreateArtigoViewMmodel GetArtigoNovo(long id)
        {
            CreateArtigoViewMmodel retorno = new CreateArtigoViewMmodel();
            List<Tag> lstTag = new List<Tag>();

            retorno.Tags = string.Empty;
            retorno.Artigo = dependency.GetArtigo(id);
            List<long> lstIdTags = dependency.GetArtigoTagPorArtigo(retorno.Artigo.IdArtigo).Select(x => x.IdTag).ToList();

            lstIdTags.ForEach(x => lstTag.Add(dependency.GetTag(x)));
            lstTag.ForEach(x => retorno.Tags += x.Nome + " ");

            return retorno;
        }
        public List<CreateArtigoViewMmodel> GetArtigosNovo(int maxArtigos = 5)
        {
            List<CreateArtigoViewMmodel> retorno = new List<CreateArtigoViewMmodel>();
            List<long> lstArtigoId = this.dependency.GetArtigosId(maxArtigos);
            lstArtigoId.ForEach(x => retorno.Add(this.GetArtigoNovo(x)));

            return retorno;
        }

        public List<CreateArtigoViewMmodel> GetArtigos(int maxArtigos = 5)
        {
            List<CreateArtigoViewMmodel> retorno = new List<CreateArtigoViewMmodel>();
            
            List<long> lstArtigoId = this.dependency.GetArtigosId(maxArtigos);

                        
            lstArtigoId.ForEach(x => retorno.Add(this.GetArtigo(x)));


            return retorno;
        }

        public List<CreateArtigoViewMmodel> GetArtigosByYear(int year)
        {
            List<CreateArtigoViewMmodel> retorno = new List<CreateArtigoViewMmodel>();
            List<long> lstArtigoId = new List<long>();

            lstArtigoId = dependency.GetArtigos(year).Select(x => x.IdArtigo).ToList();
            lstArtigoId.ForEach(x => retorno.Add(this.GetArtigo(x)));

            return retorno;
        }

        public List<CreateArtigoViewMmodel> GetArtigos(int year, int mes)
        {
            List<CreateArtigoViewMmodel> retorno = new List<CreateArtigoViewMmodel>();
            List<long> lstArtigoId = new List<long>();

            lstArtigoId = dependency.GetArtigos(year, mes).Select(x => x.IdArtigo).ToList();
            lstArtigoId.ForEach(x => retorno.Add(this.GetArtigo(x)));

            return retorno;
        }

        public List<CreateArtigoViewMmodel> GetArtigosBuscaTexto(string busca)
        {
            List<CreateArtigoViewMmodel> retorno = new List<CreateArtigoViewMmodel>();

            return retorno;
        }

        public List<CreateArtigoViewMmodel> GetArtigosBuscaTitulo(string busca)
        {
            List<CreateArtigoViewMmodel> retorno = new List<CreateArtigoViewMmodel>();

            return retorno;
        }

        public List<CreateArtigoViewMmodel> GetArtigosBuscaTituloETexto(string busca)
        {
            List<CreateArtigoViewMmodel> retorno = new List<CreateArtigoViewMmodel>();

            return retorno;
        }

        public List<CreateArtigoViewMmodel> GetArtigoPorTag(string tag)
        {
            List<CreateArtigoViewMmodel> retorno = new List<CreateArtigoViewMmodel>();

            var tagId = this.dependency.GetTag(tag).IdTag;
            var lstArtigoTag = this.dependency.GetArtigoTagPorTag(tagId).Select(x => x.IdArtigoTag).ToList();
            List<long> idArtigos = this.dependency.GetArtigoPorArtigoTagId(lstArtigoTag).Select(x => x.IdArtigo).ToList();

            idArtigos.ForEach(x => retorno.Add(this.GetArtigo(x)));
            return retorno;
        }

        public List<ArtigoTag> GetArtigoTag()
        {
            return dependency.GetArtigoTag();
        }

        public List<ArtigoTag> GetArtigoTagPorArtigo(long idArtigo)
        {
            return dependency.GetArtigoTagPorArtigo(idArtigo);
        }

        public List<ArtigoTag> GetArtigoTagPorTag(long idTag)
        {
            return dependency.GetArtigoTagPorTag(idTag);
        }

        public Autor GetAutor(string nome)
        {
            return dependency.GetAutor(nome);
        }

        public Autor GetAutor(long id)
        {
            return dependency.GetAutor(id);
        }

        public List<Autor> GetAutores()
        {
            return dependency.GetAutores();
        }

        public Imagem GetImagens(long idImagem)
        {
            return dependency.GetImagens(idImagem);
        }


        public List<RedeSocial> GetRedeSociais()
        {
            return dependency.GetRedeSociais();
        }

        public RedeSocial GetRedeSociais(long idRedeSocial)
        {
            return dependency.GetRedeSociais(idRedeSocial);
        }

        public List<RedeSocialPessoa> GetRedeSociaisPessoa(long idPessoa)
        {
            return dependency.GetRedeSociaisPessoa(idPessoa);
        }

        public List<Tag> GetTags()
        {
            return dependency.GetTags();
        }

    }
}
