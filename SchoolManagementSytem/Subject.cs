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

namespace SchoolManagementSytem
{
    public partial class Subject : Form
    {
        public Subject()
        {
            InitializeComponent();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-1QNL6FK\SQLEXPRESS;Initial Catalog=Schooldb;Integrated Security=True");
            con.Open();

            SqlCommand cnn = new SqlCommand("insert into subtab values(@subjectid,@subjectname)", con);
            cnn.Parameters.AddWithValue("@SubjectID", int.Parse(textBox1.Text));
            cnn.Parameters.AddWithValue("@SubjectName", textBox2.Text);
          
            cnn.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record Inserted Successfully", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-1QNL6FK\SQLEXPRESS;Initial Catalog=Schooldb;Integrated Security=True");
            con.Open();

            SqlCommand cnn = new SqlCommand("select * from subtab", con);
            SqlDataAdapter sda = new SqlDataAdapter(cnn);
            DataTable table = new DataTable();
            sda.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void btnUpdate_Click_1(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-1QNL6FK\SQLEXPRESS;Initial Catalog=Schooldb;Integrated Security=True"))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("UPDATE subtab SET [Subject Name] = @SubjectName WHERE [Subject ID] = @SubjectID", con);
                cmd.Parameters.AddWithValue("@SubjectID", int.Parse(textBox1.Text));
                cmd.Parameters.AddWithValue("@SubjectName", textBox2.Text);

                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                    MessageBox.Show("Record Updated Successfully", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Update Failed: No matching Subject ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void btnDelete_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-1QNL6FK\SQLEXPRESS;Initial Catalog=Schooldb;Integrated Security=True"))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM subtab WHERE [Subject ID] = @SubjectID", con);
                cmd.Parameters.AddWithValue("@SubjectID", int.Parse(textBox1.Text));

                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                    MessageBox.Show("Record Deleted Successfully", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Delete Failed: No matching Subject ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void btnNew_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void btnDisplay_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-1QNL6FK\SQLEXPRESS;Initial Catalog=Schooldb;Integrated Security=True");
            con.Open();

            SqlCommand cnn = new SqlCommand("select * from subtab", con);
            SqlDataAdapter sda = new SqlDataAdapter(cnn);
            DataTable table = new DataTable();
            sda.Fill(table);
            dataGridView1.DataSource = table;
        }

        
        
    }
}
