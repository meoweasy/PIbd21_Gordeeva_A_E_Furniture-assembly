using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FurnitureAssemblyBusinessLogic.OfficePackage;
using FurnitureAssemblyBusinessLogic.OfficePackage.HelperModels;
using FurnitureAssemblyContracts.BindingModels;
using FurnitureAssemblyContracts.BusinessLogicsContracts;
using FurnitureAssemblyContracts.StoragesContacts;
using FurnitureAssemblyContracts.ViewModels;


namespace FurnitureAssemblyBusinessLogic.BusinessLogics
{
    public class ReportLogic : IReportLogic
    {
        private readonly IDetailStorage _detailStorage;
        private readonly IFurnitureStorage _furnitureStorage;
        private readonly IOrderStorage _orderStorage;
        private readonly FurnitureSaveToExcel _saveToExcel;
        private readonly FurnitureSaveToWord _saveToWord;
        private readonly FurnitureSaveToPdf _saveToPdf;
        public ReportLogic(IFurnitureStorage furnitureStorage, IDetailStorage
       detailStorage, IOrderStorage orderStorage,
        FurnitureSaveToExcel saveToExcel, FurnitureSaveToWord saveToWord,
       FurnitureSaveToPdf saveToPdf)
        {
            _furnitureStorage = furnitureStorage;
            _detailStorage = detailStorage;
            _orderStorage = orderStorage;
            _saveToExcel = saveToExcel;
            _saveToWord = saveToWord;
            _saveToPdf = saveToPdf;
        }
        /// <summary>
        /// Получение списка компонент с указанием, в каких изделиях используются
        /// </summary>
        /// <returns></returns>
        public List<ReportFurnitureDetailViewModel> GetFurnitureDetail()
        {
            var furnitures = _furnitureStorage.GetFullList();
            var list = new List<ReportFurnitureDetailViewModel>();
            foreach (var furniture in furnitures)
            {
                var record = new ReportFurnitureDetailViewModel
                {
                    FurnitureName = furniture.FurnitureName,
                    Details = new List<Tuple<string, int>>(),
                    TotalCount = 0
                };
                foreach (var detail in furniture.FurnitureDetails)
                {
                    record.Details.Add(new Tuple<string, int>(detail.Value.Item1, detail.Value.Item2));
                    record.TotalCount += detail.Value.Item2;
                }
                list.Add(record);
            }
            return list;
        }
        /// <summary>
        /// Получение списка заказов за определенный период
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<ReportOrdersViewModel> GetOrders(ReportBindingModel model)
        {
            return _orderStorage.GetFilteredList(new OrderBindingModel
            {
                DateFrom = model.DateFrom,
                DateTo = model.DateTo
            })
            .Select(x => new ReportOrdersViewModel
            {
                DateCreate = x.DateCreate,
                FurnitureName = x.FurnitureName,
                Count = x.Count,
                Sum = x.Sum,
                Status = x.Status
            })
           .ToList();
        }
        /// <summary>
        /// Сохранение деталей в файл-Word
        /// </summary>
        /// <param name="model"></param>
        public void SaveDetailsToWordFile(ReportBindingModel model)
        {
            _saveToWord.CreateDoc(new WordInfo
            {
                FileName = model.FileName,
                Title = "Список изделий",
                Furnitures = _furnitureStorage.GetFullList()
            });
        }
        /// <summary>
        /// Сохранение деталей с указаеним фурнитуры в файл-Excel
        /// </summary>
        /// <param name="model"></param>
        public void SaveFurnitureDetailToExcelFile(ReportBindingModel model)
        {
            _saveToExcel.CreateReport(new ExcelInfo
            {
                FileName = model.FileName,
                Title = "Список деталей",
                FurnitureDetails = GetFurnitureDetail()
            });
        }
        /// <summary>
        /// Сохранение заказов в файл-Pdf
        /// </summary>
        /// <param name="model"></param>
        public void SaveOrdersToPdfFile(ReportBindingModel model)
        {
            _saveToPdf.CreateDoc(new PdfInfo
            {
                FileName = model.FileName,
                Title = "Список заказов",
                DateFrom = model.DateFrom.Value,
                DateTo = model.DateTo.Value,
                Orders = GetOrders(model)
            });
        }
    }
}
