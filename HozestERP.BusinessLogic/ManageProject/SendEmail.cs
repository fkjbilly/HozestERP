using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace HozestERP.BusinessLogic.ManageProject
{
     public class SendEmail
    {
         /// <summary>
         /// 订单同步异常
         /// </summary>
         /// <param name="msg"></param>
         public void ToSendEmail(string msg)
         {
             try
             {
                 MailMessage mailObj = new MailMessage();
                 mailObj.From = new MailAddress("hozest123@126.com"); //发送人邮箱地址
                 mailObj.To.Add("34756027@qq.com");//收件人邮箱地址
                 mailObj.Subject = "平台店铺更新异常！";    //主题
                 mailObj.Body = msg;    //正文
                 SmtpClient smtp = new SmtpClient();
                 smtp.Host = "smtp.126.com";//smtp服务器名称
                 smtp.UseDefaultCredentials = true;
                 smtp.Credentials = new NetworkCredential("hozest123@126.com", "hzl123");  //发送人的登录名和密码
                 smtp.Send(mailObj);
             }
             catch (Exception ex)
             {
                 //HozestERP.BusinessLogic.LogHelper.WriteLog(typeof(SendEmail), ex);
             }
         }
    }
}
