using System;
using System.Collections.Generic;
using System.Linq;
using FurnitureAssemblyContracts.BindingModels;
using FurnitureAssemblyContracts.ViewModels;
using FurnitureAssemblyDatabaseImplement.Models;
using FurnitureAssemblyContracts.StoragesContacts;


namespace FurnitureAssemblyDatabaseImplement.Implements
{
    public class DetailStorage : IDetailStorage
    {
        public List<DetailViewModel> GetFullList()
        {
            using var context = new FurnitureAssemblyDatabase();
            return context.Details
            .Select(CreateModel)
            .ToList();
        }
        public List<DetailViewModel> GetFilteredList(DetailBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using var context = new FurnitureAssemblyDatabase();
            return context.Details
            .Where(rec => rec.DetailName.Contains(model.DetailName))
            .Select(CreateModel)
            .ToList();
        }
        public DetailViewModel GetElement(DetailBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using var context = new FurnitureAssemblyDatabase();
            var detail = context.Details
            .FirstOrDefault(rec => rec.DetailName == model.DetailName || rec.Id
           == model.Id);
            return detail != null ? CreateModel(detail) : null;
        }
        public void Insert(DetailBindingModel model)
        {
            using var context = new FurnitureAssemblyDatabase();
            context.Details.Add(CreateModel(model, new Detail()));
            context.SaveChanges();
        }
        public void Update(DetailBindingModel model)
        {
            using var context = new FurnitureAssemblyDatabase();
            var element = context.Details.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            CreateModel(model, element);
            context.SaveChanges();
        }
        public void Delete(DetailBindingModel model)
        {
            using var context = new FurnitureAssemblyDatabase();
            Detail element = context.Details.FirstOrDefault(rec => rec.Id ==
           model.Id);
            if (element != null)
            {
                context.Details.Remove(element);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }
        private static Detail CreateModel(DetailBindingModel model, Detail detail)
        {
            detail.DetailName = model.DetailName;
            return detail;
        }
        private static DetailViewModel CreateModel(Detail detail)
        {
            return new DetailViewModel
            {
                Id = detail.Id,
                DetailName = detail.DetailName
            };
        }
    }
}
