using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace CarsDatabase
{
    public partial class frmSearch : Form
    {
        public frmCars cars { get; set; }

        public frmSearch()
        {
            InitializeComponent();
        }

        public frmSearch(frmCars cars)
        {
            InitializeComponent();
            Initialise();
            this.cars = cars;
        }

        private void Initialise() 
        {
            this.Text = "Nathan Giose - Task A - " + DateTime.Now.ToShortDateString();
        }

        static string myconnstring = ConfigurationManager.ConnectionStrings["connstring"].ConnectionString;

        private void btnRun_Click(object sender, EventArgs e)
        {
            string field, sOperator, value;

            field = cboField.Text;
            sOperator = cboOperator.Text;
            value = txtValue.Text;

            if (field == "Available" && value == "Yes")
            {
                value = true.ToString();
            }
            else if (field == "Available" && value == "No")
            {
                value = false.ToString();
            }

            SqlConnection sqlCon = new SqlConnection(myconnstring);
            DataTable dataTable = new DataTable();

            try
            {
                string sqlQuery = "SELECT * FROM tblCar1 WHERE " + field + sOperator + "@Value";
                SqlCommand cmd = new SqlCommand(sqlQuery, sqlCon);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                sqlCon.Open();
                cmd.Parameters.AddWithValue("@Value", value);

                adapter.Fill(dataTable);

                //if satement for preventing unnecessary result errors from displaying
                if (field == "VehicleRegNo" && sOperator != "=" || field == "Make" && sOperator != "=" || field == "Available" && sOperator != "=")
                {
                    MessageBox.Show($"You can't use the {field} field with the {sOperator} operator", "Invalid Input", MessageBoxButtons.OK);
                    dataTable.Clear();
                }

                dgvCars.DataSource = dataTable;

                //Changing the display format of the date registered and rental per day displayed
                dgvCars.Columns[3].DefaultCellStyle.Format = "dd/MM/yyyy";
                dgvCars.Columns[4].DefaultCellStyle.Format = "C";
                dgvCars.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show(sqlEx.Message);

            }
            finally
            {
                sqlCon.Close();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            cars.Show();
            Hide();
        }

        private void frmSearch_FormClosed(object sender, FormClosedEventArgs e)
        {
            cars.Show();
        }
    }
}
