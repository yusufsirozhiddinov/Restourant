using MySql.Data.MySqlClient;
using Restourant.ViewModels.BaseViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Restourant.Commands
{
    public class ChoseDish : BaseViewModel
    {
        public ChoseDish(string from_tables, string table_column, string columns_content)
        {
            Column_content = columns_content;
            Table_columns = table_column;
            From_table = from_tables;
            Connection();
        }
        private string column_content = "";
        public string Column_content
        {
            get { return column_content; }
            set { Set(ref column_content, value); }
        }
        private string table_columns = "";
        public string Table_columns
        {
            get { return table_columns; }
            set { Set(ref table_columns, value); }
        }
        private string from_table = "";
        public string From_table
        {
            get { return from_table; }
            set { Set(ref from_table, value); }
        }
        public void Connection()
        {
            MySqlConnection connection = new MySqlConnection("server=localhost;userid=root;password=1234;database=foods;");
            connection.Open();
            MySqlCommand cmd = new MySqlCommand($"INSERT INTO {From_table} ({Table_columns}) VALUES({Column_content});", connection);

            cmd.ExecuteNonQuery();
            connection.Close();
        }
    }
}
