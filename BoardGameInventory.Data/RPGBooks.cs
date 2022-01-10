using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameInventory.Data
{
    public enum BookType { Core = 1, Supplement, Campaign, Adventure, }
    public class RPGBooks
    {
        public int BookID { get; set; }
        public string RPGSystem { get; set; }
        public string BookTitle { get; set; }
        public BookType BookType { get; set; }

    }
}
