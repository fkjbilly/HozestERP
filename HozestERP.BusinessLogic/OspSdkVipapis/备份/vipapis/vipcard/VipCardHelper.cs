using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.vipcard{
	
	
	
	public class VipCardHelper : BeanSerializer<VipCard>
	{
		
		public static VipCardHelper OBJ = new VipCardHelper();
		
		public static VipCardHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(VipCard structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("card_code".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetCard_code(value);
					}
					
					
					
					
					
					if ("money".Equals(schemeField.Trim())){
						
						needSkip = false;
						double value;
						value = iprot.ReadDouble();
						
						structs.SetMoney(value);
					}
					
					
					
					
					
					if ("state".Equals(schemeField.Trim())){
						
						needSkip = false;
						int value;
						value = iprot.ReadI32(); 
						
						structs.SetState(value);
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
		
		
		public void Write(VipCard structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetCard_code() != null) {
				
				oprot.WriteFieldBegin("card_code");
				oprot.WriteString(structs.GetCard_code());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("card_code can not be null!");
			}
			
			
			if(structs.GetMoney() != null) {
				
				oprot.WriteFieldBegin("money");
				oprot.WriteDouble((double)structs.GetMoney());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("money can not be null!");
			}
			
			
			if(structs.GetState() != null) {
				
				oprot.WriteFieldBegin("state");
				oprot.WriteI32((int)structs.GetState()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("state can not be null!");
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(VipCard bean){
			
			
		}
		
	}
	
}