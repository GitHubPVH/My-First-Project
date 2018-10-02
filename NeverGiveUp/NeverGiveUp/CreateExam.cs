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
    public partial class CreateExam : Form
    {
        List<Question> list = null;
        public CreateExam()
        {
            InitializeComponent();
        }

        private void btnRandom_Click(object sender, EventArgs e)
        {
            AdminModel model = new AdminModel();
            string sid =cbLevel.SelectedItem.ToString();
            if (sid.Equals("Topnotch 1"))
                sid = "TN1";
            if (sid.Equals("Topnotch 2"))
                sid = "TN2";
            if (sid.Equals("Topnotch 3"))
                sid = "TN3";
            if (sid.Equals("Summit 1"))
                sid = "SM1";
            MessageBox.Show(sid);
            //list = model.GetRandomQuestion(sid);
            //MessageBox.Show("Load Question Success");
            //btnCreate.Enabled = true;
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            string Examcode = txtExamcode.Text;
            AdminModel model = new AdminModel();
            if (model.AddExam(Examcode))
            {
                foreach (var item in list)
                {
                    model.AddExamDetail(Examcode, item.ID);

                }
                MessageBox.Show("ADD NEW SUCCESS");

            }
            else
                MessageBox.Show("ADD FAILED");
           
        }
    }
}
