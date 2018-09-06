using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace PrefixionSystem.DataModule
{
    public class ComboBoxHelper
    {

        public static void InitOutSwitchType(DataGridViewComboBoxColumn box)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Display", typeof(string));
            dt.Columns.Add("Value", typeof(byte));
            DataRow dr = dt.NewRow();
            dr["Display"] = "关闭输出";
            dr["Value"] = 1;
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Display"] = "开启输出";
            dr["Value"] = 2;
            dt.Rows.Add(dr);
            box.DisplayMember = "Display";
            box.ValueMember = "Value";
            box.DataSource = dt;
        }

        public static void InitSearchType(ComboBox box)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Display", typeof(string));
            dt.Columns.Add("Value", typeof(byte));

            DataRow dr = dt.NewRow();
            dr["Display"] = "消息媒体";
            dr["Value"] = 1;
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["Display"] = "开始时间";
            dr["Value"] = 2;
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["Display"] = "事件类型码";
            dr["Value"] = 3;
            dt.Rows.Add(dr);


            dr = dt.NewRow();
            dr["Display"] = "事件级别";
            dr["Value"] = 4;
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["Display"] = "区域码";
            dr["Value"] = 5;
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["Display"] = "文本关键字";
            dr["Value"] = 6;
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["Display"] = "处理/未处理";
            dr["Value"] = 7;
            dt.Rows.Add(dr);

            box.DisplayMember = "Display";
            box.ValueMember = "Value";
            box.DataSource = dt;
        }

        public static void InitMediumType(ComboBox box)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Display", typeof(string));
            dt.Columns.Add("Value", typeof(byte));

            DataRow dr = dt.NewRow();
            dr["Display"] = "mp3";
            dr["Value"] = 1;
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["Display"] = "文本";
            dr["Value"] = 2;
            dt.Rows.Add(dr);

            box.DisplayMember = "Display";
            box.ValueMember = "Value";
            box.DataSource = dt;
        }

        public static void InitSeverityType(ComboBox box)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Display", typeof(string));
            dt.Columns.Add("Value", typeof(byte));

            DataRow dr = dt.NewRow();
            dr["Display"] = "未知级别";
            dr["Value"] = 0;
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["Display"] = "1级";
            dr["Value"] = 1;
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["Display"] = "2级";
            dr["Value"] = 2;
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["Display"] = "3级";
            dr["Value"] = 3;
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["Display"] = "4级";
            dr["Value"] = 4;
            dt.Rows.Add(dr);

            box.DisplayMember = "Display";
            box.ValueMember = "Value";
            box.DataSource = dt;
        }

        public static void InitMessageStatusType(ComboBox box)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Display", typeof(string));
            dt.Columns.Add("Value", typeof(byte));

            DataRow dr = dt.NewRow();
            dr["Display"] = "已处理";
            dr["Value"] = 1;
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["Display"] = "未处理";
            dr["Value"] = 2;
            dt.Rows.Add(dr);

            box.DisplayMember = "Display";
            box.ValueMember = "Value";
            box.DataSource = dt;
        }

    }
}
