using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FurnitureAssemblyContracts.BindingModels;
using FurnitureAssemblyContracts.ViewModels;

namespace FurnitureAssemblyContracts.BusinessLogicsContracts
{
    public interface IReportLogic
    {
        /// <summary>
        /// Получение списка деталей с указанием, в каких фурнитурах используются
        /// </summary>
        /// <returns></returns>
        List<ReportFurnitureDetailViewModel> GetFurnitureDetail();
        /// <summary>
        /// Получение списка заказов за определенный период
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        List<ReportOrdersViewModel> GetOrders(ReportBindingModel model);
        /// <summary>
        /// Сохранение деталей в файл-Word
        /// </summary>
        /// <param name="model"></param>
        void SaveDetailsToWordFile(ReportBindingModel model);
        /// <summary>
        /// Сохранение деталей с указаеним фурнитур в файл-Excel
        /// </summary>
        /// <param name="model"></param>
        void SaveFurnitureDetailToExcelFile(ReportBindingModel model);
        /// <summary>
        /// Сохранение заказов в файл-Pdf
        /// </summary>
        /// <param name="model"></param>
        void SaveOrdersToPdfFile(ReportBindingModel model);
    }
}
