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
        public string BookTitle { get; set; }
        [Required]
        public string RPGSystem { get; set; }
        [Required]
        public BookType BookType { get; set; }
    }
}
