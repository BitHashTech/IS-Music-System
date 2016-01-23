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
    public partial class CreateList : Form
    {
        public CreateList()
        {
            InitializeComponent();
        }

        private void CreateList_Load(object sender, EventArgs e)
        {
            this.ActiveControl = textBox1;
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-PDO5AM4\\SQLExpress;Initial Catalog=SoundSystem;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from SoundTrack", con);
            cmd.CommandType = CommandType.Text;
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
               checkedListBox1.Items.Add(reader["Title"]);
            }
            reader.Close();
            con.Close();
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-PDO5AM4\\SQLExpress;Initial Catalog=SoundSystem;Integrated Security=True");
            con.Open();
            int id = 1;
            string find = @"select ID from Account where Account.E_mail=@mail";
            string email=Globals.email;
            SqlCommand gl = new SqlCommand(find, con);
            SqlParameter pm = new SqlParameter("@mail", email);
            MessageBox.Show("d "+email);
            gl.Parameters.Add(pm);
            SqlDataReader reader1= gl.ExecuteReader();
            while (reader1.Read())
            {
                id=(int)reader1[0];
            }
            reader1.Close();
            string tit = textBox1.Text;
            string add = @"insert into Playlist(Title,Owner_ID) values (@title,@id)";
            SqlCommand cmd = new SqlCommand(add, con);
            SqlParameter prm = new SqlParameter("@title", tit);
            cmd.Parameters.Add(prm);
            SqlParameter prm1 = new SqlParameter("@id", id);
            cmd.Parameters.Add(prm1);
            cmd.ExecuteNonQuery();
            if (checkedListBox1.CheckedItems.Count != 0)
            {
                for (int scnt = 0; scnt < checkedListBox1.CheckedItems.Count; scnt++)
                {
                    string soundt = checkedListBox1.CheckedItems[scnt].ToString();
                    SqlCommand cm = new SqlCommand("select ID from SoundTrack where @stitle=SoundTrack.Title", con);
                    SqlParameter prma = new SqlParameter("@stitle", soundt);
                    cm.Parameters.Add(prma);
                    SqlDataReader rd = cm.ExecuteReader();
                    int sid=1;
                    while (rd.Read())
                    {
                        sid = (int)rd[0];
                    }
                    rd.Close();
                    string title = textBox1.Text;
                    SqlCommand c = new SqlCommand("select ID from Playlist where @title=Playlist.Title", con);
                    SqlParameter prm2 = new SqlParameter("@title", title);
                    c.Parameters.Add(prm2);
                    SqlDataReader r = c.ExecuteReader();
                    int pid=1;
                    while (r.Read())
                    {
                        pid = (int)r[0];
                    }
                    r.Close();

                    string add1 = @"insert into PlaylistTracks(SoundTrack_ID,Playlist_ID) values (@sid,@pid)";
                    SqlCommand a = new SqlCommand(add1, con);
                    SqlParameter sound = new SqlParameter("@sid", sid);
                    a.Parameters.Add(sound);
                    SqlParameter pl = new SqlParameter("@pid", pid);
                    a.Parameters.Add(pl);
                    a.ExecuteNonQuery();
                }
            }
            con.Close();
            MessageBox.Show("Playlist added succeesfully!");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
