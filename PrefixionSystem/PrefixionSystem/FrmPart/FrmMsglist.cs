using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;
using LayeredSkin.DirectUI;
using PrefixionSystem.DataModule;

namespace PrefixionSystem.FrmPart
{
    public partial class FrmMsglist : LayeredBaseForm
    {
        #region 变量

        public RecordDetail Webqq = null;
        private Font _font = new Font("微软雅黑", 9.3F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point,
          ((byte)(134)));
        #endregion

        #region 构造函数
        public FrmMsglist(RecordDetail wq)
        {
            InitializeComponent();
            Webqq = wq;
        }
        #endregion

        #region 窗体位置

        //public void SetLoaction(Point _Point)
        //{
        //    this.Location = _Point;
        //}

        //public void timShowShow()
        //{
        //    //try
        //    //{
        //        this.Height = ChatList.Items.Count * 55 + 80;
        //        this.Top = Screen.GetWorkingArea(this).Height - this.Height;
        //        this.Show();
        //        timShow.Enabled = true;
        //    //}
        //    //catch
        //    //{
        //    //}

        //}

        #endregion
        private void timShow_Tick(object sender, EventArgs e)
        {
            //鼠标不在窗体内时
            if (!this.Bounds.Contains(Cursor.Position))
            {
                this.BeginInvoke((MethodInvoker)delegate()
                {
                    this.Hide();
                    timShow.Enabled = false;
                });
            }
            else if (this.Bounds.Contains(Cursor.Position))
            {
                this.Height = ChatList.Items.Count * 55 + 80;
                this.Top = Screen.GetWorkingArea(this).Height - this.Height;
                //this.Show();
            }
        }
        /// <summary>
        /// 窗体加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmLoad(object sender, EventArgs e)
        {
            //timShow.Enabled = true;
            Bitmap topbg = new Bitmap(this.Width, this.Height);
            Graphics g = Graphics.FromImage(topbg);
            //绘制头部背景
            using (Brush LineartBrush = new LinearGradientBrush(
                                       new Rectangle(0, 0, ClientRectangle.Width, 30),
                                       Color.FromArgb(135, Color.White), Color.FromArgb(255, Color.White), 90))
            {
                g.FillRectangle(LineartBrush, new Rectangle(0, 0, ClientRectangle.Width, 30));
                LineartBrush.Dispose();
            }

            TopControl.BackgroundImage = topbg;
            //添加昵称
            TopControl.DUIControls.Add(AddDuiLabel("", _font, new Size(150, 30), new Point(0, 0), false));
            ChatList.BackColor = Color.White;
            BottonControl.Borders.TopColor = Color.FromArgb(100, 60, 60, 60);
            BottonControl.BackColor = Color.White;
            BottonControl.DUIControls.Add(AddDuiLabel("", _font, new Size(BottonControl.Width, 38), new Point(0, 0), false));
            DuiLabel bt1 = AddDuiLabel("全部忽略", _font, new Size(60, 30), new Point(10, 4), true);
            bt1.ForeColor = Color.Blue;
            bt1.Cursor = Cursors.Hand;
            bt1.TextAlign = ContentAlignment.MiddleCenter;
            DuiLabel bt2 = AddDuiLabel("全部查看", _font, new Size(60, 30), new Point(this.Width - 90, 4), true);
            bt2.ForeColor = Color.Blue;
            bt2.Cursor = Cursors.Hand;
            bt2.TextAlign = ContentAlignment.MiddleCenter;
            BottonControl.DUIControls.Add(bt1);
            BottonControl.DUIControls.Add(bt2);
        }

