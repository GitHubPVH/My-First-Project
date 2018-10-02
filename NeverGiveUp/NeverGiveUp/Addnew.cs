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
    public partial class Addnew : Form
    {
        public Addnew()
        {
            InitializeComponent();
        }

        private void btnAddnew_Click(object sender, EventArgs e)
        {
            string id = txtIdQuestion.Text;
            
            string A = rtA.Text;
            string B = rtB.Text;
            string C = rtC.Text;
            string D = rtD.Text;
            string sid = cbLevel.SelectedItem.ToString();
            string crr = "";
            string content = rtContent.Text;
            if (sid.Equals("Topnotch 1"))
                sid = "TN1";
            if (sid.Equals("Topnotch 2"))
                sid = "TN2";
            if (sid.Equals("Topnotch 3"))
                sid = "TN3";
            if (sid.Equals("Summit 1"))
                sid = "SM1";
            if (rdA.Checked)
                crr = "_a";
            if (rdB.Checked)
                crr = "_b";
            if (rdC.Checked)
                crr = "_c";
            if (rdD.Checked)
                crr = "_d";

            DataProcess dt = new DataProcess();
            if (dt.AddQuestion(id, content, A, B, C, D, crr,sid))
            {
                string result = "";
                result += "Id : " + txtIdQuestion.Text + "\n";
                result += "Subject :  " + cbLevel.SelectedItem.ToString() + "\n";
                result += "Content : " + rtContent.Text + "\n";
               
                MessageBox.Show(result,"Detail");
            }
                
            else
                MessageBox.Show("FAILED");
        }
    }
}
