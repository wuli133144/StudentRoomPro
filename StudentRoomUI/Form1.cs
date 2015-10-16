using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using StudentRoom.UI.form;
using StudentRoom.MODEL;
using StudentRoom.BLL;
using System.Data.SqlClient;

//using System.Data;

namespace StudentRoomUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            Loginform form0 = new Loginform();
            form0.ShowDialog(); 
            form0.Dispose();
       }
         //业务逻辑层的变量
        /// <summary>
        /// 全局变量
        /// </summary>
        studentManager stuM = new studentManager();
        DataSet dt = new DataSet();
        student stu=new student();
       
       private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“studentroomDBDataSet.student”中。您可以根据需要移动或删除它。
          //  this.studentTableAdapter.Fill(this.studentroomDBDataSet.student);
          dt = stuM.GetAllStudent();
          this.dataGridView1.DataSource = dt.Tables["student"];
        }
        /// <summary>
        /// 帮助
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 版本说明ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("G:\\Wnddemo\\c#_console\\三层架构\\StudentRoomPro\\StudentRoomUI\\doc\\read.txt");

        }
        /// <summary>
        /// 帮助
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 使用说明ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("G:\\Wnddemo\\c#_console\\三层架构\\StudentRoomPro\\StudentRoomUI\\doc\\readme.txt");

        }
        /// <summary>
        /// 帮助
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 版权说明ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("G:\\Wnddemo\\c#_console\\三层架构\\StudentRoomPro\\StudentRoomUI\\doc\\rights.txt");

        }
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            SqlDataAdapter adp = stuM.GetsqlAdp();
            SqlCommandBuilder builder = new SqlCommandBuilder(adp);
            adp.Update(dt, "student");
           
        }
        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 更改ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SqlDataAdapter adp = stuM.GetsqlAdp();
            SqlCommandBuilder builder = new SqlCommandBuilder(adp);
            adp.Update(dt, "student");
           
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count==0)//没选中行
            {
                MessageBox.Show("请选中要删除的学生！");
                return;
            }
            stu.StudentId = Convert.ToInt32(this.dataGridView1.SelectedRows[0].Cells[0].Value);
            DialogResult rets=MessageBox.Show("确定删除该学生么？", "确定删除？", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (rets==DialogResult.OK)
                {  
                    bool ret = stuM.DeleteStudent(stu);
                    if (ret)
                    {   
                        dt = stuM.GetAllStudent();
                        this.dataGridView1.DataSource = dt.Tables["student"];
                        MessageBox.Show("删除成功！"); 
                        return;
                    }
                    else
                    {
                        MessageBox.Show("删除失败！");
                        return;
                     }   
            }
     }
        /// <summary>
        /// 添加数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 添加ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SqlDataAdapter adp = stuM.GetsqlAdp();//获取适配器
            SqlCommandBuilder builder = new SqlCommandBuilder(adp);//建造命令
            adp.Update(dt, "student");//更新数据库
           
        }
        /// <summary>
        /// 查询学生的信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
          
            if (this.toolStripTextBox1.Text.Trim()==string.Empty)
            {
                MessageBox.Show("学生的学好不能为空！");
                this.toolStripTextBox1.Focus();
                return;
            }
            //查询代码  
            stu.StudentId= Convert.ToInt32(this.toolStripTextBox1.Text);
            int ret = stuM.GetStudent(stu);
            if (ret>0)
            {
                DataView dv = new DataView();//创建视图
                dv.Table = dt.Tables[0];//添加表
                dv.RowFilter = string.Format("StudentId={0}", stu.StudentId);
                this.dataGridView1.DataSource = dv;//加载数据
            }
            else
            { 
                MessageBox.Show("没有该学生信息！");
                return;
            }


        }
        /// <summary>
        /// 退出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 推出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SqlDataAdapter adp = stuM.GetsqlAdp();
            SqlCommandBuilder builder = new SqlCommandBuilder(adp);
            adp.Update(dt, "student");
            Application.Exit();
           
        }
 }
}
