using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameInventory.Data
{
    public enum BookType { Core = 1, Supplement, Campaign, Adventure, }
    public class RPGBook
    {
        [Key]
        public int BookID { get; set; }
        [Required]
        public Guid OwnerID { get; set; }
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
