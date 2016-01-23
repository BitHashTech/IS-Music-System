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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            this.ActiveControl = textBox1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-PDO5AM4\\SQLExpress;Initial Catalog=SoundSystem;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("Data_Entry", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter email = new SqlParameter("@mail", textBox1.Text);
            cmd.Parameters.Add(email);
            SqlParameter pass = new SqlParameter("@pass", textBox2.Text);
            cmd.Parameters.Add(pass);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                string name = (string)reader[0];
                Globals.email = textBox1.Text;
                MessageBox.Show("Welcome " + name);
                this.Hide();
                MainMenu main = new MainMenu(name,textBox1.Text);
                main.ShowDialog();
                this.Close();
            }
            else
                MessageBox.Show("Invalid email or password!");
            reader.Close();
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Signup signUp = new Signup();
            signUp.ShowDialog();
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        
    }
}
