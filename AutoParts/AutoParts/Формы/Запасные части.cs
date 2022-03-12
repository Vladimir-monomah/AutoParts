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
using AutoParts.Формы;
using static AutoParts.AutoPartsDataSet;

namespace AutoParts.Формы
{
    public partial class Запасные_части : Form
    {
        public delegate void OnSave();

        public delegate void OnBeforeSave(Запасные_частиRow isRecordExists);

        public Запасные_части()
        {
            this.OnSaveEvent += () => { };
            this.OnBeforeSaveEvent += isRecordExists => { };
            InitializeComponent();
        }

        public event OnSave OnSaveEvent;

        public event OnBeforeSave OnBeforeSaveEvent;

        public void ЗагрузитьЗапасныеЧасти(string МестоПокупки)
        {
            this.textBoxDate.Text = МестоПокупки;
        }

        private bool CheckTextBoxes()
        {
            if (textBoxDate.Text == ""||textBoxNumber.Text==""||textBoxPo.Text==""
                ||textBoxPrice1.Text==""||textBoxPrice2.Text==""||textBoxNumber.Text=="")
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

            var ЧастиName = this.textBoxPo.Text;
            var adapter = new Запасные_частиTableAdapter();
            adapter.Fill(EntityManager.Запасные_частиDataTable);
            Запасные_частиRow existingЧасти = null;
            foreach (var части in EntityManager.Запасные_частиDataTable)
            {
                if (части.Место_покупки == ЧастиName)
                {
                    existingЧасти = части;
                    break;
                }
            }

            if (existingЧасти != null)
            {
                this.OnBeforeSaveEvent(existingЧасти);
                MessageBox.Show("Запасные части с таким названием уже существует!", "Информация", MessageBoxButtons.OK);
                return;
            }

            var newЧасти = EntityManager.Запасные_частиDataTable.NewЗапасные_частиRow();
            newЧасти.Место_покупки = ЧастиName;
            newЧасти.Дата_отгрузки = Convert.ToInt32(textBoxDate.Text);
            newЧасти.Номер_детали = Convert.ToInt32(textBoxNumber.Text);
            newЧасти.Закупочная_цена = Convert.ToInt32(textBoxPrice1.Text);
            newЧасти.Цена_отгрузки = Convert.ToInt32(textBoxPrice2.Text);
            newЧасти.Номер_аналога = textBoxAnalog.Text;
            EntityManager.Запасные_частиDataTable.AddЗапасные_частиRow(newЧасти);
            EntityManager.UpdateЗапасные_части();
            this.OnSaveEvent();

            MessageBox.Show("Добавление прошло успешно!", "Информация", MessageBoxButtons.OK);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var окноДетали = new Авто1();
            if (окноДетали.ShowDialog() == DialogResult.OK)
            {
                this.textBoxNumber.Text = окноДетали.ПолучитьНомерДетали();
            }
        }

        private void button62_Click(object sender, EventArgs e)
        {
            var окноАналога = new Аналог();
            if (окноАналога.ShowDialog() == DialogResult.OK)
            {
                this.textBoxAnalog.Text = окноАналога.ПолучитьНомерАналога();
            }
        }
    }
}
