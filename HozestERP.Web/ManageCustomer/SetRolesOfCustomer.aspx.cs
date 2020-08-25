using System;
using System.Collections.Generic;
using HozestERP.BusinessLogic.ManageProject;
using HozestERP.Common.Utils;

namespace HozestERP.Web.ManageCustomer
{
    public partial class SetRolesOfCustomer : BaseAdministrationPage, IEditPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindrptProjectList();
            }
        }

        protected void Page_init(object sender, EventArgs e)
        {
            setProjectList();
            getProjectCount();
        }

        //项目列表
        private void BindrptProjectList()
        {
            var projectList = base.XMProjectService.GetXMProjectList();
            this.rptProjectList.DataSource = projectList;
            this.rptProjectList.DataBind();
        }

        private void getProjectCount()
        {
            int count = 0;
            var projectList = base.XMProjectService.GetXMProjectList();
            if (projectList != null && projectList.Count > 0)
            {
                count = projectList.Count;
            }
            HiddenField2.Value = count.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        private void setProjectList()
        {
            string pids = string.Empty;
            if (Session["ProjectIDs"] != null)
            {
                List<int> List = Session["ProjectIDs"] as List<int>;
                if (List != null && List.Count > 0)
                {
                    foreach (int p in List)
                    {
                        pids += p + ",";
                    }
                }
            }
            if (pids.Length > 0)
            {
                pids = pids.Substring(0, pids.Length - 1);
            }
            HiddenField1.Value = pids;
        }

        public void Face_Init()
        {
        }

        public void SetTrigger()
        {
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            bool isSucess = false;
            string projectIDs = hdfSelectAllID.Value;
            List<int> pIDs = new List<int>();
            if (string.IsNullOrEmpty(projectIDs))
            {
                base.ShowMessage("请选择项目");
                BindrptProjectList();
                return;
            }

            if (!string.IsNullOrEmpty(projectIDs))
            {
                var projectId = projectIDs.Split(',');
                if (projectId.Length > 0)
                {
                    var list = XMNickCustomerMappingService.GetProjectXMNickCustomerMappingListByCustomerID(this.CustomerID);
                    foreach(var item in list)
                    {
                        XMNickCustomerMappingService.DeleteXMNickCustomerMapping(item.NickCustomerID);
                    }

                    foreach (string id in projectId)
                    {
                        if (!pIDs.Contains(int.Parse(id)))
                        {
                            pIDs.Add(int.Parse(id));
                        }
                        List<int> NickIds = new List<int>();
                        var nicks = base.XMNickService.GetXMNickListByProjectId(int.Parse(id));
                        if (nicks != null && nicks.Count > 0)
                        {
                            foreach (XMNick parm in nicks)
                            {
                                NickIds.Add(parm.nick_id);
                            }
                        }
                        var customerInfo = base.CustomerInfoService.GetCustomerInfoByID(this.CustomerID);
                        //没有新增
                        base.XMNickCustomerMappingService.BatchMarkXMNickCustomerMappingsInsert(NickIds, this.CustomerID, Convert.ToInt16(customerInfo.DepartmentID));

                    }
                }
                isSucess = true;
            }
            HiddenField1.Value = projectIDs;
            if (isSucess)
            {
                base.ShowMessage("操作成功！");
                BindrptProjectList();
            }
            else
            {
                base.ShowMessage("请选择正确的项目，操作失败！");
                BindrptProjectList();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        private int CustomerID
        {
            get
            {
                return CommonHelper.QueryStringInt("CustomerID");
            }
        }
    }
}