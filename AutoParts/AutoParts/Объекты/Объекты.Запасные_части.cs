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
        private bool ExistsЗапасныеЧасти(Запасные_частиRow запасныеЧастиRow)
        {
            foreach (Запасные_частиRow row in this.autoPartsDataSet.Запасные_части.Rows)
            {
                if (row.Место_покупки == запасныеЧастиRow.Место_покупки)
                {
                    return true;
                }
            }

            return false;
        }

        private void button36_Click(object sender, System.EventArgs e)
        {
            Запасные_части открыть = new Запасные_части();
            открыть.OnSaveEvent += () =>
            {
                this.запасные_частиTableAdapter.Fill(this.autoPartsDataSet.Запасные_части);
            };
            открыть.ShowDialog();
        }
        private void textBox6_TextChanged(object sender, System.EventArgs e)
        {
            this.запасныеЧастиBindingSource.Filter = this.Build();
        }

        private string Build()
        {
            var filterExpressionList = new List<string>();
            var fieldFilter = this.textBox6.Text;
            if (!string.IsNullOrEmpty(fieldFilter))
            {
                filterExpressionList.Add(string.Format("(([Место покупки] Like '%{0}%'))", fieldFilter));
            }

            return string.Join(" AND ", filterExpressionList);
        }
    }
}
