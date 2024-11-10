using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Academy
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
			dataGridViewTeachers.Rows.CollectionChanged += new CollectionChangeEventHandler(CountRows);
			dataGridViewTeachers.DataSource = Connector.Select("last_name, first_name, middle_name, birth_date, group_name, direction_name", "Students, Groups, Directions", "[group] = group_id AND direction = direction_id");
			
		}
		void CountRows(object sender, EventArgs e)
		{
			toolStripStatusLabelTeacherCount.Text = $"Количество студентов: {dataGridViewTeachers.RowCount}";
		}

		private void dataGridViewTeachers_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{

		}
	}
}
