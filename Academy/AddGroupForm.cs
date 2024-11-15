using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Academy
{
	public partial class AddGroupForm : Form
	{
		public AddGroupForm()
		{
			InitializeComponent();
			comboBoxGroupLearningForms.Items.AddRange(Connector.SelectColumn("form_name", "LearningForms").ToArray());
			comboBoxAddGroupDirection.Items.AddRange(Connector.SelectColumn("direction_name", "Directions").ToArray());
		}
		public byte GetWeekDays()
		{
			byte days = 0;
			byte day = 1;
#if DEBUG
			for (int i = 0; i < checkedListBoxGroupDays.Items.Count; i++)
			{
				Console.Write(checkedListBoxGroupDays.GetItemCheckState(i) + "\t");
			}
			Console.WriteLine();
#endif
			for (int i = 0; i < checkedListBoxGroupDays.Items.Count; i++)
			{
				if (checkedListBoxGroupDays.GetItemChecked(i))
				{ 
					days |= (byte)(day << i);
				}
			}
            Console.WriteLine(days);
            return days;
		}
		private void Сохранить_Click(object sender, EventArgs e)
		{
			GetWeekDays();
		}
		public void SetWeekDays(byte value)
		{
			for (int i = 0; i < checkedListBoxGroupDays.Items.Count; i++)
			{
				bool isChecked = (value & (1 << i)) != 0;
				checkedListBoxGroupDays.SetItemChecked(i, isChecked);
			}
		}
	}
}
