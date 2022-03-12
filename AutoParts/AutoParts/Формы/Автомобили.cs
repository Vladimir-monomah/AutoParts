using AutoParts.AutoPartsDataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static AutoParts.AutoPartsDataSet;

namespace AutoParts.Формы
{
    public partial class Автомобили : Form
    {
        public delegate void OnSave();

        public delegate void OnBeforeSave(АвтомобилиRow isRecordExists);

        public Автомобили()
        {
            this.OnSaveEvent += () => { };
            this.OnBeforeSaveEvent += isRecordExists => { };
            InitializeComponent();
        }

        public event OnSave OnSaveEvent;

        public event OnBeforeSave OnBeforeSaveEvent;

        public void ЗагрузитьНовыйАвтомобиль(string названиеАвтомобиля)
        {
            this.textBoxCar.Text = названиеАвтомобиля;
        }

        private bool CheckTextBoxes()
        {
            if (textBoxCar.Text == ""||textBoxModel.Text==""||textBoxDate.Text==""
                ||textBoxVin.Text==""||textV.Text==""||textBoxNumber.Text=="")
            {
                return false;
            }
            return true;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (!CheckTextBoxes())
            {
                MessageBox.Show("Названия элементов справочника пустое и не будет сохранено.", "Информация",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                return;
            }

            var Car = this.textBoxCar.Text;
            var adapter = new АвтомобилиTableAdapter();
            adapter.Fill(EntityManager.АвтомобилиDataTable);
            АвтомобилиRow existingCar = null;
            foreach (var cars in EntityManager.АвтомобилиDataTable)
            {
                if (cars.Название_авто == Car)
                {
                    existingCar = cars;
                    break;
                }
            }

            if (existingCar != null)
            {
                this.OnBeforeSaveEvent(existingCar);
                MessageBox.Show("Автомобиль с таким названием уже существует!", "Информация", MessageBoxButtons.OK);
                return;
            }

            var newCar = EntityManager.АвтомобилиDataTable.NewАвтомобилиRow();
            newCar.Название_авто = Car;
            newCar.Модель_авто = textBoxModel.Text;
            newCar.Год_выпуска = Convert.ToInt32(textBoxDate.Text);
            newCar.Vin_код = Convert.ToInt32(textBoxVin.Text);
            newCar.Объем_двигателя = Convert.ToInt32(textV.Text);
            newCar.Номер_детали = textBoxNumber.Text;
            EntityManager.АвтомобилиDataTable.AddАвтомобилиRow(newCar);
            EntityManager.UpdateАвтомобили();
            this.OnSaveEvent();

            MessageBox.Show("Добавление прошло успешно!", "Информация", MessageBoxButtons.OK);
        }

        private void textBoxDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar) | (Char.IsPunctuation(e.KeyChar))) return;
            else
                e.Handled = true;
        }

        private void button62_Click(object sender, EventArgs e)
        {
            var окноАвто = new Авто();
            if (окноАвто.ShowDialog() == DialogResult.OK)
            {
                this.textBoxVin.Text = окноАвто.ПолучитьАвто();
            }
        }
    }
}
