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

namespace EmployeeManagementSystem
{
    public partial class frmDepartment : Form
    {
        DepartmentClass dept = new DepartmentClass();
   
        public frmDepartment()
        {
            InitializeComponent();
            dgvdeptdetails.DataSource = dept.GetDepartments();
            
        }

        private void Department_Load(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                dept.Emp_Id = Convert.ToInt32(txtEmpId.Text.Trim());
                dept.JobName = txtJobName.Text.Trim();
                dept.Job_dept = txtJobDept.Text.Trim();
                dept.Designation = txtRole.Text.Trim();
                dept.SalaryRange = cmbSalary.SelectedItem.ToString();
                var success = dept.InsertDepartment(dept);
                dgvdeptdetails.DataSource = dept.GetDepartments();
                if (success)
                {
                    ClearControls();
                    MessageBox.Show("Department has been added successfully!");
                }
                else
                {
                    MessageBox.Show("Error occured. Please try again......");
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Emp. Id doesn't match with previous data. For new data first create one");
            }
            catch (FormatException fx)
            {
                MessageBox.Show(" Data mustn't be empty and Inputs should be in correct format.\nEmp.Id =>Integer");
            }
        }
        private void ClearControls()
        {
            txtJobId.Text = "";
            txtEmpId.Text = "";
            txtJobName.Text = "";
            txtJobDept.Text = "";
            txtRole.Text = "";
            cmbSalary.Text = "";
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                dept.JobId = Convert.ToInt32(txtJobId.Text.Trim());
                dept.Emp_Id = Convert.ToInt32(txtEmpId.Text.Trim());
                dept.JobName = txtJobName.Text.Trim();
                dept.Job_dept = txtJobDept.Text.Trim();
                dept.Designation = txtRole.Text.Trim();
                dept.SalaryRange = cmbSalary.SelectedItem.ToString();
                var success = dept.UpdateDepartment(dept);
                dgvdeptdetails.DataSource = dept.GetDepartments();
                if (success)
                {
                    ClearControls();
                    MessageBox.Show("Department has been updated successfully!");
                    btnAdd.Enabled = true;
                    btnUpdate.Enabled = false;
                    btnDelete.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Error occured. Please try again......");
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Emp. Id doesn't match with previous data. For new data first create one");
            }
            catch (FormatException fx)
            {
                MessageBox.Show("Data mustn't be empty Inputs should be in correct format.\nEmp.Id =>Integer");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            dept.JobId = Convert.ToInt32(txtJobId.Text.Trim());
            var success = dept.DeleteDepartment(dept);
            dgvdeptdetails.DataSource = dept.GetDepartments();
            if (success)
            {
                ClearControls();
                MessageBox.Show("Department has been Deleted successfully!");
                btnAdd.Enabled = true;
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
            }
            else
            {
                MessageBox.Show("Error occured. Please try again......");
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearControls();
            btnAdd.Enabled = true;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
        }

        private void dgvdeptdetails_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var index = e.RowIndex;
            txtJobId.Text = dgvdeptdetails.Rows[index].Cells[0].Value.ToString();
            txtEmpId.Text = dgvdeptdetails.Rows[index].Cells[1].Value.ToString();
            txtJobName.Text = dgvdeptdetails.Rows[index].Cells[2].Value.ToString();
            txtJobDept.Text = dgvdeptdetails.Rows[index].Cells[3].Value.ToString();
            txtRole.Text = dgvdeptdetails.Rows[index].Cells[4].Value.ToString();
            cmbSalary.Text = dgvdeptdetails.Rows[index].Cells[5].Value.ToString();
            btnAdd.Enabled = false;
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
    
}
