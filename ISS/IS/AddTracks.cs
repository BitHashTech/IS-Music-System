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
    public partial class AddTracks : Form
    {
        public AddTracks()
        {
            InitializeComponent();
            this.ActiveControl = textBox1;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
                  
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-PDO5AM4\\SQLExpress;Initial Catalog=SoundSystem;Integrated Security=True");
            con.Open();
            string Title = textBox1.Text;
            //string Artist = textBox2.Text;
            string Duration = textBox3.Text;
            string add = @"insert into SoundTrack(Title,Duration) values (@Title,@Duration)";
            SqlCommand cmd = new SqlCommand(add, con);
            MessageBox.Show("Track added succeesfully!");
            SqlParameter prm = new SqlParameter("@Title", Title);
            cmd.Parameters.Add(prm);
            SqlParameter prm1 = new SqlParameter("@Duration", Duration);
            cmd.Parameters.Add(prm1);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
