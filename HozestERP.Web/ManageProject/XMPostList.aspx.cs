using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HozestERP.Common.Utils;
using HozestERP.BusinessLogic.ManageProject;
using HozestERP.BusinessLogic;
using CRM.BusinessLogic.ManageContract;

namespace HozestERP.Web.ManageProject
{
    public partial class XMPostList : BaseAdministrationPage, ISearchPage
    {

        protected override Dictionary<string, string> ButtonSecuritys
        {
            get
            {
                Dictionary<string, string> buttons = new Dictionary<string, string>();
                buttons.Add("imgBtnEdit", "ManageProject.XMPostList.Edit");//编辑
                buttons.Add("imgBtnDelete", "ManageProject.XMPostList.Delete");//删除
                buttons.Add("btnAdd", "ManageProject.XMPostList.Add");//新增
                
                return buttons;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.IsEnable.Items.Clear();
                this.IsEnable.Items.Insert(0, new ListItem("否", "false"));
                this.IsEnable.Items.Insert(1, new ListItem("是", "true"));
                this.BindGrid(1, Master.PageSize);
            }
        }

        #region ISearchPage 成员

        public void SetTrigger()
        {
            this.Master.SetTrigger(this.btnAdd.UniqueID, this.Page);
            //this.Master.SetTrigger(this.btnSearch.UniqueID, this.Page);
        }


        public void BindGrid(int paramPageIndex, int paramPageSize)
        {
            string post = this.post.Text.Trim();
            bool IsEnable = bool.Parse(this.IsEnable.SelectedValue);
            this.Master.BindData<XMPost>(this.gvXMPost
   , base.XMPostService.SearchXMPost(post,IsEnable, paramPageIndex, paramPageSize, this.Master.GridViewSortField, this.Master.GridViewSortDir.ToString()));
           
        }

        //private void BindGrid()
        //{
        //    this.BindGrid(1, this.Master.PageSize);
        //}
        #endregion

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            this.BindGrid(Master.PageIndex, Master.PageSize);
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            this.BindGrid(1, Master.PageSize);
        }

        protected void ddlNick_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.BindGrid(Master.PageIndex, Master.PageSize);
        }
        

        protected void gvXMPost_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            #region 删除
            if (e.CommandName.Equals("PostDelete"))
            {

                var xMPost = base.XMPostService.GetXMPostById(Convert.ToInt32(e.CommandArgument));

                if (xMPost != null)//删除
                {
                    xMPost.IsEnable = true;
                    xMPost.UpdatorID = HozestERPContext.Current.User.CustomerID;
                    xMPost.UpdateTime = DateTime.Now;
                    base.XMPostService.UpdateXMPost(xMPost);
                    this.BindGrid(this.Master.PageIndex, this.Master.PageSize);
                    base.ShowMessage("操作成功.");
                }

            }
            #endregion
        }

        protected void gvXMPost_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var xMPost = e.Row.DataItem as XMPost;

                //查看详情
                ImageButton imgBtnEdit = e.Row.FindControl("imgBtnEdit") as ImageButton;
                if (imgBtnEdit != null)
                {
                    imgBtnEdit.OnClientClick = "return ShowWindowDetail('岗位详情','" + CommonHelper.GetStoreLocation()
                   + "ManageProject/XMPostAdd.aspx?PostId=" + xMPost.Id + "',1000, 415, this, function(){document.getElementById('"
                   + this.btnSearch.ClientID + "').click();});";

                }

            }
        }

        public void Face_Init() 
        {

            this.Master.SetTitle("岗位查询");


            this.btnAdd.OnClientClick = "return ShowWindowDetail('岗位添加','" + CommonHelper.GetStoreLocation()
          + "ManageProject/XMPostAdd.aspx?PostId=-1',1000, 390, this, function(){document.getElementById('"
          + this.btnSearch.ClientID + "').click();});";
            Session["SessionPayTypeId"] = null;
        }

        /// <summary>
        /// 刷单参数类型Id
        /// </summary>
        public int SDParametersTypeId
        {
            get
            {
                return CommonHelper.QueryStringInt("SDParametersTypeId");
            }
        }
    }
}