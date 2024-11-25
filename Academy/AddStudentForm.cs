using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Academy
{
	public partial class AddStudentForm : Form
	{
		public string TextBoxAddStudentFirstName
		{
			get => textBoxAddStudentFirstName.Text;
		}
		public string TextBoxAddStudentLastName
		{
			get => textBoxAddStudentLastName.Text;
		}
		public string TextBoxAddStudentMiddleName
		{
			get => textBoxAddStudentMiddleName.Text;
		}
		public string ComboBoxAddStudentGroup
		{
			get => comboBoxAddStudentGroup.Text;
		}
		public DateTime DateTimePickerAddStudentBirthDate
		{
			get => dateTimePickerAddStudentBirthDate.Value;
		}

		public Student currentData;
		public AddStudentForm()
		{
			InitializeComponent();
			currentData = new Student();
			comboBoxAddStudentGroup.Items.AddRange(Connector.groups.Keys.ToArray());
		}

		private void buttonAddStudentReset_Click(object sender, EventArgs e)
		{
			ClearData();
		}
		public void ClearData()
		{
			textBoxAddStudentFirstName.Text = "";
			textBoxAddStudentLastName.Text = "";
			textBoxAddStudentMiddleName.Text = "";
			comboBoxAddStudentGroup.SelectedIndex = -1;
			dateTimePickerAddStudentBirthDate.Value = DateTime.Now;
		}
		public void Init(Student other)
		{
			currentData = other;
			textBoxAddStudentFirstName.Text = other.FirstName;
			textBoxAddStudentLastName.Text = other.LastName;
			textBoxAddStudentMiddleName.Text = other.MiddleName;
			string key = Connector.groups.First(pair => pair.Value == other.GroupID).Key;
			comboBoxAddStudentGroup.SelectedItem = key;
			dateTimePickerAddStudentBirthDate.Value = other.BirthDate;
		}
	}
}
