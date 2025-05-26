using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Text.RegularExpressions;   

namespace SchoolManagementSytem
{
    public partial class Section : Form
    {
        public Section()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-1QNL6FK\SQLEXPRESS;Initial Catalog=Schooldb;Integrated Security=True");
            con.Open();

            SqlCommand cnn = new SqlCommand("insert into sectionab values(@sectionid,@studentname,@section)", con);
            cnn.Parameters.AddWithValue("@SectionID", int.Parse(textBox1.Text));
            cnn.Parameters.AddWithValue("@StudentName", textBox2.Text);
            cnn.Parameters.AddWithValue("@Section", textBox3.Text);

            cnn.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record Inserted Successfully", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-1QNL6FK\SQLEXPRESS;Initial Catalog=Schooldb;Integrated Security=True");
            con.Open();

            SqlCommand cnn = new SqlCommand("select * from sectionab", con);
            SqlDataAdapter sda = new SqlDataAdapter(cnn);
            DataTable table = new DataTable();
            sda.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-1QNL6FK\SQLEXPRESS;Initial Catalog=Schooldb;Integrated Security=True"))
            {
                con.Open();
                var cmd = new SqlCommand("UPDATE sectionab SET [Student Name]=@name, [Section]=@section WHERE [Section ID]=@id", con);
                cmd.Parameters.AddWithValue("@id", int.Parse(textBox1.Text));
                cmd.Parameters.AddWithValue("@name", textBox2.Text);
                cmd.Parameters.AddWithValue("@section", textBox3.Text);

                int rows = cmd.ExecuteNonQuery();
                MessageBox.Show(rows > 0 ? "Updated Successfully" : "No Match Found", "Update",
                                MessageBoxButtons.OK, rows > 0 ? MessageBoxIcon.Information : MessageBoxIcon.Error);
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-1QNL6FK\SQLEXPRESS;Initial Catalog=Schooldb;Integrated Security=True"))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM sectionab WHERE [Section ID]=@SectionID", con);
                cmd.Parameters.AddWithValue("@SectionID", int.Parse(textBox1.Text));

                int rows = cmd.ExecuteNonQuery();
                MessageBox.Show(rows > 0 ? "Record Deleted Successfully" : "Delete Failed: No matching Section ID.",
                                "Delete", MessageBoxButtons.OK,
                                rows > 0 ? MessageBoxIcon.Information : MessageBoxIcon.Error);
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            
        }

        private void btnDisplay_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-1QNL6FK\SQLEXPRESS;Initial Catalog=Schooldb;Integrated Security=True");
            con.Open();

            SqlCommand cnn = new SqlCommand("select * from sectionab", con);
            SqlDataAdapter sda = new SqlDataAdapter(cnn);
            DataTable table = new DataTable();
            sda.Fill(table);
            dataGridView1.DataSource = table;
        }
    }
}
