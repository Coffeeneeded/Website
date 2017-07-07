using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TVCommon.Models
{
    public class Tag
    {
        [Key]
        public long IdTag { get; set; }

        public string Nome { get; set; }
        public ICollection<ArtigoTag> ArtigoTags { get; set; }
    }
}
