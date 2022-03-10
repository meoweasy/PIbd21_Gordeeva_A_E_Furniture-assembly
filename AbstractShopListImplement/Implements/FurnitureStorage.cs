﻿using System;
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
            List<FurnitureViewModel> result = new List<FurnitureViewModel>();
            foreach (var detail in source.Furnitures)
            {
                result.Add(CreateModel(detail));
            }
            return result;
        }
        public List<FurnitureViewModel> GetFilteredList(FurnitureBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            List<FurnitureViewModel> result = new List<FurnitureViewModel>();
            foreach (var furniture in source.Furnitures)
            {
                if (furniture.FurnitureName.Contains(model.FurnitureName))
                {
                    result.Add(CreateModel(furniture));
                }
            }
            return result;
        }
        public FurnitureViewModel GetElement(FurnitureBindingModel sample)
        {
            if (sample == null)
            {
                return null;
            }
            foreach (var furniture in source.Furnitures)
            {
                if (furniture.Id == sample.Id || furniture.FurnitureName ==
                sample.FurnitureName)
                {
                    return CreateModel(furniture);
                }
            }
            return null;
        }
        public void Insert(FurnitureBindingModel model)
        {
            Furniture tempFurniture = new Furniture
            {
                Id = 1,
                FurnitureDetails = new
            Dictionary<int, int>()
            };
            foreach (var furniture in source.Furnitures)
            {
                if (furniture.Id >= tempFurniture.Id)
                {
                    tempFurniture.Id = furniture.Id + 1;
                }
            }
            source.Furnitures.Add(CreateSample(model, tempFurniture));
        }
        public void Update(FurnitureBindingModel model)
        {
            Furniture tempFurniture = null;
            foreach (var furniture in source.Furnitures)
            {
                if (furniture.Id == model.Id)
                {
                    tempFurniture = furniture;
                }
            }
            if (tempFurniture == null)
            {
                throw new Exception("Мебель не найдена");
            }
            CreateSample(model, tempFurniture);
        }
        public void Delete(FurnitureBindingModel sample)
        {
            for (int i = 0; i < source.Furnitures.Count; ++i)
            {
                if (source.Furnitures[i].Id == sample.Id)
                {
                    source.Furnitures.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Мебель не найдена");
        }
        private Furniture CreateSample(FurnitureBindingModel sample, Furniture furniture)
        {
            furniture.FurnitureName = sample.FurnitureName;
            furniture.Price = sample.Price;
            // удаляем убранные
            foreach (var key in furniture.FurnitureDetails.Keys.ToList())
            {
                if (!sample.FurnitureDetails.ContainsKey(key))
                {
                    furniture.FurnitureDetails.Remove(key);
                }
            }
            // обновляем существуюущие и добавляем новые
            foreach (var detail in sample.FurnitureDetails)
            {
                if (furniture.FurnitureDetails.ContainsKey(detail.Key))
                {
                    furniture.FurnitureDetails[detail.Key] =
                    sample.FurnitureDetails[detail.Key].Item2;
                }
                else
                {
                    furniture.FurnitureDetails.Add(detail.Key,
                    sample.FurnitureDetails[detail.Key].Item2);
                }
            }
            return furniture;
        }
        private FurnitureViewModel CreateModel(Furniture furniture)
        {
            // требуется дополнительно получить список компонентов для изделия с названиями и их количество
            Dictionary<int, (string, int)> furnitureDetails = new
            Dictionary<int, (string, int)>();
            foreach (var pc in furniture.FurnitureDetails)
            {
                string detailName = string.Empty;
                foreach (var detail in source.Details)
                {
                    if (pc.Key == detail.Id)
                    {
                        detailName = detail.DetailName;
                        break;
                    }
                }
                furnitureDetails.Add(pc.Key, (detailName, pc.Value));
            }
            return new FurnitureViewModel
            {
                Id = furniture.Id,
                FurnitureName = furniture.FurnitureName,
                Price = furniture.Price,
                FurnitureDetails = furnitureDetails
            };
        }
    }
}
