﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;


namespace AutoParts
{
    using ФормаОбъекты = AutoParts.Объекты.Объекты;

    public partial class Главная : Form
    {
        private ФормаОбъекты tabControlContainer = new ФормаОбъекты();

        private Dictionary<object, string> formControlTabControlMap = new Dictionary<object, string>();

        private Point _imageLication = new Point(13, 5);
        private Point _imageArea = new Point(13, 2);
        Image CloseImage;

        public Главная()
        {
            InitializeComponent();

            var tooltipManager = new ToolTip();
            tooltipManager.SetToolTip(this.pictureBox2, "Заказы");

            this.formControlTabControlMap.Add(this.pictureBox2, "tabPage3");

            this.formControlTabControlMap.Add(this.заказыToolStripMenuItem, "tabPage3");
            this.formControlTabControlMap.Add(this.vinКодыToolStripMenuItem, "tabPage1");
            this.formControlTabControlMap.Add(this.автомобилиToolStripMenuItem, "tabPage2");
            this.formControlTabControlMap.Add(this.аналогиToolStripMenuItem, "tabPage4");
            this.formControlTabControlMap.Add(this.заказчикиToolStripMenuItem, "tabPage5");
            this.formControlTabControlMap.Add(this.запасныеЧастиToolStripMenuItem, "tabPage6");

            this.tabControl.DrawMode = TabDrawMode.OwnerDrawFixed;
            this.tabControl.DrawItem += tabControl_DrawItem;
            this.CloseImage = AutoParts.Properties.Resources.J_Je0r0q30444c;
            this.tabControl.Padding = new Point(10, 3);
        }

        /// <summary>
        /// Добавляет на текущую форму tabControl из невидимой формы,
        /// изходя из соответствий в <see cref="formControlTabControlMap"/>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddTabControl(object sender, EventArgs e)
        {
            if (!this.formControlTabControlMap.TryGetValue(sender, out var tabName))
            {
                var senderAsControl = sender as Control;
                var errorMessage = $"Не найдено соответствие для объекта " +
                    $"{senderAsControl?.Name ?? sender.GetType().Name}";
                throw new Exception(errorMessage);
            }

            var newOrExistsTabControl = this.tabControlContainer.GetTabByName(tabName);
            var tabPageCollection = this.tabControl.TabPages;
            if (!tabPageCollection.Contains(newOrExistsTabControl))
            {
                tabPageCollection.Add(newOrExistsTabControl);
            }

            // Делаем вкладку активной
            this.tabControl.SelectedTab = newOrExistsTabControl;
            this.tabControl.Visible = true;
        }

        private void tabControl_DrawItem(object sender, System.Windows.Forms.DrawItemEventArgs e)
        {
            Image img = new Bitmap(this.CloseImage);
            Rectangle r = e.Bounds;
            r = this.tabControl.GetTabRect(e.Index);
            r.Offset(2, 2);
            string title = this.tabControl.TabPages[e.Index].Text;
            Font f = this.Font;
            Brush titleBrush = new SolidBrush(Color.Black);
            e.Graphics.DrawString(title, f, titleBrush, new PointF(r.X, r.Y));

            e.Graphics.DrawImage(img, new Point(r.X + (this.tabControl.GetTabRect(e.Index).Width - this._imageLication.X),
                this._imageLication.Y));
        }

        private void tabControl_MouseClick(object sender, MouseEventArgs e)
        {
            TabControl tc = (TabControl)sender;
            Point p = e.Location;
            int _tabWidth = 0;
            _tabWidth = this.tabControl.GetTabRect(tc.SelectedIndex).Width - (this._imageArea.X);
            Rectangle r = this.tabControl.GetTabRect(tc.SelectedIndex);
            r.Offset(_tabWidth, this._imageArea.Y);
            r.Width = 16;
            r.Height = 16;
            if (r.Contains(p))
            {
                TabPage tabP = (TabPage)tc.TabPages[tc.SelectedIndex];
                tc.TabPages.Remove(tabP);

            }
        }

        private void Главная_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                DialogResult dialogResult = MessageBox.Show("Вы действиетльно хотите выйти?",
                    "Закрытие программы", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dialogResult == DialogResult.Yes)
                {
                    Application.Exit();
                }
                else e.Cancel = true;
            }
            else Application.Exit();
        }

        private void резервнаяКопияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dataBasePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\AutoParts.mdb";
            var saveDialog = new SaveFileDialog
            {
                FileName = "AutoParts - копия.mdb",
                Filter = "AccessDB files|*.mdb"
            };
            try
            {
                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    File.Copy(dataBasePath, saveDialog.FileName, true);
                    MessageBox.Show("Резервное копирование прошло успешно!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("Не удаётся скопировать файл из-за исключения: " + exception.Message);
            }
        }
    }
}
