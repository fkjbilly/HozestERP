<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Root.Master" AutoEventWireup="true"
    CodeBehind="XMProductManage.aspx.cs" Inherits="HozestERP.Web.ManageProject.XMProductManage"
    EnableEventValidation="true" %>

<%@ MasterType VirtualPath="~/MasterPages/Root.Master" %>
<%@ Register Src="~/Modules/CodeControl.ascx" TagName="CodeControl" TagPrefix="HozestERP" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .AdjustFactoryPriceImg
        {
            width: 16px;
            height: 16px;
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
            <td style="width: 80px; text-align: right;">
                品牌:
            </td>
            <td style="width: 150px;">
                <HozestERP:CodeControl ID="CCBrandTypeList" runat="server" Width="90%" CodeType="187"
                    EmptyValue="true" />
            </td>
             <td style="width: 80px; text-align: right;">
                供应商:
            </td>
            <td style="width: 200px;">
                     <asp:TextBox ID="ddSuppliers" name="ddSuppliers" runat="server" Width="100%"></asp:TextBox>
            </td>

            <td style="width: 80px; text-align: right;">
                产品名称:
            </td>
            <td style="width: 150px;">
                <asp:TextBox ID="txtProductName" runat="server" Width="100%"></asp:TextBox>
            </td>
            <td style="width: 80px; text-align: right;">
                厂家编码:
            </td>
            <td style="width: 150px;">
                <asp:TextBox ID="txtFactoryCode" runat="server" Width="100%"></asp:TextBox>
            </td>
            <td style="width: 80px; text-align: right;">
                商品编码:
            </td>
            <td style="width: 150px;">
                <asp:TextBox ID="txtProductCode" runat="server" Width="100%"></asp:TextBox>
            </td>
           
            <td style="text-align: right">
                <asp:Button ID="btnSearch" runat="server" Text="查询" OnClick="btnSearch_Click" />
                <asp:Button ID="btnRefresh" runat="server" Style="width: 0px; display: none;" ToolTip="刷新"
                    OnClick="btnRefresh_Click" />
            </td>
        </tr>
        <tr>
            <%--<td style="width: 80px">
            </td>
            <td style="width: 120px;">
            </td> 
            <td style="width: 20px">
            </td>
            <td style="width: 80px">
            </td>
            <td style="width: 80px">
            </td>
            <td style="width: 150px">
            </td>
            <td style="width: 80px">
            </td>
            <td style="width: 150px">
            </td>--%>
            <td style="text-align: right" colspan="11">
                <%--<asp:FileUpload ID="fileUploadImport" runat="server" Width="30%" />
                <asp:Button ID="btnStoreManufacturersInventoryImport" runat="server" Text="库存导入" SkinID="button4"
                    CssClass="reachedAndGoal" Visible="<% $CRMIsActionAllowed:XMProductManage.ImportManufacturersInventory %>"
                    OnClick="btnStoreManufacturersInventoryImport_Click" />--%>
                <asp:Button ID="btnGiftStorage" runat="server" Text="赠品入库" SkinID="button4" CssClass="reachedAndGoal"
                    Visible="<% $CRMIsActionAllowed:XMProductManage.GiftStorage %>" />
                <asp:Button ID="btnSearchGiftStorageRecords" runat="server" Text="入库查询" SkinID="button4"
                    CssClass="reachedAndGoal" Visible="<% $CRMIsActionAllowed:XMProductManage.SearchGiftStorageRecords %>" />
                <asp:Button ID="btnModifyManufacturersInventory" runat="server" Text="修改库存" SkinID="button4"
                    CssClass="reachedAndGoal" OnClick="btnModifyManufacturersInventory_Click" Visible="<% $CRMIsActionAllowed:XMProductManage.UpdateManufacturersInventory %>" />
                <asp:Button ID="btnSaveManufacturersInventory" runat="server" Text="保存库存" SkinID="button4"
                    CssClass="reachedAndGoal" OnClick="btnSaveManufacturersInventory_Click" Visible="<% $CRMIsActionAllowed:XMProductManage.SaveManufacturersInventory %>" />
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <asp:GridView ID="gvXMProduct" runat="server" AutoGenerateColumns="False" DataKeyNames="Id"
        SkinID="GridViewThemen" OnRowCancelingEdit="gvXMProduct_RowCancelingEdit" OnRowDeleting="gvXMProduct_RowDeleting"
        OnRowEditing="gvXMProduct_RowEditing" OnRowUpdating="gvXMProduct_RowUpdating" 
        OnRowDataBound="gvXMProduct_RowDataBound">
        <Columns>
            <asp:TemplateField HeaderText="">
                <ItemTemplate>
                    <%# Container.DataItemIndex + 0 %>
                </ItemTemplate>
                <EditItemTemplate>
                </EditItemTemplate>
                <HeaderStyle Wrap="False" Width="20px" HorizontalAlign="Center"></HeaderStyle>
            </asp:TemplateField>
            <asp:TemplateField>
                <HeaderTemplate>
                    <input id="chkAll" onclick="SelectAll(this, 99)" type="checkbox" />
                </HeaderTemplate>
                <ItemStyle Width="30px" HorizontalAlign="Center"></ItemStyle>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                <ItemTemplate>
                    <asp:CheckBox ID="chkSelected" TabIndex="99" runat="server" type="checkbox"></asp:CheckBox>
                    <asp:HiddenField ID="hdID" Value='<%#Eval("Id")%>' runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="发货方" SortExpression="ShipperName">
                <HeaderStyle Width="50px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("ShipperName") %>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:DropDownList ID="ddlShipper" runat="server" Width="90%">
                    </asp:DropDownList>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="品牌" SortExpression="BrandId">
                <HeaderStyle Width="70px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# (Container.DataItem as HozestERP.BusinessLogic.ManageProject.XMProduct).BrandTypeCodeName != null ? (Container.DataItem as HozestERP.BusinessLogic.ManageProject.XMProduct).BrandTypeCodeName : ""%>
                </ItemTemplate>
                <EditItemTemplate>
                    <HozestERP:CodeControl ID="CCBrandTypeId" runat="server" Width="90%" CodeType="187"
                        EmptyValue="false" />
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="供应商" SortExpression="SuppliersID">
                <HeaderStyle Width="150px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                       <%# base.XMBillsservice.ReturnSuppliersName(int.Parse(Eval("SuppliersID") == null ? "-1" : Eval("SuppliersID").ToString()))%>
                </ItemTemplate>
                <EditItemTemplate>
                     <asp:TextBox ID="ddEditSuppliersID" name="ddEditSuppliersID" runat="server" Width="95%"></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField> 
            <asp:TemplateField HeaderText="产品名称" SortExpression="ProductName">
                <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("ProductName")%>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtProductName" runat="server" Width="90%" Text='<%# Eval("ProductName") %>'
                        MaxLength="20"></asp:TextBox>
                    <div style="text-align: center; width: 100%;">
                        <asp:Label ID="lblMsgProductNameVaule" runat="server" Text="" ForeColor="red"></asp:Label>
                    </div>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="厂家编码" SortExpression="ManufacturersCode">
                <HeaderStyle Width="70px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("ManufacturersCode")%>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:HiddenField ID="hfManufacturersCode" runat="server" Value='<%# Eval("ManufacturersCode") %>' />
                    <asp:TextBox ID="txtManufacturersCode" runat="server" Width="90%" Text='<%# Eval("ManufacturersCode") %>'
                        MaxLength="50"></asp:TextBox>
                    <div style="text-align: center; width: 100%;">
                        <asp:Label ID="lblMsgManufacturersCodeVaule" runat="server" Text="" ForeColor="red"></asp:Label>
                    </div>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="尺寸" SortExpression="Specifications">
                <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("Specifications")%>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtSpecifications" runat="server" Width="90%" Text='<%# Eval("Specifications") %>'
                        MaxLength="20"></asp:TextBox>
                    <div style="text-align: center; width: 100%;">
                        <asp:Label ID="lblMsgSpecificationsVaule" runat="server" Text="" ForeColor="red"></asp:Label>
                    </div>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="系列" SortExpression="Series">
                <HeaderStyle Width="80px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("Series")%>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtSeries" runat="server" Width="90%" Text='<%# Eval("Series") %>'></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>
          <%--  <asp:TemplateField HeaderText="厂家库存" SortExpression="ManufacturersInventory">
                <HeaderStyle Width="40px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <asp:Label ID="lblManufacturersInventory" runat="server" Text='<%# Eval("ManufacturersInventory")%>'></asp:Label>
                    <asp:TextBox ID="txtManufacturersInventory" runat="server" Width="90%" Text='<%# Eval("ManufacturersInventory") %>'
                        MaxLength="8" Visible="false"></asp:TextBox>
                    <div style="text-align: center; width: 100%;">
                        <asp:Label ID="lblMsgManufacturersInventoryVaule" runat="server" Text="" ForeColor="red"></asp:Label>
                    </div>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtManufacturersInventoryE" runat="server" Width="90%" Text='<%# Eval("ManufacturersInventory") %>'
                        MaxLength="8"></asp:TextBox>
                    <div style="text-align: center; width: 100%;">
                        <asp:Label ID="lblMsgManufacturersInventoryEVaule" runat="server" Text="" ForeColor="red"></asp:Label>
                    </div>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="预警库存数" SortExpression="WarningQuantity">
                <HeaderStyle Width="20px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <asp:Label ID="lblWarningQuantity" runat="server" Text='<%# Eval("WarningQuantity")%>'></asp:Label>
                    <asp:TextBox ID="txtWarningQuantity" runat="server" Width="90%" Text='<%# Eval("WarningQuantity") %>'
                        MaxLength="8" Visible="false"></asp:TextBox>
                    <div style="text-align: center; width: 100%;">
                        <asp:Label ID="lblMsgWarningQuantityVaule" runat="server" Text="" ForeColor="red"></asp:Label>
                    </div>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtWarningQuantityE" runat="server" Width="90%" Text='<%# Eval("WarningQuantity") %>'
                        MaxLength="8"></asp:TextBox>
                    <div style="text-align: center; width: 100%;">
                        <asp:Label ID="lblMsgWarningQuantityEVaule" runat="server" Text="" ForeColor="red"></asp:Label>
                    </div>
                </EditItemTemplate>
            </asp:TemplateField>--%>
            <asp:TemplateField HeaderText="颜色" SortExpression="ProductColors">
                <HeaderStyle Width="60px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("ProductColors")%>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtProductColors" runat="server" Width="90%" Text='<%# Eval("ProductColors") %>'
                        MaxLength="20"></asp:TextBox>
                    <%-- <div style="text-align:center; width:100%;">
                 <asp:Label ID="lblMsgProductColorsVaule" runat="server" Text="" ForeColor="red"></asp:Label>
                </div>--%>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="计量单位" SortExpression="ProductUnit">
                <HeaderStyle Width="20px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("ProductUnit")%>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtProductUnit" runat="server" Width="90%" Text='<%# Eval("ProductUnit") %>'
                        MaxLength="5"></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="体重" SortExpression="ProductWeight">
                <HeaderStyle Width="50px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("ProductWeight")%>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtProductWeight" runat="server" Width="90%" Text='<%# Eval("ProductWeight") %>'
                        MaxLength="5"></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="体积" SortExpression="ProductVolume">
                <HeaderStyle Width="50px" HorizontalAlign="Center" Wrap="False" />
                <ItemTemplate>
                    <%# Eval("ProductVolume")%>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtProductVolume" runat="server" Width="90%" Text='<%# Eval("ProductVolume") %>'
                        MaxLength="5"></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="是否赠品" SortExpression="IsPremiums">
                <HeaderStyle Width="20px" HorizontalAlign="Center" Wrap="False" />
                <ItemStyle HorizontalAlign="Center" />
                <ItemTemplate>
                    <CRM:ImageCheckBox ID="imgChkIsPremiums" runat="server" Checked='<%# Eval("IsPremiums")==null?false: Eval("IsPremiums")%>' />
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:CheckBox ID="chkIsPremiums" runat="server" Checked='<%# Eval("IsPremiums")==null?false: Eval("IsPremiums")%>' />
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="调货" SortExpression="IsMoveCargo">
                <HeaderStyle Width="30px" HorizontalAlign="Center" Wrap="False" />
                <ItemStyle HorizontalAlign="Center" />
                <ItemTemplate>
                    <CRM:ImageCheckBox ID="imgChkIsMoveCargo" runat="server" Checked='<%# Eval("IsMoveCargo")==null?false: Eval("IsMoveCargo")%>' />
                </ItemTemplate>
                <EditItemTemplate>
                    <CRM:ImageCheckBox ID="imgChkIsMoveCargo" runat="server" Checked='<%# Eval("IsMoveCargo")==null?false: Eval("IsMoveCargo")%>' />
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="操作">
                <HeaderStyle HorizontalAlign="Center" Width="90px" Wrap="False" />
                <ItemTemplate>
                    <asp:ImageButton ID="imgBtnEdit" runat="server" ImageUrl="~/App_Themes/Default/Image/update.gif"
                        ToolTip="编辑" CommandName="Edit" CausesValidation="False" Visible="<% $CRMIsActionAllowed:XMProductManage.Edit %>" />
                    <asp:ImageButton ID="imgProductDetails" runat="server" ImageUrl="~/App_Themes/Blue/Image/ButtonImages/meeting.gif"
                        ToolTip="产品管理" CommandName="look" CausesValidation="False" Visible="<% $CRMIsActionAllowed:XMProductManage.XMProductDetails %>" />
                    <asp:ImageButton ID="imgBtnDelete" runat="server" ImageUrl="~/App_Themes/Default/Image/close02.gif"
                        ToolTip="删除" CommandName="Delete" CausesValidation="False" OnClientClick="return confirm('您确定要删除此条记录？');"
                        Visible="<% $CRMIsActionAllowed:XMProductManage.Delete %>" />
                    <asp:ImageButton ID="imgAdjust" runat="server" ToolTip="调整价格" CausesValidation="False"
                        ImageUrl="~/App_Themes/Default/Image/AdjustFactoryPrice.png" CssClass="AdjustFactoryPriceImg"
                        Visible="<% $CRMIsActionAllowed:XMProductManage.AdjustOperation %>" />
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:ImageButton ID="imgBtnUpdate" runat="server" ImageUrl="~/App_Themes/Default/Image/save.gif"
                        ToolTip="保存" CommandName="Update" CausesValidation="True" Visible="<% $CRMIsActionAllowed:XMProductManage.Save %>" />
                    <asp:ImageButton ID="imgBtnCancel" runat="server" ImageUrl="~/App_Themes/Default/Image/Cancel.gif"
                        ToolTip="取消" CommandName="Cancel" CausesValidation="False" Visible="<% $CRMIsActionAllowed:XMProductManage.Cancel %>" />
                </EditItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
       <script type="text/javascript">
           var data = [];
           function EditSuppliers(index, value) {
               var name = "#ctl00_ContentPlaceHolder2_gvXMProduct_ctl" + index + "_ddEditSuppliersID";
               $(name).select2({
                   data: data
               });
               //$(name).select2('val', value);
               $(name).val([value]).trigger('change');
           }
           function TopSuppliers() {
               $("#ctl00_ContentPlaceHolder2_gvXMProduct_ctl02_ddEditSuppliersID").select2({
                   data: data
               });
           }
           function GetSelect2Data()
           {
               $.ajax({
                   url: "/ManageFinance/XMBillsSelect2.ashx",
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
                       data = select2data;
                       $("#ctl00_ContentPlaceHolder1_ddSuppliers").select2({
                           data: select2data
                       });
                       $("#ctl00_ContentPlaceHolder2_gvXMProduct_ctl02_ddEditSuppliersID").select2({
                           data: select2data
                       });
                   },
                   error: function (x, e) {
                   },
                   complete: function (x) {
                   }
               });
           }
        jQuery(function ($) {
            GetSelect2Data();
        });
    </script>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="Contentplaceholder3" runat="server">
    <table border="0" cellpadding="0" cellspacing="0" width="10%">
        <tr>
            <td>
                <asp:Button ID="btnImportProduct" runat="server" Text="导入产品" Visible="<% $CRMIsActionAllowed:ManageProject.XMProductManage.ImportProduct %>"
                    SkinID="button4" />
            </td>
            <td style="width: 4px">
            </td>
            <td>
                <asp:Button ID="btnExportProduct" runat="server" Text="导出产品" OnClick="btnExportProduct_Click"
                    SkinID="button4" />
            </td>
            <td style="width: 4px">
            </td>
            <td>
                <asp:Button ID="btnMoveCargo" SkinID="button4" runat="server" Text="允许调货" OnClick="btnMoveCargo_Click"
                    OnClientClick="return confirm('您确定使选中的产品允许调货？');" Visible="<% $CRMIsActionAllowed:ManageProject.XMProductManage.MoveCargo %>" />
            </td>
            <td style="width: 4px">
            </td>
            <td>
                <asp:Button ID="btnUnMoveCargo" SkinID="button4" runat="server" Text="不允许调货" OnClick="btnUnMoveCargo_Click"
                    OnClientClick="return confirm('您确定使选中的产品不允许调货？');" Visible="<% $CRMIsActionAllowed:ManageProject.XMProductManage.UnMoveCargo %>" />
            </td>
            <td style="width: 4px">
            </td>
            <td>

                <asp:Button ID="btnImportFactoryPrice" SkinID="button4" runat="server" Text="修改出厂价" />
            </td>
        </tr>
    </table>
</asp:Content>
