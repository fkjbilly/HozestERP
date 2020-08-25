using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.order.common.pojo.order.vo{
	
	
	
	public class PrepayOrderStatusVOHelper : TBeanSerializer<PrepayOrderStatusVO>
	{
		
		public static PrepayOrderStatusVOHelper OBJ = new PrepayOrderStatusVOHelper();
		
		public static PrepayOrderStatusVOHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(PrepayOrderStatusVO structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("statusCode".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetStatusCode(value);
					}
					
					
					
					
					
					if ("statusName".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetStatusName(value);
					}
					
					
					
					
					if(needSkip){
						
						ProtocolUtil.skip(iprot);
					}
					
					iprot.ReadFieldEnd();
				}
				
				iprot.ReadStructEnd();
				Validate(structs);
			}
			else{
				
				throw new OspException();
			}
			
			
		}
		
		
		public void Write(PrepayOrderStatusVO structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetStatusCode() != null) {
				
				oprot.WriteFieldBegin("statusCode");
				oprot.WriteI32((int)structs.GetStatusCode()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetStatusName() != null) {
				
				oprot.WriteFieldBegin("statusName");
				oprot.WriteString(structs.GetStatusName());
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(PrepayOrderStatusVO bean){
			
			
		}
		
	}
	
}