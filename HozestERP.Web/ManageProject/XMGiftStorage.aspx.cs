using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HozestERP.BusinessLogic.ManageCustomerService;
using HozestERP.BusinessLogic;
using HozestERP.Common.Utils;
using System.Web.UI.HtmlControls;
using HozestERP.Web.Modules;
using System.Transactions;
using HozestERP.BusinessLogic.ManageProject;

namespace HozestERP.Web.ManageProject
{
    public partial class XMGiftStorage : BaseAdministrationPage, IEditPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadDate();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (grdvZYNewsList.Rows != null)
            {
                for (int i = 0; i < grdvZYNewsList.Rows.Count; i++)
                {
                    TextBox count = (TextBox)grdvZYNewsList.Rows[i].Cells[5].FindControl("txtCount");
                    string str = count.Text.Trim();
                    if (str != "" && Convert.ToInt32(str) != 0)
                    {
                        XMGiftStorageRecord info = new XMGiftStorageRecord();
                        info.ProductId = Convert.ToInt32(((DataBoundLiteralControl)grdvZYNewsList.Rows[i].Cells[7].Controls[0]).Text.Replace("\r\n", "").Trim());
                        info.Batch = ((DataBoundLiteralControl)grdvZYNewsList.Rows[i].Cells[4].Controls[0]).Text.Replace("\r\n", "").Trim();
                        info.Count = Convert.ToInt32(str);
                        info.IsEnable = false;
                        info.CreateID = HozestERPContext.Current.User.CustomerID;
                        info.CreateDate = DateTime.Now;
                        info.UpdateID = HozestERPContext.Current.User.CustomerID;
                        info.UpdateDate = DateTime.Now;
                        base.XMGiftStorageRecordService.InsertXMGiftStorageRecord(info);
                        var product = base.XMProductService.GetXMProductById((int)info.ProductId);
                        product.ManufacturersInventory = product.ManufacturersInventory + info.Count;
                        product.UpdateID = HozestERPContext.Current.User.CustomerID;
                        product.UpdateDate = DateTime.Now;
                        base.XMProductService.UpdateXMProduct(product);
                    }
                }
                base.ShowMessage("保存成功！");
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (type == 0)
            {
                var list = base.XMGiftStorageRecordService.GetXMGiftStorageRecordListByParm();
                this.grdvZYNewsList.DataSource = list;
                //绑定数据源
                this.grdvZYNewsList.DataBind();
            }
            else
            {
                SearchWithDate();
            }
            if (HttpContext.Current.Request.Cookies["NickId"] != null)
            {
                HttpCookie cookie = HttpContext.Current.Request.Cookies["NickId"];
                cookie.Path = "/ManageProject";
                cookie.Value = "1";
                HttpContext.Current.Response.Cookies.Add(cookie);
            }
            else
            {
                HttpCookie cookie = new HttpCookie("NickId");
                cookie.Path = "/ManageProject";
                cookie.Value = "1";
                HttpContext.Current.Response.Cookies.Add(cookie);
            }
        }

