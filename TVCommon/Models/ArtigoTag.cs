using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TVCommon.Models
{
    public class ArtigoTag
    {
        public Artigo Artigo { get; set; }

        public long IdArtigo { get; set; }

        [Key]
        public long IdArtigoTag { get; set; }

        public long IdTag { get; set; }

        public Tag Tag { get; set; }
    }
}
