using System;

namespace automaat.Models
{
    public class OrderMessage
    {
        public string Product { get; set; }
        public int Amount { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
        public String Location { get; set; }
        
    }
}