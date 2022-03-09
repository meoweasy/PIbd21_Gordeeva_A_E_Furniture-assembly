using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AbstractShopContracts.BindingModels;
using AbstractShopContracts.StoragesContacts;
using AbstractShopContracts.ViewModels;
using AbstractShopContracts.BusinessLogicsContracts;

namespace AbstractShopBusinessLogic.BusinessLogics
{
    public class ProductLogic : IProductLogic
    {
        private readonly IProductStorage _sushiStorage;
        public ProductLogic(IProductStorage sushiStorage)
        {
            _sushiStorage = sushiStorage;
        }
        public List<ProductViewModel> Read(ProductBindingModel model)
        {
            if (model == null)
            {
                return _sushiStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<ProductViewModel> { _sushiStorage.GetElement(model)
};
            }
            return _sushiStorage.GetFilteredList(model);
        }
        public void CreateOrUpdate(ProductBindingModel model)
        {
            var element = _sushiStorage.GetElement(new ProductBindingModel
            {
                ProductName = model.ProductName
            });
            if (element != null && element.Id != model.Id)
            {
                throw new Exception("Уже есть ингредиент с таким названием");
            }
            if (model.Id.HasValue)
            {
                _sushiStorage.Update(model);
            }
            else
            {
                _sushiStorage.Insert(model);
            }
        }
        public void Delete(ProductBindingModel model)
        {
            var element = _sushiStorage.GetElement(new ProductBindingModel
            {
                Id =
           model.Id
            });
            if (element == null)
            {
                throw new Exception("Ингредиент не найден");
            }
            _sushiStorage.Delete(model);
        }
    }
}
