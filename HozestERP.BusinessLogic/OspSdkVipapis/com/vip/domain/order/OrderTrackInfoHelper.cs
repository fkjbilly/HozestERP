using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.domain.order{
	
	
	
	public class OrderTrackInfoHelper : TBeanSerializer<OrderTrackInfo>
	{
		
		public static OrderTrackInfoHelper OBJ = new OrderTrackInfoHelper();
		
		public static OrderTrackInfoHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(OrderTrackInfo structs, Protocol iprot){
			
			
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
					
					
					
					
					
					if ("transport_code".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetTransport_code(value);
					}
					
					
					
					
					
					if ("transport_detail".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetTransport_detail(value);
					}
					
					
					
					
					
					if ("action_time".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetAction_time(value);
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
		
		
		public void Write(OrderTrackInfo structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetErp_order_sn() != null) {
				
				oprot.WriteFieldBegin("erp_order_sn");
				oprot.WriteString(structs.GetErp_order_sn());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetTransport_code() != null) {
				
				oprot.WriteFieldBegin("transport_code");
				oprot.WriteString(structs.GetTransport_code());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetTransport_detail() != null) {
				
				oprot.WriteFieldBegin("transport_detail");
				oprot.WriteString(structs.GetTransport_detail());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetAction_time() != null) {
				
				oprot.WriteFieldBegin("action_time");
				oprot.WriteString(structs.GetAction_time());
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(OrderTrackInfo bean){
			
			
		}
		
	}
	
}