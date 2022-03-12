using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AutoParts.Properties;
using AutoParts.Формы;
using DGV2Printer;
using static AutoParts.AutoPartsDataSet;

namespace AutoParts.Объекты
{
    public partial class Объекты
    {
        private void dataGridView_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            int index = e.RowIndex;
            string indexStr = (index + 1).ToString();
            object header = this.dataGridView.Rows[index].HeaderCell.Value;
            if (header == null || !header.Equals(indexStr))
                this.dataGridView.Rows[index].HeaderCell.Value = indexStr;
        }

        private void buttonAdd_Click(object sender, System.EventArgs e)
        {
            Заказы открыть = new Заказы(autoPartsDataSet);
            открыть.ShowDialog();

            this.заказыTableAdapter.Fill(this.autoPartsDataSet.Заказы);
        }

        /// <summary>
        /// Импортирует данные из Exel-файла, выбранного в окне диалога
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonImport_Click(object sender, System.EventArgs e)
        {
            ЗаказыDataTable order = this.autoPartsDataSet.Заказы;
            this.заказыTableAdapter.Fill(order);
            this.ImportDataFromExcel(this.GetImportingExcelFileName(),
                order,
                new[] { "ФИО_Заказчика" });
            this.заказыTableAdapter.Update(order);
            this.Объекты_Load();
        }

        /// <summary>
        /// Экспорт файла
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonExport_Click(object sender, System.EventArgs e)
        {
            Microsoft.Office.Interop.Excel.Application ExcelApp = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook ExcelWorkBook;
            Microsoft.Office.Interop.Excel.Worksheet ExcelWorkSheet;
            ExcelWorkBook = ExcelApp.Workbooks.Add(System.Reflection.Missing.Value);
            ExcelWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)ExcelWorkBook.Worksheets.get_Item(1);
            for (int i = 0; i < this.dataGridView.Columns.Count; i++)
            {
                var cellCaption = this.dataGridView.Columns[i].HeaderText;
                var bracketIndex = cellCaption.IndexOf('(') - 1;
                if (bracketIndex > -1)
                {
                    cellCaption = cellCaption.Substring(0, bracketIndex);
                }

                cellCaption = cellCaption.Replace("№ счета", "№ счета");

                ExcelWorkSheet.Cells[1, i + 1] = cellCaption;
            }
            for (int i = 0; i < this.dataGridView.Rows.Count - 1; i++)
            {
                for (int j = 0; j < this.dataGridView.Columns.Count; j++)
                {
                    ExcelWorkSheet.Cells[i + 2, j + 1] = this.dataGridView.Rows[i].Cells[j].Value.ToString();
                    if (!this.dataGridView.Columns[j].Visible)
                    {
                        ExcelWorkSheet.Cells[i + 2, j + 1].ColumnWidth = 0;
                    }
                }
            }

            for (int j = 0; j < this.dataGridView.Columns.Count; j++)
            {
                if (this.dataGridView.Columns[j].Visible)
                {
                    ExcelWorkSheet.Columns[j + 1].AutoFit();
                }
            }
            ExcelApp.Visible = true;
        }

        /// <summary>
        /// Кнопка удалить строку сотрудника из БД
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonDelete_Click(object sender, System.EventArgs e)
        {
            var idEmployee = ((ЗаказыЗапросRow)((DataRowView)this.dataGridView.CurrentRow?.DataBoundItem)?.Row)?.Id_заказа;
            if (!idEmployee.HasValue)
            {
                return;
            }

            var deleteEmployeeQuestionResult = MessageBox.Show("Вы действительно хотите удалить читателя?", "Информация",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (deleteEmployeeQuestionResult != DialogResult.Yes)
            {
                return;
            }

            using (var connection = new OleDbConnection(Settings.Default.AutoPartsConnectionString1))
            {
                connection.Open();
                using (var sqlCommand = connection.CreateCommand())
                {
                    sqlCommand.CommandText = $"DELETE FROM Заказы WHERE Id_заказа = {idEmployee.Value}";
                    sqlCommand.ExecuteNonQuery();
                }
            }

            this.Объекты_Load();
        }

        private void button11_Click(object sender, System.EventArgs e)
        {
            this.textBox3.Text = "";
        }

        private void textBox3_TextChanged(object sender, System.EventArgs e)
        {
            this.заказыBindingSource.Filter = this.BuildWorkerCardFilter();
        }

        private string BuildWorkerCardFilter()
        {
            var filterExpressionList = new List<string>();
            var fieldFilter = this.textBox3.Text;
            if (!string.IsNullOrEmpty(fieldFilter))
            {
                filterExpressionList.Add(string.Format("(([Дата счета] Like '%{0}%'))", fieldFilter));
            }

            return string.Join(" AND ", filterExpressionList);
        }

        private void buttonPrint_Click(object sender, System.EventArgs e)
        {
            PrintDataGridView pr = new PrintDataGridView(dataGridView);
            pr.isRightToLeft = true;
            pr.ReportHeader = label6.Text;
            pr.Print();
        }
    }
}
