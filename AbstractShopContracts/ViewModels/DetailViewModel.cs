using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;


namespace AbstractShopContracts.ViewModels
{
    /// <summary>
    /// Деталь, требуемая для изготовления мебели
    /// </summary>
    public class DetailViewModel
    {
        public int Id { get; set; }
        [DisplayName("Название компонента")]
        public string DetailName { get; set; }
    }
}
