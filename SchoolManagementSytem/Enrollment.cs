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
    public partial class Enrollment : Form
    {
        public Enrollment()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-1QNL6FK\SQLEXPRESS;Initial Catalog=Schooldb;Integrated Security=True");
            con.Open();

            SqlCommand cnn = new SqlCommand("insert into Enrollab values(@EnrollID,@StudentName,@Section,@Enrolldate)", con);
            cnn.Parameters.AddWithValue("@EnrollID", int.Parse(textBox1.Text));
            cnn.Parameters.AddWithValue("@StudentName", textBox2.Text);
            cnn.Parameters.AddWithValue("@Section", textBox3.Text);
            cnn.Parameters.AddWithValue("@EnrollDate", dateTimePicker1.Value);

            cnn.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record Inserted Successfully", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-1QNL6FK\SQLEXPRESS;Initial Catalog=Schooldb;Integrated Security=True");
            con.Open();

            SqlCommand cnn = new SqlCommand("select * from Enrollab", con);
            SqlDataAdapter sda = new SqlDataAdapter(cnn);
            DataTable table = new DataTable();
            sda.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
          
            using (SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-1QNL6FK\SQLEXPRESS;Initial Catalog=Schooldb;Integrated Security=True"))
            {
                SqlCommand cmd = new SqlCommand("UPDATE Enrollab SET [Student Name]=@n, [Section]=@s, [Enroll Date]=@d WHERE [Enroll ID]=@id", con);
                cmd.Parameters.AddWithValue("@id", int.Parse(textBox1.Text));
                cmd.Parameters.AddWithValue("@n", textBox2.Text);
                cmd.Parameters.AddWithValue("@s", textBox3.Text);
                cmd.Parameters.AddWithValue("@d", dateTimePicker1.Value);

                con.Open();
                MessageBox.Show(cmd.ExecuteNonQuery() > 0 ? "Record Updated Successfully" : "ID Not Found");
            }
        }

        

        private void btnDelete_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-1QNL6FK\SQLEXPRESS;Initial Catalog=Schooldb;Integrated Security=True"))
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM Enrollab WHERE [Enroll ID]=@id", con);
                cmd.Parameters.AddWithValue("@id", int.Parse(textBox1.Text));

                con.Open();
                MessageBox.Show(cmd.ExecuteNonQuery() > 0 ? "Record Deleted Successfully" : "ID Not Found");
            }
        }

        

        private void btnNew_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            dateTimePicker1.Value = DateTime.Now;
        }

        private void btnDisplay_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-1QNL6FK\SQLEXPRESS;Initial Catalog=Schooldb;Integrated Security=True");
            con.Open();

            SqlCommand cnn = new SqlCommand("select * from Enrollab", con);
            SqlDataAdapter sda = new SqlDataAdapter(cnn);
            DataTable table = new DataTable();
            sda.Fill(table);
            dataGridView1.DataSource = table;
        }
    }
}
