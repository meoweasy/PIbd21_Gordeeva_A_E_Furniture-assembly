﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AbstractShopContracts.BindingModels;
using AbstractShopContracts.BusinessLogicsContracts;


namespace AbstractShopView
{
    public partial class FormComponent : Form
    {
        public int Id { set { id = value; } }
        private readonly IComponentLogic _logic;
        private int? id;
        public FormComponent(IComponentLogic logic)
        {
            InitializeComponent();
            _logic = logic;
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxName.Text))
            {
                MessageBox.Show("Заполните название", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            try
            {
                _logic.CreateOrUpdate(new ComponentBindingModel
                {
                    Id = id,
                    ComponentName = textBoxName.Text
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
    }
}
