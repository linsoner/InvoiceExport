using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiwangExport
{
    public class Invoice
    {
        ITaxHardware TaxHardware;
        public Invoice(ITaxHardware taxHardware)
        {
            TaxHardware = taxHardware;
        }

        /// <summary>
        /// 查询发票
        /// </summary>
        /// <param name="strNSRSBH">纳税人识别号</param>
        /// <param name="strSKPBH">税控盘编号</param>
        /// <param name="strSKPPwd">税控盘口令</param>
        /// <param name="strCertPwd">税务数字证书密码</param>
        /// <param name="strFPLXDM">发票类型代码</param>
        /// <param name="nQueryType">查询方式 0：按发票号码段来读 1:按时间段来读</param>
        /// <param name="strQueryCondition">查询条件 nQueryType为1是：起始日期（YYYYMMDD）+终止日期（YYYYMMDD） nQueryType为0时： 10位发票代码+8位起始号码+8位终止号码 </param>
        /// <param name="nInvoiceUploadType">查询类型 0所有票， 1未上传 </param>
        /// <returns></returns>
        public static string GetInvoices(string strNSRSBH, string strSKPBH, string strSKPPwd, string strCertPwd
            , string strFPLXDM, int nQueryType, string strQueryCondition, int nInvoiceUploadType
            , BWJF_SKOP_ATLLib.SKControlLogic sam)
        {
            string s = string.Empty;
            try
            {
                //s = sam.GetInvoiceInfo("500102010001497", "499000116076", "88888888", "12345678"
                //    , "025", 1, "2016110120161130", 0);
                s = sam.GetInvoiceInfo(strNSRSBH, strSKPBH, strSKPPwd, strCertPwd
                    , strFPLXDM, nQueryType, strQueryCondition, nInvoiceUploadType);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return s;
        }

        /// <summary>
        /// 导入黑盘XML文件
        /// </summary>
        /// <returns></returns>
        public static string GetInvoices()
        {
            string s = string.Empty;
            try
            {
                
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return s;
        }
    }
}
