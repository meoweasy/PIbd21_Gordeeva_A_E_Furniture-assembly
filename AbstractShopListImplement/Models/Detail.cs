using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractShopListImplement.Models
{
    /// <summary>
    /// Деталь, требуемая для изготовления мебели
    /// </summary>
    public class Detail
    {
        public int Id { get; set; }
        public string DetailName { get; set; }
    }
}
