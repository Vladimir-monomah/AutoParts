using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoParts.AutoPartsDataSetTableAdapters;
using static AutoParts.AutoPartsDataSet;
using System.Data.OleDb;
using System.Data;

namespace AutoParts
{
    public class EntityManager
    {
        static AutoPartsDataSet AutoPartsDataSet = new AutoPartsDataSet();

        private static Vin_кодыTableAdapter vin_КодыTableAdapter = new Vin_кодыTableAdapter();
        private static АвтомобилиTableAdapter АвтомобилиTableAdapter = new АвтомобилиTableAdapter();
        private static АналогиTableAdapter АналогиTableAdapter = new АналогиTableAdapter();
        private static ЗаказчикTableAdapter ЗаказчикTableAdapter = new ЗаказчикTableAdapter();
        private static ЗаказыTableAdapter ЗаказыTableAdapter = new ЗаказыTableAdapter();
        private static Запасные_частиTableAdapter запасные_ЧастиTableAdapter = new Запасные_частиTableAdapter();

        public static Vin_кодыDataTable Vin_кодыDataTable
        {
            get
            {
                return AutoPartsDataSet.Vin_коды;
            }
        }

        public static АвтомобилиDataTable АвтомобилиDataTable
        {
            get
            {
                return AutoPartsDataSet.Автомобили;
            }
        }

        public static АналогиDataTable АналогиDataTable
        {
            get
            {
                return AutoPartsDataSet.Аналоги;
            }
        }

        public static ЗаказчикDataTable ЗаказчикDataTable
        {
            get
            {
                return AutoPartsDataSet.Заказчик;
            }
        }

        public static ЗаказыDataTable ЗаказыDataTable
        {
            get
            {
                return AutoPartsDataSet.Заказы;
            }
        }

        public static Запасные_частиDataTable Запасные_частиDataTable
        {
            get
            {
                return AutoPartsDataSet.Запасные_части;
            }
        }

        public static void UpdateVin_коды()
        {
            vin_КодыTableAdapter.Adapter.Update(Vin_кодыDataTable);
        }

        public static void UpdateАвтомобили()
        {
            АвтомобилиTableAdapter.Adapter.Update(АвтомобилиDataTable);
        }

        public static void UpdateАналоги()
        {
            АналогиTableAdapter.Adapter.Update(АналогиDataTable);
        }

        public static void UpdateЗаказчик()
        {
            ЗаказчикTableAdapter.Adapter.Update(ЗаказчикDataTable);
        }

        public static void UpdateЗаказы()
        {
            ЗаказыTableAdapter.Adapter.Update(ЗаказыDataTable);
        }

        public static void UpdateЗапасные_части()
        {
            запасные_ЧастиTableAdapter.Adapter.Update(Запасные_частиDataTable);
        }

        /// <summary>
        /// Возвращает отфильтрованную таблицу Vin кодов по условию <paramref name="condition"/>
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public static Vin_кодыDataTable FilterVin_коды(string condition = null)
        {
            var whereCondition = string.Empty;
            if (!string.IsNullOrEmpty(condition))
            {
                whereCondition = $"WHERE {condition}";
            }

            var filterUserCommand = new OleDbCommand()
            {
                Connection = vin_КодыTableAdapter.Connection,
                CommandText = "SELECT [№ п/п], [Vin код], Год" +
                $" FROM [Vin_коды] {whereCondition}",
                CommandType = global::System.Data.CommandType.Text
            };

            FillFilteredTable(vin_КодыTableAdapter.Adapter, filterUserCommand, Vin_кодыDataTable);

            return Vin_кодыDataTable;
        }

        /// <summary>
        /// Возвращает отфильтрованную таблицу Vin кодов по условию <paramref name="condition"/>
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public static АвтомобилиDataTable FilterАвтомобили(string condition = null)
        {
            var whereCondition = string.Empty;
            if (!string.IsNullOrEmpty(condition))
            {
                whereCondition = $"WHERE {condition}";
            }

            var filterUserCommand = new OleDbCommand()
            {
                Connection = АвтомобилиTableAdapter.Connection,
                CommandText = "SELECT [Id_авто], [Название авто], [Модель авто], [Год выпуска], " +
                "[Объем двигателя], [Vin код], [Номер детали]" +
                $" FROM [Автомобили] {whereCondition}",
                CommandType = global::System.Data.CommandType.Text
            };

            FillFilteredTable(АвтомобилиTableAdapter.Adapter, filterUserCommand, АвтомобилиDataTable);

            return АвтомобилиDataTable;
        }

