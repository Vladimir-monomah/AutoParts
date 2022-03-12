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
    public partial class Заказы : Form
    {
        private ЗаказыRow заказы;

        private AutoPartsDataSet AutoPartsDataSet;

        public Заказы(AutoPartsDataSet autoPartsDataSet)
        {
            InitializeComponent();


            this.AutoPartsDataSet=autoPartsDataSet;
        }

        public void LoadЗаказы(ЗаказыЗапросRow заказы)
        {
            this.заказы=EntityManager.FilterЗаказы($"Id_заказа={заказы.Id_заказа}").FirstOrDefault();
            this.tbDate.Text=заказы.Дата_счета;
            this.tbNumber.Text=Convert.ToInt32(заказы.___счета).ToString();
            tbCustomer.Text=заказы.ФИО_Заказчика;
            tbVendor.Text=заказы.ФИО_Поставщика;
            tbCount.Text=Convert.ToInt32(заказы.Всего_по_счету).ToString();
        }

        private bool CheckTextBoxes()
        {
            if (this.tbNumber.Text == "" || this.tbCustomer.Text == ""
                || this.tbVendor.Text == "" || this.tbCount.Text == "")
            {
                return false;
            }

            return true;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (!this.CheckTextBoxes())
            {
                MessageBox.Show("Заполните необходимые поля!",
                    "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                var Id = this.заказы?.Id_заказа;
                var adapter = new ЗаказыTableAdapter();
                adapter.Fill(EntityManager.ЗаказыDataTable);
                var savingЗаказы = EntityManager.ЗаказыDataTable.FindById_заказа(Id??-1)
                    ??EntityManager.ЗаказыDataTable.NewЗаказыRow();
                savingЗаказы.Дата_счета=this.tbDate.Text;
                savingЗаказы.___счета=Convert.ToInt32(this.tbNumber.Text);
                savingЗаказы.ФИО_Заказчика=tbCustomer.Text;
                savingЗаказы.ФИО_Поставщика=tbVendor.Text;
                savingЗаказы.Всего_по_счету=Convert.ToInt32(tbCount.Text);

                try
                {
                    if (this.заказы==null)
                    {
                        EntityManager.ЗаказыDataTable.AddЗаказыRow(savingЗаказы);
                        EntityManager.UpdateЗаказы();
                    }
                    else
                    {
                        var заказыTableAdapter = new ЗаказыTableAdapter();
                        заказыTableAdapter.Adapter.Update(savingЗаказы.Table);
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(
                       "Ошибка при добавлении/изменении! \r\n" + ex.ToString(),
                       "Ошибка",
                       MessageBoxButtons.OK);
                    return;
                }

                var message = this.заказы == null
                    ? "Добавление прошло успешно!"
                    : "Изменение завершено успешно!";

                MessageBox.Show(message, "Информация", MessageBoxButtons.OK);
                this.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Входные данные имели неверный формат! " +
                    "Проверте заполненость полей!", "Информация", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show(
                "Вы действиетльно хотите закрыть данную вкладку?",
                "Закрытие вкладки", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (dialogResult == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void tbDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 8 && (e.KeyChar < '0' || e.KeyChar > '9'))
            {
                e.KeyChar = (char)0;
                e.Handled = true;
            }
        }

        private void tbCustomer_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar)) return;
            else
                e.Handled = true;
        }
    }
}
