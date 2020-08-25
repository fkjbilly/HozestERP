using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using HozestERP.BusinessLogic.Codes;
using HozestERP.BusinessLogic.ManageProject;
using HozestERP.Common;
using HozestERP.Common.Utils;
using Newtonsoft.Json.Linq;
using System.Threading;

namespace HozestERP.Web.ManageProject
{
    public partial class XMXLMInventoryList : BaseAdministrationPage, ISearchPage
    {
        public XLMInterface xLMInterface = new BusinessLogic.ManageProject.XLMInterface();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //弹出导入页面
                this.btnImport.OnClientClick = "return ShowWindowDetail('喜临门当日库存导入','" + CommonHelper.GetStoreLocation() +
            "ManageProject/ImportXLMInventory.aspx', 500, 300, this, function(){document.getElementById('" + this.btnSearch.ClientID + "').click();});";

                this.BindGrid(1, Master.PageSize);
            }
        }

        #region ISearchPage 成员

        public void SetTrigger()
        {
            this.Master.SetTrigger(this.btnSearch.UniqueID, this.Page);
        }

        public void Face_Init()
        {
            //仓库
            //this.ddlWarehouse.Items.Clear();
            //var CodeList = base.CodeService.GetCodeListInfoByCodeTypeID(227, false);
            //this.ddlWarehouse.DataSource = CodeList;
            //this.ddlWarehouse.DataTextField = "CodeName";
            //this.ddlWarehouse.DataValueField = "CodeID";
            //this.ddlWarehouse.DataBind();
            //this.ddlWarehouse.Items.Insert(0, new ListItem("---所有---", "-1"));

            //仓库
            this.ddlWarehouse.Items.Clear();
            var CodeList = base.XMWareHousesService.GetXMWareHousesList().Where(m=>m.isEnable == false).ToArray(); 
            this.ddlWarehouse.DataSource = CodeList;
            this.ddlWarehouse.DataTextField = "Name";
            this.ddlWarehouse.DataValueField = "id";
            this.ddlWarehouse.DataBind();
            this.ddlWarehouse.Items.Insert(0, new ListItem("---所有---", "-1"));
        }

        public void BindGrid(int paramPageIndex, int paramPageSize)
        {
            //仓库
            string WarehouseID = this.ddlWarehouse.SelectedValue;
            //厂家编码
            string ManufacturersCode = this.txtManufacturersCode.Text.Trim();
            //品名规格
            string ProductName = this.txtProductName.Text.Trim();
            var list = base.XMXLMInventoryService.GetXMXLMInventoryListByParm(int.Parse(WarehouseID), ManufacturersCode, ProductName);

            //分页
            var List = new PagedList<XMXLMInventory>(list, paramPageIndex, paramPageSize, this.Master.GridViewSortField, this.Master.GridViewSortDir.ToString());
            this.Master.BindData(this.grdvClients, List, paramPageSize + 1);
        }

        #endregion

        /// <summary>
        /// 条件查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            this.BindGrid(1, Master.PageSize);
        }

        /// <summary>
        /// 刷新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            this.BindGrid(Master.PageIndex, Master.PageSize);
        }

        protected void btnXLMSynchro_Click(object sender, EventArgs e)
        {
            string msg = "";
            string method = "qs.InventoryInfo.get";
            //string[] WarehouseList = { "棉花仓(EBD)", "总部仓(EBD)", "滨海港(EBD)", "EBD香河成品仓库", "EBD成都成品仓库", "EBD佛山成品仓库", "迪米家具仓(EBD)" };
            string[] WarehouseList = {"总部仓(EBD)", "滨海港(EBD)", "EBD香河成品仓库", "EBD成都成品仓库", "EBD佛山成品仓库", "迪米家具仓(EBD)","宝瑞(爱倍)" };
            List<XMXLMInventory> List = new List<XMXLMInventory>();
            var product = base.XMProductService.GetXMProductList();
            foreach (var warehouse in WarehouseList)
            {
                //if (msg.IndexOf("错误") != -1)
                //{
                //    break;
                //}

                int WarehouseID = 0;
                if (warehouse.IndexOf("棉花仓") != -1)
                {
                    WarehouseID = 693;//南方仓库
                }
                else if (warehouse.IndexOf("总部仓") != -1)
                {
                    WarehouseID = 693;//南方仓库
                }
                else if (warehouse.IndexOf("滨海港") != -1)
                {
                    WarehouseID = 693;//南方仓库
                }
                else if (warehouse.IndexOf("宝瑞") != -1)
                {
                    WarehouseID = 693;//南方仓库
                }
                else if (warehouse.IndexOf("EBD香河成品仓库") != -1)
                {
                    WarehouseID = 694;//北方仓库
                }
                else if (warehouse.IndexOf("EBD成都成品仓库") != -1)
                {
                    WarehouseID = 695;//成都仓库
                }
                else if (warehouse.IndexOf("EBD佛山成品仓库") != -1)
                {
                     WarehouseID = 759;//TP佛山成品仓库
                }
                else if (warehouse.IndexOf("迪米家具仓") != -1)
                {
                    WarehouseID = 693;//迪米家具仓(EBD)
                }
                for (int i = 1; i < 100; i++)
                {
                    Thread.Sleep(100);
                    StringBuilder body = new StringBuilder();
                    body.Append("{\"code\":").Append("\"\"").Append(",");
                    body.Append("\"warehousename\":").Append("\"" + warehouse + "\"").Append(",");
                    body.Append("\"pageNo\":").Append("\"" + i + "\"").Append(",");
                    body.Append("\"pageSize\":").Append("\"200\"").Append("}");

                    string url = xLMInterface.GetUrl(method, body.ToString());
                    //url += "?" + parm;
                    string josnStr = xLMInterface.GetResponseData(body.ToString(), url);//GetInfo(url);
                    if (josnStr == "error")
                    {
                        msg += "网络连接错误，请稍后再试！";
                        break;
                    }

                    Dictionary<string, object> data = xLMInterface.JsonToDictionary(josnStr);
                    if (josnStr.IndexOf("\"flag\" : \"failure\"") != -1 && data.ContainsKey("message"))
                    {
                        if (msg.IndexOf(data["message"].ToString()) == -1)
                        {
                            msg += "参数错误：" + data["message"].ToString() + "！<br/>";
                        }
                        break;
                    }

                    if (UpdateXLMInventory(josnStr, WarehouseID, product,ref msg, ref List))
                    {
                        break;
                    }
                }
            }

            if (msg != "")
            {
                //if (msg.IndexOf("错误") == -1)
                //{
                //    msg = "厂家编码：" + msg + "在数据库中不存在！";
                //}
                base.ShowMessage(msg);
            }
            else
            {
                if (List.Count > 0)
                {
                    var ManufacturersCodeList = List.Select(m => m.ManufacturersCode).Distinct().ToList();
                    var newDic = List.Distinct().ToDictionary(m => (m.ManufacturersCode + m.WarehouseID), m => m.Inventory);//所有获取的库存信息的厂家编码和对应的库存
                    var updatelist = base.XMXLMInventoryService.GetXMXLMInventoryListByParm(ManufacturersCodeList);
                    foreach (var item in updatelist)
                    {
                        if (newDic.Keys.Contains(item.ManufacturersCode + item.WarehouseID))
                        {
                            item.Inventory = newDic[item.ManufacturersCode + item.WarehouseID];
                            item.CreateDate = DateTime.Now;
                        }
                    }
                    var oldMCode = updatelist.Select(m => m.ManufacturersCode).ToList();
                    var insertlist = List.Where(m => !oldMCode.Contains(m.ManufacturersCode)).ToList();
                    base.XMXLMInventoryService.OperationXMXLMInventory(updatelist, insertlist);
                    //foreach (var item in List)
                    //{
                    //    var list = base.XMXLMInventoryService.GetXMXLMInventoryListByParm((int)item.WarehouseID, item.ManufacturersCode);
                    //    if (list != null && list.Count > 0)
                    //    {
                    //        if (item.Inventory != list[0].Inventory)
                    //        {
                    //            list[0].Inventory = item.Inventory;
                    //            base.XMXLMInventoryService.UpdateXMXLMInventory(list[0]);
                    //        }
                    //    }
                    //    else
                    //    {
                    //        base.XMXLMInventoryService.InsertXMXLMInventory(item);
                    //    }
                    //}
                }
                base.ShowMessage("库存同步完成！");

                this.BindGrid(1, Master.PageSize);
            }
        }

        public bool UpdateXLMInventory(string josnStr, int WarehouseID,List<XMProduct> product, ref string msg, ref List<XMXLMInventory> List)
        {
            try
            {
                //josnStr = "{\"total\": 2,\"inventorys\": [{\"warehouseName\": \"测试仓库\",\"code\": \"ywq001\",\"name\": \"ywq001\",\"quantity\": \"0\",\"kyQuantity\": \"0\",\"skuCode\": \"ywq001\",\"skuName\": \"ywq001\"},{\"warehouseName\": \"测试仓库\",\"code\": \"ywq002\",\"name\": \"ywq002\",\"quantity\": \"0\",\"kyQuantity\": \"0\",\"skuCode\": \"ywq002\",\"skuName\": \"ywq002\"}]}";
                bool IsBreak = false;
                Dictionary<string, object> data = xLMInterface.JsonToDictionary(josnStr);
                
                if (data.ContainsKey("total") && (int)(data["total"]) > 0)
                {
                    ArrayList array = (ArrayList)data["inventorys"];
                    foreach (Dictionary<string, object> item in array)
                    {
                        if (item["code"].ToString() == "10109370" || item["code"].ToString() == "10114468" || item["code"].ToString() == "10114469") 
                        {
                            string aa = "asdasd";
                        }
                        string ManufacturersCode = item["code"].ToString();//商品代码
                        string Inventory = item["kyQuantity"].ToString();//可用数
                        if (Inventory != "")
                        {
                            //var Product = base.XMProductService.getXMProductByManufacturersCode(ManufacturersCode);
                            var Product = product.FirstOrDefault(m => m.ManufacturersCode == ManufacturersCode);
                            if (Product != null)
                            {
                                var WarehouseInfo = List.Find(x => x.WarehouseID == WarehouseID && x.ManufacturersCode == ManufacturersCode);
                                if (WarehouseInfo != null)
                                {
                                    WarehouseInfo.Inventory += int.Parse(Inventory);
                                }
                                else
                                {
                                    XMXLMInventory Info = new XMXLMInventory();
                                    Info.WarehouseID = WarehouseID;
                                    Info.ManufacturersCode = ManufacturersCode;
                                    Info.ProductName = Product.ProductName;
                                    Info.Specifications = Product.Specifications;
                                    //Info.Type = Type;
                                    //Info.BarCode = BarCode;
                                    Info.Unit = Product.ProductUnit;
                                    Info.Inventory = int.Parse(Inventory);
                                    Info.CreateDate = DateTime.Now;
                                    Info.CreateID = HozestERP.BusinessLogic.HozestERPContext.Current.User.CustomerID;
                                    List.Add(Info);
                                }
                            }
                        }
                        //else
                        //{
                        //    if (msg.IndexOf(ManufacturersCode) == -1)
                        //    {
                        //        msg += ManufacturersCode + "，";
                        //    }
                        //}
                    }
                }
                else
                {
                    IsBreak = true;
                }

                return IsBreak;
            }
            catch
            {
                return true;
            }
        }
    }
}