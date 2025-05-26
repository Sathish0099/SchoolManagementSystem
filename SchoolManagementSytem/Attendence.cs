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

namespace SchoolManagementSytem
{
    public partial class Attendence : Form
    {
        public Attendence()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-1QNL6FK\SQLEXPRESS;Initial Catalog=Schooldb;Integrated Security=True");
            con.Open();

            SqlCommand cnn = new SqlCommand("insert into attenab values(@Aid,@studentname,@status)", con);
            cnn.Parameters.AddWithValue("@AID", int.Parse(textBox1.Text));
            cnn.Parameters.AddWithValue("@StudentName", textBox2.Text);
            cnn.Parameters.AddWithValue("@Status", textBox3.Text);
            

            cnn.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record Inserted Successfully", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-1QNL6FK\SQLEXPRESS;Initial Catalog=Schooldb;Integrated Security=True");
            con.Open();

            SqlCommand cnn = new SqlCommand("select * from attenab", con);
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
                SqlCommand cnn = new SqlCommand("UPDATE attenab SET [Student Name]=@studentname, [Status]=@status WHERE [AId]=@aid", con);
                cnn.Parameters.AddWithValue("@aid", int.Parse(textBox1.Text));
                cnn.Parameters.AddWithValue("@studentname", textBox2.Text);
                cnn.Parameters.AddWithValue("@status", textBox3.Text);

                int result = cnn.ExecuteNonQuery();
                con.Close();

                MessageBox.Show(result > 0 ? "Record Updated Successfully" : "ID Not Found", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        

        private void btnDelete_Click(object sender, EventArgs e)
        {
           
            using (SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-1QNL6FK\SQLEXPRESS;Initial Catalog=Schooldb;Integrated Security=True"))
            {
                con.Open();
                SqlCommand cnn = new SqlCommand("DELETE FROM attenab WHERE [AId]=@aid", con);
                cnn.Parameters.AddWithValue("@aid", int.Parse(textBox1.Text));

                int result = cnn.ExecuteNonQuery();
                con.Close();

                MessageBox.Show(result > 0 ? "Record Deleted Successfully" : "ID Not Found", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

            SqlCommand cnn = new SqlCommand("select * from attenab", con);
            SqlDataAdapter sda = new SqlDataAdapter(cnn);
            DataTable table = new DataTable();
            sda.Fill(table);
            dataGridView1.DataSource = table;
        }
    }
}
