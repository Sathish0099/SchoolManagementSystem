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
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            display1();
            display2();
            display3();
            display4();
        }
        private void display1()
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-1QNL6FK\SQLEXPRESS;Initial Catalog=Schooldb;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM studentab", con);
            Int32 COUNT = Convert.ToInt32(cmd.ExecuteScalar());
            if (COUNT > 0)
            {
                lblcount.Text = Convert.ToString(COUNT.ToString());

            }
            else
            {
                lblcount.Text = "0";
            }
            con.Close();

        }
        private void display2()
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-1QNL6FK\SQLEXPRESS;Initial Catalog=Schooldb;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM subtab", con);
            Int32 COUNT = Convert.ToInt32(cmd.ExecuteScalar());
            if (COUNT > 0)
            {
                lblcount2.Text = Convert.ToString(COUNT.ToString());

            }
            else
            {
                lblcount2.Text = "0";
            }
            con.Close();

        }

        private void display3()
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-1QNL6FK\SQLEXPRESS;Initial Catalog=Schooldb;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM teacherab", con);
            Int32 COUNT = Convert.ToInt32(cmd.ExecuteScalar());
            if (COUNT > 0)
            {
                lblcount3.Text = Convert.ToString(COUNT.ToString());

            }
            else
            {
                lblcount3.Text = "0";
            }
            con.Close();

        }
        private void display4()
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-1QNL6FK\SQLEXPRESS;Initial Catalog=Schooldb;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Enrollab", con);
            Int32 COUNT = Convert.ToInt32(cmd.ExecuteScalar());
            if (COUNT > 0)
            {
                lblcount4.Text = Convert.ToString(COUNT.ToString());

            }
            else
            {
                lblcount4.Text = "0";
            }
            con.Close();

        }
    }
}
