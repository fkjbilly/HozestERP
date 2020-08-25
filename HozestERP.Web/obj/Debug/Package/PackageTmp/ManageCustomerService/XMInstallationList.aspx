<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Root.Master" AutoEventWireup="true" CodeBehind="XMInstallationList.aspx.cs" Inherits="HozestERP.Web.ManageCustomerService.XMInstallationList" %>
<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<%@ MasterType VirtualPath="~/MasterPages/Root.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .cbStates-list 
        {
            width: 298px;
            font: 11px tahoma,arial,helvetica,sans-serif;
        }
        
        .cbStates-list th {
            font-weight: bold;
        }
        
        .cbStates-list td, .cbStates-list th {
            padding: 3px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder4" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <script src="../My97DatePicker/WdatePicker.js" type="text/javascript"></script>
    <script src="../Script/jquery1.9.1/jquery-1.9.1.js" type="text/javascript"></script>
    <script src="../Script/jquery1.9.1/ui/jquery-ui.js" type="text/javascript"></script>
    <link href="../Script/jquery1.9.1/themes/base/jquery-ui.css" rel="stylesheet" type="text/css" />
    <link href="../Script/jquery1.9.1/themes/base/jquery.ui.theme.css" rel="stylesheet"
        type="text/css" />
 <script type="text/javascript">
     $(document).ready(function () {
         $(document).on("keyup", "#<%=tfOrderCode.ClientID %>", function () {
             select();
         });
     });

     function getInsID(id) {
         ShowWindowDetail('预约安装详细', './ManageCustomerService/XMInstallationListDetails.aspx?Id='+id, 400, 270);
     }
    </script>
        <ext:ResourceManager ID="ResourceManager1" runat="server" DirectMethodNamespace="X"/>    
        <ext:Viewport ID="Viewport1" runat="server" Layout="border">
            <Items>
             <ext:Panel ID="Panel1"
                    runat="server"
                    Region="North"
                    Title="查询"
                    Height="70"
                    Padding="5"
                    Frame="true"
                    Layout="ColumnLayout"
                    Icon="Information">
                    <Items>
                    <ext:TextField ID="txtWantID" runat="server" FieldLabel="买家ID" MaxLength="20"  ColumnWidth="0.11" LabelWidth="40"/>
                    <ext:TextField ID="txtOrderCode" runat="server" FieldLabel="订单编号" MaxLength="20" LabelAlign="Right" ColumnWidth="0.14"  LabelWidth="60"/>
                    <ext:ComboBox runat="server" ID="ddXMProject2" FieldLabel="项目" DisplayField="ProjectName" ValueField="Id" ColumnWidth="0.1" LabelWidth="30" Editable="false">
                            <Listeners>
                                <Select Handler="#{ddlNick}.clearValue(); #{Store3}.reload();"  />
                            </Listeners>
                            <Store>
                            <ext:Store runat="server" ID="Store2" AutoDataBind="false">
                                <Reader>
                                    <ext:JsonReader>
                                        <Fields>
                                            <ext:RecordField Name="ProjectName"></ext:RecordField>
                                            <ext:RecordField Name="Id"></ext:RecordField>
                                        </Fields>
                                    </ext:JsonReader>
                                </Reader>
                            </ext:Store>
                            </Store>     
                        </ext:ComboBox>
                        <ext:ComboBox runat="server" ID="ddlNick2" FieldLabel="店铺" DisplayField="nick" ValueField="nick_id" ColumnWidth="0.12" LabelWidth="30" Editable="false">
                        <Store>
                        <ext:Store runat="server" ID="Store3" AutoDataBind="false" OnRefreshData="ddXMProject2_SelectedIndexChanged">
                            <Reader>
                                <ext:JsonReader>
                                    <Fields>
                                    <ext:RecordField Name="nick"></ext:RecordField>
                                    <ext:RecordField Name="nick_id"></ext:RecordField>
                                    </Fields>
                                </ext:JsonReader>
                            </Reader>
                        </ext:Store>
                        </Store>
                        </ext:ComboBox>
                    
                    <ext:TextField ID="txtCustomerName" runat="server" FieldLabel="客户姓名" MaxLength="20" LabelAlign="Right" ColumnWidth="0.12"  LabelWidth="60"/>
                    <ext:TextField ID="txtCustomerTel" runat="server" FieldLabel="客户电话" MaxLength="20" LabelAlign="Right" ColumnWidth="0.12"  LabelWidth="60"/>
                    <ext:ComboBox ID="cmIsArrange" runat="server" FieldLabel="是否安排" LabelAlign="Right"  SelectedIndex="0" ColumnWidth="0.12"  LabelWidth="60">
                    <Items>
                    <ext:ListItem Text="所有" Value="-1" />
                    <ext:ListItem Text="是" Value="1" />
                    <ext:ListItem Text="否" Value="0" />
                    </Items>
                    </ext:ComboBox>
                     <ext:ComboBox ID="cmIsInstall" runat="server" FieldLabel="是否安装" LabelAlign="Right" SelectedIndex="0" ColumnWidth="0.12"  LabelWidth="60">
                    <Items>
                    <ext:ListItem Text="所有" Value="-1" />
                    <ext:ListItem Text="是" Value="1" />
                    <ext:ListItem Text="否" Value="0" />
                    </Items>
                    </ext:ComboBox>
                        <ext:Label runat="server" Text="开始时间："></ext:Label>
                        <ext:DateField ID="dfStart" runat="server" Width="75"/>
                        <ext:Label runat="server" Text="结束时间：" ></ext:Label>
                        <ext:DateField ID="dfEnd" runat="server" Width="75"/>
                    <ext:Button ID="Button1" runat="server" Text="查询" Width="50" ColumnWidth="0.02" LabelWidth="50">
                                        <DirectEvents>
                                        <Click OnEvent="btnSearch_Click">
                                         <EventMask ShowMask="true" Msg="正在加载数据，请稍后... ..." />
                                        </Click>
                                        </DirectEvents>
                                        </ext:Button>
                        <ext:Button runat="server" Text="导出" Width="50">
                            <DirectEvents>
                                <Click OnEvent="Export_Click"  IsUpload="true">

                                </Click>
                            </DirectEvents>
                        </ext:Button>
                    </Items>
                </ext:Panel>
                <ext:GridPanel ID="GridPanel1" 
                    runat="server" 
                    Title="安装单列表"
                    Margins="0 0 5 5"
                    Icon="UserSuit"
                    Region="Center"
                    AutoExpandColumn="OrderCode"
                    Frame="true">
                    <Store>
                        <ext:Store 
                            ID="Store1" 
                            runat="server" 
                            OnRefreshData="Store1_Refresh">
                            <Reader>
                                <ext:JsonReader IDProperty="ID">
                                    <Fields>
                                        <ext:RecordField Name="ID" />
                                        <ext:RecordField Name="ProjectName" />
                                        <ext:RecordField Name="NickName" />
                                        <ext:RecordField Name="WantID" />
                                        <ext:RecordField Name="OrderCode" />
                                        <ext:RecordField Name="PayDate" />
                                        <ext:RecordField Name="CustomerName" />
                                        <ext:RecordField Name="CustomerTel" />
                                        <ext:RecordField Name="FullName" />
                                        <ext:RecordField Name="WorkerTel" />
                                        <ext:RecordField Name="IsArrange" />
                                        <ext:RecordField Name="IsInstall" />
                                    </Fields>
                                </ext:JsonReader>
                            </Reader>
                        </ext:Store>
                    </Store>
                    <ColumnModel ID="ColumnModel1" runat="server">
                        <Columns>
                            <ext:Column DataIndex="WantID" Header="买家ID" Width="80" />
                            <ext:Column  DataIndex="OrderCode" Header="订单编号"  Width="150" />
                            <ext:Column DataIndex="ProjectName" Header="项目" Width="80" />
                            <ext:Column DataIndex="NickName" Header="店铺" Width="80" />
                            <ext:Column  DataIndex="PayDate" Header="下单时间"  Width="150" />
                            <ext:Column  DataIndex="CustomerName" Header="客户姓名"  Width="80" />
                            <ext:Column  DataIndex="CustomerTel" Header="客户电话"  Width="80" />
                            <ext:Column  DataIndex="FullName" Header="师傅姓名"  Width="80" />
                            <ext:Column  DataIndex="WorkerTel" Header="师傅电话"  Width="80" />
                            <ext:CheckColumn DataIndex="IsArrange" Header="是否安排"  Width="70"/>
                            <ext:CheckColumn DataIndex="IsInstall" Header="是否安装" Width="70"/>
                            <ext:CommandColumn runat="server" Header="预约详细"  Width="70" >
                            <Commands>
                                <ext:GridCommand Icon="NoteEdit" CommandName="Edit">
                                    <ToolTip Text="预约详细" />
                                </ext:GridCommand>
                            </Commands>

                    </ext:CommandColumn>
                       </Columns>
                       </ColumnModel>                        
                        <Listeners>
                            <Command Handler="getInsID(record.data['ID']);" />
                        </Listeners>
                    <SelectionModel>
                        <ext:RowSelectionModel ID="RowSelectionModel1" runat="server" SingleSelect="true">
                            <DirectEvents>
                                <RowSelect OnEvent="RowSelect" Buffer="100">
                                    <EventMask ShowMask="true" Target="CustomTarget" CustomTarget="#{FormPanel1}" />
                                    <ExtraParams>
                                        <%-- or can use params[2].id as value --%>
                                        <ext:Parameter Name="ID" Value="this.getSelected().id" Mode="Raw" />
                                    </ExtraParams>
                                </RowSelect>
                            </DirectEvents>
                        </ext:RowSelectionModel>
                    </SelectionModel>
                   <BottomBar>
                 <ext:PagingToolbar ID="PagingToolbar1" runat="server" PageSize="10">
                    <Items>
                        <ext:Label ID="Label1" runat="server" Text="显示行数:" />
                        <ext:ToolbarSpacer ID="ToolbarSpacer1" runat="server" Width="10" />
                        <ext:ComboBox ID="ComboBox1" runat="server" Width="80">
                            <Items>
                                <ext:ListItem Text="10" />
                                <ext:ListItem Text="20" />
                                <ext:ListItem Text="50" />
                                <ext:ListItem Text="100" />
                            </Items>
                            <SelectedItem Value="10"/>
                            <Listeners>
                                <Select Handler="#{PagingToolbar1}.pageSize = parseInt(this.getValue()); #{PagingToolbar1}.doLoad();" />
                            </Listeners>
                        </ext:ComboBox>
                    </Items>
                    <Plugins>
                        <ext:ProgressBarPager ID="ProgressBarPager1" runat="server" />
                    </Plugins>
                </ext:PagingToolbar>
            </BottomBar>
                    <LoadMask ShowMask="true" />
                </ext:GridPanel>
                <ext:FormPanel 
                    ID="FormPanel1" 
                    runat="server" 
                    Region="East"
                    Split="true"
                    Margins="0 5 5 5"
                    Frame="true" 
                    Title="安装单明细" 
                    Width="350"
                    Icon="User"
                    DefaultAnchor="100%">
                    <Items>
                        <ext:TextField ID="HiddenID" runat="server" FieldLabel="ID" DataIndex="ID" Hidden="true"/>
                        <ext:TextField ID="tfOrderCode" runat="server" FieldLabel="订单编号" DataIndex="OrderCode" MaxLength="20"/>
                        
                        <ext:ComboBox runat="server" ID="ddXMProject" FieldLabel="项目" DisplayField="ProjectName" ValueField="Id" Width="200" Editable="false">
                            <Listeners>
                                <Select Handler="#{ddlNick}.clearValue(); #{CB2Store}.reload();"  />
                            </Listeners>
                            <Store>
                            <ext:Store runat="server" ID="CB1Store" AutoDataBind="false">
                                <Reader>
                                    <ext:JsonReader>
                                        <Fields>
                                            <ext:RecordField Name="ProjectName"></ext:RecordField>
                                            <ext:RecordField Name="Id"></ext:RecordField>
                                        </Fields>
                                    </ext:JsonReader>
                                </Reader>
                            </ext:Store>
                            </Store>     
                        </ext:ComboBox>
                        <ext:ComboBox runat="server" ID="ddlNick" FieldLabel="店铺" DisplayField="nick" ValueField="nick_id" Width="200" Editable="false">
                        <Store>
                        <ext:Store runat="server" ID="CB2Store" AutoDataBind="false" OnRefreshData="ddXMProject_SelectedIndexChanged">
                            <Reader>
                                <ext:JsonReader>
                                    <Fields>
                                    <ext:RecordField Name="nick"></ext:RecordField>
                                    <ext:RecordField Name="nick_id"></ext:RecordField>
                                    </Fields>
                                </ext:JsonReader>
                            </Reader>
                        </ext:Store>
                        </Store>
                        </ext:ComboBox>
                        <ext:TextField ID="tfWantID" runat="server" FieldLabel="买家ID  " DataIndex="WantID" MaxLength="15"/>
                        <ext:TextField ID="tfCustomerName" runat="server" FieldLabel="客户姓名" DataIndex="CustomerName" MaxLength="8"/>
                        <ext:TextField ID="tfCustomerTel" runat="server" FieldLabel="客户电话" DataIndex="CustomerTel" MaxLength="20"/>
                        <ext:TextArea ID="taInstallAddress" runat="server" FieldLabel="安装地址" DataIndex="InstallAddress" MaxLength="100"/>
                        <ext:Checkbox ID="chkIsArrange" runat="server" FieldLabel="是否安排安装" DataIndex="IsArrange"/>
                        <ext:DateField ID="dfArrangeDate" runat="server" FieldLabel="安排时间" Format="yyyy-MM-dd" DataIndex="ArrangeDate" />
                        <ext:ComboBox ID="slbInstallType" runat="server" FieldLabel="安装类型" EmptyText="请选择...">
                            <Items>
                                <ext:ListItem Text="螺丝钉/渠道" Value="0" />
                                <ext:ListItem Text="渠道" Value="1" />
                                <ext:ListItem Text="螺丝钉" Value="2" />
                            </Items>
                        </ext:ComboBox>
<%--                        <ext:TextField ID="tfContactInfo" runat="server" FieldLabel="师傅联系方式" DataIndex="ContactInfo" MaxLength="50"/>--%>
                        <ext:ComboBox runat="server" ID="cbPerson" ValueField="ID" DisplayField="FullName" FieldLabel="师傅联系方式" TypeAhead="false"  MinChars="1" PageSize="10" ItemSelector="tr.list-item" ListWidth="300">
                            <Store>
                                <ext:Store runat="server" ID="StorePerson">
                                    <Proxy>
                                        <ext:HttpProxy Method="POST" Url="CbWorkerInfo.ashx" />
                                    </Proxy>
                                    <Reader>
                                        <ext:JsonReader Root="plants" TotalProperty="total">
                                            <Fields>
                                                <ext:RecordField Name="ID" />
                                                <ext:RecordField Name="FullName"/>
                                                <ext:RecordField Name="Tel" />
                                                <ext:RecordField Name="Province" />
                                                <ext:RecordField Name="City" />
                                                <ext:RecordField Name="Regin" />
                                            </Fields>
                                        </ext:JsonReader>
                                    </Reader>
                                    <AutoLoadParams>
                                        <ext:Parameter Name="start" Value="0" Mode="Raw" />
                                        <ext:Parameter Name="limit" Value="10" Mode="Raw" />
                                    </AutoLoadParams>
                                </ext:Store>
                            </Store>
                            <Template runat="server">
                                   <Html>
					                    <tpl for=".">
						                    <tpl if="[xindex] == 1">
							                    <table class="cbStates-list">
								                    <tr>
									                        <th>姓名</th>
									                        <th>联系方式</th>
                                                            <th>省</th>
                                                            <th>市</th>
                                                            <th>区</th>
								                    </tr>
						                </tpl>
						                            <tr class="list-item">
							                                <td style="padding:3px 0px;">{FullName}</td>
							                                <td>{Tel}</td>
                                                            <td>{Province}</td>
                                                            <td>{City}</td>
                                                            <td>{Regin}</td>
						                            </tr>
						                <tpl if="[xcount-xindex]==0">
							                    </table>
						                </tpl>
					                </tpl>
				                </Html>
                            </Template>
                        </ext:ComboBox>
                        <ext:Checkbox ID="chkIsInstall" runat="server" FieldLabel="是否安装完毕" DataIndex="IsInstall" />
                        <ext:TextField ID="tfInstallationFee" runat="server" FieldLabel="安装费用" DataIndex="InstallationFee" MaxLength="8"/>
                        <ext:DateField ID="dfPaymentDate" runat="server" FieldLabel="付款时间" Format="yyyy-MM-dd" DataIndex="PaymentDate" />
                        <ext:TextArea ID="taRemarks" runat="server" FieldLabel="备    注" DataIndex="Remarks" MaxLength="150"/>
                    </Items>
                    <Buttons>
                       <ext:Button ID="clear" runat="server" Text="清空">
                        <DirectEvents>
                              <Click OnEvent="Clear_Click"/>
                        </DirectEvents>
                    </ext:Button>
                       <ext:Button ID="Delete" runat="server" Text="删除">
                        <DirectEvents>
                              <Click OnEvent="Delete_Click"/>
                        </DirectEvents>
                    </ext:Button>
                       <ext:Button ID="Add" runat="server" Text="新增">
                        <DirectEvents>
                              <Click OnEvent="Add_Click">
                                  <EventMask ShowMask="true" Msg="正在新增数据，请稍后... ..." />
                              </Click>
                        </DirectEvents>
                    </ext:Button>
                    <ext:Button ID="save" runat="server" Text="修改">
                        <DirectEvents>
                              <Click OnEvent="Save_Click">
                                  <EventMask ShowMask="true" Msg="正在修改数据，请稍后... ..." />
                              </Click>
                        </DirectEvents>
                    </ext:Button>
                    </Buttons>
                </ext:FormPanel>
            </Items>
        </ext:Viewport>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="Contentplaceholder3" runat="server">

<script language="javascript" type="text/javascript">
    function select() {
        var str = $("#<%=tfOrderCode.ClientID %>");
         str.autocomplete(
            {
                source: function(request, response) {
                    $.ajax({
                        url: "XMInstallationAlert.ashx",
                        data: "p=" + str[0].value,
                        dataType: "json",
                        type: "GET",
                        success: function(data) {
                            response($.map(data, function(item) {
                            return {
                                        label: " 订单号：" + item.OrderCode + " 店铺：" + item.NickName,
                                        value: item.OrderCode,
                                        order: item };
                            }));
                        }
                    });
                }, 
                 select: function (e, i, j) {
                     $("#<%= tfOrderCode.ClientID%>").val(i.item.order.OrderCode);
                     $("#<%= tfWantID.ClientID%>").val(i.item.order.WantID);
                     $("#<%= ddXMProject.ClientID%>").val(i.item.order.ProjectName);
                     $("#<%= ddlNick.ClientID%>").val(i.item.order.NickName);
                     $("#<%= tfCustomerName.ClientID%>").val(i.item.order.FullName);
                     $("#<%= tfCustomerTel.ClientID%>").val(i.item.order.Mobile);
                     $("#<%= taInstallAddress.ClientID%>").val(i.item.order.DeliveryAddress);
                },
            });
     }
</script>
</asp:Content>
