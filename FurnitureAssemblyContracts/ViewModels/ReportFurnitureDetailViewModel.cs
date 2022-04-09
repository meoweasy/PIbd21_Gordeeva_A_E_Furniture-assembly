﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureAssemblyContracts.ViewModels
{
    public class ReportFurnitureDetailViewModel
    {
        public string DetailName { get; set; }
        public int TotalCount { get; set; }
        public List<Tuple<string, int>> Furnitures { get; set; }
    }
}
