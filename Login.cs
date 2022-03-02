using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmployeeManagementSystem
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string pass = txtPassword.Text;
            if (username == "user" && pass == "pass")
            {
                this.Hide();
                MainPortal mp = new MainPortal();
                mp.Show();
            }
            else
            {
                if (username != "user" && pass != "pass")
                {
                    MessageBox.Show("Invalid Username and Password");
                }
                else if (username != "user")
                {
                    MessageBox.Show("Invalid Username");
                }
                else if (pass != "pass")
                {
                    MessageBox.Show("Invalid Password");
                }
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtUsername.Clear();
            txtPassword.Clear();
        }
    }
}
