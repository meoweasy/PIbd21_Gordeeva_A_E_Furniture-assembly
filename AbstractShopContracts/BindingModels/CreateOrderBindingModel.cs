using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractShopContracts.BindingModels
{
    /// <summary>
    /// Данные от клиента, для создания заказа
    /// </summary>
    public class CreateOrderBindingModel
    {
        public int FurnitureId { get; set; }
        public string FurnitureName { get; set; }
        public int Count { get; set; }
        public decimal Sum { get; set; }
    }
}
