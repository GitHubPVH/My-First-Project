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
    public partial class Test : Form
    {
        private int time = 40 * 60;
        private int index = 0;
        List<Questions> list = null;
        public Test()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            time--;
            lbTime.Text = "Time left :" + time / 60 + ":" + time % 60; ;
        }

        private void Test_Load(object sender, EventArgs e)
        {
            Test lg = new Test();
            lg.ShowDialog();
            Dataprocess dt = new Dataprocess();
            list = dt.GetQuestions();
            LoadQuestion(index, list);
            timer1.Start();
        }
     
        private void LoadQuestion(int index, List<Questions> list)
        {
            Questions q = list[index];
            rtContent.Text = q.Content;
            rdA.Text = q.A;
            rdB.Text = q.B;
            rdC.Text = q.C;
            rdD.Text = q.D;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            index--;
            LoadQuestion(index, list);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            index++;
            LoadQuestion(index, list);
        }
    }
}