        #region 方法
        /// <summary>
        /// 是否存在列表
        /// </summary>
        /// <param name="uin">QQ编号（非QQ号）</param>
        /// <returns></returns>
        public DuiBaseControl IsHaveItem(string uin)
        {
            DuiBaseControl dc = null;
            //for (int i = 0; i < ChatList.Items.Count; i++)
            //{
            //    object[] obj = (object[])ChatList.Items[i].Tag;
            //    TagFrirendInfo tagFrirendInfo = (TagFrirendInfo)obj[0];
            //    if (tagFrirendInfo.Uin == uin)
            //    {
            //        dc = ChatList.Items[i];
            //        break;
            //    }
            //}
            return dc;
        }
        /// <summary>
        /// 添加新消息列表
        /// </summary>
        /// <param name="headimg"></param>
        /// <param name="uin"></param>
        /// <param name="nicname"></param>
        /// <param name="msg"></param>
        //public void AddItemsMsg(string uin, string type, string nicname, string msg)
        //{
        //    TagFrirendInfo tagFrirendInfo = null;
        //    try
        //    {
        //        tagFrirendInfo = (type == "1"
        //            ? GetObj(headimg, Webqq.GetFriendsInfomation(uin))
        //            : GetObj(headimg, Webqq.GetGroupInfomation(uin)));
        //    }
        //    catch
        //    {
        //        tagFrirendInfo = null;
        //    }
        //    if (tagFrirendInfo == null)
        //        return;
        //    FrmChat fc = FrmMain.FindFrmChat(uin, type);
        //    if (fc != null)
        //    {
        //        //fc.ReadChatRecord();
        //        return;
        //    }
        //    //判断是否存在列表中
        //    DuiBaseControl dc = IsHaveItem(tagFrirendInfo.Uin);
        //    if (dc != null)
        //    {
        //        ((DuiLabel)dc.Controls[3]).Text = (int.Parse(((DuiLabel)dc.Controls[3]).Text) + 1).ToString();
        //        ((DuiLabel)dc.Controls[1]).Text = msg;
        //    }
        //    else
        //    {
        //        DuiBaseControl item = AddChatItems(headimg, tagFrirendInfo.NicName, msg);
        //        //第一项为头像，第二项为QQ名称与个性签名，第三项为好友UIN（非QQ号）,第四项为好友类型1为好友，2为群
        //        object[] obj = new object[10];
        //        obj[0] = tagFrirendInfo;
        //        obj[1] = type;
        //        item.Tag = obj;
        //        ChatList.Items.Add(item);
        //        ChatList.RefreshList();
        //        this.Height = ChatList.Items.Count * 55 + 80;
        //        this.Top = Screen.GetWorkingArea(this).Height - this.Height;
        //    }
        //}
        /// <summary>
        /// 添加新消息列表
        /// </summary>
        /// <param name="headimg"></param>
        /// <param name="uin"></param>
        /// <param name="nicname"></param>
        /// <param name="msg"></param>
        //public void AddItemsMsg(Bitmap headimg, string uin, string type, string nicname, List<MsgModel> msgModels)
        //{
        //    TagFrirendInfo tagFrirendInfo = null;
        //    try
        //    {
        //        tagFrirendInfo = (type == "1"
        //            ? GetObj(headimg, Webqq.GetFriendsInfomation(uin))
        //            : GetObj(headimg, Webqq.GetGroupInfomation(uin)));
        //    }
        //    catch
        //    {
        //        tagFrirendInfo = null;
        //    }
        //    if (tagFrirendInfo == null)
        //        return;
        //    FrmChat fc = FrmMain.FindFrmChat(uin, type);
        //    if (fc != null)
        //    {
        //        //fc.ReadChatRecord();
        //        return;
        //    }
        //    string lastMsg = "";
        //    if (msgModels.Count > 0)
        //    {
        //        if (msgModels[0].Type == "msg")
        //            lastMsg = msgModels[msgModels.Count - 1].Value;
        //        else if (msgModels[0].Type == "face")
        //            lastMsg = "[表情]";
        //        else if (msgModels[0].Type == "offpic")
        //            lastMsg = "[自定义图片]";
        //    }

