using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

using Ext.Net;
using ExtNet = Ext.Net;
using Ext.Net.Utilities;
using HozestERP.BusinessLogic;
using HozestERP.Common.Utils;
using HozestERP.Web.Controls;

namespace HozestERP.Web
{
    public partial class Protal : BaseAdministrationPage
    {

        protected override void OnPreInit(EventArgs e)
        {
            base.OnPreInit(e);
            Page.Theme = "";
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            string[] Day = new string[] { "星期日", "星期一", "星期二", "星期三", "星期四", "星期五", "星期六" };
            this.lblDateTime.Text = DateTime.Now.ToString("yyyy年MM月dd日 ") + Day[Convert.ToInt16(DateTime.Now.DayOfWeek)];
            this.lblDayInfo.Text = ChinaDate.GetMonth(DateTime.Now) + ChinaDate.GetDay(DateTime.Now)
                + " " + ChinaDate.GetSolarTerm(DateTime.Now)
                + " " + ChinaDate.GetHoliday(DateTime.Now)
                + " " + ChinaDate.GetChinaHoliday(DateTime.Now);
            var customer = HozestERPContext.Current.User;
            var customerInfo = HozestERPContext.Current.User.SCustomerInfo;
            if (customerInfo != null)
            {
                this.lblUserName.Text = customerInfo.FullName;
                if (customerInfo.SDepartment != null)
                    this.lblUserName.Text += "【" + customerInfo.SDepartment.DepName + "】";
            }
            this.BindColumn();

            //int year = 2000;
            //for (int i = 0; i <= 50; i++)
            //{
            //    cbYear.Items.Add(new ExtNet.ListItem((year + i).ToString() + "年", (year + i).ToString()));
            //}

            //for (int i = 1; i <= 12; i++)
            //{
            //    cbMonth.Items.Add(new ExtNet.ListItem(i.ToString().PadLeft('0',2) + "月", i.ToString().PadLeft('0',2)));
            //}
        }

        #region  protected void BindColumn()
        /// <summary>
        /// 
        /// </summary>
        //protected void BindColumn()
        //{
        //    var customer = CRMContext.Current.User;
        //    if (customer != null)
        //    {
        //        var porColumnNumbers = base.PortalService.GetPortalColumnNumberList(customer.CustomerID);

        //        for (int i = 0; i < porColumnNumbers.Count; i++)
        //        {
        //            PortalColumn portalColumn = new PortalColumn();
        //            portalColumn.ID = "PortalColumn" + porColumnNumbers[i].ID;
        //            portalColumn.Cls = "x-column-padding";
        //            if (i == customer.SPortalColumnNumbers.Count - 1)
        //            {
        //                portalColumn.Cls = "x-column-padding1";
        //            }
        //            double columnWidth = 0.3;
        //            columnWidth = Convert.ToDouble(porColumnNumbers[i].Width) / 100.00;
        //            if (columnWidth <= 0)
        //            {
        //                columnWidth = 0.3;
        //            }
        //            portalColumn.ColumnWidth = columnWidth;
        //            this.Portal1.Items.Add(portalColumn);
        //            if (porColumnNumbers[i].SPortalColumns != null)
        //            {

        //                var columns = porColumnNumbers[i].SPortalColumns.OrderBy(p=>p.SortIndex).ToList();
        //                if (columns.Count > 0)
        //                {
        //                    for (int j = 0; j < columns.Count(); j++)
        //                    {
        //                        Portlet portlet = new Portlet();
        //                        //portlet.ID = "myPortlet" + columns[j].ID.ToString();
        //                        //portlet.Tools.Add(new Tool(ToolType.Refresh, "Ext.getCmp('" + portlet.ID + "').reload(true);", "Refresh Portlet"));
        //                        //portlet.Tools.Add(new Tool(ToolType.Close, "Ext.getCmp('" + portlet.ID + "').hide();", "Close Portlet"));
        //                        portlet.CloseAction = CloseAction.Hide;
        //                        portlet.Title = columns[j].SPortal.Name;
        //                        portlet.IconCls = columns[j].SPortal.iconCls;
        //                        portlet.AutoHeight = true;

