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
    public class Qualification
    {
        // Connection String decleration
        private static string myconn = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;


        // Class Properties Decleration
        public int Qual_Id { get; set; }
        public int Emp_ID { get; set; }
        public string Position { get; set; }

        public string Requirements { get; set; }
        public string Date_In { get; set; }



        //Database Queries Decleration
        private const string SelectQuery = "SELECT * FROM Qualification_details";
        private const string InsertQuery = "INSERT INTO Qualification_details(Emp_ID,Position,Requirements,Date_In)VALUES(@Emp_ID,@Position,@Requirements,@Date_In)";
        private const string UpdateQuery = "UPDATE Qualification_details SET Emp_ID=@Emp_ID,Position=@Position,Requirements=@Requirements,Date_In=@Date_In WHERE  Qual_ID=@Qual_ID";
        private const string DeleteQuery = "DELETE FROM Qualification_details WHERE  Qual_ID=@Qual_ID";


        // Public Methord Decleration
        public bool InsertQual(Qualification qual)
        {
            int rows;
            using (SqlConnection con = new SqlConnection(myconn))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(InsertQuery, con))
                {
                    cmd.Parameters.AddWithValue("@Emp_ID", qual.Emp_ID);
                    cmd.Parameters.AddWithValue("@Position", qual.Position);
                    cmd.Parameters.AddWithValue("@Requirements", qual.Requirements);
                    cmd.Parameters.AddWithValue("@Date_In", qual.Date_In);


                    rows = cmd.ExecuteNonQuery();
                }
            }

            return (rows > 0) ? true : false;
        }

        public bool UpdateQual(Qualification qual)
        {
            int rows;
            using (SqlConnection con = new SqlConnection(myconn))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(UpdateQuery, con))
                {
                    cmd.Parameters.AddWithValue("@Emp_ID", qual.Emp_ID);
                    cmd.Parameters.AddWithValue("@Position", qual.Position);
                    cmd.Parameters.AddWithValue("@Requirements", qual.Requirements);
                    cmd.Parameters.AddWithValue("@Date_In", qual.Date_In);


                    cmd.Parameters.AddWithValue("@Qual_ID", qual.Qual_Id);
                    rows = cmd.ExecuteNonQuery();
                }
            }
            return (rows > 0) ? true : false; ;

        }

        public bool DeleteQual(Qualification qual)
        {
            int rows;
            using (SqlConnection con = new SqlConnection(myconn))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(DeleteQuery, con))
                {
                    cmd.Parameters.AddWithValue("@Qual_ID", qual.Qual_Id);
                    rows = cmd.ExecuteNonQuery();
                }
            }
            return (rows > 0) ? true : false; ;
        }
        public DataTable GetQual()
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
