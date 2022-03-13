﻿using FurnitureAssemblyContracts.BindingModels;
using FurnitureAssemblyContracts.StoragesContacts;
using FurnitureAssemblyContracts.ViewModels;
using FurnitureAssemblyFileImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FurnitureAssemblyFileImplement.Implements
{
    public class FurnitureStorage : IFurnitureStorage
    {
        private readonly FileDataListSingleton source;
        public FurnitureStorage()
        {
            source = FileDataListSingleton.GetInstance();
        }
        public List<FurnitureViewModel> GetFullList()
        {
            return source.Furnitures
            .Select(CreateModel)
            .ToList();
        }
        public List<FurnitureViewModel> GetFilteredList(FurnitureBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            return source.Furnitures
            .Where(rec => rec.FurnitureName.Contains(model.FurnitureName))
            .Select(CreateModel)
            .ToList();
        }
        public FurnitureViewModel GetElement(FurnitureBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            var furniture = source.Furnitures
            .FirstOrDefault(rec => rec.FurnitureName == model.FurnitureName || rec.Id
           == model.Id);
            return furniture != null ? CreateModel(furniture) : null;
        }
        public void Insert(FurnitureBindingModel model)
        {
            int maxId = source.Furnitures.Count > 0 ? source.Furnitures.Max(rec => rec.Id)
: 0;
            var element = new Furniture
            {
                Id = maxId + 1,
                FurnitureDetails = new Dictionary<int, int>()
            };
            source.Furnitures.Add(CreateModel(model, element));
        }
        public void Update(FurnitureBindingModel model)
        {
            var element = source.Furnitures.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            CreateModel(model, element);
        }
        public void Delete(FurnitureBindingModel model)
        {
            Furniture element = source.Furnitures.FirstOrDefault(rec => rec.Id == model.Id);
            if (element != null)
            {
                source.Furnitures.Remove(element);
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }
        private static Furniture CreateModel(FurnitureBindingModel model, Furniture furniture)
        {
            furniture.FurnitureName = model.FurnitureName;
            furniture.Price = model.Price;
            // удаляем убранные
            foreach (var key in furniture.FurnitureDetails.Keys.ToList())
            {
                if (!model.FurnitureDetails.ContainsKey(key))
                {
                    furniture.FurnitureDetails.Remove(key);
                }
            }
            // обновляем существуюущие и добавляем новые
            foreach (var detail in model.FurnitureDetails)
            {
                if (furniture.FurnitureDetails.ContainsKey(detail.Key))
                {
                    furniture.FurnitureDetails[detail.Key] =
                   model.FurnitureDetails[detail.Key].Item2;
                }
                else
                {
                    furniture.FurnitureDetails.Add(detail.Key,
                   model.FurnitureDetails[detail.Key].Item2);
                }
            }
            return furniture;
        }
        private FurnitureViewModel CreateModel(Furniture furniture)
        {
            return new FurnitureViewModel
            {
                Id = furniture.Id,
                FurnitureName = furniture.FurnitureName,
                Price = furniture.Price,
                FurnitureDetails = furniture.FurnitureDetails.ToDictionary(recPC => recPC.Key, recPC =>(source.Details.FirstOrDefault(recC => recC.Id == recPC.Key)?.DetailName, recPC.Value))
            };

        }
    }
}
