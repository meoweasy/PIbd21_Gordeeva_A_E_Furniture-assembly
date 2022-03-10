using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AbstractShopContracts.BindingModels;
using AbstractShopBusinessLogic.BusinessLogics;
using Unity;

namespace AbstractShopView
{
    public partial class FormFurnitures : Form
    {
        private readonly FurnitureLogic _logic;
        public FormFurnitures(FurnitureLogic logic)
        {
            InitializeComponent();
            _logic = logic;
        }
        private void FormProducts_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            try
            {
                var list = _logic.Read(null);
                if (list != null)
                {
                    dataGridView1.DataSource = list;
                    dataGridView1.Columns[0].Visible = false;
                    dataGridView1.Columns[1].AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.Fill;
                    dataGridView1.Columns[3].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
        }
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            var form = Program.Container.Resolve<FormFurniture>();
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }
        private void buttonUpd_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                var form = Program.Container.Resolve<FormFurniture>();
                form.Id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
                }
            }
        }
        private void buttonDel_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButtons.YesNo,
               MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int id =
                   Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
                    try
                    {
                        _logic.Delete(new FurnitureBindingModel { Id = id });
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                       MessageBoxIcon.Error);
                    }
                    LoadData();
                }
            }
        }
        private void buttonRef_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
