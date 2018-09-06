using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using PrefixionSystem.FrmPart;
using CCWin;

namespace PrefixionSystem
{
    public partial class frmLogin : CCSkinMain
    {
        private Object oLock = null;
        private int formHeight = 0;

        IniFiles ini = new IniFiles(@Application.StartupPath + "\\Config.ini");
        public frmLogin()
        {
            InitializeComponent();
         
        }
        
    


        private void btnSetting_Click(object sender, EventArgs e)
        {
            this.Height = gbSetting.Visible ? formHeight - gbSetting.Height : formHeight;
            gbSetting.Visible = !gbSetting.Visible;
            btnSetting.Text = btnSetting.Text == ">>" ? "<<" : ">>";
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

            SingletonInfo.GetInstance().DataBase.SetConnectString(txtServer.Text.Trim(), txtDbuser.Text.Trim(), txtDbPass.Text.Trim(), txtDb.Text.Trim());
            if (txtCode.Text.Trim() == "")
            {
                MessageBox.Show("用户编码不能为空，请输入！", "提示");
                txtCode.Focus();
                return;
            };
            if (txtUser.Text.Trim() == "")
            {
                MessageBox.Show("用户名称不能为空，请输入！", "提示");
                txtUser.Focus();
                return;
            };
            if (txtPass.Text.Trim() == "")
            {
                MessageBox.Show("用户密码不能为空，请输入！", "提示");
                txtPass.Focus();
                return;
            };
            try
            {
                if (SingletonInfo.GetInstance().DataBase.OpenTest())
                {
                    if (!SingletonInfo.GetInstance().DataBase.CheckUser(txtUser.Text.Trim(), txtPass.Text.Trim(), txtCode.Text.Trim()))
                    {
                        MessageBox.Show("登录失败，请重新检查用户编码、用户姓名、登录密码！！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtCode.Focus();
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("数据库连接失败，请检查连接设置！", "提示");
                    return;
                }

                mainForm sMain = new mainForm();
                sMain.Show();
                this.Hide();

                SaveConfig();
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message + "\r\n请重新设置数据库连接！", "错误");
                return;
            }
            finally
            {
               
            }
        }
      

        private void txtCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if ((sender as TextBox).Name == "txtPass")
                {
                    btnLogin_Click(null, EventArgs.Empty);
                    return;
                }
                //需设置textBox的TabIndex顺序属性
                this.SelectNextControl(this.ActiveControl, true, true, true, true);  
                
            }    
        }

        private void SaveConfig()
        {
            this.ini.WriteValue("Database", "ServerName", this.txtServer.Text.Trim());
            this.ini.WriteValue("Database", "DataBase", this.txtDb.Text.Trim());
            this.ini.WriteValue("Database", "LogID", this.txtDbuser.Text.Trim());
            this.ini.WriteValue("Database", "LogPass", this.txtDbPass.Text.Trim());

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.ExitThread();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            gbSetting.Visible = false;
            oLock = new Object();
            //读取INI文件
            formHeight = this.Height;
           
            string serverName = ini.ReadValue("Database", "ServerName");
            string database = ini.ReadValue("Database", "DataBase");
            string logID = ini.ReadValue("Database", "LogID");
            string logPass = ini.ReadValue("Database", "LogPass");
          


            txtServer.Text = serverName;
            txtDb.Text = database;
            txtDbuser.Text = logID;
            txtDbPass.Text = logPass;
            this.Height = formHeight - gbSetting.Height;

        }
    }
}
