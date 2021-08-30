using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EAP_Music_Tên_Tuấn.Models
{
    public class Album
    {
        public int AlbumId { get; set; }
        [Required, StringLength(maximumLength: 32, MinimumLength = 3,
            ErrorMessage = "String length must be between 3 - 32 characters")]
        public string Title { get; set; }
        [Required, DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}",
            ApplyFormatInEditMode = true)]
        [System.ComponentModel.DataAnnotations.Schema.Column(TypeName = "DateTime2")]
        public DateTime ReleaseDate { get; set; }
        [Required]
        public string Artist { get; set; }
        [Required, Range(1, 15, ErrorMessage = "Price should be between 1 and 15$")]
        public double Price { get; set; }
        public int GenreId { get; set; }
        public virtual Genre Genre { get; set; }
    }
}