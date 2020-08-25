using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web.Script.Serialization;
using HozestERP.BusinessLogic.Infrastructure;
using HozestERP.BusinessLogic.ManageProject;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace HozestERP.BusinessLogic.ManageProject
{
    public class XLMInterface
    {

        public string NewApiUrl = "https://202.101.185.118/";//喜临门新系统接口地址


        /// <summary>
        /// 获取喜临门接口的签名
        /// </summary>
        /// <returns></returns>
        public string GetUrl(string method, string body)
        {
            string url = "http://e.chinabed.com:30005/router";//"http://114.55.14.32:30007/router";//"http://117.144.19.2:9089/router";
            string appsecret = "5d8eb92c-f9ef-4411-8c16-2eba9f2c4168";// "c3083eae-c657-11e6-9056-ac853daf4f61";//"f60164a0-efbf-4dd2-acc8-c9440e1fad85";

            Dictionary<string, string> requestParams = new Dictionary<string, string>();
            requestParams.Add("app_key", "744bd61c-1510-42b9-9cea-8b26414d11a0");//"bcc277bc-c657-11e6-9056-ac853daf4f61");//"5bdb4370-eda3-477e-a4c1-01fd87353672");
            requestParams.Add("format", "json");
            requestParams.Add("method", method);
            requestParams.Add("sessionkey", "5f988bba-73f6-4daa-9edc-741b60c84c57");//"11342f44-c658-11e6-9056-ac853daf4f61");//"2821a297-cccd-4039-a513-9405a00b2a2b");
            requestParams.Add("v", "1.0");
            string sign = Sign.sign(requestParams, body, appsecret);

            string parm = "";
            foreach (var one in requestParams)
            {
                if (parm != "")
                {
                    parm += "&";
                }
                parm += one.Key + "=" + one.Value;
            }

            url += "?" + parm + "&sign=" + sign;

            return url;
        }

        /// <summary>
        /// 喜临门新系统接口token获取
        /// </summary>
        /// <returns></returns>
        public string Gettoken() 
        {
            ServicePointManager.ServerCertificateValidationCallback = (sender, cert, chain, error) =>
            {
                return true;
            };
            string strUrl = this.NewApiUrl + "authorizationserver/oauth/token?client_id=mobile_android&client_secret=secret&username=api_user&grant_type=password&password=123456";
            WebRequest request = WebRequest.Create(strUrl);//创建请求

            request.Method = "Post";//设置访问方式

            WebResponse result = request.GetResponse() as WebResponse;

            StreamReader sr = new StreamReader(result.GetResponseStream(), Encoding.UTF8);

            string strResult = sr.ReadToEnd();
            JObject jo = (JObject)JsonConvert.DeserializeObject(strResult);
            string access_token = jo["access_token"].Value<string>();
            sr.Close();
            return access_token;
        }

        /// <summary>  
        /// 返回JSon数据  
        /// </summary>  
        /// <param name="JSONData">要处理的JSON数据</param>  
        /// <param name="Url">要提交的URL</param>  
        /// <returns>返回的JSON处理字符串</returns>  
        public string GetResponseData(string JSONData, string Url)
        {
            try
            {
                ServicePointManager.ServerCertificateValidationCallback = (sender, cert, chain, error) =>
                {
                    return true;
                };
                byte[] bytes = Encoding.UTF8.GetBytes(JSONData);
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);
                request.Method = "POST";
                request.ContentLength = bytes.Length;
                request.ContentType = "application/json; charset=utf-8";
                Stream reqstream = request.GetRequestStream();
                reqstream.Write(bytes, 0, bytes.Length);

                //声明一个HttpWebRequest请求  
                request.Timeout = 90000;
                //设置连接超时时间  
                request.Headers.Set("Pragma", "no-cache");
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream streamReceive = response.GetResponseStream();
                Encoding encoding = Encoding.UTF8;

                StreamReader streamReader = new StreamReader(streamReceive, encoding);
                string strResult = streamReader.ReadToEnd();
                streamReceive.Dispose();
                streamReader.Dispose();

                return strResult;
            }
            catch
            {
                return "error";
            }
        }

        /// <summary>
        /// 将json数据反序列化为Dictionary
        /// </summary>
        /// <param name="jsonData">json数据</param>
        /// <returns></returns>
        public Dictionary<string, object> JsonToDictionary(string jsonData)
        {
            //实例化JavaScriptSerializer类的新实例
            JavaScriptSerializer jss = new JavaScriptSerializer();
            try
            {
                //将指定的 JSON 字符串转换为 Dictionary<string, object> 类型的对象
                return jss.Deserialize<Dictionary<string, object>>(jsonData);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void UpdateDeliveryLogisticsInfo()
        {
            string method = "qs.deliveryorder.get";
            string start = DateTime.Now.AddDays(-5).ToString("yyyy-MM-dd HH:mm:ss");
            string end = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string shopcode = "005";//店铺代码

            for (int i = 1; i < 20; i++)
            {
                StringBuilder body = new StringBuilder();
                body.Append("{\"shopcode\":").Append("\"" + shopcode + "\"").Append(",");
                body.Append("\"startmodified\":").Append("\"" + start + "\"").Append(",");
                body.Append("\"endmodified\":").Append("\"" + end + "\"").Append(",");
                body.Append("\"pageno\":").Append("\"" + i + "\"").Append(",");
                body.Append("\"pagesize\":").Append("\"200\"").Append("}");

                string url = GetUrl(method, body.ToString());
                string josnStr = GetResponseData(body.ToString(), url);
                if (josnStr == "error")
                {
                    break;
                }

                Dictionary<string, object> data = JsonToDictionary(josnStr);
                if (data.ContainsKey("total_results") && (int)(data["total_results"]) > 0)
                {
                    ArrayList array = (ArrayList)data["orders"];
                    foreach (Dictionary<string, object> item in array)
                    {
                        ArrayList tids = (ArrayList)item["tids"];
                        foreach (string tid in tids)
                        {
                            var delivery = IoC.Resolve<IXMDeliveryService>().GetXMDeliveryListByLogisticsNumber(tid);
                            if (delivery != null && delivery.Count > 0 && string.IsNullOrEmpty(delivery[0].LogisticsNumber))
                            {
                                delivery[0].LogisticsNumber = item["expressnumber"].ToString();
                                delivery[0].IsDelivery = true;
                                delivery[0].UpdateId = HozestERPContext.Current.User.CustomerID;
                                delivery[0].UpdateDate = DateTime.Now;

                                string CompanyCode = item["expresscode"].ToString();
                                var CompanyCustom = IoC.Resolve<IXMCompanyCustomService>().GetXMCompanyCustomListByCompanyCode(CompanyCode);
                                if (CompanyCustom == null && CompanyCustom.Count > 0)
                                {
                                    delivery[0].LogisticsId = int.Parse(CompanyCustom[0].LogisticsId);
                                }
                                IoC.Resolve<IXMDeliveryService>().UpdateXMDelivery(delivery[0]);
                                //更新订单发货时间
                                string ordercode = delivery[0].OrderCode;
                                XMOrderInfo myXMOrderInfo = IoC.Resolve<IXMOrderInfoService>().GetXMOrderInfoByOrderCode(ordercode);
                                myXMOrderInfo.PayDate = DateTime.Now;
                                IoC.Resolve<IXMOrderInfoService>().UpdateXMOrderInfo(myXMOrderInfo);
                            }
                        }
                    }
                }
            }
        }
    }

    public class Sign
    {
        public static String sign(Dictionary<String, String> param, String body, String secretKey)
        {
            // 1. 第一步，确保参数已经排序
            string[] keys = new string[param.Keys.Count];
            param.Keys.CopyTo(keys, 0);
            Array.Sort(keys);
            // 2. 第二步，把所有参数名和参数值拼接在一起(包含 body 体)
            String joinedParams = joinRequestParams(param, body, secretKey, keys);
            // 3. 第三步，使用加密算法进行加密
            byte[] abstractMesaage = digest(joinedParams);
            // 4. 把二进制转换成大写的十六进制
            String sign = byte2Hex(abstractMesaage);
            return sign;
        }

        private static Dictionary<string, string> getParamsFromUrl(String url)
        {
            Dictionary<string, string> requestParams = new Dictionary<string, string>();
            try
            {
                String fullUrl = System.Web.HttpUtility.UrlDecode(url, System.Text.Encoding.UTF8);
                String[] urls = fullUrl.Split('?');
                if (urls.Length == 2)
                {
                    String[] paramArray = urls[1].Split('&');
                    foreach (String param in paramArray)
                    {
                        String[] values = param.Split('=');
                        if (values.Length == 2)
                        {
                            requestParams.Add(values[0], values[1]);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                // TODO
                return null;
            }
            return requestParams;
        }

        private static String byte2Hex(byte[] bytes)
        {
            char[] hexDigits = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F' };
            int j = bytes.Length;
            char[] str = new char[j * 2];
            int k = 0;
            foreach (byte byte0 in bytes)
            {
                str[k++] = hexDigits[byte0 >> 4 & 0xf];
                str[k++] = hexDigits[byte0 & 0xf];
            }
            return new String(str);
        }

        private static byte[] digest(String message)
        {
            try
            {
                //获取加密服务
                System.Security.Cryptography.MD5CryptoServiceProvider md5CSP = new System.Security.Cryptography.MD5CryptoServiceProvider();
                //获取要加密的字段，并转化为 Byte[]数组
                byte[] testEncrypt = System.Text.Encoding.UTF8.GetBytes(message);
                //加密 Byte[]数组
                byte[] resultEncrypt = md5CSP.ComputeHash(testEncrypt);
                return resultEncrypt;
            }
            catch (Exception e)
            {
                //TODO
                return null;
            }
        }

        private static String joinRequestParams(Dictionary<String, String> param, String body, String secretKey, String[] sortedKes)
        {
            StringBuilder sb = new StringBuilder(secretKey); // 前面加上 secretKey
            foreach (String key in sortedKes)
            {
                if ("sign".Equals(key))
                {
                    continue; // 签名时不计算 sign 本身
                }
                else
                {
                    String value = param[key];
                    if (isNotEmpty(key) && isNotEmpty(value))
                    {
                        sb.Append(key).Append(value);
                    }
                }
            }
            sb.Append(body); // 拼接 body 体
            sb.Append(secretKey); // 最后加上 secretKey
            return sb.ToString();
        }
        private static bool isNotEmpty(String s)
        {
            return null != s && !"".Equals(s);
        }
    }
}
