using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
		public Image PictureBox
		{
			get => pictureBoxAddStudent.Image;
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
			pictureBoxAddStudent.Image = null;
		}
		public void Init(Student other)
		{
			currentData = other;
			currentData.ID = other.ID;
			textBoxAddStudentFirstName.Text = other.FirstName;
			textBoxAddStudentLastName.Text = other.LastName;
			textBoxAddStudentMiddleName.Text = other.MiddleName;
			string key = Connector.groups.First(pair => pair.Value == other.GroupID).Key;
			comboBoxAddStudentGroup.SelectedItem = key;
			dateTimePickerAddStudentBirthDate.Value = other.BirthDate;
			GetExistingImageFromBase();
		}
		private void GetExistingImageFromBase()
		{
			byte[] imageData = Connector.GetImageDataFromBase(currentData.ID);
			if (imageData != null)
			{
				MemoryStream ms = new MemoryStream(imageData);
				pictureBoxAddStudent.Image = Image.FromStream(ms);
				ms.Close();
			}		
		}

		private void buttonAddStudentLoadImage_Click(object sender, EventArgs e)
		{
			using (OpenFileDialog fileDialog = new OpenFileDialog())
			{
				fileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
				if (fileDialog.ShowDialog() == DialogResult.OK)
				{
					pictureBoxAddStudent.Image = Image.FromFile(fileDialog.FileName);
				}
			}
			
		}
	}
}
