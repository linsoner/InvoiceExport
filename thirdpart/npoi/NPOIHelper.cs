using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Runtime.InteropServices;

using NPOI;
using NPOI.HPSF.Extractor;
using NPOI.SS.UserModel;
using NPOI.HSSF.UserModel;
using NPOI.XSSF.UserModel;

/// <summary>
/// NPOI组件
/// </summary>
namespace cl.thirdpart.npoi
{
    class NPOIHelper
    {
        /// <summary>
        /// 将Excel文件中的数据读出到DataTable中
        /// </summary>
        /// <param name="aFile">文件地址</param>
        /// <returns></returns>
        public static DataTable ExcelToDataTable(string aFile)
        {
            string aLastName = aFile.Substring(aFile.LastIndexOf(".") + 1, (aFile.Length - aFile.LastIndexOf(".") - 1)).ToLower();
            if (aLastName.Equals("xls"))
            {
                return ExcelToTableForXLS(aFile);
            }
            else if (aLastName.Equals("xlsx"))
            {
                return ExcelToTableForXLSX(aFile);
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 将Excel2003文件中的数据读出到DataTable中(xls)
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public static DataTable ExcelToTableForXLS(string file)
        {
            DataTable dt = new DataTable();
            using (FileStream fs = new FileStream(file, FileMode.Open, FileAccess.Read))
            {
                HSSFWorkbook hssfworkbook = new HSSFWorkbook(fs);
                ISheet sheet = hssfworkbook.GetSheetAt(0);

                //表头
                IRow header = sheet.GetRow(sheet.FirstRowNum);
                List<int> columns = new List<int>();
                for (int i = 0; i < header.LastCellNum; i++)
                {
                    object obj = GetValueTypeForXLS(header.GetCell(i) as HSSFCell);
                    if (obj == null || obj.ToString() == string.Empty)
                    {
                        dt.Columns.Add(new DataColumn("Columns" + i.ToString()));
                        //continue;
                    }
                    else
                        dt.Columns.Add(new DataColumn(obj.ToString()));
                    columns.Add(i);
                }
                //数据
                for (int i = sheet.FirstRowNum + 1; i <= sheet.LastRowNum; i++)
                {
                    DataRow dr = dt.NewRow();
                    bool hasValue = false;
                    foreach (int j in columns)
                    {
                        dr[j] = GetValueTypeForXLS(sheet.GetRow(i).GetCell(j) as HSSFCell);
                        if (dr[j] != null && dr[j].ToString() != string.Empty)
                        {
                            hasValue = true;
                        }
                    }
                    if (hasValue)
                    {
                        dt.Rows.Add(dr);
                    }
                }
            }
            return dt;
        }

        /// <summary>
        /// 将DataTable数据导出到Excel2003文件中(xls)
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="file"></param>
        public static void DataTableToExcel2003(DataTable dt, string file)
        {
            HSSFWorkbook hssfWorkbook = new HSSFWorkbook();
            ISheet sheet = hssfWorkbook.CreateSheet("kk");

            //表头
            IRow row = sheet.CreateRow(0);
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                ICell cell = row.CreateCell(i);
                cell.SetCellValue(dt.Columns[i].ColumnName);
            }

            //数据
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                IRow row1 = sheet.CreateRow(i + 1);
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    ICell cell = row1.CreateCell(j);
                    cell.SetCellValue(dt.Rows[i][j].ToString());
                }
            }

            //转为字节数组
            MemoryStream stream = new MemoryStream();
            hssfWorkbook.Write(stream);
            var buf = stream.ToArray();

            try
            {
                //保存为Excel文件
                using (FileStream fs = new FileStream(file, FileMode.Create, FileAccess.Write))
                {
                    fs.Write(buf, 0, buf.Length);
                    fs.Flush();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message + "\r\nNPOIHelper.DataTableToExcel2003");
            }
        }

