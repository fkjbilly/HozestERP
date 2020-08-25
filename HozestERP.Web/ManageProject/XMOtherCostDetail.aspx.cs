using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using HozestERP.Common.Utils;
using HozestERP.BusinessLogic.ManageBusiness;
using System.Text;
using System.Web.UI.WebControls;
using System.Drawing;
using HozestERP.BusinessLogic;
using HozestERP.Controls;

namespace HozestERP.Web.ManageProject
{
    public partial class XMOtherCostDetail : BaseAdministrationPage, ISearchPage
    {
        public string TableStr = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            UpdateData();
            if (!IsPostBack)
            {
                ddlYear.SelectedValue = DateTime.Now.Year.ToString();
                //初始化数据库数据
                btnSetField.OnClientClick = "return ShowWindowDetail('财务字段设置', '" + CommonHelper.GetStoreLocation()
                                + "ManageProject/SetFinanceFields.aspx?DepartmentId=" + this.DepartmentID
                                + "&rnd=' + Math.round(), 1000, 600, this, function(){document.getElementById('" + this.btnRefresh.ClientID + "').click();});";
                this.BindGrid();
            }
            this.btnImportCost.OnClientClick = "return ShowWindowDetail('财务预算数据导入','" + CommonHelper.GetStoreLocation() +
"ManageProject/ImportFinancialCost.aspx?DepartmentID=" + this.DepartmentID + "&&year=" + ddlYear.SelectedValue + "', 500, 280, this, function(){document.getElementById('" + this.btnSearch.ClientID + "').click();});";
            InitData();
        }

        private void UpdateData()
        {
            var xmOtherInclude = base.XMIncludeFieldsService.GetXMIncludeFieldsListByDepartmentID(DepartmentID);
            if (xmOtherInclude == null)
            {
                base.ShowMessage("请先设置预算字段！");
                return;
            }
            //更新数据(如删除字段，需更新数据)
            if (xmOtherInclude != null && !string.IsNullOrEmpty(xmOtherInclude.Fields))
            {
                string[] parm = xmOtherInclude.Fields.Split(',');
                string pID = "";              //父节点ID
                string cID = "";              //子节点ID
                if (parm != null && parm.Count() > 0)
                {
                    foreach (string id in parm)
                    {
                        var f = base.XMFinancialFieldService.GetXMFinancialFieldById(int.Parse(id));
                        if (f != null)
                        {
                            if (f.ParentID == 0)
                            {
                                pID += f.Id + ",";
                            }
                            else
                            {
                                cID += f.Id + ",";
                            }
                        }
                    }
                }
                if (pID != "" && pID.Length > 0)
                {
                    pID = pID.Substring(0, pID.Length - 1);
                }
                if (cID != "" && cID.Length > 0)
                {
                    cID = cID.Substring(0, cID.Length - 1);
                }

                string[] p = pID.Split(',');
                string[] c = cID.Split(',');

                foreach (string str in p)
                {
                    bool isexsitChild = false;          //是否存在子节点
                    //循环更新12个月
                    for (int i = 1; i <= 12; i++)
                    {
                        decimal total = 0;
                        var cost = base.XMOtherCostDetailService.GetXMOtherCostDataByParm(int.Parse(str), DepartmentID, DateTime.Now.Year);
                        if (cost != null)
                        {
                            var f = base.XMFinancialFieldService.GetXMFinancialFieldByParentID(int.Parse(str));
                            if (f != null && f.Count() > 0)
                            {
                                foreach (string str1 in c)
                                {
                                    foreach (XMFinancialField field in f)
                                    {
                                        if (str1 == field.Id.ToString())
                                        {
                                            isexsitChild = true;
                                            var d = base.XMOtherCostDetailService.GetXMOtherCostDataByParm(int.Parse(str1), DepartmentID, DateTime.Now.Year);
                                            if (d != null)
                                            {
                                                switch (i)
                                                {
                                                    case 1:
                                                        total += d.OneMonthCost.Value;
                                                        break;
                                                    case 2:
                                                        total += d.TwoMonthCost.Value;
                                                        break;
                                                    case 3:
                                                        total += d.ThreeMonthCost.Value;
                                                        break;
                                                    case 4:
                                                        total += d.FourMonthCost.Value;
                                                        break;
                                                    case 5:
                                                        total += d.FiveMonthCost.Value;
                                                        break;
                                                    case 6:
                                                        total += d.SixMonthCost.Value;
                                                        break;
                                                    case 7:
                                                        total += d.SevenMonthCost.Value;
                                                        break;
                                                    case 8:
                                                        total += d.EightMonthCost.Value;
                                                        break;
                                                    case 9:
                                                        total += d.NineMonthCost.Value;
                                                        break;
                                                    case 10:
                                                        total += d.TenMonthCost.Value;
                                                        break;
                                                    case 11:
                                                        total += d.ElevenMonthCost.Value;
                                                        break;
                                                    case 12:
                                                        total += d.TwelMonthCost.Value;
                                                        break;
                                                }
                                            }
                                        }
                                    }
                                }
                                if (isexsitChild)                                  //存在子节点更新数据
                                {
                                    switch (i)
                                    {
                                        case 1:
                                            cost.OneMonthCost = total;
                                            base.XMOtherCostDetailService.UpdateXMOtherCostDetail(cost);
                                            break;
                                        case 2:
                                            cost.TwoMonthCost = total;
                                            base.XMOtherCostDetailService.UpdateXMOtherCostDetail(cost);
                                            break;
                                        case 3:
                                            cost.ThreeMonthCost = total;
                                            base.XMOtherCostDetailService.UpdateXMOtherCostDetail(cost);
                                            break;
                                        case 4:
                                            cost.FourMonthCost = total;
                                            base.XMOtherCostDetailService.UpdateXMOtherCostDetail(cost);
                                            break;
                                        case 5:
                                            cost.FiveMonthCost = total;
                                            base.XMOtherCostDetailService.UpdateXMOtherCostDetail(cost);
                                            break;
                                        case 6:
                                            cost.SixMonthCost = total;
                                            base.XMOtherCostDetailService.UpdateXMOtherCostDetail(cost);
                                            break;
                                        case 7:
                                            cost.SevenMonthCost = total;
                                            base.XMOtherCostDetailService.UpdateXMOtherCostDetail(cost);
                                            break;
                                        case 8:
                                            cost.EightMonthCost = total;
                                            base.XMOtherCostDetailService.UpdateXMOtherCostDetail(cost);
                                            break;
                                        case 9:
                                            cost.NineMonthCost = total;
                                            base.XMOtherCostDetailService.UpdateXMOtherCostDetail(cost);
                                            break;
                                        case 10:
                                            cost.TenMonthCost = total;
                                            base.XMOtherCostDetailService.UpdateXMOtherCostDetail(cost);
                                            break;
                                        case 11:
                                            cost.ElevenMonthCost = total;
                                            base.XMOtherCostDetailService.UpdateXMOtherCostDetail(cost);
                                            break;
                                        case 12:
                                            cost.TwelMonthCost = total;
                                            base.XMOtherCostDetailService.UpdateXMOtherCostDetail(cost);
                                            break;
                                    }
                                }
                            }


                        }
                    }
                }
            }
        }


