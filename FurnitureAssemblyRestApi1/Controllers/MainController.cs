using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FurnitureAssemblyBusinessLogic.BusinessLogics;
using FurnitureAssemblyContracts.BusinessLogicsContracts;
using FurnitureAssemblyContracts.StoragesContacts;
using Microsoft.AspNetCore.Mvc;
using FurnitureAssemblyContracts.BindingModels;
using FurnitureAssemblyContracts.ViewModels;

namespace FurnitureAssemblyRestApi1.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MainController : ControllerBase
    {
        private readonly IOrderLogic _order;
        private readonly IFurnitureLogic _furniture;
        public MainController(IOrderLogic order, IFurnitureLogic furniture)
        {
            _order = order;
            _furniture = furniture;
        }
        [HttpGet]
        public List<FurnitureViewModel> GetProductList() => _furniture.Read(null)?.ToList();
        [HttpGet]
        public FurnitureViewModel GetProduct(int productId) => _furniture.Read(new
       FurnitureBindingModel
        { Id = productId })?[0];
        [HttpGet]
        public List<OrderViewModel> GetOrders(int clientId) => _order.Read(new
       OrderBindingModel
        { ClientId = clientId });
        [HttpPost]
        public void CreateOrder(CreateOrderBindingModel model) =>
       _order.CreateOrder(model);
    }
}
