using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.domain.inventory{
	
	
	
	public class PurchaseSalesInventoryResponseHelper : TBeanSerializer<PurchaseSalesInventoryResponse>
	{
		
		public static PurchaseSalesInventoryResponseHelper OBJ = new PurchaseSalesInventoryResponseHelper();
		
		public static PurchaseSalesInventoryResponseHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(PurchaseSalesInventoryResponse structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("detail_count".Equals(schemeField.Trim())){
						
						needSkip = false;
						int value;
						value = iprot.ReadI32(); 
						
						structs.SetDetail_count(value);
					}
					
					
					
					
					
					if ("items".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<com.vip.domain.inventory.PurchaseSalesInventoryItemInfo> value;
						
						value = new List<com.vip.domain.inventory.PurchaseSalesInventoryItemInfo>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								com.vip.domain.inventory.PurchaseSalesInventoryItemInfo elem0;
								
								elem0 = new com.vip.domain.inventory.PurchaseSalesInventoryItemInfo();
								com.vip.domain.inventory.PurchaseSalesInventoryItemInfoHelper.getInstance().Read(elem0, iprot);
								
								value.Add(elem0);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetItems(value);
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
		
		
		public void Write(PurchaseSalesInventoryResponse structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetDetail_count() != null) {
				
				oprot.WriteFieldBegin("detail_count");
				oprot.WriteI32((int)structs.GetDetail_count()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("detail_count can not be null!");
			}
			
			
			if(structs.GetItems() != null) {
				
				oprot.WriteFieldBegin("items");
				
				oprot.WriteListBegin();
				foreach(com.vip.domain.inventory.PurchaseSalesInventoryItemInfo _item0 in structs.GetItems()){
					
					
					com.vip.domain.inventory.PurchaseSalesInventoryItemInfoHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("items can not be null!");
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(PurchaseSalesInventoryResponse bean){
			
			
		}
		
	}
	
}