        private void InitData()
        {
            //更具项目ID 查询字段是否设置
            var xmOtherInclude = base.XMIncludeFieldsService.GetXMIncludeFieldsListByDepartmentID(DepartmentID);
            if (xmOtherInclude == null)
            {
                base.ShowMessage("请先设置预算字段！");
                return;
            }
            else
            {
                //判断当前年份数据是否存在（如不存在自动添加）
                if (xmOtherInclude != null && !string.IsNullOrEmpty(xmOtherInclude.Fields))
                {
                    foreach (string id in xmOtherInclude.Fields.Split(','))
                    {
                        HozestERP.BusinessLogic.ManageBusiness.XMOtherCostDetail cost = base.XMOtherCostDetailService.GetXMOtherCostDataByParm(int.Parse(id), DepartmentID, int.Parse(ddlYear.SelectedValue));
                        if (cost == null)
                        {
                            //自动插入想关数据
                            HozestERP.BusinessLogic.ManageBusiness.XMOtherCostDetail Info = new HozestERP.BusinessLogic.ManageBusiness.XMOtherCostDetail();
                            Info.DepartmentID = DepartmentID;
                            Info.FinancialFieldID = int.Parse(id);
                            Info.Year = Convert.ToInt16(ddlYear.SelectedValue);
                            Info.OneMonthCost = 0;
                            Info.TwoMonthCost = 0;
                            Info.ThreeMonthCost = 0;
                            Info.FourMonthCost = 0;
                            Info.FiveMonthCost = 0;
                            Info.SixMonthCost = 0;
                            Info.SevenMonthCost = 0;
                            Info.EightMonthCost = 0;
                            Info.NineMonthCost = 0;
                            Info.TenMonthCost = 0;
                            Info.ElevenMonthCost = 0;
                            Info.TwelMonthCost = 0;
                            Info.IsEnable = false;
                            Info.IsAudit = false;
                            Info.CreateDate = DateTime.Now;
                            Info.CreateID = HozestERPContext.Current.User.CustomerID;
                            Info.UpdateDate = DateTime.Now;
                            Info.UpdateID = HozestERPContext.Current.User.CustomerID;
                            base.XMOtherCostDetailService.InsertXMOtherCostDetail(Info);
                        }
                    }
                }
            }


        }

