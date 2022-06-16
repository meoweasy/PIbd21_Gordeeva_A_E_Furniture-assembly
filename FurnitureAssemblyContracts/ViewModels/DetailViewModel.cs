using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FurnitureAssemblyContracts.Attributes;


namespace FurnitureAssemblyContracts.ViewModels
{
    /// <summary>
    /// Деталь, требуемая для изготовления мебели
    /// </summary>
    public class DetailViewModel
    {
        [Column(title: "Номер", width: 100)]
        public int Id { get; set; }

        [Column(title: "Название детали", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string DetailName { get; set; }
    }
}
