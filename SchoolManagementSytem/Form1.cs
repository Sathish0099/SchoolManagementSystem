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

namespace SchoolManagementSytem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.AcceptButton = btnLogin;
        }


        private void btnLogin_Click(object sender, EventArgs e)
        {
           
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-1QNL6FK\SQLEXPRESS;Initial Catalog=Schooldb;Integrated Security=True");

            con.Open();
            String username = txtUsername.Text;
            String password = txtPassword.Text;

            string query = "SELECT username, password FROM logintable WHERE username = @username AND password = @password";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@password", password);

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);



            if (dt.Rows.Count > 0)
            {
                Main mn = new Main();
                mn.Show();

            }
            else
            {
                MessageBox.Show("Invalid Username or Password");
            }
            con.Close();


        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
