namespace FurnitureAssemblyView
{
    partial class FormReportFurnitureDetails
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
            this.ButtonSaveToExcel = new System.Windows.Forms.Button();
            this.dataGridViewReportFurnitureDetails = new System.Windows.Forms.DataGridView();
            this.DetailName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FurnitureName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Count = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewReportFurnitureDetails)).BeginInit();
            this.SuspendLayout();
            // 
            // ButtonSaveToExcel
            // 
            this.ButtonSaveToExcel.Location = new System.Drawing.Point(12, 12);
            this.ButtonSaveToExcel.Name = "ButtonSaveToExcel";
            this.ButtonSaveToExcel.Size = new System.Drawing.Size(240, 23);
            this.ButtonSaveToExcel.TabIndex = 0;
            this.ButtonSaveToExcel.Text = "Сохранить в Excel";
            this.ButtonSaveToExcel.UseVisualStyleBackColor = true;
            this.ButtonSaveToExcel.Click += new System.EventHandler(this.ButtonSaveToExcel_Click);
            // 
            // dataGridViewReportFurnitureDetails
            // 
            this.dataGridViewReportFurnitureDetails.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridViewReportFurnitureDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewReportFurnitureDetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DetailName,
            this.FurnitureName,
            this.Count});
            this.dataGridViewReportFurnitureDetails.Location = new System.Drawing.Point(12, 41);
            this.dataGridViewReportFurnitureDetails.Name = "dataGridViewReportFurnitureDetails";
            this.dataGridViewReportFurnitureDetails.RowTemplate.Height = 25;
            this.dataGridViewReportFurnitureDetails.Size = new System.Drawing.Size(344, 397);
            this.dataGridViewReportFurnitureDetails.TabIndex = 1;
            // 
            // DetailName
            // 
            this.DetailName.HeaderText = "Деталь";
            this.DetailName.Name = "DetailName";
            // 
            // FurnitureName
            // 
            this.FurnitureName.HeaderText = "Фурнитура";
            this.FurnitureName.Name = "FurnitureName";
            // 
            // Count
            // 
            this.Count.HeaderText = "Количество";
            this.Count.Name = "Count";
            // 
            // FormReportFurnitureDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(504, 450);
            this.Controls.Add(this.dataGridViewReportFurnitureDetails);
            this.Controls.Add(this.ButtonSaveToExcel);
            this.Name = "FormReportFurnitureDetails";
            this.Text = "Детали по фурнитурам";
            this.Load += new System.EventHandler(this.FormReportFurnitureDetails_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewReportFurnitureDetails)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ButtonSaveToExcel;
        private System.Windows.Forms.DataGridView dataGridViewReportFurnitureDetails;
        private System.Windows.Forms.DataGridViewTextBoxColumn DetailName;
        private System.Windows.Forms.DataGridViewTextBoxColumn FurnitureName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Count;
    }
}