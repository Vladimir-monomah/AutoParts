using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AutoParts.AutoPartsDataSetTableAdapters;
using static AutoParts.AutoPartsDataSet;

namespace AutoParts.Формы
{
    public delegate void OnSave();

    public delegate void OnBeforeSave(Vin_кодыRow isRecordExists);

    public partial class Vin_коды : Form
    {
        public Vin_коды()
        {
            this.OnSaveEvent += () => { };
            this.OnBeforeSaveEvent += isRecordExists => { };
            InitializeComponent();
        }

        public event OnSave OnSaveEvent;

        public event OnBeforeSave OnBeforeSaveEvent;

        public void ЗагрузитьVin_коды(string Vin)
        {
            this.tbVin.Text = Vin;
        }

        private bool CheckTextBoxes()
        {
            if (tbVin.Text == ""|| tbDate.Text=="")
            {
                return false;
            }
            return true;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (!CheckTextBoxes())
            {
                MessageBox.Show("Название элемента справочника пустое и не будет сохранено.", "Информация",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                return;
            }

            var Vin = this.tbVin.Text;
            var adapter = new Vin_кодыTableAdapter();
            adapter.Fill(EntityManager.Vin_кодыDataTable);
            Vin_кодыRow existingAutor = null;
            foreach (var vin in EntityManager.Vin_кодыDataTable)
            {
                if (vin.Vin_код==Convert.ToInt32(Vin))
                {
                    existingAutor = vin;
                    break;
                }
            }

            if (existingAutor != null)
            {
                this.OnBeforeSaveEvent(existingAutor);
                MessageBox.Show("Vin номер с таким названием уже существует!", "Информация", MessageBoxButtons.OK);
                return;
            }

            var newVin = EntityManager.Vin_кодыDataTable.NewVin_кодыRow();
            newVin.Vin_код = Convert.ToInt32(Vin);
            newVin.Год=Convert.ToInt32(tbDate.Text);
            EntityManager.Vin_кодыDataTable.AddVin_кодыRow(newVin);
            EntityManager.UpdateVin_коды();
            this.OnSaveEvent();

            MessageBox.Show("Добавление прошло успешно!", "Информация", MessageBoxButtons.OK);
        }

        private void tbVin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar) | (Char.IsPunctuation(e.KeyChar))) return;
            else
                e.Handled = true;
        }
    }
}
