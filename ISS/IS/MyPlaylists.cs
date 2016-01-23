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
    public partial class MyPlaylists : Form
    {
        private class Item
        {
            public string Name;
            public int Value;
            public Item(string name, int value)
            {
                Name = name; Value = value;
            }
            public override string ToString()
            {
                // Generates the text shown in the combo box
                return Name;
            }
        }
        public MyPlaylists()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-PDO5AM4\\SQLExpress;Initial Catalog=SoundSystem;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("show_playlist", con);
            cmd.CommandType = CommandType.StoredProcedure;
            Item itm = (Item)comboBox1.SelectedItem;
            Console.WriteLine("{0}, {1}", itm.Name, itm.Value);
            SqlParameter idd = new SqlParameter("@id",itm.Value);
            cmd.Parameters.Add(idd);
            DataTable songs = new DataTable();
            songs.Columns.Add("Song_Name");
            DataRow row;
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                row = songs.NewRow();
                row["Song_Name"] = reader["Title"];
                songs.Rows.Add(row);
            }
            reader.Close();
            con.Close();
            dataGridView1.DataSource = songs;            
        }

        private void MyPlaylists_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-PDO5AM4\\SQLExpress;Initial Catalog=SoundSystem;Integrated Security=True");
            con.Open();

            SqlCommand cmd = new SqlCommand("select ID , Title from Playlist",con);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                int i = (int)reader[0];
                string str = (string)reader[1];
                comboBox1.Items.Add(new Item(str, i));
            }
            reader.Close();
            con.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
