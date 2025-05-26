using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace SchoolManagementSytem
{
    public partial class Student : Form
    {
        public Student()
        {
            InitializeComponent();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker1.CustomFormat = "dd/MM/yyyy";
        }

        private void dateTimePicker1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back)
            {
                dateTimePicker1.CustomFormat = " ";
            }
           
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-1QNL6FK\SQLEXPRESS;Initial Catalog=Schooldb;Integrated Security=True");
            con.Open();

            SqlCommand cnn = new SqlCommand("insert into studentab values(@StudentID,@StudentName,@DateofBirth,@Gender,@Phoneno,@Emailid)",con);
            cnn.Parameters.AddWithValue("@StudentID",int.Parse(textBox1.Text));
            cnn.Parameters.AddWithValue("@StudentName", textBox2.Text);
            cnn.Parameters.AddWithValue("@DateOfBirth", dateTimePicker1.Value);
            cnn.Parameters.AddWithValue("@Gender", comboBox1.Text);
            cnn.Parameters.AddWithValue("@PhoneNo", textBox4.Text);
            cnn.Parameters.AddWithValue("@EmailID", textBox5.Text);
            

            // Inside your save/add button click event:
            string email = textBox5.Text;
            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";

            if (!Regex.IsMatch(email, emailPattern))
            {
                MessageBox.Show("Please enter a valid Email ID.", "Invalid Email", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // stop execution
            }

            cnn.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record Inserted Successfully", "Save",MessageBoxButtons.OK,MessageBoxIcon.Information);


        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-1QNL6FK\SQLEXPRESS;Initial Catalog=Schooldb;Integrated Security=True");
            con.Open();

            SqlCommand cnn = new SqlCommand("select * from studentab", con);
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
                SqlCommand cmd = new SqlCommand("UPDATE studentab SET [Student Name]=@StudentName, [Date of Birth]=@DateOfBirth, [Gender]=@Gender, [Phone No]=@PhoneNo, [Email ID]=@EmailID WHERE [Student ID]=@StudentID", con);
                cmd.Parameters.AddWithValue("@StudentID", int.Parse(textBox1.Text));
                cmd.Parameters.AddWithValue("@StudentName", textBox2.Text);
                cmd.Parameters.AddWithValue("@DateOfBirth", dateTimePicker1.Value);
                cmd.Parameters.AddWithValue("@Gender", comboBox1.Text);
                cmd.Parameters.AddWithValue("@PhoneNo", textBox4.Text);
                cmd.Parameters.AddWithValue("@EmailID", textBox5.Text);
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                    MessageBox.Show("Record Updated Successfully", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Update Failed: No matching Student ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnDelete_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-1QNL6FK\SQLEXPRESS;Initial Catalog=Schooldb;Integrated Security=True"))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM studentab WHERE [Student ID]=@StudentID", con);
                cmd.Parameters.AddWithValue("@StudentID", int.Parse(textBox1.Text));
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                    MessageBox.Show("Record Deleted Successfully", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Delete Failed: No matching Student ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
          textBox1.Text = "";
          textBox2.Text = "";
          comboBox1.Text = "";
          textBox4.Text = "";
          textBox5.Text = "";
          
        }

        private void btnDisplay_Click(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-1QNL6FK\SQLEXPRESS;Initial Catalog=Schooldb;Integrated Security=True");
            con.Open();

            SqlCommand cnn = new SqlCommand("select * from studentab", con);
            SqlDataAdapter sda = new SqlDataAdapter(cnn);
            DataTable table = new DataTable();
            sda.Fill(table);
            dataGridView1.DataSource = table;
        }
    }
}
