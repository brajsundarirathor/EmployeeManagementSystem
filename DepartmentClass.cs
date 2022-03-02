using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementSystem
{
    public class DepartmentClass
    {
        // Connection String decleration
        private static string myconn = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;


        // Class Properties Decleration
        public int Emp_Id { get; set; }
        public int JobId { get; set; }
        public string JobName { get; set; }

        public string Job_dept { get; set; }
        public string Designation { get; set; }
        public string SalaryRange { get; set; }


        //Database Queries Decleration
        private const string SelectQuery = "SELECT * FROM Dept_details";
        private const string InsertQuery = "INSERT INTO Dept_details(Emp_Id,JobName,Job_dept,Designation,SalaryRange)VALUES(@Emp_Id,@JobName,@Job_dept,@Designation,@SalaryRange)";
        private const string UpdateQuery = "UPDATE Dept_details SET Emp_Id=@Emp_Id,JobName = @JobName,Job_dept=@Job_dept,Designation=@Designation,SalaryRange=@SalaryRange WHERE  JobId=@JobId";
        private const string DeleteQuery = "DELETE FROM Dept_details WHERE  JobID=@JobID";


        // Public Methord Decleration
        public bool InsertDepartment(DepartmentClass dept)
        {
            int rows;
            using (SqlConnection con = new SqlConnection(myconn))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(InsertQuery, con))
                {
                    cmd.Parameters.AddWithValue("@Emp_Id", dept.Emp_Id);
                    cmd.Parameters.AddWithValue("@JobName", dept.JobName);
                    cmd.Parameters.AddWithValue("@Job_dept", dept.Job_dept);
                    cmd.Parameters.AddWithValue("@Designation", dept.Designation);
                    cmd.Parameters.AddWithValue("@SalaryRange", dept.SalaryRange);

                    rows = cmd.ExecuteNonQuery();
                }
            }

            return (rows > 0) ? true : false;
        }

        public bool UpdateDepartment(DepartmentClass dept)
        {
            int rows;
            using (SqlConnection con = new SqlConnection(myconn))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(UpdateQuery, con))
                {
                    cmd.Parameters.AddWithValue("@Emp_Id", dept.Emp_Id);
                    cmd.Parameters.AddWithValue("@Job_Name", dept.JobName);
                    cmd.Parameters.AddWithValue("@Job_dept", dept.Job_dept);
                    cmd.Parameters.AddWithValue("@Designation", dept.Designation);
                    cmd.Parameters.AddWithValue("@SalaryRange", dept.SalaryRange);
                    cmd.Parameters.AddWithValue("@JobId", dept.JobId);
                    rows = cmd.ExecuteNonQuery();
                }
            }
            return (rows > 0) ? true : false; ;

        }

        public bool DeleteDepartment(DepartmentClass dept)
        {
            int rows;
            using (SqlConnection con = new SqlConnection(myconn))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(DeleteQuery, con))
                {
                    cmd.Parameters.AddWithValue("@JobID", dept.JobId);
                    rows = cmd.ExecuteNonQuery();
                }
            }
            return (rows > 0) ? true : false; ;
        }
        public DataTable GetDepartments()
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(myconn))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(SelectQuery, con))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                    }
                }
                
            }
            return dt;
        }
    }
}


