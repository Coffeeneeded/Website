using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TVCommon.Models
{
    public class ArtigoTag
    {
        public Artigo Artigo { get; set; }

        [ForeignKey("Artigo")]
        public long IdArtigo { get; set; }

        [Key]
        public long IdArtigoTag { get; set; }

        [ForeignKey("Tag")]
        public long IdTag { get; set; }

        public Tag Tag { get; set; }
    }
}
