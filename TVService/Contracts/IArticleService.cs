using System;
using System.Collections.Generic;
using System.Text;
using TVCommon.Models;
using TVCommon.ViewModels;

namespace TVService.Contracts
{
    public interface IArticleService
    {
        string Get();
        List<CreateArtigoViewMmodel> GetArtigoPorTag(string tag);
        List<CreateArtigoViewMmodel> GetArtigos();
        CreateArtigoViewMmodel GetArtigo(string titulo);
        CreateArtigoViewMmodel GetArtigo(long id);
        List<CreateArtigoViewMmodel> GetArtigos(int year);
        List<CreateArtigoViewMmodel> GetArtigos(int year, int mes);
        List<CreateArtigoViewMmodel> GetArtigosBuscaTexto(string busca);
        List<CreateArtigoViewMmodel> GetArtigosBuscaTitulo(string busca);
        List<CreateArtigoViewMmodel> GetArtigosBuscaTituloETexto(string busca);
        long CreateArtigo(CreateArtigoViewMmodel obj);
        List<ArtigoTag> GetArtigoTag();
        List<ArtigoTag> GetArtigoTagPorArtigo(long idArtigo);
        List<ArtigoTag> GetArtigoTagPorTag(long idTag);
        long[] CreateArtigoTag(List<ArtigoTag> objs);
        long CreateArtigoTag(ArtigoTag obj);
        List<Autor> GetAutores();
        Autor GetAutor(string nome);
        Autor GetAutor(long id);
        long CreateAutor(Autor obj);
        Imagem GetImagens(long idImagem);
        long[] CreateImagens(List<Imagem> objs);
        List<RedeSocial> GetRedeSociais();
        RedeSocial GetRedeSociais(long idRedeSocial);
        long CreateRedeSocial(RedeSocial obj);
        List<RedeSocialPessoa> GetRedeSociaisPessoa(long idPessoa);
        long[] CreateRedeSociaisPessooa(List<RedeSocialPessoa> objs);
        List<Tag> GetTags();
        long[] CreateTags(List<Tag> objs);
        CreateArtigoViewMmodel GetArtigoNovo(long id);
        List<CreateArtigoViewMmodel> GetArtigosNovo(int maxArtigos = 5);
        //string GetTagPorArtigoId(long artigoId);
    }
}
