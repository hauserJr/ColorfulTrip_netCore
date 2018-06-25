using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CT.DB
{
    public class DBConfig
    {
        //Update DB Models
        //Scaffold-DbContext "Data Source={DBConnection};Initial Catalog={DBName};Integrated Security=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models
        private string _DevelopDBConn = @"Data Source=.\SQLEXPRESS;Initial Catalog=CTCore;Integrated Security=True";
        private string _DebugDBConn = @"";
        private string _ReleaseDBConn = @"";

        /// <summary>
        /// 開發機(R&D本地)的Db Connection
        /// R&D localhost Db Connection
        /// </summary>
        public string DevelopDBConn
        {
            get
            {
                return _DevelopDBConn;
            }
            private set
            {
                value = this._DevelopDBConn;
            }
        }

        /// <summary>
        /// 測試機的Db Connection
        /// Internal DB Connection
        /// </summary>
        public string DebugDBConn
        {
            get
            {
                return _DebugDBConn;
            }
            private set
            {
                value = this._DebugDBConn;
            }
        }

        /// <summary>
        /// 正式版的Db Connection
        /// Internal DB Connection
        /// </summary>
        public string ReleaseDBConn
        {
            get
            {
                return _ReleaseDBConn;
            }
            private set
            {
                value = this._ReleaseDBConn;
            }
        }
    }
}