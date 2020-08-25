using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.domain.inventory{
	
	
	
	public class OpPoResponseHelper : TBeanSerializer<OpPoResponse>
	{
		
		public static OpPoResponseHelper OBJ = new OpPoResponseHelper();
		
		public static OpPoResponseHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(OpPoResponse structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("opResult".Equals(schemeField.Trim())){
						
						needSkip = false;
						com.vip.domain.inventory.PoResult? value;
						
						value = com.vip.domain.inventory.PoResultUtil.FindByName(iprot.ReadString());
						
						structs.SetOpResult(value);
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
		
		
		public void Write(OpPoResponse structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetOpResult() != null) {
				
				oprot.WriteFieldBegin("opResult");
				oprot.WriteString(structs.GetOpResult().ToString());  
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("opResult can not be null!");
			}
			
			
			if(structs.GetRemark() != null) {
				
				oprot.WriteFieldBegin("remark");
				oprot.WriteString(structs.GetRemark());
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(OpPoResponse bean){
			
			
		}
		
	}
	
}