        //                        portlet.DirectEvents.Hide.Event += new ComponentDirectEvent.DirectEventHandler(Hide_Event);
        //                        portlet.DirectEvents.Hide.ExtraParams.Add(new Ext.Net.Parameter("ID", columns[j].ID.ToString()));
        //                        portlet.DirectEvents.Hide.ExtraParams.Add(new Ext.Net.Parameter("Name", columns[j].SPortal.Name));
        //                        portlet.AutoWidth = true;
        //                        portlet.ID = "portlet" + columns[j].SPortal.Url.Substring(columns[j].SPortal.Url.LastIndexOf("/") + 1,
        //                            columns[j].SPortal.Url.LastIndexOf(".aspx") - columns[j].SPortal.Url.LastIndexOf("/") - 1);
        //                        if (!string.IsNullOrEmpty(columns[j].SPortal.Url))
        //                        {
        //                            switch (portlet.Title)
        //                            {
        //                                //case "公告通知":
        //                                //    {
        //                                //        //portlet.ID = "portletBullet";
        //                                //        portlet.AutoLoad.Url = CommonHelper.GetStoreLocation() + columns[j].SPortal.Url;
        //                                //    }
        //                                //    break;
        //                                //case "充值警告":
        //                                //    {
        //                                //        //portlet.ID = "portletWarnDetail";
        //                                //        portlet.AutoLoad.Url = CommonHelper.GetStoreLocation() + columns[j].SPortal.Url;
        //                                //    }
        //                                //    break;
        //                                case "入账审批":
        //                                    {
        //                                        //portlet.ID = "portletRelatedContractPayment";
        //                                        portlet.AutoLoad.Url = CommonHelper.GetStoreLocation() + columns[j].SPortal.Url + "?date=" + cbYear.Value + "-" + cbMonth.Value + "-" + "01";
        //                                        string handler = "var year = Ext.getCmp('cbYear').getValue();var month = Ext.getCmp('cbMonth').getValue();var date = year + \"-\" + month + \"-\" + \"01\";window.frames[\"" + portlet.ID + "_IFrame\"].location = '" + columns[j].SPortal.Url + "?date=' + date;";
        //                                        portlet.Tools.Add(new Tool(ToolType.Refresh, handler, "Refresh Portlet"));
        //                                    }
        //                                    break;
        //                                //case "待审批":
        //                                //    {
        //                                //        //portlet.ID = "portletApproval";
        //                                //        portlet.AutoLoad.Url = CommonHelper.GetStoreLocation() + columns[j].SPortal.Url;
        //                                //    }
        //                                //    break;
        //                                //case "客户类型分析":
        //                                //    {
        //                                //        //portlet.ID = "portletCustomerTypeAnalyse";
        //                                //        portlet.AutoLoad.Url = CommonHelper.GetStoreLocation() + columns[j].SPortal.Url;
        //                                //    }
        //                                //    break;

        //                                default:
        //                                    {
        //                                        portlet.AutoLoad.Url = CommonHelper.GetStoreLocation() + columns[j].SPortal.Url + "?date=" + cbYear.Value + "-" + cbMonth.Value + "-" + "01";
        //                                        string handler = "var year = Ext.getCmp('cbYear').getValue();var month = Ext.getCmp('cbMonth').getValue();var date = year + \"-\" + month + \"-\" + \"01\";window.frames[\"" + portlet.ID + "_IFrame\"].location = '" + columns[j].SPortal.Url + "?date=' + date;";
        //                                        portlet.Tools.Add(new Tool(ToolType.Refresh, handler, "Refresh Portlet"));
        //                                        //portlet.AutoLoad.Url = CommonHelper.GetStoreLocation() + columns[j].SPortal.Url;
        //                                        //portlet.Tools.Add(new Tool(ToolType.Refresh, "Ext.getCmp('" + portlet.ID + "').reload(true);", "Refresh Portlet"));
        //                                    }
        //                                    break;
        //                            }
        //                            //portlet.AutoLoad.Url = CommonHelper.GetStoreLocation() + columns[j].SPortal.Url;
        //                            //portlet.Tools.Add(new Tool(ToolType.Refresh, "Ext.getCmp('" + portlet.ID + "').reload(true);", "Refresh Portlet"));
                                    
        //                            portlet.Tools.Add(new Tool(ToolType.Close, "Ext.getCmp('" + portlet.ID + "').hide();", "Close Portlet"));
        //                            portlet.AutoLoad.Mode = LoadMode.IFrame;
        //                            portlet.AutoLoad.ShowMask = true;
        //                            portlet.AutoLoad.MaskMsg = "正在初始化 " + columns[j].SPortal.Name + "，请稍等...";
        //                        }
        //                        portalColumn.AutoScroll = false;
        //                        portalColumn.Items.Add(portlet);
        //                        portalColumn.DoLayout();
        //                    }
        //                }
        //            }
        //        }
        //    }
        //}