        private int isExsitB2C(string id)
        {
            int fid = 0;
            var info = base.XMFinancialFieldService.GetXMFinancialFieldById(int.Parse(id));
            if (info != null)
            {
                if (info.FieldName == "金立毛利")
                {
                    fid = info.Id;
                }
            }
            return fid;
        }

        private void BindGrid()
        {
            int no = 1;
            int change = 0;
            StringBuilder str = new StringBuilder();
            string year = ddlYear.SelectedValue;
            if (string.IsNullOrEmpty(this.DepartmentID.ToString()))
            {
                base.ShowMessage("部门ID不能为空！");
                return;
            }
            string includefields = "";
            var xmNickInclude = base.XMIncludeFieldsService.GetXMIncludeFieldsListByDepartmentID(DepartmentID);
            if (xmNickInclude != null && !string.IsNullOrEmpty(xmNickInclude.Fields))
            {
                includefields = xmNickInclude.Fields;
            }
            else
            {
                change = 0;
                ScriptManager.RegisterStartupScript(this.grdvOtherCost, this.Page.GetType(), "BindGrid", "ChangeOverflow('" + change + "')", true);//ajax
                grdvOtherCost.DataSource = "";
                grdvOtherCost.DataBind();
                base.ShowMessage("请先设置项目的预算字段！");
                return;
            }
            List<HozestERP.BusinessLogic.ManageBusiness.XMOtherCostDetail> fields = new List<HozestERP.BusinessLogic.ManageBusiness.XMOtherCostDetail>();
            string[] parm = includefields.Split(',');
            string pID = "";              //父节点ID
            string cID = "";              //子节点ID
            if (parm != null && parm.Count() > 0)
            {
                foreach (string id in parm)
                {
                    var f = base.XMFinancialFieldService.GetXMFinancialFieldById(int.Parse(id));
                    if (f != null)
                    {
                        if (f.ParentID == 0)
                        {
                            pID += f.Id + ",";
                        }
                        else
                        {
                            cID += f.Id + ",";
                        }
                    }
                }
            }
            if (pID != "" && pID.Length > 0)
            {
                pID = pID.Substring(0, pID.Length - 1);
            }
            if (cID != "" && cID.Length > 0)
            {
                cID = cID.Substring(0, cID.Length - 1);
            }
            string[] p = pID.Split(',');
            string[] c = cID.Split(',');
            if (p != null && p.Length > 0)
            {
                for (int j = 0; j < p.Count(); j++)
                {
                    if (no == 1)
                    {
                        str.Append("<table   style='height: 5px;width:100%;border-style:solid' rules='all'>");
                        str.Append("<tr  style='font-weight:bold;height:30px;background-color:#EEEEEE'>");
                        str.Append("<th  nowrap='noWrap' align='center' style='width:120px;white-space:nowrap;cursor:pointer;' scope='col'>项目</th>");
                        str.Append("<th  nowrap='noWrap' align='center' style='width:60px;white-space:nowrap;cursor:pointer;' scope='col'>1-12月累计</th>");
                        str.Append("<th  nowrap='noWrap' align='center' style='width:70px;white-space:nowrap;cursor:pointer;' scope='col'>占毛利比</th>");

                        str.Append("</tr>");
                    }
                    str.Append("<tr class='GridRow' align='center' style='background-color:#EAEAEA;height:5px;height:5px;' oldcolor=#EAEAEA'>");
                    str.Append("<td style='width:120px;font-size:18px;'>" + getFieldNameByFieldID(p[j]) + "</td>");
                    str.Append("<td style='width:60px;text-align:center'>" + getSumAllCost(p[j]) + "</td>");
                    if (YYYJCost != 0)
                    {
                        str.Append("<td style='width:70px;text-align:center'>" + Math.Round(getSumAllCost(p[j]) / YYYJCost, 2) * 100 + "%" + "</td>");
                    }
                    else
                    {
                        str.Append("<td style='width:70px;text-align:center'>" + 0 + "%" + "</td>");
                    }
                    str.Append("</tr>");
                    var pCost = base.XMOtherCostDetailService.GetXMOtherCostDataByParm(int.Parse(p[j]), DepartmentID, int.Parse(ddlYear.SelectedValue));
                    if (pCost != null && pCost.FieldName != "")
                    {
                        fields.Add(pCost);
                    }
                    //字段管理中该字段已经删除，应该清理掉该条数据
                    if (pCost != null && pCost.FieldName == "")
                    {
                        pCost.IsEnable = true;
                        pCost.UpdateDate = DateTime.Now;
                        pCost.UpdateID = HozestERPContext.Current.User.CustomerID;
                        base.XMOtherCostDetailService.UpdateXMOtherCostDetail(pCost);
                    }
                    if (HasChild(p[j]))
                    {
                        string newStr = childFieldIDs(p[j]);
                        foreach (string childID in c)
                        {
                            foreach (string str1 in newStr.Split(','))
                            {
                                if (childID == str1)               //存在该子节点
                                {
                                    str.Append("<tr class='GridRow' align='center' style='background-color:#FFFFFF;height:5px;height:5px;' oldcolor=#FFFFFF'>");
                                    str.Append("<td style='width:120px;text-align:right'>" + getFieldNameByFieldID(childID) + "</td>");
                                    str.Append("<td style='width:60px;text-align:center'>" + getSumAllCost(childID) + "</td>");
                                    if (YYYJCost != 0)
                                    {
                                        str.Append("<td style='width:70px;text-align:center'>" + Math.Round(getSumAllCost(childID) / YYYJCost, 2) * 100 + "%" + "</td>");
                                    }
                                    else
                                    {
                                        str.Append("<td style='width:70px;text-align:center'>" + 0 + "%" + "</td>");
                                    }

                                    var childCost = base.XMOtherCostDetailService.GetXMOtherCostDataByParm(int.Parse(childID), DepartmentID, int.Parse(ddlYear.SelectedValue));
                                    if (childCost != null && childCost.FieldName != "")
                                    {
                                        fields.Add(childCost);
                                    }
                                    //字段管理中已经删除该字段，该条数据删除
                                    if (childCost != null && childCost.FieldName == "")
                                    {
                                        childCost.IsEnable = true;
                                        childCost.UpdateDate = DateTime.Now;
                                        childCost.UpdateID = HozestERPContext.Current.User.CustomerID;
                                        base.XMOtherCostDetailService.UpdateXMOtherCostDetail(childCost);
                                    }
                                }
                            }
                        }
                        str.Append("</tr>");
                    }
                    no++;
                }
                if (fields.Count > 0)
                {
                    change = 1;
                    str.Append("<tr class='GridRow' style='background-color:#F7F7F7'><td style='height:10px;' colspan='9'></td></tr></table>");
                    TableStr = str.ToString();
                }
                ScriptManager.RegisterStartupScript(this.grdvOtherCost, this.Page.GetType(), "BindGrid", "ChangeOverflow('" + change + "')", true);//ajax
                grdvOtherCost.DataSource = fields;
                grdvOtherCost.DataBind();
            }
        }

