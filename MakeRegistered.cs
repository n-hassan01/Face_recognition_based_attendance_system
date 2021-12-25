using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace MultiFaceRec
{
    public partial class MakeRegistered : Form
    {
        SqlConnection con;
        public MakeRegistered()
        {
            InitializeComponent();
            string constr = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=D:\ULAB\Fall2021\CSE416(c#)\Project\FaceRecProOV\MyDb.mdf;Integrated Security=True";
            con = new SqlConnection(constr);
        }

        private void MakeRegistered_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            string aa = "no";
            string usertype = "Student";
            string query = "SELECT user_name,roll_no,reg_date from Register_User where user_type='" + usertype + "'AND Registered='" + aa + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            BindingSource bs = new BindingSource();
            bs.DataSource = dt;
            dataGridView1.DataSource = bs;
            da.Update(dt);
            con.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            string aa = "no";
            string usertype = "Teacher";
            string query = "SELECT user_name,spec,reg_date from Register_User where user_type='" + usertype + "' AND Registered='" + aa + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            BindingSource bs = new BindingSource();
            bs.DataSource = dt;
            dataGridView1.DataSource = bs;
            da.Update(dt);
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 1 && dataGridView1.SelectedRows[0].Index != dataGridView1.Rows.Count - 1)
            {
                int aa = 1;
                string querry = "update Register_User set Registered='" + aa + "' where user_name='" + dataGridView1.SelectedRows[0].Cells[0].Value.ToString() + "'";
                SqlCommand cmd = new SqlCommand(querry, con);
                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Verified Registeration");

            }
            else
            {
                MessageBox.Show("Please Select row first Or Invalid Data", "Warning");

            }
            con.Close();
        
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string query = "SELECT user_name,u_date,u_time from AttendanceUser join Register_User on AttendanceUser.u_name=Register_User.Id";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            BindingSource bs = new BindingSource();
            bs.DataSource = dt;
            dataGridView1.DataSource = bs;
            da.Update(dt);
            con.Close();
        }

    }
}
