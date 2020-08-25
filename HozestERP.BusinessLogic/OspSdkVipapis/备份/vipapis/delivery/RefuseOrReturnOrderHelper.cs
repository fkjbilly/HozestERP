using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.delivery{
	
	
	
	public class RefuseOrReturnOrderHelper : BeanSerializer<RefuseOrReturnOrder>
	{
		
		public static RefuseOrReturnOrderHelper OBJ = new RefuseOrReturnOrderHelper();
		
		public static RefuseOrReturnOrderHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(RefuseOrReturnOrder structs, Protocol iprot){
			
			
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
					
					
					
					
					
					if ("carrier_name".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetCarrier_name(value);
					}
					
					
					
					
					
					if ("transport_no".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetTransport_no(value);
					}
					
					
					
					
					
					if ("refuse_or_return_product_list".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<vipapis.delivery.RefuseOrReturnProduct> value;
						
						value = new List<vipapis.delivery.RefuseOrReturnProduct>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								vipapis.delivery.RefuseOrReturnProduct elem0;
								
								elem0 = new vipapis.delivery.RefuseOrReturnProduct();
								vipapis.delivery.RefuseOrReturnProductHelper.getInstance().Read(elem0, iprot);
								
								value.Add(elem0);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetRefuse_or_return_product_list(value);
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
		
		
		public void Write(RefuseOrReturnOrder structs, Protocol oprot){
			
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
			
			
			if(structs.GetCarrier_name() != null) {
				
				oprot.WriteFieldBegin("carrier_name");
				oprot.WriteString(structs.GetCarrier_name());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("carrier_name can not be null!");
			}
			
			
			if(structs.GetTransport_no() != null) {
				
				oprot.WriteFieldBegin("transport_no");
				oprot.WriteString(structs.GetTransport_no());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("transport_no can not be null!");
			}
			
			
			if(structs.GetRefuse_or_return_product_list() != null) {
				
				oprot.WriteFieldBegin("refuse_or_return_product_list");
				
				oprot.WriteListBegin();
				foreach(vipapis.delivery.RefuseOrReturnProduct _item0 in structs.GetRefuse_or_return_product_list()){
					
					
					vipapis.delivery.RefuseOrReturnProductHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("refuse_or_return_product_list can not be null!");
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(RefuseOrReturnOrder bean){
			
			
		}
		
	}
	
}