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

			dataGridViewStudents.Rows.CollectionChanged += new CollectionChangeEventHandler(CountRows);
			dataGridViewStudents.DataSource = Connector.Select("last_name, first_name, middle_name, birth_date, [age] = DATEDIFF(DAY, birth_date, GETDATE()) / 365, group_name, direction_name", "Students, Groups, Directions", "[group] = group_id AND direction = direction_id");
		}
		void CountRows(object sender, EventArgs e)
		{
			toolStripStatusLabelStudentsCount.Text = $"Количество студентов: {dataGridViewStudents.RowCount}";
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
	}
}
