using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameInventory.Models.RPGBookModels
{
    public class RPGBookListItem
    {
        [Display(Name = "Book ID #")]
        public int BookID { get; set; }
        [Display(Name = "Book Title")]
        public string BookTitle { get; set; }
    }
}
