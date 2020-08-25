<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Root.Master" AutoEventWireup="true" CodeBehind="XMBills.aspx.cs" Inherits="HozestERP.Web.ManageFinance.XMBills" %>
<%@ MasterType VirtualPath="~/MasterPages/Root.Master" %>
<%@ Register Src="~/Modules/CodeControl.ascx" TagName="CodeControl" TagPrefix="CRM" %>
<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../My97DatePicker/WdatePicker.js" type="text/javascript"></script>
    <script src="../Script/CommonManager.js" type="text/javascript"></script>
    <style type="text/css">
        .headbackground
        {
            border-top-color: transparent;
            border-bottom-color: transparent;
            border-left-color: transparent;
            border-right-color: transparent;
        }
        
        .gridlist
        {
            background: none repeat 0% 0% #FFF;
            color: #444444;
            border-collapse: collapse;
            border: 1px solid #D5DFE3;
            margin: 0px;
            height: auto;
            border: 0px;
        }
      .select2-container--default .select2-selection--single .select2-selection__rendered {
            color: #444;
            line-height: 21px !important;
        }
        .select2-container .select2-selection--single {
            box-sizing: border-box;
            cursor: pointer;
            display: block;
            height: 25px !important;
            user-select: none;
            -webkit-user-select: none;
        }
    </style>
    <link href="../Script/select2-develop/dist/css/select2.css"  rel="stylesheet" type="text/css" />
    <script src="../Script/select2-develop/dist/js/select2.full.js" type="text/javascript"></script>
    <script src="../Script/bootstrap-3.3.7/js/bootstrap.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder4" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table border="0" cellpadding="2" cellspacing="2" style="width: 100%">
        <tr>
            <td style="width: 80px;">
                供应商:
            </td>
            <td style="width: 200px;">
                <asp:TextBox ID="ddSuppliers" name="ddSuppliers" runat="server" Width="90%"></asp:TextBox>
                 <!--<input type="text"  id="ddSuppliers" name="ddSuppliers" />-->
            </td>
            <td style="width: 80px;">
                账单状态
            </td>
            <td style="width: 150px;">
                 <asp:DropDownList ID="ddVerification" runat="server" Width="90%">
                </asp:DropDownList>
            </td>
            <td style="width: 80px;">
                发货单号
            </td>
            <td style="width: 150px;">
                 <asp:TextBox ID="txtDeliveryId" runat="server" Width="90%"></asp:TextBox>
            </td>
           
          
        </tr>
         <tr>
            <td style="height: 5px;">
            </td>
        </tr>
        <tr> 
            <td style="width: 80px">导入时间
            </td>
            <td style="width: 230px">
                <input id="txtCreateDateBegin" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss'})"
                    class="Wdate" runat="server" style="width: 45%;" />到
                    <input id="txtCreateDateEnd" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss'})"
                    class="Wdate" runat="server" style="width: 45%;" />
            </td>

           <td style="width: 80px;">
                商品编码
            </td>
            <td style="width: 150px;">
                 <asp:TextBox ID="txtPlatformMerchantCode" runat="server" Width="90%"></asp:TextBox>
            </td>
          
            
              <td style="text-align: right">
                <asp:Button ID="btnSearch" runat="server" Text="查询" OnClick="btnSearch_Click" /><asp:Button ID="btnRefresh" runat="server" Text="刷新" OnClick="btnRefresh_Click" />

            </td>
        </tr>
    </table>
    <script type="text/javascript">
        jQuery(function ($) {
            $.ajax({
                url: "XMBillsSelect2.ashx",
                type: "GET",
                dataType: "json",
                async: false,
                contentType: "application/json; charset=utf-8",
                success: function (json) {
                    select2data = [];
                    var allOption = new Object();
                    allOption.text = "---全部---";
                    allOption.id = -1;
                    select2data.push(allOption);
                    json.forEach(function (ele) {
                        select2data.push(ele);
                    });
                  
                    $("#ctl00_ContentPlaceHolder1_ddSuppliers").select2({
                        data: select2data
                    });
                },
                error: function (x, e) {
                },
                complete: function (x) {
                }
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <asp:GridView ID="grdvClients" runat="server" AutoGenerateColumns="False" DataKeyNames="BillID"
        SkinID="GridViewThemen" OnRowCommand="grdvClients_RowCommand"
        ShowFooter="true">
        <EmptyDataTemplate>
            <table cellpadding="0" cellspacing="0" width="100%">
                <tr class="GridHeader" style="height: 22px; font-weight: bold;">
                    <th align="center" class="GridHeard" style="white-space: nowrap;" scope="col">
                        &nbsp;
                    </th>
                    <th align="center" class="GridHeard" scope="col" style="white-space: nowrap;">
                        <input id="chkAll" onclick="SelectAll(this, 99)" type="checkbox" value="on" />
                    </th>
                    <th align="center" class="GridHeard" style="white-space: nowrap;" scope="col">
                        发货单号
                    </th>
                      <th align="center" class="GridHeard" style="white-space: nowrap;" scope="col">
                        商品编码
                    </th>
                    <th align="center" class="GridHeard" style="white-space: nowrap;" scope="col">
                        供应商  
                    </th>
                    <th align="center" class="GridHeard" style="white-space: nowrap;" scope="col">
                        数量
                    </th>
                    <th align="center" class="GridHeard" style="white-space: nowrap;" scope="col">
                        价格
                    </th>
                    <th align="center" class="GridHeard" style="white-space: nowrap;" scope="col">
                        核销状态
                    </th>
                    <th align="center" class="GridHeard" style="white-space: nowrap;" scope="col">
                        异常信息
                    </th>
                     <th align="center" class="GridHeard" style="white-space: nowrap;" scope="col">
                        导入日期
                    </th>
                    <th align="center" class="GridHeard" style="white-space: nowrap;" scope="col">
                        操作
                    </th>
                </tr>
            </table>
        </EmptyDataTemplate>
        <Columns>
            <asp:TemplateField HeaderText="">
                <ItemTemplate>
                    <%# Container.DataItemIndex + 1 %>
                </ItemTemplate>
                <HeaderStyle Wrap="False" Width="20px" HorizontalAlign="Center"></HeaderStyle>
            </asp:TemplateField>
            <asp:TemplateField>
                <HeaderTemplate>
                    <input id="chkAll" onclick="SelectAll(this, 99)" type="checkbox" runat="server" />
                    <asp:HiddenField ID="hdBillID" Value='<%#Eval("BillID")%>' runat="server" />
                </HeaderTemplate>
                <ItemStyle Width="20px" HorizontalAlign="Center"></ItemStyle>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                <ItemTemplate>
                    <asp:CheckBox ID="chkSelected" TabIndex="99" runat="server" type="checkbox"></asp:CheckBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="发货单号" SortExpression="DeliveryNumber">
                <HeaderStyle Width="60px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("DeliveryNumber")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="商品编码" SortExpression="PlatformMerchantCode">
                <HeaderStyle Width="120px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%#Eval("PlatformMerchantCode")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="供应商" SortExpression="SuppliersID">
                <HeaderStyle Width="120px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                     <%# base.XMBillsservice.ReturnSuppliersName(int.Parse(Eval("SuppliersID").ToString()))%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="数量" SortExpression="ProductNum">
                <HeaderStyle Width="65px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("ProductNum")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="价格" SortExpression="Price">
                <HeaderStyle Width="65px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("Price")%>
                </ItemTemplate>
            </asp:TemplateField>
               <asp:TemplateField HeaderText="核销状态" SortExpression="VerificationStatus">
                <HeaderStyle Width="65px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# base.XMBillsservice.ReturnStatusText(Eval("VerificationStatus").ToString())%>
                </ItemTemplate>
            </asp:TemplateField>
               <asp:TemplateField HeaderText="异常信息" SortExpression="ExMessage">
                <HeaderStyle Width="65px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("ExMessage")%>
                </ItemTemplate>
            </asp:TemplateField>
             <asp:TemplateField HeaderText="导入日期" SortExpression="CreateDate">
                <HeaderStyle Width="65px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                     <asp:Label ID="lblDateTime" runat="server" Text='<%# Eval("CreateDate")==null?"":DateTime.Parse(Eval("CreateDate").ToString()).ToString("yyyy-MM-dd HH:mm:ss")%>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="操作">
                <HeaderStyle HorizontalAlign="Center" Width="60px" Wrap="False" />
                <ItemTemplate>
                   <!-- <asp:ImageButton ID="imgBtnEdit" runat="server" ImageUrl="~/App_Themes/Default/Image/update.gif"
                        ToolTip="编辑" CommandName="Edit" CausesValidation="False" Visible="<% $CRMIsActionAllowed:ManageFinance.XMBills.Edit %>" /> -->
                    <asp:ImageButton ID="imgBtnDelete" runat="server" ImageUrl="~/App_Themes/Default/Image/close02.gif"
                        CommandArgument='<%#Eval("BillID")%>' ToolTip="删除" CommandName="XMBillsDelete" CausesValidation="False"
                        OnClientClick="return confirm('您确定要删除此条记录？');" Visible="<% $CRMIsActionAllowed:ManageFinance.XMBills.Delete %>" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="Contentplaceholder3" runat="server">
   <table border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td>
                <asp:Button ID="btnVerification" runat="server" Text="核销账单" OnClick="btnVerification_Click" Visible="<% $CRMIsActionAllowed:ManageFinance.XMBills.VerificationBills %>"
                    SkinID="button4" />
            </td>
            <td style="width: 4px">
            </td>
            <td>
               <asp:Button ID="btnImportBills" runat="server" Text="导入账单"  Visible="<% $CRMIsActionAllowed:ManageFinance.XMBills.ImportBills %>"
                    SkinID="button4" />
            </td>
            <td style="width: 4px">
             </td>
            <td>
                <asp:Button ID="btnBillsExport" SkinID="button4" runat="server" Text="导出账单"
                    OnClick="btnBillsExport_Click" Visible="<% $CRMIsActionAllowed:ManageFinance.XMBills.Export %>" />
            </td>
            <td style="width: 4px">
             </td>
        </tr>
    </table>-
</asp:Content>

