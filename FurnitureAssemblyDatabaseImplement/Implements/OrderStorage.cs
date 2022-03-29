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
    public class OrderStorage : IOrderStorage
    {
        public List<OrderViewModel> GetFullList()
        {
            using var context = new FurnitureAssemblyDatabase();
            return context.Orders
            .Select(CreateModel)
            .ToList();
        }
        public List<OrderViewModel> GetFilteredList(OrderBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using var context = new FurnitureAssemblyDatabase();
            return context.Orders
            .Where(rec => rec.FurnitureId == model.FurnitureId)
            .Select(CreateModel)
            .ToList();
        }
        public OrderViewModel GetElement(OrderBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using var context = new FurnitureAssemblyDatabase();
            var order = context.Orders
            .FirstOrDefault(rec => rec.FurnitureId == model.FurnitureId || rec.Id
           == model.Id);
            return order != null ? CreateModel(order) : null;
        }
        public void Insert(OrderBindingModel model)
        {
            using var context = new FurnitureAssemblyDatabase();
            context.Orders.Add(CreateModel(model, new Order()));
            context.SaveChanges();
        }
        public void Update(OrderBindingModel model)
        {
            using var context = new FurnitureAssemblyDatabase();
            var element = context.Orders.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            CreateModel(model, element);
            context.SaveChanges();
        }
        public void Delete(OrderBindingModel model)
        {
            using var context = new FurnitureAssemblyDatabase();
            Order element = context.Orders.FirstOrDefault(rec => rec.Id ==
           model.Id);
            if (element != null)
            {
                context.Orders.Remove(element);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }
        private static Order CreateModel(OrderBindingModel model, Order order)
        {
            order.FurnitureId = model.FurnitureId;
            order.Count = model.Count;
            order.Sum = model.Sum;
            order.Status = model.Status;
            order.DateCreate = model.DateCreate;
            order.DateImplement = model.DateImplement;
            return order;
        }
        private static OrderViewModel CreateModel(Order order)
        {
            using var context = new FurnitureAssemblyDatabase();
            return new OrderViewModel
            {
                Id = order.Id,
                FurnitureId = order.FurnitureId,
                FurnitureName = context.Furnitures.FirstOrDefault(t => t.Id == order.FurnitureId)?.FurnitureName,
                Count = order.Count,
                Sum = order.Sum,
                Status = Convert.ToString(order.Status),
                DateCreate = order.DateCreate,
                DateImplement = order.DateImplement
            };
        }
    }
}
