using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using System.Data.SqlClient;
using System.Data.SQLite;

namespace CSC262_Final
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            using var conn = new SQLiteConnection("Data Source=users.db;");
            conn.Open();

            string query = "SELECT * FROM Users WHERE Username=@username AND Password=@password";
            using var cmd = new SQLiteCommand(query, conn);
            cmd.Parameters.AddWithValue("@username", txtUsername.Text);
            cmd.Parameters.AddWithValue("@password", txtPassword.Text);

            using var reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                MessageBox.Show("Login successful!");
                this.Hide();
                new Dashboard().Show();
            }
            else
            {
                MessageBox.Show("Invalid username or password.");
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            new Register().Show();
        }
    }
}
