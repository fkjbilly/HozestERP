using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.domain.order{
	
	
	
	public class OrderTrackQueryConditionHelper : TBeanSerializer<OrderTrackQueryCondition>
	{
		
		public static OrderTrackQueryConditionHelper OBJ = new OrderTrackQueryConditionHelper();
		
		public static OrderTrackQueryConditionHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(OrderTrackQueryCondition structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("erp_order_sn".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetErp_order_sn(value);
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
		
		
		public void Write(OrderTrackQueryCondition structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetErp_order_sn() != null) {
				
				oprot.WriteFieldBegin("erp_order_sn");
				oprot.WriteString(structs.GetErp_order_sn());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("erp_order_sn can not be null!");
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(OrderTrackQueryCondition bean){
			
			
		}
		
	}
	
}