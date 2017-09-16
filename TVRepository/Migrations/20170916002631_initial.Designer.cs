using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using TVRepository;

namespace TVRepository.Migrations
{
    [DbContext(typeof(ArticlesContext))]
    [Migration("20170916002631_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TVCommon.Models.Artigo", b =>
                {
                    b.Property<long>("IdArtigo")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DataPublicacao");

                    b.Property<string>("GitHubCodeURL");

                    b.Property<long>("QuantidadeViews");

                    b.Property<string>("Texto");

                    b.Property<string>("Titulo");

                    b.HasKey("IdArtigo");

                    b.ToTable("Artigos");
                });

            modelBuilder.Entity("TVCommon.Models.ArtigoTag", b =>
                {
                    b.Property<long>("IdArtigoTag");

                    b.Property<long>("IdArtigo");

                    b.Property<long>("IdTag");

                    b.HasKey("IdArtigoTag");

                    b.HasIndex("IdArtigo");

                    b.HasIndex("IdTag");

                    b.ToTable("ArtigoTags");
                });

            modelBuilder.Entity("TVCommon.Models.Autor", b =>
                {
                    b.Property<long>("IdAutor")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Biografia");

                    b.Property<long>("IdImagem");

                    b.Property<string>("Nome");

                    b.HasKey("IdAutor");

                    b.HasIndex("IdImagem");

                    b.ToTable("Autores");
                });

            modelBuilder.Entity("TVCommon.Models.Imagem", b =>
                {
                    b.Property<long>("IdImagem")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Caminho");

                    b.Property<string>("Nome");

                    b.Property<int>("PosicaoEsq");

                    b.Property<int>("PosicaoTop");

                    b.HasKey("IdImagem");

                    b.ToTable("Imagens");
                });

            modelBuilder.Entity("TVCommon.Models.RedeSocial", b =>
                {
                    b.Property<long>("IdRedeSocial")
                        .ValueGeneratedOnAdd();

                    b.Property<long>("IdImagem");

                    b.Property<string>("Nome");

                    b.HasKey("IdRedeSocial");

                    b.HasIndex("IdImagem");

                    b.ToTable("RedeSociais");
                });

            modelBuilder.Entity("TVCommon.Models.RedeSocialPessoa", b =>
                {
                    b.Property<long>("IdRedeSocialPessoa")
                        .ValueGeneratedOnAdd();

                    b.Property<long>("IdPessoa");

                    b.Property<long>("IdRedeSocial");

                    b.Property<string>("Link");

                    b.HasKey("IdRedeSocialPessoa");

                    b.HasIndex("IdPessoa");

                    b.HasIndex("IdRedeSocial");

                    b.ToTable("RedeSocialPessoas");
                });

            modelBuilder.Entity("TVCommon.Models.Tag", b =>
                {
                    b.Property<long>("IdTag")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Nome");

                    b.HasKey("IdTag");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("TVCommon.Models.ArtigoTag", b =>
                {
                    b.HasOne("TVCommon.Models.Artigo", "Artigo")
                        .WithMany()
                        .HasForeignKey("IdArtigo");

                    b.HasOne("TVCommon.Models.Artigo")
                        .WithMany("ArtigoTags")
                        .HasForeignKey("IdArtigoTag");

                    b.HasOne("TVCommon.Models.Tag")
                        .WithMany("ArtigoTags")
                        .HasForeignKey("IdArtigoTag");

                    b.HasOne("TVCommon.Models.Tag", "Tag")
                        .WithMany()
                        .HasForeignKey("IdTag");
                });

            modelBuilder.Entity("TVCommon.Models.Autor", b =>
                {
                    b.HasOne("TVCommon.Models.Imagem", "Imagem")
                        .WithMany()
                        .HasForeignKey("IdImagem");
                });

            modelBuilder.Entity("TVCommon.Models.RedeSocial", b =>
                {
                    b.HasOne("TVCommon.Models.Imagem", "Imagem")
                        .WithMany()
                        .HasForeignKey("IdImagem");
                });

            modelBuilder.Entity("TVCommon.Models.RedeSocialPessoa", b =>
                {
                    b.HasOne("TVCommon.Models.Autor")
                        .WithMany("RedesSociaisPessoa")
                        .HasForeignKey("IdPessoa");

                    b.HasOne("TVCommon.Models.RedeSocial", "RedeSocial")
                        .WithMany()
                        .HasForeignKey("IdRedeSocial");
                });
        }
    }
}
