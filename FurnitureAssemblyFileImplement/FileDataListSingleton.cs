using System;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using System.Collections.Generic;
using FurnitureAssemblyContracts.Enums;
using FurnitureAssemblyFileImplement.Models;

namespace FurnitureAssemblyFileImplement
{
    public class FileDataListSingleton
    {
        private static FileDataListSingleton instance;
        private readonly string DetailFileName = "Detail.xml";
        private readonly string OrderFileName = "Order.xml";
        private readonly string FurnitureFileName = "Furniture.xml";
        public List<Detail> Details { get; set; }
        public List<Order> Orders { get; set; }
        public List<Furniture> Furnitures { get; set; }
        public List<Client> Clients { get; set; }
        private FileDataListSingleton()
        {
            Details = LoadDetails();
            Orders = LoadOrders();
            Furnitures = LoadFurnitures();
            Clients = new List<Client>();
        }
        public static FileDataListSingleton GetInstance()
        {
            if (instance == null)
            {
                instance = new FileDataListSingleton();
            }
            return instance;
        }
        public static void SaveData()
        {
            instance.SaveDetails();
            instance.SaveOrders();
            instance.SaveFurnitures();
        }
        private List<Detail> LoadDetails()
        {
            var list = new List<Detail>();
            if (File.Exists(DetailFileName))
            {
                var xDocument = XDocument.Load(DetailFileName);
                var xElements = xDocument.Root.Elements("Detail").ToList();
                foreach (var elem in xElements)
                {
                    list.Add(new Detail
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        DetailName = elem.Element("DetailName").Value
                    });
                }
            }
            return list;
        }
        private List<Order> LoadOrders()
        {
            var list = new List<Order>();
            if (File.Exists(OrderFileName))
            {
                var xDocument = XDocument.Load(OrderFileName);
                var xElements = xDocument.Root.Elements("Order").ToList();
                foreach (var elem in xElements)
                {  
                    list.Add(new Order
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        FurnitureId = Convert.ToInt32(elem.Element("FurnitureId").Value),
                        Count = Convert.ToInt32(elem.Element("Count").Value),
                        Sum = Convert.ToDecimal(elem.Element("Sum").Value),
                        Status = (OrderStatus)Convert.ToInt32(elem.Element("Status").Value),
                        DateCreate = Convert.ToDateTime(elem.Element("DateCreate").Value),
                        DateImplement = String.IsNullOrEmpty(elem.Element("DateImplement").Value) ? DateTime.MinValue : Convert.ToDateTime(elem.Element("DateImplement").Value),
                    });
                }
            }
            return list;
        }
        private List<Furniture> LoadFurnitures()
        {
            var list = new List<Furniture>();
            if (File.Exists(FurnitureFileName))
            {
                var xDocument = XDocument.Load(FurnitureFileName);
                var xElements = xDocument.Root.Elements("Furniture").ToList();
                foreach (var elem in xElements)
                {
                    var furnDet = new Dictionary<int, int>();
                    foreach (var detail in
                   elem.Element("FurnitureDetails").Elements("FurnitureDetails").ToList())
                    {
                        furnDet.Add(Convert.ToInt32(detail.Element("Key").Value),
                       Convert.ToInt32(detail.Element("Value").Value));
                    }
                    list.Add(new Furniture
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        FurnitureName = elem.Element("FurnitureName").Value,
                        Price = Convert.ToDecimal(elem.Element("Price").Value),
                        FurnitureDetails = furnDet
                    });
                }
            }
            return list;
        }
        private void SaveDetails()
        {
            if (Details != null)
            {
                var xElement = new XElement("Details");
                foreach (var detail in Details)
                {
                    xElement.Add(new XElement("Detail",
                    new XAttribute("Id", detail.Id),
                    new XElement("DetailName", detail.DetailName)));
                }
                var xDocument = new XDocument(xElement);
                xDocument.Save(DetailFileName);
            }
        }
        private void SaveOrders()
        {
            if (Orders != null)
            {
                var xElement = new XElement("Orders");
                foreach (var order in Orders)
                {
                    xElement.Add(new XElement("Order",
                    new XAttribute("Id", order.Id),
                    new XElement("FurnitureId", order.FurnitureId),
                    new XElement("Count", order.Count),
                    new XElement("Sum", order.Sum),
                    new XElement("Status", (int)order.Status),
                    new XElement("DateCreate", order.DateCreate),
                    new XElement("DateImplement", order.DateImplement)
                    ));
                }
                var xDocument = new XDocument(xElement);
                xDocument.Save(OrderFileName);
            }
        }
        private void SaveFurnitures()
        {
            if (Furnitures != null)
            {
                var xElement = new XElement("Furnitures");
                foreach (var furniture in Furnitures)
                {
                    var detElement = new XElement("FurnitureDetails");
                    foreach (var detail in furniture.FurnitureDetails)
                    {
                        detElement.Add(new XElement("FurnitureDetail",
                        new XElement("Key", detail.Key),
                        new XElement("Value", detail.Value)));
                    }
                    xElement.Add(new XElement("Furniture",
                     new XAttribute("Id", furniture.Id),
                     new XElement("FurnitureName", furniture.FurnitureName),
                     new XElement("Price", furniture.Price),
                     detElement));
                }
                var xDocument = new XDocument(xElement);
                xDocument.Save(FurnitureFileName);
            }
        }

    }
}
