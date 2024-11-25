//#define HOMEWORK
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
		AddGroupForm addGroup;
		AddStudentForm addStudent;
		public MainForm()
		{
			AllocConsole();
			InitializeComponent();
			addGroup = new AddGroupForm();
			addStudent = new AddStudentForm();
			loadGroups();
			loadStudents();
			SetStatusBarText(dataGridViewStudents.Rows, new EventArgs());

		}
		
		void loadStudents()
		{
			dataGridViewStudents.Rows.CollectionChanged += new CollectionChangeEventHandler(SetStatusBarText);
			dataGridViewStudents.DataSource = Connector.Select
				("student_id, last_name, first_name, middle_name, birth_date, [age] = DATEDIFF(DAY, birth_date, GETDATE()) / 365, group_name, direction_name",
				"Students, Groups, Directions",
				"[group] = group_id AND direction = direction_id"
				);
			comboBoxStudentsGroup.DataSource = Connector.Select("group_id, group_name", "Groups");
			comboBoxStudentsGroup.DisplayMember = "group_name";
			comboBoxStudentsGroup.SelectedIndex = -1;
			comboBoxStudentsGroup.ValueMember = "group_id";
			//comboBoxStudentsDirection.DataSource = Connector.Select("direction_name", "Directions");
			//comboBoxStudentsDirection.DisplayMember = "direction_name";
			//comboBoxStudentsDirection.SelectedIndex = -1;
			comboBoxStudentsDirection.Items.AddRange(Connector.directions.Keys.ToArray());
		}
		void loadGroups()
		{
			dataGridViewGroups.Rows.CollectionChanged += new CollectionChangeEventHandler(SetStatusBarText);
#if HOMEWORK
			DataTable source = Connector.Select(
					"group_id, group_name, start_date, learning_time, direction_name, form_name, learning_days",
					"Groups, Directions, LearningForms",
					$"direction = direction_id AND learning_form = form_id"
					);
			source.Columns.Add("schedule");
			dataGridViewGroups.DataSource = source;
			foreach (DataGridViewRow row in dataGridViewGroups.Rows)
			{
				byte learningDays = Convert.ToByte(row.Cells["learning_days"].Value);
				row.Cells["schedule"].Value = ConvertByteToString(learningDays);
			} 
#else
			dataGridViewGroups.DataSource = Connector.Select(
				"group_id, group_name, start_date, learning_time, direction_name, form_name, learning_days",
				"Groups, Directions, LearningForms",
				"direction = direction_id AND learning_form = form_id"
				);
			comboBoxGroupsDirections.Items.AddRange(Connector.SelectColumn("direction_name", "Directions").ToArray());
			for (int i = 0; i < dataGridViewGroups.RowCount; i++)
			{
				dataGridViewGroups.Rows[i].Cells["learning_days"].Value =
					Week.ExtractDaysToString(Convert.ToByte(dataGridViewGroups.Rows[i].Cells["learning_days"].Value));
			}
#endif
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
//		private void comboBoxStudentsGroup_TextChanged(object sender, EventArgs e)
//		{

//			//1. Очистить выпадающий список
//			//2. Создать коллекцию уникальных элементов из дата грид вью, подходящих под паттерн. Попробую потыкать хэшсет
//			//3. Запхнуть элементы коллекции в выпадающий список
//			//4. ???
//			//5. Я великолепна

//			//Почему-то через Items.Clear() курсор переносится на начало строки.
//			comboBoxStudentsGroup.Items.Clear();
//			comboBoxStudentsGroup.SelectionStart = comboBoxStudentsGroup.Text.Length;
//			HashSet<string> uniqueData = new HashSet<string>();
//			foreach (DataGridViewRow row in dataGridViewStudents.Rows)
//			{

//				//? Чтобы не падало с нулл референс эксепшен
//				string cell = row.Cells[5].Value?.ToString();
//				if (!string.IsNullOrEmpty(cell) && cell.IndexOf(comboBoxStudentsGroup.Text, StringComparison.OrdinalIgnoreCase) >= 0)
//				{
//					uniqueData.Add(cell);
//				}
//			}
//#if DEBUG
//			foreach (string value in uniqueData)
//			{
//				Console.WriteLine(value);
//			}
//			Console.WriteLine("-------------------------------------------------------------------");
//#endif
//			foreach (string value in uniqueData)
//			{
//				comboBoxStudentsGroup.Items.Add(value);
//			}

//			//Если поиск по направлению и поиск по группам будут связаны, то стоит подумать, что и как отображать в случае изменения данных в одном из них и их последующего несоответствия.
//			if (comboBoxStudentsGroup.Text != "")
//			{
//				dataGridViewStudents.DataSource = Connector.Select("last_name, first_name, middle_name, birth_date, [age] = DATEDIFF(DAY, birth_date, GETDATE()) / 365, group_name, direction_name",
//					"Students, Groups, Directions",
//					$"[group] = group_id AND direction = direction_id AND group_name LIKE N'%{comboBoxStudentsGroup.Text}%'");
//			}
//			else
//			{
//				dataGridViewStudents.DataSource = Connector.Select("last_name, first_name, middle_name, birth_date, [age] = DATEDIFF(DAY, birth_date, GETDATE()) / 365, group_name, direction_name",
//					"Students, Groups, Directions",
//					"[group] = group_id AND direction = direction_id");
//			}
//		}
		////////////////////////////////////
		[DllImport("kernel32.dll")]
		static extern bool AllocConsole();


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
			addGroup.ClearData();
			//AddGroupForm addGroup = new AddGroupForm();
			if (addGroup.ShowDialog() == DialogResult.OK)
			{
				Group group = new Group(addGroup);
				Connector.InsertGroup(group);
				loadGroups();
			}
			//if (!string.IsNullOrEmpty(comboBoxGroupsDirections.Text) && !string.IsNullOrEmpty(comboBoxSearchGroups.Text))
			//{
			//	DataTable directionTable = Connector.Select("direction_id", "Directions", $"direction_name LIKE N'%{comboBoxGroupsDirections.Text}%'");
			//	int direction_id;
			//	if (directionTable.Rows.Count > 0)
			//	{
			//		direction_id = Convert.ToInt32(directionTable.Rows[0]["direction_id"]);
			//	}
			//	else
			//	{
			//		MessageBox.Show(Owner, "There is no such direction.");
			//		return;
			//	}
			//	Connector.InsertGroup(comboBoxSearchGroups.Text, direction_id);
			//	MessageBox.Show(Owner, "Insert has been completed.");
			//}
			//else 
			//{
			//	MessageBox.Show(Owner, "Fill out all fields.");
			//}
		}

		//private void dataGridViewGroups_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		//{
		//	addGroup.textBoxGroupName.Text = dataGridViewGroups.Rows[e.RowIndex].Cells[1].Value?.ToString(); 
		//	addGroup.comboBoxAddGroupDirection.Text = dataGridViewGroups.Rows[e.RowIndex].Cells[4].Value?.ToString();
		//	addGroup.comboBoxGroupLearningForms.Text = dataGridViewGroups.Rows[e.RowIndex].Cells[5].Value?.ToString();
		//	byte days = 0;
		//	if (!string.IsNullOrEmpty(dataGridViewGroups.Rows[e.RowIndex].Cells[6].Value?.ToString()))
		//	{

		//		days = Convert.ToByte(dataGridViewGroups.Rows[e.RowIndex].Cells[6].Value);
		//		addGroup.SetWeekDays(days);
		//	}
		//	else
		//	{
		//		for (int i = 0; i < addGroup.checkedListBoxGroupDays.Items.Count; i++)
		//		{
		//			addGroup.checkedListBoxGroupDays.SetItemChecked(i, false);
		//		}
		//	}
		//          Console.WriteLine(days);
		//          addGroup.dateTimePickerGroupTime.Value = Convert.ToDateTime(dataGridViewGroups.Rows[e.RowIndex].Cells[2].Value);
		//          addGroup.dateTimePickerGroupStartDate.Value = Convert.ToDateTime(dataGridViewGroups.Rows[e.RowIndex].Cells[3].Value);
		//	int id = Convert.ToInt32(dataGridViewGroups.Rows[e.RowIndex].Cells[0].Value);
		//	//int id = Convert.ToInt32(Connector.Select("group_id", "Groups", $"group_name = '{addGroup.textBoxGroupName.Text}'").Rows[0]["group_id"]);
		//	if (addGroup.ShowDialog() == DialogResult.OK)
		//	{
		//		string group_name = addGroup.textBoxGroupName.Text;
		//		string direction = addGroup.comboBoxAddGroupDirection.Text;
		//		string learning_form = addGroup.comboBoxGroupLearningForms.Text;
		//		byte learning_days = addGroup.GetWeekDays();
		//              Console.WriteLine("here---");
		//              Console.WriteLine(learning_days + "----");
		//              TimeSpan time = addGroup.dateTimePickerGroupTime.Value.TimeOfDay;
		//		DateTime date = addGroup.dateTimePickerGroupStartDate.Value;
		//		Connector.AlterGroup(id, group_name, direction, learning_form, date, time, learning_days);
		//		addGroup.Hide();
		//		loadGroups();
		//	}
		//}
		//private void dataGridViewGroups_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
		//{
		//	Group group = new Group((sender as DataGridView).SelectedRows[0]);
		//	//group.ID =Convert.ToInt32((sender as DataGridView).SelectedRows[0].Cells[0].Value);
		//	//group.GroupName = (sender as DataGridView).SelectedRows[0].Cells[1].Value?.ToString();
		//	//group.StartDate = Convert.ToDateTime((sender as DataGridView).SelectedRows[0].Cells[2].Value);
		//	//group.LearningTime = Convert.ToDateTime((sender as DataGridView).SelectedRows[0].Cells[3].Value).TimeOfDay;
		//	//group.LearningDays = Convert.ToByte((sender as DataGridView).SelectedRows[0].Cells[6].Value);
		//	//group.Direction = Connector.directions[(sender as DataGridView).SelectedRows[0].Cells[4].Value.ToString()];
		//	//group.LearningForm = Connector.learningForms[(sender as DataGridView).SelectedRows[0].Cells[5].Value.ToString()];
		//		addGroup.Init(group);
		//	if (addGroup.ShowDialog() == DialogResult.OK)
		//	{
		//		Connector.UpdateGroup(group);
		//	}
		//	//addGroup.Init(group);
		//}
		string ConvertByteToString(byte value)
		{
			string result = "";
			for (int i = 0; i < addGroup.checkedListBoxGroupDays.Items.Count; i++)
			{
                if ((value & (1 << i)) != 0)
				{
					if (!string.IsNullOrEmpty(result))
					{
						result += ", ";
					}
					result += addGroup.checkedListBoxGroupDays.Items[i].ToString();
				}

			}
            Console.WriteLine(result);
            return result;
		}

		private void dataGridViewGroups_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
		{
			Group group = new Group((sender as DataGridView).SelectedRows[0]);
			addGroup.Init(group);

            if (addGroup.ShowDialog() == DialogResult.OK)
			{
				//Group newGroup = new Group(addGroup);
				//newGroup.ID = group.ID;
				//Connector.UpdateGroup(newGroup);
				//loadGroups();
				int index = dataGridViewGroups.SelectedRows[0].Index;
				dataGridViewGroups.Rows[index].SetValues(Connector.UpdateGroup(addGroup.group));
				addGroup.Hide();
			}
		}

		private void dataGridViewStudents_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
		{
			Student student = new Student((sender as DataGridView).SelectedRows[0]);
			addStudent.Init(student);
			if (addStudent.ShowDialog() == DialogResult.OK)
			{
				Connector.UpdateStudent(new Student(addStudent));
				loadStudents();
				addStudent.Hide();
			}
		}

		private void buttonStudentsAdd_Click(object sender, EventArgs e)
		{
			addStudent.ClearData();
			if (addStudent.ShowDialog() == DialogResult.OK)
			{
				Student student = new Student(addStudent);
				Connector.InsertStudent(student);
				Connector.UpdateGroupsDictionary(addStudent.ComboBoxAddStudentGroup);
				loadStudents();
			}
		}
	}
}
