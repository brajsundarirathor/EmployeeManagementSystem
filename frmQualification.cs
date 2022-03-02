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
    public partial class frmQualification : Form
    {
        Qualification qual = new Qualification();
        public frmQualification()
        {
            InitializeComponent();
            dgvQualDetails.DataSource = qual.GetQual();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                qual.Emp_ID = Convert.ToInt32(txtEmp_ID.Text.Trim());
                qual.Position = txtPosition.Text.Trim();
                qual.Requirements = txtRequire.Text.Trim();
                qual.Date_In = txtDate_In.Text.Trim();
                var success = qual.InsertQual(qual);
                dgvQualDetails.DataSource = qual.GetQual();
                if (success)
                {
                    ClearControls();
                    MessageBox.Show("Qualification has been added successfully!");
                }
                else
                {
                    MessageBox.Show("Error occured. Please try again......");
                }
            }
            catch(SqlException ex)
            {
                MessageBox.Show("Employee Id doesn't match with previous data. For new data first creat one");
            }
            catch (FormatException fx)
            {
                MessageBox.Show("Data mustn't be empty and Inputs should be in correct format.\nEmp.ID =>Integer");
            }

        }
        private void ClearControls()
        {
            txtQual_ID.Text = "";
            txtEmp_ID.Text = "";
            txtPosition.Text = "";
            txtRequire.Text = "";
            txtDate_In.Text = "";
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                qual.Qual_Id = Convert.ToInt32(txtQual_ID.Text.Trim());
                qual.Emp_ID = Convert.ToInt32(txtEmp_ID.Text.Trim());
                qual.Position = txtPosition.Text.Trim();
                qual.Requirements = txtRequire.Text.Trim();
                qual.Date_In = txtDate_In.Text.Trim();

                var success = qual.UpdateQual(qual);
                dgvQualDetails.DataSource = qual.GetQual();
                if (success)
                {
                    ClearControls();
                    MessageBox.Show("Qualification has been updated successfully!");
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
                MessageBox.Show("Employee Id doesn't match with previous data. For new data first creat one");
            }
            catch (FormatException fx)
            {
                MessageBox.Show(" Data mustn't be empty and Inputs should be in correct format.\nEmp.ID =>Integer");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            qual.Qual_Id= Convert.ToInt32(txtQual_ID.Text.Trim());
            var success = qual.DeleteQual(qual);
            dgvQualDetails.DataSource = qual.GetQual();
            if (success)
            {
                ClearControls();
                MessageBox.Show("Qualification has been Deleted successfully!");
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

        private void dgvQualDetails_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var index = e.RowIndex;
            txtQual_ID.Text = dgvQualDetails.Rows[index].Cells[0].Value.ToString();
            txtEmp_ID.Text = dgvQualDetails.Rows[index].Cells[1].Value.ToString();
            txtPosition.Text = dgvQualDetails.Rows[index].Cells[2].Value.ToString();
            txtRequire.Text = dgvQualDetails.Rows[index].Cells[3].Value.ToString();
            txtDate_In.Text = dgvQualDetails.Rows[index].Cells[4].Value.ToString();

            btnAdd.Enabled = false;
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
        }
    }
}
