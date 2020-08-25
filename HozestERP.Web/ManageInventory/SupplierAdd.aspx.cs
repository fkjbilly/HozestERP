using System;
using System.Web.UI;
using HozestERP.BusinessLogic;
using HozestERP.Common.Utils;
using HozestERP.BusinessLogic.ManageInventory;

namespace HozestERP.Web.ManageInventory
{
    public partial class SupplierAdd : BaseAdministrationPage, IEditPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadData(this.Id);
            }
        }

        private void loadData(int id)
        {
            if (id != 0)
            {
                XMSuppliers info = base.XMSuppliersService.GetXMSuppliersById(id);
                if (info != null)
                {
                    txtSupplierName.Text = info.SupplierName;
                    txtContacter.Text = info.Contacter;
                    txtTel.Text = info.Tel;
                    txtQQ.Text = info.QQ;
                    txtMobile.Text = info.Mobile;
                    txtAddress.Text = info.Address;
                    txtBankName.Text = info.BankName;
                    txtBankAcount.Text = info.BankAccount;
                    txtTaxNum.Text = info.TaxNumber;
                    txtFax.Text = info.Fax;
                    txtNote.Text = info.Note;
                }
            }
        }

        /// <summary>
        /// 自动生成供应商编码
        /// </summary>
        /// <returns></returns>
        private string AutoSupplierNumber()
        {
            string supplierCode = "";       //自动生成供应商编码
            int number = 1;
            var suppliers = base.XMSuppliersService.GetXMSuppliersList();
            if (suppliers != null && suppliers.Count > 0)
            {
                number = suppliers[0].Id + 1;
            }
            supplierCode = "SU" + DateTime.Now.ToString("yyyyMMddHHmmss") + number.ToString();
            return supplierCode;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid) return;
            if (Type == 0)                   //新增供应商
            {
                string supCode = AutoSupplierNumber();      //自动生成供应商编码
                string supName = txtSupplierName.Text.Trim();   //供应商名称
                var info = base.XMSuppliersService.GetXMSupplierBySupplierName(supName);
                if (info != null && info.Count > 0)
                {
                    base.ShowMessage("供应商名称已经存在！");
                    return;
                }
                string contacter = txtContacter.Text.Trim();     //联系人
                string tel = txtTel.Text.Trim();                           //联系电话
                string qq = txtQQ.Text.Trim();                         //qq
                string mobile = txtMobile.Text.Trim();              //手机
                string address = txtAddress.Text.Trim();          //地址
                string bank = txtBankName.Text.Trim();          //开户行
                string bankacount = txtBankAcount.Text.Trim();         //开户行账号
                string tax = txtTaxNum.Text.Trim();                            //税
                string fax = txtFax.Text.Trim();                                    //传真
                string note = txtNote.Text.Trim();                              //备注
                XMSuppliers supplier = new XMSuppliers();
                supplier.SupplierCode = supCode;
                supplier.SupplierName = supName;
                supplier.Contacter = contacter;
                supplier.Tel = tel;
                supplier.QQ = qq;
                supplier.Mobile = mobile;
                supplier.Address = address;
                supplier.BankName = bank;
                supplier.BankAccount = bankacount;
                supplier.TaxNumber = tax;
                supplier.Fax = fax;
                supplier.Note = note;
                supplier.UpdateID = supplier.CreateID = HozestERPContext.Current.User.CustomerID;
                supplier.UpdateDate = supplier.CreateDate = DateTime.Now;
                supplier.IsDeleted = false;
                base.XMSuppliersService.InsertXMSuppliers(supplier);
            }
            else               //编辑
            {
                string supName = txtSupplierName.Text.Trim();   //供应商名称
                string contacter = txtContacter.Text.Trim();     //联系人
                string tel = txtTel.Text.Trim();                           //联系电话
                string qq = txtQQ.Text.Trim();                         //qq
                string mobile = txtMobile.Text.Trim();              //手机
                string address = txtAddress.Text.Trim();          //地址
                string bank = txtBankName.Text.Trim();          //开户行
                string bankacount = txtBankAcount.Text.Trim();         //开户行账号
                string tax = txtTaxNum.Text.Trim();                            //税
                string fax = txtFax.Text.Trim();                                    //传真
                string note = txtNote.Text.Trim();                              //备注
                XMSuppliers Info = base.XMSuppliersService.GetXMSuppliersById(Id);
                if (Info != null)
                {
                    Info.SupplierName = supName;
                    Info.Contacter = contacter;
                    Info.Tel = tel;
                    Info.QQ = qq;
                    Info.Mobile = mobile;
                    Info.Address = address;
                    Info.BankName = bank;
                    Info.BankAccount = bankacount;
                    Info.TaxNumber = tax;
                    Info.Fax = fax;
                    Info.Note = note;
                    Info.UpdateDate = DateTime.Now;
                    Info.UpdateID = HozestERPContext.Current.User.CustomerID;
                    base.XMSuppliersService.UpdateXMSuppliers(Info);
                }
            }
            this.Master.JsWrite("alert('保存成功.');window.PopClose();", "");
        }

        public int Id
        {
            get
            {
                return CommonHelper.QueryStringInt("Id");
            }
        }

        public int Type
        {
            get
            {
                return CommonHelper.QueryStringInt("Type");
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