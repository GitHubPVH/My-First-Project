using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientApp
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string user = txtUserName.Text;
            string pass = txtPassword.Text;
            Dataprocess dt = new Dataprocess();
            if (dt.CheckLogin(user, pass) == true)
            {
                Test tt = new Test();
                tt.Show();
                
            }
            else
            {
                MessageBox.Show(this, "LOGIN FAILED", "RESULT", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUserName.Text = "";
                txtPassword.Text = "";
                txtUserName.Focus();
            }
        }
    }
}
