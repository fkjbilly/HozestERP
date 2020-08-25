using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.order.common.pojo.order.vo{
	
	
	
	public class TransportOperateLogVOHelper : TBeanSerializer<TransportOperateLogVO>
	{
		
		public static TransportOperateLogVOHelper OBJ = new TransportOperateLogVOHelper();
		
		public static TransportOperateLogVOHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(TransportOperateLogVO structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("operateTime".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetOperateTime(value);
					}
					
					
					
					
					
					if ("user".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetUser(value);
					}
					
					
					
					
					
					if ("remark".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetRemark(value);
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
		
		
		public void Write(TransportOperateLogVO structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetOperateTime() != null) {
				
				oprot.WriteFieldBegin("operateTime");
				oprot.WriteI64((long)structs.GetOperateTime()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetUser() != null) {
				
				oprot.WriteFieldBegin("user");
				oprot.WriteString(structs.GetUser());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetRemark() != null) {
				
				oprot.WriteFieldBegin("remark");
				oprot.WriteString(structs.GetRemark());
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(TransportOperateLogVO bean){
			
			
		}
		
	}
	
}