        //    //判断是否存在列表中
        //    DuiBaseControl dc = IsHaveItem(tagFrirendInfo.Uin);
        //    if (dc != null)
        //    {
        //        ((DuiLabel)dc.Controls[3]).Text = (int.Parse(((DuiLabel)dc.Controls[3]).Text) + 1).ToString();
        //        ((DuiLabel)dc.Controls[1]).Text = lastMsg;
        //    }
        //    else
        //    {
        //        DuiBaseControl item = AddChatItems(headimg, tagFrirendInfo.NicName, lastMsg);
        //        //第一项为头像，第二项为QQ名称与个性签名，第三项为好友UIN（非QQ号）,第四项为好友类型1为好友，2为群
        //        object[] obj = new object[10];
        //        obj[0] = tagFrirendInfo;
        //        obj[1] = type;
        //        item.Tag = obj;
        //        ChatList.Items.Add(item);
        //        ChatList.RefreshList();
        //        this.Height = ChatList.Items.Count * 55 + 80;
        //        this.Top = Screen.GetWorkingArea(this).Height - this.Height;
        //    }
        //}
        /// <summary>
        /// 添加列表项
        /// </summary>
        /// <param name="head"></param>
        /// <param name="displayname"></param>
        /// <param name="personalMsg"></param>
        /// <returns></returns>
        public DuiBaseControl AddChatItems(Bitmap head, string displayname, string personalMsg)
        {
            //好友名称
            DuiLabel lbl = AddDuiLabel(displayname, _font, new Size(ChatList.Width - 85, 20), new Point(60, 8),
                false);
            //消息
            DuiLabel info = AddDuiLabel(personalMsg, _font, new Size(ChatList.Width - 85, 20), new Point(59, 30),
                false);
            //消息数量
            DuiLabel infocount = AddDuiLabel("1", _font, new Size(20, 20), new Point(ChatList.Width - 50, 15),
                false);
            infocount.ForeColor = Color.White;
            infocount.TextAlign = ContentAlignment.MiddleCenter;
            infocount.BorderRender = new FilletBorderRender(12, 1, Color.FromArgb(245, 108, 11));
            infocount.BackColor = Color.FromArgb(245, 108, 11);
            info.ForeColor = Color.FromArgb(60, 60, 60);
            //好友头像
            DuiBaseControl pic = AddItemsHeadImgControll(head, ImageLayout.Stretch, Cursors.Default, new Size(45, 45),
                new Point(5, 5), true);
            pic.BackColor = Color.BurlyWood;
            //好友项容器
            DuiBaseControl item = new DuiBaseControl();
            item.BackColor = Color.Transparent;
            item.Width = ChatList.Width;
            item.Height = 55;
            item.MouseDoubleClick += ItemsMouseDoubleClick;
            item.MouseEnter += ItemsMouseEnter;
            item.MouseLeave += ItemsMouseLeave;
            item.Controls.Add(lbl);
            item.Controls.Add(info);
            item.Controls.Add(pic);
            item.Controls.Add(infocount);
            item.Name = ChatList.Items.Count.ToString();
            item.Visible = true;
            return item;
        }
        /// <summary>
        /// 返回DuiLabel
        /// </summary>
        /// <param name="text">显示的信息</param>
        /// <param name="font">字体</param>
        /// <param name="size">大小</param>
        /// <param name="location">显示位置</param>
        /// <returns></returns>
        public DuiLabel AddDuiLabel(string text, Font font, Size size, Point location, bool isEven)
        {
            DuiLabel duiLabel = new DuiLabel();
            duiLabel.Size = size;
            duiLabel.Text = text;
            duiLabel.Font = font;
            duiLabel.TextRenderMode = TextRenderingHint.AntiAliasGridFit;
            duiLabel.Location = location;
            duiLabel.ShowBorder = false;

            duiLabel.Borders.TopColor =
                duiLabel.Borders.BottomColor =
                    duiLabel.Borders.LeftColor =
                        duiLabel.Borders.RightColor = Color.FromArgb(40, Color.Black);
            if (isEven)
            {
                duiLabel.MouseEnter += HightMouseEnter;
                duiLabel.MouseLeave += HightMouseLeave;
            }
            return duiLabel;
        }
        /// <summary>
        /// 添加头像
        /// </summary>
        /// <param name="bitmap"></param>
        /// <param name="layout"></param>
        /// <param name="cursor"></param>
        /// <param name="size"></param>
        /// <param name="location"></param>
        /// <param name="isEven"></param>
        /// <returns></returns>
        public DuiBaseControl AddItemsHeadImgControll(Bitmap bitmap, ImageLayout layout, Cursor cursor, Size size,
            Point location, bool isEven)
        {
            DuiBaseControl _baseControl = new DuiBaseControl();
            _baseControl.Size = size;
            _baseControl.Cursor = cursor;
            _baseControl.Location = location;
            _baseControl.BackColor = Color.Transparent;
            //baseControl.BorderRender = new FilletBorderRender(6, 2, Color.DodgerBlue);
            _baseControl.BackgroundImage = bitmap;
            _baseControl.BackgroundImageLayout = layout;
            return _baseControl;
        }

