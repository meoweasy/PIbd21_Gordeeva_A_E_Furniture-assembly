using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using FurnitureAssemblyContracts.Attributes;

namespace FurnitureAssemblyContracts.ViewModels
{
    /// <summary>
    /// Мебель, изготавливаемая в магазине
    /// </summary>
    public class FurnitureViewModel
    {
        [Column(title: "Номер", width: 100)]
        public int Id { get; set; }

        [Column(title: "Название изделия")]
        public string FurnitureName { get; set; }

        [Column(title: "Цена", width: 50)]
        public decimal Price { get; set; }

        public Dictionary<int, (string, int)> FurnitureDetails { get; set; }
        public string GetComponents()
        {
            string stringComponents = string.Empty;
            if (FurnitureDetails != null)
            {
                foreach (var component in FurnitureDetails)
                {
                    stringComponents += component.Value.Item1 + " = " + component.Value.Item2 + " шт.; ";
                }
            }
            return stringComponents;
        }
    }
}
