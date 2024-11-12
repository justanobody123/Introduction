using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Management;
using System.Windows.Forms;

namespace Academy
{
	internal class Connector
	{
		static readonly string connectionString = ConfigurationManager.ConnectionStrings["Academy_PD_311"].ConnectionString;
		static SqlConnection connection;
		static Connector()
		{
			connection = new SqlConnection(connectionString);
		}
		public static DataTable Select(string columns, string tables, string condition = "")
		{
			DataTable table = new DataTable();
			string cmd = $"SELECT {columns} FROM {tables}";
			if (condition.Length > 0) cmd += $" WHERE {condition}";
			SqlCommand command = new SqlCommand(cmd, connection);
			connection.Open();
			SqlDataReader reader = command.ExecuteReader();
			if (reader.HasRows)
			{
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
			}
			reader.Close();
			connection.Close();
			return table;
		}
		public static void InsertGroup(string groupName, int direction_id)
		{
			string cmd = $"IF NOT EXISTS(SELECT 1 FROM GROUPS WHERE group_name = @group_name AND direction = @direction)" +
				$"BEGIN " +
				$"INSERT Groups(group_name, direction)" +
				$" VALUES(@group_name, @direction)" +
				$"END";
			SqlCommand command = new SqlCommand(cmd, connection);
			connection.Open();
			command.Parameters.Add("@group_name", SqlDbType.NVarChar, 16).Value = groupName;
			command.Parameters.Add("@direction", SqlDbType.SmallInt).Value = direction_id;
			command.ExecuteNonQuery();
			command.Dispose();
			connection.Close();
		}
	}
}
