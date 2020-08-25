<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AreaCodes.aspx.cs" Inherits="HozestERP.Web.ManageSystem.AreaCodes" %>

<script runat="server">
    [DirectMethod(Namespace = "CompanyX")]
    public string NodeLoad(string nodeID)
    {
        Ext.Net.TreeNodeCollection nodes = new Ext.Net.TreeNodeCollection();
        if (!string.IsNullOrEmpty(nodeID))
        {
            var areaCodes = base.AreaCodeService.GetAreaCode(nodeID);

            foreach (var item in areaCodes)
            {
                AsyncTreeNode asyncNode = new AsyncTreeNode();
                asyncNode.Text = item.City;
                asyncNode.NodeID = item.NumberID;
                asyncNode.Expanded = false;
                asyncNode.CustomAttributes.Add(new ConfigItem("City", item.City, ParameterMode.Value));
                asyncNode.CustomAttributes.Add(new ConfigItem("PrePath", item.PrePath, ParameterMode.Value));
                asyncNode.CustomAttributes.Add(new ConfigItem("Spell", item.Spell, ParameterMode.Value));
                asyncNode.CustomAttributes.Add(new ConfigItem("shortening", item.shortening, ParameterMode.Value));
                asyncNode.CustomAttributes.Add(new ConfigItem("Post", item.Post, ParameterMode.Value));
                asyncNode.CustomAttributes.Add(new ConfigItem("AreaID", item.AreaID, ParameterMode.Value));
                asyncNode.CustomAttributes.Add(new ConfigItem("CityType", item.CityType, ParameterMode.Value));
                nodes.Add(asyncNode);
            }
        }

        return nodes.ToJson();
    }
