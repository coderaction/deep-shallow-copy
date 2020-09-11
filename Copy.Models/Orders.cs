using System;

namespace Copy.Models
{
    [Serializable]
    public class Orders
    {
        public int Id { get; set; }
        public int UnitPrice { get; set; }
        public int Discount { get; set; }
        public int Quantity { get; set; }
    }
}