using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TestWebapp.Data;

namespace TestWebapp.Models
{
    public class Product : IEntity
    {
        public int Id { get; set; }
        public string Sku { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }
    }
}