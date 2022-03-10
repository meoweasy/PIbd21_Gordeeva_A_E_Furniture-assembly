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
    public class FurnitureLogic : IFurnitureLogic
    {
        private readonly IFurnitureStorage _sushiStorage;
        public FurnitureLogic(IFurnitureStorage sushiStorage)
        {
            _sushiStorage = sushiStorage;
        }
        public List<FurnitureViewModel> Read(FurnitureBindingModel model)
        {
            if (model == null)
            {
                return _sushiStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<FurnitureViewModel> { _sushiStorage.GetElement(model)
};
            }
            return _sushiStorage.GetFilteredList(model);
        }
        public void CreateOrUpdate(FurnitureBindingModel model)
        {
            var element = _sushiStorage.GetElement(new FurnitureBindingModel
            {
                FurnitureName = model.FurnitureName
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
        public void Delete(FurnitureBindingModel model)
        {
            var element = _sushiStorage.GetElement(new FurnitureBindingModel
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
