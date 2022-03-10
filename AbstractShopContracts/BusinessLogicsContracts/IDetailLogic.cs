using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AbstractShopContracts.BindingModels;
using AbstractShopContracts.ViewModels;


namespace AbstractShopContracts.BusinessLogicsContracts
{
    public interface IDetailLogic
    {
        List<DetailViewModel> Read(DetailBindingModel model);
        void CreateOrUpdate(DetailBindingModel model);
        void Delete(DetailBindingModel model);
    }
}
