using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FurnitureAssemblyContracts.BusinessLogicsContracts;
using FurnitureAssemblyContracts.BindingModels;

namespace FurnitureAssemblyView
{
    public partial class FormMessagesInfo : Form
    {
        private readonly IMessageInfoLogic _messageInfoLogic;
        public FormMessagesInfo(IMessageInfoLogic messageInfoLogic)
        {
            InitializeComponent();
            _messageInfoLogic = messageInfoLogic;
        }

        private void FormMessagesInfo_Load(object sender, EventArgs e)
        {
            Program.ConfigGrid(_messageInfoLogic.Read(null), dataGridView);
        }

        private void buttonRef_Click(object sender, EventArgs e)
        {
            Program.ConfigGrid(_messageInfoLogic.Read(null), dataGridView);
        }
    }
}
