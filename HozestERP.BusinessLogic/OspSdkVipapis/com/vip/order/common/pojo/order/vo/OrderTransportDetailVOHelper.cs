using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.order.common.pojo.order.vo{
	
	
	
	public class OrderTransportDetailVOHelper : TBeanSerializer<OrderTransportDetailVO>
	{
		
		public static OrderTransportDetailVOHelper OBJ = new OrderTransportDetailVOHelper();
		
		public static OrderTransportDetailVOHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(OrderTransportDetailVO structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("transportId".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetTransportId(value);
					}
					
					
					
					
					
					if ("transportNo".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetTransportNo(value);
					}
					
					
					
					
					
					if ("transportCode".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetTransportCode(value);
					}
					
					
					
					
					
					if ("transportDetail".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetTransportDetail(value);
					}
					
					
					
					
					
					if ("carriersCode".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetCarriersCode(value);
					}
					
					
					
					
					
					if ("carriersShortName".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetCarriersShortName(value);
					}
					
					
					
					
					
					if ("carriersName".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetCarriersName(value);
					}
					
					
					
					
					
					if ("carriersType".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetCarriersType(value);
					}
					
					
					
					
					
					if ("warehouse".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetWarehouse(value);
					}
					
					
					
					
					
					if ("payType".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetPayType(value);
					}
					
					
					
					
					
					if ("extPayTypeCode".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetExtPayTypeCode(value);
					}
					
					
					
					
					
					if ("extPayType".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetExtPayType(value);
					}
					
					
					
					
					
					if ("orderSn".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetOrderSn(value);
					}
					
					
					
					
					
					if ("time".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetTime(value);
					}
					
					
					
					
					
					if ("backSn".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetBackSn(value);
					}
					
					
					
					
					
					if ("id".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetId(value);
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
		
		
		public void Write(OrderTransportDetailVO structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetTransportId() != null) {
				
				oprot.WriteFieldBegin("transportId");
				oprot.WriteI32((int)structs.GetTransportId()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetTransportNo() != null) {
				
				oprot.WriteFieldBegin("transportNo");
				oprot.WriteString(structs.GetTransportNo());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetTransportCode() != null) {
				
				oprot.WriteFieldBegin("transportCode");
				oprot.WriteString(structs.GetTransportCode());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetTransportDetail() != null) {
				
				oprot.WriteFieldBegin("transportDetail");
				oprot.WriteString(structs.GetTransportDetail());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetCarriersCode() != null) {
				
				oprot.WriteFieldBegin("carriersCode");
				oprot.WriteString(structs.GetCarriersCode());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetCarriersShortName() != null) {
				
				oprot.WriteFieldBegin("carriersShortName");
				oprot.WriteString(structs.GetCarriersShortName());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetCarriersName() != null) {
				
				oprot.WriteFieldBegin("carriersName");
				oprot.WriteString(structs.GetCarriersName());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetCarriersType() != null) {
				
				oprot.WriteFieldBegin("carriersType");
				oprot.WriteString(structs.GetCarriersType());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetWarehouse() != null) {
				
				oprot.WriteFieldBegin("warehouse");
				oprot.WriteString(structs.GetWarehouse());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetPayType() != null) {
				
				oprot.WriteFieldBegin("payType");
				oprot.WriteI32((int)structs.GetPayType()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetExtPayTypeCode() != null) {
				
				oprot.WriteFieldBegin("extPayTypeCode");
				oprot.WriteString(structs.GetExtPayTypeCode());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetExtPayType() != null) {
				
				oprot.WriteFieldBegin("extPayType");
				oprot.WriteI32((int)structs.GetExtPayType()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOrderSn() != null) {
				
				oprot.WriteFieldBegin("orderSn");
				oprot.WriteString(structs.GetOrderSn());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetTime() != null) {
				
				oprot.WriteFieldBegin("time");
				oprot.WriteI64((long)structs.GetTime()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetBackSn() != null) {
				
				oprot.WriteFieldBegin("backSn");
				oprot.WriteString(structs.GetBackSn());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetId() != null) {
				
				oprot.WriteFieldBegin("id");
				oprot.WriteI64((long)structs.GetId()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(OrderTransportDetailVO bean){
			
			
		}
		
	}
	
}