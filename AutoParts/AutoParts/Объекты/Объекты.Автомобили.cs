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
        private bool ExistsАвтомобили(АвтомобилиRow автомобилиRow)
        {
            foreach (АвтомобилиRow row in this.autoPartsDataSet.Автомобили.Rows)
            {
                if (row.Название_авто == автомобилиRow.Название_авто)
                {
                    return true;
                }
            }

            return false;
        }

        private void button15_Click(object sender, System.EventArgs e)
        {
            Автомобили открыть = new Автомобили();
            открыть.OnSaveEvent += () =>
            {
                this.автомобилиTableAdapter.Fill(this.autoPartsDataSet.Автомобили);
            };
            открыть.ShowDialog();
        }

        private void textBox2_TextChanged(object sender, System.EventArgs e)
        {
            this.автомобилиBindingSource.Filter = this.BuildCardFilter();
        }

        private string BuildCardFilter()
        {
            var filterExpressionList = new List<string>();
            var fieldFilter = this.textBox2.Text;
            if (!string.IsNullOrEmpty(fieldFilter))
            {
                filterExpressionList.Add(string.Format("(([Модель авто] Like '%{0}%') OR ([Название авто] Like '%{0}%'))", fieldFilter));
            }

            return string.Join(" AND ", filterExpressionList);
        }

        private void button9_Click(object sender, System.EventArgs e)
        {
            textBox2.Text = "";
        }
    }
}
