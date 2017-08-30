using System;
using System.Collections.Generic;
using System.Text;
using TVCommon.Models;

namespace TVRepository.Interface
{
    public interface IArticlesDAL
    {

        List<Artigo> GetArtigos();
        Artigo GetArtigo(string titulo);
        Artigo GetArtigo(long id);
        List<Artigo> GetArtigos(int year);
        List<Artigo> GetArtigos(int year, int mes);
        List<Artigo> GetArtigosBuscaTexto(string busca);
        List<Artigo> GetArtigosBuscaTitulo(string busca);
        List<Artigo> GetArtigosBuscaTituloETexto(string busca);
        long CreateArtigo(Artigo obj);
        List<ArtigoTag> GetArtigoTag();
        List<ArtigoTag> GetArtigoTagPorArtigo(long idArtigo);
        List<ArtigoTag> GetArtigoTagPorTag(long idTag);
        List<ArtigoTag> GetArtigoTagPorTag(string tag);
        List<Artigo> GetArtigoPorArtigoTagId(List<long> lstArtigoTagId);
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
        Tag GetTag(string nomeTag);
        Tag GetTag(long idTag);
        long[] CreateTags(List<Tag> objs);

    }
}
