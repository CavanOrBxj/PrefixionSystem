using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace PrefixionSystem
{
    public class responseXML
    {
        private IniFiles serverini = new IniFiles(System.Windows.Forms.Application.StartupPath + "\\Config.ini");
        public string SourceAreaCode = "";
        public string SourceType = "";
        public string SourceName = "";
        public string SourceID = "";
        public string sHBRONO = "0000000000000";//"010332132300000001";//实体编号

        //通用反馈的xml头
        public int xmlHead(XmlDocument xmlDoc, XmlElement xmlElem, EBD ebdsr, string EBDstyle, string strebdid)
        {
            #region 标准头部
            XmlAttribute xmlns = xmlDoc.CreateAttribute("xmlns:xs");
            xmlns.Value = "http://www.w3.org/2001/XMLSchema";
            xmlElem.Attributes.Append(xmlns);

            //Version
            XmlElement xmlProtocolVer = xmlDoc.CreateElement("EBDVersion");
            xmlProtocolVer.InnerText = "1.0";
            xmlElem.AppendChild(xmlProtocolVer);
            //EBDID
            XmlElement xmlEBDID = xmlDoc.CreateElement("EBDID");
            xmlEBDID.InnerText = strebdid;
            xmlElem.AppendChild(xmlEBDID);

            //EBDType
            XmlElement xmlEBDType = xmlDoc.CreateElement("EBDType");
            xmlEBDType.InnerText = EBDstyle;
            xmlElem.AppendChild(xmlEBDType);

            //Source
            XmlElement xmlSRC = xmlDoc.CreateElement("SRC");
            xmlElem.AppendChild(xmlSRC);

            XmlElement xmlSRCAreaCode = xmlDoc.CreateElement("EBEID");
            xmlSRCAreaCode.InnerText = sHBRONO;// "010334152300000002";// ebdsr.SRC.EBEID;
            xmlSRC.AppendChild(xmlSRCAreaCode);
            XmlElement xmlEBDTime = xmlDoc.CreateElement("EBDTime");
            xmlEBDTime.InnerText = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            xmlElem.AppendChild(xmlEBDTime);
            #endregion End
            return 0;
        }

        /// <summary>
        /// 联动接口的通用反馈 新增于20180820  
        /// </summary>
        /// <param name="ebdsr"></param>
        /// <param name="EBDstyle"></param>
        /// <param name="strEBDID"></param>
        /// <returns></returns>
        public XmlDocument CurrencyReback(EBD ebdsr, string EBDstyle, string strEBDID)
        {
            XmlDocument xmlDoc = new XmlDocument();
            //加入XML的声明段落,Save方法不再xml上写出独立属性GB2312
            xmlDoc.AppendChild(xmlDoc.CreateXmlDeclaration("1.0", "utf-8", null));
            XmlElement xmlElem = xmlDoc.CreateElement("", "EBD", "");
            xmlDoc.AppendChild(xmlElem);
            xmlHead(xmlDoc, xmlElem, ebdsr, EBDstyle, strEBDID);

            XmlElement xmlRelatedEBD = xmlDoc.CreateElement("RelatedEBD");
            xmlElem.AppendChild(xmlRelatedEBD);

            XmlElement xmlReEBDID = xmlDoc.CreateElement("EBDID");
            xmlReEBDID.InnerText = ebdsr.EBDID;
            xmlRelatedEBD.AppendChild(xmlReEBDID);

            XmlElement xmlEBDResponse = xmlDoc.CreateElement("EBDResponse");
            xmlElem.AppendChild(xmlEBDResponse);

            XmlElement xmlResultCode = xmlDoc.CreateElement("ResultCode");
            xmlResultCode.InnerText = "1";
            xmlEBDResponse.AppendChild(xmlResultCode);

            XmlElement xmlResultDesc = xmlDoc.CreateElement("ResultDesc");
            xmlResultDesc.InnerText = "已完成接收";
            xmlEBDResponse.AppendChild(xmlResultDesc);

            return xmlDoc;


            #region  曲刚写的
            //XmlDocument xmlDoc = new XmlDocument();
            ////加入XML的声明段落,Save方法不再xml上写出独立属性GB2312
            //xmlDoc.AppendChild(xmlDoc.CreateXmlDeclaration("1.0", "utf-8", null));
            //XmlElement xmlElem = xmlDoc.CreateElement("", "EBD", "");
            //xmlDoc.AppendChild(xmlElem);
            //xmlHead(xmlDoc, xmlElem, ebd, EBDstyle, strEBDID);

            //XmlElement xmlRelatedEBD = xmlDoc.CreateElement("RelatedEBD");
            //xmlElem.AppendChild(xmlRelatedEBD);

            //XmlElement xmlReEBDID = xmlDoc.CreateElement("EBDID");
            //xmlReEBDID.InnerText = ebd.EBDID;
            //xmlRelatedEBD.AppendChild(xmlReEBDID);

            //XmlElement xmlEBDResponse = xmlDoc.CreateElement("EBDResponse");
            //xmlElem.AppendChild(xmlEBDResponse);

            //XmlElement xmlResultCode = xmlDoc.CreateElement("ResultCode");
            //xmlResultCode.InnerText = "1";
            //xmlEBDResponse.AppendChild(xmlResultCode);

            //XmlElement xmlResultDesc = xmlDoc.CreateElement("ResultDesc");
            //xmlResultDesc.InnerText = "接收解析及数据校验成功";
            //xmlEBDResponse.AppendChild(xmlResultDesc);
            //return xmlDoc;
            #endregion
        }


        /// <summary>
        /// －－接收回馈数据包-通用反馈
        /// </summary>
        /// <returns></returns>
        public XmlDocument EBDResponse(EBD ebdsr, string EBDstyle, string strEBDID)
        {
            XmlDocument xmlDoc = new XmlDocument();
            //加入XML的声明段落,Save方法不再xml上写出独立属性GB2312
            xmlDoc.AppendChild(xmlDoc.CreateXmlDeclaration("1.0", "utf-8", null));
            XmlElement xmlElem = xmlDoc.CreateElement("", "EBD", "");
            xmlDoc.AppendChild(xmlElem);
            xmlHead(xmlDoc, xmlElem, ebdsr, EBDstyle, strEBDID);

            XmlElement xmlRelatedEBD = xmlDoc.CreateElement("RelatedEBD");
            xmlElem.AppendChild(xmlRelatedEBD);

            XmlElement xmlReEBDID = xmlDoc.CreateElement("EBDID");
            xmlReEBDID.InnerText = ebdsr.EBDID;
            xmlRelatedEBD.AppendChild(xmlReEBDID);

            XmlElement xmlEBDResponse = xmlDoc.CreateElement("EBDResponse");
            xmlElem.AppendChild(xmlEBDResponse);

            XmlElement xmlResultCode = xmlDoc.CreateElement("ResultCode");
            xmlResultCode.InnerText = "1";
            xmlEBDResponse.AppendChild(xmlResultCode);

            XmlElement xmlResultDesc = xmlDoc.CreateElement("ResultDesc");
            xmlResultDesc.InnerText = "执行成功";
            xmlEBDResponse.AppendChild(xmlResultDesc);

            return xmlDoc;
        }

        public XmlDocument VerifySignatureError(EBD ebdsr, string EBDstyle, string strEBDID)
        {
            XmlDocument xmlDoc = new XmlDocument();
            //加入XML的声明段落,Save方法不再xml上写出独立属性GB2312
            xmlDoc.AppendChild(xmlDoc.CreateXmlDeclaration("1.0", "utf-8", null));
            XmlElement xmlElem = xmlDoc.CreateElement("", "EBD", "");
            xmlDoc.AppendChild(xmlElem);
            xmlHead(xmlDoc, xmlElem, ebdsr, EBDstyle, strEBDID);

            XmlElement xmlRelatedEBD = xmlDoc.CreateElement("RelatedEBD");
            xmlElem.AppendChild(xmlRelatedEBD);

            XmlElement xmlReEBDID = xmlDoc.CreateElement("EBDID");
            xmlReEBDID.InnerText = ebdsr.EBDID;
            xmlRelatedEBD.AppendChild(xmlReEBDID);

            XmlElement xmlEBDResponse = xmlDoc.CreateElement("EBDResponse");
            xmlElem.AppendChild(xmlEBDResponse);

            XmlElement xmlResultCode = xmlDoc.CreateElement("ResultCode");
            xmlResultCode.InnerText = "4";
            xmlEBDResponse.AppendChild(xmlResultCode);

            XmlElement xmlResultDesc = xmlDoc.CreateElement("ResultDesc");
            xmlResultDesc.InnerText = "签名验证失败";
            xmlEBDResponse.AppendChild(xmlResultDesc);

            return xmlDoc;
        }

        public XmlDocument EBDResponseyunweierror(EBD ebdsr, string EBDstyle, string strEBDID)
        {
            XmlDocument xmlDoc = new XmlDocument();
            //加入XML的声明段落,Save方法不再xml上写出独立属性GB2312
            xmlDoc.AppendChild(xmlDoc.CreateXmlDeclaration("1.0", "utf-8", null));
            XmlElement xmlElem = xmlDoc.CreateElement("", "EBD", "");
            xmlDoc.AppendChild(xmlElem);
            xmlHead(xmlDoc, xmlElem, ebdsr, EBDstyle, strEBDID);

            XmlElement xmlRelatedEBD = xmlDoc.CreateElement("RelatedEBD");
            xmlElem.AppendChild(xmlRelatedEBD);

            XmlElement xmlReEBDID = xmlDoc.CreateElement("EBDID");
            xmlReEBDID.InnerText = ebdsr.EBDID;
            xmlRelatedEBD.AppendChild(xmlReEBDID);

            XmlElement xmlEBDResponse = xmlDoc.CreateElement("EBDResponse");
            xmlElem.AppendChild(xmlEBDResponse);

            XmlElement xmlResultCode = xmlDoc.CreateElement("ResultCode");
            xmlResultCode.InnerText = "3";
            xmlEBDResponse.AppendChild(xmlResultCode);

            XmlElement xmlResultDesc = xmlDoc.CreateElement("ResultDesc");
            xmlResultDesc.InnerText = "该接口暂不支持";
            xmlEBDResponse.AppendChild(xmlResultDesc);

            return xmlDoc;
        }

        public XmlDocument EBDResponseerror(EBD ebdsr, string EBDstyle, string strEBDID)
        {
            XmlDocument xmlDoc = new XmlDocument();
            //加入XML的声明段落,Save方法不再xml上写出独立属性GB2312
            xmlDoc.AppendChild(xmlDoc.CreateXmlDeclaration("1.0", "utf-8", null));
            XmlElement xmlElem = xmlDoc.CreateElement("", "EBD", "");
            xmlDoc.AppendChild(xmlElem);
            xmlHead(xmlDoc, xmlElem, ebdsr, EBDstyle, strEBDID);

            XmlElement xmlRelatedEBD = xmlDoc.CreateElement("RelatedEBD");
            xmlElem.AppendChild(xmlRelatedEBD);

            XmlElement xmlReEBDID = xmlDoc.CreateElement("EBDID");
            xmlReEBDID.InnerText = ebdsr.EBDID;
            xmlRelatedEBD.AppendChild(xmlReEBDID);

            XmlElement xmlEBDResponse = xmlDoc.CreateElement("EBDResponse");
            xmlElem.AppendChild(xmlEBDResponse);

            XmlElement xmlResultCode = xmlDoc.CreateElement("ResultCode");
            xmlResultCode.InnerText = "5";
            xmlEBDResponse.AppendChild(xmlResultCode);

            XmlElement xmlResultDesc = xmlDoc.CreateElement("ResultDesc");
            xmlResultDesc.InnerText = "查找不到该EBMID";
            xmlEBDResponse.AppendChild(xmlResultDesc);

            return xmlDoc;
        }

        /// <summary>
        /// 河北－－应急消息播发状态反馈
        /// </summary>
        /// <returns>返回XML文档</returns>
        public XmlDocument EBMStateResponse(EBD ebdsr, string EBDstyle, string strebdid)
        {
            XmlDocument xmlDoc = new XmlDocument();
            //加入XML的声明段落,Save方法不再xml上写出独立属性GB2312
            xmlDoc.AppendChild(xmlDoc.CreateXmlDeclaration("1.0", "utf-8", null));
            XmlElement xmlElem = xmlDoc.CreateElement("", "EBD", "");
            xmlDoc.AppendChild(xmlElem);
            xmlHead(xmlDoc, xmlElem, ebdsr, EBDstyle, strebdid);

            XmlElement xmlRelatedEBD = xmlDoc.CreateElement("RelatedEBD");
            xmlElem.AppendChild(xmlRelatedEBD);

            XmlElement xmlReEBDID = xmlDoc.CreateElement("EBDID");
            xmlRelatedEBD.AppendChild(xmlReEBDID);
            XmlElement xmlEBMStateResponse = xmlDoc.CreateElement("EBMStateResponse");
            xmlElem.AppendChild(xmlEBMStateResponse);

            //反馈数据的时间
            XmlElement xmlRptTime = xmlDoc.CreateElement("RptTime");
            xmlRptTime.InnerText = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            xmlEBMStateResponse.AppendChild(xmlRptTime);
            //应急消息内容信息
            XmlElement xmlEBM = xmlDoc.CreateElement("EBM");
            xmlEBMStateResponse.AppendChild(xmlEBM);
            {
                //发布该应急广播消息的应急广播平台ID
                XmlElement xmlEBEID = xmlDoc.CreateElement("EBEID");
                xmlEBEID.InnerText = ebdsr.SRC.EBRID;
                xmlEBM.AppendChild(xmlEBEID);

                //应急消息ID通过应急广播平台ID和应急广播消息ID区别其他的应急广播消息
                XmlElement xmlEBMID = xmlDoc.CreateElement("EBMID");
                xmlEBMID.InnerText = ebdsr.EBM.EBMID;
                xmlEBM.AppendChild(xmlEBMID);
            }

            //播发状态标志，0：播发失败 1：正在播发 2：播发完成，该字段表明当前的应急广播消息播发是否已完成
            XmlElement xmlBrdStateCode = xmlDoc.CreateElement("BrdStateCode");
            xmlBrdStateCode.InnerText = "2";
            xmlEBMStateResponse.AppendChild(xmlBrdStateCode);

            //播发状态描述
            XmlElement xmlBrdStateDesc = xmlDoc.CreateElement("BrdStateDesc");
            xmlEBMStateResponse.AppendChild(xmlBrdStateDesc);

            //实际覆盖行政区域,该数据元素为可选
            XmlElement xmlCoverage = xmlDoc.CreateElement("Coverage");
            xmlEBMStateResponse.AppendChild(xmlCoverage);
            {
                //实际覆盖区域百分比
                XmlElement xmlCoveragePercent = xmlDoc.CreateElement("CoveragePercent");
                xmlCoveragePercent.InnerText = "90%";
                xmlCoverage.AppendChild(xmlCoveragePercent);

                //区域代码，格式为：（区域编码1，区域编码2）
                XmlElement xmlAreaCode = xmlDoc.CreateElement("AreaCode");
                if (ebdsr.EBM.MsgContent.AreaCode != null)
                {
                    xmlAreaCode.InnerText = ebdsr.EBM.MsgContent.AreaCode;
                }
                xmlCoverage.AppendChild(xmlAreaCode);
            }

            //播发数据详情，可选
            XmlElement xmlResBrdInfo = xmlDoc.CreateElement("ResBrdInfo");
            xmlEBMStateResponse.AppendChild(xmlResBrdInfo);
            {
                //播出情况，可为多个，元素关系参见资源信息数据上报
                XmlElement xmlResBrdItem = xmlDoc.CreateElement("ResBrdItem");
                xmlResBrdInfo.AppendChild(xmlResBrdItem);
                {
                    //反馈时间
                    XmlElement xmlARptTime = xmlDoc.CreateElement("RptTime");
                    xmlARptTime.InnerText = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    xmlResBrdItem.AppendChild(xmlARptTime);

                    XmlElement xmlEBEST = xmlDoc.CreateElement("EBEST");
                    xmlEBEST.InnerText = "";
                    xmlResBrdItem.AppendChild(xmlEBEST);
                    {
                        XmlElement xmlEBESTEBEID = xmlDoc.CreateElement("EBEID");
                        xmlEBESTEBEID.InnerText = "";
                        xmlEBEST.AppendChild(xmlEBESTEBEID);
                    }

                    XmlElement xmlEBEAS = xmlDoc.CreateElement("EBEAS");
                    xmlEBEAS.InnerText = "";
                    xmlResBrdItem.AppendChild(xmlEBEAS);
                    {
                        XmlElement xmlEBEASEBEID = xmlDoc.CreateElement("EBEID");
                        xmlEBEASEBEID.InnerText = "";
                        xmlEBEAS.AppendChild(xmlEBEASEBEID);
                    }

                    XmlElement xmlEBEBS = xmlDoc.CreateElement("EBEBS");
                    xmlEBEAS.InnerText = "";
                    xmlResBrdItem.AppendChild(xmlEBEBS);
                    {
                        XmlElement xmlEBEBSEBEID = xmlDoc.CreateElement("EBEID");
                        xmlEBEBSEBEID.InnerText = "";
                        xmlEBEBS.AppendChild(xmlEBEBSEBEID);

                        XmlElement xmlStartTime = xmlDoc.CreateElement("StartTime");
                        xmlStartTime.InnerText = "";
                        xmlEBEBS.AppendChild(xmlStartTime);

                        XmlElement xmlEndTime = xmlDoc.CreateElement("EndTime");
                        xmlEndTime.InnerText = "";
                        xmlEBEBS.AppendChild(xmlEndTime);

                        XmlElement xmlFileURL = xmlDoc.CreateElement("FileURL");
                        xmlEBEBS.AppendChild(xmlFileURL);

                        XmlElement xmlResultCode = xmlDoc.CreateElement("ResultCode");
                        xmlResultCode.InnerText = "2";
                        xmlEBEBS.AppendChild(xmlResultCode);

                        XmlElement xmlResultDesc = xmlDoc.CreateElement("ResultDesc");
                        xmlEBEBS.AppendChild(xmlResultDesc);
                    }
                }
            }
            return xmlDoc;
        }
        

        
        public XmlDocument EBMStateRequestResponse(EBD ebdsr, string strebdid)
        {
            XmlDocument xmlDoc = new XmlDocument();
            #region 标准头部
            //加入XML的声明段落,Save方法不再xml上写出独立属性
            xmlDoc.AppendChild(xmlDoc.CreateXmlDeclaration("1.0", "utf-8", null));
            //加入根元素
            XmlElement xmlElem = xmlDoc.CreateElement("", "EBD", "");
            xmlDoc.AppendChild(xmlElem);
            XmlAttribute xmlns = xmlDoc.CreateAttribute("xmlns:xs");
            xmlns.Value = "http://www.w3.org/2001/XMLSchema";
            xmlElem.Attributes.Append(xmlns);

            //Version
            XmlElement xmlProtocolVer = xmlDoc.CreateElement("EBDVersion");
            xmlProtocolVer.InnerText = "1.0";
            xmlElem.AppendChild(xmlProtocolVer);
            //EBDID
            XmlElement xmlEBDID = xmlDoc.CreateElement("EBDID");
            xmlEBDID.InnerText = strebdid;
            xmlElem.AppendChild(xmlEBDID);

            //EBDType
            XmlElement xmlEBDType = xmlDoc.CreateElement("EBDType");
            xmlEBDType.InnerText = "EBMStateResponse";
            xmlElem.AppendChild(xmlEBDType);

            //Source
            XmlElement xmlSRC = xmlDoc.CreateElement("SRC");

            xmlElem.AppendChild(xmlSRC);

            XmlElement xmlSRCAreaCode = xmlDoc.CreateElement("EBRID");
            xmlSRCAreaCode.InnerText = sHBRONO;//ebdsr.SRC.EBEID;
            xmlSRC.AppendChild(xmlSRCAreaCode);


            //EBDTime
            XmlElement xmlEBDTime = xmlDoc.CreateElement("EBDTime");
            xmlEBDTime.InnerText = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            xmlElem.AppendChild(xmlEBDTime);
            #endregion End

            #region EBMStateResponse
            XmlElement xmlEBMStateResponse = xmlDoc.CreateElement("EBMStateResponse");
            xmlElem.AppendChild(xmlEBMStateResponse);

            XmlElement xmlEBM = xmlDoc.CreateElement("EBM");
            xmlEBMStateResponse.AppendChild(xmlEBM);

            XmlElement xmlEBMID = xmlDoc.CreateElement("EBMID");
            if (ebdsr.EBMStateRequest != null)
                xmlEBMID.InnerText = ebdsr.EBMStateRequest.EBM.EBMID;//从100000000000开始编号
            else
                xmlEBMID.InnerText = ebdsr.EBM.EBMID;
            xmlEBM.AppendChild(xmlEBMID);

            XmlElement xmlRPTTime = xmlDoc.CreateElement("RptTime");
            xmlRPTTime.InnerText = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            xmlEBMStateResponse.AppendChild(xmlRPTTime);

            XmlElement xmlBRDState = xmlDoc.CreateElement("BrdStateCode");
            xmlBRDState.InnerText = "2";
            xmlEBMStateResponse.AppendChild(xmlBRDState);

            XmlElement BrdStateDesc = xmlDoc.CreateElement("BrdStateDesc");
            BrdStateDesc.InnerText = "完成";
            xmlEBMStateResponse.AppendChild(BrdStateDesc);

            #region Coverage

            // if (lEBMState.Count > 0)
            {
                XmlElement xmlCoverage = xmlDoc.CreateElement("Coverage");
                xmlEBMStateResponse.AppendChild(xmlCoverage);

                XmlElement xmlCoveragePercent = xmlDoc.CreateElement("CoveragePercent");
                xmlCoveragePercent.InnerText = "100";
                xmlCoverage.AppendChild(xmlCoveragePercent);

                // string[] AreaValue = lEBMState[0].BRDCoverageArea.Split('|');
                XmlElement xmlAreaCode = xmlDoc.CreateElement("AreaCode");
                if (ebdsr.EBM != null)
                    if (ebdsr.EBM.MsgContent != null)
                    {
                        xmlAreaCode.InnerText = ebdsr.EBM.MsgContent.AreaCode;//"003609810101AA"
                    }
                xmlCoverage.AppendChild(xmlAreaCode);
            }
            #endregion End

            #region Broadcast

            #endregion Broadcast
            #endregion End

            return xmlDoc;
        }

        /// <summary>
        /// 心跳包 
        /// </summary>
        /// <returns></returns>
        public XmlDocument HeartBeatResponse()
        {
            XmlDocument xmlDoc = new XmlDocument();
            //加入XML的声明段落,Save方法不再xml上写出独立属性GB2312
            xmlDoc.AppendChild(xmlDoc.CreateXmlDeclaration("1.0", "UTF-8", null));
            XmlElement xmlElem = xmlDoc.CreateElement("", "EBD", "");
            xmlDoc.AppendChild(xmlElem);

            #region 标准头部

            XmlAttribute xmlns = xmlDoc.CreateAttribute("xmlns:xs");
            xmlns.Value = "http://www.w3.org/2001/XMLSchema";
            xmlElem.Attributes.Append(xmlns);

            //Version
            XmlElement xmlProtocolVer = xmlDoc.CreateElement("EBDVersion");
            xmlProtocolVer.InnerText = "1.0";
            xmlElem.AppendChild(xmlProtocolVer);
            //EBDID
            XmlElement xmlEBDID = xmlDoc.CreateElement("EBDID");
            xmlEBDID.InnerText = "01" + sHBRONO + "0000000000000000";
            xmlElem.AppendChild(xmlEBDID);

            //EBDType
            XmlElement xmlEBDType = xmlDoc.CreateElement("EBDType");
            xmlEBDType.InnerText = "ConnectionCheck";
            xmlElem.AppendChild(xmlEBDType);

            //Source
            XmlElement xmlSRC = xmlDoc.CreateElement("SRC");
            xmlElem.AppendChild(xmlSRC);
            XmlElement xmlSRCAreaCode = xmlDoc.CreateElement("EBRID");
            xmlSRCAreaCode.InnerText = sHBRONO;// "010334152300000002";// ebdsr.SRC.EBEID;
            xmlSRC.AppendChild(xmlSRCAreaCode);

            XmlElement xmlDEST = xmlDoc.CreateElement("DEST");
            xmlElem.AppendChild(xmlDEST);

            XmlElement eebtEE = xmlDoc.CreateElement("EBRID");
            eebtEE.InnerText = "010232000000000001";// "010334152300000002";// ebdsr.SRC.EBEID;
            xmlDEST.AppendChild(eebtEE);

            XmlElement xmlEBDTime = xmlDoc.CreateElement("EBDTime");
            xmlEBDTime.InnerText = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            xmlElem.AppendChild(xmlEBDTime);
            #endregion End

            XmlElement xmlEBDResponse = xmlDoc.CreateElement("ConnectionCheck");
            xmlElem.AppendChild(xmlEBDResponse);

            XmlElement xmlResultCode = xmlDoc.CreateElement("RptTime");
            xmlResultCode.InnerText = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            xmlEBDResponse.AppendChild(xmlResultCode);

            return xmlDoc;
        }

        /// <summary>
        /// 实时流
        /// </summary>
        /// <returns></returns>
        public XmlDocument EBMStreamResponse(string strEBMID, string strUrl)
        {
            XmlDocument xmlDoc = new XmlDocument();
            //加入XML的声明段落,Save方法不再xml上写出独立属性GB2312
            xmlDoc.AppendChild(xmlDoc.CreateXmlDeclaration("1.0", "utf-8", null));
            XmlElement xmlElem = xmlDoc.CreateElement("", "EBD", "");
            xmlDoc.AppendChild(xmlElem);

            //xmlHead(xmlDoc, xmlElem, ebdsr, EBDstyle);

            #region 标准头部

            XmlAttribute xmlns = xmlDoc.CreateAttribute("xmlns:xs");
            xmlns.Value = "http://www.w3.org/2001/XMLSchema";
            xmlElem.Attributes.Append(xmlns);

            //Version
            XmlElement xmlProtocolVer = xmlDoc.CreateElement("EBDVersion");
            xmlProtocolVer.InnerText = "1.0";
            xmlElem.AppendChild(xmlProtocolVer);
            //EBDID
            XmlElement xmlEBDID = xmlDoc.CreateElement("EBDID");
            xmlEBDID.InnerText = "01" + sHBRONO + "0000000000000000";
            xmlElem.AppendChild(xmlEBDID);

            //EBDType
            XmlElement xmlEBDType = xmlDoc.CreateElement("EBDType");
            xmlEBDType.InnerText = "EBMStreamPortRequest";
            xmlElem.AppendChild(xmlEBDType);

            //Source
            XmlElement xmlSRC = xmlDoc.CreateElement("SRC");
            xmlElem.AppendChild(xmlSRC);

            XmlElement xmlSRCAreaCode = xmlDoc.CreateElement("EBRID");
            xmlSRCAreaCode.InnerText = sHBRONO;
            xmlSRC.AppendChild(xmlSRCAreaCode);
            XmlElement xmlEBDTime = xmlDoc.CreateElement("EBDTime");
            xmlEBDTime.InnerText = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            xmlElem.AppendChild(xmlEBDTime);
            #endregion End

            XmlElement xmlDevice = xmlDoc.CreateElement("EBMStream");
            xmlElem.AppendChild(xmlDevice);

            XmlElement xmlRelatedEBD = xmlDoc.CreateElement("RelatedEBM");
            xmlDevice.AppendChild(xmlRelatedEBD);
            XmlElement xmlReEBDID = xmlDoc.CreateElement("EBMID");
            xmlReEBDID.InnerText = strEBMID;//与EBDID一致就用这个写
            xmlRelatedEBD.AppendChild(xmlReEBDID);

            XmlElement xmlParams = xmlDoc.CreateElement("Params");
            xmlDevice.AppendChild(xmlParams);
            XmlElement xmlUrl = xmlDoc.CreateElement("Url");
            xmlUrl.InnerText = strUrl;//与EBDID一致就用这个写
            xmlParams.AppendChild(xmlUrl);

            return xmlDoc;
        }
        
        


        public string XmlSerialize<T>(T obj)
        {
            try
            {
                using (StringWriter sw = new StringWriter())
                {
                    Type t = obj.GetType();
                    XmlSerializer serializer = new XmlSerializer(obj.GetType());
                    serializer.Serialize(sw, obj);
                    sw.Close();
                    string[] array = sw.ToString().Split('\n');
                    string xmlString = "<?xml version='1.0' encoding='utf-8' standalone='yes'?>" + '\n';

                    for (int i = 1; i < array.Length; i++)
                    {
                        xmlString += array[i] + '\n';
                    }

                    return xmlString;
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                return null;
            }
        }

        public XmlDocument platformstateInfoResponse(string strebdid)
        {
            XmlDocument xmlDoc = new XmlDocument();

            //加入XML的声明段落,Save方法不再xml上写出独立属性
            xmlDoc.AppendChild(xmlDoc.CreateXmlDeclaration("1.0", "utf-8", null));
            //加入根元素
            XmlElement xmlElem = xmlDoc.CreateElement("", "EBD", "");
            xmlDoc.AppendChild(xmlElem);
            XmlAttribute xmlns = xmlDoc.CreateAttribute("xmlns:xs");
            xmlns.Value = "http://www.w3.org/2001/XMLSchema";
            xmlElem.Attributes.Append(xmlns);

            //Version
            XmlElement xmlProtocolVer = xmlDoc.CreateElement("EBDVersion");
            xmlProtocolVer.InnerText = "1.0";
            xmlElem.AppendChild(xmlProtocolVer);
            //EBDID
            XmlElement xmlEBDID = xmlDoc.CreateElement("EBDID");
            xmlEBDID.InnerText = strebdid;// strebdid;//
            xmlElem.AppendChild(xmlEBDID);

            //EBDType
            XmlElement xmlEBDType = xmlDoc.CreateElement("EBDType");
            xmlEBDType.InnerText = "EBRPSState";
            xmlElem.AppendChild(xmlEBDType);

            //Source
            XmlElement xmlSRC = xmlDoc.CreateElement("SRC");
            xmlElem.AppendChild(xmlSRC);

            XmlElement xmlSRCAreaCode = xmlDoc.CreateElement("EBRID");
            xmlSRCAreaCode.InnerText = sHBRONO;
            xmlSRC.AppendChild(xmlSRCAreaCode);

            //EBDTime
            XmlElement xmlEBDTime = xmlDoc.CreateElement("EBDTime");

            xmlEBDTime.InnerText = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            xmlElem.AppendChild(xmlEBDTime);


            //RelatedEBD
            //XmlElement xmlRelatedEBD = xmlDoc.CreateElement("RelatedEBD");
            //xmlElem.AppendChild(xmlRelatedEBD);
            //XmlElement xmlReEBDID = xmlDoc.CreateElement("EBDID");
            //xmlReEBDID.InnerText = strebdid;//与EBDID一致就用这个写
            //xmlRelatedEBD.AppendChild(xmlReEBDID);


            XmlElement xmlDeviceInfoReport = xmlDoc.CreateElement("EBRPSState");
            xmlElem.AppendChild(xmlDeviceInfoReport);

            XmlElement xmlDevice = xmlDoc.CreateElement("EBRPS");//Term
            xmlDeviceInfoReport.AppendChild(xmlDevice);

            XmlElement xmlRptTime = xmlDoc.CreateElement("RptTime");
            xmlRptTime.InnerText = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            xmlDevice.AppendChild(xmlRptTime);

            XmlElement xmlDeviceID = xmlDoc.CreateElement("EBRID");
            xmlDeviceID.InnerText = sHBRONO;
            xmlDevice.AppendChild(xmlDeviceID);

            XmlElement StateCode = xmlDoc.CreateElement("StateCode");
            StateCode.InnerText = "1";
            xmlDevice.AppendChild(StateCode);

            XmlElement StateDesc = xmlDoc.CreateElement("StateDesc");
            StateDesc.InnerText = "系统运行正常";
            xmlDevice.AppendChild(StateDesc);

            return xmlDoc;
        }
        
        
        

        public XmlDocument SignResponse(string refbdid, string strIssuerID, string strCertSN, string strSignatureValue)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.AppendChild(xmlDoc.CreateXmlDeclaration("1.0", "utf-8", null));

            XmlElement xmlElem = xmlDoc.CreateElement("Signature");
            xmlDoc.AppendChild(xmlElem);

            //Version
            XmlElement xmlVersion = xmlDoc.CreateElement("Version");
            xmlVersion.InnerText = "1.0";
            xmlElem.AppendChild(xmlVersion);

            //RelatedEBD
            XmlElement xmlRelatedEBD = xmlDoc.CreateElement("RelatedEBD");
            xmlElem.AppendChild(xmlRelatedEBD);

            XmlElement xmlEBDID = xmlDoc.CreateElement("EBDID");
            xmlEBDID.InnerText = refbdid;
            xmlRelatedEBD.AppendChild(xmlEBDID);

            // SignatureCert
            XmlElement xmlSignatureCert = xmlDoc.CreateElement("SignatureCert");
            xmlElem.AppendChild(xmlSignatureCert);

            XmlElement xmlCertType = xmlDoc.CreateElement("CertType");
            xmlCertType.InnerText = "01";
            xmlSignatureCert.AppendChild(xmlCertType);

            XmlElement xmlIssuerID = xmlDoc.CreateElement("IssuerID");
            xmlIssuerID.InnerText = strIssuerID;
            xmlSignatureCert.AppendChild(xmlIssuerID);

            //CertSN
            XmlElement xmlCertSN = xmlDoc.CreateElement("CertSN");
            xmlCertSN.InnerText = strCertSN;
            xmlSignatureCert.AppendChild(xmlCertSN);


            //SignatureTime
            XmlElement xmlSignatureTime = xmlDoc.CreateElement("SignatureTime");

            double D = DateTime.Now.ToOADate();
            Byte[] Bytes = BitConverter.GetBytes(D);
            String S = BitConverter.ToString(Bytes);

            xmlSignatureTime.InnerText = S;
            xmlElem.AppendChild(xmlSignatureTime);
            //DigestAlgorithm
            XmlElement xmlDigestAlgorithm = xmlDoc.CreateElement("DigestAlgorithm");
            xmlDigestAlgorithm.InnerText = "SM3";
            xmlElem.AppendChild(xmlDigestAlgorithm);
            //SignatureAlgorithm
            XmlElement xmlSignatureAlgorithm = xmlDoc.CreateElement("SignatureAlgorithm");
            xmlSignatureAlgorithm.InnerText = "SM2";
            xmlElem.AppendChild(xmlSignatureAlgorithm);

            XmlElement xmlSignatureValue = xmlDoc.CreateElement("SignatureValue");
            xmlSignatureValue.InnerText = strSignatureValue;
            xmlElem.AppendChild(xmlSignatureValue);



            return xmlDoc;
        }

        public XmlDocument ResponeEBMStateRequrest(string EBMID, string strebdid)
        {
            XmlDocument xmlDoc = new XmlDocument();
            #region 标准头部
            //加入XML的声明段落,Save方法不再xml上写出独立属性
            xmlDoc.AppendChild(xmlDoc.CreateXmlDeclaration("1.0", "utf-8", null));
            //加入根元素
            XmlElement xmlElem = xmlDoc.CreateElement("", "EBD", "");
            xmlDoc.AppendChild(xmlElem);
            XmlAttribute xmlns = xmlDoc.CreateAttribute("xmlns:xs");
            xmlns.Value = "http://www.w3.org/2001/XMLSchema";
            xmlElem.Attributes.Append(xmlns);

            //Version
            XmlElement xmlProtocolVer = xmlDoc.CreateElement("EBDVersion");
            xmlProtocolVer.InnerText = "1.0";
            xmlElem.AppendChild(xmlProtocolVer);
            //EBDID
            XmlElement xmlEBDID = xmlDoc.CreateElement("EBDID");
            xmlEBDID.InnerText = strebdid;
            xmlElem.AppendChild(xmlEBDID);

            //EBDType
            XmlElement xmlEBDType = xmlDoc.CreateElement("EBDType");
            xmlEBDType.InnerText = "EBMStateResponse";
            xmlElem.AppendChild(xmlEBDType);

            //Source
            XmlElement xmlSRC = xmlDoc.CreateElement("SRC");

            xmlElem.AppendChild(xmlSRC);

            XmlElement xmlSRCAreaCode = xmlDoc.CreateElement("EBRID");
            xmlSRCAreaCode.InnerText = sHBRONO;//ebdsr.SRC.EBEID;
            xmlSRC.AppendChild(xmlSRCAreaCode);


            //EBDTime
            XmlElement xmlEBDTime = xmlDoc.CreateElement("EBDTime");
            xmlEBDTime.InnerText = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            xmlElem.AppendChild(xmlEBDTime);
            #endregion End

            XmlElement xmlEBMStateResponse = xmlDoc.CreateElement("EBMStateResponse");
            xmlElem.AppendChild(xmlEBMStateResponse);

            XmlElement RptTime = xmlDoc.CreateElement("RptTime");
            RptTime.InnerText = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");//从100000000000开始编号
            xmlEBMStateResponse.AppendChild(RptTime);

            XmlElement xmlEBM = xmlDoc.CreateElement("EBM");
            xmlEBMStateResponse.AppendChild(xmlEBM);

            XmlElement xmlEBMID = xmlDoc.CreateElement("EBMID");
            xmlEBMID.InnerText = EBMID;//从100000000000开始编号
            xmlEBM.AppendChild(xmlEBMID);

            //不加
            //XmlElement xmlRPTTime = xmlDoc.CreateElement("RptTime");
            //xmlRPTTime.InnerText = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            //xmlEBMStateResponse.AppendChild(xmlRPTTime);

            XmlElement xmlBRDState = xmlDoc.CreateElement("BrdStateCode");
            xmlBRDState.InnerText = "2";
            xmlEBMStateResponse.AppendChild(xmlBRDState);

            XmlElement BrdStateDesc = xmlDoc.CreateElement("BrdStateDesc");
            BrdStateDesc.InnerText = "完成";
            xmlEBMStateResponse.AppendChild(BrdStateDesc);

            return xmlDoc;
        }

        public XmlDocument SendEBM(string EBMID, string MusicName, string MusicDescName)
        {
            XmlDocument xmlDoc = new XmlDocument();
            #region 标准头部
            //加入XML的声明段落,Save方法不再xml上写出独立属性
            xmlDoc.AppendChild(xmlDoc.CreateXmlDeclaration("1.0", "utf-8", null));
            //加入根元素
            XmlElement xmlElem = xmlDoc.CreateElement("", "EBD", "");
            xmlDoc.AppendChild(xmlElem);
            XmlAttribute xmlns = xmlDoc.CreateAttribute("xmlns:xs");
            xmlns.Value = "http://www.w3.org/2001/XMLSchema";
            xmlElem.Attributes.Append(xmlns);

            //Version
            XmlElement xmlProtocolVer = xmlDoc.CreateElement("EBDVersion");
            xmlProtocolVer.InnerText = "1.0";
            xmlElem.AppendChild(xmlProtocolVer);
            //EBDID
            XmlElement xmlEBDID = xmlDoc.CreateElement("EBDID");
            xmlEBDID.InnerText = EBMID;
            xmlElem.AppendChild(xmlEBDID);

            //EBDType
            XmlElement xmlEBDType = xmlDoc.CreateElement("EBDType");
            xmlEBDType.InnerText = "EBM";
            xmlElem.AppendChild(xmlEBDType);

            //Source
            XmlElement xmlSRC = xmlDoc.CreateElement("SRC");
            xmlElem.AppendChild(xmlSRC);

            XmlElement xmlSRCAreaCode = xmlDoc.CreateElement("EBRID");
            xmlSRCAreaCode.InnerText = sHBRONO;//ebdsr.SRC.EBEID;
            xmlSRC.AppendChild(xmlSRCAreaCode);


            XmlElement DEST = xmlDoc.CreateElement("DEST");
            xmlElem.AppendChild(DEST);

            XmlElement EBRID = xmlDoc.CreateElement("EBRID");
            EBRID.InnerText = sHBRONO;//ebdsr.SRC.EBEID;
            DEST.AppendChild(EBRID);


            //EBDTime
            XmlElement EBDTime = xmlDoc.CreateElement("EBDTime");
            EBDTime.InnerText = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            xmlElem.AppendChild(EBDTime);
            #endregion End

            XmlElement xmlEBM = xmlDoc.CreateElement("EBM");
            xmlElem.AppendChild(xmlEBM);

            XmlElement EBMVersion = xmlDoc.CreateElement("EBMVersion");
            xmlEBM.AppendChild(EBMVersion);

            XmlElement xmlEBMID = xmlDoc.CreateElement("EBMID");
            xmlEBMID.InnerText = sHBRONO + DateTime.Now.ToString("yyyyMMddHHmm");
            xmlEBM.AppendChild(xmlEBMID);

            XmlElement xmlMesg = xmlDoc.CreateElement("MsgBasicInfo");
            xmlEBM.AppendChild(xmlMesg);

            XmlElement MsgType = xmlDoc.CreateElement("MsgType");
            MsgType.InnerText = "1";
            xmlMesg.AppendChild(MsgType);

            XmlElement SenderName = xmlDoc.CreateElement("SenderName");
            SenderName.InnerText = "江苏省应急平台";
            xmlMesg.AppendChild(SenderName);

            XmlElement SenderCode = xmlDoc.CreateElement("SenderCode");
            SenderCode.InnerText = "010232000000000001";
            xmlMesg.AppendChild(SenderCode);

            XmlElement SentTime = xmlDoc.CreateElement("SentTime");
            SentTime.InnerText = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            xmlMesg.AppendChild(SentTime);

            XmlElement EventType = xmlDoc.CreateElement("EventType");
            EventType.InnerText = "11000";
            xmlMesg.AppendChild(EventType);

            XmlElement Severity = xmlDoc.CreateElement("Severity");
            Severity.InnerText = "4";
            xmlMesg.AppendChild(Severity);

            XmlElement StartTime = xmlDoc.CreateElement("StartTime");
            StartTime.InnerText = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            xmlMesg.AppendChild(StartTime);

            XmlElement EndTime = xmlDoc.CreateElement("EndTime");
            EndTime.InnerText = DateTime.Now.AddMinutes(5).ToString("yyyy-MM-dd HH:mm:ss");
            xmlMesg.AppendChild(EndTime);

            XmlElement LinkTypeSel = xmlDoc.CreateElement("EndTime");
            LinkTypeSel.InnerText = "0";
            xmlMesg.AppendChild(LinkTypeSel);

            XmlElement MsgContent = xmlDoc.CreateElement("MsgContent");
            xmlEBM.AppendChild(MsgContent);

            XmlElement LanguageCode = xmlDoc.CreateElement("LanguageCode");
            LanguageCode.InnerText = "zho";
            MsgContent.AppendChild(LanguageCode);

            XmlElement MsgTitle = xmlDoc.CreateElement("MsgTitle");
            MsgTitle.InnerText = "图南点歌台";
            MsgContent.AppendChild(MsgTitle);

            XmlElement MsgDesc = xmlDoc.CreateElement("MsgDesc");
            MsgDesc.InnerText = MusicName;
            MsgContent.AppendChild(MsgDesc);

            XmlElement AreaCode = xmlDoc.CreateElement("AreaCode");
            AreaCode.InnerText = "320102000000";
            MsgContent.AppendChild(AreaCode);

            XmlElement Auxiliary = xmlDoc.CreateElement("Auxiliary");
            MsgContent.AppendChild(Auxiliary);

            XmlElement AuxiliaryType = xmlDoc.CreateElement("AuxiliaryType");
            AuxiliaryType.InnerText = "2";
            Auxiliary.AppendChild(AuxiliaryType);

            XmlElement AuxiliaryDesc = xmlDoc.CreateElement("AuxiliaryDesc");
            AuxiliaryDesc.InnerText = MusicDescName;
            Auxiliary.AppendChild(AuxiliaryDesc);

            XmlElement Size = xmlDoc.CreateElement("Size");
            Size.InnerText = "0204286";
            Auxiliary.AppendChild(Size);

            XmlElement Digest = xmlDoc.CreateElement("Digest");
            Digest.InnerText = "";
            Auxiliary.AppendChild(Digest);

            return xmlDoc;
        }

    }
}
