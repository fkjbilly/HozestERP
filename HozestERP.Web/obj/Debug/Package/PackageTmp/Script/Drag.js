var Obj=''
var index=10000;//z-index;
document.onmouseup=MUp
document.onmousemove=MMove

function MDown(Object)
{
    Obj=Object.id
    document.all(Obj).setCapture()
    pX=event.x-document.all(Obj).style.pixelLeft;
    pY=event.y-document.all(Obj).style.pixelTop;
}

function MMove()
{
    if(Obj!='')
    {
         //var objwidth = document.all(Obj).style.width;
         document.all(Obj).style.left=event.x-pX;
         //document.all(Obj).style.width = objwidth;
         document.all(Obj).style.top=event.y-pY;
     }
}

function MUp()
{
    if(Obj!='')
    {
         document.all(Obj).releaseCapture();
         Obj='';
     }
}
//-- 控制层移动end of script -->
//获得焦点;
function getFocus(obj)
{
    if(obj.style.zIndex!=index)
    {
        index = index + 2;
        var idx = index;
        obj.style.zIndex=idx;
        //obj.nextSibling.style.zIndex=idx-1;
    }
}

function ssdel()
{
    if (event)
    {
        lObj = event.srcElement ;

        while (lObj && lObj.tagName != "DIV") 
        lObj = lObj.parentElement ;
    }
    var id=lObj.id
    if(lObj.title != "")
    {
        clearInterval(lObj.title);
    }
     document.getElementById(id).removeNode(true);
}