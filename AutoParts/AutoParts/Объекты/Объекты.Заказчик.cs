using AutoParts.Формы;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AutoParts.AutoPartsDataSet;

namespace AutoParts.Объекты
{
    public partial class Объекты
    {
        private bool ExistsЗаказчик(ЗаказчикRow заказчикRow)
        {
            foreach (ЗаказчикRow row in this.autoPartsDataSet.Заказчик.Rows)
            {
                if (row.Контактное_лицо == заказчикRow.Контактное_лицо)
                {
                    return true;
                }
            }

            return false;
        }

        private void button29_Click(object sender, System.EventArgs e)
        {
            Заказчик открыть = new Заказчик();
            открыть.OnSaveEvent += () =>
            {
                this.заказчикTableAdapter.Fill(this.autoPartsDataSet.Заказчик);
            };
            открыть.ShowDialog();
        }

        private void textBox5_TextChanged(object sender, System.EventArgs e)
        {
            this.заказчикBindingSource.Filter = this.BuildCar();
        }

        private string BuildCar()
        {
            var filterExpressionList = new List<string>();
            var fieldFilter = this.textBox5.Text;
            if (!string.IsNullOrEmpty(fieldFilter))
            {
                filterExpressionList.Add(string.Format("(([Реквизиты] Like '%{0}%'))", fieldFilter));
            }

            return string.Join(" AND ", filterExpressionList);
        }
    }
}
