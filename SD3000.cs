using System;
using System.Data;
using System.IO;
using System.Text;

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

            DataRow row = table.NewRow();
            table.Rows.Add(row);

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
        public static int CreateCredence(string connSString,DataTable credence 
            ,int credType, DateTime credDate,string billMaker
            ,int subId_Tax, int subId_C, int subId_D, int moneyId)
        {
            int successCount = 0;

            if (string.IsNullOrWhiteSpace(connSString))
                throw new ArgumentNullException("数据库连接字符串不能为空！");
            if (credence == null && credence.Rows.Count==0)
                throw new ArgumentNullException("凭证主表不能为空");

            string fStartDate = Utility.GetFirstDayOfMonth(credDate).ToString("yyyy-MM-dd");
            string fEndDate = Utility.GetLastDayOfMonth(credDate).ToString("yyyy-MM-dd");

            StringBuilder sb = new StringBuilder();
            string sqlDeclare = "declare @CredID varchar(30),@CredNo int,@CredCode int,@subID_D int";
            string sqlCredID = "select @CredID=convert(bigint,isnull(max(CredID), 100000000000))+1 from Credence where credid like '____________'"
                              + " if @CredID is null set @CredID=100000000000 ";
            string sqlCredNo = string.Format("SELECT  @CredNo=Max(CredNo)+1 from Credence "
                          + " WHERE creddate >= '{0}' and creddate <= '{1}' and credtypeid=1"
                         , fStartDate, fEndDate);
            sqlCredNo = sqlCredNo + " set @CredNo=isnull(@CredNo,1) ";
            string sqlCredCode = string.Format("SELECT  @CredCode=Max(CredCode)+1 from Credence "
              + " WHERE credtypeid={0} and creddate >= '{1}' and creddate <= '{2}'"
              , credType.ToString(), fStartDate, fEndDate);
            sqlCredCode = sqlCredCode + " set @CredCode=isnull(@CredCode,1) ";

            string sqlCredence = "insert into Credence(credid,shopid,credtype,rptid,credcode"
                    + ",credno,creddate,billnumber,billmaker"
                    + ",billcheck,billpost,checkflag,postflag"
                    +",relevantbillid,credtypeid,updatetime)"
                    + "select credid=@CredID,shopid=0,credtype=0, rptid=20"
                    + ",credcode=@CredCode,credno=@CredNo,creddate='"+ credDate.ToString("yyyy-MM-dd") + "', billnumber={0}"
                    + ",billmaker='"+billMaker+"', billcheck='',billpost='',checkflag='F'"
                    + ",postflag='F',relevantbillid=0,credtypeid=" + credType.ToString() + ",updatetime=getdate()";

            string sqlcredItem = "insert into dbo.CredItem (credid,fenluno,rate,rawdebit"
                + ",rawcredit,debit,credit,moneyid "
                +",subid,brief) "
                + " select credid=@CredID,fenluno={0},rate=1,rawdebit=0"
                + ",rawcredit=0,debit={1},credit={2},moneyid={3}"
                + ",subid={4},brief='{5}'";


            DBHelper dbHelper = new DBHelper(connSString);
            for (int i = 0; i < credence.Rows.Count; i++)
            {
                sb.Length = 0;
                string fSelected = credence.Rows[i]["fSelected"].ToString();
                if (fSelected.Equals("0"))
                    continue;

                
                decimal debit = 0; //含税金额
                decimal.TryParse(credence.Rows[i]["debit"].ToString(), out debit);
                if (debit == 0)
                    continue;

                sb.AppendLine(sqlDeclare);
                sb.AppendLine(sqlCredID);
                sb.AppendLine(sqlCredNo);
                sb.AppendLine(sqlCredCode);
                int fbillNumber = 0; //附件数
                int.TryParse(credence.Rows[i]["billnumber"].ToString(), out fbillNumber);
                sb.AppendFormat(sqlCredence, fbillNumber);
                //应收账款科目
                if(subId_D ==0)
                    int.TryParse(credence.Rows[i]["subid"].ToString(), out subId_D);

                decimal tax = 0; //税额
                decimal.TryParse(credence.Rows[i]["credit"].ToString(), out tax);
                decimal credit = debit- tax;
                //decimal.TryParse(credence.Rows[i]["credit"].ToString(), out credit);
                string brief = credence.Rows[i]["brief"].ToString();
                if (string.IsNullOrWhiteSpace(brief))
                    brief = "应收账款";
                int fenluno = 1;
                sb.AppendFormat(sqlcredItem, fenluno.ToString(), debit.ToString(), "0", moneyId.ToString(), subId_D.ToString()
                    , brief);
                if (subId_Tax > 0 && tax!= 0)
                {
                    fenluno++;
                    sb.AppendFormat(sqlcredItem, fenluno.ToString(), tax.ToString(), "0", moneyId.ToString(), subId_Tax.ToString()
                        , brief);
                }
                fenluno++;
                sb.AppendFormat(sqlcredItem, fenluno.ToString(), "0", credit.ToString(), moneyId.ToString(), subId_C.ToString()
                    , brief);

                try
                {
                    dbHelper.ExecuteNonQuery(sb.ToString());
                    successCount++;
                    //credence.Rows[i]["msg"] = "成功";
                }
                catch (Exception ex)
                {
                    //credence.Rows[i]["msg"] = "失败：" + ex.Message;
                }
            }

            if (dbHelper != null)
                dbHelper.Close();

            return successCount;
        }

        /// <summary>
        /// 获取科目
        /// </summary>
        /// <param name="connectionString"></param>
        /// <returns></returns>
        public static DataTable GetSubjects(string connectionString)
        {
            DBHelper dbHelper = new DBHelper(connectionString);
            string sql = " Select  subid,subcode,name,fullname,displayname=fullname  from Subject "
             + " where detailflag = 'T' and((specialcode <> '113' and specialcode <> '115' and specialcode <> '203' and specialcode <> '204') or specialcode is null) "  
             + "order by subcode ";
            return dbHelper.GetDataTable(sql);
        }

        /// <summary>
        /// 获取科目
        /// </summary>
        /// <param name="connectionString"></param>
        /// <returns></returns>
        public static DataTable GetSubjectByName(string connectionString,string name)
        {
            DBHelper dbHelper = new DBHelper(connectionString);
            string sql = " Select  subid,subcode,name,fullname,displayname=fullname  from Subject "
             + " where detailflag = 'T' and((specialcode <> '113' and specialcode <> '115' and specialcode <> '203' and specialcode <> '204') or specialcode is null) "
             + " and name='" + name + "'"
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
        
        public static DataTable GetEmptyCredenceItem()
        {
            DataTable table = new DataTable("CredenceItem");
            DataColumn column = new DataColumn("credid",typeof(string));
            column.Caption = "凭证ID";
            table.Columns.Add(column);
            column = new DataColumn("fenluno", typeof(int));
            column.Caption = "分录号";
            table.Columns.Add(column);
            column = new DataColumn("rate", typeof(decimal));
            column.Caption = "汇率";
            column.DefaultValue = 1m;
            table.Columns.Add(column);
            column = new DataColumn("rawdebit", typeof(decimal));
            column.DefaultValue = 0m;
            column.Caption = "借方汇率";
            table.Columns.Add(column);
            column = new DataColumn("rawcredit", typeof(decimal));
            column.Caption = "贷方汇率";
            table.Columns.Add(column);
            column = new DataColumn("debit", typeof(int));
            column.DefaultValue = 0m;
            column.Caption = "借方金额";
            table.Columns.Add(column);
            column = new DataColumn("credit", typeof(int));
            column.DefaultValue = 0m;
            column.Caption = "贷方金额";
            table.Columns.Add(column);
            column = new DataColumn("moneyid", typeof(int));
            column.DefaultValue = 0;
            column.Caption = "货币ID";
            table.Columns.Add(column);
            column = new DataColumn("subid", typeof(string));
            column.Caption = "科目ID";
            table.Columns.Add(column);
            //column = new DataColumn("subid_d", typeof(string));
            //column.Caption = "借方科目ID";
            //table.Columns.Add(column);
            column = new DataColumn("subID_D_Name", typeof(string));
            column.Caption = "借方科目名称";
            table.Columns.Add(column);
            column = new DataColumn("brief", typeof(string));
            column.DefaultValue = "应收账款";
            column.Caption = "摘要";
            table.Columns.Add(column);
            column = new DataColumn("vendor", typeof(string));
            column.DefaultValue = "";
            column.Caption = "购货单位";
            table.Columns.Add(column);
            column = new DataColumn("billNumber", typeof(int));
            column.DefaultValue = 0;
            column.Caption = "附件数";
            table.Columns.Add(column);
            column = new DataColumn("fSelected", typeof(int));
            column.DefaultValue = 1;
            column.Caption = "选择";
            table.Columns.Add(column);

            return table;
        }

        public static DataTable GetEmptyCredence()
        {
            DataTable table = new DataTable("Credence");
            DataColumn column = new DataColumn("credid", typeof(string));
            column.Caption = "凭证ID";
            table.Columns.Add(column);
            column = new DataColumn("shopid", typeof(int));
            column.Caption = "分支机构ID";
            table.Columns.Add(column);
            column = new DataColumn("credtype", typeof(int));
            column.Caption = "凭证类型";
            table.Columns.Add(column);
            column = new DataColumn("rptid", typeof(int));
            column.Caption = "打印样式ID";
            table.Columns.Add(column);
            column = new DataColumn("credcode", typeof(string));
            column.Caption = "凭证号";
            table.Columns.Add(column);
            column = new DataColumn("credno", typeof(string));
            column.Caption = "凭证序号";
            table.Columns.Add(column);
            column = new DataColumn("creddate", typeof(string));
            column.Caption = "编制日期";
            table.Columns.Add(column);
            column = new DataColumn("billnumber", typeof(string));
            column.Caption = "附件数";
            table.Columns.Add(column);
            column = new DataColumn("billmaker", typeof(string));
            column.Caption = "制单人";
            table.Columns.Add(column);
            column = new DataColumn("billcheck", typeof(string));
            column.Caption = "审核人";
            table.Columns.Add(column);
            column = new DataColumn("billpost", typeof(string));
            column.Caption = "登帐人";
            table.Columns.Add(column);
            column = new DataColumn("checkflag", typeof(string));
            column.Caption = "审核标志";
            table.Columns.Add(column);
            column = new DataColumn("postflag", typeof(string));
            column.Caption = "登帐标志";
            table.Columns.Add(column);
            column = new DataColumn("relevantbillid", typeof(string));
            column.Caption = "relevantbillid";
            table.Columns.Add(column);
            column = new DataColumn("credtypeid", typeof(string));
            column.Caption = "credtypeid";
            table.Columns.Add(column);

            return table;
        }
    }
}
