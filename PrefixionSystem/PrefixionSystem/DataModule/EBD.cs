using System;
using System.Xml.Serialization;

namespace PrefixionSystem
{
    [Serializable]
    [XmlRoot(ElementName = "EBD", Namespace = "http://www.w3.org/2001/XMLSchema")]
    public class EBD
    {
        [XmlAttribute]
        public string xmlns;

        public string EBDVersion;

        public string EBDID;

        public string EBDType;

        public SRC SRC;

        public DEST DEST;

        public string EBDTime;

        public RelatedEBD RealtedEBD;

        //以下可变的子序列化参数     [XmlRoot("EBD")]
        #region EBM类型的数据包数据

        public EBM EBM;

        #endregion End EBM

        public EBMStateRequest EBMStateRequest;

        public OMDRequest OMDRequest;

        public EBMStreamPortRequest EBMStreamPortRequest;

     //   public Signature Signature;
    }


    [Serializable]
    public class SRC
    {
        //public string AreaCode;

       // public string EBEType;

       // public string EBEName;

        public string EBRID;
    }

    [Serializable]
    public class DEST
    {
        public string EBRID;
    }

    [Serializable]
    public class RelatedEBD
    {
        public string EBDID;
    }

    [Serializable]
    public class EBMStateRequest
    {
        public EBM EBM;
    }

    [Serializable]
    public class OMDRequest
    {
        public string OMDType;
        public Params Params;
    }
    [Serializable]
    public class EBMStreamPortRequest
    {
        public RelatedEBM RelatedEBM;
    }
    [Serializable]
    public class Params
    {
        public string RptStartTime;
        public string RptEndTime;
        public string RptType;
    }
}
