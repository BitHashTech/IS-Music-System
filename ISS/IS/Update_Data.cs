using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace IS
{
    public partial class Update_Data : Form
    {
        string account, name;
        public Update_Data(string email, string nam)
        {
            InitializeComponent();
            label3.Text = "Welcome " + nam;
            account = email;
            name = nam;
        }

        private void Update_Data_Load(object sender, EventArgs e)
        {

        }

       

        private void button1_Click_1(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-PDO5AM4\\SQLExpress;Initial Catalog=SoundSystem;Integrated Security=True");
            con.Open();
            string update = @"update Account set Name = @name , Password = @password where E_mail = @account";
            SqlParameter user_name = new SqlParameter("@name", textBox1.Text);
            SqlParameter user_password = new SqlParameter("@password", textBox2.Text);
            SqlParameter account_name = new SqlParameter("@account", account);

            SqlCommand com = new SqlCommand(update, con);
            com.Parameters.Add(user_name);
            com.Parameters.Add(user_password);
            com.Parameters.Add(account_name);
            com.ExecuteNonQuery();
            MessageBox.Show("done!");
            con.Close();
            this.Close();
        }
    }
}
