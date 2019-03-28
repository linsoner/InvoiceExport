using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Data;
using System.IO;
using System.Xml.Linq;

namespace BaiwangExport
{
    public class XmlConvertor
    {
        public static XmlDocument StringToXml(string s)
        {
            XmlDocument doc = new XmlDocument();//新建对象
            doc.LoadXml(s);
            string fileName = "BW" + DateTime.Now.ToString("yyyyMMddmmsss")+ ".xml";
            doc.Save(fileName);
            TextReader r = new StreamReader(fileName, System.Text.Encoding.GetEncoding("gbk"));

            doc.Load(r);
            return doc;
        }

        public static DataSet XmlToDataSet(string xmlStr)
        {
            XmlDocument doc = StringToXml(xmlStr);
            if (doc == null) return null;
            XmlNode node = doc.SelectSingleNode("/business/body/output/returncode");
            int success = -1;
            if(!int.TryParse(node.InnerText,out success))
            {
                return null;
            }
            if (success != 0) return null;

            XmlNodeList nodelist = doc.SelectNodes("/business/body/output/fpxx/group");
            if (nodelist == null || nodelist.Count == 0)
                return null;

            DataSet dataSet = InitInvoiceDataTable();
            for(int i=0;i<nodelist.Count;i++)
            {
                DataRow mstRow = dataSet.Tables["Mst"].NewRow();
                
                mstRow["xh"] = i + 1;
                for (int j=0;j< nodelist[i].ChildNodes.Count;j++)
                {
                    if (dataSet.Tables["Mst"].Columns.Contains(nodelist[i].ChildNodes[j].Name))
                    {
                        if (dataSet.Tables["Mst"].Columns[nodelist[i].ChildNodes[j].Name].DataType == typeof(decimal))
                            mstRow[nodelist[i].ChildNodes[j].Name] = decimal.Parse(nodelist[i].ChildNodes[j].InnerText);
                        else
                            mstRow[nodelist[i].ChildNodes[j].Name] = nodelist[i].ChildNodes[j].InnerText;
                    }
                    else
                    {
                        if (nodelist[i].ChildNodes[j].Name == "fyxm" || nodelist[i].ChildNodes[j].Name == "qdxm")
                        {
                            #region 发票明细
                            //XmlNodeList itemNodeList = nodelist[i].ChildNodes[j].SelectNodes("/group");
                            XmlNodeList itemNodeList = nodelist[i].ChildNodes[j].ChildNodes;
                            if (itemNodeList!= null && itemNodeList.Count>0)
                            {
                                for(int k=0;k< itemNodeList.Count;k++)
                                {
                                    if (!itemNodeList[k].HasChildNodes) continue;

                                    DataRow ItemRow = dataSet.Tables["Item"].NewRow();
                                    //dataSet.Tables["Item"].Rows.Add(ItemRow);
                                    ItemRow["xh"] = nodelist[i].ChildNodes[j].Name == "fyxm" ? 2*k +1 : 2 * k+2;
                                    ItemRow["fpdm"] = mstRow["fpdm"];
                                    for (int l = 0; l < itemNodeList[k].ChildNodes.Count; l++)

                                    {
                                        if (dataSet.Tables["Item"].Columns.Contains(itemNodeList[k].ChildNodes[l].Name))
                                        {

                                            if (dataSet.Tables["Item"].Columns[itemNodeList[k].ChildNodes[l].Name].DataType == typeof(decimal))
                                                ItemRow[itemNodeList[k].ChildNodes[l].Name] = decimal.Parse(itemNodeList[k].ChildNodes[l].InnerText);
                                            else
                                                ItemRow[itemNodeList[k].ChildNodes[l].Name] = itemNodeList[k].ChildNodes[l].InnerText;
                                        }
                                    }
                                    dataSet.Tables["Item"].Rows.Add(ItemRow);
                                } 
                            }
                            #endregion 发票明细
                        }
                    }
                }
                dataSet.Tables["Mst"].Rows.Add(mstRow);
            }

            return dataSet;

        }

