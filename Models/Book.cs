using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace mvc_project.Models
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        [DefaultValue("Unknown")]
        public string Author { get; set; }

        public DateTime ReleaseDate { get; set; }

        [Required]
        [DefaultValue(69)]
        [Range(1, 100, ErrorMessage = "Display Order must be between 1-100")]
        [DisplayName("Display Order")]
        public int DisplayOrder { get; set; }
        // TODO:  define this to have a default value.  maybe go as far as to defaulting to the greatest existing value +1
    }
}