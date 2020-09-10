using System;

namespace Copy.Models
{
    public class Products    
    {
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public bool Discontinued { get; set; }
        public int UnitInStock { get; set; }
        
        public Categories Categories { get; set; }
        public Orders Orders { get; set; }

        public Products ShallowCopy()
        {
            return (Products) MemberwiseClone();
        }
    }
}