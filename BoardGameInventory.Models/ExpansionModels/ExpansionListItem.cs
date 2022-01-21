using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameInventory.Models.ExpansionModels
{
    public class ExpansionListItem 
    {
        [Display(Name = "Expansion ID #")]
        public int ExpansionID { get; set; }       
        [Display(Name = "Expansion Title")]
        public string ExpansionTitle { get; set; }        
    }
}
 