        protected void BindColumn()
        {
            var customer = HozestERPContext.Current.User;
            if (customer != null)
            {
                var porColumnNumbers = base.PortalService.GetPortalColumnNumberList(customer.CustomerID);

                for (int i = 0; i < porColumnNumbers.Count; i++)
                {
                    PortalColumn portalColumn = new PortalColumn();
                    portalColumn.ID = "PortalColumn" + porColumnNumbers[i].ID;
                    portalColumn.Cls = "x-column-padding";
                    if (i == customer.SPortalColumnNumbers.Count - 1)
                    {
                        portalColumn.Cls = "x-column-padding1";
                    }
                    double columnWidth = 0.3;
                    columnWidth = Convert.ToDouble(porColumnNumbers[i].Width) / 100.00;
                    if (columnWidth <= 0)
                    {
                        columnWidth = 0.3;
                    }
                    portalColumn.ColumnWidth = columnWidth;
                    this.Portal1.Items.Add(portalColumn);
                    if (porColumnNumbers[i].SPortalColumns != null)
                    {

                        var columns = porColumnNumbers[i].SPortalColumns.OrderBy(p => p.SortIndex).ToList();
                        if (columns.Count > 0)
                        {
                            for (int j = 0; j < columns.Count(); j++)
                            {
                                Portlet portlet = new Portlet();
                                //portlet.ID = "myPortlet" + columns[j].ID.ToString();
                                portlet.ID = "portlet" + columns[j].SPortal.Url.Substring(columns[j].SPortal.Url.LastIndexOf("/") + 1,
                                    columns[j].SPortal.Url.LastIndexOf(".aspx") - columns[j].SPortal.Url.LastIndexOf("/") - 1);
                                portlet.Tools.Add(new Tool(ToolType.Refresh, "Ext.getCmp('" + portlet.ID + "').reload(true);", "Refresh Portlet"));
                                portlet.Tools.Add(new Tool(ToolType.Close, "Ext.getCmp('" + portlet.ID + "').hide();", "Close Portlet"));
                                portlet.CloseAction = CloseAction.Hide;
                                portlet.Title = columns[j].SPortal.Name;
                                portlet.IconCls = columns[j].SPortal.iconCls;

                                portlet.DirectEvents.Hide.Event += new ComponentDirectEvent.DirectEventHandler(Hide_Event);
                                portlet.DirectEvents.Hide.ExtraParams.Add(new Ext.Net.Parameter("ID", columns[j].ID.ToString()));
                                portlet.DirectEvents.Hide.ExtraParams.Add(new Ext.Net.Parameter("Name", columns[j].SPortal.Name));
                                portlet.AutoWidth = true;
                                if (!string.IsNullOrEmpty(columns[j].SPortal.Url))
                                {
                                    portlet.AutoLoad.Url = CommonHelper.GetStoreLocation() + columns[j].SPortal.Url;
                                    portlet.AutoLoad.Mode = LoadMode.IFrame;
                                    portlet.AutoLoad.ShowMask = true;
                                    portlet.AutoLoad.MaskMsg = "正在初始化 " + columns[j].SPortal.Name + "，请稍等...";
                                }
                                portalColumn.AutoScroll = false;
                                portalColumn.Items.Add(portlet);
                                portalColumn.DoLayout();
                            }
                        }
                    }
                }
            }
        }
        #endregion

        protected void Hide_Event(object sender, DirectEventArgs e)
        {
            try
            {
                int portalcolumnid = 0;
                int.TryParse(e.ExtraParams["ID"].ToString(), out portalcolumnid);
                base.PortalService.DeletePortalColumn(portalcolumnid);
                X.Msg.Notify("提示信息", e.ExtraParams["Name"].ToString() + "　成功移除.").Show();
            }
            catch (Exception err)
            {
                X.Msg.Notify("错误信息", err.Message).Show();
            }
        }

        [DirectMethod(Namespace = "CompanyX")]
        public void EventDrop(int columnIndex, int position, int portletID)
        {
            try
            {
                base.PortalService.UpdatePortalColumn(columnIndex, portletID, position);
            }
            catch (Exception err)
            {
                X.Msg.Notify("错误信息", err.Message).Show();
            }
        }

