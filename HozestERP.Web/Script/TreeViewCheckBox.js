// JScript 文件
// JScript 文件
function OnTreeNodeChecked(treeName) {
    var element = window.event.srcElement;
    if (!IsCheckBox(element))
    {
        return;
    }
    var isChecked = element.checked;
    var tree = GetTreeById(treeName);
    var node = GetNode(tree, element);
    SetChildNodesCheckStatus(node, isChecked);
    var parent = GetParentNode(tree, node); 
    NodeOnChildNodeCheckedChanged(tree, parent, isChecked);
}

//
// 设置子节点
//
function SetChildNodesCheckStatus(node, isChecked)
{ 
    var childNodes = GetChildNodesDiv(node);
    if(childNodes == null)
    {
        return;
    }
    var inputs = WebForm_GetElementsByTagName(childNodes, "INPUT");
    if(inputs == null || inputs.length == 0)
    {
        return;
    }
    for(var i = 0; i < inputs.length; i++)
    { 
        if(IsCheckBox(inputs[i])) 
        {
            inputs[i].checked = isChecked;
        }
    }
}

//
//  改变节点上的子节点状态
// 
function NodeOnChildNodeCheckedChanged(tree, node, isChecked)
{ 
    if(node == null)
    {
        return;
    }
    // 查找子节点
    var childNodes = GetChildNodes(tree, node);
    if(childNodes == null || childNodes.length == 0)
    {
        return;
    }
    // 判断当节点是否选中
    var isAllSame = true;
    for(var i = 0; i < childNodes.length; i++)
    {
        var item = childNodes[i];
        var value = NodeGetChecked(item);
        if(isChecked != value) 
        { 
            isAllSame = false;
            break;
        }
    }
    var parent = GetParentNode(tree,node);
    if(isAllSame)
    {
        NodeSetChecked(tree,node,isChecked);
        NodeOnChildNodeCheckedChanged(tree,parent,isChecked);
    }
    else
    {
        NodeSetChecked(tree,node,false);
        NodeOnChildNodeCheckedChanged(tree,parent,false);
    }
}

//
// 获取当前节点
//
function GetNode(tree, element)
{ 
    // 得到当前节点的名称
    var id = element.id.replace(tree.id, "");
    id = id.toLowerCase().replace(element.type, "");
    id = tree.id + id; 
    
    // 判断当前节点是否存在
    var node = document.getElementById(id);
    if(node == null)
    {
        return element;
    }
    return node;
}

//
// 根据当前节点来获取父节点
//
function GetParentNode(tree, node)
{
    var div = public_GetParentByTagName(node, "DIV");
    var table = div.previousSibling;
    if(table == null)
    {
        return null;
    }
    return GetNodeInElement(tree,table);
}

//获取元素指定tagName的父元素
function public_GetParentByTagName(element, tagName) {
    var parent = element.parentNode;
    var upperTagName = tagName.toUpperCase();
    //如果这个元素还不是想要的tag就继续上溯
    while (parent && (parent.tagName.toUpperCase() != upperTagName)) {
        parent = parent.parentNode ? parent.parentNode : parent.parentElement;
    }
    return parent;
}
//
// 根据当前节点来获取子节点
//
function GetChildNodes(tree,node)
{ 
    // 检测当前节点是否为子节点
    if(NodeIsLeaf(node))
    {
        return null;
    }
    var children = new Array();
    var div = GetChildNodesDiv(node);
    var index = 0;
    for(var i = 0; i < div.childNodes.length; i++)
    { 
        var element = div.childNodes[i];
        if(element.tagName != "TABLE")
        {
            continue;
        }
        var child = GetNodeInElement(tree,element);
        if(child != null)
        {
            children[index++] = child;
        }
    }
    return children;
} 

//
// 检测当前节点是否为子节点
//
function NodeIsLeaf(node)
{
    return !(node.tagName == "A");
}

//
// 检测当前节点是否选中
//
function NodeGetChecked(node)
{ 
    var checkbox = NodeGetCheckBox(node);
    return checkbox.checked;
}

//
// 判断：只要该节点有一个字节点被选中，则该节点一定被选中
//
function NodeSetChecked(tree,node,isChecked)
{ 
    var checkbox = NodeGetCheckBox(node);
    if(checkbox != null)
    {
        var childNodes = GetChildNodes(tree,node);
        for(var i = 0; i < childNodes.length; i++)
        {
            var item = childNodes[i];
            var value = NodeGetChecked(item);
            if(value)
            {
                isChecked = true;
                break;
            }
        }
        checkbox.checked = isChecked;
    }
}

//
// 判断是为CheckBox
//
function IsCheckBox(element)
{ 
    if(element == null)
    {
        return false;
    }
    if(element.tagName == "INPUT" && element.type.toLowerCase() == "checkbox")
    {
        return true;
    }
    return false;
} 

//
// 获取树的ID
//
function GetTreeById(id)
{ 
    return document.getElementById(id);
} 

//
// 根据当前节点来获取子节点ID
//
function GetChildNodesDiv(node)
{ 
    if(NodeIsLeaf(node))
    { 
        return null;
    }
    var childNodsDivId = node.id + "Nodes";
    return document.getElementById(childNodsDivId);
}

//
// 获取节点
//
function GetNodeInElement(tree,element)
{
    var node = GetNodeInElementA(tree,element);
    if(node == null) 
    {
        node = GetNodeInElementInput(tree,element);
    }
    return node;
} 

//
// 查找A的节点
//
function GetNodeInElementA(tree,element)
{
    var as = WebForm_GetElementsByTagName(element,"A");
    if(as== null || as.length == 0)
    {
        return null;
    }
    var regexp = new RegExp("^" + tree.id + "n\\d+$");
    for(var i = 0; i < as.length; i++)
    {
        if(as[i].id.match(regexp))
        {
            return as[i];
        }
    }
    return null;
}

//
// 查找 "INPUT" 的节点
//
function GetNodeInElementInput(tree,element)
{
    var as = WebForm_GetElementsByTagName(element, "INPUT");
    if(as== null || as.length == 0)
    {
        return null;
    }
    var regexp = new RegExp("^" + tree.id + "n\\d+");
    for(var i = 0; i < as.length; i++)
    {
        if(as[i].id.match(regexp))
        {
            return as[i];
        }
    }
    return null;
}

//
// 获取有CheckBox的节点
//
function NodeGetCheckBox(node)
{ 
    if(IsCheckBox(node))
    {
        return node;
    }
    var id = node.id + "CheckBox";
    return document.getElementById(id);
}


