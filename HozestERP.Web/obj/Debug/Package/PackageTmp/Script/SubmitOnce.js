//输出Loading的层
document.write('<STYLE type="text/css">.btu { BORDER-RIGHT: #999999 1px solid; PADDING-RIGHT: 3px; BORDER-TOP: #ffffff 1px solid; PADDING-LEFT: 1px; FLOAT: none; PADDING-BOTTOM: 1px; BORDER-LEFT: #ffffff 1px solid; CURSOR: default; COLOR: #eeeeee; PADDING-TOP: 1px; BORDER-BOTTOM: #999999 1px solid; BACKGROUND-COLOR: }</STYLE>');
document.write("<div id=stdiv style='position:absolute; width:50%; height:50%; z-index:900; left:20%; top:30%; visibility:hidden;'><table  width='100%' height='100'><tr><TD align=center class=btu style=\"FONT-SIZE:12px;TEXT-DECORATION:none\"></TD></tr></table></div>");
document.write("<div id=stdiv2 style='position:absolute; width:100%; height:100%; z-index:100; left:0px; top:0px; visibility:;'><table  width='100%' height='100%'><tr><TD align=center bgcolor=ffffff style=\"FONT-SIZE:12px;TEXT-DECORATION:none\">Load...</TD></tr></table></div>");
function submitonce(theform)
{
    //if IE 4+ or NS 6+
    if (document.all||document.getElementById){
        //screen thru every element in the form, and hunt down "submit" and "reset"
        for (i=0;i<theform.length;i++){
            var tempobj=theform.elements[i]
            if(tempobj.type.toLowerCase()=="submit"||tempobj.type.toLowerCase()=="reset")
            //disable em
            tempobj.disabled=true
        }
    }
	stdiv.style.visibility = "visible";
	cal_hideElementAll(stdiv);
}

function moveit()	//这个函数用于把层放到浏览器中间
{
	stdiv.style.left=((document.body.offsetWidth-parseFloat (stdiv.style.width))/2)+document.body.scrollLeft;
	
	//stdiv.style.top=((document.body.offsetHeight-parseFloat (stdiv.style.height))/2)+document.body.scrollTop;
}document.all("stdiv").style.visibility="";
//window.onload=moveit;	//网面打开时时执行moveit()
window.onresize=moveit;	//当调整浏览器大小时执行moveit()
window.onscroll=moveit;	//当拉动滚动条时执行moveit()

function change1(opacity){
	opacity-=25;
	if(opacity>-20){
	document.all("stdiv").style.filter = "alpha(opacity=" + opacity + ")";
	document.all("stdiv2").style.filter = "alpha(opacity=" +opacity+ ")";
	setTimeout("change1("+opacity+")",100);}
	else{
	document.all("stdiv").style.visibility="hidden";
	document.all("stdiv2").style.visibility="hidden";
	}
}

//========隐藏Select框========//
var HideElementTemp = new Array();
//点击菜单时，调用此的函数,菜单对象
function cal_hideElementAll(obj){ 
	cal_HideElement("IMG",obj);
	cal_HideElement("SELECT",obj);
	cal_HideElement("OBJECT",obj);
	cal_HideElement("IFRAME",obj);
}
function cal_HideElement(strElementTagName,obj){
try{
    var showDivElement = obj;
    var calendarDiv = obj;
    var intDivLeft = cal_GetOffsetLeft(showDivElement);
    var intDivTop = cal_GetOffsetTop(showDivElement);//+showDivElement.offsetHeight;
    //HideElementTemp=new Array()
    for(i=0;i<window.document.all.tags(strElementTagName).length; i++){
	var objTemp = window.document.all.tags(strElementTagName)[i];
 if(!objTemp||!objTemp.offsetParent)
     continue;
	 var intObjLeft=cal_GetOffsetLeft(objTemp);
	 var intObjTop=cal_GetOffsetTop(objTemp);
 if(((intObjLeft+objTemp.clientWidth)>intDivLeft)&&
    (intObjLeft<intDivLeft+calendarDiv.style.posWidth)&&
    (intObjTop+objTemp.clientHeight>intDivTop)&&
    (intObjTop<intDivTop+calendarDiv.style.posHeight)){
     //var intTempIndex=HideElementTemp.length;//已经有的长度
	 //save elementTagName is stutas
     //HideElementTemp[intTempIndex]=new Array(objTemp,objTemp.style.visibility);
     HideElementTemp[HideElementTemp.length]=objTemp
     objTemp.style.visibility="hidden";
        }
    }
}catch(e){alert(e.message)
}
}

function cal_ShowElement(){
    var i;
    for(i=0;i<HideElementTemp.length; i++){
	var objTemp = HideElementTemp[i]
 if(!objTemp||!objTemp.offsetParent)
     continue;
 objTemp.style.visibility=''
    }
    HideElementTemp=new Array();
}
function cal_GetOffsetLeft(src){
    var set=0;
    if(src && src.name!="divMain"){
        if (src.offsetParent){
           set+=src.offsetLeft+cal_GetOffsetLeft(src.offsetParent);
 }
 if(src.tagName.toUpperCase()!="BODY"){
     var x=parseInt(src.scrollLeft,10);
     if(!isNaN(x))
            set-=x;
 }
    }
    return set;
}

function cal_GetOffsetTop(src){
    var set=0;
    if(src && src.name!="divMain"){
        if (src.offsetParent){
            set+=src.offsetTop+cal_GetOffsetTop(src.offsetParent);
   }
 if(src.tagName.toUpperCase()!="BODY"){
     var y=parseInt(src.scrollTop,10);
     if(!isNaN(y))
  set-=y;
 }
    }
    return set;
}

<!--
window.onload = function() {
document.onkeydown = function(){
if(event.ctrlKey&&event.keyCode==13)
{
document.forms[0].submit();
}
}
}
//-->
