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
    public partial class Payment : Form
    {
        public Payment()
        {
            InitializeComponent();
            AmountTb.Text = text;
            SeacrhName.Text = text;
        }

        private void label2_Click(object sender, EventArgs e)
        {
              Application.Exit();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=.;Initial Catalog=GymDb;Integrated Security=True");
        private void FillName()
        {
            Con.Open();
            SqlCommand cmd = new SqlCommand("select Mname from MemberTbl", Con);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();   
            Con.Close();
            dt.Load(rdr);
            dt.Columns.Add("Mname",typeof(string));
            NameCb.ValueMember = "Mname";
            NameCb.DataSource = dt;
        }
        private void populate()
        {
            Con.Open();
            string query = "select * from PaymentTbl";
            SqlDataAdapter sql = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder =  new SqlCommandBuilder();
            var ds = new DataSet();
            sql.Fill(ds);
            PaymentDGV.DataSource = ds.Tables[0];
            Con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (NameCb.Text == "" || AmountTb.Text == "" )
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                string payperiode = Periode.Value.Month.ToString()+Periode.Value.Year.ToString();
                Con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("select Count(*)from PaymentTbl where PMember='"+NameCb.SelectedValue.ToString()+"'and PMonth="+payperiode+"'",Con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows[0][0].ToString()== "1")
                {
                    MessageBox.Show("Already Paid For This Month");
                }
                else
                {
                    string query = "insert into PaymentTbl values('"+payperiode+"','"+NameCb.SelectedValue.ToString()+"','"+AmountTb.Text+")";
                    SqlCommand cmd = new SqlCommand(query,Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Amount Paid Successfully");
                }
                Con.Close();
                populate();
            }
        }
          private void filterByName()
          {
            Con.Open();
            string query = "select * from PaymentTbl where PMember='"+SeacrhName.Text+"'";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder =  new SqlCommandBuilder();
            var ds = new DataSet();
            sda.Fill(ds);
            PaymentDGV.DataSource = ds.Tables[0];
            Con.Close();
          }
        private void button4_Click(object sender, EventArgs e)
        {
            // NameCb.Text = "";
            AmountTb.Text = "";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm();
            mainForm.Show();
            this.Hide();
        }

        private void Payment_Load(object sender, EventArgs e)
        {
            FillName();
            populate();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            filterByName();
            SeacrhName.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            populate();
        }
        string text = "Buraya Yazınız";
         private void AmountTb_Enter(object sender, EventArgs e)
        {
            if (AmountTb.Text == text)
            {
                AmountTb.Text = "";
                AmountTb.ForeColor = Color.Black;
            }
        }

        private void AmountTb_Leave(object sender, EventArgs e)
        {
            if (AmountTb.Text == "")
            {
                AmountTb.Text = text;
                AmountTb.ForeColor = Color.Silver;
            }
        }

        private void SeacrhName_Enter(object sender, EventArgs e)
        {
            if (SeacrhName.Text == text)
            {
                SeacrhName.Text = "";
                SeacrhName.ForeColor = Color.Black;
            }
        }

        private void SeacrhName_Leave(object sender, EventArgs e)
        {
            if (SeacrhName.Text == "")
            {
                SeacrhName.Text = text;
                SeacrhName.ForeColor = Color.Silver;
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
