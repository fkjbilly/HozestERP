<%@ Page Language="C#" MasterPageFile="~/MasterPages/Root.Master" AutoEventWireup="true"
 CodeBehind="ChatRecordManage.aspx.cs" Inherits="HozestERP.Web.ManageCustomerService.ChatRecordManage" %>

<%@ MasterType VirtualPath="~/MasterPages/Root.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder4" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="pnlSearch" runat="server" DefaultButton="btnSearch">
        <table border="0" cellpadding="2" cellspacing="2" style="width: 100%">
            <tr>
               <td style="width: 80px">
                    客服名称：
                </td>
                <td style="width: 120px">
                    <asp:TextBox ID="txtSearchWaiter" runat="server"></asp:TextBox>
                </td>
                <td style="width: 40px">
                </td>
                <td style="width: 80px">
                    顾客名称：
                </td>
                <td style="width: 120px">
                    <asp:TextBox ID="txtSearchCustomer" runat="server"></asp:TextBox>
                </td>
                <td style="width: 40px">
                </td>
                <td style="text-align: right">
                    <asp:Button ID="btnSearch" runat="server" Text="查询" OnClick="btnSearch_Click" />
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <script type="text/javascript" src="../Script/jquery1.9.1/jquery-1.9.1.js"></script>
    <script type="text/javascript" language="javascript">
        function ShowHidde(sid, evt) {
            var b = "";
            //还原其他所有行
            $("tr[id^=div]").each(function () {
                var a = $(this).attr("id").replace('div', '');
                var obja = document.getElementById("div" + a);
                if (obja.style.display == "block" || obja.style.display == "table-row") {
                    b = a;//点击同一个
                }
                obja.style.display = "none";
                var imga = 'img' + a;
                document.getElementById(imga).src = "../images/folder.gif";
            });
            //如果点击同一个
            if (sid == b) {
                var a = b.replace('div', '');
                var obja = document.getElementById("div" + a);
                if (obja.style.display == "block" || obja.style.display == "table-row") {
                    b = $(this).attr("id"); //点击同一个
                }
                obja.style.display = "none";
                var imga = 'img' + a;
                document.getElementById(imga).src = "../images/folder.gif";
            } else {
                evt = evt || window.event;
                var target = evt.target || evt.srcElement;
                var objDiv = document.getElementById("div" + sid);
                if (window.ActiveXObject) {
                    objDiv.style.display = objDiv.style.display == "none" ? "block" : "none";
                }
                else {
                    objDiv.style.display = objDiv.style.display == "none" ? "table-row" : "none";
                }
                target.title = objDiv.style.display == "none" ? "Show" : "Hide";
                var imgid = 'img' + sid;
                document.getElementById(imgid).src = objDiv.style.display == "none" ? "../images/folder.gif" : "../images/folderopen.gif";
            }
        }
    </script> 
    <asp:GridView ID="gvContent" runat="server" AutoGenerateColumns="False" DataKeyNames="Id"
        SkinID="GridViewThemen" onrowdatabound="gvContent_RowDataBound" >
        <Columns>
            <asp:TemplateField HeaderText="">
                <ItemTemplate>
                    <a href="javascript:void(0);"><img id='img<%# Eval("Id")%>' style="border: 0px;" src="../images/folder.gif" onclick="ShowHidde('<%#Eval("Id")%>',event)" /></a>
                    <%# Container.DataItemIndex + 1 %>
                </ItemTemplate>
                <HeaderStyle Wrap="False" Width="20px" HorizontalAlign="Center"></HeaderStyle>
            </asp:TemplateField>

            <%--<asp:TemplateField>
                <HeaderTemplate>
                    <input id="chkAll" onclick="SelectAll(this, 99)" type="checkbox" />
                </HeaderTemplate>
                <ItemStyle Width="30px" HorizontalAlign="Center"></ItemStyle>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                <ItemTemplate>
                    <asp:CheckBox ID="chkSelected" TabIndex="99" runat="server" type="checkbox"></asp:CheckBox>
                </ItemTemplate>
            </asp:TemplateField>--%>
            <asp:TemplateField HeaderText="客服名称">
                <ItemTemplate>
                    <%# Eval("Waiter")%>
                </ItemTemplate>
                <HeaderStyle Wrap="False" HorizontalAlign="Center" Width="200px"></HeaderStyle>
                <ItemStyle Width="200px" />
            </asp:TemplateField>

            <asp:TemplateField HeaderText="顾客名称">
                <ItemTemplate>
                    <%# Eval("Customer") %>

                    <!--下拉tr-->
                    <tr id="div<%# Eval("Id") %>" style=" background-color:White; display:none;">
                        <td colspan="100%" style=" width:100%; height:100%;">
                            <div style="background-color:White;">
                                <div style=" position: relative; left: 0px; overflow: auto;
                                    width: 100%;">
                                    <!---绑定内层Gridview--->
                                    <asp:GridView ID="gvContent1" runat="server" Width="100%"
                                    AutoGenerateColumns="False" DataKeyNames="Id" BorderStyle="None"
                                    onrowdatabound="gvContent1_RowDataBound">
                                        <Columns>
                                            <asp:TemplateField HeaderText="聊天内容" HeaderStyle-BorderColor="#ababab">
                                                <ItemTemplate>
                                                    <asp:Label runat="server" ID="lblContent" Width="800px"></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle BorderColor="#ababab" />
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="聊天类型" HeaderStyle-BorderColor="#ababab">
                                                <ItemTemplate>
                                                    <%# ReturnChannel(Eval("Channel").ToString()) %>
                                                </ItemTemplate>
                                                <ItemStyle Width="200px" BorderColor="#ababab" />
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="时间" HeaderStyle-BorderColor="#ababab">
                                                <ItemTemplate>
                                                    <%# Eval("Time") %>
                                                </ItemTemplate>
                                                <ItemStyle Width="120px" BorderColor="#ababab" />
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </div>
                        </td>
                    </tr>


                </ItemTemplate>
                <ItemStyle Width="200px"></ItemStyle>
                <HeaderStyle Wrap="False" HorizontalAlign="Center"></HeaderStyle>
            </asp:TemplateField>

            <%--<asp:TemplateField HeaderText="聊天开始时间">
                <ItemTemplate>
                    <%# Eval("Time") %>
                    
                </ItemTemplate>
                <ItemStyle Width="40px" HorizontalAlign="Center"></ItemStyle>
                <HeaderStyle Wrap="False" HorizontalAlign="Center"></HeaderStyle>
            </asp:TemplateField>--%>
           
            <%--<asp:TemplateField HeaderText="详细">
                <ItemStyle Width="30px" HorizontalAlign="Center"></ItemStyle>
                <ItemTemplate>
                    <asp:ImageButton ID="imgbtnDetail" runat="server" CommandArgument='<%# Eval("CustomerID") %>'
                        SkinID="btnDetail" CommandName="Detail"></asp:ImageButton>
                </ItemTemplate>
            </asp:TemplateField>--%>
        </Columns>
    </asp:GridView>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="Contentplaceholder3" runat="server">
</asp:Content>

