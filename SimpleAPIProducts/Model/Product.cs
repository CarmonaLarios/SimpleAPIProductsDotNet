using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleAPIProducts
{
    [Table("Products")]
    public class Product
    {
        [Column("pId")]
        public int Id { get; set; }
        
        [Column("pName")]
        public string Name { get; set; }

        [Column("pManufacturer")]
        public string Manufacturer { get; set; }

        [Column("pPrice")]
        public double Price { get; set; }
    }
}
