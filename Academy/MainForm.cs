using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Academy
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			AllocConsole();
			InitializeComponent();
			loadGroups();
			loadStudents();
			SetStatusBarText(dataGridViewStudents.Rows, new EventArgs());
		}
		void loadStudents()
		{
			dataGridViewStudents.Rows.CollectionChanged += new CollectionChangeEventHandler(SetStatusBarText);
			dataGridViewStudents.DataSource = Connector.Select("last_name, first_name, middle_name, birth_date, [age] = DATEDIFF(DAY, birth_date, GETDATE()) / 365, group_name, direction_name", "Students, Groups, Directions", "[group] = group_id AND direction = direction_id");

		}
		void loadGroups()
		{
			dataGridViewGroups.Rows.CollectionChanged += new CollectionChangeEventHandler(SetStatusBarText);
			dataGridViewGroups.DataSource = Connector.Select
				(
					"group_name, COUNT(student_id) AS 'amount', direction_name",
					"Groups, Directions, Students",
					"direction = direction_id AND [group] = group_id GROUP BY [group_name], direction_name"
				);
			//comboBoxGroupsDirections.Items.AddRange(Connector.Select(
				//"direction_name",
				//"Directions"
				//).Rows.Cast<DataRow>().ToArray().Cast<string>().ToArray());
		}
		void SetStatusBarText(object sender, EventArgs e)
		{
			toolStripStatusLabelStudentsCount.Text = $"Number of {(tabControlMain.SelectedTab.Text.ToLower())}: {(sender as DataGridViewRowCollection).Count - 1}";
			//toolStripStatusLabelStudentsCount.Text = $"Number of {(tabControlMain.SelectedTab.Text.ToLower())}: {dataGridViewStudents.RowCount}";
		}

		private void textBoxSearchStudents_TextChanged(object sender, EventArgs e)
		{
			string[] values = (sender as TextBox).Text.Split(' ');
			if (values.Length > 1) values = values.Where(v => v != "").ToArray();
			string searchPattern = "";
			switch (values.Length)
			{
				case 1:
					searchPattern = $"(last_name LIKE N'{values[0]}%' OR first_name LIKE N'{values[0]}%' OR middle_name LIKE N'{values[0]}%')";
					break;			  
				case 2:				  
					searchPattern = $"(last_name LIKE N'{values[0]}%' OR first_name LIKE N'{values[0]}%' AND first_name LIKE N'{values[1]}%' OR middle_name LIKE N'{values[1]}%')";
					break;			  
				case 3:				  
					searchPattern = $"(last_name LIKE N'{values[0]}%' AND first_name LIKE N'{values[1]}%' AND middle_name LIKE N'{values[2]}%')";
					break;
			}
			

			dataGridViewStudents.DataSource = Connector.Select(
				"last_name, first_name, middle_name, birth_date, group_name, direction_name",
				"Students, Directions, Groups",
				$"[group] = group_id AND direction = direction_id AND {searchPattern}"
				);

			//HW
			//if (textBoxSearchStudents.Text != "")
			//{
			//	dataGridViewStudents.DataSource = Connector.Select("last_name, first_name, middle_name, birth_date, [age] = DATEDIFF(DAY, birth_date, GETDATE()) / 365, group_name, direction_name",
			//		"Students, Groups, Directions",
			//		$"[group] = group_id AND direction = direction_id AND (last_name LIKE N'%{textBoxSearchStudents.Text}%' OR first_name LIKE N'%{textBoxSearchStudents.Text}%' OR middle_name LIKE N'%{textBoxSearchStudents.Text}%'))");
			//}
			//else
			//{
			//	dataGridViewStudents.DataSource = Connector.Select("last_name, first_name, middle_name, birth_date, [age] = DATEDIFF(DAY, birth_date, GETDATE()) / 365, group_name, direction_name",
			//		"Students, Groups, Directions",
			//		"[group] = group_id AND direction = direction_id");
			//}
		}
		//Вроде работает
		private void comboBoxStudentsGroup_TextChanged(object sender, EventArgs e)
		{

			//1. Очистить выпадающий список
			//2. Создать коллекцию уникальных элементов из дата грид вью, подходящих под паттерн. Попробую потыкать хэшсет
			//3. Запхнуть элементы коллекции в выпадающий список
			//4. ???
			//5. Я великолепна

			//Почему-то через Items.Clear() курсор переносится на начало строки.
			comboBoxStudentsGroup.Items.Clear();
			comboBoxStudentsGroup.SelectionStart = comboBoxStudentsGroup.Text.Length;
			HashSet<string> uniqueData = new HashSet<string>();
			foreach (DataGridViewRow row in dataGridViewStudents.Rows)
			{

				//? Чтобы не падало с нулл референс эксепшен
				string cell = row.Cells[5].Value?.ToString();
				if (!string.IsNullOrEmpty(cell) && cell.IndexOf(comboBoxStudentsGroup.Text, StringComparison.OrdinalIgnoreCase) >= 0)
				{
					uniqueData.Add(cell);
				}
			}
#if DEBUG
			foreach (string value in uniqueData)
			{
				Console.WriteLine(value);
			}
			Console.WriteLine("-------------------------------------------------------------------");
#endif
			foreach (string value in uniqueData)
			{
				comboBoxStudentsGroup.Items.Add(value);
			}

			//Если поиск по направлению и поиск по группам будут связаны, то стоит подумать, что и как отображать в случае изменения данных в одном из них и их последующего несоответствия.
			if (comboBoxStudentsGroup.Text != "")
			{
				dataGridViewStudents.DataSource = Connector.Select("last_name, first_name, middle_name, birth_date, [age] = DATEDIFF(DAY, birth_date, GETDATE()) / 365, group_name, direction_name",
					"Students, Groups, Directions",
					$"[group] = group_id AND direction = direction_id AND group_name LIKE N'%{comboBoxStudentsGroup.Text}%'");
			}
			else
			{
				dataGridViewStudents.DataSource = Connector.Select("last_name, first_name, middle_name, birth_date, [age] = DATEDIFF(DAY, birth_date, GETDATE()) / 365, group_name, direction_name",
					"Students, Groups, Directions",
					"[group] = group_id AND direction = direction_id");
			}
		}
		////////////////////////////////////
		[DllImport("kernel32.dll")]
		static extern bool AllocConsole();

		private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{

		}

		private void statusStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
		{

		}

		private void tabControlMain_SelectedIndexChanged(object sender, EventArgs e)
		{
			switch ((sender as TabControl).SelectedTab.Text) 
			{
				case "Students":
					SetStatusBarText(dataGridViewStudents.Rows, e);
					break;
				case "Groups": SetStatusBarText(dataGridViewGroups.Rows, e);
					break;
			}
		}

		private void MainForm_Load(object sender, EventArgs e)
		{
			SetStatusBarText(dataGridViewStudents.Rows, e);
		}

		private void buttonAddGroup_Click_1(object sender, EventArgs e)
		{
			if (!string.IsNullOrEmpty(comboBoxGroupsDirections.Text) && !string.IsNullOrEmpty(comboBoxSearchGroups.Text))
			{
				DataTable directionTable = Connector.Select("direction_id", "Directions", $"direction_name LIKE N'%{comboBoxGroupsDirections.Text}%'");
				int direction_id;
				if (directionTable.Rows.Count > 0)
				{
					direction_id = Convert.ToInt32(directionTable.Rows[0]["direction_id"]);
				}
				else
				{
					MessageBox.Show(Owner, "There is no such direction.");
					return;
				}
				Connector.InsertGroup(comboBoxSearchGroups.Text, direction_id);
				MessageBox.Show(Owner, "Insert has been completed.");
			}
			else 
			{
				MessageBox.Show(Owner, "Fill out all fields.");
			}
		}
	}
}
