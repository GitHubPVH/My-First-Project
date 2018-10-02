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
    public partial class EditQuestion : Form
    {
        public EditQuestion()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string id = txtSearchEdit.Text;
            DataProcess dt = new DataProcess();
            dataGridView1.DataSource = dt.SearchById(id);
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnViewall_Click(object sender, EventArgs e)
        {
            DataProcess dt = new DataProcess();
            dataGridView1.DataSource = dt.GetQuestions();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtIdQuestionEdit.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            cbLevelEdit.Text= dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            rtContentEdit.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            rtAEdit.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            rtBEdit.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            rtCEdit.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            rtDEdit.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            txtCorrect.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string id = txtIdQuestionEdit.Text;
            DataProcess dt = new DataProcess();
            if (dt.DeleteQuestion(id) == true)
            {
                dataGridView1.DataSource = dt.GetQuestions();
                ResetGUI();
                MessageBox.Show("DELETE QUESTION SUCCESS", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
                MessageBox.Show("DELETE QUESTION FAIL");
        }

        private void ResetGUI()
        {
            txtIdQuestionEdit.Text = "";
            txtCorrect.Text = "";
            cbLevelEdit.Text = "";
            rtContentEdit.Text = "";
            rtAEdit.Text = "";
            rtBEdit.Text = "";
            rtCEdit.Text = "";
            rtDEdit.Text = "";


        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string id = txtIdQuestionEdit.Text;
            string level = cbLevelEdit.Text;
            string content = rtContentEdit.Text;
            string correct = txtCorrect.Text;
            string a = rtAEdit.Text;
            string b = rtBEdit.Text;
            string c = rtCEdit.Text;
            string d = rtDEdit.Text;
            DataProcess dt = new DataProcess();
            if (dt.UpdateQuestion(id, level, content, correct, a, b, c, d) == true)
            {
                dataGridView1.DataSource = dt.GetQuestions();
                ResetGUI();
                MessageBox.Show("UPDATE QUESTION SUCCESSFULLY", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

            }
            else
                MessageBox.Show("UPDATE FAIL");

        }
    }
}
