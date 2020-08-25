using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using HozestERP.BusinessLogic.ManageCustomerService;
using HozestERP.Common;
using HozestERP.Common.Utils;
using HozestERP.BusinessLogic;
using HozestERP.BusinessLogic.ManageProject;


namespace HozestERP.Web.ManageCustomerService
{
    public partial class XMInstallationList : BaseAdministrationPage, ISearchPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!X.IsAjaxRequest)
            {
                this.BindddXMProject2();
                //this.ddXMProject2_SelectedIndexChanged(null, null);//店铺
                this.BindGrid(1, Master.PageSize);
                this.BindddXMProject();
            }
        }

        #region ISearchPage 成员

        public void SetTrigger()
        {
        }

        public void Face_Init()
        {
            this.Master.SetTitleVisible = false;
        }

        private void BindddXMProject2()
        {
            #region 项目名称绑定

            //项目名称绑定--选取自运营项目
            if (HozestERPContext.Current.User.CustomerID == 7 || HozestERPContext.Current.User.CustomerID == 84 || HozestERPContext.Current.User.CustomerID == 658 || HozestERPContext.Current.User.CustomerID == 682 || HozestERPContext.Current.User.CustomerID == 670)
            {
                ddXMProject2.Items.Clear();
                var projectList = base.XMProjectService.GetXMProjectList();
                Ext.Net.Store Store = ddXMProject2.GetStore();
                projectList.Add(new XMProject()
                {
                    ProjectName = "---所有---",
                    Id = -1,
                });
                Store.DataSource = projectList.OrderBy(a => a.Id);
                Store.DataBind();
                ddXMProject2.SelectedIndex = 0;
                ddXMProject2.Value = "-1";
            }
            else
            {
                ddXMProject2.Items.Clear();
                var projectList = base.XMProjectService.GetXMProjectListSS(HozestERPContext.Current.User.CustomerID, 0)
                    .GroupBy(p => new { p.Id, p.ProjectName })
                    .Select(p => new
                    {
                        Id = p.Key.Id,
                        ProjectName = p.Key.ProjectName
                    });
                if (projectList.Count() == 0)
                {

                    Ext.Net.ListItem liProject = new Ext.Net.ListItem();
                    liProject.Text = "---无项目权限---";
                    liProject.Value = "0";
                    ddXMProject2.Items.Add(liProject);
                    ddXMProject2.Value = 0;
                }
                else
                {
                    Ext.Net.Store Store = ddXMProject2.GetStore();
                    Store.DataSource = projectList;
                    Store.DataBind();
                    ddXMProject2.SelectedIndex = 0;
                    ddXMProject2.Value = projectList.ToList()[0].Id;
                }
                Ext.Net.ListItem liProject1 = new Ext.Net.ListItem();
                liProject1.Text = "---所有---";
                liProject1.Value = "99";
                ddXMProject2.Items.Add(liProject1);
                ddXMProject2.Value = 99;
            }
            #endregion

            this.ddXMProject2_SelectedIndexChanged(null, null);//店铺
        }

        protected void ddXMProject2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddXMProject2.Value.ToString().Trim().Length > 0)
            {
                //店铺数据源 
                if (HozestERPContext.Current.User.CustomerID == 7 || HozestERPContext.Current.User.CustomerID == 84 || HozestERPContext.Current.User.CustomerID == 658)
                {
                    var nickList = base.XMOrderInfoAPIService.GetXMNickList("", Convert.ToInt32(true), Convert.ToInt32(ddXMProject2.Value));
                    ddlNick2.Items.Clear();
                    Ext.Net.Store Store = ddlNick2.GetStore();
                    nickList.Add(new XMNick()
                    {
                        nick = "---所有---",
                        nick_id = -1,
                    });
                    Store.DataSource = nickList.OrderBy(a => a.nick_id);
                    Store.DataBind();
                    ddlNick2.SelectedIndex = 0;
                    if (!Page.IsPostBack)
                    {
                        ddlNick2.Value = "-1";
                    }
                }
                else
                {
                    //其他
                    var nickList = base.XMOrderInfoAPIService.GetXMNickListSS("", Convert.ToInt32(true), Convert.ToInt32(ddXMProject2.Value), HozestERPContext.Current.User.CustomerID, 0);
                    ddlNick2.Items.Clear();
                    if (nickList.Count() == 0)
                    {
                        nickList.Add(new XMNick()
                        {
                            nick = "---无店铺权限---",
                            nick_id = 0,
                        });
                        Ext.Net.Store Store = ddlNick2.GetStore();
                        Store.DataSource = nickList;
                        Store.DataBind();
                        ddlNick2.SelectedIndex = 0;
                        if (!Page.IsPostBack)
                        {
                            ddlNick2.Value = "0";
                        }
                    }
                    else
                    {
                        if (nickList.Count() > 0)
                        {
                            nickList.Insert(0, new XMNick()
                            {
                                nick = "---所有---",
                                nick_id = 99,
                            });
                            Ext.Net.Store Store = ddlNick2.GetStore();
                            Store.DataSource = nickList;
                            Store.DataBind();
                            ddlNick2.SelectedIndex = 0;
                            if (!Page.IsPostBack)
                            {
                                ddlNick2.Value = "99";
                            }
                        }
                    }
                }
            }
        }

        private void BindddXMProject()
        {
            #region 项目名称绑定

            //项目名称绑定--选取自运营项目
            if (HozestERPContext.Current.User.CustomerID == 7 || HozestERPContext.Current.User.CustomerID == 84 || HozestERPContext.Current.User.CustomerID == 658 || HozestERPContext.Current.User.CustomerID == 682 || HozestERPContext.Current.User.CustomerID == 670)
            {
                ddXMProject.Items.Clear();
                var projectList = base.XMProjectService.GetXMProjectList();
                Ext.Net.Store Store = ddXMProject.GetStore();
                //projectList.Add(new XMProject()
                //{
                //    ProjectName = "---所有---",
                //    Id = -1,
                //});
                Store.DataSource = projectList;
                Store.DataBind();
                Ext.Net.ListItem liProject = new Ext.Net.ListItem();
                liProject.Text = "---所有---";
                liProject.Value = "-1";
                ddXMProject.Items.Add(liProject);
                ddXMProject.Value = -1;
                //ddXMProject.SelectedIndex = 0;
                //ddXMProject.Value = "-1";
            }
            else
            {
                ddXMProject.Items.Clear();
                var projectList = base.XMProjectService.GetXMProjectListSS(HozestERPContext.Current.User.CustomerID, 0)
                    .GroupBy(p => new { p.Id, p.ProjectName })
                    .Select(p => new
                    {
                        Id = p.Key.Id,
                        ProjectName = p.Key.ProjectName
                    });
                if (projectList.Count() == 0)
                {

                    Ext.Net.ListItem liProject = new Ext.Net.ListItem();
                    liProject.Text = "---无项目权限---";
                    liProject.Value = "0";
                    ddXMProject.Items.Add(liProject);
                    ddXMProject.Value = 0;
                }
                else
                {
                    Ext.Net.Store Store = ddXMProject.GetStore();
                    Store.DataSource = projectList;
                    Store.DataBind();
                    ddXMProject.SelectedIndex = 0;
                    ddXMProject.Value = projectList.ToList()[0].Id;
                }
                Ext.Net.ListItem liProject1 = new Ext.Net.ListItem();
                liProject1.Text = "---所有---";
                liProject1.Value = "-1";
                ddXMProject.Items.Add(liProject1);
                ddXMProject.Value = -1;
            }
            #endregion

            this.ddXMProject_SelectedIndexChanged(null, null);//店铺
        }

        protected void ddXMProject_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddXMProject.Value.ToString().Trim().Length > 0)
            {
                //店铺数据源 
                if (HozestERPContext.Current.User.CustomerID == 7 || HozestERPContext.Current.User.CustomerID == 84 || HozestERPContext.Current.User.CustomerID == 658)
                {
                    var nickList = base.XMOrderInfoAPIService.GetXMNickList("", Convert.ToInt32(true), Convert.ToInt32(ddXMProject.Value));
                    ddlNick.Items.Clear();
                    Ext.Net.Store Store = ddlNick.GetStore();
                    nickList.Add(new XMNick()
                    {
                        nick = "---所有---",
                        nick_id = -1,
                    });
                    Store.DataSource = nickList.OrderBy(a => a.nick_id);
                    Store.DataBind();
                    ddlNick.SelectedIndex = 0;
                    if (!Page.IsPostBack)
                    {
                        ddlNick.Value = "-1";
                    }
                }
                else
                {
                    //其他
                    var nickList = base.XMOrderInfoAPIService.GetXMNickListSS("", Convert.ToInt32(true), Convert.ToInt32(ddXMProject.Value), HozestERPContext.Current.User.CustomerID, 0);
                    ddlNick.Items.Clear();
                    if (nickList.Count() == 0)
                    {
                        nickList.Add(new XMNick()
                        {
                            nick = "---无店铺权限---",
                            nick_id = 0,
                        });
                        Ext.Net.Store Store = ddlNick.GetStore();
                        Store.DataSource = nickList;
                        Store.DataBind();
                        ddlNick.SelectedIndex = 0;
                        if (!Page.IsPostBack)
                        {
                            ddlNick.Value = "0";
                        }
                    }
                    else
                    {
                        if (nickList.Count() > 0)
                        {
                            nickList.Insert(0, new XMNick()
                            {
                                nick = "---所有---",
                                nick_id = -1,
                            });
                            Ext.Net.Store Store = ddlNick.GetStore();
                            Store.DataSource = nickList;
                            Store.DataBind();
                            ddlNick.SelectedIndex = 0;
                            if (!Page.IsPostBack)
                            {
                                ddlNick.Value = "-1";
                            }
                        }
                    }
                }
            }
        }

        public void BindGrid(int paramPageIndex, int paramPageSize)
        {
            string paramWantID = this.txtWantID.Text.Trim();
            string paramOrderCode = this.txtOrderCode.Text.Trim();
            string paramCustomerName = this.txtCustomerName.Text.Trim();
            string paramCustomerTel = this.txtCustomerTel.Text.Trim();
            string start = dfStart.Text.Trim() == "0001/1/1 0:00:00" ? "" : dfStart.Text.Trim();
            string end = dfEnd.Text.Trim() == "0001/1/1 0:00:00" ? "" : dfEnd.Text.Trim();
            int paramIsArrangindex = this.cmIsArrange.SelectedIndex;
            int paramIsArrange = int.Parse(this.cmIsArrange.Items[paramIsArrangindex].Value);
            int paramIsInstallindex = this.cmIsInstall.SelectedIndex;
            int paramIsInstall = int.Parse(this.cmIsInstall.Items[paramIsInstallindex].Value);
            //项目名称
            int ddXMProject2 = -1;
            if (this.ddXMProject2.Value.ToString() != "")
                ddXMProject2 = Convert.ToInt32(this.ddXMProject2.Value.ToString().Trim());
            int ddlNick2 = Convert.ToInt32(this.ddlNick2.Value.ToString());//店铺
            string nickids = "";//店铺
            if (ddlNick2 == 99) //某个项目店铺权限，选择有权限的店铺
            {
                var nickList = base.XMOrderInfoAPIService.GetXMNickListSS("", -1, ddXMProject2, HozestERPContext.Current.User.CustomerID, 0);
                for (int i = 0; i < nickList.Count; i++)
                {
                    nickids = nickids + nickList[i].nick_id + ",";
                }
                if (nickids.Length > 0)
                {
                    nickids = nickids.Substring(0, nickids.Length - 1);
                }
            }
            else
            {
                nickids = ddlNick2.ToString();
            }
            //var paramList = base.XMInstallationListService.SearchXMInstallationList(paramWantID, paramOrderCode, paramCustomerName, paramCustomerTel, paramIsArrange, paramIsInstall);
            var paramList = base.XMInstallationListService.SearchXMInstallationList2(paramWantID, paramOrderCode, paramCustomerName, paramCustomerTel, paramIsArrange, paramIsInstall, ddXMProject2, nickids, start,end);//查询物流单list
            Store Store = this.GridPanel1.GetStore();
            //var pageList = new PagedList<HozestERP.BusinessLogic.ManageCustomerService.XMInstallationList>(paramList, paramPageIndex, paramPageSize, this.Master.GridViewSortField, this.Master.GridViewSortDir.ToString());
            Store.DataSource = paramList;
            Store.DataBind();
            ////paramPageSize = 20;
            //string paramWantID = this.txtWantID.Text.Trim();
            //string paramOrderCode = this.txtOrderCode.Text.Trim();
            //string paramCustomerName = this.txtCustomerName.Text.Trim();
            //string paramCustomerTel= this.txtCustomerTel.Text.Trim();
            //int paramIsArrangindex = this.cmIsArrange.SelectedIndex;
            //int paramIsArrange = int.Parse(this.cmIsArrange.Items[paramIsArrangindex].Value);
            //int paramIsInstallindex = this.cmIsInstall.SelectedIndex;
            //int paramIsInstall = int.Parse(this.cmIsInstall.Items[paramIsInstallindex].Value);
            //var paramList = base.XMInstallationListService.SearchXMInstallationList(paramWantID, paramOrderCode, paramCustomerName, paramCustomerTel, paramIsArrange, paramIsInstall);
            //Store Store = this.GridPanel1.GetStore();
            ////var pageList = new PagedList<HozestERP.BusinessLogic.ManageCustomerService.XMInstallationList>(paramList, paramPageIndex, paramPageSize, this.Master.GridViewSortField, this.Master.GridViewSortDir.ToString());
            //Store.DataSource = paramList;
            //Store.DataBind();
            //this.BindddXMProject();//项目
            //this.ddXMProject_SelectedIndexChanged(null, null);//店铺
        }

        #endregion


        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            this.BindGrid(1, Master.PageSize);
        }

        protected void Store1_Refresh(object sender, Ext.Net.StoreRefreshDataEventArgs e)
        {
            this.BindGrid(this.Master.PageIndex, Master.PageSize);
        }

        protected void Store2_Refresh(object sender, Ext.Net.StoreRefreshDataEventArgs e)
        {
            //this.Store2.DataBind();
        }


        protected void RowSelect(object sender, DirectEventArgs e)
        {
            
            int paramID = -1;
            if (e.ExtraParams["ID"]!="" && e.ExtraParams["ID"] != null) 
            {
                paramID = int.Parse(e.ExtraParams["ID"]);
            }

            var XMInstallationList = base.XMInstallationListService.GetXMInstallationListByID(paramID);

            this.BindddXMProject();//项目

            this.ddXMProject.Value = string.IsNullOrEmpty(XMInstallationList.ProjectId.ToString()) ? "-1" : XMInstallationList.ProjectId.ToString();
            this.ddXMProject_SelectedIndexChanged(null, null);//店铺
            if (XMInstallationList.NickId!=null)
            {
                this.ddlNick.Value = XMInstallationList.NickId.ToString();
            }
            else
            {
                if (HozestERPContext.Current.User.CustomerID == 7 || HozestERPContext.Current.User.CustomerID == 84 || HozestERPContext.Current.User.CustomerID == 658)
                {
                    ddlNick.Value = "-1";
                }
                else 
                {
                    ddlNick.Value = "99";
                }
            }
            this.FormPanel1.SetValues(new
            {
                XMInstallationList.ID,
                XMInstallationList.WantID,
                XMInstallationList.OrderCode,
                XMInstallationList.CustomerName,
                XMInstallationList.CustomerTel,
                XMInstallationList.InstallAddress,
                XMInstallationList.IsArrange,
                XMInstallationList.ArrangeDate,
                XMInstallationList.InstallType,
                XMInstallationList.ContactInfo,
                XMInstallationList.IsInstall,
                XMInstallationList.InstallationFee,
                XMInstallationList.PaymentDate,
                XMInstallationList.Remarks,
                
            });
            this.slbInstallType.SetValue(XMInstallationList.InstallType.ToString());

            if(XMInstallationList.WorkerID!=null)
            {
                cbPerson.Value = XMInstallationList.WorkerID.ToString();
                //int ID = (int)XMInstallationList.WorkerID;
                //cbPerson.Value = XMWorkerInfoService.getSingle(a => a.ID == ID).FullName;
            }
            else
            {
                cbPerson.Value = "";
            }
        }

        /// <summary>
        /// 修改按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Save_Click(object sender, EventArgs e)
        {
            var paramID = this.HiddenID.Text;
            if (paramID != "")
            {
                Save("Update");
            }
            else 
            {
                X.Msg.Alert("提示", "新增安装单请点击新增按钮").Show();
            }
        }

        /// <summary>
        /// 新增按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Add_Click(object sender, DirectEventArgs e)
        {
            //int returncount = base.XMInstallationListService.JudgmentRepetition(this.tfOrderCode.Text.Trim(), taInstallAddress.Text.Trim());
            var paramWantID = this.tfWantID.Text.Trim();
            //if (returncount == 0)
            //{
            //    Save("Add");
            //}
            //else
            //{
            //    X.Msg.Alert("提示", "安装单已存在，无法创建新安装单").Show();
            //}
            Save("Add");
        }

         /// <summary>
        /// 清空按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Clear_Click(object sender, DirectEventArgs e)
        {
            this.HiddenID.Text = "";
            this.tfOrderCode.Text = "";
            this.tfWantID.Text = "";
            this.tfCustomerName.Text = "";
            this.tfCustomerTel.Text = "";
            this.taInstallAddress.Text = "";
            this.chkIsArrange.Checked = false;
            this.dfArrangeDate.Value = "";
            this.slbInstallType.SelectedIndex = -1;
            cbPerson.SelectedIndex = -1;
            //this.tfContactInfo.Text = "";
            this.chkIsInstall.Checked = false;
            this.tfInstallationFee.Text = "";
            this.dfPaymentDate.Value = "";
            this.taRemarks.Text = "";
            this.ddlNick.Value = "-1";
            this.ddXMProject.Value = "-1";
        }

        /// <summary>
        /// 删除按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Delete_Click(object sender, DirectEventArgs e)
        {
             var paramID = this.HiddenID.Text;
             if (paramID != "")
             {
                 X.Msg.Confirm("提示", "确认删除?", new MessageBoxButtonsConfig
                 {
                     Yes = new MessageBoxButtonConfig
                     {
                         Handler = "X.DoYes(" + paramID + ")",
                         Text = "是"
                     },
                     No = new MessageBoxButtonConfig
                     {
                         Handler = "X.DoNo()",
                         Text = "否"
                     }
                 }).Show();

             }
             else
             {
                 X.Msg.Alert("提示", "新增数据无法删除").Show();
             }
        }

        [DirectMethod]
        public void DoYes(string paramID)
        {
            base.XMInstallationListService.DeleteXMInstallationList(int.Parse(paramID));
            X.Msg.Alert("提示", "删除成功").Show();
            this.HiddenID.Text = "";
            this.tfOrderCode.Text = "";
            this.tfWantID.Text = "";
            this.tfCustomerName.Text = "";
            this.tfCustomerTel.Text = "";
            this.taInstallAddress.Text = "";
            this.chkIsArrange.Checked = false;
            this.dfArrangeDate.Value = "";
            this.slbInstallType.SelectedIndex = -1;
            cbPerson.SelectedIndex = -1;
            //this.tfContactInfo.Text = "";
            this.chkIsInstall.Checked = false;
            this.tfInstallationFee.Text = "";
            this.dfPaymentDate.Value = "";
            this.taRemarks.Text = "";
            this.ddlNick.Value = "-1";
            this.ddXMProject.Value = "-1";
            this.BindGrid(this.Master.PageIndex, Master.PageSize);
        }
        [DirectMethod]
        public void DoNo()
        {

        }

        protected void Export_Click(object sender, Ext.Net.DirectEventArgs e)
        {
            try
            {
                //导出存放路径
                string fileName = string.Format("Exports_{0}_{1}.xls", DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss"), CommonHelper.GenerateRandomDigitCode(4));
                string filePath = string.Format("{0}Upload\\PostListExport\\{1}", HttpContext.Current.Request.PhysicalApplicationPath, fileName);

                string paramWantID = this.txtWantID.Text.Trim();
                string paramOrderCode = this.txtOrderCode.Text.Trim();
                string paramCustomerName = this.txtCustomerName.Text.Trim();
                string paramCustomerTel = this.txtCustomerTel.Text.Trim();
                string start = dfStart.Text.Trim();
                string end = dfEnd.Text.Trim();
                int paramIsArrangindex = this.cmIsArrange.SelectedIndex;
                int paramIsArrange = int.Parse(this.cmIsArrange.Items[paramIsArrangindex].Value);
                int paramIsInstallindex = this.cmIsInstall.SelectedIndex;
                int paramIsInstall = int.Parse(this.cmIsInstall.Items[paramIsInstallindex].Value);
                //项目名称
                int ddXMProject2 = -1;
                if (this.ddXMProject2.Value.ToString() != "")
                    ddXMProject2 = Convert.ToInt32(this.ddXMProject2.Value.ToString().Trim());
                int ddlNick2 = Convert.ToInt32(this.ddlNick2.Value.ToString());//店铺
                string nickids = "";//店铺
                if (ddlNick2 == 99) //某个项目店铺权限，选择有权限的店铺
                {
                    var nickList = base.XMOrderInfoAPIService.GetXMNickListSS("", -1, ddXMProject2, HozestERPContext.Current.User.CustomerID, 0);
                    for (int i = 0; i < nickList.Count; i++)
                    {
                        nickids = nickids + nickList[i].nick_id + ",";
                    }
                    if (nickids.Length > 0)
                    {
                        nickids = nickids.Substring(0, nickids.Length - 1);
                    }
                }
                else
                {
                    nickids = ddlNick2.ToString();
                }
                //var paramList = base.XMInstallationListService.SearchXMInstallationList(paramWantID, paramOrderCode, paramCustomerName, paramCustomerTel, paramIsArrange, paramIsInstall);
                var paramList = base.XMInstallationListService.SearchXMInstallationList2(paramWantID, paramOrderCode, paramCustomerName, paramCustomerTel, paramIsArrange, paramIsInstall, ddXMProject2, nickids, start, end);//查询物流单list

                base.ExportManager.ExportPostListFromInstallation(filePath, paramList);

                CommonHelper.WriteResponseXls(filePath, fileName);
            }
            catch(Exception exc)
            {
                ProcessException(exc);
            }
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="btnType">按钮类型</param>
        public void Save(string btnType)
        {
            DateTime OutDt = DateTime.Now;
            decimal outdec = new decimal();
            var paramOrderCode = this.tfOrderCode.Text.Trim();
            var paramWantID = this.tfWantID.Text.Trim();
            var paramCustomerName = this.tfCustomerName.Text.Trim();
            var paramCustomerTel = this.tfCustomerTel.Text.Trim();
            var paramInstallAddress = this.taInstallAddress.Text.Trim();
            var paramIsArrange = this.chkIsArrange.Checked;
            var paramArrangeDate = this.dfArrangeDate.Value;
            var paramInstallType = "";
            int slbInstallTypeindex = this.slbInstallType.SelectedIndex;
            if (slbInstallTypeindex >= 0)
            {
                 paramInstallType = this.slbInstallType.Items[slbInstallTypeindex].Value;
            }
            int? workID = null;
            if(cbPerson.Value!=null&& !string.IsNullOrEmpty(cbPerson.Value.ToString()))
            {
                workID = int.Parse(cbPerson.Value.ToString());
            }
            //if (!string.IsNullOrEmpty(cbPerson.Value.ToString()))
            //{
            //    workID = int.Parse(cbPerson.Value.ToString());
            //}
            var paramContactInfo = "";
            var paramIsInstall = this.chkIsInstall.Checked;
            var paramInstallationFee = this.tfInstallationFee.Text.Trim();
            var paramPaymentDate = this.dfPaymentDate.Value;
            var paramRemarks = this.taRemarks.Text.Trim();

            #region 输入数据判断
            //订单编号和安装地址作为数据判断标准必须输入
            if (string.IsNullOrEmpty(paramOrderCode) || string.IsNullOrEmpty(paramInstallAddress))
            {
                X.Msg.Alert("提示", "订单编号和安装地址必须填写正确").Show();
                return;
            }
            //安排框打勾，对应的安排时间、安装类型、师傅联系方式必须填写
            if (paramIsArrange)
            {
                if (this.dfArrangeDate.Text.Trim() == string.Empty || this.slbInstallType.SelectedIndex == -1)
                {
                    X.Msg.Alert("提示", "安排时间、安装类型输入不正确").Show();
                    return;
                }
                else 
                {
                    if (!DateTime.TryParse(this.dfArrangeDate.Text.Trim(), out OutDt)) 
                    {
                        X.Msg.Alert("提示", "安排时间格式不正确").Show();
                        return;
                    }
                }
            }
            //安装完毕打勾，对应的安装费用和付款时间必须填写
            if (paramIsInstall) 
            {
                if (this.dfPaymentDate.Text.Trim() == string.Empty || string.IsNullOrEmpty(paramInstallationFee))
                {
                    X.Msg.Alert("提示", "安装费用和付款时间必须输入").Show();
                    return;
                }
                else
                {
                    if (!DateTime.TryParse(this.dfPaymentDate.Text.Trim(), out OutDt))
                    {
                        X.Msg.Alert("提示", "付款时间格式不正确").Show();
                        return;
                    }
                    if (!decimal.TryParse(paramInstallationFee, out outdec)) 
                    {
                        X.Msg.Alert("提示", "安装费用输入不正确").Show();
                        return;
                    }
                }
            }
            #endregion

            HozestERP.BusinessLogic.ManageCustomerService.XMInstallationList paramXMInstallationList = new BusinessLogic.ManageCustomerService.XMInstallationList();
            if (btnType == "Update") 
            {
                paramXMInstallationList = base.XMInstallationListService.GetXMInstallationListByID(int.Parse(this.HiddenID.Text.Trim()));
            }
                //var paramNickId = this.ddlNick.Value;
                //var paramProjectId = this.ddXMProject.Value;
                //paramXMInstallationList.OrderCode = paramOrderCode;
                //paramXMInstallationList.WantID = paramWantID;
                //paramXMInstallationList.CustomerName = paramCustomerName;
                //paramXMInstallationList.CustomerTel = paramCustomerTel;
                //paramXMInstallationList.InstallAddress = paramInstallAddress;
                //paramXMInstallationList.IsArrange = paramIsArrange;
                //paramXMInstallationList.NickId = int.Parse(paramNickId.ToString());
                //paramXMInstallationList.ProjectId = int.Parse(paramProjectId.ToString());
                //paramXMInstallationList.CreateID = HozestERPContext.Current.User.CustomerID;
                //paramXMInstallationList.CreateDate = DateTime.Now;
                //paramXMInstallationList.UpdateID = HozestERPContext.Current.User.CustomerID;
                //paramXMInstallationList.UpdateDate = DateTime.Now;
            if (btnType == "Add") 
            {
                var paramNickId = this.ddlNick.Value;
                var paramProjectId = this.ddXMProject.Value;
                if (paramNickId.ToString() == "-1" && paramProjectId.ToString()=="-1")
                {
                    var OrderInfo = base.XMOrderInfoService.GetXMOrderInfoByOrderCode(paramOrderCode);
                    if(OrderInfo==null)
                    {
                        X.Msg.Alert("提示", "订单号不存在，请确认项目和店铺！").Show();
                        return;
                    }

                    paramXMInstallationList.NickId = OrderInfo.NickID;
                    paramXMInstallationList.ProjectId = OrderInfo.ProjectId;

                    paramXMInstallationList.OrderCode = paramOrderCode;
                    paramXMInstallationList.WantID = paramWantID;
                    paramXMInstallationList.CustomerName = paramCustomerName;
                    paramXMInstallationList.CustomerTel = paramCustomerTel;
                    paramXMInstallationList.InstallAddress = paramInstallAddress;
                    paramXMInstallationList.IsArrange = paramIsArrange;
                    paramXMInstallationList.CreateID = HozestERPContext.Current.User.CustomerID;
                    paramXMInstallationList.CreateDate = DateTime.Now;
                    paramXMInstallationList.UpdateID = HozestERPContext.Current.User.CustomerID;
                    paramXMInstallationList.UpdateDate = DateTime.Now;
                    if (paramIsArrange)
                    {
                        paramXMInstallationList.ArrangeDate = DateTime.Parse(paramArrangeDate.ToString());
                        paramXMInstallationList.InstallType = int.Parse(paramInstallType.ToString());
                        paramXMInstallationList.ContactInfo = paramContactInfo;
                        paramXMInstallationList.WorkerID = workID;
                    }
                    paramXMInstallationList.IsInstall = paramIsInstall;
                    if (paramIsInstall)
                    {
                        paramXMInstallationList.InstallationFee = decimal.Parse(paramInstallationFee.ToString());
                        paramXMInstallationList.PaymentDate = DateTime.Parse(paramPaymentDate.ToString());
                    }
                    paramXMInstallationList.Remarks = paramRemarks;
                    base.XMInstallationListService.InsertXMInstallationList(paramXMInstallationList);
                }
                else
                {
                    paramXMInstallationList.OrderCode = paramOrderCode;
                    paramXMInstallationList.WantID = paramWantID;
                    paramXMInstallationList.CustomerName = paramCustomerName;
                    paramXMInstallationList.CustomerTel = paramCustomerTel;
                    paramXMInstallationList.InstallAddress = paramInstallAddress;
                    paramXMInstallationList.IsArrange = paramIsArrange;
                    paramXMInstallationList.NickId = int.Parse(paramNickId.ToString());
                    paramXMInstallationList.ProjectId = int.Parse(paramProjectId.ToString());
                    paramXMInstallationList.CreateID = HozestERPContext.Current.User.CustomerID;
                    paramXMInstallationList.CreateDate = DateTime.Now;
                    paramXMInstallationList.UpdateID = HozestERPContext.Current.User.CustomerID;
                    paramXMInstallationList.UpdateDate = DateTime.Now;
                    if (paramIsArrange)
                    {
                        paramXMInstallationList.ArrangeDate = DateTime.Parse(paramArrangeDate.ToString());
                        paramXMInstallationList.InstallType = int.Parse(paramInstallType.ToString());
                        paramXMInstallationList.ContactInfo = paramContactInfo;
                        paramXMInstallationList.WorkerID = workID;
                    }
                    paramXMInstallationList.IsInstall = paramIsInstall;
                    if (paramIsInstall)
                    {
                        paramXMInstallationList.InstallationFee = decimal.Parse(paramInstallationFee.ToString());
                        paramXMInstallationList.PaymentDate = DateTime.Parse(paramPaymentDate.ToString());
                    }
                    paramXMInstallationList.Remarks = paramRemarks;
                    base.XMInstallationListService.InsertXMInstallationList(paramXMInstallationList);
                }
                X.Msg.Alert("提示", "新增成功").Show();
                this.BindGrid(1, Master.PageSize);
            }
            else if (btnType == "Update") 
            {
                if (this.HiddenID.Text.Trim() != string.Empty)
                {
                    var paramNickId = this.ddlNick.Value;
                    var paramProjectId = this.ddXMProject.Value;
                    paramXMInstallationList.OrderCode = paramOrderCode;
                    paramXMInstallationList.WantID = paramWantID;
                    paramXMInstallationList.CustomerName = paramCustomerName;
                    paramXMInstallationList.CustomerTel = paramCustomerTel;
                    paramXMInstallationList.InstallAddress = paramInstallAddress;
                    paramXMInstallationList.IsArrange = paramIsArrange;
                    paramXMInstallationList.NickId = int.Parse(paramNickId.ToString());
                    paramXMInstallationList.ProjectId = int.Parse(paramProjectId.ToString());
                    paramXMInstallationList.UpdateID = HozestERPContext.Current.User.CustomerID;
                    paramXMInstallationList.UpdateDate = DateTime.Now;
                    if (paramIsArrange)
                    {
                        paramXMInstallationList.ArrangeDate = DateTime.Parse(paramArrangeDate.ToString());
                        paramXMInstallationList.InstallType = int.Parse(paramInstallType.ToString());
                        paramXMInstallationList.ContactInfo = paramContactInfo;
                        paramXMInstallationList.WorkerID = workID;
                    }
                    paramXMInstallationList.IsInstall = paramIsInstall;
                    if (paramIsInstall)
                    {
                        paramXMInstallationList.InstallationFee = decimal.Parse(paramInstallationFee.ToString());
                        paramXMInstallationList.PaymentDate = DateTime.Parse(paramPaymentDate.ToString());
                    }
                    paramXMInstallationList.Remarks = paramRemarks;
                    base.XMInstallationListService.UpdateXMInstallationList(paramXMInstallationList);

                    X.Msg.Alert("提示", "修改成功").Show();
                    this.BindGrid(this.Master.PageIndex, Master.PageSize);
                }
                else 
                {
                    X.Msg.Alert("提示", "请点击新增按钮").Show();
                }
            }
        }
    }
}