        /// <summary>
        /// Возвращает отфильтрованную таблицу Vin кодов по условию <paramref name="condition"/>
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public static АналогиDataTable FilterАналоги(string condition = null)
        {
            var whereCondition = string.Empty;
            if (!string.IsNullOrEmpty(condition))
            {
                whereCondition = $"WHERE {condition}";
            }

            var filterUserCommand = new OleDbCommand()
            {
                Connection = АналогиTableAdapter.Connection,
                CommandText = "SELECT [№ п/п], [Номер аналога], Наименование" +
                $" FROM Аналоги {whereCondition}",
                CommandType = global::System.Data.CommandType.Text
            };

            FillFilteredTable(АналогиTableAdapter.Adapter, filterUserCommand, АналогиDataTable);

            return АналогиDataTable;
        }

        /// <summary>
        /// Возвращает отфильтрованную таблицу Vin кодов по условию <paramref name="condition"/>
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public static ЗаказчикDataTable FilterЗаказчик(string condition = null)
        {
            var whereCondition = string.Empty;
            if (!string.IsNullOrEmpty(condition))
            {
                whereCondition = $"WHERE {condition}";
            }

            var filterUserCommand = new OleDbCommand()
            {
                Connection = ЗаказчикTableAdapter.Connection,
                CommandText = "SELECT [№ п/п], Реквизиты, [Контактное лицо], " +
                "[№ счета], [№ телефона], [Название авто], [Модель авто]" +
                $" FROM Заказчик {whereCondition}",
                CommandType = global::System.Data.CommandType.Text
            };

            FillFilteredTable(ЗаказчикTableAdapter.Adapter, filterUserCommand, ЗаказчикDataTable);

            return ЗаказчикDataTable;
        }

        /// <summary>
        /// Возвращает отфильтрованную таблицу Vin кодов по условию <paramref name="condition"/>
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public static ЗаказыDataTable FilterЗаказы(string condition = null)
        {
            var whereCondition = string.Empty;
            if (!string.IsNullOrEmpty(condition))
            {
                whereCondition = $"WHERE {condition}";
            }

            var filterUserCommand = new OleDbCommand()
            {
                Connection = ЗаказыTableAdapter.Connection,
                CommandText = "SELECT [Id_заказа], [Дата счета], [№ счета], " +
                "[ФИО_Заказчика], [ФИО_Поставщика], [Всего по счету]" +
                $" FROM Заказы {whereCondition}",
                CommandType = global::System.Data.CommandType.Text
            };

            FillFilteredTable(ЗаказыTableAdapter.Adapter, filterUserCommand, ЗаказыDataTable);

            return ЗаказыDataTable;
        }

        /// <summary>
        /// Возвращает отфильтрованную таблицу Vin кодов по условию <paramref name="condition"/>
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public static Запасные_частиDataTable FilterЗапасные_части(string condition = null)
        {
            var whereCondition = string.Empty;
            if (!string.IsNullOrEmpty(condition))
            {
                whereCondition = $"WHERE {condition}";
            }

            var filterUserCommand = new OleDbCommand()
            {
                Connection = запасные_ЧастиTableAdapter.Connection,
                CommandText = "SELECT Id, [Дата отгрузки], [Номер детали], " +
                "[Место покупкуи], [Закупочная цена], [Цена отгрузки]" +
                $" FROM [Запасные части] {whereCondition}",
                CommandType = global::System.Data.CommandType.Text
            };

            FillFilteredTable(запасные_ЧастиTableAdapter.Adapter, filterUserCommand, Запасные_частиDataTable);

            return Запасные_частиDataTable;
        }

        /// <summary>
        /// Создает строку для фильтрации: всевозможные комбинации по сравнению предоставленных полей с текстом поиска
        /// </summary>
        /// <param name="fields"></param>
        /// <param name="searchText"></param>
        /// <returns></returns>
        public static string GetFilterStringByFields(string[] fields, string searchText)
        {
            var findValues = string.IsNullOrEmpty(searchText)
                ? new string[] { }
                : searchText.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var filterStrings = new List<string>();
            foreach (var findingField in fields)
            {
                foreach (var findingValue in findValues)
                {
                    filterStrings.Add($"{findingField} LIKE '%{findingValue}%'");
                }
            }

            return string.Join(" OR ", filterStrings);
        }

        /// <summary>
        /// Заполняет таблицу по фильтрующей команде выбора строк
        /// </summary>
        /// <param name="adapter"></param>
        /// <param name="selectCommand"></param>
        /// <param name="table"></param>
        private static void FillFilteredTable(OleDbDataAdapter adapter, OleDbCommand selectCommand, DataTable table)
        {
            var oldSelectComand = adapter.SelectCommand;
            adapter.SelectCommand = selectCommand;

            table.Clear();

            adapter.Fill(table);
            adapter.SelectCommand = oldSelectComand;
        }
    }
}
