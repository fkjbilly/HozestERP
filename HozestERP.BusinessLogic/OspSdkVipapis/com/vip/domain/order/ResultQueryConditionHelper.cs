using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.domain.order{
	
	
	
	public class ResultQueryConditionHelper : TBeanSerializer<ResultQueryCondition>
	{
		
		public static ResultQueryConditionHelper OBJ = new ResultQueryConditionHelper();
		
		public static ResultQueryConditionHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(ResultQueryCondition structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("max_id".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetMax_id(value);
					}
					
					
					
					
					
					if ("count".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetCount(value);
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
		
		
		public void Write(ResultQueryCondition structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetMax_id() != null) {
				
				oprot.WriteFieldBegin("max_id");
				oprot.WriteI32((int)structs.GetMax_id()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetCount() != null) {
				
				oprot.WriteFieldBegin("count");
				oprot.WriteI32((int)structs.GetCount()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(ResultQueryCondition bean){
			
			
		}
		
	}
	
}