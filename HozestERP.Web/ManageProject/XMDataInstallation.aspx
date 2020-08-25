<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPages/Root.Master" CodeBehind="XMDataInstallation.aspx.cs" Inherits="HozestERP.Web.ManageProject.XMDataInstallation" %>


<%@ MasterType VirtualPath="~/MasterPages/Root.Master" %>
<%@ Register Src="~/Modules/CodeControl.ascx" TagName="CodeControl" TagPrefix="CRM" %>
<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../My97DatePicker/WdatePicker.js" type="text/javascript"></script>
    <script src="../Script/CommonManager.js" type="text/javascript"></script>
    <script src="../Script/jquery1.9.1/jquery-1.9.1.js" type="text/javascript"></script>
    <script src="../Script/jquery1.9.1/ui/jquery-ui.js" type="text/javascript"></script>
    <link href="../Script/jquery1.9.1/themes/base/jquery-ui.css" rel="stylesheet" type="text/css" />
    <link href="../Script/jquery1.9.1/themes/base/jquery.ui.theme.css" rel="stylesheet"
        type="text/css" />
    <style type="text/css">
        .headbackground {
            border-top-color: transparent;
            border-bottom-color: transparent;
            border-left-color: transparent;
            border-right-color: transparent;
        }

        .gridlist {
            background: none repeat 0% 0% #FFF;
            color: #444444;
            border-collapse: collapse;
            border: 1px solid #D5DFE3;
            margin: 0px;
            height: auto;
            border: 0px;
        }

        .x-selectable, .x-selectable * {
            -moz-user-select: text !important;
            -webkit-user-select: text !important;
            font-size: 12px;
            font-family: 'Microsoft YaHei';
        }

        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder4" runat="server">
    <ext:ResourceManager ID="ResourceManager1" runat="server" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table border="0" cellpadding="2" cellspacing="2" style="width: 100%">
        <tr>
            <td style="width: 100px">项目名称
            </td>
            <td style="width: 200px">
                <%--<asp:DropDownList ID="ddXMProject" Width="100%" runat="server" OnSelectedIndexChanged="ddXMProject_SelectedIndexChanged"
                    AutoPostBack="true">
                </asp:DropDownList>--%>
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
                <ext:ComboBox runat="server" ID="ddXMProject" DisplayField="ProjectName" ValueField="Id" StoreID="CB1Store" Width="200" Editable="false">
                    <Listeners>
                        <Select Handler="#{ddlNick2}.clearValue(); #{Store3}.reload();" />

                    </Listeners>
                </ext:ComboBox>
            </td>
            <td style="width: 20px"></td>
            <td style="width: 100px">店铺名称
            </td>
            <td style="width: 200px">
                <ext:ComboBox runat="server" ID="ddlNick2" DisplayField="nick" ValueField="nick_id" ColumnWidth="0.14" LabelWidth="30" Editable="false">
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
            </td>
            <td style="width: 50px"></td>
            <td style="width: 100px">负责人
            </td>
            <td style="width: 200px;">
                <asp:TextBox ID="txtWork" runat="server" Width="100%"></asp:TextBox>
            </td>
            <td style="width: 50px"></td>
            <td style="width: 100px">时间
            </td>
            <td style="width: 200px">
                <input id="txtCreateDateBegin" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss'})"
                    class="Wdate" runat="server" style="width: 100%;" />
            </td>
            <td style="width: 20px"></td>
            <td style="width: 80px">到
            </td>
            <td style="width: 200px">
                <input id="txtCreateDateEnd" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss'})"
                    class="Wdate" runat="server" style="width: 100%;" />
            </td>
            <td style="width: 80px"></td>
            <td style="text-align: right">
                <asp:Button ID="btnSearch" runat="server" Text="查询"  OnClick="btnSearch_Click"/>

            </td>
        </tr>
    </table>

        <ext:GridPanel ID="GridPanel"
        runat="server"
        Margins="0 0 5 5"
        Region="Center"
        Frame="true"
        Height="550" BodyCssClass="x-selectable">
        <Store>
            <ext:Store
                ID="Store1"
                runat="server">
                <Reader>
                    <ext:JsonReader>
                        <Fields>
                            <ext:RecordField Name="ProjectName" />
                            <ext:RecordField Name="NickName" />
                            <ext:RecordField Name="installationCount" />
                            <ext:RecordField Name="installationFinishCount" />
                            <ext:RecordField Name="installationMoney" />
                            <ext:RecordField Name="finishRate" />
                            <ext:RecordField Name="Worker" />
                        </Fields>
                    </ext:JsonReader>
                </Reader>
            </ext:Store>
        </Store>
        <ColumnModel ID="ColumnModel1" runat="server">
            <Columns>

                <ext:Column DataIndex="ProjectName" Header="项目" Width="100" />
                 <ext:Column DataIndex="NickName" Header="店铺" Width="200" />
                 <ext:Column DataIndex="installationCount" Header="安装数量" Width="100" />
                 <ext:Column DataIndex="installationFinishCount" Header="安装完成数量" Width="100" />
                 <ext:Column DataIndex="installationMoney" Header="安装完成金额" Width="100" />
                 <ext:Column DataIndex="finishRate" Header="完成率" Width="100" />
                 <ext:Column DataIndex="Worker" Header="负责人" Width="100" />
            </Columns>
        </ColumnModel>

            <SelectionModel>
                <ext:RowSelectionModel runat="server"></ext:RowSelectionModel>
            </SelectionModel>

    </ext:GridPanel>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

</asp:Content>
