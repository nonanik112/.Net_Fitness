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
    public partial class UpdateDelete : Form
    {
        public UpdateDelete()
        {
            InitializeComponent();
            NameTb.Text = text;
            PhoneTb.Text = text;
            AgeTb.Text = text;
            AmountTb.Text = text;
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

        private void UpdateDelete_Load(object sender, EventArgs e)
        {
              populate();
        }

        private void label2_Click(object sender, EventArgs e)
        {
             Application.Exit();
        }
        
        int key = 0;
        private void MemberSD_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            key = Convert.ToInt32(MemberSD.SelectedRows[0].Cells[0].Value.ToString());
            NameTb.Text = MemberSD.SelectedRows[0].Cells[1].Value.ToString();
            PhoneTb.Text = MemberSD.SelectedRows[0].Cells[2].Value.ToString();
            GenderTb.Text = MemberSD.SelectedRows[0].Cells[3].Value.ToString();
            AgeTb.Text = MemberSD.SelectedRows[0].Cells[4].Value.ToString();
            AmountTb.Text = MemberSD.SelectedRows[0].Cells[5].Value.ToString();
            TimingTb.Text = MemberSD.SelectedRows[0].Cells[6].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
              if (key == 0 || NameTb.Text == "" || PhoneTb.Text == "" || AgeTb.Text == "" || AmountTb.Text == "" || GenderTb.Text == "" || TimingTb.Text == "" )
            {
                MessageBox.Show("Select the Member to Be Deleted");

            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "update MemberTbl set MName='"+NameTb.Text+"',MPhone='"+PhoneTb.Text+"',MGen='"+GenderTb.Text+"',MAge="+AgeTb.Text+",MAmount="+AmountTb.Text+",MTiming='"+TimingTb.Text+"'where MId="+key+";";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    Con.Close();
                    MessageBox.Show("Member Updated Successfully");
                }
                catch (Exception Ex)
                {

                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            NameTb.Text = "";
            AgeTb.Text = "";
            PhoneTb.Text = "";
            TimingTb.Text = "";
            AmountTb.Text = "";
            GenderTb.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
             if (key == 0)
            {
                MessageBox.Show("Select the Member to Be Deleted");

            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "Delete from MemberTbl where MId="+key+";";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    Con.Close();
                    MessageBox.Show("Member Deleted Successfully");
                }
                catch (Exception Ex)
                {

                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm();
            mainForm.Show();
            this.Hide();
        }
        string text = "Buraya Yazınız";
        private void NameTb_Enter(object sender, EventArgs e)
        {
            if (NameTb.Text == text)
            {
                NameTb.Text = "";
                NameTb.ForeColor = Color.Black;
            }
        }

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