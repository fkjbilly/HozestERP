<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Root.Master" AutoEventWireup="true"
    CodeBehind="CustomerRole.aspx.cs" Inherits="HozestERP.Web.ManageSystem.CustomerRole" %>

<%@ MasterType VirtualPath="~/MasterPages/Root.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder4" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table border="0" cellpadding="2" cellspacing="2" style="width: 100%">
        <tr>
            <td style="width: 100px">
                名称
            </td>
            <td style="width: 120px">
                <asp:TextBox ID="txtName" runat="server" MaxLength="50"></asp:TextBox>
            </td>
            <td style="width: 40px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 120px">
            </td>
            <td style="text-align: right">
                <asp:Button ID="btnSearch" runat="server" Text="查询" OnClick="btnSearch_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <script language="javascript" type="text/javascript">
        function ShowDetail(URL) {
            var returnValue = window.showModalDialog(URL, "", "status:no;help:no;dialogWidth:450px;dialogHeight:300px;scroll:no;center:yes;");
            return true;
        }

        function ShowModuleDetail(URL) {

            if (window.parent.Ext != undefined) {
                var window1 = new window.parent.Ext.Window({
                    title: '权限设置',
                    bodyStyle: 'background:#fff;',
                    closeAction: 'close',
                    layout: "border",
                    closable: true,
                    width: 600,
                    height: 600,
                    modal: true,
                    resizable: false,
                    autoScroll: false,
                    plain: true,
                    autoLoad: { showMask: true, scripts: true, url: '<%=CommonHelper.GetStoreLocation() %>ManageSystem/' + URL, mode: 'iframe', maskMsg: '正在初始化 页面，请稍等...' }
                });

                window1.on("close", function () {
                    document.getElementById('<%=this.btnSearch.ClientID %>').click();
                });
                window1.show(document.body);
                return false;
            }
            else {
                var returnValue = window.showModalDialog(URL, "", "status:no;help:no;dialogWidth:600px;dialogHeight:600px;scroll:no;center:yes;");
                return true;
            }
        }


        function Load(parentid,gridid, ico_Expand)
        {
             var grid = document.getElementById(gridid);
             var parent =  parentid      
             var src;
             var action;
             if(ico_Expand.src==icon_hide)
            {
                src = icon_show;
                action = "";
            }
            else            
            {
                src = icon_hide;
                action = "none";
            }
              // aa     
            for(i=1; i< grid.rows.length;i++)
            {
                if(grid.rows[i].cells[1].childNodes[grid.rows[i].cells[1].childNodes.length-2].value == parentid)
                {
                    //第一级子节点
                    grid.rows[i].style.display = action;
                    var imgExpand = document.getElementById(grid.rows[i].ExpandID);
                    if( imgExpand != null)
                    {
                        if(action =="none" && imgExpand.src == icon_show)
                        {
                            imgExpand.src = icon_hide;
                            RowAction(action, grid.rows[i].TypeID, grid, src);
                        }
                    }
                }
            
            }
            ico_Expand.src = src;
        }

        function RowAction(action, parentid, grid, src)
        {
            var i=0;
            for(i=1; i< grid.rows.length;i++)
            {
                if(grid.rows[i].cells[1].childNodes[grid.rows[i].cells[1].childNodes.length-2].value == parentid)
                {
                    //第一级子节点
                    grid.rows[i].style.display = action;
                    var imgExpand = document.getElementById(grid.rows[i].ExpandID);
                    if( imgExpand != null)
                    {
                        if(imgExpand.src == icon_show)
                        {
                            imgExpand.src = icon_hide;
                            RowAction(action, grid.rows[i].TypeID, grid, src);
                        }
                    }
                }
            
            }
        }

    </script>
    <asp:GridView ID="grdRole" runat="server" AutoGenerateColumns="False" DataKeyNames="CustomerRoleID"
        SkinID="GridViewThemen" OnRowCommand="grdRole_RowCommand" OnRowDataBound="grdRole_RowDataBound">
        <Columns>
            <asp:TemplateField HeaderText="">
                <ItemTemplate>
                    <%# Container.DataItemIndex + 1 %>
                </ItemTemplate>
                <HeaderStyle Wrap="False" Width="20px" HorizontalAlign="Center"></HeaderStyle>
            </asp:TemplateField>
          <%--  <asp:BoundField DataField="Name" HeaderText="名称">
                <HeaderStyle Wrap="False" HorizontalAlign="Center" Width="180px"></HeaderStyle>
            </asp:BoundField>--%>
             <asp:TemplateField HeaderText="名称">
                <ItemTemplate>
                    <asp:Label id="lblTab" runat="server"></asp:Label> 
                    <asp:ImageButton id="IbtnExpand" runat="server" Width="9px" Height="9px" ImageUrl="~/images/icon_hide.gif"></asp:ImageButton> 
                    <asp:Literal ID="litName" runat="server" Text='<%# Bind("Name") %>'></asp:Literal>
                    <asp:HiddenField id="hidParentID" runat="server" Value='<%# Bind("ParentCustomerRoleID") %>'></asp:HiddenField>
                </ItemTemplate>
                </asp:TemplateField>
            <asp:TemplateField HeaderText="发布">
                <ItemTemplate>
                    <CRM:ImageCheckBox ID="chkPublished" runat="server" Checked='<%#Eval("Active")%>' />
                </ItemTemplate>
                <HeaderStyle Wrap="False" HorizontalAlign="Center" Width="60px"></HeaderStyle>
                <ItemStyle HorizontalAlign="Center" />
            </asp:TemplateField>
            <asp:BoundField DataField="Description" HeaderText="说明">
                <HeaderStyle Wrap="False" Width="250px"></HeaderStyle>
            </asp:BoundField>
            <asp:TemplateField HeaderText="详细">
                <ItemStyle Width="30px" HorizontalAlign="Center"></ItemStyle>
                <ItemTemplate>
                    <asp:ImageButton ID="imgbtnDetail" runat="server" CommandArgument='<%# Eval("CustomerRoleID") %>'
                        SkinID="btnDetail" CommandName="Detail" ToolTip="基本信息查看及修改"></asp:ImageButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="操作">
                <ItemStyle Width="30px" HorizontalAlign="Center"></ItemStyle>
                <ItemTemplate>
                    <asp:ImageButton ID="imgbtnDelte" runat="server" CommandArgument='<%# Eval("CustomerRoleID") %>'
                        SkinID="btnDetailDelete" CommandName="CustomerRoleDelete" OnClientClick="return confirm('您确定要删除此条记录.');" ToolTip="删除操作">
                    </asp:ImageButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="权限" >
                <ItemStyle Width="50px" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
                <ItemTemplate>
                    <asp:ImageButton ID="imbtnSet" runat="server" CommandArgument='<%# Eval("CustomerRoleID") %>'
                       SkinID="btnDetail" CommandName="SetCustomerRole"  ToolTip="权限维护"></asp:ImageButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="人员" >
                <ItemStyle Width="50px" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
                <ItemTemplate>
                    (<%# (Container.DataItem as CustomerRole).SCustomers.Where(p=>p.Deleted.Equals(false)).Count() %>)
                    <asp:ImageButton ID="imbtnSelectCustomer" runat="server" CommandArgument='<%# Eval("CustomerRoleID") %>'
                        ImageUrl="~/images/icon_people.gif" CommandName="SelectCustomer"  ToolTip="权限维护"></asp:ImageButton>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="Contentplaceholder3" runat="server">
    <table border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td>
                <asp:Button ID="btnAdd" runat="server" Text="添加" OnClick="btnAdd_Click" OnClientClick="return ShowDetail('CustomerRoleDetails.aspx');" />
            </td>
            <td style="width: 4px">
            </td>
        </tr>
    </table>
</asp:Content>
