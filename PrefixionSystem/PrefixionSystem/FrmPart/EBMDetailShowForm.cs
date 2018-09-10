using System.Windows.Forms;
using CCWin;
using PrefixionSystem.DataModule;

namespace PrefixionSystem
{
    public partial class EBMDetailShowForm : Form
    {
        public RecordDetail record_;

        public EBMDetailShowForm(RecordDetail  record)
        {
            InitializeComponent();
            record_ = record;
            this.Load += EBMDetailShowForm_Load;

        }

        void EBMDetailShowForm_Load(object sender, System.EventArgs e)
        {
            lab_AreaCode.Text = record_.AreaCode;
            lab_DealFlag.Text = record_.DealFlag == 1 ? "已处理" : "未处理";
            lab_EventType.Text = record_.EventType;
            lab_MediumType.Text = record_.MediumType;
            lab_MsgEndTime.Text = record_.MsgEndTime;
            lab_MsgStartTime.Text = record_.MsgStartTime;
            txt_SavePath.Text = record_.SavePath;
          //  lab_SavePath.Text = record_.SavePath;
            lab_SenderCode.Text = record_.SenderCode;
            lab_SenderName.Text = record_.SenderName;
            lab_SendTime.Text = record_.SendTime;

            switch (record_.Severity)
            {
                case "0":
                    lab_Severity.Text = "未知等级";
                    break;
                case "1":
                    lab_Severity.Text = "1级";
                    break;
                case "2":
                    lab_Severity.Text = "2级";
                    break;
                case "3":
                    lab_Severity.Text = "3级";
                    break;
                case "4":
                    lab_Severity.Text = "4级";
                    break;
            }
            txt_SourceTarPath.Text= record_.SourceTarPath;
           // lab_SourceTarPath.Text = record_.SourceTarPath;
           txt_TextContent.Text= record_.TextContent;
          //  lab_TextContent.Text = record_.TextContent;
        }
        

        private void picClose_Click(object sender, System.EventArgs e)
        {
            Close();
        }

     
    }
}
