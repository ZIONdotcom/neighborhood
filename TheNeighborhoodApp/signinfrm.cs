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

namespace TheNeighborhoodApp
{
    public partial class signinfrm : Form
    {

        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-09ORH5O\MSSQLSERVER01;Initial Catalog=neighborhoodDB;Integrated Security=True;Pooling=False");

            //  SqlConnection con = new SqlConnection();
        public signinfrm()
        {
            InitializeComponent();
        }

        private void signinfrm_Load(object sender, EventArgs e)
        {

        }

     /*   
        private void fnametxt_Enter(object sender, EventArgs e)
        {
            if (signupfnametxt.Text == " First Name")
            {
                signupfnametxt.Clear();
            }
        }

        private void fnametxt_Leave(object sender, EventArgs e)
        {
            if (signupfnametxt.Text == "")
            {
                signupfnametxt.Text = "First Name";
            }
        }

        private void lnametxt_Enter(object sender, EventArgs e)
        {
            if (signuplnametxt.Text == " Last Name")
            {
                signuplnametxt.Clear();
            }
        }

        private void lnametxt_Leave(object sender, EventArgs e)
        {
            if (signuplnametxt.Text == "")
            {
                signuplnametxt.Text = " Last Name";
            }
        }

        private void Streettxt_Enter(object sender, EventArgs e)
        {
            if (signupStreettxt.Text == " Street")
            {
                signupStreettxt.Clear();
            }
        }

        private void Streettxt_Leave(object sender, EventArgs e)
        {
            if (signupStreettxt.Text == "")
            {
                signupStreettxt.Text = " Street";
            }
        }

        private void homenumtxt_Enter(object sender, EventArgs e)
        {
            if (signuphomenumtxt.Text == " Home Number")
            {
                signuphomenumtxt.Clear();
            }
        }

        private void agetxt_Enter(object sender, EventArgs e)
        {
            if (signupfnametxt.Text == " Age")
            {
                signupfnametxt.Clear();
            }
        }

        private void homenumtxt_Leave(object sender, EventArgs e)
        {
            if (signuphomenumtxt.Text == "")
            {
                signuphomenumtxt.Text = " Home Number";
            }
        }

        private void agetxt_Leave(object sender, EventArgs e)
        {
            if (signuphomenumtxt.Text == "")
            {
                signuphomenumtxt.Text = " Age";
            }
        }
     */
        
        public string genderr()
        {
            string gender;
            if (female.Checked)
            {
                gender = "Female";
            }
            else if (male.Checked)
            {
                gender = "Male";
            }
            else if (other.Checked)
            {
                gender = "Other";
            }
            else
            {
                gender = "";
            }
            return gender;
        }

     
        private void button1_Click(object sender, EventArgs e)
        {
            string gender = genderr();

            if (signupfnametxt.Text == "" || signuplnametxt.Text == "" || gender =="" || signupStreettxt.Text == "" || signuphomenumtxt.Text == "" || signupagetxt.Text == "")
            {
                MessageBox.Show("Please fill all the fields.");
            }
            else
            {
                
                con.Open();

                string check = "Select Username FROM UserInfo WHERE Username = '"+signupusernametxt.Text+"'";

                SqlCommand cmd1 = new SqlCommand(check, con);
                string un = (string)cmd1.ExecuteScalar();
                if (un == signupusernametxt.Text)
                {
                    MessageBox.Show("Username already exist.");
                }
                else
                {
                    DateTime Today = DateTime.Today;

                    String insertInfo = "INSERT INTO UserInfo VALUES (@firstname, @lastname, @Age, @Street, @Homenumber, @gender, @Username, @Password, @UserType, @Dateregistered, @phonenumber, @verified)";
                    SqlCommand cmd = new SqlCommand(insertInfo, con);
                    cmd.Parameters.AddWithValue("@firstname", signupfnametxt.Text);
                    cmd.Parameters.AddWithValue("@lastname", signuplnametxt.Text);
                    cmd.Parameters.AddWithValue("@Age", int.Parse(signupagetxt.Text));
                    cmd.Parameters.AddWithValue("@Street", signupStreettxt.Text);
                    cmd.Parameters.AddWithValue("@Homenumber", int.Parse(signuphomenumtxt.Text));
                    cmd.Parameters.AddWithValue("@gender", gender);
                    cmd.Parameters.AddWithValue("@Username", signupusernametxt.Text);
                    cmd.Parameters.AddWithValue("@UserType", "Resident");
                    cmd.Parameters.AddWithValue("@Password", signuppasswordtxt.Text);
                    cmd.Parameters.AddWithValue("@Dateregistered", Today);
                    cmd.Parameters.AddWithValue("@phonenumber", signupnumtxt.Text);
                    cmd.Parameters.AddWithValue("@verified", "no");
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Succesfully registered! You can now log in your account.");
                }
               
                con.Close();
               

            }
        }
    }
}
