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
using System.IO;

namespace Academy
{
	internal class Connector
	{
		static readonly string connectionString = ConfigurationManager.ConnectionStrings["Academy_PD_311"].ConnectionString;
		static SqlConnection connection;
		public static Dictionary<string, int> directions;
		public static Dictionary<string, int> learningForms;
		public static Dictionary<string, int> groups;
		static Connector()
		{
			connection = new SqlConnection(connectionString);
			learningForms = LoadTableToDictionary("form_id", "form_name", "LearningForms");
			directions = LoadTableToDictionary("direction_id", "direction_name", "Directions");
			groups = LoadTableToDictionary("group_id", "group_name", "Groups");
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
		public static void InsertStudent(Student student)
		{
			//Я не буду запихивать сюда иф нот экзистс, потому что может быть такая вероятность, что у разных людей совпадают все табличные данные. Ну а вдруг кто-то близнецов по приколу одним именем назвал.
			string cmd =	@"INSERT Students (first_name, last_name, middle_name, [group], birth_date)
							VALUES(@first_name, @last_name, @middle_name, @group, @birth_date)";
			SqlCommand command = new SqlCommand (cmd, connection);
			command.Parameters.Add("@first_name", SqlDbType.NVarChar, 150).Value = student.FirstName;
			command.Parameters.Add("@last_name", SqlDbType.NVarChar, 150).Value = student.LastName;
			command.Parameters.Add("@middle_name", SqlDbType.NVarChar, 150).Value = student.MiddleName;
			command.Parameters.Add("@group", SqlDbType.Int).Value = student.GroupID;
			command.Parameters.Add("@birth_date", SqlDbType.Date).Value = student.BirthDate;
			connection.Open();
			command.ExecuteNonQuery();
			connection.Close();
		}
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
		public static void UpdateStudent(Student student)
		{
			string updateCmd = @"UPDATE Students
								SET
									first_name = @first_name,
									last_name = @last_name,
									middle_name = @middle_name,
									birth_date = @birth_date,
									[group] = @group
								WHERE student_id = @id";
			SqlCommand command = new SqlCommand(updateCmd, connection);
			command.Parameters.Add("@first_name", SqlDbType.NVarChar, 150).Value = student.FirstName;
			command.Parameters.Add("@last_name", SqlDbType.NVarChar, 150).Value = student.LastName;
			command.Parameters.Add("@middle_name", SqlDbType.NVarChar, 150).Value = student.MiddleName;
			command.Parameters.Add("@birth_date", SqlDbType.Date).Value = student.BirthDate;
			command.Parameters.Add("@group", SqlDbType.Int).Value = student.GroupID;
			command.Parameters.Add("@id", SqlDbType.BigInt).Value = student.ID;
			connection.Open();
			command.ExecuteNonQuery();
			connection.Close();
			//DataTable table = Select("student_id, last_name, first_name, middle_name, birth_date, [age] = DATEDIFF(DAY, birth_date, GETDATE()) / 365, group_name, direction_name",
			//	"Students, Groups, Directions",
			//	$"[group] = group_id AND direction = direction_id AND student_id = {student.ID}");
			//for (int i = 0; i < table.Columns.Count; i++)
			//{
			//	
   //         }
			//return table.Rows[0].ItemArray;
		}
		public static object[] UpdateGroup(Group group)
		{
			Console.Write(group.ID + " " + group.GroupName + " " + group.LearningTime + " ");
			string updateCmd = @"UPDATE Groups
			                SET 
			                    group_name = @group_name, 
			                    direction = @direction, 
			                    learning_form = @learning_form, 
			                    start_date = @start_date, 
			                    learning_time = @learning_time, 
			                    learning_days = @learning_days
			                WHERE group_id = @id";
			SqlCommand command = new SqlCommand(updateCmd, connection);
			command.Parameters.Add("@id", SqlDbType.Int).Value = group.ID;
			command.Parameters.Add("@group_name", SqlDbType.NVarChar, 16).Value = group.GroupName;
			command.Parameters.Add("@learning_form", SqlDbType.TinyInt).Value = group.LearningForm;
			command.Parameters.Add("@start_date", SqlDbType.Date).Value = group.StartDate;
			command.Parameters.Add("@learning_time", SqlDbType.Time).Value = group.LearningTime;
			command.Parameters.Add("@learning_days", SqlDbType.TinyInt).Value = group.LearningDays;
			command.Parameters.Add("@direction", SqlDbType.SmallInt).Value = group.Direction;


			//string selectCmd = $"SELECT group_id, group_name, start_date, learning_time, direction_name, form_name, learning_days FROM Groups, Directions, LearningForms WHERE group_id = {group.ID} AND direction = direction_id AND learning_form = form_id";
			//SqlCommand selectCommand = new SqlCommand(selectCmd, connection);
			//connection.Open();
			//command.ExecuteNonQuery();
			//SqlDataReader reader = selectCommand.ExecuteReader();
			//DataTable table = new DataTable();
			//for (int i = 0; i < reader.FieldCount; i++)
			//{
			//	table.Columns.Add(reader.GetName(i));
			//}
			//reader.Read();
			//DataRow row = table.NewRow();
			//for (int i = 0; i < reader.FieldCount; i++)
			//{
			//	row[i] = reader[i];
			//}
			//table.Rows.Add(row);
			//reader.Close();
			//connection.Close();
			////string selectCmd = $"SELECT group_name start_date, learning_time, direction, learning_form, learning_days FROM Groups WHERE group_id = {group.ID}";
			////
			//Console.WriteLine(table.Rows[0].ItemArray);
			//table.Rows[0][table.Columns.Count - 1] = Week.ExtractDaysToString(Convert.ToByte(table.Rows[0][table.Columns.Count - 1]));


			//return table.Rows[0].ItemArray;

			connection.Open();
			command.ExecuteNonQuery();
			connection.Close();

			DataTable table = Select(
				"group_id, group_name, start_date, learning_time, direction_name, form_name, learning_days",
				"Groups, Directions, LearningForms",
				$"group_id = {group.ID} AND direction = direction_id AND learning_form = form_id"
				);
			table.Rows[0][table.Columns.Count - 1] = Week.ExtractDaysToString(Convert.ToByte(table.Rows[0][table.Columns.Count - 1]));
			return table.Rows[0].ItemArray;
		}
		//Я не могу отслеживать подобным образом редактирование имени группы - непосредственного ключа. Если делать упор на словари, то я бы в целом не стала позволять редачить имя группы.
		public static void UpdateGroupsDictionary(string key)
		{
			//Можно уронить базу инъекцией через интерфейс юзера. В ключ прилетит имя группы.
			int id = Convert.ToInt32(Select("group_id", "Groups", $"group_name = '{key}'").Rows[0]["group_id"]);
			groups.Add(key, id);
		}
		public static byte[] GetImageDataFromBase(int student_id)
		{
			string cmd = "SELECT photo FROM Students WHERE student_id = @id";
			SqlCommand command = new SqlCommand(cmd, connection);
			command.Parameters.Add("id", SqlDbType.BigInt).Value = student_id;
			connection.Open();
			byte[] imageData = command.ExecuteScalar() as byte[];
			connection.Close();
			return imageData;
		}
		public static byte[] GetImageDataFromPictureBox(AddStudentForm form)
		{
			if (form.PictureBox != null)
			{
				using (MemoryStream memoryStream = new MemoryStream())
				{
					form.PictureBox.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Jpeg);
					return memoryStream.ToArray();
				}
			}
			return null;
		}

	}
}
