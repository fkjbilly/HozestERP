using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.order.common.pojo.order.vo{
	
	
	
	public class OpStatusVOHelper : TBeanSerializer<OpStatusVO>
	{
		
		public static OpStatusVOHelper OBJ = new OpStatusVOHelper();
		
		public static OpStatusVOHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(OpStatusVO structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("op".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetOp(value);
					}
					
					
					
					
					
					if ("opFlag".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetOpFlag(value);
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
		
		
		public void Write(OpStatusVO structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetOp() != null) {
				
				oprot.WriteFieldBegin("op");
				oprot.WriteString(structs.GetOp());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOpFlag() != null) {
				
				oprot.WriteFieldBegin("opFlag");
				oprot.WriteI32((int)structs.GetOpFlag()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(OpStatusVO bean){
			
			
		}
		
	}
	
}