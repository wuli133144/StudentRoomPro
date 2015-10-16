using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using StudentRoom.MODEL;
using StudentRoom.BLL;


namespace StudentRoom.UI.form
{
    public partial class Loginform : Form
    {
        public Loginform()
        {
            InitializeComponent();
            this.label1.Text = createNum(4);
            this.txtName.Focus();
         }
        vissiterManager Vim = new vissiterManager();
        vissiter viser = new vissiter();
        Money mon = new Money();
        moneyManager monM = new moneyManager();
        parent par = new parent();
        parentManager parm = new parentManager();



        private string createNum(int count)
        {
            string allchar = "0,1,2,3,4,5,6,7,8,9,a,b,c,d,e,f,g,h,i,j,k,l,m,n,o,p,q,r,s,t,u,v,w,x,y,z";
            string[] allchararr = allchar.Split(',');
            string randomstr = string.Empty;
            int tem = -1;
            Random ran = new Random();
            for (int i = 0; i<count;i++ )
            {
                  if (tem!=-1)
                  {
                      ran = new Random(i*tem*((int)DateTime.Now.Ticks));
                  }
                  int t = ran.Next(35);
                 if (tem==t)
                 {
                     return createNum(count);
                 }
                 tem = t;
                 randomstr += allchararr[t];
            }
            return randomstr;

        }
        
        private void btnlogin_Click(object sender, EventArgs e)
        {
          
           if (this.txtName.Text.Trim()==string.Empty||this.txtPwd.Text.Trim()==string.Empty)
           {
               MessageBox.Show("用户名或密码不能为空！");
               return;
           }
            if (this.radioButton1.Checked)
            {
                //校长助理登陆
                viser.AdminName = this.txtName.Text.Trim();
                viser.AdminPwd = this.txtPwd.Text.Trim();
              bool ret= Vim.login_admin(viser);//调用数据库
                
              if (ret)
              {
                  MessageBox.Show("登陆成功！");
                  this.Dispose();
                  return;
              }
              else
              {
                  MessageBox.Show("登陆失败！");
                  return;
              }
             }    
            //财务人员登陆
            if (this.radioButton2.Checked)
            {
                mon.Moneyname= this.txtName.Text.Trim();
                mon.MoneyPwd = this.txtPwd.Text.Trim();
                bool ret = monM.login_money(mon);
                if (ret)
                {
                    MessageBox.Show("登陆成功！");
                    moneyForm monf = new moneyForm();
                    monf.ShowDialog();
                  
                    monf.Dispose();
                    return;
                }
                else
                {
                    MessageBox.Show("登陆失败！");
                    return;
                }

            }
            //家长
            if (this.radioButton3.Checked)
            {
                par.Name = this.txtName.Text.Trim();
                par.Pwd = this.txtPwd.Text.Trim();
                bool ret = parm.loinpar(par);
                if (ret)
                {
                    MessageBox.Show("登陆成功！");
                    studentcheck monf = new studentcheck();
                    monf.ShowDialog();

                    monf.Dispose();
                    return;
                }
                else
                {
                    MessageBox.Show("登陆失败！");
                    return;
                }

            }

           
            
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
　　　 　 }

        private void Loginform_ForeColorChanged(object sender, EventArgs e)
        {
            
        }

        private void Loginform_FormClosed(object sender, FormClosedEventArgs e)
        {
           // Application.Exit();
        }
    }
}
