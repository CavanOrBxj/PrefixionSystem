using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using CCWin;
using System.Net.Sockets;

namespace PrefixionSystem.FrmPart
{
    public partial class AdapterSetForm : CCSkinMain
    {
        private IniFiles ini;
        public AdapterSetForm()
        {
            InitializeComponent();
            ini = new IniFiles(@Application.StartupPath + "\\Config.ini");
        }

        private void AdapterSetForm_Load(object sender, EventArgs e)
        {
            txtAdapterIP.Text = ini.ReadValue("AdapterSET", "AdapterIP");
            txtAdapterPort.Text = ini.ReadValue("AdapterSET", "AdapterPort");
           
        }

        private void btnSet_Click(object sender, EventArgs e)
        {
            ini.WriteValue("AdapterSET", "AdapterIP", txtAdapterIP.Text);
            ini.WriteValue("AdapterSET", "AdapterPort", txtAdapterPort.Text);

        }

        private void btnCloseWarning_Click(object sender, EventArgs e)
        {
            try
            {
                UdpClient udpcSend;
                string ip = txtAdapterIP.Text;
                int portdata = Convert.ToInt32(txtAdapterPort.Text);
                udpcSend = new UdpClient(0);//匿名发送
                string message = "/>|20|PWROUT|CLOSE|#";//关闭声光报警指令
                byte[] sendbytes = Encoding.UTF8.GetBytes(message);
                IPEndPoint remoteIpep = new IPEndPoint(IPAddress.Parse(ip), portdata); // 发送到的IP地址和端口号
                udpcSend.Send(sendbytes, sendbytes.Length, remoteIpep);
                udpcSend.Close();
                GC.Collect();
            }
            catch (Exception ex)
            {

            }
        }
    }
}
