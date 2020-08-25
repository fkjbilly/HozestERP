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
using HozestERP.BusinessLogic.ManageBusiness;
using HozestERP.BusinessLogic.Codes;
using HozestERP.BusinessLogic.ManageInventory;

namespace HozestERP.Web.ManageInventory
{
    public partial class XMJDSaleCoefficientAdd : BaseAdministrationPage, IEditPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadDate();
            }
        }

        public void loadDate()
        {
            if (this.Type == 0)
            {
                this.Face_Init();
            }
            else
            {
                this.Face_Init();
                var xmJDSaleCoefficeient = base.XMJDZYSaleCoefficientsService.GetXMJDZYSaleCoefficientsById(Id);
                if (xmJDSaleCoefficeient != null)
                {
                    this.txtSaleCoefficients.Text = xmJDSaleCoefficeient.Value.ToString().Trim();
                    var nicks = base.XMNickService.GetXMNickByID(xmJDSaleCoefficeient.NickId);
                    if (nicks != null && nicks.ProjectId != null)
                    {
                        this.ddXMProject.SelectedValue = nicks.ProjectId.ToString().Trim();
                    }
                    this.ddlNick.SelectedValue = xmJDSaleCoefficeient.NickId.ToString().Trim();
                }
            }
        }

        public void Face_Init()
        {
            if (base.GetRoles(HozestERPContext.Current.User.CustomerID) == true)
            {
                List<XMProject> XMProjectList = base.XMOrderInfoAPIService.GetXMProjectClientId(HozestERPContext.Current.User.CustomerID);
                if (XMProjectList.Count > 0)
                {
                    this.ddXMProject.Items.Clear();
                    this.ddXMProject.Items.Clear();
                    this.ddXMProject.Items.Insert(0, new ListItem(XMProjectList[0].ProjectName, XMProjectList[0].Id.ToString()));
                }
            }
            else
            {
                this.BindddXMProject();//项目
            }

            this.ddXMProject_SelectedIndexChanged(null, null);//店铺
        }

        //项目数据绑定
        private void BindddXMProject()
        {
            #region 项目名称绑定

            //项目名称绑定--选取自运营项目
            if (HozestERPContext.Current.User.CustomerID == 7 || HozestERPContext.Current.User.CustomerID == 84 || HozestERPContext.Current.User.CustomerID == 658)
            {
                this.ddXMProject.Items.Clear();
                var projectList = base.XMProjectService.GetXMProjectList();
                //.Where(c => c.ProjectTypeId == 362)

                this.ddXMProject.DataSource = projectList;
                this.ddXMProject.DataTextField = "ProjectName";
                this.ddXMProject.DataValueField = "Id";
                this.ddXMProject.DataBind();
            }
            else
            {
                this.ddXMProject.Items.Clear();
                var projectList = base.XMProjectService.GetXMProjectListSS(HozestERPContext.Current.User.CustomerID, 0)
                    .GroupBy(p => new { p.Id, p.ProjectName })
                    .Select(p => new
                    {
                        Id = p.Key.Id,
                        ProjectName = p.Key.ProjectName
                    });
                if (projectList.Count() == 0)
                {
                    this.ddXMProject.Items.Insert(0, new ListItem("---无项目权限---", "0"));
                }
                if (projectList.Count() > 0)
                {
                    this.ddXMProject.DataSource = projectList;
                    this.ddXMProject.DataTextField = "ProjectName";
                    this.ddXMProject.DataValueField = "Id";
                    this.ddXMProject.DataBind();
                }
                //this.ddXMProject.Items.Insert(0, new ListItem("---所有---", "-1"));
            }
            #endregion
        }

        protected void ddXMProject_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.ddXMProject.SelectedValue.ToString().Trim().Length > 0)
            {
                //店铺数据源 
                if (HozestERPContext.Current.User.CustomerID == 7 || HozestERPContext.Current.User.CustomerID == 84 || HozestERPContext.Current.User.CustomerID == 658)
                {
                    var nickList = base.XMOrderInfoAPIService.GetXMNickList("", Convert.ToInt32(true), Convert.ToInt32(this.ddXMProject.SelectedValue));
                    this.ddlNick.Items.Clear();
                    // var NickListNew = nickList.Where(p => p.nick_id != 16 && p.nick_id != 17 && p.nick_id != 18).ToList();
                    this.ddlNick.DataSource = nickList;
                    this.ddlNick.DataTextField = "nick";
                    this.ddlNick.DataValueField = "nick_id";
                    this.ddlNick.DataBind();
                    this.ddlNick.Items.Insert(0, new ListItem("---所有---", "-1"));
                }
                else
                {
                    //其他
                    //var xMNickList = base.XMNickService.GetMyNickListByCustomer(HozestERPContext.Current.User.CustomerID, "", 0);
                    var nickList = base.XMOrderInfoAPIService.GetXMNickListSS("", Convert.ToInt32(true), Convert.ToInt32(this.ddXMProject.SelectedValue), HozestERPContext.Current.User.CustomerID, 0);
                    this.ddlNick.Items.Clear();
                    // var NickListNew = nickList.Where(p => p.nick_id != 16 && p.nick_id != 17 && p.nick_id != 18).ToList();
                    if (nickList.Count() == 0)
                    {
                        this.ddlNick.Items.Insert(0, new ListItem("---无店铺权限---", "0"));
                    }
                    else
                    {
                        if (nickList.Count() > 0)
                        {
                            this.ddlNick.DataSource = nickList;
                            this.ddlNick.DataTextField = "nick";
                            this.ddlNick.DataValueField = "nick_id";
                            this.ddlNick.DataBind();
                        }
                        this.ddlNick.Items.Insert(0, new ListItem("---所有---", "99"));
                    }
                }
            }
        }


        protected void btnSave_Click(object sender, EventArgs e)
        {
            int nickId = Convert.ToInt16(ddlNick.SelectedValue);
            int month = Convert.ToInt16(ddlMonth.SelectedValue);
            string value = txtSaleCoefficients.Text.Trim();
            decimal saleCoefficients = 0;
            if (nickId == -1 || nickId == 99)
            {
                base.ShowMessage("请选择店铺，操作失败!");
                return;
            }
            if (string.IsNullOrEmpty(value) || !decimal.TryParse(value, out saleCoefficients))
            {
                base.ShowMessage("输入的销售系统为空或系数数据类型转化错误，操作失败!");
                return;
            }
            if (this.Type == 0)            //新增系数
            {
                var xmSaleCoefficients = base.XMJDZYSaleCoefficientsService.GetXMJDZYSaleCoefficientsByParm(nickId.ToString(), month);
                if (xmSaleCoefficients != null && xmSaleCoefficients.Count > 0)
                {
                    base.ShowMessage("该店铺下系数已设定，操作失败!");
                    return;
                }
                XMJDZYSaleCoefficients Info = new XMJDZYSaleCoefficients();
                Info.NickId = nickId;
                Info.Month = month;
                Info.Value = decimal.Parse(value);
                Info.CreateDate = Info.UpdateDate = DateTime.Now;
                Info.CreateID = Info.UpdateID = HozestERPContext.Current.User.CustomerID;
                Info.IsEnable = false;
                base.XMJDZYSaleCoefficientsService.InsertXMJDZYSaleCoefficients(Info);
            }
            else                                 //编辑
            {
                var xmSaleCoefficients = base.XMJDZYSaleCoefficientsService.GetXMJDZYSaleCoefficientsById(this.Id);
                if (xmSaleCoefficients != null)
                {
                    xmSaleCoefficients.NickId = nickId;
                    xmSaleCoefficients.Month = month;
                    xmSaleCoefficients.Value = decimal.Parse(value);
                    xmSaleCoefficients.UpdateDate = DateTime.Now;
                    xmSaleCoefficients.UpdateID = HozestERPContext.Current.User.CustomerID;
                    base.XMJDZYSaleCoefficientsService.UpdateXMJDZYSaleCoefficients(xmSaleCoefficients);
                }
            }
            this.Master.JsWrite("alert('保存成功.');window.PopClose();", "");
        }

        /// <summary>
        /// 操作类型
        /// </summary>
        public int Id
        {
            get
            {
                return CommonHelper.QueryStringInt("Id");
            }
        }

        public int Type
        {
            get
            {
                return CommonHelper.QueryStringInt("Type");
            }
        }

        public void SetTrigger()
        {
        }
    }
}