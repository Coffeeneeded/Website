using System;
using System.Collections.Generic;
using System.Text;
using TVCommon.Models;
using TVCommon.ViewModels;
using TVRepository.Interface;
using TVService.Contracts;

namespace TVService
{
    public class ArticleService : IArticleService
    {
        private readonly IArticlesDAL dependency;
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

        public Artigo GetArtigo(string titulo)
        {
            return dependency.GetArtigo(titulo);
        }

        public Artigo GetArtigo(int id)
        {
            return dependency.GetArtigo(id);
        }

        public List<Artigo> GetArtigos()
        {
            return dependency.GetArtigos();
        }

        public List<Artigo> GetArtigos(int year)
        {
            return dependency.GetArtigos(year);
        }

        public List<Artigo> GetArtigos(int year, int mes)
        {
            return dependency.GetArtigos(year, mes);
        }

        public List<Artigo> GetArtigosBuscaTexto(string busca)
        {
            return dependency.GetArtigosBuscaTexto(busca);
        }

        public List<Artigo> GetArtigosBuscaTitulo(string busca)
        {
            return dependency.GetArtigosBuscaTitulo(busca);
        }

        public List<Artigo> GetArtigosBuscaTituloETexto(string busca)
        {
            return dependency.GetArtigosBuscaTituloETexto(busca);
        }

        public List<ArtigoTag> GetArtigoTag()
        {
            return dependency.GetArtigoTag();
        }

        public List<ArtigoTag> GetArtigoTagPorArtigo(int idArtigo)
        {
            return dependency.GetArtigoTagPorArtigo(idArtigo);
        }

        public List<ArtigoTag> GetArtigoTagPorTag(int idTag)
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

        public List<Tag> GetTags(string nomeTag)
        {
            return dependency.GetTags(nomeTag);
        }
    }
}
