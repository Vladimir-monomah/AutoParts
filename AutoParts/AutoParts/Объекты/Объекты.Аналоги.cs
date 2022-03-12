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
        private bool ExistsАналоги(АналогиRow аналогиRow)
        {
            foreach (АналогиRow row in this.autoPartsDataSet.Аналоги.Rows)
            {
                if (row.Номер_аналога == аналогиRow.Номер_аналога)
                {
                    return true;
                }
            }

            return false;
        }

        private void button22_Click(object sender, System.EventArgs e)
        {
            Аналоги открыть = new Аналоги();
            открыть.OnSaveEvent += () =>
            {
                this.аналогиTableAdapter.Fill(this.autoPartsDataSet.Аналоги);
            };
            открыть.ShowDialog();
        }

        private void textBox4_TextChanged(object sender, System.EventArgs e)
        {
            this.аналогиBindingSource.Filter = this.BuildCardFilter();
        }

        private string BuildCardFilter()
        {
            var filterExpressionList = new List<string>();
            var fieldFilter = this.textBox4.Text;
            if (!string.IsNullOrEmpty(fieldFilter))
            {
                filterExpressionList.Add(string.Format("(([Наименование] Like '%{0}%'))", fieldFilter));
            }

            return string.Join(" AND ", filterExpressionList);
        }

        private void button17_Click(object sender, System.EventArgs e)
        {
            textBox4.Text = "";
        }
    }
}
