using BoardGameInventory.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameInventory.Models.RPGBookModels
{
    public class RPGBookDetail
    {
        public int BookID { get; set; }
        public string BookTitle { get; set; }
        public string RPGSystem { get; set; }
        public BookType BookType { get; set; }
    }
}
