using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoParts.Формы;

namespace AutoParts.Объекты
{
    public partial class Объекты
    {
        private void button7_Click(object sender, System.EventArgs e)
        {
            Vin_коды открыть = new Vin_коды();
            открыть.OnSaveEvent += () =>
            {
                this.vin_кодыTableAdapter.Fill(this.autoPartsDataSet.Vin_коды);
            };
            открыть.ShowDialog();
        }
    }
}
