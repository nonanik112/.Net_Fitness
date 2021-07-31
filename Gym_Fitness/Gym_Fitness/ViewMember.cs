using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gym_Fitness
{
    public partial class ViewMember : Form
    {
        public ViewMember()
        {
            InitializeComponent();
            SeacrhMember.Text = text;
        }
        SqlConnection Con = new SqlConnection(@"Data Source=.;Initial Catalog=GymDb;Integrated Security=True");
        private void populate()
        {
            Con.Open();
            string query = "Select * from MemberTbl";
            SqlDataAdapter sql = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder =  new SqlCommandBuilder();
            var ds = new DataSet();
            sql.Fill(ds);
            MemberSD.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void ViewMember_Load(object sender, EventArgs e)
        {
             populate();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();
        }
        private void filterByName()
        {
            Con.Open();
            string query = "select * from MemberTbl where MName='"+SeacrhMember.Text+"'";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder =  new SqlCommandBuilder();
            var ds = new DataSet();
            sda.Fill(ds);
            MemberSD.DataSource = ds.Tables[0];
            Con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            filterByName();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            populate();
        }
        string text = "Buraya Yazınız";
        private void SeacrhMember_Enter(object sender, EventArgs e)
        {
            if (SeacrhMember.Text == text)
            {
                SeacrhMember.Text = "";
                SeacrhMember.ForeColor = Color.Black;
            }
        }

        private void SeacrhMember_Leave(object sender, EventArgs e)
        {
            if (SeacrhMember.Text == "")
            {
                SeacrhMember.Text = text;
                SeacrhMember.ForeColor = Color.Silver;
            }
        }
       bool Keep;
       int MouseX, MouseY;
        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (Keep == true)
            {
                this.Left = Cursor.Position.X - MouseX;
                this.Top = Cursor.Position.Y - MouseY;
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            Keep = false;
            MouseY = 0;
            MouseX = 0;
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            Keep = true;
            MouseX = Cursor.Position.X - this.Left;
            MouseY = Cursor.Position.Y - this.Top;
        }
    }
}
