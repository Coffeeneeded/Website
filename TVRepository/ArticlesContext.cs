using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TVCommon.Models;

namespace TVRepository
{
    public class ArticlesContext : DbContext
    {

        public ArticlesContext(DbContextOptions<ArticlesContext> options) : base(options)
        {

        }
        public DbSet<Artigo> Artigos { get; set; }

        public DbSet<ArtigoTag> ArtigoTags { get; set; }

        public DbSet<Autor> Autores { get; set; }

        public DbSet<Imagem> Imagens { get; set; }

        public DbSet<RedeSocial> RedeSociais { get; set; }

        public DbSet<RedeSocialPessoa> RedeSocialPessoas { get; set; }

        public DbSet<Tag> Tags { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Artigo>()
                .HasMany(x => (ICollection<ArtigoTag>)x.ArtigoTags)
                .WithOne()
                .HasForeignKey(x => x.IdArtigoTag);

            modelBuilder.Entity<Tag>()
                .HasMany(x => (ICollection<ArtigoTag>)x.ArtigoTags)
                .WithOne()
                .HasForeignKey(x => x.IdArtigoTag);

            modelBuilder.Entity<Artigo>()
                .HasMany(x => (ICollection<Imagem>)x.Imagens)
                .WithOne()
                .HasForeignKey(x => x.IdImagem);

            modelBuilder.Entity<Autor>()
                .HasMany(x => (ICollection<RedeSocialPessoa>)x.RedesSociaisPessoa)
                .WithOne()
                .HasForeignKey(x => x.IdPessoa);


            foreach (var relation in modelBuilder.Model.GetEntityTypes().SelectMany(x => x.GetForeignKeys()))
            {
                relation.DeleteBehavior = Microsoft.EntityFrameworkCore.Metadata.DeleteBehavior.Restrict;
            }

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            base.OnConfiguring(optionsBuilder);
        }
    }
}
