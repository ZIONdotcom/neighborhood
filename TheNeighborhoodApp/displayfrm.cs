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
    public partial class displayfrm : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-09ORH5O\MSSQLSERVER01;Initial Catalog=neighborhoodDB;Integrated Security=True;Pooling=False");

        public displayfrm()
        {
            InitializeComponent();
        }

        private void displayfrm_Load(object sender, EventArgs e)
        {
            signuptoppnl.Visible = false;
            loginpnl.Visible = true;
            contentpnl.Visible = false;
/*
            contentpnl.BringToFront();
            loginfrm login = new loginfrm();

            login.TopLevel = false;
            contentpnl.Controls.Add(login);
            login.BringToFront();
            login.Show();
*/
        }

        private void useradminbtn_Click(object sender, EventArgs e)
        {
            Userbtn.BackColor = Color.SteelBlue;
            adminbtn.BackColor = Color.White;
            usergroup.Visible = true;
            admingroup.Visible = false;
        }

        private void adminadminbtn_Click(object sender, EventArgs e)
        {
            Userbtn.BackColor = Color.White;
            adminbtn.BackColor = Color.SteelBlue;
            admingroup.Visible = true;
            usergroup.Visible = false;
        }

        private void Userbtn_Click(object sender, EventArgs e)
        {
            Userbtn.BackColor = Color.SteelBlue;
            adminbtn.BackColor = Color.White;
            usergroup.Visible = true;
            admingroup.Visible = false;
        }

        private void adminbtn_Click(object sender, EventArgs e)
        {
            Userbtn.BackColor = Color.White;
            adminadminbtn.BackColor = Color.SteelBlue;
            usergroup.Visible = false;
            admingroup.Visible = true;
        }
        /*
        private void usertxt_Enter(object sender, EventArgs e)
        {
            if (usertxt.Text == " Username")
            {
                usertxt.Clear();
            }
        }

        private void usertxt_Leave(object sender, EventArgs e)
        {
            if (usertxt.Text == "")
            {
                usertxt.Text = " Username";
            }
        }

        private void userpasswordtxt_Enter(object sender, EventArgs e)
        {
            if (userpasswordtxt.Text == " Password")
            {
                userpasswordtxt.Clear();
            }
        }

        private void userpasswordtxt_Leave(object sender, EventArgs e)
        {
            if (userpasswordtxt.Text == "")
            {
                userpasswordtxt.Text = " Password";
            }
        }

        private void admintxt_Enter(object sender, EventArgs e)
        {
            if (admintxt.Text == " Admin")
            {
                admintxt.Clear();
            }
        }

        private void admintxt_Leave(object sender, EventArgs e)
        {
            if (admintxt.Text == "")
            {
                admintxt.Text = " Admin";
            }
        }

        private void adminpasswordtxt_Enter(object sender, EventArgs e)
        {
            if (adminpasswordtxt.Text == " Password")
            {
                adminpasswordtxt.Clear();
            }
        }

        private void adminpasswordtxt_Leave(object sender, EventArgs e)
        {
            if (adminpasswordtxt.Text == "")
            {
                adminpasswordtxt.Text = " Password";
            }
        }
        */

        private void signupbtn_Click(object sender, EventArgs e)
        {
            toppnl.Visible = true;
            signuptoppnl.Visible = true;
            contentpnl.Visible = true;
            contentpnl.BringToFront();
            signinfrm signin = new signinfrm();
            signin.TopLevel = false;
            contentpnl.Controls.Add(signin);
            signin.BringToFront();
            signin.Show();
        }

        private void backpb_Click(object sender, EventArgs e)
        {

            contentpnl.Visible = false;
            loginpnl.Visible = true;
            signuptoppnl.Visible = false;
        }

        private void admingroup_Enter(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            adminpasswordtxt.PasswordChar = checkBox2.Checked ? '\0' : '*';
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            userpasswordtxt.PasswordChar = checkBox1.Checked ? '\0' : '*';
        }

        private string verify()
        {
            string verifyy = "";
            con.Open();
            string query = "SELECT Verified FROM userInfo where username = @username";

            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@username", usertxt.Text);
            SqlDataReader da = cmd.ExecuteReader();
            while (da.Read())
            {
                verifyy = da.GetValue(0).ToString();

             
            }
             con.Close();
            return verifyy;
           
        }
        private void resident()
        {
            string usertype = "Resident";
            string query = "SELECT * FROM userInfo WHERE Username = '" + usertxt.Text + "' AND password = '" + userpasswordtxt.Text + "' AND UserType = '" + usertype + "'";

            SqlDataAdapter ad = new SqlDataAdapter(query, con);

            DataTable dtable = new DataTable();
            ad.Fill(dtable);

           // MessageBox.Show(verify());
            if (dtable.Rows.Count > 0 && verify() == "yes")
            {
                MessageBox.Show("You're logged in and verified!");
                //show form with all of the function

            }
            else if (dtable.Rows.Count > 0 && verify() == "no")
            {
                MessageBox.Show("You're logged in and not yet  verified!");
                //show form with restriction of function
            }
            else
            {
                MessageBox.Show("Invalid credentials");
            }
        }

        private void admin()
        {
            string usertype = "Admin";
            string query = "SELECT * FROM userInfo WHERE Username = '" + admintxt.Text + "' AND password = '" + adminpasswordtxt.Text + "' AND UserType = '" + usertype + "'";

            SqlDataAdapter ad = new SqlDataAdapter(query, con);
            DataTable dtable = new DataTable();
            ad.Fill(dtable);

            if (dtable.Rows.Count > 0)
            {
                MessageBox.Show("you're now logged in as an ADMIN");
            }
            else
            {
                MessageBox.Show("invalid credentials");
            }
        }
        private void loginbtn_Click(object sender, EventArgs e)
        {
            if (usergroup.Visible == true)
            {
                resident(); 
            }
            else
            {
                admin();
            }
        }
    }
}
