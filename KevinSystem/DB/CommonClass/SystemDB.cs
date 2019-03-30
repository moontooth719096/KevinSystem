using Dapper;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Logging;
using NLog;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace KevinSystem.DB.CommonClass
{
    public class SystemDB
    {
            //string publickey = ConfigurationManager.AppSettings[item.packname];//依照packget name取得對應的public key
            private static Logger logger = NLog.LogManager.GetCurrentClassLogger();
            private ILogger<SystemDB> _Ilogger { get; set; }
            public SystemDB(ILogger<SystemDB> logger)
            {
                this._Ilogger = logger;
            }

            #region DB_Action_Single
            static public T DB_Action_Single<T>(string str_conn, string SqlString, object sql_value)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(str_conn))
                    {
                        return conn.QueryFirst<T>(SqlString, sql_value);
                    }
                }
                catch (Exception ex)
                {
                    //logger.Warn(ex.ToString());
                    return default(T);
                }
            }
            #endregion

            #region DB_Action_Multiple
            static public List<T> DB_Action_Multiple<T>(string str_conn, string SqlString, object sql_value)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(str_conn))
                    {
                        return conn.Query<T>(SqlString, sql_value).ToList();
                    }
                }
                catch (Exception ex)
                {
                    //logger.Warn(ex.ToString());
                    return default(List<T>);
                }
            }
            #endregion

            #region DB_SPAction_Single
            static public T DB_SPAction_Single<T>(string str_conn, string sp_name, object sql_value)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(str_conn))
                    {
                        return conn.QuerySingleOrDefault<T>(sp_name, sql_value, commandType: CommandType.StoredProcedure);
                    }
                }
                catch (Exception ex)
                {
                    logger.Warn(ex.ToString());
                    return default(T);
                }
            }
            #endregion

            #region DB_SPAction_Multiple 資料庫連線
            /// <summary>
            /// 資料庫連線
            /// </summary>
            /// <param name="str_conn">連線字串</param>
            /// <param name="sp_name">SP 名稱</param>
            /// <param name="sql_value">輸入的值與類型</param>
            /// 
            static public List<T> DB_SPAction_Multiple<T>(string str_conn, string sp_name, object sql_value)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(str_conn))
                    {
                        return conn.Query<T>(sp_name, sql_value, commandType: CommandType.StoredProcedure).ToList();
                    }
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
            #endregion

            #region DB_Action_Output
            static public void DB_SPAction_Output(string str_conn, string sp_name, ref DynamicParameters parameters)
            {
                Dictionary<string, int> result = new Dictionary<string, int>();
                try
                {
                    using (SqlConnection conn = new SqlConnection(str_conn))
                    {
                        conn.Execute(sp_name, parameters, commandType: CommandType.StoredProcedure);
                    }
                }
                catch (Exception ex)
                {
                    logger.Warn(ex.ToString());
                    //return null;
                }
            }
            #endregion

            #region 新增修改刪除用
            static public void DB_Execute<T>(string str_conn, string SqlString, List<T> sql_value)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(str_conn))
                    {
                        conn.Execute(SqlString, sql_value);
                    }
                }
                catch (Exception ex)
                {
                    logger.Warn(ex.ToString());
                }
            }
            #endregion
    }
}
