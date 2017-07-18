using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TVCommon.Models
{
    public class RedeSocial
    {
        [Key]
        public long IdRedeSocial { get; set; }
        
        public Imagem Imagem { get; set; }

        [ForeignKey("Imagem")]
        public long IdImagem { get; set; }

        public string Nome { get; set; }
    }
}