        [DirectMethod(Namespace = "CompanyX")]
        public void ShowWindow()
        {
            this.BindGrid();
            this.Window1.Show(this.btnAddPortel);

        }

        public void BindGrid()
        {

            List<object> SPrimaryData = new List<object>();
            List<object> SData1 = new List<object>();
            List<object> SData2 = new List<object>();
            List<object> SData3 = new List<object>();
            List<object> SData4 = new List<object>();

            var protals = base.PortalService.GetAddPortalClomuns(HozestERPContext.Current.User.CustomerID);
            foreach (var item in protals)
            {
                SPrimaryData.Add(new
                {
                    ID = item.ID,
                    Name = item.Name
                });
            }

            this.SPrimarySource.DataSource = SPrimaryData;
            this.SPrimarySource.DataBind();

            var customer = HozestERPContext.Current.User;

            if (customer != null)
            {
                var porColumnNumbers = customer.SPortalColumnNumbers.OrderBy(p => p.Display).ToList();

                this.cmbSelectColumn.SelectedIndex = porColumnNumbers.Count - 1;


                switch (porColumnNumbers.Count)
                {
                    case 1:
                        {
                            this.pnlColumn1.Show();
                            this.pnlColumn2.Hide();
                            this.pnlColumn3.Hide();
                            this.pnlColumn4.Hide();
                        }
                        break;
                    case 2:
                        {
                            this.pnlColumn1.Show();
                            this.pnlColumn2.Show();
                            this.pnlColumn3.Hide();
                            this.pnlColumn4.Hide();
                        }
                        break;
                    case 3:
                        {
                            this.pnlColumn1.Show();
                            this.pnlColumn2.Show();
                            this.pnlColumn3.Show();
                            this.pnlColumn4.Hide();
                        }
                        break;
                    case 4:
                        {
                            this.pnlColumn1.Show();
                            this.pnlColumn2.Show();
                            this.pnlColumn3.Show();
                            this.pnlColumn4.Show();
                        }
                        break;

                }

                if (porColumnNumbers.Count <= 0)
                {
                    this.cmbSelectColumn.Value = 4;
                }
                for (int i = 0; i < porColumnNumbers.Count; i++)
                {
                    if (porColumnNumbers[i].SPortalColumns != null)
                    {
                        var columns = porColumnNumbers[i].SPortalColumns.ToList();
                        for (int j = 0; j < columns.Count(); j++)
                        {
                            switch (i)
                            {
                                case 0:
                                    SData1.Add(new
                                    {
                                        ID = columns[j].PortalID,
                                        Name = columns[j].SPortal.Name
                                    });
                                    break;
                                case 1:
                                    SData2.Add(new
                                    {
                                        ID = columns[j].PortalID,
                                        Name = columns[j].SPortal.Name
                                    });
                                    break;
                                case 2:
                                    SData3.Add(new
                                    {
                                        ID = columns[j].PortalID,
                                        Name = columns[j].SPortal.Name
                                    });
                                    break;
                                case 3:
                                    SData4.Add(new
                                    {
                                        ID = columns[j].PortalID,
                                        Name = columns[j].SPortal.Name
                                    });
                                    break;
                            }
                        }
                    }

                    switch (i)
                    {
                        case 0:
                            this.SDataSource1.DataSource = SData1;
                            this.SDataSource1.DataBind();
                            this.txtColumnWidth1.Text = porColumnNumbers[i].Width.ToString();
                            break;
                        case 1:
                            this.txtColumnWidth2.Text = porColumnNumbers[i].Width.ToString();
                            this.SDataSource2.DataSource = SData2;
                            this.SDataSource2.DataBind();
                            break;
                        case 2:
                            this.txtColumnWidth3.Text = porColumnNumbers[i].Width.ToString();
                            this.SDataSource3.DataSource = SData3;
                            this.SDataSource3.DataBind();
                            break;
                        case 3:
                            this.txtColumnWidth4.Text = porColumnNumbers[i].Width.ToString();
                            this.SDataSource4.DataSource = SData4;
                            this.SDataSource4.DataBind();
                            break;
                    }
                }
            }
        }

        [DirectMethod(Namespace = "CompanyX")]
        public void DoSearch22()
        {
            
        }


