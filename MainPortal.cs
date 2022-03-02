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
    public partial class MainPortal : Form
    {
        private int childFormNumber = 0;
        bool formload = false;

        public MainPortal()
        {
            InitializeComponent();
        }
        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }



        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void departmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDepartment frmDepartment = new frmDepartment();
            frmDepartment.MdiParent = this;
            frmDepartment.Show();
        }


        public void FormExist(string formname)
        {
            FormCollection fc = Application.OpenForms;
            foreach (Form form in fc)
            {
                if (form.Name == formname)
                {
                    formload = true;
                }
            }
        }



        private void employeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEmployee frmEmployee = new frmEmployee();
            FormExist(frmEmployee.Name);
            if (formload == false)
            {
                frmEmployee.MdiParent = this;
                frmEmployee.Show();
            }

        }

        private void departmentDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDepartment frmDepartment = new frmDepartment();
            FormExist(frmDepartment.Name);
            if (formload == false)
            {
                frmDepartment.MdiParent = this;
                frmDepartment.Show();
            }

        }

        private void qualificationDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmQualification frmQualification = new frmQualification();
            FormExist(frmQualification.Name);
            if (formload == false)
            {
                frmQualification.MdiParent = this;
                frmQualification.Show();
            }

        }

        private void salaryDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSalary frmSalary= new frmSalary();
            FormExist(frmSalary.Name);
            if (formload == false)
            {
                frmSalary.MdiParent = this;
                frmSalary.Show();
            }

        }

        private void payrollDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPayroll frmPayroll = new frmPayroll();
            FormExist(frmPayroll.Name);
            if (formload == false)
            {
                frmPayroll.MdiParent = this;
                frmPayroll.Show();
            }
        }
    }
}
