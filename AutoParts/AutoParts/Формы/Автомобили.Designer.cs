namespace AutoParts.Формы
{
    partial class Автомобили
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Автомобили));
            this.button62 = new System.Windows.Forms.Button();
            this.textV = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxVin = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxDate = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxModel = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxNumber = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.textBoxCar = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button62
            // 
            this.button62.Location = new System.Drawing.Point(627, 211);
            this.button62.Name = "button62";
            this.button62.Size = new System.Drawing.Size(23, 29);
            this.button62.TabIndex = 134;
            this.button62.UseVisualStyleBackColor = true;
            this.button62.Click += new System.EventHandler(this.button62_Click);
            // 
            // textV
            // 
            this.textV.Location = new System.Drawing.Point(260, 275);
            this.textV.MaxLength = 30;
            this.textV.Multiline = true;
            this.textV.Name = "textV";
            this.textV.Size = new System.Drawing.Size(361, 30);
            this.textV.TabIndex = 133;
            this.textV.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxDate_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(61, 282);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(182, 23);
            this.label6.TabIndex = 132;
            this.label6.Text = "Объем двигателя";
            // 
            // textBoxVin
            // 
            this.textBoxVin.Location = new System.Drawing.Point(260, 210);
            this.textBoxVin.MaxLength = 30;
            this.textBoxVin.Multiline = true;
            this.textBoxVin.Name = "textBoxVin";
            this.textBoxVin.ReadOnly = true;
            this.textBoxVin.Size = new System.Drawing.Size(361, 30);
            this.textBoxVin.TabIndex = 131;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(88, 210);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 23);
            this.label5.TabIndex = 130;
            this.label5.Text = "Vin код";
            // 
            // textBoxDate
            // 
            this.textBoxDate.Location = new System.Drawing.Point(260, 146);
            this.textBoxDate.MaxLength = 4;
            this.textBoxDate.Multiline = true;
            this.textBoxDate.Name = "textBoxDate";
            this.textBoxDate.Size = new System.Drawing.Size(361, 30);
            this.textBoxDate.TabIndex = 129;
            this.textBoxDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxDate_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(88, 153);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(134, 23);
            this.label4.TabIndex = 128;
            this.label4.Text = "Год выпуска";
            // 
            // textBoxModel
            // 
            this.textBoxModel.Location = new System.Drawing.Point(260, 89);
            this.textBoxModel.MaxLength = 30;
            this.textBoxModel.Multiline = true;
            this.textBoxModel.Name = "textBoxModel";
            this.textBoxModel.Size = new System.Drawing.Size(361, 30);
            this.textBoxModel.TabIndex = 127;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(88, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 23);
            this.label3.TabIndex = 126;
            this.label3.Text = "Модель";
            // 
            // textBoxNumber
            // 
            this.textBoxNumber.Location = new System.Drawing.Point(260, 337);
            this.textBoxNumber.MaxLength = 30;
            this.textBoxNumber.Multiline = true;
            this.textBoxNumber.Name = "textBoxNumber";
            this.textBoxNumber.Size = new System.Drawing.Size(361, 30);
            this.textBoxNumber.TabIndex = 125;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(88, 344);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(148, 23);
            this.label2.TabIndex = 124;
            this.label2.Text = "Номер детали";
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonCancel.Location = new System.Drawing.Point(467, 390);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(120, 39);
            this.buttonCancel.TabIndex = 122;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // buttonSave
            // 
            this.buttonSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonSave.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonSave.Location = new System.Drawing.Point(593, 390);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(120, 39);
            this.buttonSave.TabIndex = 123;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // textBoxCar
            // 
            this.textBoxCar.Location = new System.Drawing.Point(260, 21);
            this.textBoxCar.MaxLength = 30;
            this.textBoxCar.Multiline = true;
            this.textBoxCar.Name = "textBoxCar";
            this.textBoxCar.Size = new System.Drawing.Size(361, 30);
            this.textBoxCar.TabIndex = 121;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(88, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(155, 23);
            this.label1.TabIndex = 120;
            this.label1.Text = "Название авто";
            // 
            // Автомобили
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button62);
            this.Controls.Add(this.textV);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBoxVin);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBoxDate);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxModel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxNumber);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.textBoxCar);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Автомобили";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Автомобили";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button62;
        private System.Windows.Forms.TextBox textV;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxVin;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxModel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxNumber;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.TextBox textBoxCar;
        private System.Windows.Forms.Label label1;
    }
}