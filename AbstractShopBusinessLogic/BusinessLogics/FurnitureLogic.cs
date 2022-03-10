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
        private readonly IFurnitureStorage _furnitureStorage;
        public FurnitureLogic(IFurnitureStorage sushiStorage)
        {
            _furnitureStorage = sushiStorage;
        }
        public List<FurnitureViewModel> Read(FurnitureBindingModel model)
        {
            if (model == null)
            {
                return _furnitureStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<FurnitureViewModel> {_furnitureStorage.GetElement(model)
};
            }
            return _furnitureStorage.GetFilteredList(model);
        }
        public void CreateOrUpdate(FurnitureBindingModel model)
        {
            var element = _furnitureStorage.GetElement(new FurnitureBindingModel
            {
                FurnitureName = model.FurnitureName
            });
            if (element != null && element.Id != model.Id)
            {
                throw new Exception("Уже есть ингредиент с таким названием");
            }
            if (model.Id.HasValue)
            {
                _furnitureStorage.Update(model);
            }
            else
            {
                _furnitureStorage.Insert(model);
            }
        }
        public void Delete(FurnitureBindingModel model)
        {
            var element = _furnitureStorage.GetElement(new FurnitureBindingModel
            {
                Id = model.Id
            });
            if (element == null)
            {
                throw new Exception("Ингредиент не найден");
            }
            _furnitureStorage.Delete(model);
        }
    }
}
