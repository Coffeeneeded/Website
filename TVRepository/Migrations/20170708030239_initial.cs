using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TVRepository.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Artigos",
                columns: table => new
                {
                    IdArtigo = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DataPublicacao = table.Column<DateTime>(nullable: false),
                    GitHubCodeURL = table.Column<string>(nullable: true),
                    QuantidadeViews = table.Column<long>(nullable: false),
                    Texto = table.Column<string>(nullable: true),
                    Titulo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artigos", x => x.IdArtigo);
                });

            migrationBuilder.CreateTable(
                name: "Autores",
                columns: table => new
                {
                    IdAutor = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Biografia = table.Column<string>(nullable: true),
                    Nome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Autores", x => x.IdAutor);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    IdTag = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.IdTag);
                });

            migrationBuilder.CreateTable(
                name: "Imagens",
                columns: table => new
                {
                    IdImagem = table.Column<long>(nullable: false),
                    Caminho = table.Column<string>(nullable: true),
                    IdArtigo = table.Column<long>(nullable: false),
                    Nome = table.Column<string>(nullable: true),
                    PosicaoEsq = table.Column<int>(nullable: false),
                    PosicaoTop = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Imagens", x => x.IdImagem);
                    table.ForeignKey(
                        name: "FK_Imagens_Artigos_IdArtigo",
                        column: x => x.IdArtigo,
                        principalTable: "Artigos",
                        principalColumn: "IdArtigo",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Imagens_Artigos_IdImagem",
                        column: x => x.IdImagem,
                        principalTable: "Artigos",
                        principalColumn: "IdArtigo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ArtigoTags",
                columns: table => new
                {
                    IdArtigoTag = table.Column<long>(nullable: false),
                    IdArtigo = table.Column<long>(nullable: false),
                    IdTag = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArtigoTags", x => x.IdArtigoTag);
                    table.ForeignKey(
                        name: "FK_ArtigoTags_Artigos_IdArtigo",
                        column: x => x.IdArtigo,
                        principalTable: "Artigos",
                        principalColumn: "IdArtigo",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ArtigoTags_Artigos_IdArtigoTag",
                        column: x => x.IdArtigoTag,
                        principalTable: "Artigos",
                        principalColumn: "IdArtigo",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ArtigoTags_Tags_IdArtigoTag",
                        column: x => x.IdArtigoTag,
                        principalTable: "Tags",
                        principalColumn: "IdTag",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ArtigoTags_Tags_IdTag",
                        column: x => x.IdTag,
                        principalTable: "Tags",
                        principalColumn: "IdTag",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RedeSociais",
                columns: table => new
                {
                    IdRedeSocial = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdImagem = table.Column<long>(nullable: false),
                    Nome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RedeSociais", x => x.IdRedeSocial);
                    table.ForeignKey(
                        name: "FK_RedeSociais_Imagens_IdImagem",
                        column: x => x.IdImagem,
                        principalTable: "Imagens",
                        principalColumn: "IdImagem",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RedeSocialPessoas",
                columns: table => new
                {
                    IdRedeSocialPessoa = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdPessoa = table.Column<long>(nullable: false),
                    IdRedeSocial = table.Column<long>(nullable: false),
                    Link = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RedeSocialPessoas", x => x.IdRedeSocialPessoa);
                    table.ForeignKey(
                        name: "FK_RedeSocialPessoas_Autores_IdPessoa",
                        column: x => x.IdPessoa,
                        principalTable: "Autores",
                        principalColumn: "IdAutor",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RedeSocialPessoas_RedeSociais_IdRedeSocial",
                        column: x => x.IdRedeSocial,
                        principalTable: "RedeSociais",
                        principalColumn: "IdRedeSocial",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArtigoTags_IdArtigo",
                table: "ArtigoTags",
                column: "IdArtigo");

            migrationBuilder.CreateIndex(
                name: "IX_ArtigoTags_IdTag",
                table: "ArtigoTags",
                column: "IdTag");

            migrationBuilder.CreateIndex(
                name: "IX_Imagens_IdArtigo",
                table: "Imagens",
                column: "IdArtigo");

            migrationBuilder.CreateIndex(
                name: "IX_RedeSociais_IdImagem",
                table: "RedeSociais",
                column: "IdImagem");

            migrationBuilder.CreateIndex(
                name: "IX_RedeSocialPessoas_IdPessoa",
                table: "RedeSocialPessoas",
                column: "IdPessoa");

            migrationBuilder.CreateIndex(
                name: "IX_RedeSocialPessoas_IdRedeSocial",
                table: "RedeSocialPessoas",
                column: "IdRedeSocial");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArtigoTags");

            migrationBuilder.DropTable(
                name: "RedeSocialPessoas");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "Autores");

            migrationBuilder.DropTable(
                name: "RedeSociais");

            migrationBuilder.DropTable(
                name: "Imagens");

            migrationBuilder.DropTable(
                name: "Artigos");
        }
    }
}
