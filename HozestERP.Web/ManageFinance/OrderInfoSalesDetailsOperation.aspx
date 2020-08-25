 
 <%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrderInfoSalesDetailsOperation.aspx.cs" Inherits="HozestERP.Web.ManageFinance.OrderInfoSalesDetailsOperation" %>
   
<%@ Register Src="~/Modules/GridNevigator.ascx" TagName="GridNevigator" TagPrefix="HozestERP" %>
    
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <style type="text/css">
        .textfield 
        {
            font-size:18px;  
            text-align:center;
           line-height:50px;
            
           
        }
        
         .textfieldV 
        {
           font-size:18px; 
           text-align:center;
           color:Red;  
        }
         
        
        </style> 
    <meta http-equiv="expires" content="0" />
    <ext:ResourcePlaceHolder ID="ResourcePlaceHolder1" runat="server" Mode="Script">
    </ext:ResourcePlaceHolder>

    <%--<script type="text/javascript">
   

   var searchArea = new 
    
    </script>--%>
</head>
<body>
     <form id="form1" runat="server">  
    <ext:ResourceManager ID="ResourceManager2" runat="server" Namespace="CompanyX" ShowWarningOnAjaxFailure="false" /> 
    
    <ext:Viewport ID="Viewport1" runat="server"  Region="Center"  
         Layout="BorderLayout"  > 
        <Items>   
            <ext:Panel ID="pnlRoleModule" Icon="Application" Region="North" Height="250"  Layout="BorderLayout"  Border="false" runat="server"> 
                  
              <TopBar>
                <ext:Toolbar  runat="server"  Layout="ToolbarLayout" > 
                <LayoutConfig> 
                <ext:LayoutConfig  />
                </LayoutConfig>
                        <Items>
                            <ext:Button ID="btnSearch" runat="server" Text="查询" Icon="Magnifier">
                            <DirectEvents>
                            <Click  OnEvent="btnSearch_Click">
                            <EventMask ShowMask="true" Msg="正在查询……" />
                            </Click> 
                            </DirectEvents>
                            </ext:Button>  
                        <ext:ToolbarSeparator>
                            </ext:ToolbarSeparator>
                            <ext:Button ID="btnOrderInfoSalesDetailsExport" runat="server" Icon="ApplicationViewTile" Text="导出销售明细" 
                             OnClick="btnOrderInfoSalesDetailsExport_Click" AutoPostBack="true">
                            <%--  使用<Click> </Click>  导出后无法弹出保存excle 小窗口  
                            <DirectEvents>
                            <Click  OnEvent="btnOrderInfoSalesDetailsExport_Click"  Timeout="90000">
                            <EventMask ShowMask="true" Msg="正在导出……" />
                            </Click>  
                            </DirectEvents> --%>
                            </ext:Button>  
                        </Items>
                    </ext:Toolbar> 
               </TopBar>

              <Items>     
                       <ext:FormPanel  ID="fromPanel1" runat="server" Region="Center"  Collapsed="false" Border="false"
                        Frame="true" LabelAlign="Right"   BodyStyle="padding:5px;"  MonitorValid="true" 
                         LabelWidth="80"     Layout="BorderLayout"   >  
                           <LayoutConfig>  
                           <ext:TableLayoutConfig Columns="5"></ext:TableLayoutConfig>
                            </LayoutConfig>   
                        <Items>  
                         
                           <ext:ComboBox ID="cbPlatformTypeId" runat="server" FieldLabel="平台类型" TypeAhead="true" Editable="false" LazyRender="true"  TriggerAction="All" 
                           Mode="Local" Width="230"  > 
                           </ext:ComboBox>   
                           <ext:ComboBox 
                                ID="cbXMProjectTypeId"
                                runat="server"
                                Editable="false" 
                                ForceSelection="true"
                                TriggerAction="All"
                                Width="230"
                                FieldLabel="项目类型"  > 
                                <DirectEvents>   
                                   <Select OnEvent="cbXMProjectTypeId_Change">
                                   <EventMask  ShowMask="true" Msg="正在加载……" /> 
                                   </Select>
                               </DirectEvents>   
                           </ext:ComboBox> 
                           <ext:Panel ID="ComboBoxXMProjectPanel" runat="server" > 
                            <Items>
                           <ext:ComboBox 
                                ID="cbXMProject"
                                runat="server"
                                Editable="false" 
                                ForceSelection="true"
                                TriggerAction="All"
                                Width="230"
                                FieldLabel="项目名称"  > 
                                <DirectEvents>   
                                   <Select OnEvent="cbXMProject_Change">
                                   <EventMask  ShowMask="true" Msg="正在加载……" /> 
                                   </Select>
                               </DirectEvents>   
                           </ext:ComboBox>   
                           </Items>
                           </ext:Panel> 
                           <ext:Panel ID="ComboBoxPanel1" runat="server" > 
                             <Items>   
                               <ext:ComboBox 
                               ID="cbNick"  
                               runat="server"   Editable="false"  
                               ForceSelection="true" TriggerAction="All"  AutoDataBind="true" 
                               TypeAhead="true"   FieldLabel="店铺名称"  Width="230"   >    
                               </ext:ComboBox>
                             </Items> 
                            </ext:Panel>  
                           <ext:TextField ID="txtManufacturersCode" runat="server" FieldLabel="厂家编码" Width="230" ></ext:TextField> 
                             

                           <ext:ComboBox ID="cbOrderStatus" runat="server" FieldLabel="时间类型" TypeAhead="true" Editable="false" LazyRender="true"  TriggerAction="All" 
                           Mode="Local" Width="230"  ></ext:ComboBox> 
                            <ext:DateField ID="txtOrderInfoModifiedStart" runat="server" Vtype="daterange" FieldLabel="开始日期" Format="yyyy-MM-dd" MsgTarget="Side" Width="230"   /> 
                           <ext:DateField ID="txtOrderInfoModifiedEnd" runat="server" Vtype="daterange"   FieldLabel="结束日期" Format="yyyy-MM-dd" MsgTarget="Side" Width="230"   /> 
                           <ext:Label ID="label6" runat="server" FieldLabel=""></ext:Label> 
                           <ext:Label ID="label7" runat="server" FieldLabel=""></ext:Label> 
                            
                            <ext:Label ID="txtPayPriceV" runat="server" FieldLabel=""  Width="150"      CtCls="textfield"/> 
                            <ext:Label ID="txtSumProductNumV" runat="server" FieldLabel=""  Width="150"      CtCls="textfield"/> 
                            <ext:Label ID="txtSumFactoryPriceV" runat="server" FieldLabel=""  Width="150" CtCls="textfield" />
                            <ext:Label ID="txtSumCashBackMoneyV" runat="server" FieldLabel=""  Width="200" CtCls="textfield" />
                            <ext:Label ID="txtSumSalePriceV" runat="server" FieldLabel="" Width="200" CtCls="textfield" />

                            <ext:Label ID="txtPayPriceSum" runat="server" FieldLabel=""  Width="150" CtCls="textfieldV" />  
                            <ext:Label ID="txtSumProductNumSum" runat="server" FieldLabel=""  Width="150"  CtCls="textfieldV" /> 
                            <ext:Label ID="txtSumFactoryPriceSum" runat="server" FieldLabel=""  Width="150" CtCls="textfieldV" />
                            <ext:Label ID="txtSumCashBackMoneySum" runat="server" FieldLabel=""  Width="200" CtCls="textfieldV" />
                            <ext:Label ID="txtSumSalePriceSum" runat="server" FieldLabel="" Width="200" CtCls="textfieldV" />
                             
                            <ext:Label ID="txtSumFeeV" runat="server" FieldLabel="" Width="200" CtCls="textfield" /> 
                            <ext:Label ID="txtSumDeductionV" runat="server" FieldLabel=""  Width="150" CtCls="textfield" /> 
                           <ext:Label ID="label8" runat="server" FieldLabel=""></ext:Label> 
                           <ext:Label ID="label9" runat="server" FieldLabel=""></ext:Label> 
                           <ext:Label ID="label10" runat="server" FieldLabel=""></ext:Label> 
                            
                            <ext:Label ID="txtSumFeeSum" runat="server" FieldLabel="" Width="200" CtCls="textfieldV" /> 
                            <ext:Label ID="txtSumDeductionSum" runat="server" FieldLabel=""  Width="150" CtCls="textfieldV" />  
                           <ext:Label ID="label11" runat="server" FieldLabel=""></ext:Label> 
                           <ext:Label ID="label12" runat="server" FieldLabel=""></ext:Label> 
                           <ext:Label ID="label13" runat="server" FieldLabel=""></ext:Label>                           
                             
                             
                        </Items>   
                    </ext:FormPanel>
                   
                </Items>
                
            </ext:Panel> 

            <ext:TabPanel ID="tabCenter" Region="Center" EnableTabScroll="true" LayoutOnTabChange="true"
                Border="false" runat="server">
                <Items>
                     
                    <ext:Panel ID="PanelOrderInfoDetails" Title="订单明细" Region="Center" Layout="BorderLayout" Icon="CalendarSelectDay" runat="server"> 
                   <%--  <AutoLoad  ShowMask="true" Url="" Mode="IFrame" MaskMsg="正在初始化，请稍等..."></AutoLoad>--%>
                        <Items> 
                            <ext:GridPanel ID="GridPanel5" runat="server" Region="Center"  StripeRows="true" AutoScroll="true" AutoDataBind="false" Border="false">
                                <Store> 
                                    <ext:Store ID="Store5" runat="server" AutoLoad="true"  OnRefreshData="MyData5_Refresh">
                                        <Reader>
                                            <ext:JsonReader IDProperty="ID">
                                                <Fields>
                                                    <ext:RecordField Name="ID" Type="Int" />   
                                                    <ext:RecordField Name="ProjectName" Type="String" /> 
                                                    <ext:RecordField Name="PlatformTypeName" Type="String" /> 
                                                    <ext:RecordField Name="NickName" Type="String" />
                                                    <ext:RecordField Name="OrderCode" Type="String" />
                                                    <ext:RecordField Name="WantID" Type="String" />
                                                    <ext:RecordField Name="FullName" Type="String" />
                                                    <ext:RecordField Name="Mobile" Type="String" />
                                                    <ext:RecordField Name="Tel" Type="String" />
                                                    <ext:RecordField Name="DistributePrice" Type="String" />
                                                    <ext:RecordField Name="ReceivablePrice" Type="String" />
                                                    <ext:RecordField Name="PayPrice" Type="String" /> 
                                                    <ext:RecordField Name="DeliveryTime"  Type="Date"/>
                                                    <ext:RecordField Name="PayDate" Type="Date" />
                                                </Fields>
                                            </ext:JsonReader>
                                        </Reader>
                                      
                                       
                                    </ext:Store>
                                    
                                </Store> 
                                <ColumnModel ID="ColumnModel5" runat="server">
                                    <Columns>
                                        <ext:RowNumbererColumn>
                                        </ext:RowNumbererColumn>  
                                        <ext:Column ColumnID="ProjectName" Header="项目名称" Width="80" DataIndex="ProjectName">
                                        </ext:Column> 
                                        <ext:Column ColumnID="PlatformTypeName" Header="平台名称" Width="80" DataIndex="PlatformTypeName">
                                        </ext:Column> 
                                        <ext:Column ColumnID="NickName" Header="店铺名称" Width="100" DataIndex="NickName">
                                        </ext:Column>
                                        <ext:Column ColumnID="OrderCode" Header="订单号" Width="120" DataIndex="OrderCode">
                                        </ext:Column>
                                        <ext:Column ColumnID="WantID" Header="网名" Width="120" DataIndex="WantID">
                                        </ext:Column>
                                        <ext:Column ColumnID="FullName" Header="姓名" Width="100" DataIndex="FullName">
                                        </ext:Column>
                                        <ext:Column ColumnID="Mobile" Header="手机" Width="100" DataIndex="Mobile">
                                        </ext:Column>
                                        <ext:Column ColumnID="Tel" Header="电话" Width="100" DataIndex="Tel">
                                        </ext:Column>
                                        <ext:Column ColumnID="DistributePrice" Header="运费" Width="100" DataIndex="DistributePrice">
                                        </ext:Column>
                                        <ext:Column ColumnID="ReceivablePrice" Header="应收金额" Width="100" DataIndex="ReceivablePrice">
                                        </ext:Column>
                                        <ext:Column ColumnID="PayPrice" Header="已支付金额" Width="100" DataIndex="PayPrice" > 
                                        </ext:Column>
                                        <ext:Column ColumnID="DeliveryTime" Header="发货时间" Width="120" DataIndex="DeliveryTime">
                                        <Renderer Fn="Ext.util.Format.dateRenderer('Y-m-d H:i:s')" />
                                        </ext:Column>
                                        <ext:Column ColumnID="PayDate" Header="付款时间" Width="120" DataIndex="PayDate">
                                        <Renderer Fn="Ext.util.Format.dateRenderer('Y-m-d H:i:s')" />
                                        </ext:Column>
                                    </Columns>
                                </ColumnModel> 
                                <Plugins>
                                <ext:GridFilters runat="server"></ext:GridFilters>
                                </Plugins>
                              <%--  <SelectionModel>
                                    <ext:RowSelectionModel ID="RowSelectionModel5" runat="server" SingleSelect="true" />
                                </SelectionModel>
                                <LoadMask ShowMask="true" Msg="正在加载数据，请稍等..." /> 
                               --%>
                                <BottomBar> 
                                    <ext:PagingToolbar ID="PagingToolbar5" runat="server" PageSize="10" DisplayInfo="true" 
                                     DisplayMsg="显示 {0} - {1}条记录，总共 {2}条记录" EmptyMsg="没有记录" HideRefresh="true" StoreID="Store5">  
                                        <Items>
                                            <ext:Label ID="Label5" runat="server" Text="记录数:" />
                                            <ext:ToolbarSpacer ID="ToolbarSpacer5" runat="server" Width="10"   />
                                            <ext:ComboBox ID="ComboBox5" runat="server" Width="80">
                                                <Items>
                                                    <ext:ListItem Text="10" />
                                                    <ext:ListItem Text="20" />
                                                    <ext:ListItem Text="30" />
                                                    <ext:ListItem Text="40" />
                                                    <ext:ListItem Text="50" />
                                                    <ext:ListItem Text="60" />
                                                    <ext:ListItem Text="70" />
                                                    <ext:ListItem Text="80" />
                                                    <ext:ListItem Text="90" />
                                                    <ext:ListItem Text="100" />
                                                </Items>
                                                  <SelectedItem Value="10" />
                                              <Listeners>
                                           <%--   <Select Handler="#{GridPanel5}.store.pageSize = parseInt(this.getValue(), 10); #{GridPanel5}.store.reload();" />--%>
                                                    <Select Handler="#{PagingToolbar5}.pageSize = parseInt(this.getValue(),10); #{PagingToolbar5}.doLoad();" />
                                                </Listeners>
                                            </ext:ComboBox>
                                        </Items>
                                    </ext:PagingToolbar>
                                </BottomBar> 
                            </ext:GridPanel>
                        </Items>
                    </ext:Panel>

                    <ext:Panel Title="产品明细" Region="Center" Layout="BorderLayout" Icon="CalendarSelectDay" runat="server">
                        <Items>
                            <ext:GridPanel ID="GridPanel1" runat="server" Region="Center" AutoExpandColumn="ProductName"  StripeRows="true" >
                                <Store> 
                                    <ext:Store ID="Store1" runat="server" OnRefreshData="MyData_Refresh" >
                                        <Reader>
                                            <ext:JsonReader IDProperty="DetailsID">
                                                <Fields>
                                                    <ext:RecordField Name="DetailsID" Type="Int" />  
                                                    <ext:RecordField Name="PlatformTypeName" Type="String" />
                                                    <ext:RecordField Name="ProjectName" Type="String" />
                                                    <ext:RecordField Name="NickName" Type="String" />
                                                    <ext:RecordField Name="OrderCode" Type="String" />
                                                    <ext:RecordField Name="DeliveryTime"  Type="Date"/>
                                                    <ext:RecordField Name="PayDate" Type="Date" />
                                                    <ext:RecordField Name="ManufacturersCode" Type="String" />
                                                    <ext:RecordField Name="PlatformMerchantCode" Type="String" />
                                                    <ext:RecordField Name="ProductName" Type="String" />
                                                    <ext:RecordField Name="Specifications" Type="String" />
                                                    <ext:RecordField Name="ProductNum" Type="Int" />
                                                    <ext:RecordField Name="PayPrice" Type="String" /> 
                                                </Fields>
                                            </ext:JsonReader>
                                        </Reader>
                                    </ext:Store>
                                </Store>
                                <ColumnModel ID="ColumnModel1" runat="server">
                                    <Columns>
                                        <ext:RowNumbererColumn>
                                        </ext:RowNumbererColumn>  
                                        <ext:Column ColumnID="PlatformTypeName" Header="平台名称" Width="80" DataIndex="PlatformTypeName">
                                        </ext:Column>
                                        <ext:Column ColumnID="ProjectName" Header="项目名称" Width="80" DataIndex="ProjectName">
                                        </ext:Column>
                                        <ext:Column ColumnID="NickName" Header="店铺名称" Width="100" DataIndex="NickName">
                                        </ext:Column>
                                        <ext:Column ColumnID="DeliveryTime" Header="订单号" Width="120" DataIndex="OrderCode">
                                        </ext:Column>
                                        <ext:Column ColumnID="DeliveryTime" Header="发货时间" Width="120" DataIndex="DeliveryTime">
                                        <Renderer Fn="Ext.util.Format.dateRenderer('Y-m-d H:i:s')" />
                                        </ext:Column>
                                        <ext:Column ColumnID="PayDate" Header="付款时间" Width="120" DataIndex="PayDate">
                                        <Renderer Fn="Ext.util.Format.dateRenderer('Y-m-d H:i:s')" />
                                        </ext:Column>
                                        <ext:Column ColumnID="ManufacturersCode" Header="厂家编码" Width="100" DataIndex="ManufacturersCode">
                                        </ext:Column>
                                        <ext:Column ColumnID="PlatformMerchantCode" Header="商品编码" Width="100" DataIndex="PlatformMerchantCode">
                                        </ext:Column>
                                        <ext:Column ColumnID="ProductName" Header="产品名称" Width="100" DataIndex="ProductName">
                                        </ext:Column>
                                        <ext:Column ColumnID="Specifications" Header="尺寸" Width="100" DataIndex="Specifications">
                                        </ext:Column>
                                        <ext:Column ColumnID="ProductNum" Header="订购数量" Width="100" DataIndex="ProductNum">
                                        </ext:Column>
                                        <ext:Column ColumnID="PayPrice" Header="成交金额" Width="100" DataIndex="PayPrice" >
                                        
                                        </ext:Column>
                                         
                                    </Columns>
                                </ColumnModel> 
                                <SelectionModel>
                                    <ext:RowSelectionModel ID="RowSelectionModel1" runat="server" SingleSelect="true" />
                                </SelectionModel>
                                <LoadMask ShowMask="true" Msg="正在加载数据，请稍等..." />
                                <BottomBar>
                                    <ext:PagingToolbar ID="PagingToolbar1" runat="server" PageSize="10">
                                        <Items>
                                            <ext:Label ID="Label1" runat="server" Text="记录数:" />
                                            <ext:ToolbarSpacer ID="ToolbarSpacer1" runat="server" Width="10" />
                                            <ext:ComboBox ID="ComboBox1" runat="server" Width="80">
                                                <Items>
                                                    <ext:ListItem Text="10" />
                                                    <ext:ListItem Text="20" />
                                                    <ext:ListItem Text="30" />
                                                    <ext:ListItem Text="40" />
                                                    <ext:ListItem Text="50" />
                                                    <ext:ListItem Text="60" />
                                                    <ext:ListItem Text="70" />
                                                    <ext:ListItem Text="80" />
                                                    <ext:ListItem Text="90" />
                                                    <ext:ListItem Text="100" />
                                                </Items>
                                                <SelectedItem Value="10" />
                                                <Listeners>
                                                    <Select Handler="#{PagingToolbar1}.pageSize = parseInt(this.getValue(),10); #{PagingToolbar1}.doLoad();" />
                                                </Listeners>
                                            </ext:ComboBox>
                                        </Items>
                                    </ext:PagingToolbar>
                                </BottomBar>
                            </ext:GridPanel>
                        </Items>
                    </ext:Panel>
                     
                    <ext:Panel Title="产品统计" Region="Center" Layout="BorderLayout" Icon="Note">
                        <Items>
                            <ext:GridPanel ID="GridPanel2" runat="server" Region="Center" AutoExpandColumn="ProductName" StripeRows="true" Footer="true"
                                Border="false">
                                <Store> 
                                    <ext:Store ID="Store2" runat="server" OnRefreshData="MyData2_Refresh"    
                                       SkipIdForNewRecords="false" RefreshAfterSaving="None">
                                        <Reader>
                                            <ext:JsonReader IDProperty="ProductName">
                                                <Fields>
                                                    <ext:RecordField Name="ProductName" Type="String" />  
                                                    <ext:RecordField Name="ProductName" Type="String" /> 
                                                    <ext:RecordField Name="AvgFactoryPrice"  Type="Float"   /> 
                                                    <ext:RecordField Name="ProductNum" Type="Int" /> 
                                                    <ext:RecordField Name="FactoryPrice"  Type="Float" /> 
                                                   
                                                </Fields>
                                            </ext:JsonReader>
                                        </Reader>
                                        
                                    </ext:Store>
                                </Store>
                                <ColumnModel ID="ColumnModel2" runat="server">
                                    <Columns>
                                        <ext:RowNumbererColumn> </ext:RowNumbererColumn>   
                                        <ext:Column ColumnID="ProductName" Header="产品名称" Width="200" DataIndex="ProductName">  </ext:Column>
                                        <ext:Column ColumnID="AvgFactoryPrice" Header="平均单价" Width="200" DataIndex="AvgFactoryPrice" >
                                         </ext:Column> 
                                        <ext:Column ColumnID="ProductNum" Header="订购数量" Width="200" DataIndex="ProductNum"> </ext:Column>
                                        <ext:Column ColumnID="FactoryPrice" Header="出厂总价" Width="200" DataIndex="FactoryPrice"> </ext:Column>  
                                    </Columns>
                                </ColumnModel>

                                
                                <Plugins>
                                <ext:PanelResizer></ext:PanelResizer>

                                </Plugins>
                                 
                             <SelectionModel>
                                    <ext:RowSelectionModel ID="RowSelectionModel2" runat="server" SingleSelect="true" />
                                </SelectionModel>
                                <LoadMask ShowMask="true" Msg="正在加载数据，请稍等..." />
                                <BottomBar>
                                    <ext:PagingToolbar ID="PagingToolbar2" runat="server" PageSize="10">
                                        <Items>
                                            <ext:Label ID="Label2" runat="server" Text="记录数:" />
                                            <ext:ToolbarSpacer ID="ToolbarSpacer2" runat="server" Width="10" />
                                            <ext:ComboBox ID="ComboBox2" runat="server" Width="80">
                                                <Items>
                                                    <ext:ListItem Text="10" />
                                                    <ext:ListItem Text="20" />
                                                    <ext:ListItem Text="30" />
                                                    <ext:ListItem Text="40" />
                                                    <ext:ListItem Text="50" />
                                                    <ext:ListItem Text="60" />
                                                    <ext:ListItem Text="70" />
                                                    <ext:ListItem Text="80" />
                                                    <ext:ListItem Text="90" />
                                                    <ext:ListItem Text="100" />
                                                </Items>
                                                <SelectedItem Value="10" />
                                                <Listeners>
                                                    <Select Handler="#{PagingToolbar2}.pageSize = parseInt(this.getValue(),10); #{PagingToolbar2}.doLoad();" />
                                                </Listeners>
                                            </ext:ComboBox>
                                        </Items>
                                    </ext:PagingToolbar>
                                </BottomBar>
                            </ext:GridPanel>
                        </Items>
                    </ext:Panel>
                     
                    <ext:Panel Title="返现明细" Region="Center" Layout="BorderLayout" Icon="ApplicationViewGallery">
                        <Items>
                            <ext:GridPanel ID="GridPanel3" runat="server" Region="Center"  StripeRows="true" Footer="true"
                                Border="false">
                                <Store> 
                                    <ext:Store ID="Store3" runat="server" OnRefreshData="MyData3_Refresh"    
                                       SkipIdForNewRecords="false" RefreshAfterSaving="None">
                                        <Reader>
                                            <ext:JsonReader IDProperty="Id">
                                                <Fields>
                                                    <ext:RecordField Name="Id" Type="String" />  
                                                    <ext:RecordField Name="OrderCode" Type="String" /> 
                                                    <ext:RecordField Name="WantNo"  Type="String"   /> 
                                                    <ext:RecordField Name="BuyerName" Type="String" /> 
                                                    <ext:RecordField Name="BuyerAlipayNo" Type="String" />
                                                    <ext:RecordField Name="CashBackMoney"  Type="Float" /> 
                                                   
                                                </Fields>
                                            </ext:JsonReader>
                                        </Reader>
                                        
                                    </ext:Store>
                                </Store>
                                <ColumnModel ID="ColumnModel3" runat="server">
                                    <Columns>
                                        <ext:RowNumbererColumn> </ext:RowNumbererColumn>   
                                        <ext:Column ColumnID="OrderCode" Header="订单号" Width="200" DataIndex="OrderCode">  </ext:Column>
                                        <ext:Column ColumnID="WantNo" Header="旺旺号" Width="200" DataIndex="WantNo" > </ext:Column> 
                                        <ext:Column ColumnID="BuyerName" Header="姓名" Width="200" DataIndex="BuyerName"> </ext:Column>
                                        <ext:Column ColumnID="BuyerAlipayNo" Header="收款账号" Width="200" DataIndex="BuyerAlipayNo"> </ext:Column>
                                        <ext:Column ColumnID="CashBackMoney" Header="返现金额" Width="200" DataIndex="CashBackMoney"> </ext:Column>  
                                    </Columns>
                                </ColumnModel>

                                
                                <Plugins>
                                <ext:PanelResizer></ext:PanelResizer>

                                </Plugins>
                                 
                             <SelectionModel>
                                    <ext:RowSelectionModel ID="RowSelectionModel3" runat="server" SingleSelect="true" />
                                </SelectionModel>
                                <LoadMask ShowMask="true" Msg="正在加载数据，请稍等..." />
                                <BottomBar>
                                    <ext:PagingToolbar ID="PagingToolbar3" runat="server" PageSize="10">
                                        <Items>
                                            <ext:Label ID="Label3" runat="server" Text="记录数:" />
                                            <ext:ToolbarSpacer ID="ToolbarSpacer3" runat="server" Width="10" />
                                            <ext:ComboBox ID="ComboBox3" runat="server" Width="80">
                                                <Items>
                                                    <ext:ListItem Text="10" />
                                                    <ext:ListItem Text="20" />
                                                    <ext:ListItem Text="30" />
                                                    <ext:ListItem Text="40" />
                                                    <ext:ListItem Text="50" />
                                                    <ext:ListItem Text="60" />
                                                    <ext:ListItem Text="70" />
                                                    <ext:ListItem Text="80" />
                                                    <ext:ListItem Text="90" />
                                                    <ext:ListItem Text="100" />
                                                </Items>
                                                <SelectedItem Value="10" />
                                                <Listeners>
                                                    <Select Handler="#{PagingToolbar3}.pageSize = parseInt(this.getValue(),10); #{PagingToolbar3}.doLoad();" />
                                                </Listeners>
                                            </ext:ComboBox>
                                        </Items>
                                    </ext:PagingToolbar>
                                </BottomBar>
                            </ext:GridPanel>
                        </Items>
                    </ext:Panel>

                    <ext:Panel Title="刷单明细" Region="Center" Layout="BorderLayout" Icon="ApplicationViewDetail" runat="server">
                        <Items>
                            <ext:GridPanel ID="GridPanel4" runat="server" Region="Center" AutoExpandColumn="ProductName" StripeRows="true" Footer="true"
                                Border="false">
                                <Store> 
                                    <ext:Store ID="Store4" runat="server" OnRefreshData="MyData4_Refresh"    
                                       SkipIdForNewRecords="false" RefreshAfterSaving="None">
                                        <Reader>
                                            <ext:JsonReader IDProperty="ID">
                                                <Fields>
                                                    <ext:RecordField Name="ID" Type="Int" />  
                                                    <ext:RecordField Name="OrderCode" Type="String" /> 
                                                    <ext:RecordField Name="WantID"  Type="String"   /> 
                                                    <ext:RecordField Name="ProductName" Type="String" /> 
                                                    <ext:RecordField Name="SalePrice"  Type="Float" /> 
                                                    <ext:RecordField Name="Fee"  Type="Float" /> 
                                                    <ext:RecordField Name="Deduction"  Type="Float" /> 
                                                   
                                                </Fields>
                                            </ext:JsonReader>
                                        </Reader>
                                        
                                    </ext:Store>
                                </Store>
                                <ColumnModel ID="ColumnModel4" runat="server">
                                    <Columns>
                                        <ext:RowNumbererColumn> </ext:RowNumbererColumn>   
                                        <ext:Column ColumnID="OrderCode" Header="订单号" Width="200" DataIndex="OrderCode">  </ext:Column>
                                        <ext:Column ColumnID="WantID" Header="旺旺号" Width="200" DataIndex="WantID" > </ext:Column> 
                                        <ext:Column ColumnID="ProductName" Header="商品名称" Width="200" DataIndex="ProductName"> </ext:Column>
                                        <ext:Column ColumnID="SalePrice" Header="销售价" Width="200" DataIndex="SalePrice"> </ext:Column>  
                                        <ext:Column ColumnID="Fee" Header="佣金" Width="200" DataIndex="Fee"> </ext:Column>  
                                        <ext:Column ColumnID="Deduction" Header="扣点" Width="200" DataIndex="Deduction"> </ext:Column>  
                                    </Columns>
                                </ColumnModel>

                                
                                <Plugins>
                                <ext:PanelResizer></ext:PanelResizer>

                                </Plugins>
                                 
                             <SelectionModel>
                                    <ext:RowSelectionModel ID="RowSelectionModel4" runat="server" SingleSelect="true" />
                                </SelectionModel>
                                <LoadMask ShowMask="true" Msg="正在加载数据，请稍等..." />
                                <BottomBar>
                                    <ext:PagingToolbar ID="PagingToolbar4" runat="server" PageSize="10">
                                        <Items>
                                            <ext:Label ID="Label4" runat="server" Text="记录数:" />
                                            <ext:ToolbarSpacer ID="ToolbarSpacer4" runat="server" Width="10" />
                                            <ext:ComboBox ID="ComboBox4" runat="server" Width="80">
                                                <Items>
                                                    <ext:ListItem Text="10" />
                                                    <ext:ListItem Text="20" />
                                                    <ext:ListItem Text="30" />
                                                    <ext:ListItem Text="40" />
                                                    <ext:ListItem Text="50" />
                                                    <ext:ListItem Text="60" />
                                                    <ext:ListItem Text="70" />
                                                    <ext:ListItem Text="80" />
                                                    <ext:ListItem Text="90" />
                                                    <ext:ListItem Text="100" />
                                                </Items>
                                                <SelectedItem Value="10" />
                                                <Listeners>
                                                    <Select Handler="#{PagingToolbar4}.pageSize = parseInt(this.getValue(),10); #{PagingToolbar4}.doLoad();" />
                                                </Listeners>
                                            </ext:ComboBox>
                                        </Items>
                                    </ext:PagingToolbar>
                                </BottomBar>
                            </ext:GridPanel>
                        </Items>
                    </ext:Panel>


                   <%--  <ext:Panel Title="退款明细" Region="Center" Layout="BorderLayout" Icon="Application">
                        <Items>  
                        </Items>
                    </ext:Panel>--%>
                    
                </Items>
            </ext:TabPanel>
        </Items>
         
    </ext:Viewport> 
    
    </form>
</body>
</html>
