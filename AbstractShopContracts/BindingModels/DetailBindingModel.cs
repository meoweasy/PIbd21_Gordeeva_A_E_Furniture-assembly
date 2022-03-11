using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractShopContracts.BindingModels
{
    /// <summary>
    /// Деталь, требуемая для изготовления мебели
    /// </summary>
    public class DetailBindingModel
    {
        public int? Id { get; set; }
        public string DetailName { get; set; }
    }
}
