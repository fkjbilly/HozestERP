using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Reflection;
using System.Collections;
using System.Data;

using HozestERP.Common.Utils;
using HozestERP.Web.Modules;
using HozestERP.Common;

namespace HozestERP.Web.MasterPages
{
  
    public partial class TwoCommon : BaseAdministrationMasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public bool CanRowClickColor = true;

        public ArrayList FixCol = new ArrayList();

        /// <summary>
        /// 
        /// </summary>
        public bool SetSearchPanelVisible
        {
            set
            {
                this.trTitle2.Visible = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool SetActionPanelVisible
        {
            set
            {
                this.tdContent2.Visible = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool SetTitleVisible
        {
            set
            {
                this.trTitle.Visible = value;
            }
        }

        public int PageIndex
        {
            get { return this.GridNevigator1.PageIndex; }
            set { this.GridNevigator1.PageIndex = value; }
        }

        public int PageSize
        {
            get
            {
                try
                {
                    if (this.GridNevigator1.PageSize <= 0)
                    {
                        return 10;
                    }
                    return this.GridNevigator1.PageSize;
                }
                catch
                {
                }

                return 10;
            }
            set { this.GridNevigator1.PageSize = value; }
        }

       
       

        public void SetTrigger(string triggerId, Page currentPage)
        {
            AsyncPostBackTrigger trigger = new AsyncPostBackTrigger();
            trigger.ControlID = triggerId;
            this.UpdatePanel1.Triggers.Add(trigger);
            if (ScriptManager.GetCurrent(currentPage).IsInAsyncPostBack) { triggerInitMethod.Invoke(trigger, null); }


            AsyncPostBackTrigger trigger2 = new AsyncPostBackTrigger();
            trigger2.ControlID = triggerId;
            this.UpdatePanel2.Triggers.Add(trigger2);
            if (ScriptManager.GetCurrent(currentPage).IsInAsyncPostBack) { triggerInitMethod.Invoke(trigger2, null); }
        }

        private static MethodInfo triggerInitMethod = typeof(UpdatePanelTrigger).GetMethod("Initialize", BindingFlags.NonPublic | BindingFlags.Instance);


        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);



            // 加自定义控件事件
            this.GridNevigator1.PageChange += new GridNevigator.PageChangeHandler(GridNevigator1_PageChange);
            this.GridNevigator1.PageSizeChange += new GridNevigator.PageSizeChangeHandler(GridNevigator1_PageSizeChange);
            ((ISearchPage)this.Page).SetTrigger();
            ((ISearchPage)this.Page).Face_Init();

            SetJsPageLoad();

            Page.Header.Controls.Add(new LiteralControl(@"<script type=""text/javascript"" src=""" + CommonHelper.GetStoreLocation() + @"Script/CommonManager.js"" ></script>"));
            Page.Header.Controls.Add(new LiteralControl(@"<script type=""text/javascript"" src=""" + CommonHelper.GetStoreLocation() + @"Script/AjaxError.js"" ></script>"));
      
            //// 加自定义控件事件 
            //((IEditPage)this.Page).Face_Init();
            //((IEditPage)this.Page).SetTrigger();

            //Page.Header.Controls.Add(new LiteralControl(@"<script type=""text/javascript"" src=""" + CommonHelper.GetStoreLocation() + @"Script/CommonManager.js"" ></script>"));
            //Page.Header.Controls.Add(new LiteralControl(@"<script type=""text/javascript"" src=""" + CommonHelper.GetStoreLocation() + @"Script/CommonEdit.js"" ></script>"));
            //Page.Header.Controls.Add(new LiteralControl(@"<script type=""text/javascript"" src=""" + CommonHelper.GetStoreLocation() + @"Script/AjaxError.js"" ></script>"));
            ////this.imgExpand.Attributes.Add("onclick", "Expand('" + this.tdContentPlaceHolder1.ClientID + "','" + this.tdContentPlaceHolder01.ClientID + "',this);return false;");

            //string path = CommonHelper.GetStoreLocation() + "App_Themes/" + base.Page.Theme;
            //this.JsBaseWrite("imgCloseExpandSrc='" + path + "/Image/btn2down.gif';", "InitUp");
            //this.JsBaseWrite("imgOpenExpandSrc='" + path + "/Image/btn2up.gif';", "InitDown");
        }

        public void GridNevigator1_PageSizeChange(object sender, OnChageEventArg e)
        {
            this.GridNevigator1.PageIndex = 1;
            // 改变页面大小
            ((ISearchPage)this.Page).BindGrid(1, e.newPageSize);

        }

        public void GridNevigator1_PageChange(object sender, OnChageEventArg e)
        {
            // 改变页码
            ((ISearchPage)this.Page).BindGrid(e.newPageIndex, e.newPageSize);
        }

        public void BindData<T>(GridView mygrid, PagedList<T> gridSource, int pageSize)
        {
            // 设置表格线
            mygrid.Attributes.Add("bordercolor", "#ababab");

            if (gridSource.Count > 0)
            {
                // 如果有数据就绑定数据
                this.GridNevigator1.BindData(mygrid, gridSource, pageSize);
                this.SetRowStyle(mygrid);
                this.GridTable.Style.Add("display", "''");
                this.GridFoot.Visible = true;
                this.GridNevigator1.Visible = true;
            }
            else
            {
                // 如果有数据就绑定数据
                this.GridNevigator1.BindData(mygrid, gridSource, pageSize);
                //this.GridTable.Style.Add("display", "'none'");
                this.SetRowStyle(mygrid);
                this.GridTable.Style.Add("display", "''");
                this.GridFoot.Visible = true;
                this.GridNevigator1.Visible = true;
                // this.JsWrite("alert('没有您要查看的数据');", "EmptyData");
            }
            // 设置表头样式
            this.SetGridHeadStyle(mygrid);
            JsWrite("AutoDivHeight('" + this.GridTable.ClientID + "','" + this.tdGrid.ClientID + "','"
                                    + this.tablework.ClientID + "','" + this.DivGrid.ClientID + "','"
                                    + this.tdtdGrid.ClientID + "');", "AutoDiv");
            JsWrite("AutoDivWidth('" + this.DivGrid.ClientID + "','" + mygrid.ClientID + "');", "AutoDivWidth");
        }

        public void BindData<T>(GridView mygrid, PagedList<T> gridSource)
        {
            mygrid.SortedAscendingHeaderStyle.CssClass = "";
            // 设置表格线
            mygrid.Attributes.Add("bordercolor", "#ababab");

            if (gridSource.Count > 0)
            {
                // 如果有数据就绑定数据
                this.GridNevigator1.BindData(mygrid, gridSource);
                this.SetRowStyle(mygrid);
                this.GridTable.Style.Add("display", "''");
                this.GridFoot.Visible = true;
                this.GridNevigator1.Visible = true;
            }
            else
            {
                // 如果有数据就绑定数据
                this.GridNevigator1.BindData(mygrid, gridSource);
                //this.GridTable.Style.Add("display", "'none'");
                this.SetRowStyle(mygrid);
                this.GridTable.Style.Add("display", "''");
                this.GridFoot.Visible = true;
                this.GridNevigator1.Visible = true;
                // this.JsWrite("alert('没有您要查看的数据');", "EmptyData");
            }
            // 设置表头样式
            this.SetGridHeadStyle(mygrid);
            JsWrite("AutoDivHeight('" + this.GridTable.ClientID + "','" + this.tdGrid.ClientID + "','"
                                    + this.tablework.ClientID + "','" + this.DivGrid.ClientID + "','"
                                    + this.tdtdGrid.ClientID + "');", "AutoDiv");
            JsWrite("AutoDivWidth('" + this.DivGrid.ClientID + "','" + mygrid.ClientID + "');", "AutoDivWidth");
        } 

        public void BindData(GridView mygrid, DataTable gridSource)
        {
            // 设置表格线
            mygrid.Attributes.Add("bordercolor", "#ababab");

            if (gridSource.Rows.Count > 0)
            {
                // 如果有数据就绑定数据
                mygrid.DataSource = gridSource;
                mygrid.DataBind();
                this.SetRowStyle(mygrid);
                this.GridTable.Style.Add("display", "''");
                this.GridFoot.Visible = false;
                this.GridNevigator1.Visible = false;
            }
            else
            {
                // 如果有数据就绑定数据
                mygrid.DataSource = gridSource;
                mygrid.DataBind();
                this.GridTable.Style.Add("display", "'none'");
                this.GridFoot.Visible = false;
                this.GridNevigator1.Visible = false;
                this.JsWrite("alert('没有您要查看的数据');", "EmptyData");
            }
            // 设置表头样式
            this.SetGridHeadStyle(mygrid);
            JsWrite("AutoDivHeight('" + this.GridTable.ClientID + "','" + this.tdGrid.ClientID + "','"
                                    + this.tablework.ClientID + "','" + this.DivGrid.ClientID + "','"
                                    + this.tdtdGrid.ClientID + "');", "AutoDiv");
            JsWrite("AutoDivWidth('" + this.DivGrid.ClientID + "','" + mygrid.ClientID + "');", "AutoDivWidth");
        }

        public void BindData<T>(Repeater mygrid, PagedList<T> gridSource)
        {
            if (gridSource.Count > 0)
            {
                // 如果有数据就绑定数据
                this.GridNevigator1.BindData(mygrid, gridSource);
                this.GridTable.Style.Add("display", "''");
                this.GridFoot.Visible = true;
                this.GridNevigator1.Visible = true;
            }
            else
            {
                // 如果有数据就绑定数据
                this.GridNevigator1.BindData(mygrid, gridSource);
                this.GridTable.Style.Add("display", "''");
                this.GridFoot.Visible = true;
                this.GridNevigator1.Visible = true;
            }
        }

        #region public void SetRowStyle(GridView myGrid)
        /// <summary>
        /// 设置行样式
        /// </summary>
        /// <param name="myGrid"></param>
        public void SetRowStyle(GridView myGrid)
        {
            CheckBox myChk = null;
            if (CanRowClickColor)
            {
                for (int i = 0; i < myGrid.Rows.Count; i++)
                {

                    myChk = (CheckBox)myGrid.Rows[i].Cells[0].FindControl("chkSelected");
                    myGrid.Rows[i].Style.Add("height", "5px");

                    if (myGrid.EditIndex != i)
                    {
                        if (myChk != null)
                        {
                            if (myChk.Visible)
                            {
                                myGrid.Rows[i].Attributes.Add("onclick", "RowColorIn('" + myChk.ClientID + "',this);");
                                myChk.Attributes.Add("onclick", "SelectChange(this);");
                            }
                        }
                        else
                        {
                            myGrid.Rows[i].Attributes.Add("onclick", "RowColorIn('',this);");
                        }
                        if (myGrid.Rows[i].RowState == DataControlRowState.Alternate)
                        {
                            if (myGrid.Rows[i].Attributes["OldColor"] == null)
                            {
                                myGrid.Rows[i].Attributes.Add("OldColor", "#F7F7F7");
                            }
                        }
                        else
                        {
                            if (myGrid.Rows[i].Attributes["OldColor"] == null)
                            {
                                myGrid.Rows[i].Attributes.Add("OldColor", "#FFFFFF");
                            }
                        }
                    }
                    // 设定固定列
                    if (FixCol.Count > 0)
                    {
                        for (int j = 0; j < FixCol.Count; j++)
                        {
                            //myGrid.Rows[i].Cells[Convert.ToInt32(FixCol[j])].Style.Add("left", "expression(this.offsetParent.scrollLeft)");
                            //myGrid.Rows[i].Cells[Convert.ToInt32(FixCol[j])].Style.Add("z-index", "1000");
                            myGrid.Rows[i].Cells[Convert.ToInt32(FixCol[j])].CssClass = "fixCol";
                        }
                    }

                }
            }
        }
        #endregion

        #region public void SetGridHeadStyle(GridView myGrid)
        /// <summary>
        /// 设置表头样式
        /// </summary>
        /// <param name="myGrid"></param>
        public void SetGridHeadStyle(GridView myGrid)
        {
            if (myGrid.HeaderRow == null)
            {
                return;
            }

            myGrid.Style.Add("word-break", "keep-all");
            myGrid.Style.Add("word-wrap", "normal");

            myGrid.HeaderRow.Style.Add("height", "22px");
            // 表头处理
            int CellsCount = myGrid.HeaderRow.Cells.Count;
            for (int j = 0; j < CellsCount; j++)
            {

                myGrid.HeaderRow.Cells[j].Attributes.Add("class", "GridHeard");
                //myGrid.HeaderRow.Cells[j].Attributes.Add("onmouseover", "SetHeadCellsCss('Over',this);");
                //myGrid.HeaderRow.Cells[j].Attributes.Add("onmouseout", "SetHeadCellsCss('out',this);");
                myGrid.HeaderRow.Cells[j].Attributes.Add("noWrap", "noWrap");
                //如果有设置排序码的话就设置排序事件
                if (myGrid.Columns[j].SortExpression != null & myGrid.Columns[j].SortExpression != string.Empty)
                {
                    myGrid.HeaderRow.Cells[j].Attributes.CssStyle.Add("cursor", "pointer");
                    myGrid.HeaderRow.Cells[j].Attributes.Add("onclick", "HeadClick('" + myGrid.Columns[j].SortExpression + "','"
                        + this.btnGridViewSort.ClientID + "','" + this.hidGridViewSortField.ClientID + "')");

                    myGrid.HeaderRow.Cells[j].Attributes.Add("oncontextmenu", "HeadClick('" + myGrid.Columns[j].SortExpression + "','"
                        + this.btnGridViewSort.ClientID + "','" + this.hidGridViewSortField.ClientID + "'); return false;");


                    if (this.GridViewSortField.ToString().Trim().Length > 0 && myGrid.Columns[j].SortExpression == this.GridViewSortField)
                    {
                        if (this.GridViewSortDir == GridViewTwoSortDirEnum.DESC)
                        {
                            myGrid.HeaderRow.Cells[j].Attributes.CssStyle.Add("background-image", "url('" + CommonHelper.GetStoreLocation() + "app_themes/blue/image/down.gif')");
                            myGrid.HeaderRow.Cells[j].Attributes.CssStyle.Add("background-position", "right center;");
                            myGrid.HeaderRow.Cells[j].Attributes.CssStyle.Add("background-repeat", "no-repeat");
                        }
                        else
                        {
                            myGrid.HeaderRow.Cells[j].Attributes.CssStyle.Add("background-image", "url('" + CommonHelper.GetStoreLocation() + "app_themes/blue/image/up.gif')");
                            myGrid.HeaderRow.Cells[j].Attributes.CssStyle.Add("background-position", "right center;");
                            myGrid.HeaderRow.Cells[j].Attributes.CssStyle.Add("background-repeat", "no-repeat");
                        }
                    }
                }
                // 设定固定列
                if (FixCol.Contains(j))
                {
                    myGrid.HeaderRow.Cells[j].Style.Add("left", "expression(this.offsetParent.scrollLeft)");
                    myGrid.HeaderRow.Cells[j].Style.Add("z-index", "1000");
                }
                if (myGrid.Columns.Count <= j)
                {
                    continue;
                }
            }
        }

        protected void btnGridViewSort_Click(object sender, EventArgs e)
        {
            if (this.hidGridViewSortField.Value == this.GridViewSortField)
            {
                if (this.GridViewSortDir == GridViewTwoSortDirEnum.DESC)
                {
                    this.GridViewSortDir = GridViewTwoSortDirEnum.ASC;
                }
                else
                {
                    this.GridViewSortDir = GridViewTwoSortDirEnum.DESC;
                }
            }
            else
            {
                this.GridViewSortField = this.hidGridViewSortField.Value;
            }
            // 改变页面大小
            ((ISearchPage)this.Page).BindGrid(1, this.PageSize);
        }
        #endregion

         

        #region public void JsWrite(string paramAction, string parmaName)
        /// <summary>
        ///  写入JS脚本
        /// </summary>
        /// <param name="paramAction">内容</param>
        /// <param name="parmaName"></param>
        public void JsWrite(string paramAction, string parmaName)
        {
            if (ScriptManager.GetCurrent(this.Page).IsInAsyncPostBack)
            {
                ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.Page.GetType(), parmaName, paramAction, true);
                ScriptManager.RegisterStartupScript(this.UpdatePanel2, this.Page.GetType(), parmaName, paramAction, true);
            }
            else
            {
                this.JsBaseWrite(paramAction, parmaName);
            }
        }
        #endregion

        #region public void JsBaseWrite(string paramAction, string parmaName)
        /// <summary>
        ///  写入JS脚本
        /// </summary>
        /// <param name="paramAction">内容</param>
        /// <param name="parmaName"></param>
        public void JsBaseWrite(string paramAction, string parmaName)
        {
            Type cstype = this.GetType();
            ClientScriptManager cs = Page.ClientScript;
            string strCheckInput = paramAction;
            if (!cs.IsStartupScriptRegistered(cstype, parmaName))
            {
                cs.RegisterStartupScript(cstype, parmaName, strCheckInput, true);
            }
        }
        #endregion

        #region public void SetJsPageLoad()
        /// <summary>
        /// 设置JS加载，如果页面没传宽度就取当前的，如果传 了就按传过来的
        /// </summary>
        public void SetJsPageLoad()
        {
            string width = "";
            string height = "";
            if (Request["width"] != null && Request["width"].ToString().Length > 0)
            {
                width = Request["width"].ToString();
            }
            if (Request["height"] != null && Request["height"].ToString().Length > 0)
            {
                height = Request["height"].ToString();
            }

            JsWrite("PageLoad('" + width + "','" + height + "');", "InitPage");
        }
        #endregion


        protected void ScriptManager1_AsyncPostBackError(object sender, AsyncPostBackErrorEventArgs e)
        {
            this.ScriptManager1.AsyncPostBackErrorMessage = "系统在执行中遇到错误,原因如下：" + e.Exception.Message;

        }

        #region public ArrayList GetSelectedIds(GridView paramGridView)
        /// <summary>
        /// 取GRID中选中的行的ID集合
        /// </summary>
        /// <param name="paramGridView">表格控件</param>
        /// <returns></returns>
        public List<int> GetSelectedIds(GridView paramGridView)
        {
            List<int> myIDs = new List<int>();
            for (int i = 0; i < paramGridView.Rows.Count; i++)
            {
                CheckBox myChk = (CheckBox)paramGridView.Rows[i].Cells[0].FindControl("chkSelected");
                if (myChk != null)
                {
                    if (myChk.Checked)
                    {
                        int keyID = 0;
                        int.TryParse(paramGridView.DataKeys[i].Value.ToString(), out keyID);
                        myIDs.Add(keyID);
                    }
                }
            }
            return myIDs;
        }

        /// <summary>
        /// 取GRID中选中的行的ID集合
        /// </summary>
        /// <param name="paramGridView">表格控件</param>
        /// <returns></returns>
        public List<int> GetSelectedIds(GridView paramGridView, int keyIndex)
        {
            List<int> myIDs = new List<int>();
            for (int i = 0; i < paramGridView.Rows.Count; i++)
            {
                CheckBox myChk = (CheckBox)paramGridView.Rows[i].Cells[0].FindControl("chkSelected");
                if (myChk != null)
                {
                    if (myChk.Checked)
                    {
                        int keyID = 0;
                        int.TryParse(paramGridView.DataKeys[i].Values[keyIndex].ToString(), out keyID);
                        myIDs.Add(keyID);
                    }
                }
            }
            return myIDs;
        }
        #endregion 

        /// <summary>
        /// GridView 排序规则
        /// </summary>
        public GridViewTwoSortDirEnum GridViewSortDir
        {
            get
            {
                try
                {
                    return (GridViewTwoSortDirEnum)ViewState["GridViewSortDirEnum"];
                }
                catch
                {
                }
                return GridViewTwoSortDirEnum.ASC;
            }
            set
            {
                ViewState["GridViewSortDirEnum"] = value;
            }
        }

        public string GridViewSortField
        {
            get
            {
                try
                {
                    return ViewState["GridViewSortField"].ToString();
                }
                catch
                {
                }
                return string.Empty;
            }
            set
            {
                ViewState["GridViewSortField"] = value;
            }
        }
         

        //原
        /// <summary>
        /// 标题
        /// </summary>
        public void SetTitle(string paramTitle)
        {
            this.lblTitle.Text = paramTitle;
            this.Page.Title = paramTitle;
        } 
        public void SetLeftTitle(string paramTitle)
        {
            this.lblLeftTitle.Text = paramTitle;
        }


        public void SetEditHeadVisble(bool Visible)
        {
            this.trEditHead.Visible = Visible;
        }

        public override void ShowError(string message, string completeMessage)
        {
            this.JsWrite("alert('" + message + "');", "EmptyData");
        }

        public override void ShowMessage(string message)
        {
            this.JsWrite("alert('" + message + "');", "EmptyData");
        }
    }

    public enum GridViewTwoSortDirEnum
    {
        DESC,
        ASC
    }
}