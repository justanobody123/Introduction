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
		public static Dictionary<string, int> directions;
		public static Dictionary<string, int> learningForms;
		static Connector()
		{
			connection = new SqlConnection(connectionString);
			learningForms = LoadTableToDictionary("form_id", "form_name", "LearningForms");
			directions = LoadTableToDictionary("direction_id", "direction_name", "Directions");
			//initializeDirectionsDictionary();
			//initializeLearningFormsDictionary();
		}
		public static Dictionary<string, int> LoadTableToDictionary(string id, string value, string table)
		{
			Dictionary<string, int> dictionary = new Dictionary<string, int>();
			string cmd = $"SELECT {id}, {value} FROM {table}";
			SqlCommand comamnd = new SqlCommand(cmd, connection);
			connection.Open();
			SqlDataReader reader = comamnd.ExecuteReader();
			if (reader.HasRows)
			{
				while (reader.Read())
				{
					dictionary.Add(reader[1].ToString(), Convert.ToInt32(reader[0]));
				}
			}
			reader.Close();
			connection.Close();
			return dictionary;
		}
		static void initializeDirectionsDictionary()
		{
			//directions = new Dictionary<string, int>();
			DataTable table = Connector.Select("direction_name, direction_id", "Directions");
			for (int i = 0; i < table.Rows.Count; i++)
			{

				directions.Add(table.Rows[i]["direction_name"].ToString(), Convert.ToInt32(table.Rows[i]["direction_id"]));
#if DEBUG
				Console.WriteLine(table.Rows[i]["direction_name"].ToString().PadRight(60) + table.Rows[i]["direction_id"].ToString());
#endif
			}
		}
		static void initializeLearningFormsDictionary()
		{
			//learningForms = new Dictionary<string, int>();
			DataTable table = Connector.Select("form_name, form_id", "LearningForms");
			for (int i = 0; i < table.Rows.Count; i++)
			{
				learningForms.Add(table.Rows[i]["form_name"].ToString(), Convert.ToInt32(table.Rows[i]["form_id"]));
#if DEBUG
				Console.WriteLine(table.Rows[i]["form_name"].ToString().PadRight(60) + table.Rows[i]["form_id"].ToString());
#endif
			}
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
		//public static void InsertGroup(string groupName, int direction_id)
		//{
		//	string cmd = $"IF NOT EXISTS(SELECT 1 FROM Groups WHERE group_name = @group_name AND direction = @direction)" +
		//		$"BEGIN " +
		//		$"INSERT Groups(group_name, direction)" +
		//		$" VALUES(@group_name, @direction)" +
		//		$"END";
		//	SqlCommand command = new SqlCommand(cmd, connection);
		//	connection.Open();
		//	command.Parameters.Add("@group_name", SqlDbType.NVarChar, 16).Value = groupName;
		//	command.Parameters.Add("@direction", SqlDbType.SmallInt).Value = direction_id;
		//	command.ExecuteNonQuery();
		//	command.Dispose();
		//	connection.Close();
		//}
		public static void InsertGroup(Group group)
		{
string cmd = "IF NOT EXISTS (SELECT group_id FROM Groups WHERE group_name = @group_name) " +
				"BEGIN " +
				"INSERT Groups (group_name, start_date, learning_time, direction, learning_form, learning_days) " +
					$"VALUES(@group_name, @start_date, @learning_time, @direction, @learning_form, @learning_days) " +
				"END";
			SqlCommand command = new SqlCommand(cmd, connection);
			command.Parameters.Add("@group_name", SqlDbType.NVarChar, 16).Value = group.GroupName;
			command.Parameters.Add("@start_date", SqlDbType.Date).Value = group.StartDate;
			command.Parameters.Add("@learning_time", SqlDbType.Time).Value = group.LearningTime;
			command.Parameters.Add("@direction", SqlDbType.SmallInt).Value = group.Direction;
			command.Parameters.Add("@learning_form", SqlDbType.TinyInt).Value = group.LearningForm;
			command.Parameters.Add("@learning_days", SqlDbType.TinyInt).Value = group.LearningDays;
			connection.Open();
			command.ExecuteNonQuery();
			connection.Close();
		}
		public static void UpdateGroup(Group group)
		{
			//int form_id = learningForms[learning_form];
			////DataTable form = Select("form_id", "LearningForms", $"form_name = '{learning_form}'");
			//int direction_id = directions[direction];
			////DataTable group_direction = Select("direction_id", "Directions", $"direction_name = '{direction}'");

			//string cmd = @"UPDATE Groups
			//                SET 
			//                    group_name = @group_name, 
			//                    direction = @direction, 
			//                    learning_form = @learning_form, 
			//                    start_date = @start_date, 
			//                    learning_time = @learning_time, 
			//                    learning_days = @learning_days
			//                WHERE group_id = @id";

			//SqlCommand command = new SqlCommand(cmd, connection);
			//command.Parameters.Add("@id", SqlDbType.Int).Value = id;
			//command.Parameters.Add("@group_name", SqlDbType.NVarChar, 16).Value = group_name;
			//command.Parameters.Add("@learning_form", SqlDbType.TinyInt).Value = form_id;
			//command.Parameters.Add("@start_date", SqlDbType.Date).Value = start_date;
			//command.Parameters.Add("@learning_time", SqlDbType.Time).Value = learning_time;
			//command.Parameters.Add("@learning_days", SqlDbType.TinyInt).Value = learning_days;
			//command.Parameters.Add("@direction", SqlDbType.SmallInt).Value = direction_id;

			//connection.Open();
			//command.ExecuteNonQuery();
			//connection.Close();
			Console.Write(group.ID + " " + group.GroupName + " " + group.LearningTime + " ");
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
			command.Parameters.Add("@id", SqlDbType.Int).Value = group.ID;
			command.Parameters.Add("@group_name", SqlDbType.NVarChar, 16).Value = group.GroupName;
			command.Parameters.Add("@learning_form", SqlDbType.TinyInt).Value = group.LearningForm;
			command.Parameters.Add("@start_date", SqlDbType.Date).Value = group.StartDate;
			command.Parameters.Add("@learning_time", SqlDbType.Time).Value = group.LearningTime;
			command.Parameters.Add("@learning_days", SqlDbType.TinyInt).Value = group.LearningDays;
			command.Parameters.Add("@direction", SqlDbType.SmallInt).Value = group.Direction;
			connection.Open();
			command.ExecuteNonQuery();
			connection.Close();
			//string selectCmd = $"SELECT group_name start_date, learning_time, direction, learning_form, learning_days FROM Groups WHERE group_id = {group.ID}";
			//SqlCommand selectCommand = new SqlCommand(selectCmd, connection);

			//SqlDataReader reader = selectCommand.ExecuteReader();
			//DataTable table = new DataTable();
			//for (int i = 0; i < reader.FieldCount; i++)
			//{
			//	table.Columns.Add(reader.GetName(i));
			//}
			//DataRow row = table.NewRow();
			//for (int i = 0; i < reader.FieldCount; i++)
			//{
			//	row[i] = reader[i];
			//}
			//table.Rows.Add(row);
			//reader.Close();

			//return table;
		}
	}
}
