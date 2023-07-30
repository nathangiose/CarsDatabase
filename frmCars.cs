using System.Data;
using System.Globalization;

namespace CarsDatabase
{
    public partial class frmCars : Form
    {
        public frmCars()
        {
            InitializeComponent();
            Text = $"Task A Keagan {DateTime.Today:d}";
        }

        static int recordsCount;
        static int rowNum = 0;

        private void frmCars_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        public Database ReadyDatabase()
        {
            string dateRegistered = "";

            Console.WriteLine($"{txtRentalPerDay.Text}, {txtDateRegistered.Text}");

            if (txtDateRegistered.Text != "")
            {
                dateRegistered = DateTime.ParseExact(txtDateRegistered.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("yyyy/MM/dd");
            }

            decimal rentalPerDay = 0;
            if (txtRentalPerDay.Text != "")
            {
                string fixedRPD = txtRentalPerDay.Text.Remove(0, 1);
                rentalPerDay = Convert.ToDecimal(fixedRPD);
            }

            return new Database(txtVehicleRegNo.Text, txtMake.Text, txtEngineSize.Text, dateRegistered, rentalPerDay, chkAvailable.Checked);
        }

        public void LoadData()
        {
            Database database = ReadyDatabase();

            bool success = database.LoadData(out DataTable dataTable);
            if (!success)
            {
                MessageBox.Show("Failed to load data");
            }
            else if(dataTable.Rows.Count > 0)
            {
                recordsCount = dataTable.Rows.Count;
                txtVehicleRegNo.Text = dataTable.Rows[0].Field<string>(0);
                txtMake.Text = dataTable.Rows[0].Field<string>(1);
                txtEngineSize.Text = dataTable.Rows[0].Field<string>(2);
                txtDateRegistered.Text = Convert.ToString(dataTable.Rows[0].Field<DateTime>(3).ToString("dd/MM/yyyy"));
                txtRentalPerDay.Text = Convert.ToString(dataTable.Rows[0].Field<decimal>(4).ToString("C"));
                chkAvailable.Checked = dataTable.Rows[0].Field<bool>(5);
                UpdateRecordDisplay();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtDateRegistered.Text != "")
            {
                Database database = ReadyDatabase();
                bool success = database.UpdateDatabase();
                if (success)
                {
                    MessageBox.Show("Successfully updated the database.", "Success");
                }
                else 
                {
                    MessageBox.Show("Failed to update the database.", "Error");
                }
            }
            else 
            {
                MessageBox.Show("None of the fields may be left blank");
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Database database = ReadyDatabase();
            bool success = database.AddData();
            if (success)
            {
                MessageBox.Show("Successfully added record to database.", "Success");
            }
            else 
            {
                MessageBox.Show("Failed to add record to database.", "Error");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Database database = ReadyDatabase();
            bool success = database.DeleteRecord();
            if (success)
            {
                MessageBox.Show("Successfully deleted record.", "Success");
            }
            else 
            {
                MessageBox.Show("Failed to delete record.", "Error");
            }

            btnFirst_Click(sender, e);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtVehicleRegNo.Text = "";
            txtMake.Text = "";
            txtEngineSize.Text = "";
            txtDateRegistered.Text = "";
            txtRentalPerDay.Text = "";
            chkAvailable.Checked = false;

            txtRecord.Text = "";
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            Database database = ReadyDatabase();
            bool success = database.LoadData(out DataTable dataTable);
            if (!success)
            {
                MessageBox.Show("Failed to load data");
            }
            else
            {
                recordsCount = dataTable.Rows.Count;

                if (rowNum < recordsCount - 1)
                {
                    rowNum++;
                    txtVehicleRegNo.Text = dataTable.Rows[rowNum].Field<string>(0);
                    txtMake.Text = dataTable.Rows[rowNum].Field<string>(1);
                    txtEngineSize.Text = dataTable.Rows[rowNum].Field<string>(2);
                    txtDateRegistered.Text = Convert.ToString(dataTable.Rows[rowNum].Field<DateTime>(3).ToString("dd/MM/yyyy"));
                    txtRentalPerDay.Text = Convert.ToString(dataTable.Rows[rowNum].Field<decimal>(4).ToString("C"));
                    chkAvailable.Checked = dataTable.Rows[rowNum].Field<bool>(5);
                }
                else
                {
                    btnFirst_Click(sender, e);
                }

                UpdateRecordDisplay();
            }
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            Database database = ReadyDatabase();
            bool success = database.LoadData(out DataTable dataTable);
            if (!success)
            {
                MessageBox.Show("Failed to load data");
            }
            else
            {
                recordsCount = dataTable.Rows.Count;

                if (rowNum > 0)
                {
                    rowNum--;
                    txtVehicleRegNo.Text = dataTable.Rows[rowNum].Field<string>(0);
                    txtMake.Text = dataTable.Rows[rowNum].Field<string>(1);
                    txtEngineSize.Text = dataTable.Rows[rowNum].Field<string>(2);
                    txtDateRegistered.Text = Convert.ToString(dataTable.Rows[rowNum].Field<DateTime>(3).ToString("dd/MM/yyyy"));
                    txtRentalPerDay.Text = Convert.ToString(dataTable.Rows[rowNum].Field<decimal>(4).ToString("C"));
                    chkAvailable.Checked = dataTable.Rows[rowNum].Field<bool>(5);
                }
                else
                {
                    btnLast_Click(sender, e);
                }

                UpdateRecordDisplay();
            }
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            Database database = ReadyDatabase();
            bool success = database.LoadData(out DataTable dataTable);
            if (!success)
            {
                MessageBox.Show("Failed to load data");
            }
            else
            {
                recordsCount = dataTable.Rows.Count;

                txtVehicleRegNo.Text = dataTable.Rows[0].Field<string>(0);
                txtMake.Text = dataTable.Rows[0].Field<string>(1);
                txtEngineSize.Text = dataTable.Rows[0].Field<string>(2);
                txtDateRegistered.Text = Convert.ToString(dataTable.Rows[0].Field<DateTime>(3).ToString("dd/MM/yyyy"));
                txtRentalPerDay.Text = Convert.ToString(dataTable.Rows[0].Field<decimal>(4).ToString("C"));
                chkAvailable.Checked = dataTable.Rows[0].Field<bool>(5);

                rowNum = 0;
                UpdateRecordDisplay();
            }
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            Database database = ReadyDatabase();
            bool success = database.LoadData(out DataTable dataTable);
            if (!success)
            {
                MessageBox.Show("Failed to load data");
            }
            else
            {
                recordsCount = dataTable.Rows.Count;

                txtVehicleRegNo.Text = dataTable.Rows[recordsCount - 1].Field<string>(0);
                txtMake.Text = dataTable.Rows[recordsCount - 1].Field<string>(1);
                txtEngineSize.Text = dataTable.Rows[recordsCount - 1].Field<string>(2);
                txtDateRegistered.Text = dataTable.Rows[recordsCount - 1].Field<DateTime>(3).ToString("dd/MM/yyyy");
                txtRentalPerDay.Text = dataTable.Rows[recordsCount - 1].Field<decimal>(4).ToString("C");
                chkAvailable.Checked = dataTable.Rows[recordsCount - 1].Field<bool>(5);

                rowNum = recordsCount - 1;
                UpdateRecordDisplay();
            }
        }

        public void UpdateRecordDisplay()
        {
            Database database = ReadyDatabase();
            bool success = database.LoadData(out DataTable dataTable);
            if (!success)
            {
                MessageBox.Show("Failed to load data");
            }
            else
            {
                recordsCount = dataTable.Rows.Count;
                txtRecord.Text = $"{rowNum + 1} of {recordsCount}";
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            const string message = "Do you want to Exit?";
            const string caption = "Exit App";

            var result = MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            frmSearch search = new frmSearch(this);
            search.Show();
            Hide();
        }
    }
}
