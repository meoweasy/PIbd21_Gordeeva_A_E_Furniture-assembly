using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AbstractShopContracts.BindingModels;
using AbstractShopContracts.BusinessLogicsContracts;
using AbstractShopContracts.StoragesContacts;
using AbstractShopContracts.ViewModels;
using AbstractShopContracts.Enums;

namespace AbstractShopBusinessLogic.BusinessLogics
{
    public class OrderLogic : IOrderLogic
    {
        private readonly IOrderStorage _orderStorage;
        public OrderLogic(IOrderStorage orderStorage)
        {
            _orderStorage = orderStorage;
        }

        public List<OrderViewModel> Read(OrderBindingModel model)
        {
            if (model == null)
            {
                return _orderStorage.GetFullList();
            }
            return _orderStorage.GetFilteredList(model);
        }

        public void UpdateStatus(OrderBindingModel model)
        {
            var element = _orderStorage.GetElement(new OrderBindingModel
            {
                Id = model.Id
            });

            if (element.Id == model.Id && element.Status == "Принят")
            {
                model.Status = OrderStatus.Выполняется;
            }

            if (element.Id == model.Id && element.Status == "Выполняется")
            {
                model.Status = OrderStatus.Готов;
            }

            if (element.Id == model.Id && element.Status == "Готов")
            {
                model.Status = OrderStatus.Выдан;
            }
        }

        public void CreateOrder(CreateOrderBindingModel model)
        {
            var element = _orderStorage.GetElement(new OrderBindingModel
            {
                Count = model.Count,
                Sum = model.Sum
            });
            if (element != null)
            {
                throw new Exception("Уже есть такой заказ");
            }
            else
            {
                _orderStorage.Insert();
            }

        }
    }
}
