using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiwangExport
{
    /// <summary>
    /// 税控盘借口
    /// </summary>
    public interface ITaxHardware
    {
        string GetInvoices(string strNSRSBH, string strSKPBH, string strSKPPwd, string strCertPwd
            , string strFPLXDM, string nQueryType, string strQueryCondition, string nInvoiceUploadType);
    }
}
