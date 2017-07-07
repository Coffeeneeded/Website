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
        private readonly ArticlesContext _dependency;
        public ArticlesDAL(ArticlesContext dependecy)
        {
            this._dependency = dependecy;
        }

        public string get()
        {
            return this._dependency.Autores.FirstOrDefault().Biografia;
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
        public Artigo GetArtigo(int id)
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
        public List<ArtigoTag> GetArtigoTagPorArtigo(int idArtigo)
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
        public List<ArtigoTag> GetArtigoTagPorTag(int idTag)
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

        public List<Imagem> GetImagensPorArtigo(long idArtigo)
        {
            List<Imagem> retorno = new List<Imagem>();

            try
            {
                retorno = this._dependency.Imagens.Where(x => x.IdArtigo == idArtigo).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return retorno;
        }

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

        #endregion

        #region Criacao

        #endregion

        #endregion

        #region RedeSocialPessoa

        #region Busca

        #endregion

        #region Criacao

        #endregion

        #endregion

        #region Tag

        #region Busca

        #endregion

        #region Criacao

        #endregion

        #endregion

    }
}
