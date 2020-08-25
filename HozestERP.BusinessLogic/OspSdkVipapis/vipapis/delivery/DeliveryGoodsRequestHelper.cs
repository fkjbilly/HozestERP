using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.delivery{
	
	
	
	public class DeliveryGoodsRequestHelper : TBeanSerializer<DeliveryGoodsRequest>
	{
		
		public static DeliveryGoodsRequestHelper OBJ = new DeliveryGoodsRequestHelper();
		
		public static DeliveryGoodsRequestHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(DeliveryGoodsRequest structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("vendor_id".Equals(schemeField.Trim())){
						
						needSkip = false;
						int value;
						value = iprot.ReadI32(); 
						
						structs.SetVendor_id(value);
					}
					
					
					
					
					
					if ("po_no".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetPo_no(value);
					}
					
					
					
					
					
					if ("delivery_no".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetDelivery_no(value);
					}
					
					
					
					
					
					if ("warehouse".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetWarehouse(value);
					}
					
					
					
					
					
					if ("arrival_time".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetArrival_time(value);
					}
					
					
					
					
					
					if ("carrier_code".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetCarrier_code(value);
					}
					
					
					
					
					
					if ("carrier_name".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetCarrier_name(value);
					}
					
					
					
					
					
					if ("delivery_method".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetDelivery_method(value);
					}
					
					
					
					
					
					if ("delivery_time".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetDelivery_time(value);
					}
					
					
					
					
					
					if ("store_sn".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetStore_sn(value);
					}
					
					
					
					
					
					if ("jit_type".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetJit_type(value);
					}
					
					
					
					
					
					if ("delivery_list".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<vipapis.delivery.DeliveryGoods> value;
						
						value = new List<vipapis.delivery.DeliveryGoods>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								vipapis.delivery.DeliveryGoods elem0;
								
								elem0 = new vipapis.delivery.DeliveryGoods();
								vipapis.delivery.DeliveryGoodsHelper.getInstance().Read(elem0, iprot);
								
								value.Add(elem0);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetDelivery_list(value);
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
		
		
		public void Write(DeliveryGoodsRequest structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetVendor_id() != null) {
				
				oprot.WriteFieldBegin("vendor_id");
				oprot.WriteI32((int)structs.GetVendor_id()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("vendor_id can not be null!");
			}
			
			
			if(structs.GetPo_no() != null) {
				
				oprot.WriteFieldBegin("po_no");
				oprot.WriteString(structs.GetPo_no());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("po_no can not be null!");
			}
			
			
			if(structs.GetDelivery_no() != null) {
				
				oprot.WriteFieldBegin("delivery_no");
				oprot.WriteString(structs.GetDelivery_no());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("delivery_no can not be null!");
			}
			
			
			if(structs.GetWarehouse() != null) {
				
				oprot.WriteFieldBegin("warehouse");
				oprot.WriteString(structs.GetWarehouse());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("warehouse can not be null!");
			}
			
			
			if(structs.GetArrival_time() != null) {
				
				oprot.WriteFieldBegin("arrival_time");
				oprot.WriteString(structs.GetArrival_time());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("arrival_time can not be null!");
			}
			
			
			if(structs.GetCarrier_code() != null) {
				
				oprot.WriteFieldBegin("carrier_code");
				oprot.WriteString(structs.GetCarrier_code());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("carrier_code can not be null!");
			}
			
			
			if(structs.GetCarrier_name() != null) {
				
				oprot.WriteFieldBegin("carrier_name");
				oprot.WriteString(structs.GetCarrier_name());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("carrier_name can not be null!");
			}
			
			
			if(structs.GetDelivery_method() != null) {
				
				oprot.WriteFieldBegin("delivery_method");
				oprot.WriteString(structs.GetDelivery_method());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("delivery_method can not be null!");
			}
			
			
			if(structs.GetDelivery_time() != null) {
				
				oprot.WriteFieldBegin("delivery_time");
				oprot.WriteString(structs.GetDelivery_time());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("delivery_time can not be null!");
			}
			
			
			if(structs.GetStore_sn() != null) {
				
				oprot.WriteFieldBegin("store_sn");
				oprot.WriteString(structs.GetStore_sn());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetJit_type() != null) {
				
				oprot.WriteFieldBegin("jit_type");
				oprot.WriteI32((int)structs.GetJit_type()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetDelivery_list() != null) {
				
				oprot.WriteFieldBegin("delivery_list");
				
				oprot.WriteListBegin();
				foreach(vipapis.delivery.DeliveryGoods _item0 in structs.GetDelivery_list()){
					
					
					vipapis.delivery.DeliveryGoodsHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("delivery_list can not be null!");
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(DeliveryGoodsRequest bean){
			
			
		}
		
	}
	
}