using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PrefixionSystem.DataModule
{
    public class RecordDetail
    {
        public string RecordId { get; set; }

        public string SourceTar { get; set; }

        public string SourceTarPath { get; set; }

        public string MediumType { get; set; }

        public string MsgStartTime { get; set; }

        public string MsgEndTime { get; set; }

        public string AreaCode { get; set; }

        public string SavePath { get; set; }

        /// <summary>
        /// 事件级别   0：未知级别（Unknown）1：1级（特别重大/红色预警/Red） 2：2级（重大/橙色预警/ Orange）3：3级（较大/黄色预警/ Yellow）4：4级（一般/蓝色预警/ Blue
        /// </summary>
        public string Severity { get; set; }

        /// <summary>
        /// 事件类型编码
        /// </summary>
        public string EventType { get; set; }

        /// <summary>
        /// 文本信息的内容
        /// </summary>
        public string TextContent { get; set; }

        /// <summary>
        /// 处理标记  1表示已处理  0表示未处理
        /// </summary>
        public int DealFlag { get; set; }

        /// <summary>
        /// 发送消息部门
        /// </summary>
       public string SenderName { get; set; }

        /// <summary>
        /// 发送部门资源码
        /// </summary>
        public string SenderCode { get; set; }

        /// <summary>
        /// 消息发送时间
        /// </summary>
        public string SendTime { get; set; }

        /// <summary>
        /// 消息标题
        /// </summary>
        public string MsgTitle { get; set; }



    }
}
