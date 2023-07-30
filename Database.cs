using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsDatabase
{
    public class Database
    {
        static string myconnstring = ConfigurationManager.ConnectionStrings["connstring"].ConnectionString;

        public string regNum { get; set; }
        public string make { get; set; }
        public string engineSize { get; set; }
        public string dateReg { get; set; }
        public decimal rentalPerDay { get; set; }
        public bool available { get; set; }

        public Database(string regNum, string make, string engineSize, string dateReg, decimal rentalPerDay, bool available)
        {
            this.regNum = regNum;
            this.make = make;
            this.engineSize = engineSize;
            this.dateReg = dateReg;
            this.rentalPerDay = rentalPerDay;
            this.available = available;
        }

        public bool UpdateDatabase()
        {
            bool success = false;
            SqlConnection sqlCon = new SqlConnection(myconnstring);

            try
            {
                string sqlQuery = "UPDATE tblCar SET VehicleRegNo=@vehicleRegNo, Make=@make, EngineSize=@engineSize, DateRegistered=@dateRegistered, RentalPerDay=@rentalPerDay, Available=@available WHERE VehicleRegNo=@vehicleRegNo";

                SqlCommand cmd = new SqlCommand(sqlQuery, sqlCon);
                sqlCon.Open();
                cmd.Parameters.AddWithValue("@vehicleRegNo", regNum);
                cmd.Parameters.AddWithValue("@make", make);
                cmd.Parameters.AddWithValue("@engineSize", engineSize);
                cmd.Parameters.AddWithValue("@dateRegistered", dateReg);
                cmd.Parameters.AddWithValue("@rentalPerDay", rentalPerDay);
                cmd.Parameters.AddWithValue("@available", available);

                int rows = cmd.ExecuteNonQuery();

                success = (rows > 0);
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                sqlCon.Close();
            }

            return success;
        }

        public bool LoadData(out DataTable dataTable)
        {
            bool success = false;
            SqlConnection sqlCon = new SqlConnection(myconnstring);
            dataTable = new DataTable();

            try
            {
                string sqlQuery = "SELECT * FROM tblCar";
                SqlCommand cmd = new SqlCommand(sqlQuery, sqlCon);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                sqlCon.Open();
                adapter.Fill(dataTable);
                success = true;
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                sqlCon.Close();
            }

            return success;
        }

        public bool AddData()
        {
            bool success = false;
            SqlConnection sqlCon = new SqlConnection(myconnstring);

            try
            {
                string sqlQuery = "INSERT INTO tblCar(VehicleRegNo, Make, EngineSize, DateRegistered, RentalPerDay, Available) VALUES (@vehicleRegNo, @make, @engineSize, @dateRegistered, @rentalPerDay, @available)";
                SqlCommand cmd = new SqlCommand(sqlQuery, sqlCon);

                cmd.Parameters.AddWithValue("@vehicleRegNo", regNum);
                cmd.Parameters.AddWithValue("@make", make);
                cmd.Parameters.AddWithValue("@engineSize", engineSize);
                cmd.Parameters.AddWithValue("@dateRegistered", dateReg);
                cmd.Parameters.AddWithValue("@rentalPerDay", rentalPerDay);
                cmd.Parameters.AddWithValue("@available", available);
                sqlCon.Open();

                int rows = cmd.ExecuteNonQuery();

                success = (rows > 0);
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                sqlCon.Close();
            }

            return success;
        }

        public bool DeleteRecord()
        {
            bool success = false;
            SqlConnection sqlCon = new SqlConnection(myconnstring);
            try
            {
                string sqlQuery = "DELETE tblCar WHERE VehicleRegNo=@vehicleRegNo";
                SqlCommand cmd = new SqlCommand(sqlQuery, sqlCon);
                sqlCon.Open();

                cmd.Parameters.AddWithValue("@vehicleRegNo", regNum);

                int rows = cmd.ExecuteNonQuery();

                success = (rows > 0);
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                sqlCon.Close();
            }
            return success;
        }
    }
}
