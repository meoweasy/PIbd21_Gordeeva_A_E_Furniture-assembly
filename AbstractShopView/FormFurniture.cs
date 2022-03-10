using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;
using AbstractShopContracts.BindingModels;
using AbstractShopContracts.BusinessLogicsContracts;
using AbstractShopContracts.ViewModels;


namespace AbstractShopView
{
    public partial class FormFurniture : Form
    {
        public int Id { set { id = value; } }
        private readonly IFurnitureLogic _logic;
        private int? id;
        private Dictionary<int, (string, int)> FurnitureDetails;
        public FormFurniture(IFurnitureLogic logic)
        {
            InitializeComponent();
            _logic = logic;

        }


        private void FormProduct_Load(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    FurnitureViewModel view = _logic.Read(new FurnitureBindingModel
                    {
                        Id =
                   id.Value
                    })?[0];
                    if (view != null)
                    {
                        textBoxName.Text = view.ProductName;
                        textBoxPrice.Text = view.Price.ToString();
                        FurnitureDetails = view.ProductComponents;
                        LoadData();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
                }
            }
            else
            {
                FurnitureDetails = new Dictionary<int, (string, int)>();
            }
        }

        private void LoadData()
        {
            try
            {
                if (FurnitureDetails != null)
                {
                    dataGridView.Rows.Clear();
                    foreach (var pc in FurnitureDetails)
                    {
                        dataGridView.Rows.Add(new object[] { pc.Key, pc.Value.Item1,
pc.Value.Item2 });
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxName.Text))
            {
                MessageBox.Show("Заполните название", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBoxPrice.Text))
            {
                MessageBox.Show("Заполните цену", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            if (FurnitureDetails == null || FurnitureDetails.Count == 0)
            {
                MessageBox.Show("Заполните компоненты", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            try
            {
                _logic.CreateOrUpdate(new FurnitureBindingModel
                {
                    Id = id,
                    FurnitureName = textBoxName.Text,
                    Price = Convert.ToDecimal(textBoxPrice.Text),
                    FurnitureDetails = FurnitureDetails
                });
                MessageBox.Show("Сохранение прошло успешно", "Сообщение",
               MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void buttonUpd_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                var form = Program.Container.Resolve<FormFurnitureDetail>();
                int id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value);
                form.Id = id;
                form.Count = FurnitureDetails[id].Item2;
                if (form.ShowDialog() == DialogResult.OK)
                {
                    FurnitureDetails[form.Id] = (form.ComponentName, form.Count);
                    LoadData();
                }
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            var form = Program.Container.Resolve<FormFurnitureDetail>();
            if (form.ShowDialog() == DialogResult.OK)
            {
                if (FurnitureDetails.ContainsKey(form.Id))
                {
                    FurnitureDetails[form.Id] = (form.ComponentName, form.Count);
                }
                else
                {
                    FurnitureDetails.Add(form.Id, (form.ComponentName, form.Count));
                }
                LoadData();
            }
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButtons.YesNo,
               MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {

                        FurnitureDetails.Remove(Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value));
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
