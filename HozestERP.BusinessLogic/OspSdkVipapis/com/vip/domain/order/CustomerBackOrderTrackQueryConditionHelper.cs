using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.domain.order{
	
	
	
	public class CustomerBackOrderTrackQueryConditionHelper : TBeanSerializer<CustomerBackOrderTrackQueryCondition>
	{
		
		public static CustomerBackOrderTrackQueryConditionHelper OBJ = new CustomerBackOrderTrackQueryConditionHelper();
		
		public static CustomerBackOrderTrackQueryConditionHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(CustomerBackOrderTrackQueryCondition structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("erp_back_sn".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetErp_back_sn(value);
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
		
		
		public void Write(CustomerBackOrderTrackQueryCondition structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetErp_back_sn() != null) {
				
				oprot.WriteFieldBegin("erp_back_sn");
				oprot.WriteString(structs.GetErp_back_sn());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("erp_back_sn can not be null!");
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(CustomerBackOrderTrackQueryCondition bean){
			
			
		}
		
	}
	
}