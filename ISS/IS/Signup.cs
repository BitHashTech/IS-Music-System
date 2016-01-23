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
    public partial class Signup : Form
    {
        public Signup()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-PDO5AM4\\SQLExpress;Initial Catalog=SoundSystem;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("Mail_Check", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter mail = new SqlParameter("@mail", textBox2.Text);
            cmd.Parameters.Add(mail);
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                MessageBox.Show("This Email already has an account registered!");
                textBox2.Clear();
                reader.Close();
            }
            else
            {
                reader.Close();
                string upd = @"insert into Account(E_mail,Name,Password) values (@mail,@name,@pass)";
                SqlCommand cmd2 = new SqlCommand(upd, con);
                //MessageBox.Show("Registered succeesfully!");
                string user_name = textBox1.Text;
                string user_mail = textBox2.Text;
                string user_pass = textBox3.Text;
                Globals.email = textBox2.Text;
                SqlParameter prm = new SqlParameter("@name", user_name);
                cmd2.Parameters.Add(prm);
                SqlParameter prm1 = new SqlParameter("@mail", user_mail);
                cmd2.Parameters.Add(prm1);
                SqlParameter prm2 = new SqlParameter("@pass", user_pass);
                cmd2.Parameters.Add(prm2);
                //MessageBox.Show("Registered succeesfully!");
                cmd2.ExecuteNonQuery();
                MessageBox.Show("Registered succeesfully!");
                this.Hide();
                MainMenu main = new MainMenu(user_name,user_mail);
                main.ShowDialog();
                this.Close();
            }
            con.Close();
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
