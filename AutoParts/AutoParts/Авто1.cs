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
    public partial class Авто1 : Form
    {
        public Авто1()
        {
            InitializeComponent();
        }

        public string ПолучитьНомерДетали()
        {
            return ((АвтомобилиRow)((DataRowView)this.dataGridView1.CurrentRow?.DataBoundItem)?.Row).Номер_детали;
        }

        private void Авто1_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "autoPartsDataSet.Автомобили". При необходимости она может быть перемещена или удалена.
            this.автомобилиTableAdapter.Fill(this.autoPartsDataSet.Автомобили);

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
