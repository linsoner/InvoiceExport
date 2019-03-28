using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.IO;

namespace BaiwangExport
{
    public class Company
    {
        static string filePath = Path.Combine(System.Environment.CurrentDirectory, "settings.dat");
        public static DataTable GetData()
        {
            DataTable table = null;
            if (File.Exists(filePath))
            {
                byte[] by = DataTableConvertBytes.GetBytesFromFile(filePath);
                table = DataTableConvertBytes.ConvertBytesToDataTable(by);
            }
            else
            {
                table = InitDataTable();
            }

            return table;
        }

        public static bool SaveData(DataTable dt)
        {
            bool success = false;
            byte[] by = DataTableConvertBytes.ConvertDataTableToBytes(dt);
            DataTableConvertBytes.SaveToFile(by, filePath);
            return success;
        }

        public static DataTable InitDataTable()
        {
            DataTable table = new DataTable();

            DataColumn column = new DataColumn("company", typeof(string)); //公司简称
            table.Columns.Add(column);

            column = new DataColumn("NSRSBH", typeof(string));//纳税人识别号
            table.Columns.Add(column);

            column = new DataColumn("SKPBH", typeof(string));//税控盘编号
            table.Columns.Add(column);

            column = new DataColumn("SKPPwd", typeof(string));//税控盘口令
            table.Columns.Add(column);

            column = new DataColumn("CertPwd", typeof(string));//税务数字证书密码
            table.Columns.Add(column);

            column = new DataColumn("Hardware", typeof(string));//税控盘类型
            table.Columns.Add(column);

            return table;
        }
    }
}
