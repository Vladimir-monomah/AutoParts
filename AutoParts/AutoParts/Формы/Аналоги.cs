using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AutoParts.AutoPartsDataSetTableAdapters;
using AutoParts.Формы;
using static AutoParts.AutoPartsDataSet;

namespace AutoParts.Формы
{
    public partial class Аналоги : Form
    {
        public delegate void OnSave();

        public delegate void OnBeforeSave(АналогиRow isRecordExists);

        public Аналоги()
        {
            this.OnSaveEvent += () => { };
            this.OnBeforeSaveEvent += isRecordExists => { };
            InitializeComponent();
        }

        public event OnSave OnSaveEvent;

        public event OnBeforeSave OnBeforeSaveEvent;

        public void ЗагрузитьАналог(string названиеАналога)
        {
            this.textBoxАnalogue.Text = названиеАналога;
        }

        private bool CheckTextBoxes()
        {
            if (textBoxАnalogue.Text == ""||textBoxNaz.Text=="")
            {
                return false;
            }
            return true;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (!CheckTextBoxes())
            {
                MessageBox.Show("Названия элементов справочника пустое и не будет сохранено.", "Информация",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                return;
            }

            var Аnalogue = this.textBoxАnalogue.Text;
            var adapter = new АналогиTableAdapter();
            adapter.Fill(EntityManager.АналогиDataTable);
            АналогиRow existingАnalogue = null;
            foreach (var analogue in EntityManager.АналогиDataTable)
            {
                if (analogue.Номер_аналога == Аnalogue)
                {
                    existingАnalogue = analogue;
                    break;
                }
            }
            if (existingАnalogue != null)
            {
                this.OnBeforeSaveEvent(existingАnalogue);
                MessageBox.Show("Аналог с таким названием уже существует!", "Информация", MessageBoxButtons.OK);
                return;
            }

            var newАnalogue = EntityManager.АналогиDataTable.NewАналогиRow();
            newАnalogue.Номер_аналога = Аnalogue;
            newАnalogue.Наименование = textBoxNaz.Text;
            EntityManager.АналогиDataTable.AddАналогиRow(newАnalogue);
            EntityManager.UpdateАналоги();
            this.OnSaveEvent();

            MessageBox.Show("Добавление прошло успешно!", "Информация", MessageBoxButtons.OK);
        }
    }
}
