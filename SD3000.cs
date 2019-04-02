using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.IO;
using System.Data.SqlClient;

namespace BaiwangExport
{
    public class SD3000
    {
        static string connectionFilePath = Path.Combine(System.Environment.CurrentDirectory, "sdsettings.dat");

        public static DataTable GetConnectionTable()
        {
            DataTable table = null;
            if (File.Exists(connectionFilePath))
            {
                byte[] by = DataTableConvertBytes.GetBytesFromFile(connectionFilePath);
                table = DataTableConvertBytes.ConvertBytesToDataTable(by);
            }
            else
            {
                table = InitConnectionDataTable();
            }

            return table;
        }

        public static bool SaveConnection(DataTable dt)
        {
            bool success = false;
            byte[] by = DataTableConvertBytes.ConvertDataTableToBytes(dt);
            DataTableConvertBytes.SaveToFile(by, connectionFilePath);
            return success;
        }

        /// <summary>
        /// 获取速达系统数据库
        /// </summary>
        /// <param name="connectionString"></param>
        /// <returns></returns>
        public static DataTable GetSDSysDb(string connectionString)
        {
            string sql = "Select name  FROM Master.dbo.SysDatabases "
                + " where name like '%SDAccset'";
            DBHelper dbHelper = new DBHelper(connectionString);

            DataTable table= dbHelper.GetDataTable(sql);
            if (table == null)
                table = GetInitailSysDb();
            return table;
        }
        public static DataTable GetInitailSysDb()
        {
            DataTable table = new DataTable();
            DataColumn column = new DataColumn("name", typeof(string));
            table.Columns.Add(column);
            DataRow row = table.NewRow();
            row["name"] = "";
            table.Rows.Add(row);
            return table;
        }

        /// <summary>
        /// 获取速达帐套数据库
        /// </summary>
        /// <param name="connectionString"></param>
        /// <returns></returns>
        public static DataTable GetAccounts(string connectionString)
        {
            DBHelper dbHelper = new DBHelper(connectionString);
            string sql = "select accsetname,corpname from dbo.accset";
            DataTable table = null;
            try
            {
                table = dbHelper.GetDataTable(sql);
            }
            catch(Exception ex)
            {
                throw ex;
            }

            return table;
        }

        public static DataTable GetInitailAccounts()
        {
            DataTable table = new DataTable();
            DataColumn column = new DataColumn("accsetname", typeof(string));
            table.Columns.Add(column);
            column = new DataColumn("corpname", typeof(string));
            table.Columns.Add(column);
            DataRow row = table.NewRow();
            row["accsetname"] = "";
            row["corpname"] = "";
            table.Rows.Add(row);
            return table;
        }

        public static DataTable InitConnectionDataTable()
        {
            DataTable table = new DataTable();

            DataColumn column = new DataColumn("server", typeof(string));
            column.Caption = "服务器";
            column.DefaultValue = "127.0.0.1";
            table.Columns.Add(column);

            column = new DataColumn("dbUser", typeof(string));
            column.Caption = "数据库账号";
            column.DefaultValue = "sa";
            table.Columns.Add(column);

            column = new DataColumn("password", typeof(string));
            column.Caption = "数据库密码";
            column.DefaultValue = "Qq123456";
            table.Columns.Add(column);

            column = new DataColumn("accset", typeof(string));
            column.Caption = "帐套数据库";
            column.DefaultValue = "SD11211N_SDAccset";
            table.Columns.Add(column);

            column = new DataColumn("integratedSecurity", typeof(bool));
            column.Caption = "集成Windows认证";
            column.DefaultValue = 0;
            table.Columns.Add(column);
            

            return table;
        }

