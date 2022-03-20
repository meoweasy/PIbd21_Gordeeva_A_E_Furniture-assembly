using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace FurnitureAssemblyDatabaseImplement.Models
{
    /// <summary>
    /// Сколько деталей, требуется при изготовлении изделия
    /// </summary>
    public class FurnitureDetail
    {
        public int Id { get; set; }
        public int FurnitureId { get; set; }
        public int DetailId { get; set; }
        [Required]
        public int Count { get; set; }
        public virtual Detail Detail { get; set; }
        public virtual Furniture Furniture { get; set; }
    }
}
