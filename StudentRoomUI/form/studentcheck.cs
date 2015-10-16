using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using StudentRoom.BLL;
using StudentRoom.MODEL;


namespace StudentRoom.UI.form
{
    public partial class studentcheck : Form
    {
        public studentcheck()
        {
            InitializeComponent();
        }
        //feeManager feeM = new feeManager();
        student stu = new student();
       // fee1 fee = new fee1();
        studentManager stuM = new studentManager();

        private void studentcheck_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
         
        /// <summary>
        /// 获取获取全部学生的信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            stu.StudentId = Convert.ToInt32(this.toolStripTextBox1.Text);
            DataSet dt = stuM.getallinfo(stu);//数据集
            this.dataGridView1.DataSource = dt.Tables["infostudent"];//
        }

        private void studentcheck_Load(object sender, EventArgs e)

        {

        }
    }
}
