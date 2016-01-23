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
    public partial class MainMenu : Form
    {
        string account, name;
        public MainMenu(string nam, string email)
        {
            InitializeComponent();
            account = email;
            name = nam;
            label1.Text = name;    
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Soundtracks soundtracks = new Soundtracks();
            soundtracks.ShowDialog();
            this.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Playlists pl = new Playlists();
            this.Hide();
            pl.ShowDialog();
            this.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Update_Data upt = new Update_Data(account, name);
            upt.ShowDialog();
            this.Show();
        }
    }
}
