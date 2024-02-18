using System;
using System.ComponentModel.DataAnnotations;

namespace Market.Models
{
    public class Store
    {
        [Key] public int Id { get; set; }
        public int Count { get; set; }
        public virtual ICollection<Product> Products { get; set; } = new List<Product>();
    }
}