        private string childFieldIDs(string id)
        {
            string newStr = string.Empty;
            var field = base.XMFinancialFieldService.GetXMFinancialFieldByParentID(int.Parse(id));
            if (field != null)
            {
                foreach (XMFinancialField f in field)
                {
                    newStr += f.Id + ",";
                }
            }
            if (!string.IsNullOrEmpty(newStr) && newStr.Length > 0)
            {
                newStr = newStr.Substring(0, newStr.Length - 1);
            }
            return newStr;
        }

        private bool HasChild(string fid)
        {
            bool isexsit = false;
            var field = base.XMFinancialFieldService.GetXMFinancialFieldByParentID(int.Parse(fid));
            if (field != null && field.Count() > 0)
            {
                isexsit = true;
            }
            return isexsit;
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private bool isParentField(string id)
        {
            bool isYes = false;
            var field = base.XMFinancialFieldService.GetXMFinancialFieldById(int.Parse(id));
            if (field != null && field.ParentID == 0)
            {
                isYes = true;
            }
            return isYes;
        }



        /// <summary>
        /// 通过FieldID 获取字段名称
        /// </summary>
        /// <param name="id"></param>
        private string getFieldNameByFieldID(string id)
        {
            string fieldName = string.Empty;
            var field = base.XMFinancialFieldService.GetXMFinancialFieldById(int.Parse(id));
            if (field != null)
            {
                fieldName = field.FieldName;
            }
            return fieldName;
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
                int index = Convert.ToInt16(grdvOtherCost.DataKeys[e.Row.RowIndex]["FinancialFieldID"].ToString());
                var field = base.XMFinancialFieldService.GetXMFinancialFieldById(index);
                if (field != null && field.ParentID == 0)              //父节点
                {
                    e.Row.Attributes["style"] = "background-color:#EAEAEA";
                }
                else
                {
                    e.Row.Attributes["style"] = "background-color:#FFFFFF";
                }
            }
        }


