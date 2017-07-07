using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TVCommon.Models
{
    public class Imagem
    {
        public Artigo Artigo { get; set; }

        public string Caminho { get; set; }

        [Key]
        public long IdImagem { get; set; }

        public string Nome { get; set; }

        public int PosicaoEsq { get; set; }

        public int PosicaoTop { get; set; }

        [ForeignKey("Artigo")]
        public long IdArtigo { get; set; }
    }
}
