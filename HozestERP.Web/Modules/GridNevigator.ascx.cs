using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using HozestERP.Common;

namespace HozestERP.Web.Modules
{
    public partial class GridNevigator : BaseAdministrationUserControl
    {
        #region 定义控件属性

        #region public int PageSize
        /// <summary>
        /// 页面显示行数
        /// </summary>
        public int PageSize
        {
            set
            {
                if (this.ddlPageSize.Items.Count == 0)
                {
                    this.SetDll();
                }
                ListItem myListItem = this.ddlPageSize.Items.FindByValue(value.ToString());
                if (myListItem != null)
                {
                    ddlPageSize.SelectedValue = value.ToString();
                }
                else
                {
                    //throw new Exception("分页控件不支持每页显示 " + value.ToString() + "行");
                }

            }
            get
            { return int.Parse(ddlPageSize.SelectedValue); }
        }
        #endregion

        #region public int PageIndex
        /// <summary>
        /// 当前页码
        /// </summary>
        public int PageIndex
        {
            set { this.lblCurrent.Text = value.ToString(); }
            get {
                return !string.IsNullOrEmpty(this.lblCurrent.Text) ? Convert.ToInt32(this.lblCurrent.Text) : 1;
            }
        }
        #endregion

        #region public int PageCount
        /// <summary>
        /// 总共页数
        /// </summary>
        public int PageCount
        {
            set { this.lblPageCount.Text = value.ToString(); }
            get { return !string.IsNullOrEmpty(this.lblPageCount.Text) ? Convert.ToInt32(this.lblPageCount.Text) : 0; }
        }
        #endregion

        #region public int RecordCount
        /// <summary>
        /// 总共记录数
        /// </summary>
        public int RecordCount
        {
            set { this.lblRowsCount.Text = value.ToString(); }
            get { return !string.IsNullOrEmpty(this.lblRowsCount.Text) ? Convert.ToInt32(this.lblRowsCount.Text) : 0; }
        }
        #endregion

        //public string ddlPageSizeID
        //{
        //    get { return this.ddlPageSize.UniqueID; }
        //}

        #endregion

        #region 重置控件属性

        private void InitButtonState()
        {
            this.ddlPageSize.Enabled = false;
            this.imgbtnFirst.Enabled = false;
            //this.imgbtnFirst.CssClass = "graybtn";
            this.imgbtnFirst.ImageUrl = this.imgbtnFirst.ImageUrl.Replace("icon_page_First.gif", "icon_page_First_gray.gif");
            this.imgbtnPre.Enabled = false;
            //this.imgbtnPre.CssClass = "graybtn";
            //this.imgbtnPre.ImageUrl = @"~/Skins/Default/image/icon_page_pre_gray.gif";
            this.imgbtnPre.ImageUrl = this.imgbtnPre.ImageUrl.Replace("icon_page_front.gif", "icon_page_front_gray.gif");
            this.imgbtnEnd.Enabled = false;
            //this.imgbtnEnd.CssClass = "graybtn";
            //this.imgbtnEnd.ImageUrl = @"~/Skins/Default/image/icon_page_end_gray.gif";
            this.imgbtnEnd.ImageUrl = this.imgbtnEnd.ImageUrl.Replace("icon_page_end.gif", "icon_page_end_gray.gif");
            this.imgbtnNext.Enabled = false;
            //this.imgbtnNext.CssClass = "graybtn";
            //this.imgbtnNext.ImageUrl = @"~/Skins/Default/image/icon_page_next_gray.gif";
            this.imgbtnNext.ImageUrl = this.imgbtnNext.ImageUrl.Replace("icon_page_next.gif", "icon_page_next_gray.gif");
            this.txtGoto.Enabled = false;
            this.imgbtnGo.Enabled = false;
            //this.imgbtnGo.CssClass = "graybtn";
            //this.imgbtnGo.ImageUrl = @"~/Skins/Default/image/icon_page_go_gray.gif";
            this.imgbtnGo.ImageUrl = this.imgbtnGo.ImageUrl.Replace("icon_page_go.gif", "icon_page_go_gray.gif");
        }

        private void setLblData()
        {
            this.lblCurrent.Text = "0";
            this.lblPageCount.Text = "0";
            this.lblRowsCount.Text = "0";
        }

        #endregion