        private bool getIsAuditByDepartmentID()
        {
            bool isAudit = false;
            string year = ddlYear.SelectedValue;
            var xmNickInclude = base.XMIncludeFieldsService.GetXMIncludeFieldsListByDepartmentID(DepartmentID);
            if (xmNickInclude != null && !string.IsNullOrEmpty(xmNickInclude.Fields))
            {
                foreach (string id in xmNickInclude.Fields.Split(','))
                {
                    HozestERP.BusinessLogic.ManageBusiness.XMOtherCostDetail cost = base.XMOtherCostDetailService.GetXMOtherCostDataByParm(int.Parse(id), DepartmentID, int.Parse(year));
                    if (cost != null && cost.IsAudit != null)
                    {
                        isAudit = cost.IsAudit.Value;
                    }
                }
            }
            return isAudit;
        }
        /// <summary>
        /// 求和（12个月数据累加）
        /// </summary>
        /// <param name="detail"></param>
        /// <returns></returns>
        private decimal getSumAllCost(string id)
        {
            decimal sum = 0;
            HozestERP.BusinessLogic.ManageBusiness.XMOtherCostDetail detail = new HozestERP.BusinessLogic.ManageBusiness.XMOtherCostDetail();
            var field = base.XMFinancialFieldService.GetXMFinancialFieldById(int.Parse(id));
            if (field != null)
            {
                detail = base.XMOtherCostDetailService.GetXMOtherCostDataByParm(int.Parse(id), DepartmentID, int.Parse(ddlYear.SelectedValue));
                if (detail != null)
                {
                    sum = detail.OneMonthCost.Value + detail.TwoMonthCost.Value + detail.ThreeMonthCost.Value + detail.FourMonthCost.Value + detail.FiveMonthCost.Value + detail.SixMonthCost.Value + detail.SevenMonthCost.Value + detail.EightMonthCost.Value + detail.NineMonthCost.Value + detail.TenMonthCost.Value + detail.ElevenMonthCost.Value + detail.TwelMonthCost.Value;
                }
            }
            if (field != null && (this.DepartmentID == 297 || this.DepartmentID == 63) && field.FieldName.Contains("营业业绩额"))
            {
                if (detail != null)
                {
                    YYYJCost = detail.OneMonthCost.Value + detail.TwoMonthCost.Value + detail.ThreeMonthCost.Value + detail.FourMonthCost.Value + detail.FiveMonthCost.Value + detail.SixMonthCost.Value + detail.SevenMonthCost.Value + detail.EightMonthCost.Value + detail.NineMonthCost.Value + detail.TenMonthCost.Value + detail.ElevenMonthCost.Value + detail.TwelMonthCost.Value;
                }
            }
            else if (this.DepartmentID == 507 && field.Id == 70)
            {
                if (detail != null)
                {
                    YYYJCost = detail.OneMonthCost.Value + detail.TwoMonthCost.Value + detail.ThreeMonthCost.Value + detail.FourMonthCost.Value + detail.FiveMonthCost.Value + detail.SixMonthCost.Value + detail.SevenMonthCost.Value + detail.EightMonthCost.Value + detail.NineMonthCost.Value + detail.TenMonthCost.Value + detail.ElevenMonthCost.Value + detail.TwelMonthCost.Value;
                }
            }
            return sum;
        }