        public void SearchWithDate()
        {
            string begin = this.txtBeginDate.Value.Trim();
            string end = this.txtEndDate.Value.Trim();
            if (begin == "" || end == "")
            {
                base.ShowMessage("请先选择开始与结束日期！");
                return;
            }
            DateTime Begin = Convert.ToDateTime(begin);
            DateTime End = Convert.ToDateTime(end).AddDays(1).AddSeconds(-1);
            var list = base.XMGiftStorageRecordService.GetXMGiftStorageRecordListByDate(Begin, End);
            this.grdvZYNewsList.DataSource = list;
            //绑定数据源
            this.grdvZYNewsList.DataBind();

            if (list != null)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    TextBox count = (TextBox)grdvZYNewsList.Rows[i].Cells[5].FindControl("txtCount");
                    count.Text = list[i].Count.ToString();
                    count.ReadOnly = true;
                }
            }
        }

        public void loadDate()
        {
            this.Face_Init();
            if (type == 0)
            {
                //屏蔽操作列
                this.grdvZYNewsList.Columns[8].Visible = false;
                this.txtBeginDate.Attributes.Add("disabled", "disabled");
                this.txtEndDate.Attributes.Add("disabled", "disabled");
            }
            else
            {
                this.btnSave.Visible = false;
            }
        }


        /// <summary>
        /// 操作类型
        /// </summary>
        public int type
        {
            get
            {
                return CommonHelper.QueryStringInt("type");
            }
        }

        public void Face_Init()
        {
            this.grdvZYNewsList.Columns[6].Visible = false;
            this.grdvZYNewsList.Columns[7].Visible = false;
        }

        public void SetTrigger()
        {
            //throw new NotImplementedException();
        }

        protected void grdvClients_RowEditing(object sender, GridViewEditEventArgs e)
        {
            this.grdvZYNewsList.EditIndex = e.NewEditIndex;
            SearchWithDate();
            if (HttpContext.Current.Request.Cookies["EditIndex"] != null)
            {
                HttpCookie cookie = HttpContext.Current.Request.Cookies["EditIndex"];
                cookie.Path = "/ManageProject";
                cookie.Value = e.NewEditIndex.ToString();
                HttpContext.Current.Response.Cookies.Add(cookie);
            }
            else
            {
                HttpCookie cookie = new HttpCookie("EditIndex");
                cookie.Path = "/ManageProject";
                cookie.Value = e.NewEditIndex.ToString();
                HttpContext.Current.Response.Cookies.Add(cookie);
            }
            var row = this.grdvZYNewsList.Rows[e.NewEditIndex];
            TextBox txtCount = (TextBox)row.FindControl("txtCount");
            txtCount.ReadOnly = false;
        }
        /// <summary>
        /// 更新行数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grdvClients_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string ProductId = "";
            int ID = 0;
            int.TryParse(this.grdvZYNewsList.DataKeys[e.RowIndex].Value.ToString(), out ID);
            TextBox count = (TextBox)grdvZYNewsList.Rows[e.RowIndex].Cells[5].FindControl("txtCount");
            if (count.Text.Trim() == "")
            {
                base.ShowMessage("数量不能为空");
                return;
            }

            var gift = base.XMGiftStorageRecordService.GetXMGiftStorageRecordById(ID);
            if (HttpContext.Current.Request.Cookies["ProductId"] != null)
            {
                HttpCookie cookie = HttpContext.Current.Request.Cookies["ProductId"];
                if (cookie.Value == "")
                {
                    ProductId = gift.ProductId.ToString();
                }
                else
                {
                    ProductId = cookie.Value;
                    cookie.Path = "/ManageProject";
                    cookie.Value = "";
                    HttpContext.Current.Response.Cookies.Add(cookie);
                }
            }
            else
            {
                ProductId = gift.ProductId.ToString();
            }

            var oldProduct = base.XMProductService.GetXMProductById((int)gift.ProductId);
            var product = base.XMProductService.GetXMProductById(int.Parse(ProductId));

            product.ManufacturersInventory = product.ManufacturersInventory + int.Parse(count.Text.Trim());
            product.UpdateID = HozestERPContext.Current.User.CustomerID;
            product.UpdateDate = DateTime.Now;
            base.XMProductService.UpdateXMProduct(product);

            oldProduct.ManufacturersInventory = oldProduct.ManufacturersInventory - gift.Count;
            oldProduct.UpdateID = HozestERPContext.Current.User.CustomerID;
            oldProduct.UpdateDate = DateTime.Now;
            base.XMProductService.UpdateXMProduct(oldProduct);

            gift.ProductId = int.Parse(ProductId);
            gift.Count = int.Parse(count.Text.Trim());
            gift.UpdateID = HozestERPContext.Current.User.CustomerID;
            gift.UpdateDate = DateTime.Now;
            base.XMGiftStorageRecordService.UpdateXMGiftStorageRecord(gift);

            base.ShowMessage("保存成功!");
            this.grdvZYNewsList.EditIndex = -1;
            SearchWithDate();
        }
        /// <summary>
        /// 取消编辑
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grdvClients_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            this.grdvZYNewsList.EditIndex = -1;
            SearchWithDate();
        }
    }
}