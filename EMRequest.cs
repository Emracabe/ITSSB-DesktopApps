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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Session2
{
    class Priority
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }

    public partial class EMRequest : Form
    {
        SqlCommand? command;
        SqlDataReader? dataReader;
        SqlDataAdapter? adapter = new SqlDataAdapter();
        string selectedAssetSN;

        public EMRequest(string selectedAssetSN)
        {
            InitializeComponent();
            this.selectedAssetSN = selectedAssetSN;
            this.FormClosing += this.EMRequest_Closing;
            addAssetInformation();
            populatePriorityComboBox();
        }

        private void populatePriorityComboBox()
        {
            List<Priority> priorities = new List<Priority>();

            string sql = "SELECT * FROM priorities";

            command = new SqlCommand(sql, DBConnect.getConn());
            dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                string pName = Convert.ToString(dataReader.GetValue(1));
                priorities.Add(new Priority() { Name = pName, Value = pName });
            }

            priorityComboBox.DataSource = priorities;
            priorityComboBox.DisplayMember = "Name";
            priorityComboBox.ValueMember = "Value";

            priorityComboBox.DropDownStyle = ComboBoxStyle.DropDownList;

            dataReader.Close();
            command.Dispose();
        }

        private void addAssetInformation()
        {
            string sql = $"SELECT a.AssetSN, a.AssetName, d.Name FROM assets a LEFT JOIN DepartmentLocations dl ON a.DepartmentLocationID = dl.ID LEFT JOIN Departments d ON dl.DepartmentID = d.ID\r\nWHERE a.AssetSN = '{selectedAssetSN}'";

            command = new SqlCommand(sql, DBConnect.getConn());

            dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                string assetSN = Convert.ToString(dataReader.GetValue(0));
                string assetName = Convert.ToString(dataReader.GetValue(1));
                string department = Convert.ToString(dataReader.GetValue(2));

                txtAssetSN.Text = assetSN;
                txtAssetName.Text = assetName;
                txtDepartment.Text = department;

                break;
            }

            command.Dispose();
            dataReader.Close();
        }

        private void EMRequest_Closing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult == DialogResult.Cancel)
            {
                Application.Exit();
            }
        }

        private int getPriorityID()
        {
            string sql = $"SELECT id FROM priorities WHERE Name='{priorityComboBox.SelectedValue.ToString()}'";

            command = new SqlCommand(sql, DBConnect.getConn());
            dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                int id = Convert.ToInt32(dataReader.GetValue(0));
                dataReader.Close();
                command.Dispose();
                return id;
            }

            return 0;
        }

        private int getAssetID()
        {
            string sql = $"SELECT id FROM assets WHERE AssetSN='{selectedAssetSN}'";

            command = new SqlCommand(sql, DBConnect.getConn());
            dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                int id = Convert.ToInt32(dataReader.GetValue(0));
                dataReader.Close();
                command.Dispose();
                return id;
            }

            return 0;
        }

        private void btnSendRequest_Click(object sender, EventArgs e)
        {
            string sql = $"INSERT INTO EmergencyMaintenances(AssetID, PriorityID, DescriptionEmergency, OtherConsiderations, EMReportDate, EMStartDate, EMEndDate, EMTechnicianNote) VALUES({getAssetID()}, {getPriorityID()}, '{txtBoxDescription.Text}', '{txtBoxConsideration.Text}', '{DateTime.Now.ToString("yyyy-MM-dd")}', NULL, NULL, '');";
       
            command = new SqlCommand(sql, DBConnect.getConn());
            adapter.InsertCommand = new SqlCommand(sql, DBConnect.getConn());
            int isInserted = adapter.InsertCommand.ExecuteNonQuery();

            if (isInserted > 0)
            {
                MessageBox.Show("Request sent!");
                this.Hide();
                EMMEmployee eMMEmployee = new EMMEmployee();
                eMMEmployee.ShowDialog();
            } 
            else
            {
                MessageBox.Show("Request not sent!");
            }

            command.Dispose();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
            EMMEmployee eMMEmployee = new EMMEmployee();
            eMMEmployee.ShowDialog();
        }
    }
}