        /// <summary>
        /// 将xml转为Datable
        /// </summary>
        public static DataTable XmlToDataTable2(string xmlStr)
        {
            if (!string.IsNullOrEmpty(xmlStr))
            {
                StringReader StrStream = null;
                XmlTextReader Xmlrdr = null;
                try
                {
                    DataSet ds = new DataSet();
                    //读取字符串中的信息  
                    StrStream = new StringReader(xmlStr);
                    //获取StrStream中的数据  
                    Xmlrdr = new XmlTextReader(StrStream);
                    //ds获取Xmlrdr中的数据                 
                    ds.ReadXml(Xmlrdr);
                    return ds.Tables[0];
                }
                catch (Exception e)
                {
                    return null;
                }
                finally
                {
                    //释放资源  
                    if (Xmlrdr != null)
                    {
                        Xmlrdr.Close();
                        StrStream.Close();
                        StrStream.Dispose();
                    }
                }
            }
            return null;
        }

        public static DataSet InitInvoiceDataTable()
        {
            DataSet ds = new DataSet();

            DataTable mstTable = new DataTable("Mst");
            DataColumn column = new DataColumn("fpdm", typeof(string));//发票代码
            column.Caption = "发票代号";
            mstTable.Columns.Add(column);
            mstTable.PrimaryKey = new DataColumn[] { column };

            column = new DataColumn("fphm", typeof(string));//发票号码
            column.Caption = "发票号码";
            mstTable.Columns.Add(column);
            column = new DataColumn("xh", typeof(int));
            column.Caption = "序号";
            mstTable.Columns.Add(column);
            column = new DataColumn("fpzt", typeof(string));//发票状态
            column.Caption = "发票状态";
            mstTable.Columns.Add(column);
            column = new DataColumn("scbz", typeof(string));//上传标志
            column.Caption = "上传标志";
            mstTable.Columns.Add(column);
            column = new DataColumn("kprq", typeof(string));//开票日期
            column.Caption = "开票日期";
            mstTable.Columns.Add(column);
            column = new DataColumn("xhdwsbh", typeof(string));//销货单位识别号
            column.Caption = "销货单位识别号";
            mstTable.Columns.Add(column);
            column = new DataColumn("xhdwmc", typeof(string));
            column.Caption = "销货单位";
            mstTable.Columns.Add(column);
            column = new DataColumn("ghdwsbh", typeof(string));//购货单位识别号
            column.Caption = "购货单位识别号";
            mstTable.Columns.Add(column);
            column = new DataColumn("ghdwmc", typeof(string));
            column.Caption = "购货单位";
            mstTable.Columns.Add(column);
            column = new DataColumn("zhsl", typeof(decimal));
            column.Caption = "综合税率";
            mstTable.Columns.Add(column);
            column = new DataColumn("hjje", typeof(decimal));
            column.Caption = "合计金额";
            mstTable.Columns.Add(column);
            column = new DataColumn("hjse", typeof(decimal));
            column.Caption = "合计税额";
            mstTable.Columns.Add(column);
            column = new DataColumn("jshj", typeof(decimal));
            column.Caption = "价税合计";
            mstTable.Columns.Add(column);
            column = new DataColumn("bz", typeof(string));
            column.Caption = "备注";
            mstTable.Columns.Add(column);

            ds.Tables.Add(mstTable);

            DataTable ItemTable = new DataTable("Item");
            column = new DataColumn("fpdm", typeof(string));
            column.Caption = "发票代号";
            ItemTable.Columns.Add(column);
            DataColumn column2 = new DataColumn("xh", typeof(string));
            column2.Caption = "序号";
            ItemTable.Columns.Add(column2);
            ItemTable.PrimaryKey = new DataColumn[] { column ,column2 };
            column = new DataColumn("fphxz", typeof(string));
            column.Caption = "发票行性质";
            ItemTable.Columns.Add(column);
            column = new DataColumn("spmc", typeof(string));
            column.Caption = "商品名称";
            ItemTable.Columns.Add(column);
            column = new DataColumn("spsm", typeof(string));
            column.Caption = "商品税目";
            ItemTable.Columns.Add(column);
            column = new DataColumn("ggxh", typeof(string));
            column.Caption = "规格型号";
            ItemTable.Columns.Add(column);
            column = new DataColumn("dw", typeof(string));
            column.Caption = "单位";
            ItemTable.Columns.Add(column);
            column = new DataColumn("spsl", typeof(string));
            column.Caption = "商品数量";
            ItemTable.Columns.Add(column);
            column = new DataColumn("dj", typeof(string));
            column.Caption = "单价";
            ItemTable.Columns.Add(column);
            column = new DataColumn("je", typeof(string));
            column.Caption = "金额";
            ItemTable.Columns.Add(column);
            column = new DataColumn("sl", typeof(string));
            column.Caption = "税率";
            ItemTable.Columns.Add(column);
            column = new DataColumn("se", typeof(string));
            column.Caption = "税额";
            ItemTable.Columns.Add(column);
            column = new DataColumn("hsbz", typeof(string));
            column.Caption = "含税标志";
            ItemTable.Columns.Add(column);

            ds.Tables.Add(ItemTable);

            return ds;
        }
    }

   
}


