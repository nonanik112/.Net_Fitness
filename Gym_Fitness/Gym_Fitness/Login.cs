using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gym_Fitness
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
             if (UidTb.Text == "" || PassTb.Text == "")
            {
                MessageBox.Show("Missing Information");

            }
            else if (UidTb.Text == "Admin" && PassTb.Text == "Admin")
            {
                MainForm mainForm = new MainForm();
                mainForm.Show();
                this.Hide();

            }
            else
            {
                MessageBox.Show("Wrong Id or Password");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UidTb.Text = "";
            PassTb.Text = "";
        }
       
        private void label5_Click(object sender, EventArgs e)
        {
             Application.Exit();
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

