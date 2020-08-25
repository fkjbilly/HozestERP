using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.order.biz.request{
	
	
	
	public class AutoTakeInventoryReqHelper : TBeanSerializer<AutoTakeInventoryReq>
	{
		
		public static AutoTakeInventoryReqHelper OBJ = new AutoTakeInventoryReqHelper();
		
		public static AutoTakeInventoryReqHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(AutoTakeInventoryReq structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("userId".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetUserId(value);
					}
					
					
					
					
					
					if ("orderSn".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetOrderSn(value);
					}
					
					
					
					
					
					if ("inventoryList".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<com.vip.order.biz.request.Inventory> value;
						
						value = new List<com.vip.order.biz.request.Inventory>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								com.vip.order.biz.request.Inventory elem0;
								
								elem0 = new com.vip.order.biz.request.Inventory();
								com.vip.order.biz.request.InventoryHelper.getInstance().Read(elem0, iprot);
								
								value.Add(elem0);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetInventoryList(value);
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
		
		
		public void Write(AutoTakeInventoryReq structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetUserId() != null) {
				
				oprot.WriteFieldBegin("userId");
				oprot.WriteI64((long)structs.GetUserId()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOrderSn() != null) {
				
				oprot.WriteFieldBegin("orderSn");
				oprot.WriteString(structs.GetOrderSn());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetInventoryList() != null) {
				
				oprot.WriteFieldBegin("inventoryList");
				
				oprot.WriteListBegin();
				foreach(com.vip.order.biz.request.Inventory _item0 in structs.GetInventoryList()){
					
					
					com.vip.order.biz.request.InventoryHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(AutoTakeInventoryReq bean){
			
			
		}
		
	}
	
}