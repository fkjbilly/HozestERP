using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.domain.order{
	
	
	
	public class CustomerBackOrderInfoHelper : TBeanSerializer<CustomerBackOrderInfo>
	{
		
		public static CustomerBackOrderInfoHelper OBJ = new CustomerBackOrderInfoHelper();
		
		public static CustomerBackOrderInfoHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(CustomerBackOrderInfo structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("transaction_id".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetTransaction_id(value);
					}
					
					
					
					
					
					if ("erp_order_sn".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetErp_order_sn(value);
					}
					
					
					
					
					
					if ("create_user".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetCreate_user(value);
					}
					
					
					
					
					
					if ("update_date".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetUpdate_date(value);
					}
					
					
					
					
					
					if ("itemList".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<com.vip.domain.order.CustomerBackOrderItemInfo> value;
						
						value = new List<com.vip.domain.order.CustomerBackOrderItemInfo>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								com.vip.domain.order.CustomerBackOrderItemInfo elem0;
								
								elem0 = new com.vip.domain.order.CustomerBackOrderItemInfo();
								com.vip.domain.order.CustomerBackOrderItemInfoHelper.getInstance().Read(elem0, iprot);
								
								value.Add(elem0);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetItemList(value);
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
		
		
		public void Write(CustomerBackOrderInfo structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetTransaction_id() != null) {
				
				oprot.WriteFieldBegin("transaction_id");
				oprot.WriteString(structs.GetTransaction_id());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("transaction_id can not be null!");
			}
			
			
			if(structs.GetErp_order_sn() != null) {
				
				oprot.WriteFieldBegin("erp_order_sn");
				oprot.WriteString(structs.GetErp_order_sn());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("erp_order_sn can not be null!");
			}
			
			
			if(structs.GetCreate_user() != null) {
				
				oprot.WriteFieldBegin("create_user");
				oprot.WriteString(structs.GetCreate_user());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("create_user can not be null!");
			}
			
			
			if(structs.GetUpdate_date() != null) {
				
				oprot.WriteFieldBegin("update_date");
				oprot.WriteString(structs.GetUpdate_date());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("update_date can not be null!");
			}
			
			
			if(structs.GetItemList() != null) {
				
				oprot.WriteFieldBegin("itemList");
				
				oprot.WriteListBegin();
				foreach(com.vip.domain.order.CustomerBackOrderItemInfo _item0 in structs.GetItemList()){
					
					
					com.vip.domain.order.CustomerBackOrderItemInfoHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("itemList can not be null!");
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(CustomerBackOrderInfo bean){
			
			
		}
		
	}
	
}