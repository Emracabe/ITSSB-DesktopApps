using System;
using System.Data.SqlClient;

namespace Session2
{
    public partial class Login : Form
    {
        SqlCommand command;
        SqlDataReader dataReader;
        String sql;

        public Login()
        {
            DBConnect.getConn().Open();
            InitializeComponent();
        }

        private void myComponent()
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnOk_Click(object sender, EventArgs e)
        {

            sql = $"SELECT * FROM employees WHERE Username = '{txtBoxUsername.Text}' AND Password = '{txtBoxPassword.Text}'";

            command = new SqlCommand(sql, DBConnect.getConn());

            dataReader = command.ExecuteReader();

            if (dataReader.HasRows)
            {
                dataReader.Close();
                command.Dispose();
                this.Hide();
                EMMEmployee form2 = new EMMEmployee();
                form2.ShowDialog();
            } else
            {
                MessageBox.Show("Invalid Username or Password");
            }

            dataReader.Close();
            command.Dispose();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DBConnect.getConn().Close();
            this.Close();
        }

        private void txtBoxUsername_TextChanged(object sender, EventArgs e)
        {

        }
    }
}