using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.order.common.pojo.order.vo{
	
	
	
	public class OrderActiveVOHelper : TBeanSerializer<OrderActiveVO>
	{
		
		public static OrderActiveVOHelper OBJ = new OrderActiveVOHelper();
		
		public static OrderActiveVOHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(OrderActiveVO structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("activeField".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetActiveField(value);
					}
					
					
					
					
					
					if ("activeName".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetActiveName(value);
					}
					
					
					
					
					
					if ("activeNo".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetActiveNo(value);
					}
					
					
					
					
					
					if ("activeType".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetActiveType(value);
					}
					
					
					
					
					
					if ("detail".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetDetail(value);
					}
					
					
					
					
					
					if ("isDelete".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetIsDelete(value);
					}
					
					
					
					
					
					if ("addTime".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetAddTime(value);
					}
					
					
					
					
					
					if ("updateTime".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetUpdateTime(value);
					}
					
					
					
					
					
					if ("orderSn".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetOrderSn(value);
					}
					
					
					
					
					
					if ("activeId".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetActiveId(value);
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
		
		
		public void Write(OrderActiveVO structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetActiveField() != null) {
				
				oprot.WriteFieldBegin("activeField");
				oprot.WriteI32((int)structs.GetActiveField()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetActiveName() != null) {
				
				oprot.WriteFieldBegin("activeName");
				oprot.WriteString(structs.GetActiveName());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetActiveNo() != null) {
				
				oprot.WriteFieldBegin("activeNo");
				oprot.WriteString(structs.GetActiveNo());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetActiveType() != null) {
				
				oprot.WriteFieldBegin("activeType");
				oprot.WriteI32((int)structs.GetActiveType()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetDetail() != null) {
				
				oprot.WriteFieldBegin("detail");
				oprot.WriteString(structs.GetDetail());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetIsDelete() != null) {
				
				oprot.WriteFieldBegin("isDelete");
				oprot.WriteI32((int)structs.GetIsDelete()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetAddTime() != null) {
				
				oprot.WriteFieldBegin("addTime");
				oprot.WriteI64((long)structs.GetAddTime()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetUpdateTime() != null) {
				
				oprot.WriteFieldBegin("updateTime");
				oprot.WriteString(structs.GetUpdateTime());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOrderSn() != null) {
				
				oprot.WriteFieldBegin("orderSn");
				oprot.WriteString(structs.GetOrderSn());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetActiveId() != null) {
				
				oprot.WriteFieldBegin("activeId");
				oprot.WriteI64((long)structs.GetActiveId()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(OrderActiveVO bean){
			
			
		}
		
	}
	
}