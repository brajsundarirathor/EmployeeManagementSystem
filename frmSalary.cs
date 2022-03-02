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
    public partial class frmSalary : Form
    {
        Salary salary = new Salary();
        public frmSalary()
        {
            InitializeComponent();
            dgvSalDetails.DataSource = salary.GetSalary();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                salary.Job_Id = Convert.ToInt32(txtjobId.Text.Trim());
                salary.Amount = txtAmount.Text.Trim();
                salary.Bonus = txtBonus.Text.Trim();
                var success = salary.InsertSalary(salary);
                dgvSalDetails.DataSource = salary.GetSalary();
                if (success)
                {
                    ClearControls();
                    MessageBox.Show("Salary has been added successfully!");
                }
                else
                {
                    MessageBox.Show("Error occured. Please try again......");
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Job Id doesn't match with previous data. For new data first create one");
            }
            catch (FormatException fx)
            {
                MessageBox.Show("Data mustn't be empty and Inputs should be in correct format.\nJob ID =>Integer");
            }
        }
        private void ClearControls()
        {
            txtSal_Id.Text = "";
            txtjobId.Text = "";
            txtAmount.Text = "";
            txtBonus.Text = "";
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                salary.Salary_Id = Convert.ToInt32(txtSal_Id.Text.Trim());
                salary.Job_Id = Convert.ToInt32(txtjobId.Text.Trim());
                salary.Amount = txtAmount.Text.Trim();
                salary.Bonus = txtBonus.Text.Trim();

                var success = salary.UpdateSalary(salary);
                dgvSalDetails.DataSource = salary.GetSalary();
                if (success)
                {
                    ClearControls();
                    MessageBox.Show("Salary has been updated successfully!");
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
                MessageBox.Show("Job Id doesn't match with previous data. For new data first create one");
            }
            catch (FormatException fx)
            {
                MessageBox.Show("Data mustn't be empty and Inputs should be in correct format.\nJob ID =>Integer");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            salary.Salary_Id = Convert.ToInt32(txtSal_Id.Text.Trim());
            var success = salary.DeleteSalary(salary);
            dgvSalDetails.DataSource = salary.GetSalary();
            if (success)
            {
                ClearControls();
                MessageBox.Show("Salary has been Deleted successfully!");
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

        private void dgvSalDetails_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var index = e.RowIndex;
            txtSal_Id.Text = dgvSalDetails.Rows[index].Cells[0].Value.ToString();
            txtjobId.Text = dgvSalDetails.Rows[index].Cells[1].Value.ToString();
            txtAmount.Text = dgvSalDetails.Rows[index].Cells[2].Value.ToString();
            txtBonus.Text = dgvSalDetails.Rows[index].Cells[3].Value.ToString();
            btnAdd.Enabled = false;
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
        }
    }
}
