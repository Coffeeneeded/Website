using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TVCommon.Models
{
    public class RedeSocialPessoa
    {
        public long IdRedeSocial { get; set; }

        [Key]
        public long IdRedeSocialPessoa { get; set; }

        public string Link { get; set; }

        public long IdPessoa { get; set; }

        public RedeSocial RedeSocial { get; set; }
    }
}
