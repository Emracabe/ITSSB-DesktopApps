using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Session2
{
    public partial class EMMEmployee : Form
    {
        SqlCommand command;
        SqlDataReader dataReader;

        public EMMEmployee()
        {
            InitializeComponent();
            myComponents();
        }

        private void myComponents()
        {
            addDataToAssetsTable();
            this.FormClosing += Form2_FormClosing;
        }

        private void addDataToAssetsTable()
        {
            List<Asset> assets = new List<Asset>();

            String sql = "SELECT a.AssetSN, a.AssetName, MAX(em.EMEndDate) AS \"Last Closed EM\", COUNT(em.AssetID) AS \"Number of EMs\" FROM assets a LEFT JOIN  EmergencyMaintenances em ON em.AssetID = a.ID GROUP BY em.AssetID, a.AssetSN,a.AssetName;";

            command = new SqlCommand(sql, DBConnect.getConn());

            dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                string assetSN = dataReader.GetString(0);
                string assetName = dataReader.GetString(1);
                DateTime? lastclosedEM;
                if (dataReader.IsDBNull(2))
                {
                    lastclosedEM = null;
                }
                else
                {
                    lastclosedEM = dataReader.GetDateTime(2);
                }

                int numberOfEM = dataReader.GetInt32(3);

                Asset newAsset = new Asset(assetSN, assetName, lastclosedEM, numberOfEM);
                assets.Add(newAsset);
            }

            for (int i = 0; i < assets.Count; i++)
            {
                int n = assetsTable.Rows.Add();
                assetsTable.Rows[n].Cells[0].Value = assets[i].AssetSN;
                assetsTable.Rows[n].Cells[1].Value = assets[i].AssetName;
                assetsTable.Rows[n].Cells[2].Value = assets[i].LastClosedEM;
                assetsTable.Rows[n].Cells[3].Value = assets[i].NumberOfEMS;
            }

            for (int i = 0; i < assets.Count; i++)
            {
                if (assets[i].LastClosedEM == null)
                {
                    assetsTable.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                }
            }

            dataReader.Close();
            command.Dispose();
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void assetTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
        }

        private void Form2_FormClosing(Object sender, FormClosingEventArgs e)
        {
            if (DialogResult == DialogResult.Cancel)
            {
                Application.Exit();
            }
        }

        private void btnSendRequest_Click(Object sender, EventArgs e)
        {
            string assetSN = "";
            if (assetsTable.SelectedCells.Count > 0)
            {
                int selectedRowIndex = assetsTable.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = assetsTable.Rows[selectedRowIndex];
                assetSN = Convert.ToString(selectedRow.Cells[0].Value);

                if (assetSN == "")
                {
                    MessageBox.Show("Selected Asset is Empty!");
                }
                else
                {
                    this.Hide();
                    EMRequest eMRequest = new EMRequest(assetSN);
                    eMRequest.ShowDialog();
                }

            }
        }
    }

    class Asset
    {
        private String assetSN;
        private String assetName;
        private DateTime? lastClosedEM;
        private int numberOfEMS;

        public Asset(string assetSN, string assetName, DateTime? lastClosedEM, int numberOfEMS)
        {
            this.assetSN = assetSN;
            this.assetName = assetName;
            this.lastClosedEM = lastClosedEM;
            this.numberOfEMS = numberOfEMS;
        }

        public string AssetSN { get => assetSN; set => assetSN = value; }
        public string AssetName { get => assetName; set => assetName = value; }

        public int NumberOfEMS { get => numberOfEMS; set => numberOfEMS = value; }
        public DateTime? LastClosedEM { get => lastClosedEM; set => lastClosedEM = value; }
    }
}
