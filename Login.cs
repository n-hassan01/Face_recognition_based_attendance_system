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
    public partial class Login : Form
    {
        SqlConnection con;
        public Login()
        {
            InitializeComponent();
            string constr = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=D:\ULAB\Fall2021\CSE416(c#)\Project\FaceRecProOV\MyDb.mdf;Integrated Security=True";
            con = new SqlConnection(constr);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string usertype="";
            string querry = "select * from Register_User where user_name='" + textBox1.Text + "' AND pwd='" + textBox3.Text + "'";
            SqlCommand cmd = new SqlCommand(querry, con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                usertype = dr["user_type"].ToString();

            }
            else
            {

                MessageBox.Show("Invalid Credintials");
            }
            if (usertype.Equals("Admin"))
            {
                
                MakeRegistered mr = new MakeRegistered();
                mr.Show();
            }
            else
            {
                this.Hide();
                FrmPrincipal fp = new FrmPrincipal();
                fp.Show();

            }
            con.Close();   
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
