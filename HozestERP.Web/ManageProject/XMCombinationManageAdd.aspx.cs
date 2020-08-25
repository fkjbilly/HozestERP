using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HozestERP.BusinessLogic.ManageCustomerService;
using HozestERP.BusinessLogic;
using HozestERP.BusinessLogic.ManageProject;
using HozestERP.Common.Utils;
using System.Web.UI.HtmlControls;
using HozestERP.Web.Modules;
using System.Transactions;
using HozestERP.Common;

namespace HozestERP.Web.ManageProject
{
    public partial class XMCombinationManageAdd : BaseAdministrationPage, ISearchPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (CombinationID == 0)
                {
                    Session["EditFirstBindGrid"] = true;
                }
                else
                {
                    Session["EditFirstBindGrid"] = false;
                }
                Session["ProductInfoList"] = null;
                Session["ProductInfoCount"] = null;
                this.BindGrid(1, Master.PageSize);
            }
        }

        #region ISearchPage 成员

        public void SetTrigger()
        {
            //this.Master.SetTrigger(this.btnSearch.UniqueID, this.Page);
            //this.Master.SetTrigger(this.btnRefresh.UniqueID, this.Page);
            //this.Master.SetTrigger(this.btnSynchronousOrderData.UniqueID, this.Page);
        }

        public void Face_Init()
        {
            this.ddlNickId.Items.Clear();
            var NickList = base.XMNickService.GetXMNickList();
            var newNickList = NickList.Where(p => p.isEnable == true).ToList();
            this.ddlNickId.DataSource = newNickList;
            this.ddlNickId.DataTextField = "nick";
            this.ddlNickId.DataValueField = "nick_id";
            this.ddlNickId.DataBind();
            this.ddlNickId.Items.Insert(0, new ListItem("---所有---", "-1"));

            this.btnProductAdd.OnClientClick = "return ShowWindowDetail('产品列表','" + CommonHelper.GetStoreLocation()
           + "ManageProject/XMCombinationManageProductList.aspx',1000, 500, this, function(){document.getElementById('"
           + this.btnRefresh.ClientID + "').click();})";
        }

        public void BindGrid(int paramPageIndex, int paramPageSize)
        {
            try
            {
                List<int> IDs = new List<int>();
                List<int> countList = new List<int>();

                if ((bool)Session["EditFirstBindGrid"] == true)
                {
                    if (Session["ProductInfoList"] != null)
                    {
                        IDs = (List<int>)Session["ProductInfoList"];

                        var xMProjectList = base.XMProductService.GetXMProductByIDs(IDs);
                        var xMProjectPageList = new PagedList<XMProduct>(xMProjectList, paramPageIndex, paramPageSize, this.Master.GridViewSortField, this.Master.GridViewSortDir.ToString());
                        this.Master.BindData(this.grdvClients, xMProjectPageList, paramPageSize + 1);

                        if (Session["ProductInfoCount"] != null)
                        {
                            countList = (List<int>)Session["ProductInfoCount"];
                            int no = 0;
                            foreach (GridViewRow item in grdvClients.Rows)
                            {
                                TextBox ddlCount = item.FindControl("ddlCount") as TextBox;
                                if (ddlCount.Visible && no <= Master.PageSize)
                                {
                                    ddlCount.Text = countList[no].ToString();
                                    no++;
                                }
                            }
                        }
                    }
                    else
                    {
                        List<XMProduct> nul = new List<XMProduct>();
                        var xMProjectPageList = new PagedList<XMProduct>(nul, paramPageIndex, paramPageSize, this.Master.GridViewSortField, this.Master.GridViewSortDir.ToString());
                        this.Master.BindData(this.grdvClients, xMProjectPageList, paramPageSize + 1);
                    }
                }
                else
                {
                    var CombinationInfo = base.XMCombinationService.GetXMCombinationByID(CombinationID);
                    this.ddlNickId.SelectedValue = CombinationInfo.NickId.ToString();
                    this.ddlProductName.Text = CombinationInfo.ProductName;
                    this.ddlProductWeight.Text = CombinationInfo.ProductWeight;
                    this.ddlManufacturersCode.Text = CombinationInfo.ManufacturersCode;
                    var IDList = base.XMProductCombinationService.GetXMProductCombinationByCombinationID(CombinationID);
                    foreach (XMProductCombination info in IDList)
                    {
                        IDs.Add((int)info.ProductID);
                    }

                    Session["ProductInfoList"] = IDs;
                    var xMProjectList = base.XMProductService.GetXMProductByIDsCount(IDs, CombinationID);
                    var xMProjectPageList = new PagedList<XMProductAddCount>(xMProjectList, paramPageIndex, paramPageSize, this.Master.GridViewSortField, this.Master.GridViewSortDir.ToString());
                    this.Master.BindData(this.grdvClients, xMProjectPageList, paramPageSize + 1);
                    int no = 0;
                    //循环grid 每行 
                    foreach (GridViewRow item in grdvClients.Rows)
                    {
                        TextBox ddlCount = item.FindControl("ddlCount") as TextBox;
                        if (ddlCount.Visible)
                        {
                            ddlCount.Text = xMProjectPageList[no].Count.ToString();
                            countList.Add((int)xMProjectPageList[no].Count);
                            no++;
                        }
                    }
                    Session["ProductInfoCount"] = countList;
                    Session["EditFirstBindGrid"] = true;
                }
            }
            catch
            {

            }
        }

        #endregion

        /// <summary>
        /// 条件查询
        /// </summary>
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            this.BindGrid(1, Master.PageSize);
        }

        protected void btnDeleteAll_Click(object sender, EventArgs e)
        {
            if (Session["ProductInfoList"] != null)
            {
                Session["ProductInfoList"] = null;
            }
            if (Session["ProductInfoCount"] != null)
            {
                Session["ProductInfoCount"] = null;
            }

            this.BindGrid(1, Master.PageSize);
        }

        /// <summary>
        /// 保存
        /// </summary>
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                int NickID = int.Parse(this.ddlNickId.SelectedValue);
                string ProductName = this.ddlProductName.Text.Trim();
                int a = 0;
                if (int.TryParse(this.ddlProductWeight.Text.Trim(), out a) == false)
                {
                    base.ShowMessage("重量必须为整数！");
                    return;
                }

                string ManufacturersCode = this.ddlManufacturersCode.Text.Trim();
                if (CombinationID == 0)
                {
                    var list = base.XMCombinationService.GetXMCombinationByManufacturersCode(ManufacturersCode);
                    if (list != null && list.Count > 1)
                    {
                        base.ShowMessage("此厂家编码在数据库中已存在！");
                        return;
                    }
                }
                List<int> countList = new List<int>();

                //循环grid 每行 
                foreach (GridViewRow item in grdvClients.Rows)
                {
                    TextBox ddlCount = item.FindControl("ddlCount") as TextBox;
                    string id = grdvClients.DataKeys[item.RowIndex].Values[0].ToString();
                    if (ddlCount.Visible)
                    {
                        //数据转换
                        if (ddlCount.Text.Trim() != "")
                        {
                            if (int.TryParse(this.ddlProductWeight.Text.Trim(), out a) == true)
                            {
                                countList.Add(int.Parse(ddlCount.Text.Trim()));
                            }
                            else
                            {
                                base.ShowMessage("数量必须为整数！");
                                return;
                            }
                        }
                        else
                        {
                            countList.Add(0);
                        }
                    }
                }

                var CombinationInfo = base.XMCombinationService.GetXMCombinationByID(CombinationID);
                int Code = 0;
                if (CombinationInfo == null)
                {
                    XMCombination info = new XMCombination();
                    info.NickId = NickID;
                    info.ProductName = ProductName;
                    info.ProductWeight = this.ddlProductWeight.Text.Trim();
                    info.ManufacturersCode = ManufacturersCode;
                    info.IsEnabled = false;
                    info.CreatorID = HozestERPContext.Current.User.CustomerID;
                    info.CreateTime = DateTime.Now;
                    info.UpdatorID = HozestERPContext.Current.User.CustomerID;
                    info.UpdateTime = DateTime.Now;
                    base.XMCombinationService.InsertXMCombination(info);
                    Code = info.ID;
                }
                else
                {
                    CombinationInfo.NickId = NickID;
                    CombinationInfo.ProductName = ProductName;
                    CombinationInfo.ProductWeight = this.ddlProductWeight.Text.Trim();
                    CombinationInfo.ManufacturersCode = ManufacturersCode;
                    CombinationInfo.UpdatorID = HozestERPContext.Current.User.CustomerID;
                    CombinationInfo.UpdateTime = DateTime.Now;
                    base.XMCombinationService.UpdateXMCombination(CombinationInfo);
                }

                List<int> IDs = (List<int>)Session["ProductInfoList"];
                //int Code = 0;
                if (CombinationID != 0)
                {
                    Code = CombinationID;
                }

                if (CombinationID != 0)
                {
                    var ProductCombinationList = base.XMProductCombinationService.GetXMProductCombinationByCombinationID(CombinationID);
                    foreach (XMProductCombination ProductCombinationInfo in ProductCombinationList)
                    {
                        ProductCombinationInfo.IsEnabled = true;
                        ProductCombinationInfo.UpdatorID = HozestERPContext.Current.User.CustomerID;
                        ProductCombinationInfo.UpdateTime = DateTime.Now;
                        base.XMProductCombinationService.UpdateXMProductCombination(ProductCombinationInfo);
                    }
                }

                if (IDs != null && IDs.Count != 0)
                {
                    for (int i = 0; i < IDs.Count; i++)
                    {
                        XMProductCombination productCom = new XMProductCombination();
                        productCom.ProductID = IDs[i];
                        productCom.CombinationID = Code;
                        productCom.Count = countList[i];
                        productCom.IsEnabled = false;
                        productCom.CreatorID = HozestERPContext.Current.User.CustomerID;
                        productCom.CreateTime = DateTime.Now;
                        productCom.UpdatorID = HozestERPContext.Current.User.CustomerID;
                        productCom.UpdateTime = DateTime.Now;
                        base.XMProductCombinationService.InsertXMProductCombination(productCom);
                    }
                }
                base.ShowMessage("保存成功！");
                Session["ProductInfoList"] = null;
            }
            catch 
            {
            
            }
        }

        /// <summary>
        /// 刷新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            this.BindGrid(1, Master.PageSize);
        }

        /// <summary>
        /// 删除行数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grdvClients_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            #region 删除
            if (e.CommandName.Equals("Del"))
            {
                List<int> IDs = new List<int>();
                List<int> countList = new List<int>();

                if (Session["ProductInfoList"] != null)
                {
                    IDs = (List<int>)Session["ProductInfoList"];
                }

                int index = 0;
                if (IDs != null)
                {
                    for (int i = 0; i < IDs.Count;i++ )
                    {
                        if (IDs[i] == Convert.ToInt32(e.CommandArgument))
                        {
                            index = i;
                            break;
                        }
                    }
                }
                IDs.Remove(Convert.ToInt32(e.CommandArgument));
                Session["ProductInfoList"] = IDs;

                //var Info = base.XMProductCombinationService.GetXMProductCombinationByIDCom(CombinationID, Convert.ToInt32(e.CommandArgument));
                //if (Info != null && Info.Count > 0)
                //{
                //    Info.IsEnabled = true;
                //    Info.UpdatorID = HozestERPContext.Current.User.CustomerID;
                //    Info.UpdateTime = DateTime.Now;
                //    base.XMProductCombinationService.UpdateXMProductCombination(Info);
                //}

                //循环grid 每行
                foreach (GridViewRow item in grdvClients.Rows)
                {
                    TextBox ddlCount = item.FindControl("ddlCount") as TextBox;
                    if (ddlCount.Visible && item.RowIndex != index)
                    {
                        //数据转换
                        if (ddlCount.Text.Trim() != "")
                        {
                            countList.Add(int.Parse(ddlCount.Text.Trim()));
                        }
                        else
                        {
                            countList.Add(0);
                        }
                    }
                }
                Session["ProductInfoCount"] = countList;

                if (IDs != null)//删除
                {
                    int rowscount = IDs.Count();//获取行数;
                    if (rowscount % this.Master.PageSize == 0)
                    {
                        this.BindGrid(this.Master.PageIndex - 1, this.Master.PageSize);
                    }
                    else
                    {
                        this.BindGrid(this.Master.PageIndex, this.Master.PageSize);
                    }
                    //base.ShowMessage("操作成功！");
                }

            }
            #endregion
        }

        public int CombinationID
        {
            get
            {
                return Convert.ToInt32(Request.Params["CombinationID"]);
            }
        }

    }

}