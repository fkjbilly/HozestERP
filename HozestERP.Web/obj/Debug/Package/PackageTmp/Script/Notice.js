// JScript 文件

// JScript 文件
//关闭通知（层的关闭）

var CurrentTop = 0;
var Halder = new Array();
var Divs = new Array();
var ThemeLocation = '';
var NoticeTimeSpan = 60000;

function CloseNotice(paramDivID)
{
    var Notice = document.getElementById(paramDivID);
    //Notice = null;
   document.body.removeChild(Notice);
}

function SetgetNotice()
{
     var halder1 = window.setInterval("getNotice();",NoticeTimeSpan);
     getNotice();
}

function getNotice()
{
    //ClearAllInterval();
    ClearNotices();
    
    var myDataSet = LindonSoft.WGERP.UILayer._Default.getNotice();
    CurrentTop = document.body.clientHeight;
    if(myDataSet.value != null)
    {
        var myDataTable = myDataSet.value.Tables[0];
        if(myDataTable == undefined)
        {
            return;
        }
        for(var i=0;i<myDataTable.Rows.length;i++)
        {
            var Title = myDataTable.Rows[i].Title;
            var Content = myDataTable.Rows[i].Content;
            var ID = myDataTable.Rows[i].ID;
            var Creater = myDataTable.Rows[i].TrueName;
                       
            CreateNotice(myDataTable.Rows.length - i , "Notice" + i, Title, Content,ID, Creater);
        }
    }
    //CreateNotice(2, "Notice1", "服务器重启","服务器将在5分钟后重启", "张三");
}

function CreateNotice(paramIndex,paramDivId, paramTitle, paramContent, paramID, paramCreater)
{
    var leftPix = document.body.clientWidth - 255;
    var topPix = document.body.clientHeight;
    var DivHTML = " <DIV class=\"Cccc\" onmousedown=\"getFocus(this)\" id=\"" + paramDivId + "\""
                + " style=\"Z-INDEX: " + paramIndex + "; LEFT: " + leftPix + "px; POSITION: absolute; TOP: " + topPix + "px; BACKGROUND-COLOR: white; border-right: #ababab thin solid; border-top: #ababab thin solid; border-left: #ababab thin solid;filter:progid:DXImageTransform.Microsoft.Shadow(Strength=6, Direction=135, color=#999999);; width: 250px; border-bottom: #ababab thin solid;\"> "
                + " <TABLE border=0  cellpadding=\"0\" cellspacing=\"0\" > "
                + " <TBODY> "
                + " <tr style=\"height: 32px;background-image: url("+ThemeLocation+"Image/Notice/NoticeTop.gif)\"> "
                + " <td onmousedown=\"MDown(" + paramDivId + ")\" style=\"CURSOR: move;height: 20px;background-color: #e2e5e6;\" width=\"100%\"> &nbsp;"
                + paramTitle
                + " </td> "
                + " <td style=\"CURSOR: hand\" onclick=\"ssdel()\" align=\"left\" width=\"40px\"><img src=\""+ThemeLocation+"Image/Notice/NoticeClose.gif\"  width=\"11px\" />&nbsp;&nbsp;</td> "
                + " </tr> "
                + " <tr> "
                + " <td style=\"PADDING-RIGHT: 5px; PADDING-LEFT: 5px; PADDING-BOTTOM: 5px; PADDING-TOP: 5px; HEIGHT: 100px;\" colSpan=2> "
                + paramContent
                + " <DIV style=\"PADDING-RIGHT: 5px; PADDING-LEFT: 5px; FLOAT: right; PADDING-BOTTOM: 5px; PADDING-TOP: 5px\"> "
                + " </DIV> "
                + " </td> "
                + " </tr> "
                 + " <tr> "
                + " <td style=\"PADDING-RIGHT: 5px; PADDING-LEFT: 5px; PADDING-BOTTOM: 5px; PADDING-TOP: 5px; HEIGHT: 25px;text-align: right;background-image: url("+ThemeLocation+"Image/Notice/NoticeFoot.gif);\" colSpan=2> "
               + paramCreater
                + " </td> "
                + " </tr> "
                + " </TBODY> "
                + " </TABLE> "
                + " </DIV> "
    var Notice=document.createElement("DIV");
    Notice.innerHTML = DivHTML;
    
    document.body.appendChild(Notice);
    Divs.push(paramDivId);
    SetMove(paramDivId);
}

function SetMove(Notice)
{
    CurrentTop = CurrentTop - document.getElementById(Notice).clientHeight - 8;
    halder = window.setInterval("MoveDiv('" + Notice + "'," + CurrentTop + ");",25);
    document.getElementById(Notice).title = halder;
    Halder.push(halder);
}

function MoveDiv(Notice,top)
{
    var Notice = document.getElementById(Notice);
     if(Notice != undefined)
     {
        if(Notice.style.pixelTop > top)
        {
             Notice.style.pixelTop =  Notice.style.pixelTop - 1;
        }
        else
        {
            clearInterval(Notice.title);
            Notice.title= "";
        }
    }
}

function ClearAllInterval()
{
    for(i =0; i< Halder.length; i++)
    {
         try
         {
            clearInterval(Halder[i]);
         }
         catch(e)
         {
         }
    }
}

function ClearNotices()
{
    for(i =0; i< Divs.length; i++)
    {
         try
         {
            document.getElementById(Divs[i]).removeNode(true);
         }
         catch(e)
         {
         }
    }
}