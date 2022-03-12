using System.Data.OleDb;
using System.Reflection;
using System.Windows.Forms;

namespace AutoParts.Объекты
{
    public partial class Объекты : Form
    {
        private OleDbConnection connection;

        public Объекты()
        {
            InitializeComponent();
            this.Объекты_Load();
        }

        public TabPage GetTabByName(string tabName)
        {
            return (TabPage)this.GetType()
                .GetField(tabName, BindingFlags.NonPublic | BindingFlags.Instance)
                .GetValue(this);
        }

        public void Объекты_Load()
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "autoPartsDataSet.Запасные_части". При необходимости она может быть перемещена или удалена.
            this.запасные_частиTableAdapter.Fill(this.autoPartsDataSet.Запасные_части);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "autoPartsDataSet.Заказчик". При необходимости она может быть перемещена или удалена.
            this.заказчикTableAdapter.Fill(this.autoPartsDataSet.Заказчик);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "autoPartsDataSet.Заказчик". При необходимости она может быть перемещена или удалена.
            this.заказчикTableAdapter.Fill(this.autoPartsDataSet.Заказчик);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "autoPartsDataSet.Аналоги". При необходимости она может быть перемещена или удалена.
            this.аналогиTableAdapter.Fill(this.autoPartsDataSet.Аналоги);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "autoPartsDataSet.Автомобили". При необходимости она может быть перемещена или удалена.
            this.автомобилиTableAdapter.Fill(this.autoPartsDataSet.Автомобили);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "autoPartsDataSet.Vin_коды". При необходимости она может быть перемещена или удалена.
            this.vin_кодыTableAdapter.Fill(this.autoPartsDataSet.Vin_коды);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "autoPartsDataSet.Заказы". При необходимости она может быть перемещена или удалена.
            this.заказыTableAdapter.Fill(this.autoPartsDataSet.Заказы);
        }

        private void Объекты_Load(object sender, System.EventArgs e)
        {

        }
    }
}
