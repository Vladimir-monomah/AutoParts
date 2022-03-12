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

namespace AutoParts
{
    public partial class Авто : Form
    {
        public Авто()
        {
            InitializeComponent();
        }

        public string ПолучитьАвто()
        {
            return Convert.ToInt32(((Vin_кодыRow)((DataRowView)this.dataGridView.CurrentRow?.DataBoundItem)?.Row).Vin_код).ToString();
        }

        private void Авто_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "autoPartsDataSet.Vin_коды". При необходимости она может быть перемещена или удалена.
            this.vin_кодыTableAdapter.Fill(this.autoPartsDataSet.Vin_коды);

        }

        private void dataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
