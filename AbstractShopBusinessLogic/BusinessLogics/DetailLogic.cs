using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AbstractShopContracts.BindingModels;
using AbstractShopContracts.BusinessLogicsContracts;
using AbstractShopContracts.StoragesContacts;
using AbstractShopContracts.ViewModels;


namespace AbstractShopBusinessLogic.BusinessLogics
{
    public class DetailLogic : IDetailLogic
    {
        private readonly IDetailStorage _componentStorage;
        public DetailLogic(IDetailStorage componentStorage)
        {
            _componentStorage = componentStorage;
        }
        public List<DetailViewModel> Read(DetailBindingModel model)
        {
            if (model == null)
            {
                return _componentStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<DetailViewModel> { _componentStorage.GetElement(model)
};
            }
            return _componentStorage.GetFilteredList(model);
        }
        public void CreateOrUpdate(DetailBindingModel model)
        {
            var element = _componentStorage.GetElement(new DetailBindingModel
            {
                DetailName = model.DetailName
            });
            if (element != null && element.Id != model.Id)
            {
                throw new Exception("Уже есть компонент с таким названием");
            }
            if (model.Id.HasValue)
            {
                _componentStorage.Update(model);
            }
            else
            {
                _componentStorage.Insert(model);
            }
        }
        public void Delete(DetailBindingModel model)
        {
            var element = _componentStorage.GetElement(new DetailBindingModel
            {
                Id =
           model.Id
            });
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            _componentStorage.Delete(model);
        }
    }
}
