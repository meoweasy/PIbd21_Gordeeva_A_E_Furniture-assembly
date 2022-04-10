
namespace FurnitureAssemblyView
{
    partial class FormReportOrders
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelReportOrders = new System.Windows.Forms.Panel();
            this.labelReportOrder = new System.Windows.Forms.Label();
            this.labelReportOrders2 = new System.Windows.Forms.Label();
            this.dateTimePickerFrom = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerTo = new System.Windows.Forms.DateTimePicker();
            this.buttonMake = new System.Windows.Forms.Button();
            this.buttonToPdf = new System.Windows.Forms.Button();
            this.panelReportOrders.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelReportOrders
            // 
            this.panelReportOrders.Controls.Add(this.buttonToPdf);
            this.panelReportOrders.Controls.Add(this.buttonMake);
            this.panelReportOrders.Controls.Add(this.dateTimePickerTo);
            this.panelReportOrders.Controls.Add(this.dateTimePickerFrom);
            this.panelReportOrders.Controls.Add(this.labelReportOrders2);
            this.panelReportOrders.Controls.Add(this.labelReportOrder);
            this.panelReportOrders.Location = new System.Drawing.Point(0, 0);
            this.panelReportOrders.Name = "panelReportOrders";
            this.panelReportOrders.Size = new System.Drawing.Size(646, 38);
            this.panelReportOrders.TabIndex = 0;
            // 
            // labelReportOrder
            // 
            this.labelReportOrder.AutoSize = true;
            this.labelReportOrder.Location = new System.Drawing.Point(12, 11);
            this.labelReportOrder.Name = "labelReportOrder";
            this.labelReportOrder.Size = new System.Drawing.Size(15, 15);
            this.labelReportOrder.TabIndex = 0;
            this.labelReportOrder.Text = "C";
            // 
            // labelReportOrders2
            // 
            this.labelReportOrders2.AutoSize = true;
            this.labelReportOrders2.Location = new System.Drawing.Point(184, 11);
            this.labelReportOrders2.Name = "labelReportOrders2";
            this.labelReportOrders2.Size = new System.Drawing.Size(21, 15);
            this.labelReportOrders2.TabIndex = 1;
            this.labelReportOrders2.Text = "по";
            // 
            // dateTimePickerFrom
            // 
            this.dateTimePickerFrom.Location = new System.Drawing.Point(32, 7);
            this.dateTimePickerFrom.Name = "dateTimePickerFrom";
            this.dateTimePickerFrom.Size = new System.Drawing.Size(146, 23);
            this.dateTimePickerFrom.TabIndex = 2;
            // 
            // dateTimePickerTo
            // 
            this.dateTimePickerTo.Location = new System.Drawing.Point(211, 7);
            this.dateTimePickerTo.Name = "dateTimePickerTo";
            this.dateTimePickerTo.Size = new System.Drawing.Size(143, 23);
            this.dateTimePickerTo.TabIndex = 3;
            // 
            // buttonMake
            // 
            this.buttonMake.Location = new System.Drawing.Point(372, 7);
            this.buttonMake.Name = "buttonMake";
            this.buttonMake.Size = new System.Drawing.Size(102, 23);
            this.buttonMake.TabIndex = 4;
            this.buttonMake.Text = "Сформировать";
            this.buttonMake.UseVisualStyleBackColor = true;
            this.buttonMake.Click += new System.EventHandler(this.buttonMake_Click);
            // 
            // buttonToPdf
            // 
            this.buttonToPdf.Location = new System.Drawing.Point(528, 7);
            this.buttonToPdf.Name = "buttonToPdf";
            this.buttonToPdf.Size = new System.Drawing.Size(105, 23);
            this.buttonToPdf.TabIndex = 1;
            this.buttonToPdf.Text = "В Pdf";
            this.buttonToPdf.UseVisualStyleBackColor = true;
            this.buttonToPdf.Click += new System.EventHandler(this.buttonToPdf_Click);
            // 
            // FormReportOrders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(645, 272);
            this.Controls.Add(this.panelReportOrders);
            this.Name = "FormReportOrders";
            this.Text = "Заказы";
            this.panelReportOrders.ResumeLayout(false);
            this.panelReportOrders.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelReportOrders;
        private System.Windows.Forms.Button buttonToPdf;
        private System.Windows.Forms.Button buttonMake;
        private System.Windows.Forms.DateTimePicker dateTimePickerTo;
        private System.Windows.Forms.DateTimePicker dateTimePickerFrom;
        private System.Windows.Forms.Label labelReportOrders2;
        private System.Windows.Forms.Label labelReportOrder;
    }
}