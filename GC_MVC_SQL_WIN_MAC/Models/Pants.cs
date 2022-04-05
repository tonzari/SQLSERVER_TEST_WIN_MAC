using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GC_MVC_SQL_WIN_MAC.Models
{
    public enum Size
    {
        S, M, L, XL, XXL
    }
    public class Pants
    {
        public int ID { get; set; }
        public int Length { get; set; }
        public int Waist { get; set; }
        public Size? Size { get; set; } // Nullable. Just testing out how this is handled by EF.
        public string Brand { get; set; }
        public string ProductName { get; set; }
        public string Color { get; set; }
        public double Price { get; set; }
    }
}