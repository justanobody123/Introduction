namespace Academy
{
	partial class AddStudentForm
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
			this.labelAddStudentFirstName = new System.Windows.Forms.Label();
			this.labelAddStudentLastName = new System.Windows.Forms.Label();
			this.labelAddStudentMiddleName = new System.Windows.Forms.Label();
			this.labelAddStudentGroup = new System.Windows.Forms.Label();
			this.labelAddStudentBirthDate = new System.Windows.Forms.Label();
			this.dateTimePickerAddStudentBirthDate = new System.Windows.Forms.DateTimePicker();
			this.textBoxAddStudentFirstName = new System.Windows.Forms.TextBox();
			this.textBoxAddStudentLastName = new System.Windows.Forms.TextBox();
			this.textBoxAddStudentMiddleName = new System.Windows.Forms.TextBox();
			this.comboBoxAddStudentGroup = new System.Windows.Forms.ComboBox();
			this.buttonAddStudentReset = new System.Windows.Forms.Button();
			this.buttonAddStudentSave = new System.Windows.Forms.Button();
			this.buttonAddStudentCancel = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// labelAddStudentFirstName
			// 
			this.labelAddStudentFirstName.AutoSize = true;
			this.labelAddStudentFirstName.Location = new System.Drawing.Point(89, 29);
			this.labelAddStudentFirstName.Name = "labelAddStudentFirstName";
			this.labelAddStudentFirstName.Size = new System.Drawing.Size(36, 16);
			this.labelAddStudentFirstName.TabIndex = 0;
			this.labelAddStudentFirstName.Text = "Имя:";
			// 
			// labelAddStudentLastName
			// 
			this.labelAddStudentLastName.AutoSize = true;
			this.labelAddStudentLastName.Location = new System.Drawing.Point(56, 68);
			this.labelAddStudentLastName.Name = "labelAddStudentLastName";
			this.labelAddStudentLastName.Size = new System.Drawing.Size(69, 16);
			this.labelAddStudentLastName.TabIndex = 1;
			this.labelAddStudentLastName.Text = "Фамилия:";
			// 
			// labelAddStudentMiddleName
			// 
			this.labelAddStudentMiddleName.AutoSize = true;
			this.labelAddStudentMiddleName.Location = new System.Drawing.Point(52, 103);
			this.labelAddStudentMiddleName.Name = "labelAddStudentMiddleName";
			this.labelAddStudentMiddleName.Size = new System.Drawing.Size(73, 16);
			this.labelAddStudentMiddleName.TabIndex = 2;
			this.labelAddStudentMiddleName.Text = "Отчество:";
			// 
			// labelAddStudentGroup
			// 
			this.labelAddStudentGroup.AutoSize = true;
			this.labelAddStudentGroup.Location = new System.Drawing.Point(68, 141);
			this.labelAddStudentGroup.Name = "labelAddStudentGroup";
			this.labelAddStudentGroup.Size = new System.Drawing.Size(57, 16);
			this.labelAddStudentGroup.TabIndex = 3;
			this.labelAddStudentGroup.Text = "Группа:";
			// 
			// labelAddStudentBirthDate
			// 
			this.labelAddStudentBirthDate.AutoSize = true;
			this.labelAddStudentBirthDate.Location = new System.Drawing.Point(16, 192);
			this.labelAddStudentBirthDate.Name = "labelAddStudentBirthDate";
			this.labelAddStudentBirthDate.Size = new System.Drawing.Size(109, 16);
			this.labelAddStudentBirthDate.TabIndex = 4;
			this.labelAddStudentBirthDate.Text = "Дата рождения:";
			// 
			// dateTimePickerAddStudentBirthDate
			// 
			this.dateTimePickerAddStudentBirthDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dateTimePickerAddStudentBirthDate.Location = new System.Drawing.Point(132, 189);
			this.dateTimePickerAddStudentBirthDate.Name = "dateTimePickerAddStudentBirthDate";
			this.dateTimePickerAddStudentBirthDate.Size = new System.Drawing.Size(379, 22);
			this.dateTimePickerAddStudentBirthDate.TabIndex = 5;
			// 
			// textBoxAddStudentFirstName
			// 
			this.textBoxAddStudentFirstName.Location = new System.Drawing.Point(132, 29);
			this.textBoxAddStudentFirstName.Name = "textBoxAddStudentFirstName";
			this.textBoxAddStudentFirstName.Size = new System.Drawing.Size(379, 22);
			this.textBoxAddStudentFirstName.TabIndex = 6;
			// 
			// textBoxAddStudentLastName
			// 
			this.textBoxAddStudentLastName.Location = new System.Drawing.Point(132, 66);
			this.textBoxAddStudentLastName.Name = "textBoxAddStudentLastName";
			this.textBoxAddStudentLastName.Size = new System.Drawing.Size(379, 22);
			this.textBoxAddStudentLastName.TabIndex = 7;
			// 
			// textBoxAddStudentMiddleName
			// 
			this.textBoxAddStudentMiddleName.Location = new System.Drawing.Point(132, 103);
			this.textBoxAddStudentMiddleName.Name = "textBoxAddStudentMiddleName";
			this.textBoxAddStudentMiddleName.Size = new System.Drawing.Size(379, 22);
			this.textBoxAddStudentMiddleName.TabIndex = 8;
			// 
			// comboBoxAddStudentGroup
			// 
			this.comboBoxAddStudentGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxAddStudentGroup.FormattingEnabled = true;
			this.comboBoxAddStudentGroup.Location = new System.Drawing.Point(132, 141);
			this.comboBoxAddStudentGroup.Name = "comboBoxAddStudentGroup";
			this.comboBoxAddStudentGroup.Size = new System.Drawing.Size(379, 24);
			this.comboBoxAddStudentGroup.TabIndex = 9;
			// 
			// buttonAddStudentReset
			// 
			this.buttonAddStudentReset.Location = new System.Drawing.Point(19, 258);
			this.buttonAddStudentReset.Name = "buttonAddStudentReset";
			this.buttonAddStudentReset.Size = new System.Drawing.Size(75, 23);
			this.buttonAddStudentReset.TabIndex = 10;
			this.buttonAddStudentReset.Text = "Сброс";
			this.buttonAddStudentReset.UseVisualStyleBackColor = true;
			this.buttonAddStudentReset.Click += new System.EventHandler(this.buttonAddStudentReset_Click);
			// 
			// buttonAddStudentSave
			// 
			this.buttonAddStudentSave.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.buttonAddStudentSave.Location = new System.Drawing.Point(251, 258);
			this.buttonAddStudentSave.Name = "buttonAddStudentSave";
			this.buttonAddStudentSave.Size = new System.Drawing.Size(87, 23);
			this.buttonAddStudentSave.TabIndex = 11;
			this.buttonAddStudentSave.Text = "Сохранить";
			this.buttonAddStudentSave.UseVisualStyleBackColor = true;
			// 
			// buttonAddStudentCancel
			// 
			this.buttonAddStudentCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonAddStudentCancel.Location = new System.Drawing.Point(436, 258);
			this.buttonAddStudentCancel.Name = "buttonAddStudentCancel";
			this.buttonAddStudentCancel.Size = new System.Drawing.Size(75, 23);
			this.buttonAddStudentCancel.TabIndex = 12;
			this.buttonAddStudentCancel.Text = "Отмена";
			this.buttonAddStudentCancel.UseVisualStyleBackColor = true;
			// 
			// AddStudentForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(582, 323);
			this.Controls.Add(this.buttonAddStudentCancel);
			this.Controls.Add(this.buttonAddStudentSave);
			this.Controls.Add(this.buttonAddStudentReset);
			this.Controls.Add(this.comboBoxAddStudentGroup);
			this.Controls.Add(this.textBoxAddStudentMiddleName);
			this.Controls.Add(this.textBoxAddStudentLastName);
			this.Controls.Add(this.textBoxAddStudentFirstName);
			this.Controls.Add(this.dateTimePickerAddStudentBirthDate);
			this.Controls.Add(this.labelAddStudentBirthDate);
			this.Controls.Add(this.labelAddStudentGroup);
			this.Controls.Add(this.labelAddStudentMiddleName);
			this.Controls.Add(this.labelAddStudentLastName);
			this.Controls.Add(this.labelAddStudentFirstName);
			this.Name = "AddStudentForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "AddStudentForm";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label labelAddStudentFirstName;
		private System.Windows.Forms.Label labelAddStudentLastName;
		private System.Windows.Forms.Label labelAddStudentMiddleName;
		private System.Windows.Forms.Label labelAddStudentGroup;
		private System.Windows.Forms.Label labelAddStudentBirthDate;
		private System.Windows.Forms.DateTimePicker dateTimePickerAddStudentBirthDate;
		private System.Windows.Forms.TextBox textBoxAddStudentFirstName;
		private System.Windows.Forms.TextBox textBoxAddStudentLastName;
		private System.Windows.Forms.TextBox textBoxAddStudentMiddleName;
		private System.Windows.Forms.ComboBox comboBoxAddStudentGroup;
		private System.Windows.Forms.Button buttonAddStudentReset;
		private System.Windows.Forms.Button buttonAddStudentSave;
		private System.Windows.Forms.Button buttonAddStudentCancel;
	}
}