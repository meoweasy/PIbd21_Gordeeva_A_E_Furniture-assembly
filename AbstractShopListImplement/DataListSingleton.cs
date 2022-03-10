using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AbstractShopListImplement.Models;


namespace AbstractShopListImplement
{
    public class DataListSingleton
    {
        private static DataListSingleton instance;
        public List<Detail> Components { get; set; }
        public List<Order> Orders { get; set; }
        public List<Furniture> Products { get; set; }
        private DataListSingleton()
        {
            Components = new List<Detail>();
            Orders = new List<Order>();
            Products = new List<Furniture>();
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
