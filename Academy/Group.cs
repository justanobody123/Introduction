using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Academy
{
	public class Group
	{
		public int ID { get; set; }
		public string GroupName { get; set; }
		public DateTime StartDate { get; set; }
		public TimeSpan LearningTime { get; set; }
		public int Direction { get; set; }
		public int LearningForm { get; set; }
		public byte LearningDays { get; set; }
		public Group(Group other)
		{
			this.ID = other.ID;
			this.GroupName = other.GroupName;
			this.StartDate = other.StartDate;
			this.LearningTime = other.LearningTime;
			this.Direction = other.Direction;
			this.LearningForm = other.LearningForm;
			this.LearningDays = other.LearningDays;
		}
		public Group(){}
		public Group(AddGroupForm form)
		{
			this.GroupName = form.textBoxGroupName.Text;
			this.StartDate = form.dateTimePickerGroupStartDate.Value;
			this.LearningTime = form.dateTimePickerGroupTime.Value.TimeOfDay;
			this.Direction = form.comboBoxAddGroupDirection.SelectedIndex + 1;
			this.LearningForm = form.comboBoxGroupLearningForms.SelectedIndex + 1;
			this.LearningDays = form.GetWeekDays();
		}
		public Group(System.Windows.Forms.DataGridViewRow row)
		{
			this.ID				= Convert.ToInt32(row.Cells[0].Value);
			this.GroupName		= row.Cells[1].Value.ToString();
			this.StartDate		= Convert.ToDateTime(row.Cells[2].Value);
			this.LearningTime	= Convert.ToDateTime(row.Cells[3].Value).TimeOfDay;
			this.Direction		= Connector.directions[row.Cells[4].Value.ToString()];
			this.LearningForm	= Connector.learningForms[row.Cells[5].Value.ToString()];
			this.LearningDays	= Week.CompressStringToByte(row.Cells[6].Value.ToString());
		}
	}
}
