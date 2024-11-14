namespace Academy
{
	partial class MainForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.tabControlMain = new System.Windows.Forms.TabControl();
			this.tabPageStudents = new System.Windows.Forms.TabPage();
			this.comboBoxStudentsDirection = new System.Windows.Forms.ComboBox();
			this.labelStudentsDirection = new System.Windows.Forms.Label();
			this.labelSearchStudentsGroup = new System.Windows.Forms.Label();
			this.comboBoxStudentsGroup = new System.Windows.Forms.ComboBox();
			this.labelSearchStudents = new System.Windows.Forms.Label();
			this.textBoxSearchStudents = new System.Windows.Forms.TextBox();
			this.dataGridViewStudents = new System.Windows.Forms.DataGridView();
			this.tabPageGroups = new System.Windows.Forms.TabPage();
			this.buttonAddGroup = new System.Windows.Forms.Button();
			this.labelGroupsDirection = new System.Windows.Forms.Label();
			this.labelSearchGroup = new System.Windows.Forms.Label();
			this.comboBoxSearchGroups = new System.Windows.Forms.ComboBox();
			this.comboBoxGroupsDirections = new System.Windows.Forms.ComboBox();
			this.dataGridViewGroups = new System.Windows.Forms.DataGridView();
			this.tabPageDisciplines = new System.Windows.Forms.TabPage();
			this.tabPageTeachers = new System.Windows.Forms.TabPage();
			this.comboBoxTeachersDirection = new System.Windows.Forms.ComboBox();
			this.labelDirectionSearch = new System.Windows.Forms.Label();
			this.labelStudentsGroup = new System.Windows.Forms.Label();
			this.comboBoxTeachers = new System.Windows.Forms.ComboBox();
			this.labelSearchTeacher = new System.Windows.Forms.Label();
			this.textBoxSearchTeachers = new System.Windows.Forms.TextBox();
			this.dataGridViewTeachers = new System.Windows.Forms.DataGridView();
			this.toolStripStatusLabelStudentsCount = new System.Windows.Forms.ToolStripStatusLabel();
			this.statusStrip = new System.Windows.Forms.StatusStrip();
			this.tabControlMain.SuspendLayout();
			this.tabPageStudents.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewStudents)).BeginInit();
			this.tabPageGroups.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewGroups)).BeginInit();
			this.tabPageTeachers.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewTeachers)).BeginInit();
			this.statusStrip.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabControlMain
			// 
			this.tabControlMain.Controls.Add(this.tabPageStudents);
			this.tabControlMain.Controls.Add(this.tabPageGroups);
			this.tabControlMain.Controls.Add(this.tabPageDisciplines);
			this.tabControlMain.Controls.Add(this.tabPageTeachers);
			this.tabControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControlMain.Location = new System.Drawing.Point(0, 0);
			this.tabControlMain.Name = "tabControlMain";
			this.tabControlMain.SelectedIndex = 0;
			this.tabControlMain.Size = new System.Drawing.Size(1112, 424);
			this.tabControlMain.TabIndex = 0;
			this.tabControlMain.SelectedIndexChanged += new System.EventHandler(this.tabControlMain_SelectedIndexChanged);
			// 
			// tabPageStudents
			// 
			this.tabPageStudents.Controls.Add(this.comboBoxStudentsDirection);
			this.tabPageStudents.Controls.Add(this.labelStudentsDirection);
			this.tabPageStudents.Controls.Add(this.labelSearchStudentsGroup);
			this.tabPageStudents.Controls.Add(this.comboBoxStudentsGroup);
			this.tabPageStudents.Controls.Add(this.labelSearchStudents);
			this.tabPageStudents.Controls.Add(this.textBoxSearchStudents);
			this.tabPageStudents.Controls.Add(this.dataGridViewStudents);
			this.tabPageStudents.Location = new System.Drawing.Point(4, 25);
			this.tabPageStudents.Name = "tabPageStudents";
			this.tabPageStudents.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageStudents.Size = new System.Drawing.Size(1104, 395);
			this.tabPageStudents.TabIndex = 0;
			this.tabPageStudents.Text = "Students";
			this.tabPageStudents.UseVisualStyleBackColor = true;
			// 
			// comboBoxStudentsDirection
			// 
			this.comboBoxStudentsDirection.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.comboBoxStudentsDirection.FormattingEnabled = true;
			this.comboBoxStudentsDirection.Location = new System.Drawing.Point(876, 7);
			this.comboBoxStudentsDirection.Name = "comboBoxStudentsDirection";
			this.comboBoxStudentsDirection.Size = new System.Drawing.Size(220, 24);
			this.comboBoxStudentsDirection.TabIndex = 15;
			// 
			// labelStudentsDirection
			// 
			this.labelStudentsDirection.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.labelStudentsDirection.AutoSize = true;
			this.labelStudentsDirection.Location = new System.Drawing.Point(770, 11);
			this.labelStudentsDirection.Name = "labelStudentsDirection";
			this.labelStudentsDirection.Size = new System.Drawing.Size(100, 16);
			this.labelStudentsDirection.TabIndex = 14;
			this.labelStudentsDirection.Text = "Направление:";
			// 
			// labelSearchStudentsGroup
			// 
			this.labelSearchStudentsGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.labelSearchStudentsGroup.AutoSize = true;
			this.labelSearchStudentsGroup.Location = new System.Drawing.Point(518, 10);
			this.labelSearchStudentsGroup.Name = "labelSearchStudentsGroup";
			this.labelSearchStudentsGroup.Size = new System.Drawing.Size(57, 16);
			this.labelSearchStudentsGroup.TabIndex = 13;
			this.labelSearchStudentsGroup.Text = "Группа:";
			// 
			// comboBoxStudentsGroup
			// 
			this.comboBoxStudentsGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.comboBoxStudentsGroup.FormattingEnabled = true;
			this.comboBoxStudentsGroup.Location = new System.Drawing.Point(581, 8);
			this.comboBoxStudentsGroup.Name = "comboBoxStudentsGroup";
			this.comboBoxStudentsGroup.Size = new System.Drawing.Size(183, 24);
			this.comboBoxStudentsGroup.TabIndex = 12;
			this.comboBoxStudentsGroup.TextChanged += new System.EventHandler(this.comboBoxStudentsGroup_TextChanged);
			// 
			// labelSearchStudents
			// 
			this.labelSearchStudents.AutoSize = true;
			this.labelSearchStudents.Location = new System.Drawing.Point(9, 13);
			this.labelSearchStudents.Name = "labelSearchStudents";
			this.labelSearchStudents.Size = new System.Drawing.Size(50, 16);
			this.labelSearchStudents.TabIndex = 11;
			this.labelSearchStudents.Text = "Поиск:";
			// 
			// textBoxSearchStudents
			// 
			this.textBoxSearchStudents.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
			this.textBoxSearchStudents.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.RecentlyUsedList;
			this.textBoxSearchStudents.Location = new System.Drawing.Point(65, 10);
			this.textBoxSearchStudents.Name = "textBoxSearchStudents";
			this.textBoxSearchStudents.Size = new System.Drawing.Size(199, 22);
			this.textBoxSearchStudents.TabIndex = 10;
			this.textBoxSearchStudents.TextChanged += new System.EventHandler(this.textBoxSearchStudents_TextChanged);
			// 
			// dataGridViewStudents
			// 
			this.dataGridViewStudents.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dataGridViewStudents.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dataGridViewStudents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewStudents.Location = new System.Drawing.Point(4, 41);
			this.dataGridViewStudents.Name = "dataGridViewStudents";
			this.dataGridViewStudents.RowHeadersWidth = 51;
			this.dataGridViewStudents.RowTemplate.Height = 24;
			this.dataGridViewStudents.Size = new System.Drawing.Size(1112, 424);
			this.dataGridViewStudents.TabIndex = 8;
			// 
			// tabPageGroups
			// 
			this.tabPageGroups.Controls.Add(this.buttonAddGroup);
			this.tabPageGroups.Controls.Add(this.labelGroupsDirection);
			this.tabPageGroups.Controls.Add(this.labelSearchGroup);
			this.tabPageGroups.Controls.Add(this.comboBoxSearchGroups);
			this.tabPageGroups.Controls.Add(this.comboBoxGroupsDirections);
			this.tabPageGroups.Controls.Add(this.dataGridViewGroups);
			this.tabPageGroups.Location = new System.Drawing.Point(4, 25);
			this.tabPageGroups.Name = "tabPageGroups";
			this.tabPageGroups.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageGroups.Size = new System.Drawing.Size(1104, 395);
			this.tabPageGroups.TabIndex = 1;
			this.tabPageGroups.Text = "Groups";
			this.tabPageGroups.UseVisualStyleBackColor = true;
			// 
			// buttonAddGroup
			// 
			this.buttonAddGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonAddGroup.Location = new System.Drawing.Point(968, 2);
			this.buttonAddGroup.Name = "buttonAddGroup";
			this.buttonAddGroup.Size = new System.Drawing.Size(128, 23);
			this.buttonAddGroup.TabIndex = 5;
			this.buttonAddGroup.Text = "Добавить группу";
			this.buttonAddGroup.UseVisualStyleBackColor = true;
			this.buttonAddGroup.Click += new System.EventHandler(this.buttonAddGroup_Click_1);
			// 
			// labelGroupsDirection
			// 
			this.labelGroupsDirection.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.labelGroupsDirection.AutoSize = true;
			this.labelGroupsDirection.Location = new System.Drawing.Point(494, 9);
			this.labelGroupsDirection.Name = "labelGroupsDirection";
			this.labelGroupsDirection.Size = new System.Drawing.Size(166, 16);
			this.labelGroupsDirection.TabIndex = 4;
			this.labelGroupsDirection.Text = "Направление обучения:";
			// 
			// labelSearchGroup
			// 
			this.labelSearchGroup.AutoSize = true;
			this.labelSearchGroup.Location = new System.Drawing.Point(9, 10);
			this.labelSearchGroup.Name = "labelSearchGroup";
			this.labelSearchGroup.Size = new System.Drawing.Size(113, 16);
			this.labelSearchGroup.TabIndex = 3;
			this.labelSearchGroup.Text = "Поиск по имени:";
			// 
			// comboBoxSearchGroups
			// 
			this.comboBoxSearchGroups.FormattingEnabled = true;
			this.comboBoxSearchGroups.Location = new System.Drawing.Point(138, 6);
			this.comboBoxSearchGroups.Name = "comboBoxSearchGroups";
			this.comboBoxSearchGroups.Size = new System.Drawing.Size(204, 24);
			this.comboBoxSearchGroups.TabIndex = 2;
			// 
			// comboBoxGroupsDirections
			// 
			this.comboBoxGroupsDirections.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.comboBoxGroupsDirections.FormattingEnabled = true;
			this.comboBoxGroupsDirections.Location = new System.Drawing.Point(666, 3);
			this.comboBoxGroupsDirections.Name = "comboBoxGroupsDirections";
			this.comboBoxGroupsDirections.Size = new System.Drawing.Size(284, 24);
			this.comboBoxGroupsDirections.TabIndex = 1;
			// 
			// dataGridViewGroups
			// 
			this.dataGridViewGroups.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dataGridViewGroups.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dataGridViewGroups.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewGroups.Location = new System.Drawing.Point(3, 32);
			this.dataGridViewGroups.Name = "dataGridViewGroups";
			this.dataGridViewGroups.RowHeadersWidth = 51;
			this.dataGridViewGroups.RowTemplate.Height = 24;
			this.dataGridViewGroups.Size = new System.Drawing.Size(1095, 340);
			this.dataGridViewGroups.TabIndex = 0;
			this.dataGridViewGroups.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewGroups_CellDoubleClick);
			// 
			// tabPageDisciplines
			// 
			this.tabPageDisciplines.Location = new System.Drawing.Point(4, 25);
			this.tabPageDisciplines.Name = "tabPageDisciplines";
			this.tabPageDisciplines.Size = new System.Drawing.Size(1104, 395);
			this.tabPageDisciplines.TabIndex = 2;
			this.tabPageDisciplines.Text = "Disciplines";
			this.tabPageDisciplines.UseVisualStyleBackColor = true;
			// 
			// tabPageTeachers
			// 
			this.tabPageTeachers.Controls.Add(this.comboBoxTeachersDirection);
			this.tabPageTeachers.Controls.Add(this.labelDirectionSearch);
			this.tabPageTeachers.Controls.Add(this.labelStudentsGroup);
			this.tabPageTeachers.Controls.Add(this.comboBoxTeachers);
			this.tabPageTeachers.Controls.Add(this.labelSearchTeacher);
			this.tabPageTeachers.Controls.Add(this.textBoxSearchTeachers);
			this.tabPageTeachers.Controls.Add(this.dataGridViewTeachers);
			this.tabPageTeachers.Location = new System.Drawing.Point(4, 25);
			this.tabPageTeachers.Name = "tabPageTeachers";
			this.tabPageTeachers.Size = new System.Drawing.Size(1104, 395);
			this.tabPageTeachers.TabIndex = 3;
			this.tabPageTeachers.Text = "Teachers";
			this.tabPageTeachers.UseVisualStyleBackColor = true;
			// 
			// comboBoxTeachersDirection
			// 
			this.comboBoxTeachersDirection.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.comboBoxTeachersDirection.FormattingEnabled = true;
			this.comboBoxTeachersDirection.Location = new System.Drawing.Point(876, 7);
			this.comboBoxTeachersDirection.Name = "comboBoxTeachersDirection";
			this.comboBoxTeachersDirection.Size = new System.Drawing.Size(220, 24);
			this.comboBoxTeachersDirection.TabIndex = 7;
			// 
			// labelDirectionSearch
			// 
			this.labelDirectionSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.labelDirectionSearch.AutoSize = true;
			this.labelDirectionSearch.Location = new System.Drawing.Point(770, 11);
			this.labelDirectionSearch.Name = "labelDirectionSearch";
			this.labelDirectionSearch.Size = new System.Drawing.Size(100, 16);
			this.labelDirectionSearch.TabIndex = 6;
			this.labelDirectionSearch.Text = "Направление:";
			// 
			// labelStudentsGroup
			// 
			this.labelStudentsGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.labelStudentsGroup.AutoSize = true;
			this.labelStudentsGroup.Location = new System.Drawing.Point(518, 10);
			this.labelStudentsGroup.Name = "labelStudentsGroup";
			this.labelStudentsGroup.Size = new System.Drawing.Size(57, 16);
			this.labelStudentsGroup.TabIndex = 5;
			this.labelStudentsGroup.Text = "Группа:";
			// 
			// comboBoxTeachers
			// 
			this.comboBoxTeachers.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.comboBoxTeachers.FormattingEnabled = true;
			this.comboBoxTeachers.Location = new System.Drawing.Point(581, 8);
			this.comboBoxTeachers.Name = "comboBoxTeachers";
			this.comboBoxTeachers.Size = new System.Drawing.Size(183, 24);
			this.comboBoxTeachers.TabIndex = 4;
			// 
			// labelSearchTeacher
			// 
			this.labelSearchTeacher.AutoSize = true;
			this.labelSearchTeacher.Location = new System.Drawing.Point(9, 13);
			this.labelSearchTeacher.Name = "labelSearchTeacher";
			this.labelSearchTeacher.Size = new System.Drawing.Size(50, 16);
			this.labelSearchTeacher.TabIndex = 3;
			this.labelSearchTeacher.Text = "Поиск:";
			// 
			// textBoxSearchTeachers
			// 
			this.textBoxSearchTeachers.Location = new System.Drawing.Point(65, 10);
			this.textBoxSearchTeachers.Name = "textBoxSearchTeachers";
			this.textBoxSearchTeachers.Size = new System.Drawing.Size(199, 22);
			this.textBoxSearchTeachers.TabIndex = 2;
			// 
			// dataGridViewTeachers
			// 
			this.dataGridViewTeachers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dataGridViewTeachers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dataGridViewTeachers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewTeachers.Location = new System.Drawing.Point(4, 41);
			this.dataGridViewTeachers.Name = "dataGridViewTeachers";
			this.dataGridViewTeachers.RowHeadersWidth = 51;
			this.dataGridViewTeachers.RowTemplate.Height = 24;
			this.dataGridViewTeachers.Size = new System.Drawing.Size(1100, 329);
			this.dataGridViewTeachers.TabIndex = 0;
			// 
			// toolStripStatusLabelStudentsCount
			// 
			this.toolStripStatusLabelStudentsCount.Name = "toolStripStatusLabelStudentsCount";
			this.toolStripStatusLabelStudentsCount.Size = new System.Drawing.Size(239, 20);
			this.toolStripStatusLabelStudentsCount.Text = "toolStripStatusLabelStudentsCount";
			// 
			// statusStrip
			// 
			this.statusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelStudentsCount});
			this.statusStrip.Location = new System.Drawing.Point(0, 424);
			this.statusStrip.Name = "statusStrip";
			this.statusStrip.Size = new System.Drawing.Size(1112, 26);
			this.statusStrip.TabIndex = 9;
			this.statusStrip.Text = "statusStrip1";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1112, 450);
			this.Controls.Add(this.tabControlMain);
			this.Controls.Add(this.statusStrip);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "MainForm";
			this.Text = "Academy";
			this.Load += new System.EventHandler(this.MainForm_Load);
			this.tabControlMain.ResumeLayout(false);
			this.tabPageStudents.ResumeLayout(false);
			this.tabPageStudents.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewStudents)).EndInit();
			this.tabPageGroups.ResumeLayout(false);
			this.tabPageGroups.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewGroups)).EndInit();
			this.tabPageTeachers.ResumeLayout(false);
			this.tabPageTeachers.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewTeachers)).EndInit();
			this.statusStrip.ResumeLayout(false);
			this.statusStrip.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TabControl tabControlMain;
		private System.Windows.Forms.TabPage tabPageStudents;
		private System.Windows.Forms.TabPage tabPageGroups;
		private System.Windows.Forms.TabPage tabPageDisciplines;
		private System.Windows.Forms.TabPage tabPageTeachers;
		private System.Windows.Forms.ComboBox comboBoxStudentsDirection;
		private System.Windows.Forms.Label labelStudentsDirection;
		private System.Windows.Forms.Label labelSearchStudentsGroup;
		private System.Windows.Forms.ComboBox comboBoxStudentsGroup;
		private System.Windows.Forms.Label labelSearchStudents;
		private System.Windows.Forms.TextBox textBoxSearchStudents;
		private System.Windows.Forms.DataGridView dataGridViewStudents;
		private System.Windows.Forms.ComboBox comboBoxTeachersDirection;
		private System.Windows.Forms.Label labelDirectionSearch;
		private System.Windows.Forms.Label labelStudentsGroup;
		private System.Windows.Forms.ComboBox comboBoxTeachers;
		private System.Windows.Forms.Label labelSearchTeacher;
		private System.Windows.Forms.TextBox textBoxSearchTeachers;
		private System.Windows.Forms.DataGridView dataGridViewTeachers;
		private System.Windows.Forms.ComboBox comboBoxGroupsDirections;
		private System.Windows.Forms.DataGridView dataGridViewGroups;
		private System.Windows.Forms.Label labelGroupsDirection;
		private System.Windows.Forms.Label labelSearchGroup;
		private System.Windows.Forms.ComboBox comboBoxSearchGroups;
		private System.Windows.Forms.Button buttonAddGroup;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelStudentsCount;
		private System.Windows.Forms.StatusStrip statusStrip;
	}
}

