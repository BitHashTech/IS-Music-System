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
    public partial class AllTracks : Form
    {
        public AllTracks()
        {
            InitializeComponent();
        }

        private void AllTracks_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-PDO5AM4\\SQLExpress;Initial Catalog=SoundSystem;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from SoundTrack", con);
            cmd.CommandType = CommandType.Text;
            SqlDataReader reader = cmd.ExecuteReader();
            DataTable songs = new DataTable();
            songs.Columns.Add("Song_Name");
            songs.Columns.Add("Duration");
            DataRow row;
            while (reader.Read())
            {
                row = songs.NewRow();
                row["Song_Name"] = reader["Title"];
                row["Duration"] = reader["Duration"];
                songs.Rows.Add(row);
            }
            reader.Close();
            con.Close();
            dataGridView1.DataSource = songs;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-PDO5AM4\\SQLExpress;Initial Catalog=SoundSystem;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("Find", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter name = new SqlParameter("@name", textBox1.Text);
            if (textBox1.Text == "")//Show all
            {
                SqlCommand cmdd = new SqlCommand("select * from SoundTrack", con);
                cmdd.CommandType = CommandType.Text;
                SqlDataReader reader = cmdd.ExecuteReader();
                DataTable songs = new DataTable();
                songs.Columns.Add("Song_Name");
                songs.Columns.Add("Duration");
                DataRow row;
                while (reader.Read())
                {
                    row = songs.NewRow();
                    row["Song_Name"] = reader["Title"];
                    row["Duration"] = reader["Duration"];
                    songs.Rows.Add(row);
                }
                reader.Close();
                dataGridView1.DataSource = songs;
            }
            else
            {
                cmd.Parameters.Add(name);
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable songss = new DataTable();
                songss.Columns.Add("Song_Name");
                songss.Columns.Add("Duration");
                DataRow roww;

                while (reader.Read())
                {
                    roww = songss.NewRow();
                    roww["Song_Name"] = reader["Title"];
                    roww["Duration"] = reader["Duration"];
                    songss.Rows.Add(roww);
                }
                reader.Close();
                con.Close();
                dataGridView1.DataSource = songss;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
