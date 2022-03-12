namespace AutoParts
{
    partial class Аналог
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Аналог));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.autoPartsDataSet = new AutoParts.AutoPartsDataSet();
            this.аналогиBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.аналогиTableAdapter = new AutoParts.AutoPartsDataSetTableAdapters.АналогиTableAdapter();
            this.номерАналогаDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.autoPartsDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.аналогиBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.номерАналогаDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.аналогиBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(776, 426);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // autoPartsDataSet
            // 
            this.autoPartsDataSet.DataSetName = "AutoPartsDataSet";
            this.autoPartsDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // аналогиBindingSource
            // 
            this.аналогиBindingSource.DataMember = "Аналоги";
            this.аналогиBindingSource.DataSource = this.autoPartsDataSet;
            // 
            // аналогиTableAdapter
            // 
            this.аналогиTableAdapter.ClearBeforeFill = true;
            // 
            // номерАналогаDataGridViewTextBoxColumn
            // 
            this.номерАналогаDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.номерАналогаDataGridViewTextBoxColumn.DataPropertyName = "Номер аналога";
            this.номерАналогаDataGridViewTextBoxColumn.HeaderText = "Номер аналога";
            this.номерАналогаDataGridViewTextBoxColumn.Name = "номерАналогаDataGridViewTextBoxColumn";
            this.номерАналогаDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // Аналог
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Аналог";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Аналог";
            this.Load += new System.EventHandler(this.Аналог_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.autoPartsDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.аналогиBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private AutoPartsDataSet autoPartsDataSet;
        private System.Windows.Forms.BindingSource аналогиBindingSource;
        private AutoPartsDataSetTableAdapters.АналогиTableAdapter аналогиTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn номерАналогаDataGridViewTextBoxColumn;
    }
}