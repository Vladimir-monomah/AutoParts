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
    public partial class Аналог : Form
    {
        public Аналог()
        {
            InitializeComponent();
        }

        public string ПолучитьНомерАналога()
        {
            return ((АналогиRow)((DataRowView)this.dataGridView1.CurrentRow?.DataBoundItem)?.Row).Номер_аналога;
        }

        private void Аналог_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "autoPartsDataSet.Аналоги". При необходимости она может быть перемещена или удалена.
            this.аналогиTableAdapter.Fill(this.autoPartsDataSet.Аналоги);

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
