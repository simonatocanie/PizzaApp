﻿using System.ComponentModel.DataAnnotations;

namespace PizzaApp.Domain
{
    public class Ingredient
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        public List<Product>? Products { get; set; } = [];
    }
}
