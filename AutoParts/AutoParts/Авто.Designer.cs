namespace AutoParts
{
    partial class Авто
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Авто));
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.autoPartsDataSet = new AutoParts.AutoPartsDataSet();
            this.vinКодыBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.vin_кодыTableAdapter = new AutoParts.AutoPartsDataSetTableAdapters.Vin_кодыTableAdapter();
            this.vinКодDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.autoPartsDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vinКодыBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.AutoGenerateColumns = false;
            this.dataGridView.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.vinКодDataGridViewTextBoxColumn});
            this.dataGridView.DataSource = this.vinКодыBindingSource;
            this.dataGridView.Location = new System.Drawing.Point(12, 12);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowTemplate.Height = 24;
            this.dataGridView.Size = new System.Drawing.Size(776, 433);
            this.dataGridView.TabIndex = 1;
            this.dataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellDoubleClick);
            // 
            // autoPartsDataSet
            // 
            this.autoPartsDataSet.DataSetName = "AutoPartsDataSet";
            this.autoPartsDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // vinКодыBindingSource
            // 
            this.vinКодыBindingSource.DataMember = "Vin коды";
            this.vinКодыBindingSource.DataSource = this.autoPartsDataSet;
            // 
            // vin_кодыTableAdapter
            // 
            this.vin_кодыTableAdapter.ClearBeforeFill = true;
            // 
            // vinКодDataGridViewTextBoxColumn
            // 
            this.vinКодDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.vinКодDataGridViewTextBoxColumn.DataPropertyName = "Vin код";
            this.vinКодDataGridViewTextBoxColumn.HeaderText = "Vin код";
            this.vinКодDataGridViewTextBoxColumn.Name = "vinКодDataGridViewTextBoxColumn";
            this.vinКодDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // Авто
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Авто";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Авто";
            this.Load += new System.EventHandler(this.Авто_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.autoPartsDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vinКодыBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView;
        private AutoPartsDataSet autoPartsDataSet;
        private System.Windows.Forms.BindingSource vinКодыBindingSource;
        private AutoPartsDataSetTableAdapters.Vin_кодыTableAdapter vin_кодыTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn vinКодDataGridViewTextBoxColumn;
    }
}