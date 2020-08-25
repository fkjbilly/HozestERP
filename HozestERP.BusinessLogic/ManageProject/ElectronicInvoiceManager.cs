using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace HozestERP.BusinessLogic.ManageProject
{
    public class ElectronicInvoiceManager
    {
        /// <summary>
        /// AES加密密钥
        /// </summary>
        private static string key1 = "WuMlCJRN8zO886dw";
        /// <summary>
        /// HMAC-SHA1加密密钥
        /// </summary>
        private static string key2 = "I7GBo4w9E6dmGlLVJMaVtXrhbNqp4KBh";

        /// <summary>
        /// 获取发票查询请求报文
        /// </summary>
        /// <param name="NSRSBH">纳税人识别号</param>
        /// <param name="DDLSH">订单流水号</param>
        /// <returns></returns>
        public string getFPCX_Xml(string NSRSBH,string DDLSH)
        {
            StringBuilder sb1 = new StringBuilder();
            sb1.Append("<FPXX>");
            sb1.Append("<NSRSBH>"+ NSRSBH + "</NSRSBH>");
            sb1.Append("<DDLSH>" + DDLSH + "</DDLSH>");
            sb1.Append("</FPXX>");

            string text = EncryptAes(sb1.ToString());

            StringBuilder sb = new StringBuilder();
            sb.Append("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
            sb.Append("<interface>");
            sb.Append("<globalInfo>");
            sb.Append("<version>4.0</version>");
            sb.Append("<interfaceCode>DZFPCX</interfaceCode>");
            sb.Append("<token></token>");
            sb.Append("<requestTime>"+DateTime.Now.ToString("yyyyMMddHHmmss") +"</requestTime>");
            sb.Append("</globalInfo>");
            sb.Append("<Data>");
            sb.Append("<content>"+ text + "</content>");
            sb.Append("</Data>");
            sb.Append("</interface>");

            return sb.ToString();
        }

        /// <summary>
        /// 发票开具请求报文
        /// </summary>
        /// <param name="NSRSBH">开票方识别号（必须）</param>
        /// <param name="NSRMC">开票方名称（必须）</param>
        /// <param name="DDLSH">订单流水号（必须） 订单流水号（唯一码）开票方识别号 +企业自编流水号</param>
        /// <param name="DDH">订单号（必须）</param>
        /// <param name="DDDATE">订单时间（必须） 格式 yyyy-MM-dd</param>
        /// <param name="XHF_DZ">销货方地址（必须）</param>
        /// <param name="XHF_DH">销货方电话（必须）</param>
        /// <param name="XHF_YHZH">销货方银行账号（必须）  开户行名称及账号</param>
        /// <param name="GHFMC">购货方名称（必须）购货方名称，即发票抬头。购货方为“个人”时，可输入名称，输入名称是为“个人(名称)”，”（”为半角；例个人(王杰)</param>
        /// <param name="GHF_NSRSBH">购货方识别号（非必须）  企业消费，如果填写识别号，需要传输过来</param>
        /// <param name="GHF_DZ">购货方地址（非必须）</param>
        /// <param name="GHF_GDDH">购货方固定电话（非必须）</param>
        /// <param name="GHF_SJ">购货方手机（非必须）  手机号码需要推短消息，必填</param>
        /// <param name="GHF_EMAIL">购货方邮箱（非必须）  需要推邮件，必填</param>
        /// <param name="GHF_YHZH">购货方银行账号（非必须）  开户行及账号</param>
        /// <param name="KPLY">开票来源（必须）  开票来源：默认999—没有来源，具体的来源编号找文档提供商</param>
        /// <param name="KPY">开票员（必须）</param>
        /// <param name="SKY">收款员（非必须）</param>
        /// <param name="FHR">复核人（非必须）</param>
        /// <param name="KPLX">开票类型（必须）  1正票、2红票</param>
        /// <param name="YFP_DM">原发票代码（非必须）  KPLX为红票时候都是必录</param>
        /// <param name="YFP_HM">原发票号码（非必须）  KPLX为红票时候都是必录</param>
        /// <param name="KPHJJE">价税合计金额（必须）  小数点后2位，以元为单位精确到分</param>
        /// <param name="HJBHSJE">合计不含税金额。所有商品行不含税金额之和（必须）  小数点后2位，以元为单位精确到分（单行商品金额之和）。平台处理价税分离，此值传0</param>
        /// <param name="HJSE">合计税额。所有商品行税额之和（必须）  小数点后2位，以元为单位精确到分(单行商品税额之和)，平台处理价税分离，此值传0</param>
        /// <param name="BZ">备注（非必须）</param>
        /// <param name="BB">币种（非必须）  海运费企业必填</param>
        /// <param name="WB">外币金额（非必须）  海运费企业必填</param>
        /// <param name="FPZL">发票种类（非必须）  发票种类，默认“51”</param>
        /// <param name="XMMC">项目名称（必须）</param>
        /// <param name="XMDW">项目单位（非必须）</param>
        /// <param name="GGXH">规格型号（非必须）</param>
        /// <param name="XMSL">项目数量（非必须）  小数点后6位, 小数点后都是0时，PDF上只显示整数</param>
        /// <param name="HSBZ">含税标志（必须）  表示项目单价和项目金额是否含税。0表示都不含税只支持0</param>
        /// <param name="XMDJ">项目单价（非必须）  小数点后8位小数点后都是0时，PDF上只显示2位小数；否则只显示至最后一位不为0的数字</param>
        /// <param name="FPHXZ">发票行性质（必须）  0正常行、1折扣行、2被折扣行</param>
        /// <param name="SPBM">商品编码（必须）</param>
        /// <param name="ZXBM">自行编码（非必须）</param>
        /// <param name="YHZCBS">优惠政策标识（必须）  0：不使用，1：使用</param>
        /// <param name="LSLBS">零税率标识（非必须）  空：非零税率，1：免税，2：不征收，3普通零税率</param>
        /// <param name="ZZSTSGL">增值税特殊管理（非必须）  优惠政策标识为1时，必填</param>
        /// <param name="XMJE">项目金额（必须）  小数点后2位，以元为单位精确到分。等于=单价* 数量，根据含税标志，确定此金额是否为含税金额。</param>
        /// <param name="SL">税率（必须）  如果税率为0，零税率标识必填</param>
        /// <param name="SE">税额（必须）  小数点后2位，以元为单位精确到分</param>
        /// <param name="KCE">扣除额（非必须）</param>
        /// <returns></returns>
        public string getFPKJ_Xml(string NSRSBH,string NSRMC,string DDLSH,string DDH,string DDDATE,string XHF_DZ,string XHF_DH,string XHF_YHZH,string GHFMC,
            string GHF_NSRSBH,string GHF_DZ,string GHF_GDDH,string GHF_SJ,string GHF_EMAIL,string GHF_YHZH,string KPLY,string KPY,string SKY,string FHR,string KPLX,
            string YFP_DM,string YFP_HM,string KPHJJE,string HJBHSJE,string HJSE,string BZ,string BB,string WB,string FPZL,string XMMC,string XMDW,string GGXH,
            string XMSL,string HSBZ,string XMDJ,string FPHXZ,string SPBM,string ZXBM,string YHZCBS,string LSLBS,string ZZSTSGL,string XMJE,string SL,string SE,string KCE)
        {
            StringBuilder sb1 = new StringBuilder();
            sb1.Append("<REQUEST_FPKJXX>");
            sb1.Append("<FPKJXX_FPTXX>");
            sb1.Append("<NSRSBH>"+ NSRSBH + "</NSRSBH>");
            sb1.Append("<NSRMC>" + NSRMC + "</NSRMC>");
            sb1.Append("<DDLSH>"+ DDLSH + "</DDLSH>");
            sb1.Append("<DDH>"+ DDH + "</DDH>");
            sb1.Append("<DDDATE>"+ DDDATE + "</DDDATE>");
            sb1.Append("<BMB_BBH>1.0</BMB_BBH>");
            sb1.Append("<XHF_DZ>"+ XHF_DZ + "</XHF_DZ>");
            sb1.Append("<XHF_DH>"+ XHF_DH + "</XHF_DH>");
            sb1.Append("<XHF_YHZH>"+ XHF_YHZH + "</XHF_YHZH>");
            sb1.Append("<GHFMC>"+ GHFMC + "</GHFMC>");
            sb1.Append("<GHF_NSRSBH>"+ GHF_NSRSBH + "</GHF_NSRSBH>");
            sb1.Append("<GHF_DZ>"+ GHF_DZ + "</GHF_DZ>");
            sb1.Append("<GHF_GDDH>"+ GHF_GDDH + "</GHF_GDDH>");
            sb1.Append("<GHF_SJ>"+ GHF_SJ + "</GHF_SJ>");
            sb1.Append("<GHF_EMAIL>" + GHF_EMAIL + "</GHF_EMAIL>");
            sb1.Append("<GHF_YHZH>" + GHF_YHZH + "</GHF_YHZH>");
            sb1.Append("<KPLY>" + KPLY + "</KPLY>");
            sb1.Append("<KPY>" + KPY + "</KPY>");
            sb1.Append("<SKY>" + SKY + "</SKY>");
            sb1.Append("<FHR>" + FHR + "</FHR>");
            sb1.Append("<KPLX>" + KPLX + "</KPLX>");
            sb1.Append("<YFP_DM>" + YFP_DM + "</YFP_DM>");
            sb1.Append("<YFP_HM>" + YFP_HM + "</YFP_HM>");
            sb1.Append("<KPHJJE>" + KPHJJE + "</KPHJJE>");
            sb1.Append("<HJBHSJE>" + HJBHSJE + "</HJBHSJE>");
            sb1.Append("<HJSE>" + HJSE + "</HJSE>");
            sb1.Append("<BZ>" + BZ + "</BZ>");
            sb1.Append("<BB>" + BB + "</BB>");
            sb1.Append("<WB>" + WB + "</WB>");
            sb1.Append("<FPZL>" + FPZL + "-51</FPZL>");
            sb1.Append("</FPKJXX_FPTXX>");
            sb1.Append("<FPKJXX_XMXXS>");
            sb1.Append("<FPKJXX_XMXX>");
            sb1.Append("<XMMC>" + XMMC + "</XMMC>");
            sb1.Append("<XMDW>" + XMDW + "</XMDW>");
            sb1.Append("<GGXH>" + GGXH + "</GGXH>");
            sb1.Append("<XMSL>" + XMSL + "</XMSL>");
            sb1.Append("<HSBZ>" + HSBZ + "</HSBZ>");
            sb1.Append("<XMDJ>" + XMDJ + "</XMDJ>");
            sb1.Append("<FPHXZ>" + FPHXZ + "</FPHXZ>");
            sb1.Append("<SPBM>" + SPBM + "</SPBM>");
            sb1.Append("<ZXBM>"+ ZXBM + "</ZXBM>");
            sb1.Append("<YHZCBS>" + YHZCBS + "</YHZCBS>");
            sb1.Append("<LSLBS>" + LSLBS + "</LSLBS>");
            sb1.Append("<ZZSTSGL>" + ZZSTSGL + "</ZZSTSGL>");
            sb1.Append("<XMJE>" + XMJE + "</XMJE>");
            sb1.Append("<SL>" + SL + "</SL>");
            sb1.Append("<SE>" + SE + "</SE>");
            sb1.Append("<KCE>" + KCE + "</KCE>");
            sb1.Append("</FPKJXX_XMXX>");
            sb1.Append("</FPKJXX_XMXXS>");
            sb1.Append("</REQUEST_FPKJXX>");

            string text = EncryptAes(sb1.ToString());

            StringBuilder sb = new StringBuilder();
            sb.Append("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
            sb.Append("<interface>");
            sb.Append("<globalInfo>");
            sb.Append("<version>4.0</version>");
            sb.Append("<interfaceCode>DZFPCX</interfaceCode>");
            sb.Append("<token></token>");
            sb.Append("<requestTime>" + DateTime.Now.ToString("yyyyMMddHHmmss") + "</requestTime>");
            sb.Append("</globalInfo>");
            sb.Append("<Data>");
            sb.Append("<content>" + text + "</content>");
            sb.Append("</Data>");
            sb.Append("</interface>");

            return sb.ToString();
        }

        /// <summary>
        /// AES加密
        /// </summary>
        /// <param name="source">源数据</param>
        /// <param name="key">密钥</param>
        /// <returns></returns>
        public string EncryptAes(string source)
        {
            if(string.IsNullOrEmpty(source))
            {
                throw new Exception("明文不能为空");
            }

            byte[] toEncryptArray = Encoding.UTF8.GetBytes(source);

            RijndaelManaged rm = new RijndaelManaged
            {
                Key = Encoding.UTF8.GetBytes(key1),
                Mode = CipherMode.ECB,
                Padding = PaddingMode.PKCS7
            };

            ICryptoTransform cTransform = rm.CreateEncryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }

        /// <summary>
        /// base64加密
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public string EncryptBase64(string source)
        {
            byte[] bytes = Encoding.Default.GetBytes(source);
            return Convert.ToBase64String(bytes);
        }

        /// <summary>
        /// HMAC-SHA1 加密
        /// </summary>
        /// <param name="source">源数据</param>
        /// <param name="key">密钥</param>
        /// <returns></returns>
        public string EncryptHMACSHA1(string source)
        {
            var data = new HMACSHA1(Encoding.Default.GetBytes(key2)).ComputeHash(Encoding.Default.GetBytes(source));
            return BitConverter.ToString(data).Replace("-", "");
        }
    }
}
