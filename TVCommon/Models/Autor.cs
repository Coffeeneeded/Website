using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TVCommon.Models
{
    public class Autor
    {
        [Key]
        public long IdAutor { get; set; }
        
        public string Nome { get; set; }
        
        public ICollection<RedeSocialPessoa> RedesSociaisPessoa { get; set; }

        public string Biografia { get; set; }
    }
}
