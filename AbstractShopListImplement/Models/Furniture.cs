﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractShopListImplement.Models
{
    /// <summary>
    /// Мебель, изготавливаемая в магазине
    /// </summary>
    public class Furniture
    {
        public int Id { get; set; }
        public string FurnitureName { get; set; }
        public decimal Price { get; set; }
        public Dictionary<int, int> FurnitureDetails { get; set; }
    }
}
