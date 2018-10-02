using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NeverGiveUp
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string user = txtUser.Text;
            string pass = txtPass.Text;
            DataProcess dt = new DataProcess();
            if(dt.CheckLogin(user,pass)==true)
            {
                MnAdmin mn = new MnAdmin();
                this.Hide();
                mn.ShowDialog();
                this.Show();

            } 
            else
            {
                MessageBox.Show(this, "Login Failed ", "Result ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUser.Text = "";
                txtPass.Text = "";
                txtUser.Focus();
            }

            
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(MessageBox.Show("Do you want to close application","Notification",MessageBoxButtons.OKCancel,MessageBoxIcon.Question) != System.Windows.Forms.DialogResult.OK)

            {
                e.Cancel = true;
            }
        }
    }
}
