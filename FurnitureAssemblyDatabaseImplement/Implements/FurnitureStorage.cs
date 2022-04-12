using FurnitureAssemblyContracts.BindingModels;
using FurnitureAssemblyContracts.StoragesContacts;
using FurnitureAssemblyContracts.ViewModels;
using FurnitureAssemblyDatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;


namespace FurnitureAssemblyDatabaseImplement.Implements
{
    public class FurnitureStorage : IFurnitureStorage
    {
        public List<FurnitureViewModel> GetFullList()
        {
            using var context = new FurnitureAssemblyDatabase();
            var tmp = context.Furnitures
            .Include(rec => rec.FurnitureDetails)
            .ThenInclude(rec => rec.Detail)
            .ToList()
            .Select(CreateModel)
            .ToList();
            return tmp;
        }
        public List<FurnitureViewModel> GetFilteredList(FurnitureBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using var context = new FurnitureAssemblyDatabase();
            return context.Furnitures
            .Include(rec => rec.FurnitureDetails)
            .ThenInclude(rec => rec.Detail)
            .Where(rec => rec.FurnitureName.Contains(model.FurnitureName))
            .ToList()
            .Select(CreateModel)
            .ToList();
        }
        public FurnitureViewModel GetElement(FurnitureBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using var context = new FurnitureAssemblyDatabase();
            var furniture = context.Furnitures
            .Include(rec => rec.FurnitureDetails)
            .ThenInclude(rec => rec.Detail)
            .FirstOrDefault(rec => rec.FurnitureName == model.FurnitureName || rec.Id == model.Id);
            return furniture != null ? CreateModel(furniture) : null;
        }
        public void Insert(FurnitureBindingModel model)
        {
            using var context = new FurnitureAssemblyDatabase();
            using var transaction = context.Database.BeginTransaction();
            try
            {
                Furniture furniture = new Furniture()
                {
                    FurnitureName = model.FurnitureName,
                    Price = model.Price
                };
                context.Furnitures.Add(furniture);
                context.SaveChanges();
                CreateModel(model, furniture, context);
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }
        public void Update(FurnitureBindingModel model)
        {
            using var context = new FurnitureAssemblyDatabase();
            using var transaction = context.Database.BeginTransaction();
            try
            {
                var element = context.Furnitures.FirstOrDefault(rec => rec.Id ==
                model.Id);
                if (element == null)
                {
                    throw new Exception("Элемент не найден");
                }
                CreateModel(model, element, context);
                context.SaveChanges();
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }
        public void Delete(FurnitureBindingModel model)
        {
            using var context = new FurnitureAssemblyDatabase();
            Furniture element = context.Furnitures.FirstOrDefault(rec => rec.Id ==
            model.Id);
            if (element != null)
            {
                context.Furnitures.Remove(element);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }
        private static Furniture CreateModel(FurnitureBindingModel model, Furniture furniture,
       FurnitureAssemblyDatabase context)
        {
            furniture.FurnitureName = model.FurnitureName;
            furniture.Price = model.Price;
            if (model.Id.HasValue)
            {
                var furnitureDetails = context.FurnitureDetails.Where(rec =>
               rec.FurnitureId == model.Id.Value).ToList();
                // удалили те, которых нет в модели
                context.FurnitureDetails.RemoveRange(furnitureDetails.Where(rec =>
               !model.FurnitureDetails.ContainsKey(rec.DetailId)).ToList());
                context.SaveChanges();
                // обновили количество у существующих записей
                foreach (var updateDetail in furnitureDetails)
                {
                    updateDetail.Count = model.FurnitureDetails[updateDetail.DetailId].Item2;
                    model.FurnitureDetails.Remove(updateDetail.DetailId);
                }
                context.SaveChanges();
            }
            // добавили новые
            foreach (var pc in model.FurnitureDetails)
            {
                context.FurnitureDetails.Add(new FurnitureDetail
                {
                    FurnitureId = furniture.Id,
                    DetailId = pc.Key,
                    Count = pc.Value.Item2
                });
                context.SaveChanges();
            }
            return furniture;
        }
        private static FurnitureViewModel CreateModel(Furniture furniture)
        {
            return new FurnitureViewModel
            {
                Id = furniture.Id,
                FurnitureName = furniture.FurnitureName,
                Price = furniture.Price,
                FurnitureDetails = furniture.FurnitureDetails
                .ToDictionary(recPC => recPC.DetailId, recPC => (recPC.Detail?.DetailName, recPC.Count))
            };
        }
    }
}
