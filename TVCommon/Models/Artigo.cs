using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

       
        [DataType(DataType.MultilineText)]
        public string Texto { get; set; }

        public string Titulo { get; set; }

        public ICollection<ArtigoTag> ArtigoTags { get; set; }
        
    }
}
