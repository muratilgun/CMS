using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Models
{
    public class Page:BaseEntity
    {
        [Required]
        [MinLength(2, ErrorMessage ="Mininmum lenght is 2")]
        public string Title { get; set; }
        public string Slug { get; set; }

        [Required]
        [MinLength(4, ErrorMessage = "Mininmum lenght is 4")]
        public string Content { get; set; }

        public int Sorting { get; set; }
    }
}
