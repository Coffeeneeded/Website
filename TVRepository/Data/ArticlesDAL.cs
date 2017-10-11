using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TVCommon.Models;
using TVRepository.Interface;

namespace TVRepository.Data
{
    public class ArticlesDAL : IArticlesDAL
    {
        private ArticlesContext _dependency;
        public ArticlesDAL(ArticlesContext dependecy)
        {
            this._dependency = dependecy;
        }


        #region Artigo

        #region Busca

        public List<Artigo> GetArtigos()
        {
            List<Artigo> retorno = new List<Artigo>();

            try
            {
                retorno = this._dependency.Artigos.ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return retorno;
        }
        public List<long> GetArtigosId(int maxArticles = 5)
        {
            List<long> retorno = new List<long>();

            try
            {
                retorno = this._dependency.Artigos.OrderByDescending(x => x.IdArtigo).Select(x => x.IdArtigo).Take(maxArticles).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return retorno;
        }
        public Artigo GetArtigo(string titulo)
        {
            Artigo retorno = new Artigo();

            try
            {
                retorno = this._dependency.Artigos.FirstOrDefault(x => x.Titulo.Trim() == titulo.Trim());
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return retorno;
        }

        public List<Artigo> GetArtigoPorArtigoTagId(List<long> lstArtigoTagId)
        {
            List<Artigo> retorno = new List<Artigo>();

            try
            {
                retorno = this._dependency.ArtigoTags.Where(x => lstArtigoTagId.Contains(x.IdArtigoTag)).Select(x => x.Artigo).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return retorno;
        }
        public Artigo GetArtigo(long id)
        {
            Artigo retorno = new Artigo();

            try
            {
                retorno = this._dependency.Artigos.FirstOrDefault(x => x.IdArtigo == id);
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return retorno;
        }
        public List<Artigo> GetArtigos(int year)
        {
            List<Artigo> retorno = new List<Artigo>();

            try
            {
                retorno = this._dependency.Artigos.Where(x => x.DataPublicacao.Year == year).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return retorno;
        }
        public List<Artigo> GetArtigos(int year, int mes)
        {
            List<Artigo> retorno = new List<Artigo>();

            try
            {
                retorno = this._dependency.Artigos.Where(x => x.DataPublicacao.Month == mes && x.DataPublicacao.Year == year).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return retorno;
        }
        public List<Artigo> GetArtigosBuscaTexto(string busca)
        {
            List<Artigo> retorno = new List<Artigo>();

            try
            {
                retorno = this._dependency.Artigos.Where(x => x.Texto.Contains(busca)).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return retorno;
        }
        public List<Artigo> GetArtigosBuscaTitulo(string busca)
        {
            List<Artigo> retorno = new List<Artigo>();

            try
            {
                retorno = this._dependency.Artigos.Where(x => x.Titulo.Contains(busca)).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return retorno;
        }
        public List<Artigo> GetArtigosBuscaTituloETexto(string busca)
        {
            List<Artigo> retorno = new List<Artigo>();

            try
            {
                retorno = this._dependency.Artigos.Where(x => x.Titulo.Contains(busca)
                || x.Texto.Contains(busca)).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return retorno;
        }

        #endregion

        #region Criacao

        public long CreateArtigo(Artigo obj)
        {
            long retorno = 0;

            try
            {
                this._dependency.Artigos.Add(obj);
                retorno = obj.IdArtigo;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return retorno;
        }

        #endregion

        #endregion

        #region ArtigoTag

        #region Busca

        public List<ArtigoTag> GetArtigoTag()
        {
            List<ArtigoTag> retorno = new List<ArtigoTag>();

            try
            {
                retorno = this._dependency.ArtigoTags.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }


            return retorno;
        }
        public List<ArtigoTag> GetArtigoTagPorArtigo(long idArtigo)
        {
            List<ArtigoTag> retorno = new List<ArtigoTag>();

            try
            {
                retorno = this._dependency.ArtigoTags.Where(x => x.IdArtigo == idArtigo).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }


            return retorno;
        }
        public List<ArtigoTag> GetArtigoTagPorTag(long idTag)
        {
            List<ArtigoTag> retorno = new List<ArtigoTag>();

            try
            {
                retorno = this._dependency.ArtigoTags.Where(x => x.IdTag == idTag).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }


            return retorno;
        }
        public List<ArtigoTag> GetArtigoTagPorTag(string tag)
        {
            List<ArtigoTag> retorno = new List<ArtigoTag>();

            try
            {
                retorno = this._dependency.ArtigoTags.Where(x => x.Tag.Nome == tag).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }


            return retorno;
        }

        #endregion

        #region Criacao

        public long[] CreateArtigoTag(List<ArtigoTag> objs)
        {
            long[] retorno = new long[objs.Count];

            try
            {
                int counter = 0;
                foreach (ArtigoTag obj in objs)
                {
                    this._dependency.ArtigoTags.Add(obj);
                    retorno[counter] = obj.IdArtigoTag;
                    counter++;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return retorno;
        }

        public long CreateArtigoTag(ArtigoTag obj)
        {
            long retorno = 0;

            try
            {
                this._dependency.ArtigoTags.Add(obj);
                retorno = obj.IdArtigoTag;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return retorno;
        }

        #endregion


        #endregion

        #region Autor

        #region Busca

        public List<Autor> GetAutores()
        {
            List<Autor> retorno = new List<Autor>();

            try
            {
                retorno = this._dependency.Autores.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return retorno;
        }

        public Autor GetAutor(string nome)
        {
            Autor retorno = new Autor();

            try
            {
                retorno = this._dependency.Autores.FirstOrDefault(x => x.Nome.Trim() == nome.Trim());
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return retorno;
        }

        public Autor GetAutor(long id)
        {
            Autor retorno = new Autor();

            try
            {
                retorno = this._dependency.Autores.FirstOrDefault(x => x.IdAutor == id);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return retorno;
        }

        #endregion

        #region Criacao

        public long CreateAutor(Autor obj)
        {
            long retorno = 0;

            try
            {
                this._dependency.Add(obj);
                retorno = obj.IdAutor;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return retorno;
        }

        #endregion

        #endregion

        #region Imagem

        #region Busca



        public Imagem GetImagens(long idImagem)
        {
            Imagem retorno = new Imagem();

            try
            {
                this._dependency.Imagens.FirstOrDefault(x => x.IdImagem == idImagem);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return retorno;
        }

        #endregion

        #region Criacao

        public long[] CreateImagens(List<Imagem> objs)
        {
            long[] retorno = new long[objs.Count];

            try
            {
                int counter = 0;
                foreach (Imagem obj in objs)
                {
                    this._dependency.Imagens.Add(obj);
                    retorno[counter] = obj.IdImagem;

                    counter++;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return retorno;
        }

        #endregion

        #endregion

        #region RedeSocial

        #region Busca

        public List<RedeSocial> GetRedeSociais()
        {
            List<RedeSocial> retorno = new List<RedeSocial>();

            try
            {
                retorno = this._dependency.RedeSociais.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return retorno;
        }
        public RedeSocial GetRedeSociais(long idRedeSocial)
        {
            RedeSocial retorno = new RedeSocial();

            try
            {
                retorno = this._dependency.RedeSociais.FirstOrDefault(x => x.IdRedeSocial == idRedeSocial);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return retorno;
        }

        #endregion

        #region Criacao

        public long CreateRedeSocial(RedeSocial obj)
        {
            long retorno = 0;

            try
            {
                this._dependency.RedeSociais.Add(obj);
                retorno = obj.IdRedeSocial;
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return retorno;
        }

        #endregion

        #endregion

        #region RedeSocialPessoa

        #region Busca

        public List<RedeSocialPessoa> GetRedeSociaisPessoa(long idPessoa)
        {
            List<RedeSocialPessoa> retorno = new List<RedeSocialPessoa>();

            try
            {
                retorno = this._dependency.RedeSocialPessoas.Where(x => x.IdPessoa == idPessoa).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return retorno;
        }

        #endregion

        #region Criacao

        public long[] CreateRedeSociaisPessooa(List<RedeSocialPessoa> objs)
        {
            long[] retorno = new long[objs.Count];
            long counter = 0;

            try
            {
                foreach (RedeSocialPessoa obj in objs)
                {
                    this._dependency.RedeSocialPessoas.Add(obj);
                    retorno[counter] = obj.IdRedeSocialPessoa;
                    counter++;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return retorno;
        }

        #endregion

        #endregion

        #region Tag

        #region Busca

        public List<Tag> GetTags()
        {
            List<Tag> retorno = new List<Tag>();

            try
            {
                retorno = this._dependency.Tags.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return retorno;
        }
        public Tag GetTag(string nomeTag)
        {
            Tag retorno = new Tag();

            try
            {
                retorno = this._dependency.Tags.FirstOrDefault(x => x.Nome == nomeTag);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return retorno;
        }

        public Tag GetTag(long idTag)
        {
            Tag retorno = new Tag();
            try
            {
                retorno = this._dependency.Tags.FirstOrDefault(x => x.IdTag == idTag);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return retorno;
        }

        #endregion

        #region Criacao

        public long[] CreateTags(List<Tag> objs)
        {
            long[] retorno = new long[objs.Count];
            long counter = 0;
            try
            {
                foreach (Tag obj in objs)
                {
                    this._dependency.Tags.Add(obj);
                    retorno[counter] = obj.IdTag;
                    counter++;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return retorno;
        }



        #endregion

        #endregion

    }
}
