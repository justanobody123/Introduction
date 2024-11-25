using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Academy
{
	public class Student
	{
		public int ID { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string MiddleName { get; set; }
		public int GroupID { get; set; }
		public DateTime BirthDate { get; set; }

		public Student() { }
		public Student(Student other)
		{
			this.ID = other.ID;
			this.FirstName = other.FirstName;
			this.LastName = other.LastName;
			this.MiddleName = other.MiddleName;
			this.GroupID = other.GroupID;
			this.BirthDate = other.BirthDate;
		}
		public Student(AddStudentForm form)
		{
			GroupID = Connector.groups[form.ComboBoxAddStudentGroup];
			FirstName = form.TextBoxAddStudentFirstName;
			LastName = form.TextBoxAddStudentLastName;
			MiddleName = form.TextBoxAddStudentMiddleName;
			BirthDate = form.DateTimePickerAddStudentBirthDate;
		}
		public Student(DataGridViewRow row)
		{
			ID = Convert.ToInt32(row.Cells[0].Value);
			LastName = row.Cells[1].Value.ToString();
			FirstName = row.Cells[2].Value.ToString();
			MiddleName = row.Cells[3].Value.ToString();
			BirthDate = Convert.ToDateTime(row.Cells[4].Value);
			GroupID = Connector.groups[row.Cells[6].Value.ToString()];
		}
	}
	
}
