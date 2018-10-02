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
    public partial class MnAdmin : Form
    {
        public MnAdmin()
        {
            InitializeComponent();
        }

        private void addNewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Addnew ad = new Addnew();
            ad.Show();
        }

        private void editQuestionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditQuestion ed = new EditQuestion();
            ed.Show();
        }

        private void createExamToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateExam cr = new CreateExam();
            cr.Show();

        }
    }
}
