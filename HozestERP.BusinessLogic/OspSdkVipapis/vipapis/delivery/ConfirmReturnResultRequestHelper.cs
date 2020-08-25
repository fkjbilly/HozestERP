using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.delivery{
	
	
	
	public class ConfirmReturnResultRequestHelper : TBeanSerializer<ConfirmReturnResultRequest>
	{
		
		public static ConfirmReturnResultRequestHelper OBJ = new ConfirmReturnResultRequestHelper();
		
		public static ConfirmReturnResultRequestHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(ConfirmReturnResultRequest structs, Protocol iprot){
			
			
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
					
					
					
					
					
					if ("order_id".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetOrder_id(value);
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
					
					
					
					
					
					if ("delivery_no".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetDelivery_no(value);
					}
					
					
					
					
					
					if ("note".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetNote(value);
					}
					
					
					
					
					
					if ("goods_list".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<vipapis.delivery.ReturnGoods> value;
						
						value = new List<vipapis.delivery.ReturnGoods>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								vipapis.delivery.ReturnGoods elem0;
								
								elem0 = new vipapis.delivery.ReturnGoods();
								vipapis.delivery.ReturnGoodsHelper.getInstance().Read(elem0, iprot);
								
								value.Add(elem0);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetGoods_list(value);
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
		
		
		public void Write(ConfirmReturnResultRequest structs, Protocol oprot){
			
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
			
			
			if(structs.GetOrder_id() != null) {
				
				oprot.WriteFieldBegin("order_id");
				oprot.WriteString(structs.GetOrder_id());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("order_id can not be null!");
			}
			
			
			if(structs.GetCarrier_code() != null) {
				
				oprot.WriteFieldBegin("carrier_code");
				oprot.WriteString(structs.GetCarrier_code());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetCarrier_name() != null) {
				
				oprot.WriteFieldBegin("carrier_name");
				oprot.WriteString(structs.GetCarrier_name());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("carrier_name can not be null!");
			}
			
			
			if(structs.GetDelivery_no() != null) {
				
				oprot.WriteFieldBegin("delivery_no");
				oprot.WriteString(structs.GetDelivery_no());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("delivery_no can not be null!");
			}
			
			
			if(structs.GetNote() != null) {
				
				oprot.WriteFieldBegin("note");
				oprot.WriteString(structs.GetNote());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetGoods_list() != null) {
				
				oprot.WriteFieldBegin("goods_list");
				
				oprot.WriteListBegin();
				foreach(vipapis.delivery.ReturnGoods _item0 in structs.GetGoods_list()){
					
					
					vipapis.delivery.ReturnGoodsHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("goods_list can not be null!");
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(ConfirmReturnResultRequest bean){
			
			
		}
		
	}
	
}