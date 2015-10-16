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
    public partial class moneyForm : Form
    {
        public moneyForm()
        {
            InitializeComponent();
          
        }
        feeManager feeM = new feeManager();
        student stu = new student();
        fee1 fee = new fee1();
        studentManager stuM = new studentManager();

        private void moneyForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void moneyForm_Load(object sender, EventArgs e)
        {
            this.txttime.Text = DateTime.Now.ToString();
            this.comboBox1.SelectedIndex = 0;
            this.txtcon.Text = "20元";
            this.txtwarm.Text = "20元";
            this.txtfood.Text = "880元";//4个月计算
            this.txtnum.Focus();
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void 说明ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("G:\\Wnddemo\\c#_console\\三层架构\\StudentRoomPro\\StudentRoomUI\\doc\\read1.txt");

        }

        private void 收费ToolStripMenuItem_Click(object sender, EventArgs e)
        {   
            //非空判断
            if (this.txtnum.Text.Trim()==string.Empty)
            {
                MessageBox.Show("学生学号不能为空！");
                return;
            }
            fee.Studentid = Convert.ToInt32(this.txtnum.Text.Trim());
            stu.StudentId= fee.Studentid;
            fee.Feebook=Convert.ToInt32(this.txtBook.Text.Trim());
           
            fee.Feefood=880;
            fee.Feewarm=20;
            fee.Feeconditioner=20;
            //判断学生是否存在
           int retva=stuM.GetStudent(stu);
            if (retva>0)
            {

                bool ret = feeM.innsertFeeStudent(fee);
                if (ret)
                {
                    MessageBox.Show("收费成功！");
                    this.txtnum.Text = string.Empty;
                    this.txtBook.Text = string.Empty;
                    this.txtnum.Focus();
                    return;
                }
                else
                {
                    MessageBox.Show("收费失败 !该学生已经交过费用！");
                    this.txtnum.Text = string.Empty;
                    this.txtBook.Text = string.Empty;
                    this.txtnum.Focus();
                    return;
                }
            }
            else
            {
                MessageBox.Show("不存在该学生的信息！");
                return;
            }
    }

     

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
           int stupar = this.comboBox1.SelectedIndex;

            switch (stupar)
            {
                case 0 :
                    {
                        fee.Feeroom = 80;
                        break;
                    }
                case 1:
                    {
                        fee.Feeroom = 60;
                        break;
                    }
                case 2:
                    {
                        fee.Feeroom = 100;
                         break;
                    }

            }
            this.txtroom.Text = Convert.ToString(fee.Feeroom) + "元";
   }

        private void txttime_TextChanged(object sender, EventArgs e)
        {
        
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
        
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
           
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            fee.Studentid = Convert.ToInt32(this.toolStripTextBox1.Text.Trim());
            DataSet dt=feeM.selectfeestudent(fee);
            this.dataGridView1.DataSource = dt.Tables["feestudent"];
        }

        private void 退费ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //退费
            stu.StudentId = Convert.ToInt32(this.txtnum.Text);
            bool bret=stuM.cheackfee(stu);
            if (bret)
            {
                this.txtcheck.Text = "全勤";
                this.txtbackfee.Text = "10元";
            }
            else
            {
                this.txtcheck.Text = "缺勤";
                this.txtbackfee.Text="0元";
            }
           
        }

      }
}
