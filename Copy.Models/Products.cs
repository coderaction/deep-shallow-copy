using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Copy.Models
{
    [Serializable]
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
        
        public Products DeepCopy()
        {
            using (var memoryStream = new MemoryStream())
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(memoryStream, this);
                memoryStream.Position = 0;

                return (Products)formatter.Deserialize(memoryStream);
            }
        }

    }
}