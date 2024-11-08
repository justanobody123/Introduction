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
			this.tabPageGroups = new System.Windows.Forms.TabPage();
			this.tabPageDisciplines = new System.Windows.Forms.TabPage();
			this.tabPageTeachers = new System.Windows.Forms.TabPage();
			this.dataGridViewTeachers = new System.Windows.Forms.DataGridView();
			this.statusStripTeachers = new System.Windows.Forms.StatusStrip();
			this.toolStripStatusLabelTeacherCount = new System.Windows.Forms.ToolStripStatusLabel();
			this.textBoxSearchStudent = new System.Windows.Forms.TextBox();
			this.labelSearchTeacher = new System.Windows.Forms.Label();
			this.comboBoxStudentsGroup = new System.Windows.Forms.ComboBox();
			this.labelStudentsGroup = new System.Windows.Forms.Label();
			this.labelDirectionSearch = new System.Windows.Forms.Label();
			this.comboBoxStudentsDirection = new System.Windows.Forms.ComboBox();
			this.tabControlMain.SuspendLayout();
			this.tabPageTeachers.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewTeachers)).BeginInit();
			this.statusStripTeachers.SuspendLayout();
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
			this.tabControlMain.Size = new System.Drawing.Size(874, 450);
			this.tabControlMain.TabIndex = 0;
			// 
			// tabPageStudents
			// 
			this.tabPageStudents.Location = new System.Drawing.Point(4, 25);
			this.tabPageStudents.Name = "tabPageStudents";
			this.tabPageStudents.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageStudents.Size = new System.Drawing.Size(792, 421);
			this.tabPageStudents.TabIndex = 0;
			this.tabPageStudents.Text = "Students";
			this.tabPageStudents.UseVisualStyleBackColor = true;
			// 
			// tabPageGroups
			// 
			this.tabPageGroups.Location = new System.Drawing.Point(4, 25);
			this.tabPageGroups.Name = "tabPageGroups";
			this.tabPageGroups.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageGroups.Size = new System.Drawing.Size(792, 421);
			this.tabPageGroups.TabIndex = 1;
			this.tabPageGroups.Text = "Groups";
			this.tabPageGroups.UseVisualStyleBackColor = true;
			// 
			// tabPageDisciplines
			// 
			this.tabPageDisciplines.Location = new System.Drawing.Point(4, 25);
			this.tabPageDisciplines.Name = "tabPageDisciplines";
			this.tabPageDisciplines.Size = new System.Drawing.Size(792, 421);
			this.tabPageDisciplines.TabIndex = 2;
			this.tabPageDisciplines.Text = "Disciplines";
			this.tabPageDisciplines.UseVisualStyleBackColor = true;
			// 
			// tabPageTeachers
			// 
			this.tabPageTeachers.Controls.Add(this.comboBoxStudentsDirection);
			this.tabPageTeachers.Controls.Add(this.labelDirectionSearch);
			this.tabPageTeachers.Controls.Add(this.labelStudentsGroup);
			this.tabPageTeachers.Controls.Add(this.comboBoxStudentsGroup);
			this.tabPageTeachers.Controls.Add(this.labelSearchTeacher);
			this.tabPageTeachers.Controls.Add(this.textBoxSearchStudent);
			this.tabPageTeachers.Controls.Add(this.statusStripTeachers);
			this.tabPageTeachers.Controls.Add(this.dataGridViewTeachers);
			this.tabPageTeachers.Location = new System.Drawing.Point(4, 25);
			this.tabPageTeachers.Name = "tabPageTeachers";
			this.tabPageTeachers.Size = new System.Drawing.Size(866, 421);
			this.tabPageTeachers.TabIndex = 3;
			this.tabPageTeachers.Text = "Teachers";
			this.tabPageTeachers.UseVisualStyleBackColor = true;
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
			this.dataGridViewTeachers.Size = new System.Drawing.Size(862, 355);
			this.dataGridViewTeachers.TabIndex = 0;
			// 
			// statusStripTeachers
			// 
			this.statusStripTeachers.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.statusStripTeachers.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelTeacherCount});
			this.statusStripTeachers.Location = new System.Drawing.Point(0, 395);
			this.statusStripTeachers.Name = "statusStripTeachers";
			this.statusStripTeachers.Size = new System.Drawing.Size(866, 26);
			this.statusStripTeachers.TabIndex = 1;
			this.statusStripTeachers.Text = "statusStrip1";
			// 
			// toolStripStatusLabelTeacherCount
			// 
			this.toolStripStatusLabelTeacherCount.Name = "toolStripStatusLabelTeacherCount";
			this.toolStripStatusLabelTeacherCount.Size = new System.Drawing.Size(233, 20);
			this.toolStripStatusLabelTeacherCount.Text = "toolStripStatusLabelTeacherCount";
			// 
			// textBoxSearchStudent
			// 
			this.textBoxSearchStudent.Location = new System.Drawing.Point(65, 10);
			this.textBoxSearchStudent.Name = "textBoxSearchStudent";
			this.textBoxSearchStudent.Size = new System.Drawing.Size(199, 22);
			this.textBoxSearchStudent.TabIndex = 2;
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
			// comboBoxStudentsGroup
			// 
			this.comboBoxStudentsGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.comboBoxStudentsGroup.FormattingEnabled = true;
			this.comboBoxStudentsGroup.Location = new System.Drawing.Point(343, 8);
			this.comboBoxStudentsGroup.Name = "comboBoxStudentsGroup";
			this.comboBoxStudentsGroup.Size = new System.Drawing.Size(183, 24);
			this.comboBoxStudentsGroup.TabIndex = 4;
			// 
			// labelStudentsGroup
			// 
			this.labelStudentsGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.labelStudentsGroup.AutoSize = true;
			this.labelStudentsGroup.Location = new System.Drawing.Point(280, 10);
			this.labelStudentsGroup.Name = "labelStudentsGroup";
			this.labelStudentsGroup.Size = new System.Drawing.Size(57, 16);
			this.labelStudentsGroup.TabIndex = 5;
			this.labelStudentsGroup.Text = "Группа:";
			// 
			// labelDirectionSearch
			// 
			this.labelDirectionSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.labelDirectionSearch.AutoSize = true;
			this.labelDirectionSearch.Location = new System.Drawing.Point(532, 11);
			this.labelDirectionSearch.Name = "labelDirectionSearch";
			this.labelDirectionSearch.Size = new System.Drawing.Size(100, 16);
			this.labelDirectionSearch.TabIndex = 6;
			this.labelDirectionSearch.Text = "Направление:";
			// 
			// comboBoxStudentsDirection
			// 
			this.comboBoxStudentsDirection.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.comboBoxStudentsDirection.FormattingEnabled = true;
			this.comboBoxStudentsDirection.Location = new System.Drawing.Point(638, 7);
			this.comboBoxStudentsDirection.Name = "comboBoxStudentsDirection";
			this.comboBoxStudentsDirection.Size = new System.Drawing.Size(220, 24);
			this.comboBoxStudentsDirection.TabIndex = 7;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(874, 450);
			this.Controls.Add(this.tabControlMain);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "MainForm";
			this.Text = "Academy";
			this.tabControlMain.ResumeLayout(false);
			this.tabPageTeachers.ResumeLayout(false);
			this.tabPageTeachers.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewTeachers)).EndInit();
			this.statusStripTeachers.ResumeLayout(false);
			this.statusStripTeachers.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TabControl tabControlMain;
		private System.Windows.Forms.TabPage tabPageStudents;
		private System.Windows.Forms.TabPage tabPageGroups;
		private System.Windows.Forms.TabPage tabPageDisciplines;
		private System.Windows.Forms.TabPage tabPageTeachers;
		private System.Windows.Forms.StatusStrip statusStripTeachers;
		private System.Windows.Forms.DataGridView dataGridViewTeachers;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelTeacherCount;
		private System.Windows.Forms.ComboBox comboBoxStudentsDirection;
		private System.Windows.Forms.Label labelDirectionSearch;
		private System.Windows.Forms.Label labelStudentsGroup;
		private System.Windows.Forms.ComboBox comboBoxStudentsGroup;
		private System.Windows.Forms.Label labelSearchTeacher;
		private System.Windows.Forms.TextBox textBoxSearchStudent;
	}
}

