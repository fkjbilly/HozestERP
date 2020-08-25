<%@ WebHandler Language="C#" Class="UploadHandler2" %>

using System;
using System.Web;
using System.IO;
using HozestERP.BusinessLogic.Infrastructure;
using HozestERP.BusinessLogic;
using HozestERP.BusinessLogic.ManageFile;
using HozestERP.Common.Utils;

public class UploadHandler2 : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/plain";
        context.Response.Charset = "utf-8";
        HttpPostedFile file = context.Request.Files["Filedata"];
        string strTaggantID = context.Request["TaggantID"].ToString();
        string strTableName = context.Request["TableName"].ToString();
        Guid? result = null;
        try
        {
            result = new Guid(strTaggantID);
        }
        catch
        {
        }
        Guid taggantid = result.GetValueOrDefault();
        int objectid = 0;
        int.TryParse(context.Request["ObjectID"].ToString(), out objectid);
        string uploadPath = HttpContext.Current.Server.MapPath("~") + "Upload\\";
        if (file != null)
        {
            if (!Directory.Exists(uploadPath))
            {
                Directory.CreateDirectory(uploadPath);
            }
            string[] strExtensions = file.FileName.Split('.');
            string strExtension = string.Empty;
            string strFileName = file.FileName;
            if (strExtensions.Length > 0)
            {
                strExtension = strExtensions[strExtensions.Length - 1];
                strFileName = DateRndName() + "." + strExtension;
            }
            file.SaveAs(uploadPath + strFileName);
            var uploadfile = IoC.Resolve<IFileService>().InsertUploadFile(new UploadFile()
            {
                FullName = file.FileName
                ,
                Url = strFileName
                ,
                TaggantID = taggantid
                ,
                ObjectID = objectid
                ,
                TableName = strTableName
                ,
                Created = DateTime.Now
                ,
                CreatorID = 0
            });
            //下面这句代码缺少的话，上传成功后上传队列的显示不会自动消失     
            context.Response.Write(uploadfile.UploadFileID.ToString());
        }
        else
        {
            context.Response.Write("0");
        }
    }

    #region public DateRndName() 日期时间+3位数随机
    /// <summary>
    /// 日期时间+3位数随机
    /// </summary>
    /// <returns></returns>
    public string DateRndName()
    {
        Random myRandom = new Random();
        DateTime myDateTime = DateTime.Now;
        string str = null, paramYear, paramMonth, paramDay, paramHour, paramMinutes, paramSecond;
        paramYear = myDateTime.Year.ToString();
        paramMonth = myDateTime.Month.ToString();
        if (paramMonth.Length < 2)
        {
            paramMonth = "0" + paramMonth;
        }
        paramDay = myDateTime.Day.ToString();
        if (paramDay.Length < 2)
        {
            paramDay = "0" + paramDay;
        }
        paramHour = myDateTime.Hour.ToString();
        if (paramHour.Length < 2)
        {
            paramHour = "0" + paramHour;
        }
        paramMinutes = myDateTime.Minute.ToString();
        if (paramMinutes.Length < 2)
        {
            paramMinutes = "0" + paramMinutes;
        }
        paramSecond = myDateTime.Second.ToString();
        if (paramSecond.Length < 2)
        {
            paramSecond = "0" + paramSecond;
        }
        str += paramYear + paramMonth + paramDay + paramHour + paramMinutes + paramSecond;
        str += myRandom.Next(100, 999).ToString();
        return str;
    }
    #endregion

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }
}
