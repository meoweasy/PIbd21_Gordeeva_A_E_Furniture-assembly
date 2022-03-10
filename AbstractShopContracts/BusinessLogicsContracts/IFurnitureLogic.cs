using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AbstractShopContracts.BindingModels;
using AbstractShopContracts.ViewModels;


namespace AbstractShopContracts.BusinessLogicsContracts
{
    public interface IFurnitureLogic
    {
        List<FurnitureViewModel> Read(FurnitureBindingModel model);
        void CreateOrUpdate(FurnitureBindingModel model);
        void Delete(FurnitureBindingModel model);
    }
}
