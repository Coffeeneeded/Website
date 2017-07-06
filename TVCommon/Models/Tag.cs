using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TVCommon.Models
{
    public class Tag
    {
        public ICollection<Artigo> Artigos { get; set; }

        [Key]
        public long IdTag { get; set; }

        public string Nome { get; set; }
        public ArtigoTag ArtigoTag { get; set; }
    }
}