        #region private void SetButtonState()
        /// <summary>
        /// 设置控件状态
        /// </summary>
        private void SetButtonState()
        {
            this.InitButtonState();
            if (this.PageCount >= 1)
            {
                this.ddlPageSize.Enabled = true;
                if (this.PageIndex <= this.PageCount)
                {
                    if (this.PageIndex > 1)
                    {
                        this.imgbtnFirst.Enabled = true;
                        //this.imgbtnFirst.CssClass = "";
                        //this.imgbtnFirst.ImageUrl = @"~/Skins/Default/image/icon_page_front.gif";
                        this.imgbtnFirst.ImageUrl = this.imgbtnFirst.ImageUrl.Replace("icon_page_First_gray.gif", "icon_page_First.gif");
                        this.imgbtnPre.Enabled = true;
                        //this.imgbtnPre.CssClass = "";
                        //this.imgbtnPre.ImageUrl = @"~/Skins/Default/image/icon_page_pre.gif";
                        this.imgbtnPre.ImageUrl = this.imgbtnPre.ImageUrl.Replace("icon_page_front_gray.gif", "icon_page_front.gif");
                    }

                    if (this.PageIndex != this.PageCount)
                    {
                        this.imgbtnEnd.Enabled = true;
                        //this.imgbtnEnd.CssClass = "";
                        //this.imgbtnEnd.ImageUrl = @"~/Skins/Default/image/icon_page_end.gif";
                        this.imgbtnEnd.ImageUrl = this.imgbtnEnd.ImageUrl.Replace("icon_page_end_gray.gif", "icon_page_end.gif");
                        this.imgbtnNext.Enabled = true;
                        //this.imgbtnNext.CssClass = "";
                        //this.imgbtnNext.ImageUrl = @"~/Skins/Default/image/icon_page_next.gif";
                        this.imgbtnNext.ImageUrl = this.imgbtnNext.ImageUrl.Replace("icon_page_next_gray.gif", "icon_page_next.gif");
                    }

                }
                if (this.PageCount >= 1)
                {
                    this.txtGoto.Enabled = true;
                    this.imgbtnGo.Enabled = true;
                    //this.imgbtnGo.CssClass = "";
                    //this.imgbtnGo.ImageUrl = @"~/Skins/Default/image/icon_page_go.gif";
                    this.imgbtnGo.ImageUrl = this.imgbtnGo.ImageUrl.Replace("icon_page_go_gray.gif", "icon_page_go.gif");
                }

            }
        }
        #endregion

        /// <summary>
        /// 自定义翻页控件的页码委托
        /// </summary>
        public delegate void PageChangeHandler(object sender, OnChageEventArg e);

        public event PageChangeHandler PageChange;

        /// <summary>
        /// 自定义翻页控件的页码委托
        /// </summary>
        public delegate void PageSizeChangeHandler(object sender, OnChageEventArg e);

