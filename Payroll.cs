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
    public class Payroll
    {
        // Connection String decleration
        private static string myconn = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;


        // Class Properties Decleration
        public int Payroll_Id { get; set; }
        public int Emp_ID { get; set; }
        public int Salary_ID { get; set; }
        public int Leaves { get; set; }
        public string Date { get; set; }

        public string Report { get; set; }
        public string Total_Amount { get; set; }



        //Database Queries Decleration
        private const string SelectQuery = "SELECT * FROM Payroll_details";
        private const string InsertQuery = "INSERT INTO Payroll_details(Emp_ID,Salary_ID,Leaves,Date,Report,Total_Amount)VALUES(@Emp_ID,@Salary_ID,@Leaves,@Date,@Report,@Total_Amount)";
        private const string UpdateQuery = "UPDATE Payroll_details SET Emp_ID=@Emp_ID,Salary_ID=@Salary_ID,Leaves=@Leaves,Date=@Date,Report=@Report,Total_Amount=@Total_Amount WHERE  Payroll_ID=@Payroll_ID";
        


        // Public Methord Decleration
        public bool InsertPayroll(Payroll payroll)
        {
            int rows;
            using (SqlConnection con = new SqlConnection(myconn))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(InsertQuery, con))
                {
                    cmd.Parameters.AddWithValue("@Emp_ID", payroll.Emp_ID);
                    cmd.Parameters.AddWithValue("@Salary_ID", payroll.Salary_ID);
                    cmd.Parameters.AddWithValue("@Leaves", payroll.Leaves);
                    cmd.Parameters.AddWithValue("@Date", payroll.Date);
                    cmd.Parameters.AddWithValue("@Report", payroll.Report);
                    cmd.Parameters.AddWithValue("@Total_Amount", payroll.Total_Amount);


                    rows = cmd.ExecuteNonQuery();
                }
            }

            return (rows > 0) ? true : false;
        }

        public bool UpdatePayroll(Payroll payroll)
        {
            int rows;
            using (SqlConnection con = new SqlConnection(myconn))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(UpdateQuery, con))
                {
                    cmd.Parameters.AddWithValue("@Emp_ID", payroll.Emp_ID);
                    cmd.Parameters.AddWithValue("@Salary_ID", payroll.Salary_ID);
                    cmd.Parameters.AddWithValue("@Leaves", payroll.Leaves);
                    cmd.Parameters.AddWithValue("@Date", payroll.Date);
                    cmd.Parameters.AddWithValue("@Report", payroll.Report);
                    cmd.Parameters.AddWithValue("@Total_Amount", payroll.Total_Amount);


                    cmd.Parameters.AddWithValue("@Payroll_ID", payroll.Payroll_Id);
                    rows = cmd.ExecuteNonQuery();
                }
            }
            return (rows > 0) ? true : false; ;

        }

        
        public DataTable GetPayroll()
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
