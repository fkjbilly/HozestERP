using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.vop.vcloud.order{
	
	
	
	public class OrderSequenceHelper : TBeanSerializer<OrderSequence>
	{
		
		public static OrderSequenceHelper OBJ = new OrderSequenceHelper();
		
		public static OrderSequenceHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(OrderSequence structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("nextId".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetNextId(value);
					}
					
					
					
					
					
					if ("name".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetName(value);
					}
					
					
					
					
					
					if ("lastUpdateTime".Equals(schemeField.Trim())){
						
						needSkip = false;
						System.DateTime? value;
						value = Osp.Sdk.Util.TimeUtil.FromUnixTime(iprot.ReadI64()); 
						
						structs.SetLastUpdateTime(value);
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
		
		
		public void Write(OrderSequence structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetNextId() != null) {
				
				oprot.WriteFieldBegin("nextId");
				oprot.WriteI32((int)structs.GetNextId()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetName() != null) {
				
				oprot.WriteFieldBegin("name");
				oprot.WriteString(structs.GetName());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetLastUpdateTime() != null) {
				
				oprot.WriteFieldBegin("lastUpdateTime");
				oprot.WriteI64(Osp.Sdk.Util.TimeUtil.ToUnixTime((System.DateTime)structs.GetLastUpdateTime())); 
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(OrderSequence bean){
			
			
		}
		
	}
	
}