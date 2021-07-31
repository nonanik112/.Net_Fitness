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
    public partial class AddMember : Form
    {
        public AddMember()
        {
            InitializeComponent();
            NameTb.Text = text;
            PhoneTb.Text = text;
            AgeTb.Text = text;
            AmountTb.Text = text;
            
        }
       SqlConnection Con = new SqlConnection(@"Data Source=.;Initial Catalog=GymDb;Integrated Security=True");
        private void AddMember_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (NameTb.Text == "" || PhoneTb.Text == "" || AmountTb.Text == "" || AgeTb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "insert into MemberTbl Values('" + NameTb.Text + "','" + PhoneTb.Text + "', '" + GenderCb.SelectedItem.ToString() + "'," + AgeTb.Text + "," + AmountTb.Text + ",'" + TimingCb.SelectedItem.ToString() + "')";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Member Successfully Added");
                    Con.Close();
                    AmountTb.Text = "";
                    AgeTb.Text = "";
                    NameTb.Text = "";
                    PhoneTb.Text = "";
                    GenderCb.SelectedItem = "";
                    TimingCb.SelectedItem = "";
                }
                catch (Exception Ex)
                {

                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AmountTb.Text = "";
            AgeTb.Text = "";
            NameTb.Text = "";
            PhoneTb.Text = "";
            GenderCb.SelectedItem = "";
            TimingCb.SelectedItem = "";
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm();
            mainForm.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();
        }

        private void NameTb_Enter(object sender, EventArgs e)
        {
            if (NameTb.Text == text)
            {
                NameTb.Text = "";
                NameTb.ForeColor = Color.Black;
            }
        }
        string text = "Buraya Yazınız";
        private void NameTb_Leave(object sender, EventArgs e)
        {
            if (NameTb.Text == "")
            {
                NameTb.Text = text;
                NameTb.ForeColor = Color.Silver;
            }
        }

        private void PhoneTb_Enter(object sender, EventArgs e)
        {
            if (PhoneTb.Text == text)
            {
                PhoneTb.Text = "";
                PhoneTb.ForeColor = Color.Black;
            }
        }

        private void PhoneTb_Leave(object sender, EventArgs e)
        {
            if (PhoneTb.Text == "")
            {
                PhoneTb.Text = text;
                PhoneTb.ForeColor = Color.Silver;
            }
        }

        private void AgeTb_Enter(object sender, EventArgs e)
        {
            if (AgeTb.Text == text)
            {
                AgeTb.Text = "";
                AgeTb.ForeColor = Color.Black;
            }
        }

        private void AgeTb_Leave(object sender, EventArgs e)
        {
            if (AgeTb.Text == "")
            {
                AgeTb.Text = text;
                AgeTb.ForeColor = Color.Silver;
            }
        }

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

        private void AgeTb_KeyPress(object sender, KeyPressEventArgs e)
        {
             e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void PhoneTb_KeyPress(object sender, KeyPressEventArgs e)
        {
           e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
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
