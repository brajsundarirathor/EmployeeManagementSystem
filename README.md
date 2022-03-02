# EmployeeManagementSystem
it's an Internship project, we create a Employee Management System using C# Windows Form Application with database SQL connectivity.
we have also create the login form so before we started we have to login the form and then work on it. 
for the login form the login username is "user" and Password is "pass".



here the code for the form.

// for the employees form.
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
    public class Employee
    {
        // Connection String decleration
        private static string myconn = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;


        // Class Properties Decleration
        public int EmpId { get; set; }
        public string Emp_FName { get; set; }
        public string Emp_LName { get; set; }
        public int Emp_Age { get; set; }
        public string Emp_Contact { get; set; }
        public string Emp_Gender { get; set; }
        public string Emp_email { get; set; }


        //Database Queries Decleration
        private const string SelectQuery = "SELECT * FROM Emp_details1";
        private const string InsertQuery = "INSERT INTO Emp_details1(Emp_FName,Emp_LName ,Emp_Age,Emp_Contact,Emp_Gender,Emp_email)VALUES(@Emp_FName,@Emp_LName,@Emp_Age,@Emp_Contact,@Emp_Gender,@Emp_email)";
        private const string UpdateQuery = "UPDATE Emp_details1 SET Emp_FName = @Emp_FName,Emp_LName = @Emp_LName,Emp_Age=@Emp_Age,Emp_Contact=@Emp_Contact,Emp_Gender=@Emp_Gender,Emp_email=@Emp_email WHERE  EmpId=@EmpId";
        private const string DeleteQuery = "DELETE FROM Emp_details1 WHERE  EmpID=@EmpID";


        // Public Methord Decleration
        public bool InsertEmployee(Employee employee)
        {
            int rows;
            using (SqlConnection con = new SqlConnection(myconn))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(InsertQuery, con))
                {
                    cmd.Parameters.AddWithValue("@Emp_FName", employee.Emp_FName);
                    cmd.Parameters.AddWithValue("@Emp_LName", employee.Emp_LName);
                    cmd.Parameters.AddWithValue("@Emp_Age", employee.Emp_Age);
                    cmd.Parameters.AddWithValue("@Emp_Contact", employee.Emp_Contact);
                    cmd.Parameters.AddWithValue("@Emp_Gender", employee.Emp_Gender);
                    cmd.Parameters.AddWithValue("@Emp_email", employee.Emp_email);
                    rows = cmd.ExecuteNonQuery();
                }
            }

            return (rows > 0) ? true : false;
        }

        public bool UpdateEmployee(Employee employee)
        {
            int rows;
            using (SqlConnection con = new SqlConnection(myconn))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(UpdateQuery, con))
                {
                    cmd.Parameters.AddWithValue("@Emp_FName", employee.Emp_FName);
                    cmd.Parameters.AddWithValue("@Emp_LName", employee.Emp_LName);
                    cmd.Parameters.AddWithValue("@Emp_Age", employee.Emp_Age);
                    cmd.Parameters.AddWithValue("@Emp_Contact", employee.Emp_Contact);
                    cmd.Parameters.AddWithValue("@Emp_Gender", employee.Emp_Gender);
                    cmd.Parameters.AddWithValue("@Emp_email", employee.Emp_email);
                    cmd.Parameters.AddWithValue("@EmpId", employee.EmpId);
                    rows = cmd.ExecuteNonQuery();
                }
            }
            return (rows > 0) ? true : false; ;
 
        }

        public bool DeleteEmployee(Employee employee)
        {
            int rows;
            using (SqlConnection con = new SqlConnection(myconn))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(DeleteQuery, con))
                {
                    cmd.Parameters.AddWithValue("@EmpID", employee.EmpId);
                    rows = cmd.ExecuteNonQuery();
                }
            }
            return (rows > 0) ? true : false; ;
        }
        public DataTable GetEmployees()
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