        /// <summary>
        /// 将DataTable数据导出到Excel2007文件中(xlsx)
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="file"></param>
        public static void DataTableToExcel2007(DataTable dt, string file)
        {
            try
            {
            XSSFWorkbook xssfworkbook = new XSSFWorkbook();
            ISheet sheet = xssfworkbook.CreateSheet("kk");

            //表头
            IRow row = sheet.CreateRow(0);
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                ICell cell = row.CreateCell(i);
                cell.SetCellValue(dt.Columns[i].ColumnName);
            }

            //数据
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                IRow row1 = sheet.CreateRow(i + 1);
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    ICell cell = row1.CreateCell(j);
                    cell.SetCellValue(dt.Rows[i][j].ToString());
                }
            }

            //转为字节数组
            MemoryStream stream = new MemoryStream();
            xssfworkbook.Write(stream);
            var buf = stream.ToArray();

            
                //保存为Excel文件
                using (FileStream fs = new FileStream(file, FileMode.Create, FileAccess.Write))
                {
                    fs.Write(buf, 0, buf.Length);
                    fs.Flush();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message + "\r\nNPOIHelper.DataTableToExcel2007");
            }
        }

        /// <summary>
        /// 获取单元格类型(xls)
        /// </summary>
        /// <param name="cell"></param>
        /// <returns></returns>
        private static object GetValueTypeForXLS(HSSFCell cell)
        {
            if (cell == null)
                return null;
            switch (cell.CellType)
            {
                case CellType.Blank: //BLANK:
                    return null;
                case CellType.Boolean: //BOOLEAN:
                    return cell.BooleanCellValue;
                case CellType.Numeric: //NUMERIC:
                    return cell.NumericCellValue;
                case CellType.String: //STRING:
                    return cell.StringCellValue;
                case CellType.Error: //ERROR:
                    return cell.ErrorCellValue;
                case CellType.Formula: //FORMULA:
                default:
                    return "=" + cell.CellFormula;
            }
        }

        /// <summary>
        /// 将Excel2007文件中的数据读出到DataTable中(xlsx)
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public static DataTable ExcelToTableForXLSX(string file)
        {
            DataTable dt = new DataTable();
            using (FileStream fs = new FileStream(file, FileMode.Open, FileAccess.Read))
            {
                XSSFWorkbook xssfworkbook = new XSSFWorkbook(fs);
                ISheet sheet = xssfworkbook.GetSheetAt(0);

                //表头
                IRow header = sheet.GetRow(sheet.FirstRowNum);
                List<int> columns = new List<int>();
                for (int i = 0; i < header.LastCellNum; i++)
                {
                    object obj = GetValueTypeForXLSX(header.GetCell(i) as XSSFCell);
                    if (obj == null || obj.ToString() == string.Empty)
                    {
                        dt.Columns.Add(new DataColumn("Columns" + i.ToString()));
                        //continue;
                    }
                    else
                        dt.Columns.Add(new DataColumn(obj.ToString()));
                    columns.Add(i);
                }
                //数据
                for (int i = sheet.FirstRowNum + 1; i <= sheet.LastRowNum; i++)
                {
                    DataRow dr = dt.NewRow();
                    bool hasValue = false;
                    foreach (int j in columns)
                    {
                        dr[j] = GetValueTypeForXLSX(sheet.GetRow(i).GetCell(j) as XSSFCell);
                        if (dr[j] != null && dr[j].ToString() != string.Empty)
                        {
                            hasValue = true;
                        }
                    }
                    if (hasValue)
                    {
                        dt.Rows.Add(dr);
                    }
                }
            }
            return dt;
        }

        /// <summary>
        /// 获取单元格类型(xlsx)
        /// </summary>
        /// <param name="cell"></param>
        /// <returns></returns>
        private static object GetValueTypeForXLSX(XSSFCell cell)
        {
            if (cell == null)
                return null;
            switch (cell.CellType)
            {
                case CellType.Blank:
                    return null;
                case CellType.Boolean:
                    return cell.BooleanCellValue;
                case CellType.Numeric: 
                    return cell.NumericCellValue;
                case CellType.String: 
                    return cell.StringCellValue;
                case CellType.Error: 
                    return cell.ErrorCellValue;
                case CellType.Formula: 
                default:
                    return "=" + cell.CellFormula;
            }
        }

        /// <summary>
        /// NPOI DataGridView 导出 EXCEL
        /// </summary>
        /// <param name="fileName"> 默认保存文件名</param>
        /// <param name="dgv">要导出的DataGridView</param>
        /// <param name="fontName">字体名称</param>
        /// <param name="fontSize">字体大小</param>
        public static void DataGridViewToExcel(string fileName, DataGridView dgv, string fontName, short fontSize)
        {
            //检测是否有数据
            if (dgv.SelectedRows.Count == 0) return;
            //创建主要对象
            HSSFWorkbook workbook = new HSSFWorkbook();
            HSSFSheet sheet = (HSSFSheet)workbook.CreateSheet("Weight");
            //设置字体，大小，对齐方式
            HSSFCellStyle style = (HSSFCellStyle)workbook.CreateCellStyle();
            HSSFFont font = (HSSFFont)workbook.CreateFont();
            font.FontName = fontName;
            font.FontHeightInPoints = fontSize;
            style.SetFont(font);
            style.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Center; //居中对齐
            
            //添加表头
            HSSFRow dataRow = (HSSFRow)sheet.CreateRow(0);
            for (int i = 0; i < dgv.Columns.Count; i++)
            {
                dataRow.CreateCell(i).SetCellValue(dgv.Columns[i].HeaderText);
                dataRow.GetCell(i).CellStyle = style;
            }
            //注释的这行是设置筛选的
            //sheet.SetAutoFilter(new CellRangeAddress(0, dgv.Columns.Count, 0, dgv.Columns.Count));
            //添加列及内容
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                dataRow = (HSSFRow)sheet.CreateRow(i + 1);
                for (int j = 0; j < dgv.Columns.Count; j++)
                {
                    string ValueType = dgv.Rows[i].Cells[j].Value.GetType().ToString();
                    string Value = dgv.Rows[i].Cells[j].Value.ToString();
                    switch (ValueType)
                    {
                        case "System.String"://字符串类型
                            dataRow.CreateCell(j).SetCellValue(Value);
                            break;
                        case "System.DateTime"://日期类型
                            System.DateTime dateV;
                            System.DateTime.TryParse(Value, out dateV);
                            dataRow.CreateCell(j).SetCellValue(dateV);
                            break;
                        case "System.Boolean"://布尔型
                            bool boolV = false;
                            bool.TryParse(Value, out boolV);
                            dataRow.CreateCell(j).SetCellValue(boolV);
                            break;
                        case "System.Int16"://整型
                        case "System.Int32":
                        case "System.Int64":
                        case "System.Byte":
                            int intV = 0;
                            int.TryParse(Value, out intV);
                            dataRow.CreateCell(j).SetCellValue(intV);
                            break;
                        case "System.Decimal"://浮点型
                        case "System.Double":
                            double doubV = 0;
                            double.TryParse(Value, out doubV);
                            dataRow.CreateCell(j).SetCellValue(doubV);
                            break;
                        case "System.DBNull"://空值处理
                            dataRow.CreateCell(j).SetCellValue("");
                            break;
                        default:
                            dataRow.CreateCell(j).SetCellValue("");
                            break;
                    }
                    dataRow.GetCell(j).CellStyle = style;
                    //设置宽度
                    sheet.SetColumnWidth(j, (Value.Length + 10) * 256);
                }
            }
            //保存文件
            //string saveFileName = "";
            //SaveFileDialog saveDialog = new SaveFileDialog();
            //saveDialog.DefaultExt = "xls";
            //saveDialog.Filter = "Excel文件|*.xls";
            //saveDialog.FileName = fileName;
            //MemoryStream memoryStream = new MemoryStream();
            //if (saveDialog.ShowDialog() == DialogResult.OK)
            if(1==1)
            {
                //saveFileName = saveDialog.FileName;
                if (!CheckFiles(fileName))
                {
                    MessageBox.Show("文件被站用，请关闭文件 " + fileName);
                    workbook = null;
                    //memoryStream.Close();
                    //memoryStream.Dispose();
                    return;
                }
                //workbook.Write(memoryStream);
                FileStream file = new FileStream(fileName, FileMode.Create);
                workbook.Write(file);
                file.Close();
                workbook = null;
                //memoryStream.Close();
                //memoryStream.Dispose();
                MessageBox.Show(fileName + " 保存成功", "提示", MessageBoxButtons.OK);
            }
            else
            {
                workbook = null;
                //memoryStream.Close();
                //memoryStream.Dispose();
            }
        }

        /// <summary>
        /// 检测文件是否被占用 
        /// </summary>
        /// <param name="lpPathName">要检测的文件路径</param>
        /// <param name="iReadWrite"></param>
        /// <returns></returns>
        [DllImport("kernel32.dll")]
        public static extern IntPtr _lopen(string lpPathName, int iReadWrite);
        [DllImport("kernel32.dll")]
        public static extern bool CloseHandle(IntPtr hObject);
        public const int OF_READWRITE = 2;
        public const int OF_SHARE_DENY_NONE = 0x40;
        public static readonly IntPtr HFILE_ERROR = new IntPtr(-1);
        public static bool CheckFiles(string FileNames)
        {
            if (!File.Exists(FileNames))
            {
                //文件不存在
                return true;
            }
            IntPtr vHandle = _lopen(FileNames, OF_READWRITE | OF_SHARE_DENY_NONE);
            if (vHandle == HFILE_ERROR)
            {
                //文件被占用
                return false;
            }
            //文件没被占用
            CloseHandle(vHandle);
            return true;
        }
    }
}
