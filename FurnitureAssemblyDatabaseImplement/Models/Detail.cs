using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FurnitureAssemblyDatabaseImplement.Models
{
    /// <summary>
    /// Деталь, требуемая для изготовления изделия
    /// </summary>
    public class Detail
    {
        public int Id { get; set; }
        [Required]
        public string DetailName { get; set; }
        [ForeignKey("DetailtId")]
        public virtual List<FurnitureDetail> FurnitureDetails { get; set; }
    }
}
