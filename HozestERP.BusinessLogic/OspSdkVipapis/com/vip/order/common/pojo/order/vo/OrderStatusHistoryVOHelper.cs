using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.order.common.pojo.order.vo{
	
	
	
	public class OrderStatusHistoryVOHelper : TBeanSerializer<OrderStatusHistoryVO>
	{
		
		public static OrderStatusHistoryVOHelper OBJ = new OrderStatusHistoryVOHelper();
		
		public static OrderStatusHistoryVOHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(OrderStatusHistoryVO structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("preOrderStatus".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetPreOrderStatus(value);
					}
					
					
					
					
					
					if ("preOrderStatusUpdateTime".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetPreOrderStatusUpdateTime(value);
					}
					
					
					
					
					
					if ("orderScenario".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetOrderScenario(value);
					}
					
					
					
					
					
					if ("orderStatus".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetOrderStatus(value);
					}
					
					
					
					
					
					if ("orderStatusUpdateTime".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetOrderStatusUpdateTime(value);
					}
					
					
					
					
					
					if ("remark".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetRemark(value);
					}
					
					
					
					
					
					if ("seq".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetSeq(value);
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
		
		
		public void Write(OrderStatusHistoryVO structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetPreOrderStatus() != null) {
				
				oprot.WriteFieldBegin("preOrderStatus");
				oprot.WriteI32((int)structs.GetPreOrderStatus()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetPreOrderStatusUpdateTime() != null) {
				
				oprot.WriteFieldBegin("preOrderStatusUpdateTime");
				oprot.WriteI64((long)structs.GetPreOrderStatusUpdateTime()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOrderScenario() != null) {
				
				oprot.WriteFieldBegin("orderScenario");
				oprot.WriteI32((int)structs.GetOrderScenario()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOrderStatus() != null) {
				
				oprot.WriteFieldBegin("orderStatus");
				oprot.WriteI32((int)structs.GetOrderStatus()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOrderStatusUpdateTime() != null) {
				
				oprot.WriteFieldBegin("orderStatusUpdateTime");
				oprot.WriteI64((long)structs.GetOrderStatusUpdateTime()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetRemark() != null) {
				
				oprot.WriteFieldBegin("remark");
				oprot.WriteString(structs.GetRemark());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetSeq() != null) {
				
				oprot.WriteFieldBegin("seq");
				oprot.WriteI32((int)structs.GetSeq()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(OrderStatusHistoryVO bean){
			
			
		}
		
	}
	
}