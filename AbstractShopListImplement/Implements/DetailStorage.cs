using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AbstractShopContracts.BindingModels;
using AbstractShopContracts.StoragesContacts;
using AbstractShopContracts.ViewModels;
using AbstractShopListImplement.Models;


namespace AbstractShopListImplement.Implements
{
    public class DetailStorage : IDetailStorage
    {
        private readonly DataListSingleton source;
        public DetailStorage()
        {
            source = DataListSingleton.GetInstance();
        }
        public List<DetailViewModel> GetFullList()
        {
            var result = new List<DetailViewModel>();
            foreach (var component in source.Components)
            {
                result.Add(CreateModel(component));
            }
            return result;
        }
        public List<DetailViewModel> GetFilteredList(DetailBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            var result = new List<DetailViewModel>();
            foreach (var component in source.Components)
            {
                if (component.DetailName.Contains(model.DetailName))
                {
                    result.Add(CreateModel(component));
                }
            }
            return result;
        }
        public DetailViewModel GetElement(DetailBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            foreach (var component in source.Components)
            {
                if (component.Id == model.Id || component.DetailName ==
               model.DetailName)
                {
                    return CreateModel(component);
                }
            }
            return null;
        }
        public void Insert(DetailBindingModel model)
        {
            var tempComponent = new Detail { Id = 1 };
            foreach (var component in source.Components)
            {
                if (component.Id >= tempComponent.Id)
                {
                    tempComponent.Id = component.Id + 1;
                }
            }
            source.Components.Add(CreateModel(model, tempComponent));
        }
        public void Update(DetailBindingModel model)
        {
            Detail tempComponent = null;
            foreach (var component in source.Components)
            {
                if (component.Id == model.Id)
                {
                    tempComponent = component;
                }
            }
            if (tempComponent == null)
            {
                throw new Exception("Элемент не найден");
            }
            CreateModel(model, tempComponent);
        }
        public void Delete(DetailBindingModel model)
        {
            for (int i = 0; i < source.Components.Count; ++i)
            {
                if (source.Components[i].Id == model.Id.Value)
                {
                    source.Components.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Элемент не найден");
        }
        private static Detail CreateModel(DetailBindingModel model, Detail
component)
        {
            component.DetailName = model.DetailName;
            return component;
        }
        private static DetailViewModel CreateModel(Detail component)
        {
            return new DetailViewModel
            {
                Id = component.Id,
                DetailName = component.DetailName
            };
        }
    }
}