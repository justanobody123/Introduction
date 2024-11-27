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
using System.Runtime.Remoting.Channels;
namespace AcademyDataSet
{
	public partial class MainForm : Form
	{
		string connectionString = "";
		SqlConnection connection = null;
		DataSet GroupsRelatedData = null;
		public MainForm()
		{
			InitializeComponent();
			AllocConsole();
			connectionString = ConfigurationManager.ConnectionStrings["Academy_PD_311"].ConnectionString;
            Console.WriteLine(connectionString);
			connection = new SqlConnection(connectionString);
			LoadGroupsRelatedData();
			comboBoxDirection.DataSource = GroupsRelatedData.Tables["Directions"];
			comboBoxDirection.DisplayMember = "direction_name";
			comboBoxDirection.ValueMember = "direction_id";
			comboBoxDirection.SelectedIndex = 0;

			comboBoxGroup.DataSource = GroupsRelatedData.Tables["Groups"];
			comboBoxGroup.DisplayMember = "group_name";
			comboBoxGroup.ValueMember = "group_id";
			comboBoxGroup.SelectedIndex = 0;
        }
		void LoadGroupsRelatedData()
		{
			Console.WriteLine("Hello, DataSet");

			GroupsRelatedData = new DataSet(nameof(GroupsRelatedData));

			const string dsTable_Directions = "Directions";
			const string directionsCol_direction_id = "direction_id";
			const string directionsCol_direction_name = "direction_name";
			GroupsRelatedData.Tables.Add(dsTable_Directions);
			GroupsRelatedData.Tables[dsTable_Directions].Columns.Add(directionsCol_direction_id, typeof(short));
			GroupsRelatedData.Tables[dsTable_Directions].Columns.Add(directionsCol_direction_name, typeof(string));
			GroupsRelatedData.Tables[dsTable_Directions].PrimaryKey = new DataColumn[]
			{
				GroupsRelatedData.Tables[dsTable_Directions].Columns[directionsCol_direction_id]
			};

			const string dsTable_Groups = "Groups";
			const string groupsCol_group_id = "group_id";
			const string groupsCol_group_name = "group_name";
			const string groupsCol_direction = "direction";
			GroupsRelatedData.Tables.Add(dsTable_Groups);
			GroupsRelatedData.Tables[dsTable_Groups].Columns.Add(groupsCol_group_id, typeof(int));
			GroupsRelatedData.Tables[dsTable_Groups].Columns.Add(groupsCol_group_name, typeof(string));
			GroupsRelatedData.Tables[dsTable_Groups].Columns.Add(groupsCol_direction, typeof(short));
			GroupsRelatedData.Tables[dsTable_Groups].PrimaryKey = new DataColumn[]
			{
				GroupsRelatedData.Tables[dsTable_Groups].Columns[groupsCol_group_id]
			};


			//GroupsRelatingData
			string directionCmd = "SELECT * FROM Directions";
			string groupsCmd = "SELECT group_id, group_name, direction FROM Groups";
			SqlDataAdapter directionsAdapter = new SqlDataAdapter(directionCmd, connection);
			SqlDataAdapter groupsAdapter = new SqlDataAdapter(groupsCmd, connection);
			connection.Open();
			directionsAdapter.Fill(GroupsRelatedData.Tables[dsTable_Directions]);
			groupsAdapter.Fill(GroupsRelatedData.Tables[dsTable_Groups]);
			connection.Close();

			GroupsRelatedData.Relations.Add
				(
				"GroupsDirections",
				GroupsRelatedData.Tables[dsTable_Directions].Columns[directionsCol_direction_id],
				GroupsRelatedData.Tables[dsTable_Groups].Columns[groupsCol_direction]
				);

			foreach (DataRow row in GroupsRelatedData.Tables[dsTable_Directions].Rows)
			{
				Console.WriteLine($"{row[directionsCol_direction_id]}\t{row[directionsCol_direction_name]}");
			}
			Console.WriteLine("\n-----------------------------------------------\n");
			for (int i = 0; i < GroupsRelatedData.Tables[dsTable_Groups].Rows.Count; i++)
			{
				for (int j = 0; j < GroupsRelatedData.Tables[dsTable_Groups].Columns.Count; j++)
				{
					Console.Write($"{GroupsRelatedData.Tables[dsTable_Groups].Rows[i][j].ToString().PadRight(16)}");
				}
				Console.WriteLine();
			}
			Console.WriteLine("\n-----------------------------------------------\n");
			for (int i = 0; i < GroupsRelatedData.Tables[dsTable_Directions].Rows.Count; i++)
			{
				Console.WriteLine($"{GroupsRelatedData.Tables[dsTable_Directions].Rows[i][directionsCol_direction_name]}:");
				DataRow[] children = GroupsRelatedData.Tables[dsTable_Directions].Rows[i].GetChildRows("GroupsDirections");
				for (int j = 0; j < children.Length; j++)
				{
					Console.Write(children[j][groupsCol_group_name] + "\t");
				}
				Console.WriteLine(";");
			}
		}
		[DllImport("kernel32.dll")]
		static extern bool AllocConsole();

		private void comboBoxDirection_SelectedIndexChanged(object sender, EventArgs e)
		{
			object selectedValue = (sender as ComboBox).SelectedValue;
			string to_string = selectedValue.ToString();
			string get_type = selectedValue.GetType().ToString();
			if (selectedValue.ToString() != selectedValue.GetType().ToString())
			{
				string filter = $"direction = {selectedValue.ToString()}";
				GroupsRelatedData.Tables["Groups"].DefaultView.RowFilter = filter;
			}
			
        }
	}
}
