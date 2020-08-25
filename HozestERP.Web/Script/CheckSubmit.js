<script>
		var __hassubmit = 0;
		var __srconsubmit = document.forms[0].onsubmit;
		
		function __doPostBackDef(eventTarget, eventArgument) 
		{
			if(__hassubmit == 1)
			{
				window.alert("页面正在提交中...");
				return false;
			}
			__hassubmit= 1;
			try
			{
				return __srconsubmit(eventTarget, eventArgument);	
			}catch(ex){}
		}		
		
		try
		{
			document.forms[0].onsubmit=__doPostBackDef;
		}catch(ex){}
</script>