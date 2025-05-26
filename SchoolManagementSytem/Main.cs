using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SchoolManagementSytem
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnStudent_Click(object sender, EventArgs e)
        {
            Student student = new Student();
            student.Show();
        }

        private void btnSubject_Click(object sender, EventArgs e)
        {
            Subject subject = new Subject();
            subject.Show();
        }

        private void btnTeacher_Click(object sender, EventArgs e)
        {
            Teacher teacher = new Teacher();
            teacher.Show();
        }

        private void btnSection_Click(object sender, EventArgs e)
        {
            Section section = new Section();
            section.Show();
        }

        private void btnEnrollment_Click(object sender, EventArgs e)
        {
            Enrollment enrollment = new Enrollment();
            enrollment.Show();
        }

        private void btnAttendance_Click(object sender, EventArgs e)
        {
            Attendence attendance = new Attendence();
            attendance.Show();
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            Dashboard dashboard = new Dashboard();
            dashboard.Show();
        }
    }
}