        public event PageSizeChangeHandler PageSizeChange;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // 设置下拉框
                this.SetDll();
            }
        }

        private void SetDll()
        {
            if (this.ddlPageSize.Items.Count == 0) { 
                this.ddlPageSize.Items.Insert(0, new ListItem("10", "10"));
                this.ddlPageSize.Items.Insert(1, new ListItem("50", "50"));
                this.ddlPageSize.Items.Insert(2, new ListItem("100", "100"));
            }
           
            this.ddlPageSize.SelectedValue = this.PageSize.ToString();

            //if (this.ddlPageSize.Items.Count == 0)
            //{
            //    for (int i = 10; i <= 100; i += 50)
            //    {
            //        this.ddlPageSize.Items.Add(new ListItem(i.ToString(), i.ToString()));
            //    }
            //}
            //this.ddlPageSize.SelectedValue = this.PageSize.ToString();


        }

        #region public void BindData<T>(GridView paramGrid, PagedList<T> paramDv)
        /// <summary>
        /// 绑定指定的页数数据到GRID,
        /// </summary>
        /// <param name="paramGrid"></param>
        /// <param name="paramDv"></param>
        /// <param name="paramPageIndex"></param>
        public void BindData<T>(GridView paramGrid, PagedList<T> paramDv)
        {
            setLblData();

            paramGrid.AllowPaging = true;
            paramGrid.PagerSettings.Visible = false;

            paramGrid.PageIndex = paramDv.PageIndex;
            paramGrid.PageSize = paramDv.PageSize;

            paramGrid.DataSource = paramDv;
            paramGrid.DataBind();

            this.PageCount = paramDv.TotalPages;
            this.PageSize = paramDv.PageSize;
            this.PageIndex = paramDv.PageIndex;
            this.RecordCount = paramDv.TotalCount;

            this.imgbtnGo.Attributes.Add("onclick", "return CheckInputPageIndex('" + this.txtGoto.ClientID + "','" + this.PageCount.ToString() + "');");
            this.SetButtonState();
        }
        
        /// <summary>
        /// 绑定指定的页数数据到GRID,
        /// </summary>
        /// <param name="paramGrid"></param>
        /// <param name="paramDv"></param>
        /// <param name="paramPageIndex"></param>
        public void BindData<T>(GridView paramGrid, PagedList<T> paramDv, int pageSize)
        {
            setLblData();

            paramGrid.AllowPaging = true;
            paramGrid.PagerSettings.Visible = false;

            paramGrid.PageIndex = paramDv.PageIndex;
            paramGrid.PageSize = pageSize;

            paramGrid.DataSource = paramDv;
            paramGrid.DataBind();

            this.PageCount = paramDv.TotalPages;
            this.PageSize = paramDv.PageSize;
            this.PageIndex = paramDv.PageIndex;
            this.RecordCount = paramDv.TotalCount;

            this.imgbtnGo.Attributes.Add("onclick", "return CheckInputPageIndex('" + this.txtGoto.ClientID + "','" + this.PageCount.ToString() + "');");
            this.SetButtonState();
        }
        #endregion


        #region public void BindData<T>(GridView paramGrid, PagedList<T> paramDv)
        /// <summary>
        /// 绑定指定的页数数据到GRID,
        /// </summary>
        /// <param name="paramGrid"></param>
        /// <param name="paramDv"></param>
        /// <param name="paramPageIndex"></param>
        public void BindData<T>(Repeater paramGrid, PagedList<T> paramDv)
        {
            setLblData();

            paramGrid.DataSource = paramDv;
            paramGrid.DataBind();

            this.PageCount = paramDv.TotalPages;
            this.PageSize = paramDv.PageSize;
            this.PageIndex = paramDv.PageIndex;
            this.RecordCount = paramDv.TotalCount;

            this.imgbtnGo.Attributes.Add("onclick", "return CheckInputPageIndex('" + this.txtGoto.UniqueID + "','" + this.PageCount.ToString() + "');");
            this.SetButtonState();
        }
        #endregion

        protected void ddlPageSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.PageSize = int.Parse(this.ddlPageSize.SelectedValue);
            if (PageSizeChange != null)
            {
                OnChageEventArg myArg = new OnChageEventArg(this.PageIndex, this.PageSize);
                PageSizeChange(sender, myArg);
                if(this.Page.AppRelativeVirtualPath.Contains("xmproductmanage.aspx"))
                    ScriptManager.RegisterStartupScript(this, typeof(UpdatePanel), "", "TopSuppliers();", true);
            }
        }

        public void SetPageSize(int paramPageSize)
        {

        }

        protected void imgbtn_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton myBtn = (ImageButton)sender;
            switch (myBtn.CommandName.ToUpper())
            {
                case "FIRST":
                    this.PageIndex = 1;
                    break;
                case "NEXT":
                    this.PageIndex++;
                    break;
                case "PRE":
                    this.PageIndex--;
                    break;
                case "END":
                    this.PageIndex = this.PageCount;
                    break;
                case "GOTO":
                    this.PageIndex = int.Parse(this.txtGoto.Text.Trim());
                    break;
            }
            OnChageEventArg myArg = new OnChageEventArg(this.PageIndex, this.PageSize);
            PageChange(sender, myArg);
            if(this.Page.AppRelativeVirtualPath.Contains("xmproductmanage.aspx"))
                ScriptManager.RegisterStartupScript(this, typeof(UpdatePanel), "", "TopSuppliers();", true);
        }
    }

    public class OnChageEventArg : EventArgs
    {
        public int newPageIndex;
        public int newPageSize;

        public OnChageEventArg(int paramNewPageIndex, int paramNewPageSize)
        {
            this.newPageIndex = paramNewPageIndex;
            this.newPageSize = paramNewPageSize;
        }
    }
}
