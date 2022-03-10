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
    public class FurnitureStorage : IFurnitureStorage
    {
        private readonly DataListSingleton source;
        public FurnitureStorage()
        {
            source = DataListSingleton.GetInstance();
        }
        public List<FurnitureViewModel> GetFullList()
        {
            var result = new List<FurnitureViewModel>();
            foreach (var component in source.Products)
            {
                result.Add(CreateModel(component));
            }
            return result;
        }
        public List<FurnitureViewModel> GetFilteredList(FurnitureBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            var result = new List<FurnitureViewModel>();
            foreach (var product in source.Products)
            {
                if (product.FurnitureName.Contains(model.FurnitureName))
                {
                    result.Add(CreateModel(product));
                }
            }
            return result;
        }
        public FurnitureViewModel GetElement(FurnitureBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            foreach (var product in source.Products)
            {
                if (product.Id == model.Id || product.FurnitureName ==
                model.FurnitureName)
                {
                    return CreateModel(product);
                }
            }
            return null;
        }
        public void Insert(FurnitureBindingModel model)
        {
            var tempProduct = new Furniture
            {
                Id = 1,
                FurnitureDetails = new
            Dictionary<int, int>()
            };
            foreach (var product in source.Products)
            {
                if (product.Id >= tempProduct.Id)
                {
                    tempProduct.Id = product.Id + 1;
                }
            }
            source.Products.Add(CreateModel(model, tempProduct));
        }
        public void Update(FurnitureBindingModel model)
        {
            Furniture tempProduct = null;
            foreach (var product in source.Products)
            {
                if (product.Id == model.Id)
                {
                    tempProduct = product;
                }
            }
            if (tempProduct == null)
            {
                throw new Exception("Элемент не найден");
            }
            CreateModel(model, tempProduct);
        }
        public void Delete(FurnitureBindingModel model)
        {
            for (int i = 0; i < source.Products.Count; ++i)
            {
                if (source.Products[i].Id == model.Id)
                {
                    source.Products.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Элемент не найден");
        }
        private static Furniture CreateModel(FurnitureBindingModel model, Furniture
        product)
        {
            product.FurnitureName = model.FurnitureName;
            product.Price = model.Price;
            // удаляем убранные
            foreach (var key in product.FurnitureDetails.Keys.ToList())
            {
                if (!model.FurnitureDetails.ContainsKey(key))
                {
                    product.FurnitureDetails.Remove(key);
                }
            }
            // обновляем существуюущие и добавляем новые
            foreach (var component in model.FurnitureDetails)
            {
                if (product.FurnitureDetails.ContainsKey(component.Key))
                {
                    product.FurnitureDetails[component.Key] =
                    model.FurnitureDetails[component.Key].Item2;
                }
                else
                {
                    product.FurnitureDetails.Add(component.Key,
                    model.FurnitureDetails[component.Key].Item2);
                }
            }
            return product;
        }
        private FurnitureViewModel CreateModel(Furniture product)
        {
            // требуется дополнительно получить список компонентов для изделия с названиями и их количество
            var productComponents = new Dictionary<int, (string, int)>();
            foreach (var pc in product.FurnitureDetails)
            {
                string componentName = string.Empty;
                foreach (var component in source.Components)
                {
                    if (pc.Key == component.Id)
                    {
                        componentName = component.DetailName;
                        break;
                    }
                }
                productComponents.Add(pc.Key, (componentName, pc.Value));
            }
            return new FurnitureViewModel
            {
                Id = product.Id,
                FurnitureName = product.FurnitureName,
                Price = product.Price,
                FurnitureDetails = productComponents
            };
        }
    }
}
