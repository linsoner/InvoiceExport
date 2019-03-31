using System;
using System.Collections.Generic;
 
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace BaiwangExport
{
    /// <summary>
    /// 数据库操作类，执行各种数据库操作
    /// </summary>
    public class DBHelper
    {
        protected SqlConnection conn;
        protected SqlCommand cmd;
        protected SqlDataReader reader;
        protected SqlDataAdapter adapter;
        protected string connectionString;
        //public static DBHelper Instance = null;

        /// <summary>
        ///获取或设置数据库连接字符串
        /// </summary>
        /// <value>数据库连接字符串</value>
        public string ConnectionString
        {
            get { return this.connectionString; }
            set { this.connectionString = value; }
        }

        /// <summary>
        ///  <see cref="DBHelper"/> 类构造函数。
        /// </summary>
        /// <param name="connectionString">数据库连接字符串</param>
        public DBHelper(string connectionString)
        {
            this.connectionString = connectionString;
            //this.conn = this.GetConnection(this.connectionString);
        }

        //static DBHelper()
        //{
           // DBHelper.Instance = new DBHelper();
       // }
 
        /// <summary>
        /// 获取SqlConnection对象
        /// </summary>
        /// <returns>SqlConnection对象</returns>
        public SqlConnection GetConnection()
        {
            if (conn != null)
                return this.conn;
            return this.conn = new SqlConnection(connectionString);
        }
 
        /// <summary>
        /// 使用指定的数据库连接字符串获取SqlConnection对象
        /// </summary>
        /// <param name="_connStr">数据库连接字符串</param>
        /// <returns>SqlConnection对象</returns>
        public SqlConnection GetConnection(string _connStr)
        {
            if (this.conn != null)
                this.conn.ConnectionString = _connStr; 
            else
                this.conn = new SqlConnection(_connStr);
            return this.conn;
        }
 
        /// <summary>
        /// 使用指定的Sql语句创建SqlCommand对象
        /// </summary>
        /// <param name="sqlStr">Sql语句</param>
        /// <returns>SqlCommand对象</returns>
        private SqlCommand GetCommand(string sqlStr)
        {
            if (this.conn == null)
                this.conn = GetConnection();
            if (this.cmd == null)
                this.cmd = this.GetCommand(sqlStr, CommandType.Text, null);
            else
            {
                this.cmd.CommandText = sqlStr;
                this.cmd.CommandType = CommandType.Text;
                this.cmd.Parameters.Clear();
            }
            return this.cmd;
        }
 
        /// <summary>
        /// 使用指定的Sql语句,CommandType,SqlParameter数组创建SqlCommand对象
        /// </summary>
        /// <param name="sqlStr">Sql语句</param>
        /// <param name="type">命令类型</param>
        /// <param name="paras">SqlParameter数组</param>
        /// <returns>SqlCommand对象</returns>
        public SqlCommand GetCommand(string sqlStr, CommandType type, SqlParameter[] paras)
        {
            if (conn == null)
                this.conn = this.GetConnection();
            if (cmd == null)
                this.cmd = conn.CreateCommand();
            this.cmd.CommandType = type;
            this.cmd.CommandText = sqlStr;
            this.cmd.Parameters.Clear();
            if (paras != null)
                this.cmd.Parameters.AddRange(paras);
            return this.cmd;
        }
 
        /// <summary>
        /// 执行Sql语句返回受影响的行数
        /// </summary>
        /// <param name="sqlStr">Sql语句</param>
        /// <returns>受影响的行数,失败则返回-1</returns>
        public int ExecuteNonQuery(string sqlStr)
        {
            int line = -1;
            try { line = this.ExecuteNonQuery(sqlStr,CommandType.Text,null); }
            catch (SqlException e) { throw new Exception(e.Message); }
            return line;
        }
 
        /// <summary>
        /// 使用指定的Sql语句,CommandType,SqlParameter数组执行Sql语句,返回受影响的行数
        /// </summary>
        /// <param name="sqlStr">Sql语句</param>
        /// <param name="type">命令类型</param>
        /// <param name="paras">SqlParameter数组</param>
        /// <returns>受影响的行数</returns>
        public int ExecuteNonQuery(string sqlStr, CommandType type, SqlParameter[] paras)
        {
            int line = -1;
            CheckArgs(sqlStr);
            if (this.cmd == null)
                GetCommand(sqlStr, type, paras);
            this.cmd.Parameters.Clear();
            this.cmd.CommandText = sqlStr;
            this.cmd.CommandType = type;
            if(paras != null)
                this.cmd.Parameters.AddRange(paras);
            try { Open(); line = this.cmd.ExecuteNonQuery(); }
            catch (SqlException e) { throw new Exception(e.Message); }
            return line;
        }
 
        /// <summary>
        /// 使用指定Sql语句获取dataTable
        /// </summary>
        /// <param name="sqlStr">Sql语句</param>
        /// <returns>DataTable对象</returns>
        public DataTable GetDataTable(string sqlStr)
        {
            CheckArgs(sqlStr);
            if (this.conn == null)
                this.conn = GetConnection();
            this.adapter = new SqlDataAdapter(sqlStr, this.conn);
            DataTable table = new DataTable();
            try { adapter.Fill(table); }
            catch (SqlException e) { throw new Exception(e.Message); }
            finally { this.adapter.Dispose(); }
            return table;
        }
 
        /// <summary>
        /// 使用指定的Sql语句获取SqlDataReader
        /// </summary>
        /// <param name="sqlStr">sql语句</param>
        /// <returns>SqlDataReader对象</returns>
        public SqlDataReader GetSqlDataReader(string sqlStr)
        {
            CheckArgs(sqlStr);
            if (cmd == null)
                GetCommand(sqlStr);
            if(reader != null)
                reader.Dispose();
            try { Open(); this.reader = this.cmd.ExecuteReader(); }
            catch (SqlException e) { throw new Exception(e.Message); }
            return this.reader;
        }
 
        /// <summary>
        /// 使用事务执行多条Sql语句
        /// </summary>
        /// <param name="sqlCommands">sql语句数组</param>
        /// <returns>全部成功则返回true否则返回false</returns>
        public bool ExecuteSqls(List<string> sqlCommands)
        {
            if (sqlCommands == null)
                throw new ArgumentNullException();
            if (sqlCommands.Count == 0)
                throw new ArgumentOutOfRangeException();
            if(this.cmd == null)
                GetCommand(null);
            SqlTransaction tran = null;
            try {
                Open();
                tran = this.conn.BeginTransaction();
                this.cmd.Transaction = tran;
                foreach (string sql in sqlCommands)
                {
                    if (ExecuteNonQuery(sql) == 0) 
                    { tran.Rollback(); return false; }
                }
            }
            catch { if (tran != null) tran.Rollback(); throw; }
            tran.Commit();
            return true;
        }
 
        public virtual void Dispose()
        {
            if (this.reader != null)
            { reader.Dispose(); this.reader = null; }
            if (this.cmd != null)
            { this.cmd.Dispose(); this.cmd = null; }
            if (this.conn != null)
            { this.conn.Dispose(); conn = null; }
        }

        public void Open()
        {
            try {
                if (this.conn.State != ConnectionState.Open)
                    conn.Open();
            }
            catch (SqlException e) { throw new Exception(e.Message); }
        }
 
        /// <summary>
        /// 关闭连接
        /// </summary>
        public void Close()
        {
            if (this.conn != null && this.conn.State == ConnectionState.Open)
                this.conn.Close();
        }
 
        /// <summary>
        /// 检查Sql语句是否合法
        /// </summary>
        /// <param name="sqlStr">Sql语句</param>
        protected virtual void CheckArgs(string sqlStr)
        {
            if (sqlStr == null)
                throw new ArgumentNullException();
            if (sqlStr.Length == 0)
                throw new ArgumentOutOfRangeException();
        }

        /// <summary>
        /// 修改<see cref="DBHelper"/>的数据库链接里的数据库名称,返回新的数据库连接字符串
        /// </summary>
        /// <param name="newDatabase">新数据库名称</param>
        /// <returns>新的数据库连接字符串</returns>
        public string ChangeDatabase(string newDatabase)
        {        
            string dbServer = "";
            string dbUser = "";
            string dbPassword = "";

            string[] s = this.connectionString.Split(new char[1] { ';' });
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i].Split(new char[1] { '=' })[0].Trim().ToUpper().Equals("SERVER"))
                    dbServer = s[i].Split(new char[1] { '=' })[1];
                else if (s[i].Split(new char[1] { '=' })[0].Trim().ToUpper().Equals("UID"))
                    dbUser = s[i].Split(new char[1] { '=' })[1];
                else if (s[i].Split(new char[1] { '=' })[0].Trim().ToUpper().Equals("PWD"))
                    dbPassword = s[i].Split(new char[1] { '=' })[1];
            }

            return "server=" + dbServer + ";" + "database=" + newDatabase + ";" +
                    "uid=" + dbUser + ";" + "pwd=" + dbPassword;
        }

        public static string GetConnectionString(string server, string dbName, string dbUser, string dbPassword, bool IntegratedSecurity)
        {
            if (string.IsNullOrWhiteSpace(dbName))
                throw new ArgumentNullException("数据库名称不能为空！");
            if (string.IsNullOrWhiteSpace(server))
                throw new ArgumentNullException("数据库服务器不能为空！");
            if (string.IsNullOrWhiteSpace(dbUser))
                throw new ArgumentNullException("数据库用户名不能为空！");
            if (string.IsNullOrWhiteSpace(dbPassword))
                throw new ArgumentNullException("数据库用户密码不能为空！");

            //Data Source=.;Initial Catalog=数据库;Integrated Security=True
            if (IntegratedSecurity)
                return string.Format(@"Data Source={0};Initial Catalog={1};Integrated Security=True"
               , server, dbName);
            else
                return string.Format(@"Data Source={0};Initial Catalog={1};User ID={2}; password = {3}"
                   , server, dbName, dbUser, dbPassword);
        }
    }
}