        protected void grdvClients_RowCreated(object sender, GridViewRowEventArgs e)
        {
            //判断创建的行是否为表头行
            if (e.Row.RowType == DataControlRowType.Header)
            {

                if (!getIsAuditByDepartmentID())
                {
                    //ImageButton imgBtnEditOne = e.Row.FindControl("imgBtnEditOne") as ImageButton;
                    for (int i = 1; i <= 12; i++)
                    {
                        ImageCheckBox ck = e.Row.FindControl("FinancialStatus" + i.ToString()) as ImageCheckBox;
                        ck.Visible = false;
                        ImageButton imgBtnEdit = e.Row.FindControl("imgBtnEdit_" + i.ToString()) as ImageButton;
                        if (imgBtnEdit != null)
                        {
                            imgBtnEdit.OnClientClick = "return ShowWindowDetail('" + i.ToString() + "月份预算数据修改','" + CommonHelper.GetStoreLocation()
                  + "ManageProject/XMprojectCostDetailAdd.aspx?month=" + i.ToString() + "&&year=" + ddlYear.SelectedValue + "&&DepartmentID=" + this.DepartmentID + "&Type=1',550, 600, this, function(){document.getElementById('"
                  + this.btnRefresh.ClientID + "').click();});";
                        }
                    }
                }
                else
                {
                    for (int i = 1; i <= 12; i++)
                    {
                        ImageCheckBox ck = e.Row.FindControl("FinancialStatus" + i.ToString()) as ImageCheckBox;
                        ck.Visible = true;
                        ImageButton imgBtnEdit = e.Row.FindControl("imgBtnEdit_" + i.ToString()) as ImageButton;
                        imgBtnEdit.Visible = false;
                    }
                }
            }
        }

        public void BindGrid(int paramPageIndex, int paramPageSize)
        {

        }


        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindGrid();
        }

        /// <summary>
        /// 刷新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            BindGrid();
        }


        /// <summary>
        /// 审核
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnIsAudit_Click(object sender, EventArgs e)
        {
            string year = ddlYear.SelectedValue;
            var xmNickInclude = base.XMIncludeFieldsService.GetXMIncludeFieldsListByDepartmentID(DepartmentID);
            if (xmNickInclude != null && !string.IsNullOrEmpty(xmNickInclude.Fields))
            {
                foreach (string id in xmNickInclude.Fields.Split(','))
                {
                    HozestERP.BusinessLogic.ManageBusiness.XMOtherCostDetail cost = base.XMOtherCostDetailService.GetXMOtherCostDataByParm(int.Parse(id), DepartmentID, int.Parse(year));
                    if (cost != null)
                    {
                        cost.IsAudit = true;
                        cost.UpdateID = HozestERPContext.Current.User.SCustomerInfo.CustomerID;
                        cost.UpdateDate = DateTime.Now;
                        base.XMOtherCostDetailService.UpdateXMOtherCostDetail(cost);
                    }
                }
                BindGrid();
                base.ShowMessage("操作成功！");
            }
        }


        /// <summary>
        /// 反审核
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnIsAuditFalse_Click(object sender, EventArgs e)
        {
            string year = ddlYear.SelectedValue;
            var xmNickInclude = base.XMIncludeFieldsService.GetXMIncludeFieldsListByDepartmentID(DepartmentID);
            if (xmNickInclude != null && !string.IsNullOrEmpty(xmNickInclude.Fields))
            {
                foreach (string id in xmNickInclude.Fields.Split(','))
                {
                    HozestERP.BusinessLogic.ManageBusiness.XMOtherCostDetail cost = base.XMOtherCostDetailService.GetXMOtherCostDataByParm(int.Parse(id), DepartmentID, int.Parse(year));
                    if (cost != null)
                    {
                        cost.IsAudit = false;
                        cost.UpdateID = HozestERPContext.Current.User.SCustomerInfo.CustomerID;
                        cost.UpdateDate = DateTime.Now;
                        base.XMOtherCostDetailService.UpdateXMOtherCostDetail(cost);
                    }
                }
                BindGrid();
                base.ShowMessage("操作成功！");
            }
        }

        public void SetTrigger()
        {

        }

        public void Face_Init()
        {

        }


        /// <summary>
        /// 部门ID
        /// </summary>
        public int DepartmentID
        {
            get
            {
                return CommonHelper.QueryStringInt("departmentId");
            }
        }


        /// <summary>
        /// 总的营业业绩额
        /// </summary>
        public decimal YYYJCost
        {
            get
            {
                return ViewState["YYCost"] == null ? 0 : (decimal)ViewState["YYCost"];
            }
            set
            {
                ViewState["YYCost"] = value;
            }
        }
    }
}