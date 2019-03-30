using KevinSystem.DB.CommonClass;
using KevinSystem.Models.SystemModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KevinSystem.DB
{
    public class kevinSystemDB: DBConnection
    {
        public kevinSystemDB()
        {
            base.DbName = "kevinSystemDB";
            Connection(DbName);
        }

        #region 取得155品項
        public MainFunctionModel MainFunction_Get()
        {
            StringBuilder SqlString = new StringBuilder(@"SELECT top 1 [MainFunctionID]
                                                            ,[MainFunctionName]
                                                            FROM [kevinSystemDB].[dbo].[MainFunctionData]");

            object param = new { };
            return SystemDB.DB_Action_Single<MainFunctionModel>(str_conn, SqlString.ToString(), param);
        }
        #endregion
    }
}
