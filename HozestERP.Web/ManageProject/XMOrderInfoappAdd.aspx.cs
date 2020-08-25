using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HozestERP.BusinessLogic.ManageProject;
using HozestERP.BusinessLogic;
using HozestERP.Common.Utils;
using System.Web.UI.HtmlControls;
using HozestERP.Web.Modules;
using System.Transactions;
using System.Net;
using System.IO;
using System.Text;
namespace HozestERP.Web.ManageProject
{
    public partial class XMOrderInfoappAdd : BaseAdministrationPage, IEditPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            { loadDate(); }
        }

        protected void btnGetToken_Click(object sender, EventArgs e)
        {
            this.PostURL("https://auth.vip.com/oauth2/token?client_id=a0b276a6&client_secret=EAA5D5E7D2A3BA8A94284B411309423A&grant_type=authorization_code&redirect_uri=http://www.hozest.com&request_client_ip=127.0.0.1&code=01ffe4cbf8f24e1db9258424c95195fd");
            //this.PostURL(" https://auth.vip.com/oauth2/authorize?client_id=a0b276a&response_type=code&redirect_uri=http://www.hozest.com");
            //1688token获取
            //this.PostURL("https://gw.open.1688.com/openapi/http/1/system.oauth2/getToken/2158919?grant_type=authorization_code&need_refresh_token=true&client_id=2158919&client_secret=ZdZN5IRrXva&redirect_uri=http://www.hozest.com&code=ec06ae24-f59c-40be-b267-e8f6bcdffebb");
        }

        public string PostURL(string strUrl) 
        {
            WebRequest request = WebRequest.Create(strUrl);//创建请求

            request.Method = "Post";//设置访问方式

            WebResponse result = request.GetResponse() as WebResponse;

            StreamReader sr = new StreamReader(result.GetResponseStream(), Encoding.UTF8);

            string strResult = sr.ReadToEnd();

            sr.Close();
            return strResult;
        }

        //返回URL结果  
        public string GetURLResult(string strUrl)
        {
            string strMsg = "";
            try
            {
                WebRequest request = WebRequest.Create(strUrl);
                WebResponse response = request.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding("gb2312"));

                strMsg = reader.ReadToEnd();

                reader.Close();
                reader.Dispose();
                response.Close();
            }
            catch
            { }
            return strMsg;
        }  

        protected void btnSave_Click(object sender, EventArgs e)
        {
            int ddlNick=Convert.ToInt32(ddlNickId.SelectedValue);
            int ddlPlatformType=Convert.ToInt32(ddlPlatformTypeId.SelectedValue);
            string AppKeyname=AppKey.Text;
            string AppSecretname=AppSecret.Text;
            string CallbackUrlname=CallbackUrl.Text;
            string AccessTokenname=AccessToken.Text;
            string ServerUrlname=ServerUrl.Text;
            if (AppKeyname.ToString() == "" || AppSecretname.ToString() == "" || AccessTokenname.ToString() == "" || ServerUrlname.ToString()=="")
            {
                base.ShowMessage("AppKey、AppSecret、AccessToken,ServerUrl不能为空!");
                return;
            }
            else
            {
                if (XMOrderInfoAppId == -1)//添加
                {
                    XMOrderInfoApp orderinfoapp = new XMOrderInfoApp();
                    orderinfoapp.NickId = ddlNick;
                    orderinfoapp.PlatformTypeId = ddlPlatformType;
                    orderinfoapp.AppKey = AppKeyname;
                    orderinfoapp.AppSecret = AppSecretname;
                    orderinfoapp.CallbackUrl = CallbackUrlname;
                    orderinfoapp.AccessToken = AccessTokenname;
                    orderinfoapp.ServerUrl = ServerUrlname;
                    orderinfoapp.IsEnabled = false;
                    orderinfoapp.CreateId = HozestERPContext.Current.User.CustomerID;
                    orderinfoapp.CreateDate = DateTime.Now;
                    orderinfoapp.ModifyId = HozestERPContext.Current.User.CustomerID;
                    orderinfoapp.ModifyDate = DateTime.Now;
                    base.XMOrderInfoAppService.InsertXMOrderInfoApp(orderinfoapp);
                    //this.Master.JsWrite("alert('保存成功！')", "");
                    base.ShowMessage("保存成功!");
                }
                else  //编辑
                {
                    XMOrderInfoApp orderinfoapp = base.XMOrderInfoAppService.GetXMOrderInfoAppByID(XMOrderInfoAppId);
                    if (orderinfoapp != null)//判断有没有这条数据
                    {
                        orderinfoapp.NickId = ddlNick;
                        orderinfoapp.PlatformTypeId = ddlPlatformType;
                        orderinfoapp.AppKey = AppKeyname;
                        orderinfoapp.AppSecret = AppSecretname;
                        orderinfoapp.CallbackUrl = CallbackUrlname;
                        orderinfoapp.AccessToken = AccessTokenname;
                        orderinfoapp.ServerUrl = ServerUrlname;
                        orderinfoapp.IsEnabled = false;
                        orderinfoapp.ModifyId = HozestERPContext.Current.User.CustomerID;
                        orderinfoapp.ModifyDate = DateTime.Now;
                        base.XMOrderInfoAppService.UpdateXMOrderInfoApp(orderinfoapp);
                        base.ShowMessage("保存成功!");
                    }
                }
            }
        }

        public void loadDate() {
            if (XMOrderInfoAppId == -1)
            {
                this.Face_Init();
            }
            else
            {
                var XMOrderInfoApp = base.XMOrderInfoAppService.GetXMOrderInfoAppByID(XMOrderInfoAppId);
                this.ddlNickId.SelectedValue = XMOrderInfoApp.NickId.ToString();
                this.ddlPlatformTypeId.SelectedValue = XMOrderInfoApp.PlatformTypeId.ToString(); 
                this.AppKey.Text = XMOrderInfoApp.AppKey;
                this.AppSecret.Text = XMOrderInfoApp.AppSecret;
                this.CallbackUrl.Text = XMOrderInfoApp.CallbackUrl;
                this.AccessToken.Text = XMOrderInfoApp.AccessToken;
                this.ServerUrl.Text = XMOrderInfoApp.ServerUrl;
            }
        }
            
        

        /// <summary>
        /// 刷单申请Id
        /// </summary>
        public int XMOrderInfoAppId
        {
            get
            {
                return  CommonHelper.QueryStringInt("XMOrderInfoAppId");
            }
        }

        public void Face_Init()
        {
            //throw new NotImplementedException();
            this.ddlPlatformTypeId.Items.Clear();
            var codePlatformTypeList = base.CodeService.GetCodeListInfoByCodeTypeID(182, false);
            this.ddlPlatformTypeId.DataSource = codePlatformTypeList;
            this.ddlPlatformTypeId.DataTextField = "CodeName";
            this.ddlPlatformTypeId.DataValueField = "CodeID";
            this.ddlPlatformTypeId.DataBind();

            this.ddlNickId.Items.Clear();
            var NickList = base.XMNickService.GetXMNickList();
            var newNickList = NickList.Where(p => p.isEnable == true).ToList();
            this.ddlNickId.DataSource = newNickList;
            this.ddlNickId.DataTextField = "nick";
            this.ddlNickId.DataValueField = "nick_id";
            this.ddlNickId.DataBind();

        }

        public void SetTrigger()
        {
            //throw new NotImplementedException();
        }
    }
}