using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TVCommon.Models
{
    public class Artigo
    {
        public DateTime DataPublicacao { get; set; }

        public string GitHubCodeURL { get; set; }

        [Key]
        public long IdArtigo { get; set; }

        public long QuantidadeViews { get; set; }

        public ICollection<Tag> Tags { get; set; }

        public ICollection<Imagem> Imagens { get; set; }

        public string Texto { get; set; }

        public string Titulo { get; set; }

        public ArtigoTag ArtigoTag { get; set; }
    }
}
