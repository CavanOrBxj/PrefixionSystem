using System.Threading;
using System.Collections.Generic;
using System.Data;
using PrefixionSystem.DataModule;

namespace PrefixionSystem
{
    public class SingletonInfo
    {
        private static SingletonInfo _singleton;
        

        public int SequenceCodes;//顺序码

        /// <summary>
        /// 连接的数据库
        /// </summary>
        public MySQLDBHelper DataBase;

        public List<RecordDetail> RecordDetailList;

        private SingletonInfo()                                                                 
        {
            SequenceCodes = 0;
            DataBase = new MySQLDBHelper();
            RecordDetailList = new List<RecordDetail>();
        }
        public static SingletonInfo GetInstance()
        {
            if (_singleton == null)
            {
                Interlocked.CompareExchange(ref _singleton, new SingletonInfo(), null);
            }
            return _singleton;
        }
    }
}