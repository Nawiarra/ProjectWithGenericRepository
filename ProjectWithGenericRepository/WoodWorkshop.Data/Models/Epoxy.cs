using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WoodWorkshop.Data.Models
{
    public class Epoxy
    {
        [Key]
        public int Id { get; set; }
        public string Type { get; set; }
        public string Price { get; set; }
        public virtual ICollection<WoodFurnitureOrder> WoodFurnitureOrders { get; set; }
    }
}
