using BoardGameInventory.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameInventory.Models.RPGBookModels
{
    public class RPGBookEdit
    {
        [Required]
        public int BookID { get; set; }
        [Required]
        [Display(Name = "Book Title")]
        public string BookTitle { get; set; }
        [Required]
        [Display(Name = "RPG System")]
        public string RPGSystem { get; set; }
        [Required]
        [Display(Name = "Book Type")]
        public BookType BookType { get; set; }
    }
}
