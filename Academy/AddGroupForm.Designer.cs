namespace Academy
{
	partial class AddGroupForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.labelGroupName = new System.Windows.Forms.Label();
			this.textBoxGroupName = new System.Windows.Forms.TextBox();
			this.labelGroupDirection = new System.Windows.Forms.Label();
			this.labelGroupTime = new System.Windows.Forms.Label();
			this.labelGroupDays = new System.Windows.Forms.Label();
			this.comboBoxAddGroupDirection = new System.Windows.Forms.ComboBox();
			this.dateTimePickerGroupTime = new System.Windows.Forms.DateTimePicker();
			this.checkedListBoxGroupDays = new System.Windows.Forms.CheckedListBox();
			this.labelLearningForm = new System.Windows.Forms.Label();
			this.comboBoxGroupLearningForms = new System.Windows.Forms.ComboBox();
			this.labelGroupStartDate = new System.Windows.Forms.Label();
			this.dateTimePickerGroupStartDate = new System.Windows.Forms.DateTimePicker();
			this.Сохранить = new System.Windows.Forms.Button();
			this.buttonGroupCreationCancel = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// labelGroupName
			// 
			this.labelGroupName.AutoSize = true;
			this.labelGroupName.Location = new System.Drawing.Point(12, 19);
			this.labelGroupName.Name = "labelGroupName";
			this.labelGroupName.Size = new System.Drawing.Size(126, 16);
			this.labelGroupName.TabIndex = 0;
			this.labelGroupName.Text = "Название группы:";
			// 
			// textBoxGroupName
			// 
			this.textBoxGroupName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
			this.textBoxGroupName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.RecentlyUsedList;
			this.textBoxGroupName.Location = new System.Drawing.Point(167, 16);
			this.textBoxGroupName.Name = "textBoxGroupName";
			this.textBoxGroupName.Size = new System.Drawing.Size(379, 22);
			this.textBoxGroupName.TabIndex = 1;
			// 
			// labelGroupDirection
			// 
			this.labelGroupDirection.AutoSize = true;
			this.labelGroupDirection.Location = new System.Drawing.Point(38, 61);
			this.labelGroupDirection.Name = "labelGroupDirection";
			this.labelGroupDirection.Size = new System.Drawing.Size(100, 16);
			this.labelGroupDirection.TabIndex = 2;
			this.labelGroupDirection.Text = "Направление:";
			// 
			// labelGroupTime
			// 
			this.labelGroupTime.AutoSize = true;
			this.labelGroupTime.Location = new System.Drawing.Point(321, 195);
			this.labelGroupTime.Name = "labelGroupTime";
			this.labelGroupTime.Size = new System.Drawing.Size(51, 16);
			this.labelGroupTime.TabIndex = 3;
			this.labelGroupTime.Text = "Время:";
			// 
			// labelGroupDays
			// 
			this.labelGroupDays.AutoSize = true;
			this.labelGroupDays.Location = new System.Drawing.Point(37, 150);
			this.labelGroupDays.Name = "labelGroupDays";
			this.labelGroupDays.Size = new System.Drawing.Size(101, 16);
			this.labelGroupDays.TabIndex = 4;
			this.labelGroupDays.Text = "Дни обучения:";
			// 
			// comboBoxAddGroupDirection
			// 
			this.comboBoxAddGroupDirection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxAddGroupDirection.FormattingEnabled = true;
			this.comboBoxAddGroupDirection.Location = new System.Drawing.Point(167, 57);
			this.comboBoxAddGroupDirection.Name = "comboBoxAddGroupDirection";
			this.comboBoxAddGroupDirection.Size = new System.Drawing.Size(379, 24);
			this.comboBoxAddGroupDirection.TabIndex = 5;
			// 
			// dateTimePickerGroupTime
			// 
			this.dateTimePickerGroupTime.CustomFormat = "HH:mm";
			this.dateTimePickerGroupTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dateTimePickerGroupTime.Location = new System.Drawing.Point(402, 192);
			this.dateTimePickerGroupTime.Name = "dateTimePickerGroupTime";
			this.dateTimePickerGroupTime.Size = new System.Drawing.Size(75, 22);
			this.dateTimePickerGroupTime.TabIndex = 6;
			// 
			// checkedListBoxGroupDays
			// 
			this.checkedListBoxGroupDays.CheckOnClick = true;
			this.checkedListBoxGroupDays.ColumnWidth = 38;
			this.checkedListBoxGroupDays.FormattingEnabled = true;
			this.checkedListBoxGroupDays.Items.AddRange(new object[] {
            "Пн",
            "Вт",
            "Ср",
            "Чт",
            "Пт",
            "Сб",
            "Вс"});
			this.checkedListBoxGroupDays.Location = new System.Drawing.Point(167, 145);
			this.checkedListBoxGroupDays.MultiColumn = true;
			this.checkedListBoxGroupDays.Name = "checkedListBoxGroupDays";
			this.checkedListBoxGroupDays.Size = new System.Drawing.Size(379, 38);
			this.checkedListBoxGroupDays.TabIndex = 7;
			// 
			// labelLearningForm
			// 
			this.labelLearningForm.AutoSize = true;
			this.labelLearningForm.Location = new System.Drawing.Point(18, 106);
			this.labelLearningForm.Name = "labelLearningForm";
			this.labelLearningForm.Size = new System.Drawing.Size(120, 16);
			this.labelLearningForm.TabIndex = 8;
			this.labelLearningForm.Text = "Форма обучения:";
			// 
			// comboBoxGroupLearningForms
			// 
			this.comboBoxGroupLearningForms.FormattingEnabled = true;
			this.comboBoxGroupLearningForms.Location = new System.Drawing.Point(167, 102);
			this.comboBoxGroupLearningForms.Name = "comboBoxGroupLearningForms";
			this.comboBoxGroupLearningForms.Size = new System.Drawing.Size(379, 24);
			this.comboBoxGroupLearningForms.TabIndex = 9;
			// 
			// labelGroupStartDate
			// 
			this.labelGroupStartDate.AutoSize = true;
			this.labelGroupStartDate.Location = new System.Drawing.Point(32, 196);
			this.labelGroupStartDate.Name = "labelGroupStartDate";
			this.labelGroupStartDate.Size = new System.Drawing.Size(106, 16);
			this.labelGroupStartDate.TabIndex = 10;
			this.labelGroupStartDate.Text = "Старт занятий:";
			// 
			// dateTimePickerGroupStartDate
			// 
			this.dateTimePickerGroupStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dateTimePickerGroupStartDate.Location = new System.Drawing.Point(167, 193);
			this.dateTimePickerGroupStartDate.Name = "dateTimePickerGroupStartDate";
			this.dateTimePickerGroupStartDate.Size = new System.Drawing.Size(105, 22);
			this.dateTimePickerGroupStartDate.TabIndex = 11;
			// 
			// Сохранить
			// 
			this.Сохранить.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.Сохранить.Location = new System.Drawing.Point(241, 257);
			this.Сохранить.Name = "Сохранить";
			this.Сохранить.Size = new System.Drawing.Size(94, 23);
			this.Сохранить.TabIndex = 12;
			this.Сохранить.Text = "Сохранить";
			this.Сохранить.UseVisualStyleBackColor = true;
			this.Сохранить.Click += new System.EventHandler(this.Сохранить_Click);
			// 
			// buttonGroupCreationCancel
			// 
			this.buttonGroupCreationCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonGroupCreationCancel.Location = new System.Drawing.Point(390, 257);
			this.buttonGroupCreationCancel.Name = "buttonGroupCreationCancel";
			this.buttonGroupCreationCancel.Size = new System.Drawing.Size(75, 23);
			this.buttonGroupCreationCancel.TabIndex = 13;
			this.buttonGroupCreationCancel.Text = "Cancel";
			this.buttonGroupCreationCancel.UseVisualStyleBackColor = true;
			// 
			// AddGroupForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(580, 309);
			this.Controls.Add(this.buttonGroupCreationCancel);
			this.Controls.Add(this.Сохранить);
			this.Controls.Add(this.dateTimePickerGroupStartDate);
			this.Controls.Add(this.labelGroupStartDate);
			this.Controls.Add(this.comboBoxGroupLearningForms);
			this.Controls.Add(this.labelLearningForm);
			this.Controls.Add(this.checkedListBoxGroupDays);
			this.Controls.Add(this.dateTimePickerGroupTime);
			this.Controls.Add(this.comboBoxAddGroupDirection);
			this.Controls.Add(this.labelGroupDays);
			this.Controls.Add(this.labelGroupTime);
			this.Controls.Add(this.labelGroupDirection);
			this.Controls.Add(this.textBoxGroupName);
			this.Controls.Add(this.labelGroupName);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "AddGroupForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "AddGroupForm";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label labelGroupName;
		internal System.Windows.Forms.TextBox textBoxGroupName;
		private System.Windows.Forms.Label labelGroupDirection;
		private System.Windows.Forms.Label labelGroupTime;
		private System.Windows.Forms.Label labelGroupDays;
		internal System.Windows.Forms.ComboBox comboBoxAddGroupDirection;
		internal System.Windows.Forms.DateTimePicker dateTimePickerGroupTime;
		internal System.Windows.Forms.CheckedListBox checkedListBoxGroupDays;
		private System.Windows.Forms.Label labelLearningForm;
		internal System.Windows.Forms.ComboBox comboBoxGroupLearningForms;
		private System.Windows.Forms.Label labelGroupStartDate;
		internal System.Windows.Forms.DateTimePicker dateTimePickerGroupStartDate;
		private System.Windows.Forms.Button Сохранить;
		private System.Windows.Forms.Button buttonGroupCreationCancel;
	}
}