        /// <summary>
        /// 好友信息类封装成object
        /// </summary>
        /// <param name="wq"></param>
        /// <param name="uin"></param>
        /// <param name="headBitmap"></param>
        /// <param name="nicName"></param>
        /// <param name="personalMsg"></param>
        /// <param name="isonline"></param>
        /// <returns></returns>
        //public TagFrirendInfo GetObj(Bitmap headBitmap, FriendsInfo fi)
        //{
        //    TagFrirendInfo tag = new TagFrirendInfo();
        //    tag.HeadImg = headBitmap;
        //    tag.NicName = fi.Nick;
        //    tag.Sign = "";
        //    tag.QQ = Webqq.GetTrueUin(fi.Uin, "1");
        //    tag.Uin = fi.Uin;
        //    tag.MarkName = fi.MarkName;
        //    tag.FlagStatus = fi.Flag;
        //    tag.IsVip = fi.Isvip;
        //    tag.VipLv = fi.Viplevel;
        //    tag.IsHaveMsg = "";
        //    return tag;
        //}
        /// <summary>
        /// 好友信息类封装成object
        /// </summary>
        /// <param name="wq"></param>
        /// <param name="uin"></param>
        /// <param name="headBitmap"></param>
        /// <param name="nicName"></param>
        /// <param name="personalMsg"></param>
        /// <param name="isonline"></param>
        /// <returns></returns>
        //public TagFrirendInfo GetObj(Bitmap headBitmap, GroupInfo gi)
        //{
        //    TagFrirendInfo tag = new TagFrirendInfo();
        //    tag.HeadImg = headBitmap;
        //    tag.NicName = gi.Name;
        //    tag.Sign = "";
        //    tag.QQ = Webqq.GetTrueUin(gi.Code, "2");//获取群成员
        //    tag.Uin = gi.Code;//用户获取头像
        //    tag.MarkName = "";
        //    tag.IsVip = "0";
        //    tag.VipLv = "0";
        //    tag.IsHaveMsg = "";
        //    return tag;
        //}
        #endregion
        #region 事件
        private void ItemsMouseDoubleClick(object sender, MouseEventArgs e)
        {
            //this.BeginInvoke((MethodInvoker)delegate()
            //{
            //    try
            //    {
            //DuiBaseControl items = ((DuiBaseControl)sender);
            //object tag;
            //object[] obj = (object[])items.Tag;
            //tag = obj[0];
            ////第一项为区分是好友消息还是群消息（1为好友消息，2为群消息）
            ////第二项为好友信息或群信息
            //string Qtype = (string)obj[1];
            //TagFrirendInfo tagFrirendInfo = (TagFrirendInfo)tag;

            //FrmChat fc = FrmMain.FindFrmChat(tagFrirendInfo.Uin, Qtype);
            //if (fc != null)
            //{
            //    if (fc.WindowState == FormWindowState.Minimized)
            //    {
            //        fc.WindowState = FormWindowState.Normal;
            //    }
            //    //fc.ReadChatRecord();
            //}
            //else
            //{
            //    fc = new FrmChat(Webqq, tagFrirendInfo, Qtype);
            //    FrmMain.FrmChatsList.Add(fc);
            //    //fc.ReadChatRecord();
            //    fc.Show();
            //}
            //ChatList.Items.Remove(items);
            //ChatList.RefreshList();
            //if (ChatList.Items.Count <= 0)
            //{
            //    timShow.Enabled = false;
            //    this.Hide();
            //}
            //this.Height = ChatList.Items.Count * 55 + 80;
            //this.Top = Screen.GetWorkingArea(this).Height - this.Height;

            ////MessageBox.Show(str[0] + "\r\n" + str[1]);
            //    }
            //    catch
            //    {
            //    }
            //});
        }
        /// <summary>
        /// 选中的好友项ID(为选中为-1)
        /// </summary>
        public int ItemsIndex = -1;
        /// <summary>
        /// 好友项鼠标离开时显示的背景色
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ItemsMouseLeave(object sender, EventArgs e)
        {
            if (ItemsIndex != int.Parse(((DuiBaseControl)sender).Name))
            {
                ((DuiBaseControl)sender).BackColor = Color.Transparent;
            }
        }
        /// <summary>
        /// 好友项鼠标进入控件时显示的背景色
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ItemsMouseEnter(object sender, EventArgs e)
        {
            if (ItemsIndex != int.Parse(((DuiBaseControl)sender).Name))
            {
                ((DuiBaseControl)sender).BackColor = Color.FromArgb(120, Color.SteelBlue);
            }
        }
        /// <summary>
        /// 鼠标离开控件时不显示边框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HightMouseLeave(object sender, EventArgs e)
        {
            ((DuiBaseControl)sender).ShowBorder = false;
        }
        /// <summary>
        ///  鼠标进入控件时高亮显示边框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HightMouseEnter(object sender, EventArgs e)
        {
            ((DuiBaseControl)sender).ShowBorder = true;
        }

        private void layeredButton1_Click(object sender, EventArgs e)
        {
        }
        #endregion
    }
}