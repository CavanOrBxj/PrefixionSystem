using MySql.Data.MySqlClient;
using PrefixionSystem.DataModule;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
//using System.Data.SqlClient;

namespace PrefixionSystem
{
    /// <summary>
    /// 数据库处理
    /// </summary>
    public class MySQLDBHelper
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(MySQLDBHelper));

        private MySqlConnection conn;
        private const int TIMEOUT = 120;

        public MySQLDBHelper()
        {
            conn = new MySqlConnection();
        }

        /// <summary>
        /// 获取数据库连接字符串
        /// </summary>
        /// <returns></returns>
        public void SetConnectString(string server, string user, string pass, string dataBase)
        {
            string sql = string.Format("Server={0};Database={1};Uid={2};Pwd={3};charset=utf8;port={4};Compress=true;", server, dataBase, user, pass,3306);

            conn.ConnectionString = sql;
        }

        /// <summary>
        /// 检查是否能连接上数据库
        /// </summary>
        /// <returns></returns>
        public bool OpenTest()
        {
            try
            {
                conn.Open();
            }
            catch
            {
                return false;
            }
            conn.Close();
            return true;
        }

        public bool CheckUser(string username,string password,string usercode)
        {
            bool flag = false;
            string sql = "select  *  from Users where USER_DETAIL='" + username + "' and USER_PWD='"+ password+ "' and USER_CODE='" + usercode + "'";
            try
            {
                DataTable dt = new DataTable();
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                cmd.CommandText = sql;
                MySqlDataAdapter sqlAdapter = new MySqlDataAdapter(cmd);
                sqlAdapter.Fill(dt);
                if (dt.Rows.Count==1)
                {
                    flag = true;
                }
            }
            catch (Exception ex)
            {
               
            }
            finally { conn.Close(); }

            return flag;
        }

        /// <summary>
        /// 批量更新设备在线状态    需修改语法
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        //public bool UpdateSrvEquipmentStatusBatch(DataTable dt)
        //{
        //    if (dt == null || dt.Rows.Count == 0) return false;

        //    MySqlDataAdapter sd = null;
        //    DataTable dataTable = new DataTable();
        //    int reslut = -1;
        //    try
        //    {
        //        if (conn.State != ConnectionState.Open)
        //            conn.Open();
        //       // sd = new MySqlDataAdapter("SELECT SRV_ID,SRV_RMT_TIME,SRV_RMT_STATUS,SRV_PHYSICAL_CODE FROM Srv WITH(NOLOCK)", conn);
        //        sd = new MySqlDataAdapter("SELECT SRV_ID,SRV_RMT_TIME,SRV_RMT_STATUS,SRV_PHYSICAL_CODE FROM Srv", conn);
        //        MySqlCommandBuilder scb = new MySqlCommandBuilder(sd);
        //        sd.UpdateCommand = scb.GetUpdateCommand();
        //        sd.UpdateCommand = new MySqlCommand("update Srv set SRV_RMT_TIME=@SRV_RMT_TIME, SRV_RMT_STATUS=@SRV_RMT_STATUS where SRV_PHYSICAL_CODE=@SRV_PHYSICAL_CODE", conn);
        //        sd.UpdateCommand.Parameters.Add("@SRV_RMT_TIME", MySqlDbType.DateTime, 6, "SRV_RMT_TIME");
        //        sd.UpdateCommand.Parameters.Add("@SRV_RMT_STATUS", MySqlDbType.VarChar, 255, "SRV_RMT_STATUS");
        //        sd.UpdateCommand.Parameters.Add("@SRV_PHYSICAL_CODE", MySqlDbType.VarChar, 255, "SRV_PHYSICAL_CODE");
        //        sd.UpdateCommand.UpdatedRowSource = UpdateRowSource.None;


        //        sd.UpdateBatchSize = 0;
        //        sd.Fill(dataTable);


        //        if (dataTable.Rows.Count>0)//添加于20180116  SRV表中的数据来源？
        //        {
        //           for (int i = 0; i < dt.Rows.Count; i++)
        //        {
        //            dataTable.Rows[i].BeginEdit();
        //            var rows = dataTable.Select("SRV_PHYSICAL_CODE='" + dt.Rows[i]["srv_physical_code"] + "'");
        //            if (rows != null && rows.Length > 0)
        //            {
        //                rows[0]["SRV_RMT_TIME"] = DateTime.Parse(dt.Rows[i]["srv_time"].ToString());
        //                rows[0]["SRV_RMT_STATUS"] = "在线";
        //            }
        //            dataTable.Rows[i].EndEdit();
        //        }
        //        reslut = sd.Update(dataTable);
        //        }
             
        //    }
        //    catch (Exception ex)
        //    {
        //        log.Error("批量更新设备在线状态发生异常", ex);
        //    }
        //    finally
        //    {
        //        dataTable.Clear();
        //        sd.Dispose();
        //        dataTable.Dispose();
        //        conn.Close();
        //    }
        //    return reslut != -1;
        //}


        //public void BulkEquipmentDetail(DataTable dt)
        //{
        //    if (dt == null || dt.Rows.Count == 0) return;

        //    try
        //    {
        //        if (conn.State != ConnectionState.Open)
        //            conn.Open();
        //        foreach (DataRow row in dt.Rows)
        //        {
        //            try
        //            {

        //                MySqlCommand mySqlCommandPro = new MySqlCommand("UporInsertSrv_Status", conn);
        //                mySqlCommandPro.CommandType = CommandType.StoredProcedure;//设置调用的类型为存储过程             

        //                MySqlParameter sqlParme;
        //                //参数1               
        //                sqlParme = mySqlCommandPro.Parameters.AddWithValue("@PCODE", "");
        //                sqlParme.Direction = ParameterDirection.Input;
        //                sqlParme.Value = row["srv_physical_code"].ToString();
        //                //参数2        
        //                sqlParme = mySqlCommandPro.Parameters.AddWithValue("@Powersupplystatus", "");
        //                sqlParme.Direction = ParameterDirection.Input;
        //                sqlParme.Value = row["powersupplystatus"].ToString();
        //                //参数2        
        //                sqlParme = mySqlCommandPro.Parameters.AddWithValue("@Powervoltage", "");
        //                sqlParme.Direction = ParameterDirection.Input;
        //                sqlParme.Value = row["powervoltage"].ToString();
        //                //参数3     
        //                //sqlParme = mySqlCommandPro.Parameters.AddWithValue("@textTime", SqlDbType.NText);
        //                sqlParme = mySqlCommandPro.Parameters.AddWithValue("@Controlfrequency", "");
        //                sqlParme.Direction = ParameterDirection.Input;
        //                sqlParme.Value = row["controlfrequency"].ToString();
        //                //参数4     
        //                //sqlParme = mySqlCommandPro.Parameters.AddWithValue("@textTime", SqlDbType.NText);
        //                sqlParme = mySqlCommandPro.Parameters.AddWithValue("@Cflevel", "");
        //                sqlParme.Direction = ParameterDirection.Input;
        //                sqlParme.Value = row["cflevel"].ToString();
        //                //参数5     
        //                //sqlParme = mySqlCommandPro.Parameters.AddWithValue("@textTime", SqlDbType.NText);
        //                sqlParme = mySqlCommandPro.Parameters.AddWithValue("@Audiofrequency", "");
        //                sqlParme.Direction = ParameterDirection.Input;
        //                sqlParme.Value = row["audiofrequency"].ToString();
        //                //参数6     
        //                //sqlParme = mySqlCommandPro.Parameters.AddWithValue("@textTime", SqlDbType.NText);
        //                sqlParme = mySqlCommandPro.Parameters.AddWithValue("@Aflevel", "");
        //                sqlParme.Direction = ParameterDirection.Input;
        //                sqlParme.Value = row["aflevel"].ToString();
        //                //参数7     
        //                //sqlParme = mySqlCommandPro.Parameters.AddWithValue("@textTime", SqlDbType.NText);
        //                sqlParme = mySqlCommandPro.Parameters.AddWithValue("@Devlogicid", "");
        //                sqlParme.Direction = ParameterDirection.Input;
        //                sqlParme.Value = row["devlogicid"].ToString();
        //                //参数8     
        //                //sqlParme = mySqlCommandPro.Parameters.AddWithValue("@textTime", SqlDbType.NText);
        //                sqlParme = mySqlCommandPro.Parameters.AddWithValue("@Devphyid", "");
        //                sqlParme.Direction = ParameterDirection.Input;
        //                sqlParme.Value = row["devphyid"].ToString();
        //                //参数9     
        //                //sqlParme = mySqlCommandPro.Parameters.AddWithValue("@textTime", SqlDbType.NText);
        //                sqlParme = mySqlCommandPro.Parameters.AddWithValue("@Srv_time", "");
        //                sqlParme.Direction = ParameterDirection.Input;
        //                sqlParme.Value = row["srv_time"].ToString();


        //                mySqlCommandPro.ExecuteNonQuery();//执行存储过程 
        //            }
        //            catch (Exception ex)
        //            {
        //                log.Error("更新设备信息异常", ex);
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        log.Error("更新设备信息数据库异常", ex);
        //    }
        //    finally { conn.Close(); }
        //}



        //public void BulkNewEquipmentDetail(DataTable dt)
        //{
        //    if (dt == null || dt.Rows.Count == 0) return;

        //    try
        //    {
        //        if (conn.State != ConnectionState.Open)
        //            conn.Open();
        //        foreach (DataRow row in dt.Rows)
        //        {
        //            try
        //            {
        //                MySqlCommand mySqlCommandPro = new MySqlCommand("UporInsertSrv_StatusGxNew", conn);
        //                mySqlCommandPro.CommandType = CommandType.StoredProcedure;//设置调用的类型为存储过程             

        //                MySqlParameter sqlParme;
        //                //参数1               
        //                sqlParme = mySqlCommandPro.Parameters.AddWithValue("@PCODE", "");
        //                sqlParme.Direction = ParameterDirection.Input;
        //                sqlParme.Value = row["srv_physical_code"].ToString();
        //                //参数2               
        //                sqlParme = mySqlCommandPro.Parameters.AddWithValue("@Broadcaststate", "");
        //                sqlParme.Direction = ParameterDirection.Input;
        //                sqlParme.Value = row["broadcaststate"].ToString();
        //                //参数3               
        //                sqlParme = mySqlCommandPro.Parameters.AddWithValue("@Voltage220", "");
        //                sqlParme.Direction = ParameterDirection.Input;
        //                sqlParme.Value = row["voltage220"].ToString();
        //                //参数4               
        //                sqlParme = mySqlCommandPro.Parameters.AddWithValue("@Fm_frelist1", "");
        //                sqlParme.Direction = ParameterDirection.Input;
        //                sqlParme.Value = row["fm_frelist1"].ToString();
        //                //参数5               
        //                sqlParme = mySqlCommandPro.Parameters.AddWithValue("@Fm_signalstrength1", "");
        //                sqlParme.Direction = ParameterDirection.Input;
        //                sqlParme.Value = row["fm_signalstrength1"].ToString();
        //                //参数6               
        //                sqlParme = mySqlCommandPro.Parameters.AddWithValue("@Fm_frelist2", "");
        //                sqlParme.Direction = ParameterDirection.Input;
        //                sqlParme.Value = row["fm_frelist2"].ToString();
        //                //参数7               
        //                sqlParme = mySqlCommandPro.Parameters.AddWithValue("@Fm_signalstrength2", "");
        //                sqlParme.Direction = ParameterDirection.Input;
        //                sqlParme.Value = row["fm_signalstrength2"].ToString();
        //                //参数8               
        //                sqlParme = mySqlCommandPro.Parameters.AddWithValue("@Logicaladdress", "");
        //                sqlParme.Direction = ParameterDirection.Input;
        //                sqlParme.Value = row["logicaladdress"].ToString();
        //                //参数9               
        //                sqlParme = mySqlCommandPro.Parameters.AddWithValue("@Physicaladdress", "");
        //                sqlParme.Direction = ParameterDirection.Input;
        //                sqlParme.Value = row["physicaladdress"].ToString();
        //                //参数10               
        //                sqlParme = mySqlCommandPro.Parameters.AddWithValue("@Srv_time", "");
        //                sqlParme.Direction = ParameterDirection.Input;
        //                sqlParme.Value = row["srv_time"].ToString();
        //                //参数11               
        //                sqlParme = mySqlCommandPro.Parameters.AddWithValue("@Playtype", "");
        //                sqlParme.Direction = ParameterDirection.Input;
        //                sqlParme.Value = row["playtype"].ToString();
        //                //参数12               
        //                sqlParme = mySqlCommandPro.Parameters.AddWithValue("@Versions", "");
        //                sqlParme.Direction = ParameterDirection.Input;
        //                sqlParme.Value = row["versions"].ToString();
        //                //参数13               
        //                sqlParme = mySqlCommandPro.Parameters.AddWithValue("@Digitaltv_radiofrequencymode", "");
        //                sqlParme.Direction = ParameterDirection.Input;
        //                sqlParme.Value = row["digitaltv_radiofrequencymode"].ToString();
        //                //参数14               
        //                sqlParme = mySqlCommandPro.Parameters.AddWithValue("@Digitaltv_radiofrequencyfre", "");
        //                sqlParme.Direction = ParameterDirection.Input;
        //                sqlParme.Value = row["digitaltv_radiofrequencyfre"].ToString();
        //                //参数15               
        //                sqlParme = mySqlCommandPro.Parameters.AddWithValue("@Broadcast_volume", "");
        //                sqlParme.Direction = ParameterDirection.Input;
        //                sqlParme.Value = row["broadcast_volume"].ToString();
        //                //参数16               
        //                sqlParme = mySqlCommandPro.Parameters.AddWithValue("@Currentmode_signalquality", "");
        //                sqlParme.Direction = ParameterDirection.Input;
        //                sqlParme.Value = row["currentmode_signalquality"].ToString();
        //                //参数17               
        //                sqlParme = mySqlCommandPro.Parameters.AddWithValue("@Currentmode_signalstrength", "");
        //                sqlParme.Direction = ParameterDirection.Input;
        //                sqlParme.Value = row["currentmode_signalstrength"].ToString();
        //                //参数18               
        //                sqlParme = mySqlCommandPro.Parameters.AddWithValue("@Remotecontrolcenter_ip", "");
        //                sqlParme.Direction = ParameterDirection.Input;
        //                sqlParme.Value = row["remotecontrolcenter_ip"].ToString();
        //                //参数19               
        //                sqlParme = mySqlCommandPro.Parameters.AddWithValue("@Remotecontrolcenter_port", "");
        //                sqlParme.Direction = ParameterDirection.Input;
        //                sqlParme.Value = row["remotecontrolcenter_port"].ToString();
        //                //参数20               
        //                sqlParme = mySqlCommandPro.Parameters.AddWithValue("@Audioserver_ip", "");
        //                sqlParme.Direction = ParameterDirection.Input;
        //                sqlParme.Value = row["audioserver_ip"].ToString();
        //                //参数21               
        //                sqlParme = mySqlCommandPro.Parameters.AddWithValue("@Audioserver_port", "");
        //                sqlParme.Direction = ParameterDirection.Input;
        //                sqlParme.Value = row["audioserver_port"].ToString();
        //                //参数22               
        //                sqlParme = mySqlCommandPro.Parameters.AddWithValue("@Callway", "");
        //                sqlParme.Direction = ParameterDirection.Input;
        //                sqlParme.Value = row["callway"].ToString();
        //                //参数23               
        //                sqlParme = mySqlCommandPro.Parameters.AddWithValue("@Filename", "");
        //                sqlParme.Direction = ParameterDirection.Input;
        //                sqlParme.Value = row["filename"].ToString();
        //                //参数24               
        //                sqlParme = mySqlCommandPro.Parameters.AddWithValue("@Recording_duration", "");
        //                sqlParme.Direction = ParameterDirection.Input;
        //                sqlParme.Value = row["recording_duration"].ToString();
        //                //参数25               
        //                sqlParme = mySqlCommandPro.Parameters.AddWithValue("@Packs_totalnumber", "");
        //                sqlParme.Direction = ParameterDirection.Input;
        //                sqlParme.Value = row["packs_totalnumber"].ToString();
        //                //参数26               
        //                sqlParme = mySqlCommandPro.Parameters.AddWithValue("@Rebackfiletype", "");
        //                sqlParme.Direction = ParameterDirection.Input;
        //                sqlParme.Value = row["rebackfiletype"].ToString();
        //                //参数27               
        //                sqlParme = mySqlCommandPro.Parameters.AddWithValue("@Packstartindex", "");
        //                sqlParme.Direction = ParameterDirection.Input;
        //                sqlParme.Value = row["packstartindex"].ToString();
        //                //参数28               
        //                sqlParme = mySqlCommandPro.Parameters.AddWithValue("@Lastpacksnumber", "");
        //                sqlParme.Direction = ParameterDirection.Input;
        //                sqlParme.Value = row["lastpacksnumber"].ToString();
        //                //参数29               
        //                sqlParme = mySqlCommandPro.Parameters.AddWithValue("@Terminaltype", "");
        //                sqlParme.Direction = ParameterDirection.Input;
        //                sqlParme.Value = row["terminaltype"].ToString();
        //                //参数30               
        //                sqlParme = mySqlCommandPro.Parameters.AddWithValue("@Longitude", "");
        //                sqlParme.Direction = ParameterDirection.Input;
        //                sqlParme.Value = row["longitude"].ToString();
        //                //参数31               
        //                sqlParme = mySqlCommandPro.Parameters.AddWithValue("@Latitude", "");
        //                sqlParme.Direction = ParameterDirection.Input;
        //                sqlParme.Value = row["latitude"].ToString();
        //                //参数32               
        //                sqlParme = mySqlCommandPro.Parameters.AddWithValue("@Rebackmode", "");
        //                sqlParme.Direction = ParameterDirection.Input;
        //                sqlParme.Value = row["rebackmode"].ToString();
        //                //参数33               
        //                sqlParme = mySqlCommandPro.Parameters.AddWithValue("@Networkmode", "");
        //                sqlParme.Direction = ParameterDirection.Input;
        //                sqlParme.Value = row["networkmode"].ToString();
        //                //参数34               
        //                sqlParme = mySqlCommandPro.Parameters.AddWithValue("@Voltage24", "");
        //                sqlParme.Direction = ParameterDirection.Input;
        //                sqlParme.Value = row["voltage24"].ToString();
        //                //参数35               
        //                sqlParme = mySqlCommandPro.Parameters.AddWithValue("@Voltage12", "");
        //                sqlParme.Direction = ParameterDirection.Input;
        //                sqlParme.Value = row["voltage12"].ToString();
        //                //参数36               
        //                sqlParme = mySqlCommandPro.Parameters.AddWithValue("@Amplifierelectric_current", "");
        //                sqlParme.Direction = ParameterDirection.Input;
        //                sqlParme.Value = row["amplifierelectric_current"].ToString();
        //                //参数37               
        //                sqlParme = mySqlCommandPro.Parameters.AddWithValue("@Localhost", "");
        //                sqlParme.Direction = ParameterDirection.Input;
        //                sqlParme.Value = row["localhost"].ToString();
        //                //参数38               
        //                sqlParme = mySqlCommandPro.Parameters.AddWithValue("@Subnetmask", "");
        //                sqlParme.Direction = ParameterDirection.Input;
        //                sqlParme.Value = row["subnetmask"].ToString();
        //                //参数39               
        //                sqlParme = mySqlCommandPro.Parameters.AddWithValue("@Defaultgateway", "");
        //                sqlParme.Direction = ParameterDirection.Input;
        //                sqlParme.Value = row["defaultgateway"].ToString();
        //                //参数40               
        //                sqlParme = mySqlCommandPro.Parameters.AddWithValue("@Manufacturer_information", "");
        //                sqlParme.Direction = ParameterDirection.Input;
        //                sqlParme.Value = row["manufacturer_information"].ToString();

        //                mySqlCommandPro.ExecuteNonQuery();//执行存储过程 
        //            }
        //            catch (Exception ex)
        //            {
        //                log.Error("更新设备信息异常", ex);
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        log.Error("更新设备信息时数据库异常", ex);
        //    }
        //    finally { conn.Close(); }

        //}

        /// <summary>
        /// 更新或插入录音记录
        /// </summary>
        /// <param name = "detail" ></ param >
        public int InsertRecorde(RecordDetail detail)
        {
            if (detail == null) return -1;
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                string sqlUpdate = "";

                detail.SourceTarPath = detail.SourceTarPath.Replace(@"\", @"\\");
                detail.SavePath = detail.SavePath.Replace(@"\", @"\\");

                    sqlUpdate = string.Format("insert into RecordList " +
                        "(SourceTar,SourceTarPath,MediumType,MsgStartTime,MsgEndTime,AreaCode,SavePath,Severity,EventType,TextContent,DealFlag) " +
                        "values('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}','{9}',{10})",
                         detail.SourceTar,detail.SourceTarPath, detail.MediumType, detail.MsgStartTime,
                        detail.MsgEndTime, detail.AreaCode, detail.SavePath,detail.Severity,detail.EventType,detail.TextContent,detail.DealFlag);
                
                cmd.CommandText = sqlUpdate;
                if (cmd.ExecuteNonQuery() > 0)
                {
                    string sql = "select max(RecordId) from RecordList";
                    cmd.CommandText = sql;
                    var rowCount = cmd.ExecuteScalar();
                    return Convert.ToInt32(rowCount.ToString()); 
                }
                return -1;

            }
            catch (Exception ex)
            {
                log.Error("更新或插入录音记录异常", ex);
                return -1;
            }
            finally { conn.Close(); }
        }

        public int UpdateRecorde(RecordDetail detail)
        {
            if (detail == null) return -1;
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                string sqlUpdate = "";

                sqlUpdate = string.Format("update  RecordList set " +
                    "DealFlag={0} where RecordId={1}",detail.DealFlag,detail.RecordId);

                cmd.CommandText = sqlUpdate;
                if (cmd.ExecuteNonQuery() > 0)
                {
                    string sql = "select max(RecordId) from RecordList";
                    cmd.CommandText = sql;
                    var rowCount = cmd.ExecuteScalar();
                    return Convert.ToInt32(rowCount.ToString());
                }
                return -1;

            }
            catch (Exception ex)
            {
                log.Error("更新或插入录音记录异常", ex);
                return -1;
            }
            finally { conn.Close(); }
        }

        /// <summary>
        /// 查询sql
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        public bool FromSql(string sql, out DataTable dt)
        {
            bool insertFlag = false;
            dt = new DataTable();

            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = sql;

            try
            {
                conn.Open();
                MySqlDataAdapter sqlAdapter = new MySqlDataAdapter(cmd);
                sqlAdapter.Fill(dt);
                insertFlag = dt.Rows.Count > 0;
            }
            catch (Exception e)
            {
                log.Error("更新状态信息异常", e);
            }
            finally
            {
                conn.Close();
            }
            return insertFlag;
        }

        public List<int> AeraCode2DeviceID(List<int> AeraID)
        {
            List<int> DeviceIdList = new List<int>();
            List<string> ORGCODEAList = new List<string>();
            DataTable dt = new DataTable();

            foreach (var aeraID in AeraID)
            {
                string sql = "select ORG_CODEA from organization where ORG_ID='" + aeraID + "';";
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = sql;
                string ORG_CODEA = "";

                try
                {
                    conn.Open();
                    MySqlDataAdapter sqlAdapter = new MySqlDataAdapter(cmd);
                    sqlAdapter.Fill(dt);
                    ORG_CODEA = dt.Rows[0]["ORG_CODEA"].ToString().Trim();
                    ORGCODEAList.Add(ORG_CODEA);
                    dt.Clear();
                }
                catch (Exception e)
                {
                    log.Error("查询区域码异常", e);
                }
                finally
                {
                    conn.Close();
                }
            }



            foreach (var orgID in ORGCODEAList)
            {
                string orgcodea=orgID.ToString();
                string sql = "select devid from srv_statusgxnew where orgCodea like'%" + orgcodea + "%';";
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = sql;
                string ORG_CODEA = "";

                try
                {
                    conn.Open();
                    MySqlDataAdapter sqlAdapter = new MySqlDataAdapter(cmd);
                    sqlAdapter.Fill(dt);
                    foreach (DataRow item in dt.Rows)
                    {
                        DeviceIdList.Add(Convert.ToInt32(item["devid"].ToString()));
                    }
                    dt.Clear();
                }
                catch (Exception e)
                {
                    log.Error("查询区域码异常", e);
                }
                finally
                {
                    conn.Close();
                }
            }
            return DeviceIdList;
        
        }


        public List<string> PhysicalSearch(List<int> DeviceID)
        {
            List<string> PhysicalList = new List<string>();
            DataTable dt = new DataTable();

            foreach (var devID in DeviceID)
            {
                string sql = "select srv_physical_code from Srv_StatusGxNew where devid='" + devID + "';";
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = sql;
                string physicalcode = "";

                try
                {
                    conn.Open();
                    MySqlDataAdapter sqlAdapter = new MySqlDataAdapter(cmd);
                    sqlAdapter.Fill(dt);
                    physicalcode = dt.Rows[0][0].ToString().Trim();

                    PhysicalList.Add(physicalcode);
                    dt.Clear();
                }
                catch (Exception e)
                {
                    log.Error("查询物理码异常", e);
                }
                finally
                {
                    conn.Close();
                }
            }

            return PhysicalList;

        }
        public void Test()
        {
            try
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                
                    try
                    {

                        MySqlCommand mySqlCommandPro = new MySqlCommand("AddUser", conn);
                        mySqlCommandPro.CommandType = CommandType.StoredProcedure;//设置调用的类型为存储过程             

                        MySqlParameter sqlParme;
                        //参数1               
                        sqlParme = mySqlCommandPro.Parameters.AddWithValue("@_name", "");
                        sqlParme.Direction = ParameterDirection.Input;
                        sqlParme.Value = "超级管理员";
                        //参数2        
                        sqlParme = mySqlCommandPro.Parameters.AddWithValue("@_USER_DETAIL", "");
                        sqlParme.Direction = ParameterDirection.Input;
                        sqlParme.Value ="TestUser";
                        //参数2        
                        sqlParme = mySqlCommandPro.Parameters.AddWithValue("@_USER_PWD", "");
                        sqlParme.Direction = ParameterDirection.Input;
                        sqlParme.Value = "123";
                  

                        mySqlCommandPro.ExecuteNonQuery();//执行存储过程 
                    }
                    catch (Exception ex)
                    {
                        log.Error("更新设备信息异常", ex);
                    }
                
            }
            catch (Exception ex)
            {
                log.Error("更新设备信息数据库异常", ex);
            }
            finally { conn.Close(); }
        }

    }
}
