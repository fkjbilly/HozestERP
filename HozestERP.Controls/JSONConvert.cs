using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Security.Cryptography;
using System.Collections;
using System.IO;
using System.Net;

/// <summary>
    /// 类  名：JSONConvert
    /// 描  述：JSON解析类
    /// 编  写：csw
    /// 日  期：2010-10-21
    /// 版  本：1.1.0
    /// </summary>
public static class JSONConvert
{
    #region 全局变量

    public static string url = "http://vipapis.com";   //唯品会API地址
    public static string format = "json"; //报文格式 xml/json
    public static string reqtype = "get";//HTTP请求方式
    public static string vendorid = "6480";//供应商id(多个供应商时这个必填项)

    public static string service = "";//服务名称
    public static string method = "";//方法名称
    public static string version = "";//版本号
    public static string timestamp = "";//时间戳

    public static string appKey = "";//应用ID，开放平台分配给应用的唯一标识
    public static string appSecret = "";//
    public static string sign = "";//API输入参数的签名结果

    #endregion

    #region 时间戳转换

    public static int ConvertDateTimeInt(System.DateTime time)
    {
        System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));
        return (int)(time - startTime).TotalSeconds;
    }

    #endregion

    #region url路径获取json

    public static string post(string UseInter)
    {
        //系统级参数
        String SysInter = "appKey" + appKey + "format" + format + "method" + method
            + "service" + service + "timestamp" + timestamp + "version" + version;

        //sign签名
        sign = BytetoString(HmacSha1Sign(SysInter + UseInter, appSecret));

        //post系统级参数
        String PostSysInter = "appKey=" + appKey + "&format=" + format + "&method=" + method
            + "&service=" + service + "&timestamp=" + timestamp + "&version=" + version + "&sign=" + sign;

        string url = "http://vipapis.com?" + PostSysInter;
        byte[] dataArray = Encoding.Default.GetBytes(UseInter);
        //创建请求
        HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
        request.Method = "POST";
        request.ContentLength = dataArray.Length;
        request.ContentType = "application/json; charset=utf-8;";
        //创建输入流
        Stream dataStream = null;
        try
        {
            dataStream = request.GetRequestStream();
        }
        catch (Exception)
        {
            return null;//连接服务器失败
        }

        //发送请求
        dataStream.Write(dataArray, 0, dataArray.Length);
        dataStream.Close();
        //读取返回消息
        string res = string.Empty;
        try
        {
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
            res = reader.ReadToEnd();
            reader.Close();
        }
        catch (Exception ex)
        {
            return null;//连接服务器失败
        }
        return res;
    }

    #endregion

    #region  HMAC-MD5加密

    public static byte[] HmacSha1Sign(string key, string appsercet)
    {
        HMACMD5 hmacsha1 = new HMACMD5();

        byte[] secretKeyBArr = Encoding.UTF8.GetBytes(appsercet);
        byte[] contentBArr = Encoding.UTF8.GetBytes(key);

        hmacsha1.Key = secretKeyBArr;
        byte[] final = hmacsha1.ComputeHash(contentBArr);

        return final;
    }

    private static string HEXSTR = "0123456789ABCDEF";

    public static string BytetoString(byte[] bytes)
    {
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < bytes.Length; i++)
        {
            int a = (bytes[i] & 0xf0) >> 4;
            int b = (bytes[i] & 0x0f);
            char c = HEXSTR[a];//字节高4位
            char d = HEXSTR[b];//字节低4位
            sb.Append(c.ToString());
            sb.Append(d.ToString());
        }
        return sb.ToString().ToUpper();
    }

    #endregion


}