using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using HozestERP.BusinessLogic;
using HozestERP.BusinessLogic.CustomerManagement;
using HozestERP.BusinessLogic.ManageProject;
using HozestERP.Common;
using HozestERP.Common.Utils;
using Newtonsoft.Json.Linq;

namespace HozestERP.Web.ManageCustomer
{
    public partial class XMExpressManageList : BaseAdministrationPage, ISearchPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.btnAdd.OnClientClick = "return ShowWindowDetail('快递管理添加','" + CommonHelper.GetStoreLocation()
           + "ManageCustomer/XMExpressManageAdd.aspx?Id=0&Jurisdiction=1&Copy=0',500, 585, this, function(){document.getElementById('"
           + this.btnSearch.ClientID + "').click();});";

                //选择快递公司
                this.btnDirectThermalPrint.OnClientClick = "return CkeckShowWindowDetail(SaveExpressManageIDs(),'快递公司','" + CommonHelper.GetStoreLocation() +
            "ManageCustomer/XMChoseExpress.aspx?type=0',300,170, this, function(){document.getElementById('" + this.btnSearch.ClientID + "').click();});";

                this.BindGrid(1, Master.PageSize);
            }
        }

        public void SetTrigger()
        {
            this.Master.SetTrigger(this.btnSearch.UniqueID, this.Page);
        }

        public void Face_Init()
        {
            //部门绑定
            this.ddlDepartment.Items.Clear();
            var list = base.EnterpriseService.GetDepartmentByParentID(3, 0);
            this.ddlDepartment.DataSource = list;
            this.ddlDepartment.DataTextField = "DepName";
            this.ddlDepartment.DataValueField = "DepartmentID";
            this.ddlDepartment.DataBind();
            this.ddlDepartment.Items.Insert(0, new ListItem("---所有---", "-1"));
        }

        public void BindGrid(int paramPageIndex, int paramPageSize)
        {
            string CourierNumber = this.txtCourierNumber.Text.Trim();//寄件单号
            int DepartmentID = int.Parse(this.ddlDepartment.SelectedValue);//寄件部门
            string Sender = this.txtSender.Text.Trim();//寄件人
            string ReceivingName = this.txtReceivingName.Text.Trim();//收件人
            int Print = int.Parse(this.ddlPrint.SelectedValue);//是否打印

            List<int?> CustomerInfoIDs = new List<int?>();
            var CustomerInfoList = base.CustomerInfoService.GetCustomerInfoListInSearch(-1, Sender, -1, false);
            foreach (var info in CustomerInfoList)
            {
                CustomerInfoIDs.Add(info.CustomerID);
            }

            var list = base.XMExpressManagementService.GetXMExpressManagementListByParam(CourierNumber, DepartmentID, CustomerInfoIDs, ReceivingName, Print);

            //分页
            var List = new PagedList<XMExpressManagement>(list, paramPageIndex, paramPageSize, this.Master.GridViewSortField, this.Master.GridViewSortDir.ToString());
            this.Master.BindData(this.grdvClients, List, paramPageSize + 1);
        }

        /// <summary>
        /// 条件查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            this.BindGrid(1, Master.PageSize);
        }

        /// <summary>
        /// 刷新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            this.BindGrid(Master.PageIndex, Master.PageSize);
        }

        /// <summary>
        /// 行绑定、行操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grdvClients_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var Info = e.Row.DataItem as XMExpressManagement;

                //查看详情
                ImageButton imgBtnEdit = e.Row.FindControl("imgBtnEdit") as ImageButton;
                ImageButton imgBtnEditAll = e.Row.FindControl("imgBtnEditAll") as ImageButton;
                ImageButton imgBtnCopy = e.Row.FindControl("imgBtnCopy") as ImageButton;
                if (imgBtnEdit != null)
                {
                    imgBtnEdit.OnClientClick = "return ShowWindowDetail('快递管理编辑','" + CommonHelper.GetStoreLocation()
                   + "ManageCustomer/XMExpressManageAdd.aspx?Id=" + Info.ID + "&Jurisdiction=0&Copy=0',500, 585, this, function(){document.getElementById('"
                   + this.btnRefresh.ClientID + "').click();});";
                }
                if (imgBtnEditAll != null)
                {
                    imgBtnEditAll.OnClientClick = "return ShowWindowDetail('快递管理编辑','" + CommonHelper.GetStoreLocation()
                   + "ManageCustomer/XMExpressManageAdd.aspx?Id=" + Info.ID + "&Jurisdiction=1&Copy=0',500, 585, this, function(){document.getElementById('"
                   + this.btnRefresh.ClientID + "').click();});";
                }
                if(imgBtnCopy!=null)
                {
                    imgBtnCopy.OnClientClick = "return ShowWindowDetail('快递管理复制','" + CommonHelper.GetStoreLocation()
                   + "ManageCustomer/XMExpressManageAdd.aspx?Id=" + Info.ID + "&Jurisdiction=1&Copy=1',500, 585, this, function(){document.getElementById('"
                   + this.btnSearch.ClientID + "').click();});";
                }
            }
        }

        /// <summary>
        /// 删除行数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grdvClients_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            #region 删除
            if (e.CommandName.Equals("ToDelete"))
            {
                var Info = base.XMExpressManagementService.GetXMExpressManagementByID(Convert.ToInt32(e.CommandArgument));
                if (Info != null)//删除
                {
                    if (!string.IsNullOrEmpty(Info.CourierNumber))
                    {
                        base.ShowMessage("请先取消寄件单号，再删除记录！");
                        return;
                    }

                    if (Info.Price != null)
                    {
                        base.ShowMessage("已填写价格的快递单不能删除！");
                        return;
                    }

                    Info.IsEnable = true;
                    Info.UpdateID = HozestERPContext.Current.User.CustomerID;
                    Info.UpdateDate = DateTime.Now;
                    base.XMExpressManagementService.UpdateXMExpressManagement(Info);

                    string CourierNumber = this.txtCourierNumber.Text.Trim();//寄件单号
                    int DepartmentID = int.Parse(this.ddlDepartment.SelectedValue);//寄件部门
                    string Sender = this.txtSender.Text.Trim();//寄件人
                    string ReceivingName = this.txtReceivingName.Text.Trim();//收件人
                    int Print = int.Parse(this.ddlPrint.SelectedValue);//是否打印
                    List<int?> CustomerInfoIDs = new List<int?>();
                    var CustomerInfoList = base.CustomerInfoService.GetCustomerInfoListInSearch(-1, Sender, -1, false);
                    foreach (var info in CustomerInfoList)
                    {
                        CustomerInfoIDs.Add(info.CustomerID);
                    }
                    var list = base.XMExpressManagementService.GetXMExpressManagementListByParam(CourierNumber, DepartmentID, CustomerInfoIDs, ReceivingName, Print);
                    int rowscount = list.Count();//获取行数;

                    if (rowscount % this.Master.PageSize == 0)
                    {
                        this.BindGrid(this.Master.PageIndex - 1, this.Master.PageSize);
                    }
                    else
                    {
                        this.BindGrid(this.Master.PageIndex, this.Master.PageSize);
                    }

                    base.ShowMessage("操作成功！");
                }
            }
            else if(e.CommandName.Equals("toLogisticsInfo"))
            {
                string url = "https://www.kuaidi100.com/chaxun?";
                var Info = base.XMExpressManagementService.GetXMExpressManagementByID(Convert.ToInt32(e.CommandArgument));
                if(Info!=null)
                {
                    if(Info.ExpressID!=null&&!string.IsNullOrEmpty(Info.CourierNumber))
                    {
                        var xmCompanyCustom = XMCompanyCustomService.GetXMCompanyCustomByLogisticId(Info.ExpressID.ToString());
                        if (xmCompanyCustom != null)
                        {
                            url = url + "com=" + xmCompanyCustom.Code + "&nu=" + Info.CourierNumber;
                        }
                    }
                }

                //源地址 https://www.kuaidi100.com/chaxun?com=yunda&nu=1500066330925

                Window1.AutoLoad.Url = url;
                Window1.AutoLoad.Mode = Ext.Net.LoadMode.IFrame;
                Window1.AutoLoad.ShowMask = true;
                Window1.AutoLoad.MaskMsg = "正在加载中...";
                Window1.Render();
                Window1.Show();
            }
            #endregion
        }

        /// <summary>
        /// 取消面单号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnCancelWaybill_Click(object sender, EventArgs e)
        {
            List<int> IDs = this.Master.GetSelectedIds(this.grdvClients);
            if (IDs.Count <= 0)
            {
                base.ShowMessage("你没有选择任何记录！");
                return;
            }
            else
            {
                List<int> Ids = GetRoleMappingIds(HozestERPContext.Current.User.CustomerID);//该用户所拥有角色所包含的用户，及可操作的用户
                List<XMExpressManagement> list = new List<XMExpressManagement>();
                foreach (int ID in IDs)
                {
                    var Info = base.XMExpressManagementService.GetXMExpressManagementByID(ID);
                    if (Info != null)
                    {
                        if (string.IsNullOrEmpty(Info.CourierNumber))
                        {
                            base.ShowMessage("收件人：" + Info.ReceivingName + "，的快递单还没有寄件单号，不能取消寄件单号！");
                            return;
                        }
                        if (Info.Price != null)
                        {
                            base.ShowMessage("收件人：" + Info.ReceivingName + "，的快递单已填写价格，不能取消寄件单号！");
                            return;
                        }
                        if (!Ids.Contains((int)Info.SenderID))
                        {
                            base.ShowMessage("收件人：" + Info.ReceivingName + "，的快递单,您没有权限取消寄件单号！");
                            return;
                        }
                        list.Add(Info);
                    }
                }

                string str = base.XMOrderInfoAPIService.CancelWaybill(list);
                if (str == "")
                {
                    base.ShowMessage("取消寄件单号成功！");
                }
                else
                {
                    base.ShowMessage(str);
                }
            }

            this.BindGrid(Master.PageIndex, Master.PageSize);
        }

        /// <summary>
        /// 该角色下的包含用户
        /// </summary>
        /// <returns></returns>
        public List<int> GetRoleMappingIds(int UserId)
        {
            List<int> Ids = new List<int>();
            Ids.Add(UserId);
            var Roles = base.CustomerService.GetCustomerRolesByCustomerId(UserId);
            if (Roles != null && Roles.Count > 0)
            {
                foreach (var role in Roles)
                {
                    var ids = base.CustomerService.GetCustomerInfosByRoleID(role.CustomerRoleID);
                    if (ids != null && ids.Count > 0)
                    {
                        Ids.AddRange(ids.Select(x => x.CustomerID).ToList());
                    }
                }
            }
            return Ids.Distinct().ToList();
        }
    }
}