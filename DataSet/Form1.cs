using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace DataSet
{
	public partial class Form1 : Form
	{
		string connectionString = "";
		SqlConnection connection = null;
		System.Data.DataSet groupsRelationData = null;
		public Form1()
		{
			InitializeComponent();
			connectionString = ConfigurationManager.ConnectionStrings["Academy_PD_311"].ConnectionString;
			connection = new SqlConnection(connectionString);
		}
	}
}
