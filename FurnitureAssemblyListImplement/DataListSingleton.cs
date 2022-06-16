using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FurnitureAssemblyListImplement.Models;


namespace FurnitureAssemblyListImplement
{
    public class DataListSingleton
    {
        private static DataListSingleton instance;
        public List<Detail> Details { get; set; }
        public List<Order> Orders { get; set; }
        public List<Furniture> Furnitures { get; set; }
        public List<Client> Clients { get; set; }
        public List<Implementer> Implementers { get; set; }
        public List<MessageInfo> MessagesInfo { get; set; }
        private DataListSingleton()
        {
            Details = new List<Detail>();
            Orders = new List<Order>();
            Furnitures = new List<Furniture>();
            Clients = new List<Client>();
            Implementers = new List<Implementer>();
            MessagesInfo = new List<MessageInfo>();
        }
        public static DataListSingleton GetInstance()
        {
            if (instance == null)
            {
                instance = new DataListSingleton();
            }
            return instance;
        }
    }
}