</script>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <ext:ResourcePlaceHolder ID="ResourcePlaceHolder2" runat="server" Mode="Script" />
    <script type="text/javascript">
        var node;

        function nodeLoad(node) {
            CompanyX.NodeLoad(node.id, {
                success: function (result) {
                    var data = eval("(" + result + ")");
                    node.loadNodes(data);
                },

                failure: function (errorMsg) {
                    Ext.Msg.alert('Failure', errorMsg);
                }
            });
        }

        function rowClick(a)
        {
            node = a;
        }

        function editLoad()
        {
            if (typeof (node) == "undefined") {
                alert("请选择一条记录");
            }
            else
            {
                var PersonRecord = Ext.data.Record.create([
                    { name: 'City', type: 'string' },
                    { name: 'ID', type: 'string' },
                    { name: 'PrePath', type: 'string' },
                    { name: 'Spell', type: 'string' },
                    { name: 'shortening', type: 'string' },
                    { name: 'Post', type: 'string' },
                    { name: 'AreaID', type: 'string' },
                    { name: 'CityType', type: 'string' }
                ]);

                var data = new PersonRecord({
                    ID:node.id,
                    City: node.City,
                    PrePath: node.PrePath,
                    Spell: node.Spell,
                    shortening: node.shortening,
                    Post: node.Post,
                    AreaID: node.AreaID,
                    CityType:node.CityType
                });

                CompanyX.Window1.show();
                CompanyX.fromPanel1.reset();
                CompanyX.fromPanel1.getForm().loadRecord(data);
                CompanyX.btnEdit.setVisible(true);
                CompanyX.btnSave.setVisible(false);
            }
        }

        function addLoad()
        {
            CompanyX.Window1.show();
            CompanyX.fromPanel1.reset();
            CompanyX.btnEdit.setVisible(false);
            CompanyX.btnSave.setVisible(true);

            if (typeof (node) != "undefined")
            {
                var PersonRecord = Ext.data.Record.create([
                        { name: 'ID', type: 'string' }
                ]);

                var data = new PersonRecord({
                    ID: node.id,
                });

                CompanyX.fromPanel1.getForm().loadRecord(data);
            }
        }

        function getID()
        {
            return node.id;
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <ext:ResourceManager ID="ResourceManager1" runat="server" Namespace="CompanyX" />
    <ext:Viewport ID="Viewport1" runat="server" Layout="BorderLayout">
        <Items>
            <ext:TreeGrid ID="TreeGrid1" runat="server" Region="Center" NoLeafIcon="true" EnableDD="true" AutoExpandColumn="0">
                <TopBar>
                    <ext:Toolbar runat="server">
                        <Items>
                            <ext:Button runat="server" Text="新增" Icon="Add" ID="addInfo">
                                <Listeners>
                                    <Click Handler="addLoad()" />
                                </Listeners>
                            </ext:Button>
                            <ext:Button runat="server" Text="修改" Icon="Add" ID="editInfo">
                                <Listeners>
                                    <Click Handler="editLoad()" />
                                </Listeners>
                            </ext:Button>
<%--                            <ext:Button runat="server" Text="删除" Icon="Add" ID="delInfo">
                                <DirectEvents>
                                    <Click OnEvent="del_Click">
                                        <EventMask ShowMask="true" Msg="正在处理..."></EventMask>
                                        <ExtraParams>
                                            <ext:Parameter Name="ID" Value="getID()" Mode="Raw"></ext:Parameter>
                                        </ExtraParams>
                                    </Click>
                                </DirectEvents>
                            </ext:Button>--%>
                        </Items>
                    </ext:Toolbar>
                </TopBar>
                <Columns>
                    <ext:TreeGridColumn Header="名称" DataIndex="City" />
                    <ext:TreeGridColumn Header="全称" DataIndex="PrePath" Width="200" />
                    <ext:TreeGridColumn Header="拼音" DataIndex="Spell" Width="200" />
                    <ext:TreeGridColumn Header="简称" DataIndex="shortening" Width="50" />
                    <ext:TreeGridColumn Header="邮编" DataIndex="Post" Width="50" />
                    <ext:TreeGridColumn Header="区号" DataIndex="AreaID" Width="50" />
                    <ext:TreeGridColumn Header="类型" DataIndex="CityType" Width="100" />
                </Columns>
                <Root>
                    <ext:AsyncTreeNode NodeID="001" Text="菜单" Expanded="true">
                    </ext:AsyncTreeNode>
                </Root>
                <Listeners>
                    <BeforeLoad Fn="nodeLoad" />
                    <Click Handler="rowClick(node.attributes)" />
                </Listeners>
            </ext:TreeGrid>
        </Items>
    </ext:Viewport>
        <ext:Window ID="Window1" runat="server" BodyStyle="background:#fff;"
            CloseAction="Hide" Hidden="true" Width="350" Height="270" Layout="BorderLayout"
            Constrain="true" Icon="NoteEdit" Frame="true" Modal="true" ButtonAlign="Center" AutoScroll="true">
            <Items>
                <ext:FormPanel ID="fromPanel1" runat="server" Region="Center" Frame="true" DefaultAnchor="92%"
                    MonitorValid="true">
                    <Items>
                        <ext:TextField runat="server" ID="formID" DataIndex="ID" Hidden="true" />
                        <ext:TextField runat="server" ID="txtCity" FieldLabel="名称" DataIndex="City"/>
                        <ext:TextField runat="server" ID="txtPrePath" FieldLabel="全称" DataIndex="PrePath"/>
                        <ext:TextField runat="server" ID="txtSpell" FieldLabel="拼音" DataIndex="Spell"/>
                        <ext:TextField runat="server" ID="txtshortening" FieldLabel="简称" DataIndex="shortening"/>
                        <ext:TextField runat="server" ID="txtPost" FieldLabel="邮编" DataIndex="Post"/>
                        <ext:TextField runat="server" ID="txtAreaID" FieldLabel="区号" DataIndex="AreaID"/>
                        <ext:TextField runat="server" ID="txtCityType" FieldLabel="类型" DataIndex="CityType"/>
                    </Items>
                </ext:FormPanel>
            </Items>
            <Buttons>
                <ext:Button Text="保存" ID="btnSave" runat="server">
                    <DirectEvents>
                        <Click OnEvent="btnSave_Click" Success="CompanyX.Window1.hide();#{TreeGrid1}.getRootNode().reload()">
                            <EventMask ShowMask="true" Msg="正在提交中……" />
                        </Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button runat="server" ID="btnEdit" Text="修改">
                    <DirectEvents>
                        <Click OnEvent="btnEdit_Click" Success="CompanyX.Window1.hide();#{TreeGrid1}.getRootNode().reload()">
                            <EventMask ShowMask="true" Msg="正在提交中……" />
                        </Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button runat="server" Text="关闭" Handler="function(){CompanyX.Window1.hide();}">
                </ext:Button>
            </Buttons>
        </ext:Window>
    </form>
</body>
</html>
