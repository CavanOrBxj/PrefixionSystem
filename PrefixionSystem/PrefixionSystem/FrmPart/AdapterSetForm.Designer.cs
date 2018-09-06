namespace PrefixionSystem.FrmPart
{
    partial class AdapterSetForm
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
            this.txtAdapterPort = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCloseWarning = new System.Windows.Forms.Button();
            this.txtAdapterIP = new System.Windows.Forms.TextBox();
            this.btnSet = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtAdapterPort
            // 
            this.txtAdapterPort.Location = new System.Drawing.Point(173, 106);
            this.txtAdapterPort.Name = "txtAdapterPort";
            this.txtAdapterPort.Size = new System.Drawing.Size(118, 21);
            this.txtAdapterPort.TabIndex = 7;
            this.txtAdapterPort.Text = "8082";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(81, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "适配器端口号：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(105, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "适配器IP：";
            // 
            // btnCloseWarning
            // 
            this.btnCloseWarning.Location = new System.Drawing.Point(216, 166);
            this.btnCloseWarning.Name = "btnCloseWarning";
            this.btnCloseWarning.Size = new System.Drawing.Size(75, 23);
            this.btnCloseWarning.TabIndex = 9;
            this.btnCloseWarning.Text = "关闭报警";
            this.btnCloseWarning.UseVisualStyleBackColor = true;
            this.btnCloseWarning.Click += new System.EventHandler(this.btnCloseWarning_Click);
            // 
            // txtAdapterIP
            // 
            this.txtAdapterIP.Location = new System.Drawing.Point(173, 57);
            this.txtAdapterIP.Name = "txtAdapterIP";
            this.txtAdapterIP.Size = new System.Drawing.Size(118, 21);
            this.txtAdapterIP.TabIndex = 10;
            this.txtAdapterIP.Text = "8082";
            // 
            // btnSet
            // 
            this.btnSet.Location = new System.Drawing.Point(82, 166);
            this.btnSet.Name = "btnSet";
            this.btnSet.Size = new System.Drawing.Size(75, 23);
            this.btnSet.TabIndex = 11;
            this.btnSet.Text = "保存配置";
            this.btnSet.UseVisualStyleBackColor = true;
            this.btnSet.Click += new System.EventHandler(this.btnSet_Click);
            // 
            // AdapterSetForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(21)))), ((int)(((byte)(20)))));
            this.ClientSize = new System.Drawing.Size(368, 244);
            this.Controls.Add(this.btnSet);
            this.Controls.Add(this.txtAdapterIP);
            this.Controls.Add(this.btnCloseWarning);
            this.Controls.Add(this.txtAdapterPort);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.EffectCaption = CCWin.TitleType.Title;
            this.Name = "AdapterSetForm";
            this.Text = "适配器声光报警设置";
            this.TitleColor = System.Drawing.Color.White;
            this.Load += new System.EventHandler(this.AdapterSetForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtAdapterPort;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCloseWarning;
        private System.Windows.Forms.TextBox txtAdapterIP;
        private System.Windows.Forms.Button btnSet;
    }
}