/*
 * 
<?xml version="1.0" encoding="gbk"?>
<business comment="发票查询" id="FPCX">
	<body yylxdm="1">
		<output>
			<fplxdm>发票类型代码</fplxdm>
			<returncode>0</returncode>
			<returnmsg>成功</returnmsg>
			<fpxx count="1">
				<group xh="1">
					<fpdm>发票代码</fpdm>
					<fphm>发票号码</fphm>
					<fpzt>发票状态</fpzt>
					<scbz>上传标志</scbz>
					<kprq>开票日期</kprq>
					<kpsj>开票时间</kpsj>
					<tspz>特殊票种标识</tspz>
					<skpbh>税控盘编号</skpbh>
					<skm>税控码</skm>
					<jym>校验码</jym>
					<xhdwsbh>销货单位识别号</xhdwsbh>
					<xhdwmc>销货单位名称</xhdwmc>
					<xhdwdzdh>销货单位地址电话</xhdwdzdh>
					<xhdwyhzh>销货单位银行帐号</xhdwyhzh>
					<ghdwsbh>购货单位识别号</ghdwsbh>
					<ghdwmc>购货单位名称</ghdwmc>
					<ghdwdzdh>购货单位地址电话</ghdwdzdh>
					<ghdwyhzh>购货单位银行帐号</ghdwyhzh>
					<fyxm count="1">
						<group xh="1">
							<fphxz>发票行性质</fphxz>
							<spmc>商品名称</spmc>
							<spsm>商品税目</spsm>
							<ggxh>规格型号</ggxh>
							<dw>单位</dw>
							<spsl>商品数量</spsl>
							<dj>单价</dj>
							<je>金额</je>
							<sl>税率</sl>
							<se>税额</se>
							<hsbz>含税标志</hsbz>
						</group>
				    </fyxm>
					<qdxm count="1">
						<group xh="1">
							<fphxz>发票行性质</fphxz>
							<spmc>商品名称</spmc>
							<spsm>商品税目</spsm>
							<ggxh>规格型号</ggxh>
							<dw>单位</dw>
							<spsl>商品数量</spsl>
							<dj>单价</dj>
							<je>金额</je>
							<sl>税率</sl>
							<se>税额</se>
							<hsbz>含税标志</hsbz>
						</group>
					</qdxm>
					<qtxm count="1">
						<group xh="1">
							<sl>税率</sl>
							<je>金额</je>
							<se>税额</se>
						</group>
					</qtxm>
					<zhsl>综合税率</zhsl>
					<hjje>合计金额</hjje>
					<hjse>合计税额</hjse>
					<jshj>价税合计</jshj>
					<bz>备注</bz>
					<skr>收款人</skr>
					<fhr>复核人</fhr>
					<kpr>开票人</kpr>
					<jmbbh>加密版本号</jmbbh>
					<zyspmc>主要商品名称</zyspmc>
					<spsm>商品税目</spsm>
					<qdbz>清单标志</qdbz>
					<ssyf>所属月份</ssyf>
					<kpjh>开票机号</kpjh>
					<tzdbh>通知单编号</tzdbh>
					<yfpdm>原发票代码</yfpdm>
					<yfphm>原发票号码</yfphm>
					<zfrq>作废日期</zfrq>
					<zfr>作废人</zfr>
					<qmcs>签名参数</qmcs>
					<qmz>签名值</qmz>
					<ykfsje>已开负数金额</ykfsje>
				</group>
			</fpxx>
		</output>
	</body>
</business>
 * */
