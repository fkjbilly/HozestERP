using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HozestERP.BusinessLogic.ManageProject;
using HozestERP.BusinessLogic.ManageCustomerService;
using HozestERP.BusinessLogic;
using HozestERP.Common.Utils;
using System.Web.UI.HtmlControls;
using HozestERP.Web.Modules;
using System.Transactions;
namespace HozestERP.Web.ManageCustomerService
{
    public partial class XMCustomerServiceLevelAdd : BaseAdministrationPage, IEditPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            { loadDate(); }
        }
        
        protected void btnSave_Click(object sender, EventArgs e)
        {
            string rank_name =  RankName.Text;
            string rank_number = RankNumber.Text;
            string basic_salary = BasicSalary.Text;
            string bonus_base = BonusBase.Text;
            int a = 0;
            if (rank_name.ToString() == "" || rank_number.ToString() == "" || basic_salary.ToString() == "" || bonus_base.ToString() == "")
            {
                base.ShowMessage("等级名称、等级编号、底薪、奖金基数不能为空!");
                return;
            }
            else if (int.TryParse(rank_number, out a) == false || int.TryParse(basic_salary, out a) == false || int.TryParse(bonus_base, out a) == false)
            {
                base.ShowMessage("等级编号、底薪、奖金基数必须为整数!");
                return;
            }
            else
            {
                if (XMCustomerServiceLevelId == -1)//添加
                {
                    XMCustomerServiceLevel orderinfoapp = new XMCustomerServiceLevel();
                    orderinfoapp.RankName = rank_name;
                    orderinfoapp.RankNumber = int.Parse(rank_number);
                    orderinfoapp.BasicSalary = int.Parse(basic_salary);
                    orderinfoapp.BonusBase = int.Parse(bonus_base);
                    orderinfoapp.IsEnabled = false;
                    orderinfoapp.CreatorID = HozestERPContext.Current.User.CustomerID;
                    orderinfoapp.CreateTime = DateTime.Now;
                    orderinfoapp.UpdatorID = HozestERPContext.Current.User.CustomerID;
                    orderinfoapp.UpdateTime = DateTime.Now;
                    base.XMCustomerServiceLevelService.InsertXMCustomerServiceLevel(orderinfoapp);
                    //this.Master.JsWrite("alert('保存成功！')", "");
                    base.ShowMessage("保存成功!");
                }
                else  //编辑
                {
                    XMCustomerServiceLevel orderinfoapp = base.XMCustomerServiceLevelService.GetXMCustomerServiceLevelById(XMCustomerServiceLevelId);
                    if (orderinfoapp != null)//判断有没有这条数据
                    {
                        orderinfoapp.RankName = rank_name;
                        orderinfoapp.RankNumber = int.Parse(rank_number);
                        orderinfoapp.BasicSalary = int.Parse(basic_salary);
                        orderinfoapp.BonusBase = int.Parse(bonus_base);
                        orderinfoapp.IsEnabled = false;
                        orderinfoapp.UpdatorID = HozestERPContext.Current.User.CustomerID;
                        orderinfoapp.UpdateTime = DateTime.Now;
                        base.XMCustomerServiceLevelService.UpdateXMCustomerServiceLevel(orderinfoapp);
                        base.ShowMessage("保存成功!");
                    }
                }
            }
        }

        public void loadDate() {
            if (XMCustomerServiceLevelId == -1)
            {
                this.Face_Init();
            }
            else
            {
                var XMOrderInfoApp = base.XMCustomerServiceLevelService.GetXMCustomerServiceLevelById(XMCustomerServiceLevelId);
                this.RankName.Text = XMOrderInfoApp.RankName;
                this.RankNumber.Text = XMOrderInfoApp.RankNumber.ToString();
                this.BasicSalary.Text = XMOrderInfoApp.BasicSalary.ToString();
                this.BonusBase.Text = XMOrderInfoApp.BonusBase.ToString();
            }
        }
            
        

        /// <summary>
        /// 操作类型
        /// </summary>
        public int XMCustomerServiceLevelId
        {
            get
            {
                return CommonHelper.QueryStringInt("XMCustomerServiceLevelId");
            }
        }

        public void Face_Init()
        {

        }

        public void SetTrigger()
        {
            
        }
    }
}