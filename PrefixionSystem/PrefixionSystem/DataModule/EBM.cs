using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace PrefixionSystem
{
    [Serializable]
    public class EBM
    {
        public string EBMVersion; //
        public string EBEID; //

        public string EBMID;

        public RelatedEBM RelatedEBM;//

        public string TestType;  //
     //   public string MsgType;

     //   public string ExerciseType;

     //   public string Sender;

     //   public string SentTime;

        public string StartTime;

        public string EndTime;

        public string ProcessMethod;//

        public MsgBasicInfo MsgBasicInfo;//

        public MsgContent MsgContent;//

        //public string MsgDesc;

        //public string EventType;

        //public string Severity;

        //public string Language;

        //public string CharSet;

        //public Auxiliary Auxiliary;

        //public Coverage Coverage;

        public Dispatch Dispatch;
    }

    [Serializable]
    public class RelatedEBM  //
    {
        public string EBMID;
        
    }
    [Serializable]
    public class MsgBasicInfo
    {
        public string MsgType;
        public string SenderName;
        public string SenderCode;
        public string SentTime;
        public string EventType;
        public string Severity;

        public string StartTime;
        public string EndTime;
    }

    [Serializable]
    public class MsgContent
    {
        public string LanguageCode;

       // public string CharSet;

        public string MsgTitle;

        public string MsgDesc;

        public string AreaCode;

        //public string ProgramNum;

        public Auxiliary Auxiliary;
    }

    [Serializable]
    public class Auxiliary
    {
        public string AuxiliaryType;

        public string AuxiliaryDesc;

        public string Size;

        public string Digest;

    }

    [Serializable]
    public class Coverage
    {
       [XmlElement]
       public List<Area> Area;
    }

    [Serializable]
    public class Area
    {
        public string AreaName;
        public string AreaCode;
    }

    [Serializable]
    public class Dispatch
    {
        public string LanguageCode;

        public EBEAS EBEAS;

        public EBEBS EBEBS;
        //public DataReturn DataReturn;

        //[XmlElement]
        //public List<StationDispatch> StationDispatch;

    }

    //[Serializable]
    //public class DataReturn
    //{
    //    public string URL;

    //    public string Tel;
    //}

    //[Serializable]
    //public class StationDispatch
    //{
    //    public EBEAS EBEAS;

    //    [XmlElement]
    //    public List<EBEBS> EBEBS;

    //}

    [Serializable]
    public class EBEAS
    {
        public string EBEID;//应急广播消息适配器ID
    }

    [Serializable]
    public class EBEBS
    {
        public string BrdSysType;

        public string BrdSysInfo;

    }

}
