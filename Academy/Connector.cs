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
		public static List<string> SelectColumn(string column, string table)
		{
			List<string> values = new List<string>();
			string cmd = $"SELECT {column} FROM {table}";
			SqlCommand command = new SqlCommand(cmd, connection);
			connection.Open();
			SqlDataReader reader = command.ExecuteReader();
			if (reader.HasRows)
			{
				while (reader.Read())
				{
					values.Add(reader[0].ToString());
				}
			}
			reader.Close();
			connection.Close();
			return values;
		}
		public static void InsertGroup(string groupName, int direction_id)
		{
			string cmd = $"IF NOT EXISTS(SELECT 1 FROM Groups WHERE group_name = @group_name AND direction = @direction)" +
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
		public static void AlterGroup(int id, string group_name, string direction, string learning_form, DateTime start_date, TimeSpan learning_time, byte learning_days)
		{
			DataTable form = Select("form_id", "LearningForms", $"form_name = '{learning_form}'");
			DataTable group_direction = Select("direction_id", "Directions", $"direction_name = '{direction}'");

			string cmd = @"UPDATE Groups
                   SET 
                       group_name = @group_name, 
                       direction = @direction, 
                       learning_form = @learning_form, 
                       start_date = @start_date, 
                       learning_time = @learning_time, 
                       learning_days = @learning_days
                   WHERE group_id = @id";

			SqlCommand command = new SqlCommand(cmd, connection);
			command.Parameters.Add("@id", SqlDbType.Int).Value = id;
			command.Parameters.Add("@group_name", SqlDbType.NVarChar, 16).Value = group_name;
			command.Parameters.Add("@learning_form", SqlDbType.TinyInt).Value = form.Rows[0]["form_id"];
			command.Parameters.Add("@start_date", SqlDbType.Date).Value = start_date;
			command.Parameters.Add("@learning_time", SqlDbType.Time).Value = learning_time;
			command.Parameters.Add("@learning_days", SqlDbType.TinyInt).Value = learning_days;
			command.Parameters.Add("@direction", SqlDbType.SmallInt).Value = group_direction.Rows[0]["direction_id"];

			connection.Open();
			command.ExecuteNonQuery();
			connection.Close();
		}
	}
}
