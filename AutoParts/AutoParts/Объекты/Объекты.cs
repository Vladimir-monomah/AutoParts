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
            // TODO: данная строка кода позволяет загрузить данные в таблицу "autoPartsDataSet.Заказы". При необходимости она может быть перемещена или удалена.
            this.заказыTableAdapter.Fill(this.autoPartsDataSet.Заказы);
        }

        private void Объекты_Load(object sender, System.EventArgs e)
        {

        }
    }
}
