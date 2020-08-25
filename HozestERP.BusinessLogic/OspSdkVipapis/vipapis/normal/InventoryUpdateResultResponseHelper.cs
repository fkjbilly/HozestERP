using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.normal{
	
	
	
	public class InventoryUpdateResultResponseHelper : TBeanSerializer<InventoryUpdateResultResponse>
	{
		
		public static InventoryUpdateResultResponseHelper OBJ = new InventoryUpdateResultResponseHelper();
		
		public static InventoryUpdateResultResponseHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(InventoryUpdateResultResponse structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("total".Equals(schemeField.Trim())){
						
						needSkip = false;
						int value;
						value = iprot.ReadI32(); 
						
						structs.SetTotal(value);
					}
					
					
					
					
					
					if ("inventoryUpdateResultList".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<vipapis.normal.InventoryUpdateResult> value;
						
						value = new List<vipapis.normal.InventoryUpdateResult>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								vipapis.normal.InventoryUpdateResult elem0;
								
								elem0 = new vipapis.normal.InventoryUpdateResult();
								vipapis.normal.InventoryUpdateResultHelper.getInstance().Read(elem0, iprot);
								
								value.Add(elem0);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetInventoryUpdateResultList(value);
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
		
		
		public void Write(InventoryUpdateResultResponse structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetTotal() != null) {
				
				oprot.WriteFieldBegin("total");
				oprot.WriteI32((int)structs.GetTotal()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("total can not be null!");
			}
			
			
			if(structs.GetInventoryUpdateResultList() != null) {
				
				oprot.WriteFieldBegin("inventoryUpdateResultList");
				
				oprot.WriteListBegin();
				foreach(vipapis.normal.InventoryUpdateResult _item0 in structs.GetInventoryUpdateResultList()){
					
					
					vipapis.normal.InventoryUpdateResultHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(InventoryUpdateResultResponse bean){
			
			
		}
		
	}
	
}