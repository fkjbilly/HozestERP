using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.order{
	
	
	
	public class OmniCancelledOrderHelper : TBeanSerializer<OmniCancelledOrder>
	{
		
		public static OmniCancelledOrderHelper OBJ = new OmniCancelledOrderHelper();
		
		public static OmniCancelledOrderHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(OmniCancelledOrder structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("order_id".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetOrder_id(value);
					}
					
					
					
					
					
					if ("province".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetProvince(value);
					}
					
					
					
					
					
					if ("city".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetCity(value);
					}
					
					
					
					
					
					if ("district".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetDistrict(value);
					}
					
					
					
					
					
					if ("order_skus".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<vipapis.order.OrderSku> value;
						
						value = new List<vipapis.order.OrderSku>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								vipapis.order.OrderSku elem1;
								
								elem1 = new vipapis.order.OrderSku();
								vipapis.order.OrderSkuHelper.getInstance().Read(elem1, iprot);
								
								value.Add(elem1);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetOrder_skus(value);
					}
					
					
					
					
					
					if ("order_type".Equals(schemeField.Trim())){
						
						needSkip = false;
						byte? value;
						value = iprot.ReadByte(); 
						
						structs.SetOrder_type(value);
					}
					
					
					
					
					
					if ("province_code".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetProvince_code(value);
					}
					
					
					
					
					
					if ("city_code".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetCity_code(value);
					}
					
					
					
					
					
					if ("district_code".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetDistrict_code(value);
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
		
		
		public void Write(OmniCancelledOrder structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetOrder_id() != null) {
				
				oprot.WriteFieldBegin("order_id");
				oprot.WriteString(structs.GetOrder_id());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("order_id can not be null!");
			}
			
			
			if(structs.GetProvince() != null) {
				
				oprot.WriteFieldBegin("province");
				oprot.WriteString(structs.GetProvince());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("province can not be null!");
			}
			
			
			if(structs.GetCity() != null) {
				
				oprot.WriteFieldBegin("city");
				oprot.WriteString(structs.GetCity());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("city can not be null!");
			}
			
			
			if(structs.GetDistrict() != null) {
				
				oprot.WriteFieldBegin("district");
				oprot.WriteString(structs.GetDistrict());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("district can not be null!");
			}
			
			
			if(structs.GetOrder_skus() != null) {
				
				oprot.WriteFieldBegin("order_skus");
				
				oprot.WriteListBegin();
				foreach(vipapis.order.OrderSku _item0 in structs.GetOrder_skus()){
					
					
					vipapis.order.OrderSkuHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("order_skus can not be null!");
			}
			
			
			if(structs.GetOrder_type() != null) {
				
				oprot.WriteFieldBegin("order_type");
				oprot.WriteByte((byte)structs.GetOrder_type()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetProvince_code() != null) {
				
				oprot.WriteFieldBegin("province_code");
				oprot.WriteString(structs.GetProvince_code());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetCity_code() != null) {
				
				oprot.WriteFieldBegin("city_code");
				oprot.WriteString(structs.GetCity_code());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetDistrict_code() != null) {
				
				oprot.WriteFieldBegin("district_code");
				oprot.WriteString(structs.GetDistrict_code());
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(OmniCancelledOrder bean){
			
			
		}
		
	}
	
}