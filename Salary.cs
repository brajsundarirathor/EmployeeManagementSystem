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
    public class Salary
    { // Connection String decleration
        private static string myconn = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;


        // Class Properties Decleration
        public int Salary_Id { get; set; }
        public int Job_Id { get; set; }
        public string Amount { get; set; }

        public string Bonus { get; set; }
       


        //Database Queries Decleration
        private const string SelectQuery = "SELECT * FROM Salary_details";
        private const string InsertQuery = "INSERT INTO Salary_details(Job_Id,Amount,Bonus)VALUES(@Job_Id,@Amount,@Bonus)";
        private const string UpdateQuery = "UPDATE Salary_details SET Job_Id=@Job_Id,Amount=@Amount,Bonus=@Bonus WHERE  Salary_ID=@Salary_ID";
        private const string DeleteQuery = "DELETE FROM Salary_details WHERE  Salary_ID=@Salary_ID";


        // Public Methord Decleration
        public bool InsertSalary(Salary salary)
        {
            int rows;
            using (SqlConnection con = new SqlConnection(myconn))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(InsertQuery, con))
                {
                    cmd.Parameters.AddWithValue("@Job_Id", salary.Job_Id);
                    cmd.Parameters.AddWithValue("@Amount", salary.Amount);
                    cmd.Parameters.AddWithValue("@Bonus", salary.Bonus);
      

                    rows = cmd.ExecuteNonQuery();
                }
            }

            return (rows > 0) ? true : false;
        }

        public bool UpdateSalary(Salary salary)
        {
            int rows;
            using (SqlConnection con = new SqlConnection(myconn))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(UpdateQuery, con))
                {
                    cmd.Parameters.AddWithValue("@Job_Id", salary.Job_Id);
                    cmd.Parameters.AddWithValue("@Amount", salary.Amount);
                    cmd.Parameters.AddWithValue("@Bonus", salary.Bonus);

                    cmd.Parameters.AddWithValue("@Salary_ID", salary.Salary_Id);
                    rows = cmd.ExecuteNonQuery();
                }
            }
            return (rows > 0) ? true : false; ;

        }

        public bool DeleteSalary(Salary salary)
        {
            int rows;
            using (SqlConnection con = new SqlConnection(myconn))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(DeleteQuery, con))
                {
                    cmd.Parameters.AddWithValue("@Salary_Id", salary.Salary_Id);
                    rows = cmd.ExecuteNonQuery();
                }
            }
            return (rows > 0) ? true : false; ;
        }
        public DataTable GetSalary()
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

