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
using System.Text;
using System.Text.RegularExpressions;

namespace HozestERP.Web.ManageProject
{
    public partial class XMprojectCostDetailAdd : BaseAdministrationPage, IEditPage
    {
        public string TableStr = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //获取项目拥有字段名称和值的列表
                GetFieldCostList();
            }

        }

        protected void Page_Init(object sender, EventArgs e)
        {
            if (this.ProjectID != 0)
            {
                hiddType.Value = "0";         //类型为项目
            }
            if (this.DepartmentID != 0)
            {
                hiddType.Value = "1";         //类型为B2B或B2C
            }
        }

        private void GetFieldCostList()
        {

            StringBuilder str = new StringBuilder();
            if (this.ProjectID != 0||this.NickID!=0)                       //如果是项目
            {
                string includefields = "";
                //获取项目所属字段集合字符串
                XMIncludeFields xmNickInclude = null;
                if(this.ProjectID !=0)
                {
                    xmNickInclude = base.XMIncludeFieldsService.GetXMIncludeFieldsListByProjectID(this.ProjectID);
                }
                if(this.NickID  !=0)
                {
                    xmNickInclude = base.XMIncludeFieldsService.GetXMIncludeFieldsListByNickID(this.NickID);
                }
                //var xmNickInclude = base.XMIncludeFieldsService.GetXMIncludeFieldsListByProjectID(this.ProjectID);
                if (xmNickInclude != null && !string.IsNullOrEmpty(xmNickInclude.Fields))
                {
                    includefields = xmNickInclude.Fields;
                }

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
                str.Append("<table  border='1'  rules='all' width='480px'  id='tb1'>");
                str.Append("<tr  align='center' style='height:5px;height:5px;'>");

                if (p != null && p.Length > 0)
                {
                    for (int j = 0; j < p.Count(); j++)
                    {
                        decimal cost = 0;               //字段数值
                        HozestERP.BusinessLogic.ManageBusiness.XMProjectCostDetail field = null;
                        if(this.ProjectID !=0)
                        {
                            field = base.XMProjectCostDetailService.GetXMProjectCostDataByParm(int.Parse(p[j]), this.ProjectID, Year);
                        }
                        if(this.NickID !=0)
                        {
                            field = base.XMProjectCostDetailService.GetXMProjectCostDataByNick(int.Parse(p[j]), this.NickID, Year);
                        }
                        //HozestERP.BusinessLogic.ManageBusiness.XMProjectCostDetail field = base.XMProjectCostDetailService.GetXMProjectCostDataByParm(int.Parse(p[j]), this.ProjectID, Year);
                        //添加父节点
                        str.Append("<td style='width:40%;font-size:18px;text-align:left;'>" + field.FieldName + "</td>");
                        //遍历所有月份获取相应月份的数值
                        switch (Month)
                        {
                            case 1:
                                cost = field.OneMonthCost.Value;
                                break;
                            case 2:
                                cost = field.TwoMonthCost.Value;
                                break;
                            case 3:
                                cost = field.ThreeMonthCost.Value;
                                break;
                            case 4:
                                cost = field.FourMonthCost.Value;
                                break;
                            case 5:
                                cost = field.FiveMonthCost.Value;
                                break;
                            case 6:
                                cost = field.SixMonthCost.Value;
                                break;
                            case 7:
                                cost = field.SevenMonthCost.Value;
                                break;
                            case 8:
                                cost = field.EightMonthCost.Value;
                                break;
                            case 9:
                                cost = field.NineMonthCost.Value;
                                break;
                            case 10:
                                cost = field.TenMonthCost.Value;
                                break;
                            case 11:
                                cost = field.ElevenMonthCost.Value;
                                break;
                            case 12:
                                cost = field.TwelMonthCost.Value;
                                break;
                        }
                        bool isexsit = false;
                        if(this.ProjectID !=0)
                        {
                            isexsit = ishaveChildField(field.FinancialFieldID.ToString(), ProjectID, 0, 0);
                        }
                        if(this.NickID !=0)
                        {
                            isexsit = ishaveChildField(field.FinancialFieldID.ToString(), 0, 0, this.NickID);
                        }
                        //bool isexsit = ishaveChildField(field.FinancialFieldID.ToString(), ProjectID, 0,0);
                        bool isAuto = isAutoCalCulateField(field.FinancialFieldID.ToString());
                        if (isexsit || isAuto)
                        {
                            str.Append("<td style='width:50%;text-align:right'> <input type=\"hidden\" id=\"hiddID\" runat=\"server\"  value=' " + field.FinancialFieldID + "'/><input type=\"text\"  runat=\"server\" disabled=\"disabled\" name=\"dd\" id='txtCost_" + field.FinancialFieldID + "'  value='" + cost + "'/><input type=\"hidden\" id=\"hiddID\" runat=\"server\"  value=' " + field.FieldName + "'/></td></tr>");
                        }
                        else
                        {
                            str.Append("<td style='width:50%;text-align:right'> <input type=\"hidden\" id=\"hiddID\" runat=\"server\"  value=' " + field.FinancialFieldID + "'/><input type=\"text\"  runat=\"server\" name=\"dd\" id='txtCost_" + field.FinancialFieldID + "'  value='" + cost + "'/><input type=\"hidden\" id=\"hiddID\" runat=\"server\"  value=' " + field.FieldName + "'/></td></tr>");
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
                                        HozestERP.BusinessLogic.ManageBusiness.XMProjectCostDetail f = null;
                                        if(this.ProjectID !=0)
                                        {
                                            f = base.XMProjectCostDetailService.GetXMProjectCostDataByParm(int.Parse(childID), this.ProjectID, Year);
                                        }
                                        if(this.NickID !=0)
                                        {
                                            f = base.XMProjectCostDetailService.GetXMProjectCostDataByNick(int.Parse(childID), this.NickID, Year);
                                        }
                                        //var f = base.XMProjectCostDetailService.GetXMProjectCostDataByParm(int.Parse(childID), this.ProjectID, Year);
                                        switch (Month)
                                        {
                                            case 1:
                                                cost = f.OneMonthCost.Value;
                                                break;
                                            case 2:
                                                cost = f.TwoMonthCost.Value;
                                                break;
                                            case 3:
                                                cost = f.ThreeMonthCost.Value;
                                                break;
                                            case 4:
                                                cost = f.FourMonthCost.Value;
                                                break;
                                            case 5:
                                                cost = f.FiveMonthCost.Value;
                                                break;
                                            case 6:
                                                cost = f.SixMonthCost.Value;
                                                break;
                                            case 7:
                                                cost = f.SevenMonthCost.Value;
                                                break;
                                            case 8:
                                                cost = f.EightMonthCost.Value;
                                                break;
                                            case 9:
                                                cost = f.NineMonthCost.Value;
                                                break;
                                            case 10:
                                                cost = f.TenMonthCost.Value;
                                                break;
                                            case 11:
                                                cost = f.ElevenMonthCost.Value;
                                                break;
                                            case 12:
                                                cost = f.TwelMonthCost.Value;
                                                break;
                                        }
                                        str.Append("<tr align='center' style='height:5px;height:5px;'>");
                                        str.Append("<td style='width:40%;font-size:18px;text-align:right;font-size:13px;'>" + f.FieldName + "</td>");
                                        str.Append("<td style='width:50%;text-align:right'> <input type=\"hidden\" id=\"hiddID\" runat=\"server\"  value=' " + f.FinancialFieldID + "'/><input type=\"text\"  runat=\"server\" name=\"dd\" id='txtCost_" + f.FinancialFieldID + "'  value='" + cost + "'/><input type=\"hidden\" id=\"hiddID\" runat=\"server\"  value=' " + f.FieldName + "'/></td>");
                                        str.Append("</tr>");
                                    }
                                }
                            }
                        }
                    }
                    str.Append("</table>");
                    TableStr = str.ToString();
                }
            }
            else if (this.DepartmentID != 0)
            {
                string includefields = "";
                //获取项目所属字段集合字符串
                var xmOtherInclude = base.XMIncludeFieldsService.GetXMIncludeFieldsListByDepartmentID(this.DepartmentID);
                if (xmOtherInclude != null && !string.IsNullOrEmpty(xmOtherInclude.Fields))
                {
                    includefields = xmOtherInclude.Fields;
                }

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
                str.Append("<table  border='1'  rules='all' width='480px'  id='tb1'>");
                str.Append("<tr  align='center' style='background-color:" + "" + ";height:5px;height:5px;' oldcolor='" + "" + "'>");

                if (p != null && p.Length > 0)
                {
                    for (int j = 0; j < p.Count(); j++)
                    {
                        decimal cost = 0;               //字段数值
                        HozestERP.BusinessLogic.ManageBusiness.XMOtherCostDetail otherField = base.XMOtherCostDetailService.GetXMOtherCostDataByParm(int.Parse(p[j]), this.DepartmentID, Year);
                        //添加父节点
                        str.Append("<td style='width:40%;font-size:18px;text-align:left;background-color:EAEAEA'>" + otherField.FieldName + "</td>");
                        //遍历所有月份获取相应月份的数值
                        switch (Month)
                        {
                            case 1:
                                cost = otherField.OneMonthCost.Value;
                                break;
                            case 2:
                                cost = otherField.TwoMonthCost.Value;
                                break;
                            case 3:
                                cost = otherField.ThreeMonthCost.Value;
                                break;
                            case 4:
                                cost = otherField.FourMonthCost.Value;
                                break;
                            case 5:
                                cost = otherField.FiveMonthCost.Value;
                                break;
                            case 6:
                                cost = otherField.SixMonthCost.Value;
                                break;
                            case 7:
                                cost = otherField.SevenMonthCost.Value;
                                break;
                            case 8:
                                cost = otherField.EightMonthCost.Value;
                                break;
                            case 9:
                                cost = otherField.NineMonthCost.Value;
                                break;
                            case 10:
                                cost = otherField.TenMonthCost.Value;
                                break;
                            case 11:
                                cost = otherField.ElevenMonthCost.Value;
                                break;
                            case 12:
                                cost = otherField.TwelMonthCost.Value;
                                break;
                        }
                        // 有子节点的不能编辑 和 （毛利，增值税，营业税附加，税前利润，所得税，直接净利润 字段无法输入，进行自动计算）
                        bool isexsit = ishaveChildField(otherField.FinancialFieldID.ToString(), 0, DepartmentID,0);
                        bool isAuto = isAutoCalCulateField(otherField.FinancialFieldID.ToString());
                        if (isexsit || isAuto)
                        {
                            str.Append("<td style='width:50%;text-align:right'> <input type=\"hidden\" id=\"hiddID\" runat=\"server\"  value=' " + otherField.FinancialFieldID + "'/><input type=\"text\"  runat=\"server\" disabled=\"disabled\" name=\"dd\" id='txtCost_" + otherField.FinancialFieldID + "'  value='" + cost + "'/><input type=\"hidden\" id=\"hiddID\" runat=\"server\"  value=' " + otherField.FieldName + "'/></td></tr>");
                        }
                        else
                        {
                            str.Append("<td style='width:50%;text-align:right'> <input type=\"hidden\" id=\"hiddID\" runat=\"server\"  value=' " + otherField.FinancialFieldID + "'/><input type=\"text\"  runat=\"server\" name=\"dd\" id='txtCost_" + otherField.FinancialFieldID + "'  value='" + cost + "'/><input type=\"hidden\" id=\"hiddID\" runat=\"server\"  value=' " + otherField.FieldName + "'/></td></tr>");
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
                                        var f = base.XMOtherCostDetailService.GetXMOtherCostDataByParm(int.Parse(childID), this.DepartmentID, Year);
                                        switch (Month)
                                        {
                                            case 1:
                                                cost = f.OneMonthCost.Value;
                                                break;
                                            case 2:
                                                cost = f.TwoMonthCost.Value;
                                                break;
                                            case 3:
                                                cost = f.ThreeMonthCost.Value;
                                                break;
                                            case 4:
                                                cost = f.FourMonthCost.Value;
                                                break;
                                            case 5:
                                                cost = f.FiveMonthCost.Value;
                                                break;
                                            case 6:
                                                cost = f.SixMonthCost.Value;
                                                break;
                                            case 7:
                                                cost = f.SevenMonthCost.Value;
                                                break;
                                            case 8:
                                                cost = f.EightMonthCost.Value;
                                                break;
                                            case 9:
                                                cost = f.NineMonthCost.Value;
                                                break;
                                            case 10:
                                                cost = f.TenMonthCost.Value;
                                                break;
                                            case 11:
                                                cost = f.ElevenMonthCost.Value;
                                                break;
                                            case 12:
                                                cost = f.TwelMonthCost.Value;
                                                break;
                                        }
                                        str.Append("<tr  align='center' style='background-color:" + "" + ";height:5px;height:5px;' oldcolor='" + "" + "'>");
                                        str.Append("<td style='width:40%;font-size:18px;text-align:right;font-size:13px;background-color:#FFFFFF'>" + f.FieldName + "</td>");
                                        str.Append("<td style='width:50%;text-align:right'> <input type=\"hidden\" id=\"hiddID\" runat=\"server\"  value=' " + f.FinancialFieldID + "'/><input type=\"text\"  runat=\"server\" name=\"dd\" id='txtCost_" + f.FinancialFieldID + "'  value='" + cost + "'/><input type=\"hidden\" id=\"hiddID\" runat=\"server\"  value=' " + f.FieldName + "'/></td>");
                                        str.Append("</tr>");
                                    }
                                }
                            }
                            str.Append("</tr>");
                        }
                    }
                    str.Append("</table>");
                    TableStr = str.ToString();
                }
            }
        }

        /// <summary>
        /// 判断是否是自动计算字段
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private bool isAutoCalCulateField(string id)
        {
            bool isAuto = false;
            var field = base.XMFinancialFieldService.GetXMFinancialFieldById(int.Parse(id));
            if (field != null && field.FieldName != "" && (field.FieldName.Contains("毛利") || field.FieldName.Contains("增值税") || field.FieldName.Contains("营业税及附加") || field.FieldName.Contains("税前利润") || field.FieldName.Contains("所得税") || field.FieldName.Contains("直销净利润")))
            {
                isAuto = true;
            }
            return isAuto;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private bool ishaveChildField(string id, int projectId, int departmentId,int nickId)
        {
            bool isExsitChild = false;
            var d = base.XMFinancialFieldService.GetXMFinancialFieldByParentID(int.Parse(id));
            if (projectId != 0|| nickId !=0)
            {
                XMIncludeFields include = null;
                if(projectId!=0)
                {
                    include = base.XMIncludeFieldsService.GetXMIncludeFieldsListByProjectID(projectId);
                }
                if(nickId!=0)
                {
                    include = base.XMIncludeFieldsService.GetXMIncludeFieldsListByNickID(nickId);
                }
                //var include = base.XMIncludeFieldsService.GetXMIncludeFieldsListByProjectID(projectId);
                if (d.Count() > 0)
                {
                    if (include != null)
                    {
                        foreach (XMFinancialField f in d)
                        {
                            foreach (string str2 in include.Fields.Split(','))
                            {
                                if (str2 == f.Id.ToString())
                                {
                                    isExsitChild = true;
                                }
                            }
                        }
                    }
                }
            }
            if (departmentId != 0)
            {
                var include = base.XMIncludeFieldsService.GetXMIncludeFieldsListByDepartmentID(departmentId);
                if (d.Count() > 0)
                {
                    if (include != null)
                    {
                        foreach (XMFinancialField f in d)
                        {
                            foreach (string str3 in include.Fields.Split(','))
                            {
                                if (str3 == f.Id.ToString())
                                {
                                    isExsitChild = true;
                                }
                            }
                        }
                    }
                }
            }
            return isExsitChild;
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
        /// 判断B2C是否存在金立毛利字段
        /// </summary>
        /// <param name="fields"></param>
        /// <returns></returns>
        private int isExsitB2C(string fields)
        {
            int fid = 0;
            foreach (string id in fields.Split(','))
            {
                var info = base.XMFinancialFieldService.GetXMFinancialFieldById(int.Parse(id));
                if (info != null)
                {
                    if (info.FieldName == "金立毛利")
                    {
                        fid = info.Id;
                    }
                }
            }
            return fid;
        }

        /// <summary>
        /// 判断是否是父节点
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int isParentField(string id)
        {
            var field = base.XMFinancialFieldService.GetXMFinancialFieldById(int.Parse(id));
            if (field.ParentID == 0)
            {
                //
                return 0;
            }
            else
            {
                return field.Id;
            }
        }

        protected void grdvFielsCost_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //TextBox txtCost = e.Row.FindControl("txtCountMoney") as TextBox;

                //if (txtCost != null)
                //{
                //    txtCost.TextChanged += txtCost_TextChanged;
                //}
            }
        }

       


        public void Face_Init()
        {
        }

        public void SetTrigger()
        {
        }


        public int ProjectID
        {
            get
            {
                return CommonHelper.QueryStringInt("ProjectId");
            }
        }

        public int NickID
        {
            get
            {
                return CommonHelper.QueryStringInt("NickID");
            }
        }

        public int Month
        {
            get
            {
                return CommonHelper.QueryStringInt("month");
            }
        }

        public int Year
        {
            get
            {
                return CommonHelper.QueryStringInt("year");
            }
        }

        public int DepartmentID
        {
            get
            {
                return CommonHelper.QueryStringInt("DepartmentID");
            }
        }

        public int Id
        {
            get { return (int)ViewState["Id"]; }
            set { ViewState["Id"] = value; }
        }

        /// <summary>
        /// 判断一个字符串是否为合法数字(指定整数位数和小数位数)
        /// </summary>
        /// <param name="s">字符串</param>
        /// <param name="precision">整数位数</param>
        /// <param name="scale">小数位数</param>
        /// <returns></returns>
        public static bool IsNumber(string s, int precision, int scale)
        {
            if ((precision == 0) && (scale == 0))
            {
                return false;
            }
            string pattern = @"(^\d{1," + precision + "}";
            if (scale > 0)
            {
                pattern += @"\.\d{0," + scale + "}$)|" + pattern;
            }
            pattern += "$)";
            return Regex.IsMatch(s, pattern);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            //判断输入框输入值是否合法
            bool isnumber = true;
            string[] ids = hiddAllID.Value.Substring(0, hiddAllID.Value.Length - 1).Split(',');
            string[] costs = hiddAllCost.Value.Substring(0, hiddAllCost.Value.Length - 1).Split(',');
            if (costs.Count() > 0)
            {
                foreach (string str in costs)
                {
                    if (!IsNumber(str, 11, 2) && decimal.Parse(str) > 0)
                    {
                        isnumber = false;
                    }
                }
            }
            if (!isnumber)
            {
                base.ShowMessage("输入数字格式不正确，请重新输入！");
                GetFieldCostList();
                return;
            }
            //项目添加预算
            if (this.ProjectID != 0||this.NickID !=0)
            {
                if (ids.Count() > 0 && costs.Count() > 0)
                {
                    for (int i = 0; i < ids.Length; i++)
                    {
                        HozestERP.BusinessLogic.ManageBusiness.XMProjectCostDetail info = null;
                        if(this.ProjectID !=0)
                        {
                            info = base.XMProjectCostDetailService.GetXMProjectCostDataByParm(int.Parse(ids[i]), this.ProjectID, this.Year);
                        }
                        if(this.NickID !=0)
                        {
                            info = base.XMProjectCostDetailService.GetXMProjectCostDataByNick(int.Parse(ids[i]), this.NickID, this.Year);
                        }
                        //var info = base.XMProjectCostDetailService.GetXMProjectCostDataByParm(int.Parse(ids[i]), this.ProjectID, this.Year);
                        if (info != null)
                        {
                            switch (this.Month)
                            {
                                case 1:
                                    info.OneMonthCost = decimal.Parse(costs[i]);
                                    break;
                                case 2:
                                    info.TwoMonthCost = decimal.Parse(costs[i]);
                                    break;
                                case 3:
                                    info.ThreeMonthCost = decimal.Parse(costs[i]);
                                    break;
                                case 4:
                                    info.FourMonthCost = decimal.Parse(costs[i]); ;
                                    break;
                                case 5:
                                    info.FiveMonthCost = decimal.Parse(costs[i]);
                                    break;
                                case 6:
                                    info.SixMonthCost = decimal.Parse(costs[i]); ;
                                    break;
                                case 7:
                                    info.SevenMonthCost = decimal.Parse(costs[i]);
                                    break;
                                case 8:
                                    info.EightMonthCost = decimal.Parse(costs[i]);
                                    break;
                                case 9:
                                    info.NineMonthCost = decimal.Parse(costs[i]);
                                    break;
                                case 10:
                                    info.TenMonthCost = decimal.Parse(costs[i]);
                                    break;
                                case 11:
                                    info.ElevenMonthCost = decimal.Parse(costs[i]);
                                    break;
                                case 12:
                                    info.TwelMonthCost = decimal.Parse(costs[i]);
                                    break;
                            }
                            info.UpdateID = HozestERPContext.Current.User.CustomerID;
                            info.UpdateDate = DateTime.Now;
                            base.XMProjectCostDetailService.UpdateXMProjectCostDetail(info);
                        }
                    }
                    base.ShowMessage("操作成功！");
                }
            }

            if (this.DepartmentID != 0)
            {
                if (ids.Count() > 0 && costs.Count() > 0)
                {
                    for (int i = 0; i < ids.Length; i++)
                    {
                        var info = base.XMOtherCostDetailService.GetXMOtherCostDataByParm(int.Parse(ids[i]), this.DepartmentID, this.Year);
                        if (info != null)
                        {
                            switch (this.Month)
                            {
                                case 1:
                                    info.OneMonthCost = decimal.Parse(costs[i]);
                                    break;
                                case 2:
                                    info.TwoMonthCost = decimal.Parse(costs[i]);
                                    break;
                                case 3:
                                    info.ThreeMonthCost = decimal.Parse(costs[i]);
                                    break;
                                case 4:
                                    info.FourMonthCost = decimal.Parse(costs[i]); ;
                                    break;
                                case 5:
                                    info.FiveMonthCost = decimal.Parse(costs[i]);
                                    break;
                                case 6:
                                    info.SixMonthCost = decimal.Parse(costs[i]); ;
                                    break;
                                case 7:
                                    info.SevenMonthCost = decimal.Parse(costs[i]);
                                    break;
                                case 8:
                                    info.EightMonthCost = decimal.Parse(costs[i]);
                                    break;
                                case 9:
                                    info.NineMonthCost = decimal.Parse(costs[i]);
                                    break;
                                case 10:
                                    info.TenMonthCost = decimal.Parse(costs[i]);
                                    break;
                                case 11:
                                    info.ElevenMonthCost = decimal.Parse(costs[i]);
                                    break;
                                case 12:
                                    info.TwelMonthCost = decimal.Parse(costs[i]);
                                    break;
                            }
                            info.UpdateID = HozestERPContext.Current.User.CustomerID;
                            info.UpdateDate = DateTime.Now;
                            base.XMOtherCostDetailService.UpdateXMOtherCostDetail(info);

                        }
                    }
                    base.ShowMessage("操作成功！");
                }
            }
            GetFieldCostList();
        }
    }
}