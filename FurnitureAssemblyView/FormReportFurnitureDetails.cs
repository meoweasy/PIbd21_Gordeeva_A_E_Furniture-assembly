﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FurnitureAssemblyContracts.BindingModels;
using FurnitureAssemblyContracts.BusinessLogicsContracts;

namespace FurnitureAssemblyView
{
    public partial class FormReportFurnitureDetails : Form
    {
        private readonly IReportLogic _logic;
        public FormReportFurnitureDetails(IReportLogic logic)
        {
            InitializeComponent();
            _logic = logic;
        }

        private void ButtonSaveToExcel_Click(object sender, EventArgs e)
        {
            using var dialog = new SaveFileDialog { Filter = "xlsx|*.xlsx" };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    _logic.SaveFurnitureDetailToExcelFile(new ReportBindingModel
                    {
                        FileName = dialog.FileName
                    });
                    MessageBox.Show("Выполнено", "Успех",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void FormReportFurnitureDetails_Load(object sender, EventArgs e)
        {
            try
            {
                var dict = _logic.GetFurnitureDetail();
                if (dict != null)
                {
                    dataGridViewReportFurnitureDetails.Rows.Clear();
                    foreach (var elem in dict)
                    {
                        dataGridViewReportFurnitureDetails.Rows.Add(new object[] { elem.DetailName, "", ""
});
                        foreach (var listElem in elem.Furnitures)
                        {
                            dataGridViewReportFurnitureDetails.Rows.Add(new object[] { "", listElem.Item1,
listElem.Item2 });
                        }
                        dataGridViewReportFurnitureDetails.Rows.Add(new object[] { "Итого", "", elem.TotalCount
});
                        dataGridViewReportFurnitureDetails.Rows.Add(Array.Empty<object>());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }

        }
    }
}
