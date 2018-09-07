namespace PrefixionSystem.FrmPart
{
    partial class FrmMsglist
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMsglist));
            this.timShow = new System.Windows.Forms.Timer(this.components);
            this.ChatList = new LayeredSkin.Controls.LayeredListBox();
            this.layeredButton1 = new LayeredSkin.Controls.LayeredButton();
            this.BottonControl = new LayeredSkin.Controls.LayeredBaseControl();
            this.TopControl = new LayeredSkin.Controls.LayeredBaseControl();
            this.SuspendLayout();
            // 
            // timShow
            // 
            this.timShow.Interval = 1000;
            this.timShow.Tick += new System.EventHandler(this.timShow_Tick);
            // 
            // ChatList
            // 
            this.ChatList.AutoFocus = false;
            this.ChatList.BackColor = System.Drawing.Color.Transparent;
            this.ChatList.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ChatList.Borders.BottomColor = System.Drawing.Color.Transparent;
            this.ChatList.Borders.BottomWidth = 0;
            this.ChatList.Borders.LeftColor = System.Drawing.Color.Transparent;
            this.ChatList.Borders.LeftWidth = 0;
            this.ChatList.Borders.RightColor = System.Drawing.Color.Transparent;
            this.ChatList.Borders.RightWidth = 0;
            this.ChatList.Borders.TopColor = System.Drawing.Color.Transparent;
            this.ChatList.Borders.TopWidth = 0;
            this.ChatList.Canvas = ((System.Drawing.Bitmap)(resources.GetObject("ChatList.Canvas")));
            this.ChatList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ChatList.EnabledMouseWheel = true;
            this.ChatList.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ChatList.ItemSize = new System.Drawing.Size(100, 100);
            this.ChatList.ListTop = 0;
            this.ChatList.Location = new System.Drawing.Point(4, 34);
            this.ChatList.Name = "ChatList";
            this.ChatList.Orientation = LayeredSkin.Controls.ListOrientation.Vertical;
            this.ChatList.RollSize = 30;
            this.ChatList.ScrollBarBackColor = System.Drawing.Color.Silver;
            this.ChatList.ScrollBarColor = System.Drawing.Color.DimGray;
            this.ChatList.ScrollBarHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ChatList.ScrollBarWidth = 10;
            this.ChatList.ShowScrollBar = true;
            this.ChatList.Size = new System.Drawing.Size(261, 210);
            this.ChatList.SmoothScroll = true;
            this.ChatList.TabIndex = 4;
            this.ChatList.Text = "好友列表";
            this.ChatList.Ulmul = false;
            this.ChatList.Value = 0D;
            // 
            // layeredButton1
            // 
            this.layeredButton1.AdaptImage = true;
            this.layeredButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.layeredButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.layeredButton1.BaseColor = System.Drawing.Color.Wheat;
            this.layeredButton1.Borders.BottomColor = System.Drawing.Color.Empty;
            this.layeredButton1.Borders.BottomWidth = 1;
            this.layeredButton1.Borders.LeftColor = System.Drawing.Color.Empty;
            this.layeredButton1.Borders.LeftWidth = 1;
            this.layeredButton1.Borders.RightColor = System.Drawing.Color.Empty;
            this.layeredButton1.Borders.RightWidth = 1;
            this.layeredButton1.Borders.TopColor = System.Drawing.Color.Empty;
            this.layeredButton1.Borders.TopWidth = 1;
            this.layeredButton1.Canvas = ((System.Drawing.Bitmap)(resources.GetObject("layeredButton1.Canvas")));
            this.layeredButton1.ControlState = LayeredSkin.Controls.ControlStates.Normal;
            this.layeredButton1.HaloColor = System.Drawing.Color.White;
            this.layeredButton1.HaloSize = 5;
            this.layeredButton1.HoverImage = ((System.Drawing.Image)(resources.GetObject("layeredButton1.HoverImage")));
            this.layeredButton1.IsPureColor = false;
            this.layeredButton1.Location = new System.Drawing.Point(240, 4);
            this.layeredButton1.Name = "layeredButton1";
            this.layeredButton1.NormalImage = ((System.Drawing.Image)(resources.GetObject("layeredButton1.NormalImage")));
            this.layeredButton1.PressedImage = ((System.Drawing.Image)(resources.GetObject("layeredButton1.PressedImage")));
            this.layeredButton1.Radius = 10;
            this.layeredButton1.ShowBorder = true;
            this.layeredButton1.Size = new System.Drawing.Size(23, 25);
            this.layeredButton1.TabIndex = 3;
            this.layeredButton1.TextLocationOffset = new System.Drawing.Point(0, 0);
            this.layeredButton1.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            this.layeredButton1.TextShowMode = LayeredSkin.TextShowModes.Halo;
            this.layeredButton1.Click += new System.EventHandler(this.layeredButton1_Click);
            // 
            // BottonControl
            // 
            this.BottonControl.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.BottonControl.Borders.BottomColor = System.Drawing.Color.Empty;
            this.BottonControl.Borders.BottomWidth = 1;
            this.BottonControl.Borders.LeftColor = System.Drawing.Color.Empty;
            this.BottonControl.Borders.LeftWidth = 1;
            this.BottonControl.Borders.RightColor = System.Drawing.Color.Empty;
            this.BottonControl.Borders.RightWidth = 1;
            this.BottonControl.Borders.TopColor = System.Drawing.Color.Empty;
            this.BottonControl.Borders.TopWidth = 1;
            this.BottonControl.Canvas = ((System.Drawing.Bitmap)(resources.GetObject("BottonControl.Canvas")));
            this.BottonControl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BottonControl.Location = new System.Drawing.Point(4, 244);
            this.BottonControl.Name = "BottonControl";
            this.BottonControl.Size = new System.Drawing.Size(261, 38);
            this.BottonControl.TabIndex = 2;
            // 
            // TopControl
            // 
            this.TopControl.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.TopControl.Borders.BottomColor = System.Drawing.Color.Empty;
            this.TopControl.Borders.BottomWidth = 1;
            this.TopControl.Borders.LeftColor = System.Drawing.Color.Empty;
            this.TopControl.Borders.LeftWidth = 1;
            this.TopControl.Borders.RightColor = System.Drawing.Color.Empty;
            this.TopControl.Borders.RightWidth = 1;
            this.TopControl.Borders.TopColor = System.Drawing.Color.Empty;
            this.TopControl.Borders.TopWidth = 1;
            this.TopControl.Canvas = ((System.Drawing.Bitmap)(resources.GetObject("TopControl.Canvas")));
            this.TopControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.TopControl.Location = new System.Drawing.Point(4, 4);
            this.TopControl.Name = "TopControl";
            this.TopControl.Size = new System.Drawing.Size(261, 30);
            this.TopControl.TabIndex = 1;
            // 
            // FrmMsglist
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(269, 286);
            this.Controls.Add(this.ChatList);
            this.Controls.Add(this.layeredButton1);
            this.Controls.Add(this.BottonControl);
            this.Controls.Add(this.TopControl);
            this.Name = "FrmMsglist";
            this.Padding = new System.Windows.Forms.Padding(4);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FrmLoad);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timShow;
        private LayeredSkin.Controls.LayeredBaseControl TopControl;
        private LayeredSkin.Controls.LayeredBaseControl BottonControl;
        private LayeredSkin.Controls.LayeredButton layeredButton1;
        public LayeredSkin.Controls.LayeredListBox ChatList;
    }
}