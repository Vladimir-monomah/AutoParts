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
    public partial class Заказчик : Form
    {
        public delegate void OnSave();

        public delegate void OnBeforeSave(ЗаказчикRow isRecordExists);

        public Заказчик()
        {
            this.OnSaveEvent += () => { };
            this.OnBeforeSaveEvent += isRecordExists => { };
            InitializeComponent();
        }
        public event OnSave OnSaveEvent;

        public event OnBeforeSave OnBeforeSaveEvent;

        public void ЗагрузитьЗаказчика(string ФИО)
        {
            this.textBoxFIO.Text = ФИО;
        }

        private bool CheckTextBoxes()
        {
            if (textBoxRequisites.Text == ""||textBoxFIO.Text==""||textBoxNumber.Text==""
                ||textBoxPhone.Text==""||textBoxNaz.Text==""||textBoxModel.Text=="")
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
            var CustomerName = this.textBoxFIO.Text;
            var adapter = new ЗаказчикTableAdapter();
            adapter.Fill(EntityManager.ЗаказчикDataTable);
            ЗаказчикRow existingCustomer = null;
            foreach (var customer in EntityManager.ЗаказчикDataTable)
            {
                if (customer.Контактное_лицо == CustomerName)
                {
                    existingCustomer = customer;
                    break;
                }
            }
            if (existingCustomer != null)
            {
                this.OnBeforeSaveEvent(existingCustomer);
                MessageBox.Show("Заказчик с таким именем уже существует!", "Информация", MessageBoxButtons.OK);
                return;
            }

            var newCustomer = EntityManager.ЗаказчикDataTable.NewЗаказчикRow();
            newCustomer.Контактное_лицо = CustomerName;
            newCustomer.Реквизиты = textBoxRequisites.Text;
            newCustomer.___счета = textBoxNumber.Text;
            newCustomer.___телефона = Convert.ToInt32(textBoxPhone.Text);
            newCustomer.Название_авто = textBoxNaz.Text;
            newCustomer.Модель_авто = textBoxModel.Text;
            EntityManager.ЗаказчикDataTable.AddЗаказчикRow(newCustomer);
            EntityManager.UpdateЗаказчик();
            this.OnSaveEvent();

            MessageBox.Show("Добавление прошло успешно!", "Информация", MessageBoxButtons.OK);
        }
    }
}
