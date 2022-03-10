using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractShopContracts.BindingModels
{
    /// <summary>
    /// Изделие, изготавливаемое в магазине
    /// </summary>
    public class FurnitureBindingModel
    {
        public int? Id { get; set; }
        public string FurnitureName { get; set; }
        public decimal Price { get; set; }
        public Dictionary<int, (string, int)> FurnitureDetails { get; set; }
    }
}
