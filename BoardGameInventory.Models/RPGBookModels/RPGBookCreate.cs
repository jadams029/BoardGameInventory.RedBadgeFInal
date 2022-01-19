using BoardGameInventory.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameInventory.Models.RPGBookModels
{
    public class RPGBookCreate
    {        
        [Required]
        public string BookTitle { get; set; }
        [Required]
        public string RPGSystem { get; set; }
        [Required]
        public BookType BookType { get; set; }
    }
}