        /// <summary>
        /// 生成速达凭证
        /// </summary>
        /// <param name="connSString"></param>
        /// <param name="credence">凭证主表</param>
        /// <param name="credType">凭证字ID</param>
        /// <param name="credDate">凭证日期</param>
        /// <param name="billMaker">制单人</param>
        /// <param name="subId_D">借方科目</param>
        /// <param name="subId_Tax">税收科目</param>
        /// <param name="subId_C">贷方科目</param>
        /// <param name="moneyId">货币</param>
        /// <returns></returns>
        public static bool CreateCredence(string connSString,DataTable credence 
            ,int credType, DateTime credDate,string billMaker
            ,int subId_D,int subId_Tax, int subId_C,int moneyId)
        {
            bool success = false;

            if (string.IsNullOrWhiteSpace(connSString))
                throw new ArgumentNullException("数据库连接字符串不能为空！");
            if (credence == null && credence.Rows.Count==0)
                throw new ArgumentNullException("凭证主表不能为空");
            //if (credItem == null && credItem.Rows.Count == 0)
            //    throw new ArgumentNullException("凭证细表不能为空！");

            string fStartDate = Utility.GetFirstDayOfMonth(credDate).ToString("yyyy-MM-dd");
            string fEndDate = Utility.GetLastDayOfMonth(credDate).ToString("yyyy-MM-dd");

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("declare @CredID varchar(30),@CredNo int,@CredCode int");
            string sqlCredID = "select @CredID=isnull(max(CredID), 100000000000)+1 from Credence where credid like '____________'"
                              + " set @CredID=isnull(@CredID,100000000000) ";
            string sqlCredNo = string.Format("SELECT  @CredNo=Max(CredNo)+1 from Credence "
                          + " WHERE creddate >= '{0}' and creddate <= '{1}'"
                         , fStartDate, fEndDate);
            sqlCredNo = sqlCredNo + " set @CredNo=isnull(@CredNo,1) ";
            string sqlCredCode = string.Format("SELECT  @CredCode=Max(CredCode)+1 from Credence "
              + " WHERE credtypeid={0} creddate >= '{1}' and creddate <= '{2}'"
              , credType.ToString(), fStartDate, fEndDate);
            sqlCredCode = sqlCredCode + " set @CredCode=isnull(@CredCode,1) ";

            string sqlCredence = "insert into Credence(credid,shopid,credtype,rptid,credcode"
                    + ",credno,creddate,billnumber,billmaker"
                    + ",billcheck,billpost,checkflag,postflag"
                    +",relevantbillid,credtypeid,updatetime)"
                    + "select credid=@CredID,shopid=0,credtype="+ credType.ToString().ToString() + ", rptid=20"
                    + ",credcode=@CredCode,credno=@CredNo,creddate='"+ credDate.ToString("yyyy-MM-dd") + "', billnumber={0}"
                    + ",billmaker='"+ billMaker+"', billcheck='',billpost='',checkflag='F'"
                    + ",postflag='F',relevantbillid=1,credtypeid=0,updatetime=getdate()";

            string sqlcredItem = "INSERT INTO dbo.CredItem (credid,fenluno,rate,rawdebit"
                +",rawcredit,debit,credit,moneyid"
                +",subid,brief)"
                + " select credid=@CredID,fenluno={0},rate=1,rawdebit=0"
                + ",rawcredit=0,debit={1},credit={2},moneyid={3}"
                + ",subid={4},brief='{5}')";

            for (int i = 0; i < credence.Rows.Count; i++)
            {
                sb.AppendLine(sqlCredID);
                sb.AppendLine(sqlCredNo);
                int fbillNumber = 0;
                int.TryParse(credence.Rows[i]["billnumber"].ToString(), out fbillNumber);
                sb.AppendFormat(sqlCredence, fbillNumber);

                decimal debit = 0;
                decimal.TryParse(credence.Rows[i]["debit"].ToString(), out debit);

                decimal credit = 0;
                decimal.TryParse(credence.Rows[i]["credit"].ToString(), out credit);
                decimal tax = 0;
                decimal.TryParse(credence.Rows[i]["tax"].ToString(), out tax);
                string brief = credence.Rows[i]["debit"].ToString();
                int fenluno = 1;
                sb.AppendFormat(sqlcredItem, fenluno.ToString(), debit.ToString(), "0", moneyId.ToString(), subId_D.ToString()
                    , brief);
                if (subId_Tax > 0)
                {
                    fenluno++;
                    sb.AppendFormat(sqlcredItem, fenluno.ToString(), tax.ToString(), "0", moneyId.ToString(), subId_Tax.ToString()
                        , brief);
                }
                fenluno++;
                sb.AppendFormat(sqlcredItem, fenluno.ToString(), "0", credit.ToString(), moneyId.ToString(), subId_C.ToString()
                    , brief);
            }

            return success;
        }

        /// <summary>
        /// 获取科目
        /// </summary>
        /// <param name="connectionString"></param>
        /// <returns></returns>
        public static DataTable GetSubjects(string connectionString)
        {
            DBHelper dbHelper = new DBHelper(connectionString);
            string sql = " Select  subid,subcode,name,fullname,displayname=subcode+fullname  from Subject "
             + " where detailflag = 'T' and((specialcode <> '113' and specialcode <> '115' and specialcode <> '203' and specialcode <> '204') or specialcode is null) "  
             + "order by subcode ";
            return dbHelper.GetDataTable(sql);
        }

        /// <summary>
        /// 获取凭证字
        /// </summary>
        /// <param name="connectionString"></param>
        /// <returns></returns>
        public static DataTable GetCredTypes(string connectionString)
        {
            DBHelper dbHelper = new DBHelper(connectionString);
            string sql = " Select id,typeid,name from CredType ";
            return dbHelper.GetDataTable(sql);
        }

        /// <summary>
        /// 获取用户
        /// </summary>
        /// <param name="connectionString"></param>
        /// <returns></returns>
        public static DataTable GetOperators(string connectionString)
        {
            DBHelper dbHelper = new DBHelper(connectionString);
            string sql = " select opid, opcode, opname, pass, opgroup, empid from operator ";
            return dbHelper.GetDataTable(sql);
        }
        
       }
}
