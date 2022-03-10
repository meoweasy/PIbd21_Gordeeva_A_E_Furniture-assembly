using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AbstractShopContracts.BusinessLogicsContracts;
using AbstractShopContracts.ViewModels;


namespace AbstractShopView
{
    public partial class FormFurnitureDetail : Form
    {
        public int Id
        {
            get { return Convert.ToInt32(comboBoxDetail.SelectedValue); }
            set { comboBoxDetail.SelectedValue = value; }
        }
        public string DetailName { get { return comboBoxDetail.Text; } }
        public int Count
        {
            get { return Convert.ToInt32(textBoxCount.Text); }
            set
            {
                textBoxCount.Text = value.ToString();
            }
        }

        public FormFurnitureDetail(IDetailLogic logic)
        {
            InitializeComponent();
            List<DetailViewModel> list = logic.Read(null);
            if (list != null)
            {
                comboBoxDetail.DisplayMember = "DetailName";
                comboBoxDetail.ValueMember = "Id";
                comboBoxDetail.DataSource = list;
                comboBoxDetail.SelectedItem = null;
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxCount.Text))
            {
                MessageBox.Show("Заполните поле Количество", "Ошибка",
               MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (comboBoxDetail.SelectedValue == null)
            {
                MessageBox.Show("Выберите компонент", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            DialogResult = DialogResult.OK;
            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
