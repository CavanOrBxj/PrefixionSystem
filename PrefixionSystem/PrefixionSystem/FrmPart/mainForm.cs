using CCWin;
using PrefixionSystem.DataModule;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrefixionSystem.FrmPart
{
    public partial class mainForm : CCSkinMain
    {
        private ServerIPSetForm setipFrm;
        private TmpFolderSetForm tmpforldFrm;
        private AdapterSetForm adapterFrm;

        Thread httpthread = null;//HTTP服务
       // Thread thTar = null;//解压回复线程
        private HttpServer httpServer = null;//HttpServer端//


        private List<string> xmlfilename = new List<string>();//获取Tar包里面的XML文件名列表（一个签名包，一个请求包）
        public static List<string> lRevFiles;
        private string sUrlAddress = string.Empty;//回复地址
        private bool bDeal = true;//线程处理是否停止处理
        private IniFiles serverini;

        public string sSendTarName = "";//发送Tar包名字
        public static string sRevTarPath = "";//接收Tar包存放路径
        public static string sSendTarPath = "";//发送Tar包存放路径
        public static string sSourcePath = "";//需压缩文件路径
        public static string sUnTarPath = "";//Tar包解压缩路径
        public static string sAudioFilesFolder = "";//音频文件存放位置


        public static string strBeUnTarFolder = "";//预处理解压缩
        public static string strBeSendFileMakeFolder = "";//生成XML文件路径
        //心跳包变量
        public static string sHeartSourceFilePath = string.Empty;

        //SRV状态包变量
        public static string SRVSSourceFilePath = string.Empty;
        //SRV信息包变量
        public static string SRVISourceFilePath = string.Empty;

        //平台状态包变量
        public static string TerraceSSourceFilePath = string.Empty;
        //平台信息包变量
        public static string TerradcISourceFilePath = string.Empty;
        //定时心跳
        public static string TimesHeartSourceFilePath = string.Empty;

        public static string sEBMStateResponsePath = string.Empty;

        public static TarHelper tar = null;


        public static string strSourceAreaCode = "";
        public static string strSourceType = "";
        public static string strSourceName = "";
        public static string strSourceID = "";
        public static string strHBRONO = "";  //ini文件中配置的实体编号，与通用反馈中的SRC/EBEID对应，即本平台的ID

        public static string strHBAREACODE = "";  //2016-04-03 电科院区域码对应


        private IPAddress iServerIP;
        private int iServerPort = 0;

        public string sServerIP = "";
        public string sServerPort = "";

        private readonly string ClassName;

        MessageShowForm MessageShowDlg;
        EBMDetailShowForm EBMDetailShowDlg;
        TaskbarNotifier taskbarNotifier3;


        public mainForm()
        {
            InitializeComponent();
            ClassName = GetType().Name;
            Load += MainForm_Load;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            InitData();

            HttpProcessor.MyEvent += new HttpProcessor.MyDelegate(ShowData);

            GetSQLData();
            InitCombox();

            InitTaskbarNotifier();


        }

        private void InitTaskbarNotifier()
        {
            taskbarNotifier3 = new TaskbarNotifier();
            taskbarNotifier3.CloseClickable = true;
            taskbarNotifier3.TitleClickable = false;
            taskbarNotifier3.ContentClickable = true;
            taskbarNotifier3.EnableSelectionRectangle = true;
            taskbarNotifier3.KeepVisibleOnMousOver = true;
            taskbarNotifier3.ReShowOnMouseOver = true;

            taskbarNotifier3.SetBackgroundBitmap(Resource1.skin3, Color.FromArgb(255, 0, 255));
            taskbarNotifier3.SetCloseBitmap(Resource1.close3, Color.FromArgb(255, 0, 255), new Point(262, 2));
            taskbarNotifier3.TitleRectangle = new Rectangle(90, 30, 176, 20);
            taskbarNotifier3.ContentRectangle = new Rectangle(68, 75, 197, 30);
            taskbarNotifier3.MediumTypeRectangle = new Rectangle(68, 105, 197, 30);
            taskbarNotifier3.UnhandledMsgRectangle = new Rectangle(68, 135, 197, 30);
            taskbarNotifier3.ContentClick += new TaskbarNotifier.MyEvent(ContentClick);
        }
        


        void ContentClick(RecordDetail ea)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                WindowState = FormWindowState.Normal;
                //激活窗体并给予它焦点
                this.Activate();
                //任务栏区显示图标
                this.ShowInTaskbar = true;

                skinDataGridView_Record.Rows.Clear();
                panel1.Visible = false;
                skinDataGridView_Main.Visible = true;
            }


            foreach (DataGridViewRow item in skinDataGridView_Main.Rows)
            {
                RecordDetail pp = (RecordDetail)item.Tag;
                if (pp.RecordId== ea.RecordId)
                {
                    //  item.Selected = true;

                    item. DefaultCellStyle.BackColor = Color.Green;
                }
            }
        }

        private void InitCombox()
        {
            ComboBoxHelper.InitSearchType(cmb_SearchType);
            ComboBoxHelper.InitMediumType(cmb_MediumType);
            ComboBoxHelper.InitSeverityType(cmb_Severity);
            ComboBoxHelper.InitMessageStatusType(cmb_MessageStatus);

        }

        private void GetSQLData()
        {
            DataTable dt = new DataTable();

            string sql = "select * from recordlist";
            SingletonInfo.GetInstance().DataBase.FromSql(sql, out dt);
            if (dt.Rows.Count>0)
            {
                foreach (DataRow item in dt.Rows)
                {
                    RecordDetail pp = new RecordDetail();
                    pp.AreaCode = item["AreaCode"].ToString();
                    pp.DealFlag = Convert.ToInt32(item["DealFlag"].ToString());
                    pp.EventType= item["EventType"].ToString();
                    pp.MediumType= item["MediumType"].ToString();
                    pp.MsgEndTime = item["MsgEndTime"].ToString();
                    pp.MsgStartTime = item["MsgStartTime"].ToString();
                    pp.RecordId = item["RecordId"].ToString();
                    pp.SavePath= item["SavePath"].ToString();
                    pp.Severity= item["Severity"].ToString();
                    pp.SourceTar= item["SourceTar"].ToString();
                    pp.SourceTarPath= item["SourceTarPath"].ToString();
                    pp.TextContent = item["TextContent"].ToString();
                    pp.MsgTitle= item["MsgTitle"].ToString();
                    pp.SenderCode= item["SenderCode"].ToString();
                    pp.SenderName= item["SenderName"].ToString();
                    pp.SendTime= item["SendTime"].ToString();

                    SetDataGridviewControlPropertyValue(this.skinDataGridView_Main, pp);
                    SingletonInfo.GetInstance().RecordDetailList.Add(pp);

                }
            }
        }

        private void ShowData(object obj)
        {
            RecordDetail dd = (RecordDetail)obj;
            SetDataGridviewControlPropertyValue(this.skinDataGridView_Main,dd);

            int UnhandledMsgCount = 0;

            UnhandledMsgCount=SingletonInfo.GetInstance().RecordDetailList.FindAll(s => s.DealFlag==0).Count;


            this.Invoke(new Action(() =>
            {
                taskbarNotifier3.Show(dd, UnhandledMsgCount);
            }));
        }

        private void InitData()
        {
            tar = new TarHelper();
            serverini = new IniFiles(@Application.StartupPath + "\\Config.ini");
            strSourceAreaCode = serverini.ReadValue("INFOSET", "SourceAreaCode");
            strSourceID = serverini.ReadValue("INFOSET", "SourceID");
            strSourceName = serverini.ReadValue("INFOSET", "SourceName");
            strSourceType = serverini.ReadValue("INFOSET", "SourceType");

            strHBRONO = serverini.ReadValue("INFOSET", "HBRONO");  //实体编号///////////////////////////////
            strHBAREACODE = serverini.ReadValue("INFOSET", "HBAREACODE");//////////////////////////////////



            sServerIP = serverini.ReadValue("INFOSET", "ServerIP");
            sServerPort = serverini.ReadValue("INFOSET", "ServerPort");

            if (sServerIP != "")
            {
                if (!IPAddress.TryParse(sServerIP, out iServerIP))
                {
                    MessageBox.Show("非有效的IP地址，关闭服务重新配置IP后启动！");
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("服务IP不能为空，关闭服务重新配置IP后启动！");
                this.Close();
            }


            if (sServerPort != "")
            {
                if (int.TryParse(sServerPort, out iServerPort))
                {
                    if (iServerPort < 1 || iServerPort > 65535)
                    {
                        MessageBox.Show("无效的端口号，请重新输入！");
                       // txtServerPort.Focus();
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("非端口号，请重新输入！");
                   // txtServerPort.Focus();
                    return;
                }
            }
            else
            {
                MessageBox.Show("服务端口号不能为空！");
              //  txtServerPort.Focus();
                return;
            }
        }

        private void ServerIPSet_Click(object sender, EventArgs e)
        {
            try
            {
                if (setipFrm == null || setipFrm.IsDisposed)
                {
                    setipFrm = new ServerIPSetForm();
                    setipFrm.MdiParent = this;
                    setipFrm.Show();
                }
                else
                {
                    if (setipFrm.WindowState == FormWindowState.Minimized)
                    {
                        setipFrm.WindowState = FormWindowState.Normal;
                    }
                    else
                        setipFrm.Activate();
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(typeof(mainForm),ex.Message);
            }
        }

        private void mnuFolderSet_Click(object sender, EventArgs e)
        {
            if (tmpforldFrm == null || tmpforldFrm.IsDisposed)
            {
                tmpforldFrm = new TmpFolderSetForm();
                tmpforldFrm.MdiParent = this;
                tmpforldFrm.Show();
            }
            else
            {
                if (tmpforldFrm.WindowState == FormWindowState.Minimized)
                {
                    tmpforldFrm.WindowState = FormWindowState.Normal;
                }
                else
                    tmpforldFrm.Activate();
            }
        }

        private void mnuExit_Click(object sender, EventArgs e)
        {
            this.Dispose(true);//释放资源
            Application.Exit();
            Application.ExitThread();
            System.Environment.Exit(0);
        }

        private void mnuStartServer_Click(object sender, EventArgs e)
        {
            #region 设置处理文件夹路径Tar包存放文件夹路径
            try
            {
                //接收TAR包存放路径
                sRevTarPath = serverini.ReadValue("FolderSet", "RevTarFolder");
                if (!Directory.Exists(sRevTarPath))
                {
                    Directory.CreateDirectory(sRevTarPath);//不存在该路径就创建
                }
                //接收到的Tar包解压存放路径
                sUnTarPath = serverini.ReadValue("FolderSet", "UnTarFolder");
                if (!Directory.Exists(sUnTarPath))
                {
                    Directory.CreateDirectory(sUnTarPath);//不存在该路径就创建
                }
                //生成的需发送的XML文件路径
                sSourcePath = serverini.ReadValue("FolderSet", "XmlBuildFolder");
                if (!Directory.Exists(sSourcePath))
                {
                    Directory.CreateDirectory(sSourcePath);//
                }
                //生成的TAR包，将要被发送的位置
                sSendTarPath = serverini.ReadValue("FolderSet", "SndTarFolder");
                if (!Directory.Exists(sSendTarPath))
                {
                    Directory.CreateDirectory(sSendTarPath);
                }
                sAudioFilesFolder = serverini.ReadValue("FolderSet", "AudioFileFolder");
                if (!Directory.Exists(sAudioFilesFolder))
                {
                    Directory.CreateDirectory(sAudioFilesFolder);
                }
                //预处理文件夹
                strBeUnTarFolder = serverini.ReadValue("FolderSet", "BeUnTarFolder");
                if (!Directory.Exists(strBeUnTarFolder))
                {
                    Directory.CreateDirectory(strBeUnTarFolder);
                }
                strBeSendFileMakeFolder = serverini.ReadValue("FolderSet", "BeXmlFileMakeFolder");
                if (!Directory.Exists(strBeSendFileMakeFolder))
                {
                    Directory.CreateDirectory(strBeSendFileMakeFolder);
                }
                //预处理文件夹
                if (strBeUnTarFolder == "" || strBeSendFileMakeFolder == "")
                {
                    MessageBox.Show("预处理文件夹路径不能为空，请设置好路径！");
                    this.Close();
                }

                if (sRevTarPath == "" || sSendTarPath == "" || sSourcePath == "" || sUnTarPath == "")
                {
                    MessageBox.Show("文件夹路径不能为空，请设置好路径！");
                    this.Close();
                }
            }
            catch (Exception em)
            {
                MessageBox.Show("文件夹设置错误，请重新：" + em.Message);
                this.Close();
            }
            #endregion 文件夹路径设置END

            bDeal = true;//解析开关
            try
            {
                IPAddress[] ipArr;
                ipArr = Dns.GetHostAddresses(Dns.GetHostName());
                if (!ipArr.Contains(iServerIP))
                {
                    MessageBox.Show("IP设置错误，请重新设置后运行服务！");
                    return;
                }
                httpServer = new HttpServer(iServerIP, iServerPort);
            }
            catch (Exception es)
            {
                MessageBox.Show("可能端口已经使用中，请重新分配端口：" + es.Message);
                return;
            }


            if (mnuStartServer.Text == "启动伺服")
            {
                //启动服务
                MessageShowDlg = new MessageShowForm { label1 = { Text = @"启动服务？" } };
                MessageShowDlg.ShowDialog();
                if (MessageShowDlg.IsSure)
                {
                    mnuStartServer.Text = "停止伺服";
                    httpthread = new Thread(new ThreadStart(httpServer.listen));
                    httpthread.IsBackground = true;
                    httpthread.Name = "HttpServer服务";
                    httpthread.Start();
                    skinDataGridView_Main.Visible = true;
                   // skinDataGridView_Main.Dock=Dock.f
                }

            }
            else
            {
                //停止服务
                MessageShowDlg = new MessageShowForm { label1 = { Text = @"停止服务？" } };
                MessageShowDlg.ShowDialog();
                if (MessageShowDlg.IsSure)
                {
                    mnuStartServer.Text = "启动伺服";
                    if (httpthread != null)
                    {
                        httpthread.Abort();
                        httpthread = null;
                    }
                    httpServer.StopListen();
                    skinDataGridView_Main.Visible = false;
                }
            }
        }


        public static void DeleteFolder(string folderpath)
        {
            try
            {
                foreach (string delFile in Directory.GetFileSystemEntries(folderpath))
                {
                    if (File.Exists(delFile))
                    {
                        FileInfo fi = new FileInfo(delFile);
                        if (fi.Attributes.ToString().IndexOf("ReadOnly") != -1)
                            fi.Attributes = FileAttributes.Normal;
                        File.Delete(delFile);//直接删除其中的文件
                        // SetText("删除文件：" + delFile);
                    }
                    else
                    {
                        DirectoryInfo dInfo = new DirectoryInfo(delFile);
                        if (dInfo.GetFiles().Length != 0)
                        {
                            DeleteFolder(dInfo.FullName);//递归删除子文件夹
                        }
                        Directory.Delete(delFile);
                    }
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(typeof(mainForm), ex.Message);
            }
        }

        #region 多线程更新Listview
        delegate void SetDataGridviewControlValueCallback(DataGridView oControl, RecordDetail task);
        private void SetDataGridviewControlPropertyValue(DataGridView oControl, RecordDetail task)
        {

            if (oControl.InvokeRequired)  // InvokeRequired 当前线程不是创建控件的线程时为true
            {
                //任务的增删改
                SetDataGridviewControlValueCallback d = new SetDataGridviewControlValueCallback(SetDataGridviewControlPropertyValue);
                oControl.Invoke(d, new object[] { oControl, task });
            }
            else
            {
                //原先没有，表示该任务为新加的
                DataGridViewRow dgvR = new DataGridViewRow();
                dgvR.CreateCells(skinDataGridView_Main);
                if (task.DealFlag == 1)
                {
                    dgvR.Cells[0].Value = "已处理";
                    dgvR.Cells[0].ReadOnly = true;
                   // dgvR.Cells[0].Style.ForeColor = Color.Green;
                }
                else
                {
                    dgvR.Cells[0].Value = "未处理";
                  //  dgvR.Cells[0].Style.ForeColor = Color.Red;
                }


                dgvR.Cells[1].Value = task.RecordId;
                dgvR.Cells[2].Value = "详情";
                dgvR.Cells[3].Value = task.MediumType;
                dgvR.Cells[4].Value = task.EventType;

                switch (task.Severity)
                {
                    case "0":
                        dgvR.Cells[5].Value = "未知级别";
                        break;
                    case "1":
                        dgvR.Cells[5].Value = "1级";
                        dgvR.Cells[5].Style.ForeColor = Color.Red;
                        break;
                    case "2":
                        dgvR.Cells[5].Value = "2级";
                        dgvR.Cells[5].Style.ForeColor = Color.Orange;
                        break;
                    case "3":
                        dgvR.Cells[5].Value = "3级";
                        dgvR.Cells[5].Style.ForeColor = Color.Yellow;
                        break;
                    case "4":
                        dgvR.Cells[5].Value = "4级";
                        dgvR.Cells[5].Style.ForeColor = Color.Blue;
                        break;
                }
                dgvR.Cells[6].Value = task.MsgStartTime;
                dgvR.Cells[7].Value = task.MsgEndTime;
                dgvR.Cells[8].Value = task.AreaCode;
                dgvR.Cells[9].Value = task.SavePath;
                dgvR.Height =30;
                dgvR.Tag = task;
                skinDataGridView_Main.Rows.Add(dgvR);
            }
        }
        private void SetDataGridviewControlPropertyValueNew(DataGridView oControl, RecordDetail task)
        {

            if (oControl.InvokeRequired)  // InvokeRequired 当前线程不是创建控件的线程时为true
            {
                //任务的增删改
                SetDataGridviewControlValueCallback d = new SetDataGridviewControlValueCallback(SetDataGridviewControlPropertyValueNew);
                oControl.Invoke(d, new object[] { oControl, task });
            }
            else
            {
                //原先没有，表示该任务为新加的
                DataGridViewRow dgvR = new DataGridViewRow();
                dgvR.CreateCells(skinDataGridView_Record);
                if (task.DealFlag == 1)
                {
                    dgvR.Cells[0].Value = "已处理";
                    dgvR.Cells[0].ReadOnly = true;
                    // dgvR.Cells[0].Style.ForeColor = Color.Green;
                }
                else
                {
                    dgvR.Cells[0].Value = "未处理";
                    //  dgvR.Cells[0].Style.ForeColor = Color.Red;
                }


                dgvR.Cells[1].Value = task.RecordId;
                dgvR.Cells[2].Value = "详情";
                dgvR.Cells[3].Value = task.MediumType;
                dgvR.Cells[4].Value = task.EventType;

                switch (task.Severity)
                {
                    case "0":
                        dgvR.Cells[5].Value = "未知级别";
                        break;
                    case "1":
                        dgvR.Cells[5].Value = "1级";
                        dgvR.Cells[5].Style.ForeColor = Color.Red;
                        break;
                    case "2":
                        dgvR.Cells[5].Value = "2级";
                        dgvR.Cells[5].Style.ForeColor = Color.Orange;
                        break;
                    case "3":
                        dgvR.Cells[5].Value = "3级";
                        dgvR.Cells[5].Style.ForeColor = Color.Yellow;
                        break;
                    case "4":
                        dgvR.Cells[5].Value = "4级";
                        dgvR.Cells[5].Style.ForeColor = Color.Blue;
                        break;
                }
                dgvR.Cells[6].Value = task.MsgStartTime;
                dgvR.Cells[7].Value = task.MsgEndTime;
                dgvR.Cells[8].Value = task.AreaCode;
                dgvR.Cells[9].Value = task.SavePath;
                dgvR.Height = 30;
                dgvR.Tag = task;
                skinDataGridView_Record.Rows.Add(dgvR);
            }
        }
        #endregion

        private void skinDataGridView_Main_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                switch (e.ColumnIndex)
                {

                    case 0:
                        MessageShowDlg = new MessageShowForm { label1 = { Text = @"确认处理？" } };
                        MessageShowDlg.ShowDialog();
                        if (MessageShowDlg.IsSure)
                        {
                            DataGridViewRow dgvR = skinDataGridView_Main.Rows[e.RowIndex];
                            dgvR.DefaultCellStyle.BackColor = Color.FromArgb(40,36,36);
                            RecordDetail selectone = (RecordDetail)dgvR.Tag;
                            selectone.DealFlag = 1;
                            //更新数据库
                            SingletonInfo.GetInstance().DataBase.UpdateRecorde(selectone);
                            dgvR.Cells[0].Value = "已处理";
                            dgvR.Cells[0].ReadOnly = true;
                        }

                            break;
                    case 2:
                        DataGridViewRow dgvRS = skinDataGridView_Main.Rows[e.RowIndex];
                        RecordDetail selected = (RecordDetail)dgvRS.Tag;

                        EBMDetailShowDlg = new EBMDetailShowForm(selected);
                        EBMDetailShowDlg.ShowDialog();
                        break;
                    case 9:
                        MessageShowDlg = new MessageShowForm { label1 = { Text = @"打开链接？" } };
                        MessageShowDlg.ShowDialog();
                        if (MessageShowDlg.IsSure)
                        {
                            DataGridViewRow dgvR = skinDataGridView_Main.Rows[e.RowIndex];
                            RecordDetail selectone = (RecordDetail)dgvR.Tag;
                            string path = Path.GetDirectoryName(selectone.SavePath);
                            System.Diagnostics.Process.Start(path);
                        }
                        break;
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void mnuAdapterSet_Click(object sender, EventArgs e)
        {
            if (adapterFrm == null || adapterFrm.IsDisposed)
            {
                adapterFrm = new AdapterSetForm();
                adapterFrm.TopMost = true;
               // adapterFrm.MdiParent = this;
                adapterFrm.Show();
            }
            else
            {
                if (adapterFrm.WindowState == FormWindowState.Minimized)
                {
                    adapterFrm.WindowState = FormWindowState.Normal;
                }
                else
                    adapterFrm.Activate();
            }
        }

        private void mnuRecordSearch_Click(object sender, EventArgs e)
        {
            try
            {
                panel1.Visible = true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void cmb_SearchType_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmb_SearchType.SelectedIndex)
            {
                case 0:
                    panel_MessageType.Visible = true;
                    panel_SearchTime.Visible = false;
                    panel_EventType.Visible = false;
                    panel_Severity.Visible = false;
                    panel_AreaCode.Visible = false;
                    panel_TextContent.Visible = false;
                    panel_MessageStatus.Visible = false;
                    break;
                case 1:
                    panel_MessageType.Visible = false;
                    panel_SearchTime.Visible = true;
                    panel_EventType.Visible = false;
                    panel_Severity.Visible = false;
                    panel_AreaCode.Visible = false;
                    panel_TextContent.Visible = false;
                    panel_MessageStatus.Visible = false;
                    break;
                case 2:
                    panel_MessageType.Visible = false;
                    panel_SearchTime.Visible = false;
                    panel_EventType.Visible = true;
                    panel_Severity.Visible = false;
                    panel_AreaCode.Visible = false;
                    panel_TextContent.Visible = false;
                    panel_MessageStatus.Visible = false;
                    break;
                case 3:
                    panel_MessageType.Visible = false;
                    panel_SearchTime.Visible = false;
                    panel_EventType.Visible = false;
                    panel_Severity.Visible = true;
                    panel_AreaCode.Visible = false;
                    panel_TextContent.Visible = false;
                    panel_MessageStatus.Visible = false;
                    break;
                case 4:
                    panel_MessageType.Visible = false;
                    panel_SearchTime.Visible = false;
                    panel_EventType.Visible = false;
                    panel_Severity.Visible = false;
                    panel_AreaCode.Visible = true;
                    panel_TextContent.Visible = false;
                    panel_MessageStatus.Visible = false;
                    break;
                case 5:
                    panel_MessageType.Visible = false;
                    panel_SearchTime.Visible = false;
                    panel_EventType.Visible = false;
                    panel_Severity.Visible = false;
                    panel_AreaCode.Visible = false;
                    panel_TextContent.Visible = true;
                    panel_MessageStatus.Visible = false;
                    break;
                case 6:
                    panel_MessageType.Visible = false;
                    panel_SearchTime.Visible = false;
                    panel_EventType.Visible = false;
                    panel_Severity.Visible = false;
                    panel_AreaCode.Visible = false;
                    panel_TextContent.Visible = false;
                    panel_MessageStatus.Visible = true;
                    break;
                
            }
        }

        private void btn_Search_Click(object sender, EventArgs e)
        {
            try
            {
                List<RecordDetail> FindedList = new List<RecordDetail>();
                switch (cmb_SearchType.SelectedIndex)
                {
                    case 0://消息媒体

                        int MediumType = Convert.ToInt32(cmb_MediumType.SelectedValue);
                        switch (MediumType)
                        {
                            case 1:
                                //mp3
                                FindedList=SingletonInfo.GetInstance().RecordDetailList.Where(x => x.MediumType == "mp3").ToList();
                                break;
                            case 2:
                                //文本
                                FindedList = SingletonInfo.GetInstance().RecordDetailList.Where(x => x.MediumType == "文本").ToList();
                                break;
                        }
                        break;
                    case 1://开始时间
                        foreach (RecordDetail item in SingletonInfo.GetInstance().RecordDetailList)
                        {
                            DateTime starttime = Convert.ToDateTime(item.MsgStartTime);
                            if (DateTime.Compare(starttime, dateTimePicker1.Value)>0 && DateTime.Compare(starttime, dateTimePicker2.Value) <0)
                            {
                                FindedList.Add(item);
                            }
                        }
                        break;
                    case 2://事件类型码
                        FindedList = SingletonInfo.GetInstance().RecordDetailList.Where(x => x.EventType == txt_EventType.Text.Trim()).ToList();
                        break;
                    case 3://事件级别
                        int Severity = Convert.ToInt32(cmb_Severity.SelectedValue);
                        switch (Severity)
                        {
                            case 0:
                                FindedList = SingletonInfo.GetInstance().RecordDetailList.Where(x => x.Severity == "0").ToList();
                                break;
                            case 1:
                                FindedList = SingletonInfo.GetInstance().RecordDetailList.Where(x => x.Severity == "1").ToList();
                                break;
                            case 2:
                                FindedList = SingletonInfo.GetInstance().RecordDetailList.Where(x => x.Severity == "2").ToList();
                                break;
                            case 3:
                                FindedList = SingletonInfo.GetInstance().RecordDetailList.Where(x => x.Severity == "3").ToList();
                                break;
                            case 4:
                                FindedList = SingletonInfo.GetInstance().RecordDetailList.Where(x => x.Severity == "4").ToList();
                                break;
                        }
                        break;
                    case 4://区域码

                        FindedList = SingletonInfo.GetInstance().RecordDetailList.Where(x => x.AreaCode == txt_AreaCode.Text.Trim()).ToList();
                        break;
                    case 5://文本关键字

                        foreach (RecordDetail item in SingletonInfo.GetInstance().RecordDetailList)
                        {
                            if (!string.IsNullOrEmpty(item.TextContent))
                            {
                                if (item.TextContent.Contains(txt_TextContent.Text.Trim()))
                                {
                                    FindedList.Add(item);
                                }
                            }
                        }
                        break;
                    case 6:
                        // 消息处理未处理
                        int MessageStatus = Convert.ToInt32(cmb_MessageStatus.SelectedValue);
                        switch (MessageStatus)
                        {
                            case 1://已处理
                                FindedList = SingletonInfo.GetInstance().RecordDetailList.Where(x => x.DealFlag == 1).ToList();
                                break;
                            case 2://未处理
                                FindedList = SingletonInfo.GetInstance().RecordDetailList.Where(x => x.DealFlag == 0).ToList();
                                break;
                        }
                        break;
                }

                ShowSelectRecord(FindedList);
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void ShowSelectRecord(List<RecordDetail> DataList)
        {
            skinDataGridView_Record.Rows.Clear();
            foreach (RecordDetail item in DataList)
            {
                SetDataGridviewControlPropertyValueNew(skinDataGridView_Record, item);
            }

        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            skinDataGridView_Record.Rows.Clear();
            panel1.Visible = false;
            skinDataGridView_Main.Visible = true;

        }

        private void skinDataGridView_Record_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                switch (e.ColumnIndex)
                {

                    case 0:
                        MessageShowDlg = new MessageShowForm { label1 = { Text = @"确认处理？" } };
                        MessageShowDlg.ShowDialog();
                        if (MessageShowDlg.IsSure)
                        {
                            DataGridViewRow dgvR = skinDataGridView_Record.Rows[e.RowIndex];
                            RecordDetail selectone = (RecordDetail)dgvR.Tag;
                            selectone.DealFlag = 1;
                            //更新数据库
                            SingletonInfo.GetInstance().DataBase.UpdateRecorde(selectone);
                            dgvR.Cells[0].Value = "已处理";
                            dgvR.Cells[0].ReadOnly = true;


                            //通知到主显示表skinDataGridView_Main
                            this.Invoke(new Action(() =>
                            {
                                foreach (DataGridViewRow item in skinDataGridView_Main.Rows)
                                {
                                    if (item.Cells[1].Value.ToString()== selectone.RecordId)
                                    {
                                        item.Tag = selectone;
                                        item.Cells[0].Value = "已处理";
                                    }
                                }
                            }));
                        }

                        break;
                    case 2:
                        DataGridViewRow dgvRS = skinDataGridView_Record.Rows[e.RowIndex];
                        RecordDetail selected = (RecordDetail)dgvRS.Tag;

                        EBMDetailShowDlg = new EBMDetailShowForm(selected);
                        EBMDetailShowDlg.ShowDialog();
                        break;
                    case 9:
                        MessageShowDlg = new MessageShowForm { label1 = { Text = @"打开链接？" } };
                        MessageShowDlg.ShowDialog();
                        if (MessageShowDlg.IsSure)
                        {
                            DataGridViewRow dgvR = skinDataGridView_Record.Rows[e.RowIndex];
                            RecordDetail selectone = (RecordDetail)dgvR.Tag;
                            string path = Path.GetDirectoryName(selectone.SavePath);
                            System.Diagnostics.Process.Start(path);
                        }
                        break;
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

      

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                //还原窗体显示    
                WindowState = FormWindowState.Normal;
                //激活窗体并给予它焦点
                this.Activate();
                //任务栏区显示图标
                this.ShowInTaskbar = true;
                //托盘区图标隐藏
              //  notifyIcon1.Visible = false;
            }
        }

        private void mainForm_SizeChanged(object sender, EventArgs e)
        {
            try
            {
                //判断是否选择的是最小化按钮
                if (WindowState == FormWindowState.Minimized)
                {
                    //隐藏任务栏区图标
                    this.ShowInTaskbar = false;
                    //图标显示在托盘区
                    notifyIcon1.Visible = true;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void mainForm_FormClosing(object sender, FormClosingEventArgs e)
        {

            MessageShowDlg = new MessageShowForm { label1 = { Text = @"是否确认退出程序？" } };
            MessageShowDlg.ShowDialog();
            if (MessageShowDlg.IsSure)
            {
                if (httpthread != null)
                {
                    httpthread.Abort();
                    httpthread = null;
                }
                httpServer.StopListen();

                System.Environment.Exit(0);
            }
            else
            {
                e.Cancel = true;
            } 
        }

        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Show();
            }
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                MessageShowDlg = new MessageShowForm { label1 = { Text = @"是否确认退出程序？" } };
                MessageShowDlg.ShowDialog();
                if (MessageShowDlg.IsSure)
                {
                    if (httpthread != null)
                    {
                        httpthread.Abort();
                        httpthread = null;
                    }
                    httpServer.StopListen();

                    System.Environment.Exit(0);
                }
                else
                {
                    //e.Cancel = true;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
