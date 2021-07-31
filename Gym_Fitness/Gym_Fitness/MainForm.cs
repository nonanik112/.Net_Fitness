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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void bunifuThinButton24_Click(object sender, EventArgs e)
        {
            
            AddMember addMember = new AddMember();
            addMember.Show();
            this.Hide();
        }

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            ViewMember viewMembers = new ViewMember();
            viewMembers.Show();
            this.Hide();
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            UpdateDelete updateDelete = new UpdateDelete();
            updateDelete.Show();
            this.Hide();
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            Payment payment = new Payment();
            payment.Show();
            this.Hide();
        }
        bool Keep;
        int MouseX, MouseY;
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (Keep == true)
            {
                this.Left = Cursor.Position.X - MouseX;
                this.Top = Cursor.Position.Y - MouseY;
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            Keep = false;
            MouseY = 0;
            MouseX = 0;
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            Keep = true;
            MouseX = Cursor.Position.X - this.Left;
            MouseY = Cursor.Position.Y - this.Top;
        }
       
    }
}
