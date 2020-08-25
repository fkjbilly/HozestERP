using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using HozestERP.Common.Utils;
using HozestERP.BusinessLogic.ManageBusiness;
using HozestERP.BusinessLogic;
using System.Web.UI;
using System.Web;
using System.IO;


namespace HozestERP.Web.ManageProject
{
    public partial class SetFinanceFields : BaseAdministrationPage, IEditPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //绑定综管部预算字段集合
                if (this.DepartmentId != 0 && this.DepartmentId == 507)
                {
                    BindManagerDepartFinanceField(this.DepartmentId);
                }
                else
                {
                    //绑定项目 B2B B2C 预算字段集合
                    BindrptParentField();
                }
            }
        }

        protected void Page_init(object sender, EventArgs e)
        {
            InitData();
            //判断当年数据是否已经审核
            if (checkIsAudit())
            {
                base.ShowMessage("请先反审核后再添加字段！");
            }
        }
        /// <summary>
        /// 判断当年数据是否已经审核
        /// </summary>
        /// <returns></returns>
        private bool checkIsAudit()
        {
            bool isAudit = false;
            if (this.ProjectId != 0)     //如果是项目
            {
                string year = DateTime.Now.Year.ToString();
                //获取项目所属字段集合
                var xmNickInclude = base.XMIncludeFieldsService.GetXMIncludeFieldsListByProjectID(ProjectId);
                if (xmNickInclude != null && !string.IsNullOrEmpty(xmNickInclude.Fields))
                {
                    //拆分字段
                    foreach (string id in xmNickInclude.Fields.Split(','))
                    {
                        //根据字段ID，年份,项目ID 查询相关记录
                        HozestERP.BusinessLogic.ManageBusiness.XMProjectCostDetail cost = base.XMProjectCostDetailService.GetXMProjectCostDataByParm(int.Parse(id), ProjectId, int.Parse(year));
                        if (cost != null && cost.IsAudit != null)
                        {
                            isAudit = cost.IsAudit.Value;
                        }
                    }
                }
            }

            if (this.DepartmentId != 0)    //如果是部门
            {
                string year = DateTime.Now.Year.ToString();
                var xmOtherInclude = base.XMIncludeFieldsService.GetXMIncludeFieldsListByDepartmentID(this.DepartmentId);
                if (xmOtherInclude != null && !string.IsNullOrEmpty(xmOtherInclude.Fields))
                {
                    //拆分字段
                    foreach (string id in xmOtherInclude.Fields.Split(','))
                    {
                        HozestERP.BusinessLogic.ManageBusiness.XMOtherCostDetail cost = base.XMOtherCostDetailService.GetXMOtherCostDataByParm(int.Parse(id), DepartmentId, int.Parse(year));
                        if (cost != null && cost.IsAudit != null)
                        {
                            isAudit = cost.IsAudit.Value;
                        }
                    }
                }
            }

            return isAudit;
        }

        private void InitData()
        {
            if (this.ProjectId != 0)
            {
                var field = base.XMIncludeFieldsService.GetXMIncludeFieldsListByProjectID(this.ProjectId);
                if (field != null && field.Fields != null)
                {
                    hdfIDs.Value = field.Fields;
                }
            }
            else if (this.DepartmentId != 0)
            {
                var field = base.XMIncludeFieldsService.GetXMIncludeFieldsListByDepartmentID(this.DepartmentId);
                if (field != null && field.Fields != null)
                {
                    hdfIDs.Value = field.Fields;
                }
            }
            else if(this.NickID!=0)
            {
                var field = base.XMIncludeFieldsService.GetXMIncludeFieldsListByNickID(this.NickID);
                if (field != null && field.Fields != null)
                {
                    hdfIDs.Value = field.Fields;
                }
            }
        }

        ////判断是否是子节点
        //private bool isChildField(int id)
        //{
        //    bool isChild = false;
        //    var filed = base.XMFinancialFieldService.GetXMFinancialFieldById(id);
        //    if (filed != null)
        //    {
        //        isChild = filed.ParentID
        //    }
        //}

        /// <summary>
        /// 绑定综管部预算字段集合
        /// </summary>
        /// <param name="departmentId"></param>
        private void BindManagerDepartFinanceField(int departmentId)
        {
            //获取综管部预算集合
            var fields = base.XMFinancialFieldService.GetXMManagerFinancialFileldList();
            List<XMFinancialField> pList = new List<XMFinancialField>();
            if (fields.Count > 0)
            {
                foreach (var f in fields)
                {
                    var filed = base.XMFinancialFieldService.GetXMFinancialFieldById(f.Id);
                    if (filed != null && filed.ParentID != 0)            //是子节点
                    {
                        //父节点信息
                        var pfields = base.XMFinancialFieldService.GetXMFinancialFieldById(filed.ParentID.Value);
                        if (pfields != null)
                        {
                            if (pList.Count == 0 || (pList.Count > 0 && !pList.Contains(pfields)))
                            {
                                pList.Add(pfields);
                            }
                        }
                    }
                }
            }
            this.rptParentField.DataSource = pList;
            this.rptParentField.DataBind();
        }

        //B2B B2C  项目 绑定所有预算字段
        private void BindrptParentField()
        {
            //获取父节点数据(ParentID = 0)
            var field = base.XMFinancialFieldService.GetXMFinancialFieldByParentID(0);
            this.rptParentField.DataSource = field;
            this.rptParentField.DataBind();
        }

        protected int i = 1;
        protected void rptChildField_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            //动态控制repeater显示行数
            if (i % 16 == 0 && i > 0)
            {
                e.Item.Controls.Add(new LiteralControl("</tr><tr>"));
            }
            i++;
        }

        protected void rptParentField_OnItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            int id = 0;
            List<XMFinancialField> childList = new List<XMFinancialField>();
            HiddenField hidd = e.Item.FindControl("hdfParentID") as HiddenField;
            if (hidd != null)
            {
                id = int.Parse(hidd.Value);
                //根据Id为父级查询是否有子集如果有绑定子级reapter
                if (this.DepartmentId != 0 && this.DepartmentId == 507)                //综管部
                {
                    childList = base.XMFinancialFieldService.GetXMMangerFinancialFieldListByParentID(id);
                }
                else
                {
                    childList = base.XMFinancialFieldService.GetXMFinancialFieldByParentID(id);              //B2B B2C 项目
                }
                //如果有子级绑定子级repeater
                if (childList != null && childList.Count > 0)
                {
                    //绑定子级
                    Repeater repChildField = e.Item.FindControl("rptChildField") as Repeater;
                    repChildField.DataSource = childList;
                    repChildField.DataBind();
                }

            }
        }

        /// <summary>
        /// 项目Id
        /// </summary>
        public int ProjectId
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

        public int DepartmentId
        {
            get
            {
                return CommonHelper.QueryStringInt("DepartmentId");
            }
        }

        public void Face_Init()
        {
        }

        public void SetTrigger()
        {
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ID"></param>
        private void autoSaveData(string ids, int projectID, int departmentID,int nickID)
        {
            //插入项目数据
            if (!string.IsNullOrEmpty(ids) && projectID != 0)
            {
                foreach (string id in ids.Split(','))
                {
                    HozestERP.BusinessLogic.ManageBusiness.XMProjectCostDetail cost = base.XMProjectCostDetailService.GetXMProjectCostDataByParm(int.Parse(id), projectID, DateTime.Now.Year);
                    if (cost == null)
                    {
                        //自动插入想关数据
                        HozestERP.BusinessLogic.ManageBusiness.XMProjectCostDetail Info = new HozestERP.BusinessLogic.ManageBusiness.XMProjectCostDetail();
                        Info.ProjectId = projectID;
                        Info.FinancialFieldID = int.Parse(id);
                        Info.Year = DateTime.Now.Year;
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
                        base.XMProjectCostDetailService.InsertXMProjectCostDetail(Info);
                    }
                }
            }

            if (!string.IsNullOrEmpty(ids) && departmentID != 0)
            {
                foreach (string id in ids.Split(','))
                {
                    HozestERP.BusinessLogic.ManageBusiness.XMOtherCostDetail othercost = base.XMOtherCostDetailService.GetXMOtherCostDataByParm(int.Parse(id), departmentID, DateTime.Now.Year);
                    if (othercost == null)
                    {
                        //自动插入相关数据
                        HozestERP.BusinessLogic.ManageBusiness.XMOtherCostDetail Info = new HozestERP.BusinessLogic.ManageBusiness.XMOtherCostDetail();
                        Info.DepartmentID = departmentID;
                        Info.FinancialFieldID = int.Parse(id);
                        Info.Year = DateTime.Now.Year;
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

            if (!string.IsNullOrEmpty(ids) && nickID != 0)
            {
                foreach (string id in ids.Split(','))
                {
                    HozestERP.BusinessLogic.ManageBusiness.XMProjectCostDetail cost = base.XMProjectCostDetailService.GetXMProjectCostDataByNick(int.Parse(id), nickID, DateTime.Now.Year);
                    if (cost == null)
                    {
                        //自动插入想关数据
                        HozestERP.BusinessLogic.ManageBusiness.XMProjectCostDetail Info = new HozestERP.BusinessLogic.ManageBusiness.XMProjectCostDetail();
                        Info.NickId = nickID;
                        Info.FinancialFieldID = int.Parse(id);
                        Info.Year = DateTime.Now.Year;
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
                        base.XMProjectCostDetailService.InsertXMProjectCostDetail(Info);
                    }
                }
            }
        }

        //字段按照DisplayOrder排序
        private string SortByDisplayOrder(string str)
        {
            string newStr = "";
            List<DisplayOrder> List = new List<DisplayOrder>();
            string[] field = str.Split(',');
            if (field.Length > 0)
            {
                foreach (string parm in field)
                {
                    DisplayOrder order = new DisplayOrder();
                    var fields = base.XMFinancialFieldService.GetXMFinancialFieldById(int.Parse(parm));
                    if (fields != null)
                    {
                        order.Id = fields.Id;
                        order.DisplayOrderNum = fields.DisplayOrder;
                    }
                    List.Add(order);
                }
                //根据DisplayOrder排序
                List.Sort(delegate(DisplayOrder a, DisplayOrder b) { return a.DisplayOrderNum.CompareTo(b.DisplayOrderNum); });
                //遍历生成字符串
                if (List != null && List.Count > 0)
                {
                    foreach (DisplayOrder o in List)
                    {
                        newStr += o.Id + ",";
                    }
                }
                if (newStr != "")
                {
                    newStr = newStr.Substring(0, newStr.Length - 1);
                }
            }
            return newStr;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            //
            if (checkIsAudit())
            {
                base.ShowMessage("请先反审核后在添加字段！");
                BindrptParentField();
                return;
            }
            string IDs = hdfSelectAllID.Value;

            if (string.IsNullOrEmpty(IDs))
            {
                base.ShowMessage("请选择字段");
                BindrptParentField();
                return;
            }

            string departmentID = this.DepartmentId.ToString();
            if (!string.IsNullOrEmpty(IDs) && this.ProjectId != 0)
            {
                string newStr = SortByDisplayOrder(IDs);
                hdfIDs.Value = IDs;
                var includeField = base.XMIncludeFieldsService.GetXMIncludeFieldsListByProjectID(this.ProjectId);
                //新增
                if (includeField == null)
                {
                    XMIncludeFields info = new XMIncludeFields();
                    info.ProjectId = this.ProjectId;
                    info.Fields = newStr;
                    info.CreateId = HozestERPContext.Current.User.CustomerID;
                    info.Createdate = DateTime.Now;
                    info.UpdateId = HozestERPContext.Current.User.CustomerID;
                    info.Updatetime = DateTime.Now;
                    base.XMIncludeFieldsService.InsertXMIncludeFields(info);

                    //自动插入字段数据
                    autoSaveData(IDs, this.ProjectId, 0,0);
                }
                else
                {
                    includeField.Fields = newStr;
                    includeField.UpdateId = HozestERPContext.Current.User.CustomerID;
                    includeField.Updatetime = DateTime.Now;
                    base.XMIncludeFieldsService.UpdateXMIncludeFields(includeField);
                    autoSaveData(IDs, this.ProjectId, 0,0);
                }

                //项目字段更新后需要更新项目导入模板
                UpdateImportProjectTemplate();
                base.ShowMessage("操作成功!");
            }

            if (!string.IsNullOrEmpty(IDs) && this.DepartmentId != 0)
            {
                hdfIDs.Value = IDs;
                string newStr = SortByDisplayOrder(IDs);
                var fieldInclude = base.XMIncludeFieldsService.GetXMIncludeFieldsListByDepartmentID(this.DepartmentId);
                if (fieldInclude == null)
                {
                    XMIncludeFields info = new XMIncludeFields();
                    info.DepartmentId = this.DepartmentId;
                    info.Fields = newStr;
                    info.CreateId = HozestERPContext.Current.User.CustomerID;
                    info.Createdate = DateTime.Now;
                    info.UpdateId = HozestERPContext.Current.User.CustomerID;
                    info.Updatetime = DateTime.Now;
                    base.XMIncludeFieldsService.InsertXMIncludeFields(info);
                    //自动插入字段数据

                    autoSaveData(IDs, 0, this.DepartmentId,0);
                }
                else
                {
                    fieldInclude.Fields = newStr;
                    fieldInclude.UpdateId = HozestERPContext.Current.User.CustomerID;
                    fieldInclude.Updatetime = DateTime.Now;
                    base.XMIncludeFieldsService.UpdateXMIncludeFields(fieldInclude);

                    autoSaveData(IDs, 0, this.DepartmentId,0);
                }
                UpdateB2BOrB2CCostTemplate();
                base.ShowMessage("操作成功!");
            }

            if (!string.IsNullOrEmpty(IDs) && this.NickID != 0)
            {
                hdfIDs.Value = IDs;
                string newStr = SortByDisplayOrder(IDs);
                var fieldInclude = base.XMIncludeFieldsService.GetXMIncludeFieldsListByNickID(this.NickID);
                if (fieldInclude == null)
                {
                    XMIncludeFields info = new XMIncludeFields();
                    info.NickId = this.NickID;
                    info.Fields = newStr;
                    info.CreateId = HozestERPContext.Current.User.CustomerID;
                    info.Createdate = DateTime.Now;
                    info.UpdateId = HozestERPContext.Current.User.CustomerID;
                    info.Updatetime = DateTime.Now;
                    base.XMIncludeFieldsService.InsertXMIncludeFields(info);
                    //自动插入字段数据

                    autoSaveData(IDs, 0, 0,this.NickID);
                }
                else
                {
                    fieldInclude.Fields = newStr;
                    fieldInclude.UpdateId = HozestERPContext.Current.User.CustomerID;
                    fieldInclude.Updatetime = DateTime.Now;
                    base.XMIncludeFieldsService.UpdateXMIncludeFields(fieldInclude);

                    autoSaveData(IDs, 0, 0,this.NickID);
                }

                base.ShowMessage("操作成功!");
            }

            if (this.DepartmentId != 0 && this.DepartmentId == 507)
            {
                BindManagerDepartFinanceField(this.DepartmentId);
            }
            else
            {
                BindrptParentField();
            }

        }

        //更新B2BorB2C数据导入模板
        private void UpdateB2BOrB2CCostTemplate()
        {
            string fileName = string.Empty;
            if (this.DepartmentId == 297)        //B2B文件名
            {
                fileName = "B2BFieldCost.xls";
            }
            else if (DepartmentId == 63)
            {
                fileName = "B2CFieldCost.xls";
            }
            else if (DepartmentId == 507)            //综管部
            {
                fileName = "ManagerFieldCost.xls";
            }
            string filePath = string.Format("{0}Template", HttpContext.Current.Request.PhysicalApplicationPath);
            if (Directory.Exists(filePath) == false)//如果不存在就创建file文件夹
            {
                Directory.CreateDirectory(filePath);
            }
            filePath = filePath + "\\" + fileName;
            bool isExists = File.Exists(filePath);
            if (isExists)                    //如果存在删除该文件
            {
                //删除源文件
                File.Delete(filePath);
                //添加新文件
                base.ExportManager.ExportFinancialFieldCostExcel(filePath, 0, this.DepartmentId);
            }
            else
            {
                //添加新文件
                base.ExportManager.ExportFinancialFieldCostExcel(filePath, 0, this.DepartmentId);
            }
        }

        //更新项目导入模板
        private void UpdateImportProjectTemplate()
        {
            //根据项目ID 查询数据库自动生成excel 模板保存到/Template路径下
            string fileName = "ProjectFieldCost.xls";
            string filePath = string.Format("{0}Template", HttpContext.Current.Request.PhysicalApplicationPath);
            if (Directory.Exists(filePath) == false)//如果不存在就创建file文件夹
            {
                Directory.CreateDirectory(filePath);
            }
            filePath = filePath + "\\" + fileName;
            bool isExists = File.Exists(filePath);
            if (isExists)                    //如果存在删除该文件
            {
                //删除源文件
                File.Delete(filePath);
                //添加新文件
                base.ExportManager.ExportFinancialFieldCostExcel(filePath, this.ProjectId, 0);
            }
            else
            {
                //添加新文件
                base.ExportManager.ExportFinancialFieldCostExcel(filePath, this.ProjectId, 0);
            }

        }



    }

    public class DisplayOrder
    {
        public int Id;
        public int DisplayOrderNum;
    }
}