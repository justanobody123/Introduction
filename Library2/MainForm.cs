using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using System.Runtime.InteropServices;

namespace Library2
{
	public partial class MainForm : Form
	{
		string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString_2_Library_PD_311"].ConnectionString;
		SqlConnection connection;
		public MainForm()
		{
			connection = new SqlConnection(connectionString);
#if DEBUG
			AllocConsole(); 
#endif
			InitializeComponent();
			textBoxQuery.Text = "SELECT * FROM Authors";
			InitializeComboBoxTables();
		}
		void InitializeComboBoxTables()
		{
			connection.Open();
			DataTable tables = connection.GetSchema("Tables");
#if DEBUG
			Console.WriteLine("tables.Rows.Count = " + tables.Rows.Count); 
#endif
			foreach (DataRow row in tables.Rows)
			{
				comboBoxTables.Items.Add(row[2].ToString());
#if DEBUG
				Console.WriteLine("table name - " + row[2].ToString()); 
#endif
			}
			connection.Close();
		}
		private void buttonExecute_Click(object sender, EventArgs e)
		{
			string cmd = textBoxQuery.Text;
			SqlCommand command = new SqlCommand(cmd, connection);
			connection.Open();
			DataTable table = new DataTable();
			SqlDataReader reader = command.ExecuteReader();
			for (int i = 0; i < reader.FieldCount; i++)
			{
				table.Columns.Add(reader.GetName(i));
			}
			while (reader.Read())
			{
				DataRow row = table.NewRow();
				for (int i = 0; i < reader.FieldCount; i++)
				{
					row[i] = reader[i];
				}
				table.Rows.Add(row);
			}
			reader.Close();
			connection.Close();
			dataGridView.DataSource = table;
		}

		///////////////////////////////////////////////
		[DllImport("kernel32.dll")]
		static extern bool AllocConsole();

		private void buttonComboBoxTable_Click(object sender, EventArgs e)
		{
			if (comboBoxTables.SelectedIndex != -1)
			{
				string cmd = $"SELECT * FROM [{comboBoxTables.SelectedItem.ToString()}]";
#if DEBUG
				Console.WriteLine(cmd);
#endif
				SqlCommand command = new SqlCommand(cmd, connection);
				connection.Open();
				DataTable table = new DataTable();
				SqlDataReader reader = command.ExecuteReader();
				for (int i = 0; i < reader.FieldCount; i++)
				{
					table.Columns.Add(reader.GetName(i));
				}
				while (reader.Read())
				{
					DataRow row = table.NewRow();
					for (int i = 0; i < reader.FieldCount; i++)
					{
						row[i] = reader[i];
					}
					table.Rows.Add(row);
				}
				reader.Close();
				connection.Close();
				dataGridView.DataSource = table;
			}
		}
	}
}