        [DirectMethod(Namespace = "CompanyX")]
        public void SaveColumn(List<DataEves> paramDataSource1, List<DataEves> paramDataSource2
            , List<DataEves> paramDataSource3, List<DataEves> paramDataSource4)
        {
            try
            {
                int columnNumber = 0;
                int.TryParse(this.cmbSelectColumn.Value.ToString(), out columnNumber);
                List<HozestERP.BusinessLogic.ManageProtal.PortalColumnNumber> portalcolumnnumbers
                    = new List<HozestERP.BusinessLogic.ManageProtal.PortalColumnNumber>();
                for (int i = 1; i <= columnNumber; i++)
                {
                    HozestERP.BusinessLogic.ManageProtal.PortalColumnNumber portalcolumnnumber
                        = new HozestERP.BusinessLogic.ManageProtal.PortalColumnNumber();

                    portalcolumnnumber.CustomerID = HozestERPContext.Current.User.CustomerID;
                    portalcolumnnumber.Display = i;
                    decimal width = 0;
                    portalcolumnnumber.SPortalColumns = new List<HozestERP.BusinessLogic.ManageProtal.PortalColumn>();
                    #region 获取宽度,PortalColumn秩序
                    switch (i)
                    {
                        case 1:
                            {
                                decimal.TryParse(this.txtColumnWidth1.Text, out width);
                                int index = 0;
                                foreach (var item in paramDataSource1)
                                {
                                    var portal = base.PortalService.GetPortal(item.ID);
                                    portalcolumnnumber.SPortalColumns.Add(new HozestERP.BusinessLogic.ManageProtal.PortalColumn()
                                    {
                                        PortalID = item.ID,
                                        IsExpand = 0,
                                        SortIndex = index,
                                        SPortalColumnNumber = portalcolumnnumber,
                                        SPortal = portal
                                    });
                                    index++;
                                }
                            }
                            break;
                        case 2:
                            {
                                decimal.TryParse(this.txtColumnWidth2.Text, out width);
                                int index = 0;
                                foreach (var item in paramDataSource2)
                                {
                                    var portal = base.PortalService.GetPortal(item.ID);
                                    portalcolumnnumber.SPortalColumns.Add(new HozestERP.BusinessLogic.ManageProtal.PortalColumn()
                                    {
                                        PortalID = item.ID,
                                        IsExpand = 0,
                                        SortIndex = index,
                                        SPortalColumnNumber = portalcolumnnumber,
                                        SPortal = portal
                                    });
                                    index++;
                                }
                            }
                            break;
                        case 3:
                            {
                                decimal.TryParse(this.txtColumnWidth3.Text, out width);
                                int index = 0;
                                foreach (var item in paramDataSource3)
                                {
                                    var portal = base.PortalService.GetPortal(item.ID);
                                    portalcolumnnumber.SPortalColumns.Add(new HozestERP.BusinessLogic.ManageProtal.PortalColumn()
                                    {
                                        PortalID = item.ID,
                                        IsExpand = 0,
                                        SortIndex = index,
                                        SPortalColumnNumber = portalcolumnnumber,
                                        SPortal = portal
                                    });
                                    index++;
                                }
                            }
                            break;
                        case 4:
                            {
                                decimal.TryParse(this.txtColumnWidth4.Text, out width);
                                int index = 0;
                                foreach (var item in paramDataSource4)
                                {
                                    portalcolumnnumber.SPortalColumns.Add(new HozestERP.BusinessLogic.ManageProtal.PortalColumn()
                                    {
                                        PortalID = item.ID,
                                        IsExpand = 0,
                                        SortIndex = index,
                                        SPortalColumnNumber = portalcolumnnumber
                                    });
                                    index++;
                                }
                            }
                            break;
                    }
                    #endregion
                    portalcolumnnumber.Width = width;
                    portalcolumnnumbers.Add(portalcolumnnumber);
                }

                base.PortalService.SavePortalColumnsNumber(portalcolumnnumbers, HozestERPContext.Current.User.CustomerID);

                X.Msg.Notify("提示信息", "修改成功.点击刷新安扭.").Show();
            }
            catch (Exception err)
            {
                X.Msg.Notify("错误信息", "保存失败").Show();
            }
            this.Window1.Hide(this.btnAddPortel, "function(){window.location='Protal.aspx';}");
        }

        public class DataEves
        {
            public int ID { get; set; }

            public string Name { get; set; }
        }

    }
}