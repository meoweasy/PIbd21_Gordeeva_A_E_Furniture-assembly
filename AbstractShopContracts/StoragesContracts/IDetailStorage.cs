using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AbstractShopContracts.BindingModels;
using AbstractShopContracts.ViewModels;

namespace AbstractShopContracts.StoragesContacts
{
    public interface IDetailStorage
    {
        List<DetailViewModel> GetFullList();
        List<DetailViewModel> GetFilteredList(DetailBindingModel model);
        DetailViewModel GetElement(DetailBindingModel model);
        void Insert(DetailBindingModel model);
        void Update(DetailBindingModel model);
        void Delete(DetailBindingModel model);
    }
}
