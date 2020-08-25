using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.stock{
	
	
	
	public class GetFrozenStockDetailsResponseHelper : TBeanSerializer<GetFrozenStockDetailsResponse>
	{
		
		public static GetFrozenStockDetailsResponseHelper OBJ = new GetFrozenStockDetailsResponseHelper();
		
		public static GetFrozenStockDetailsResponseHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(GetFrozenStockDetailsResponse structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("forzen_inventory_list".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<vipapis.stock.FrozenInventory> value;
						
						value = new List<vipapis.stock.FrozenInventory>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								vipapis.stock.FrozenInventory elem0;
								
								elem0 = new vipapis.stock.FrozenInventory();
								vipapis.stock.FrozenInventoryHelper.getInstance().Read(elem0, iprot);
								
								value.Add(elem0);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetForzen_inventory_list(value);
					}
					
					
					
					
					
					if ("total".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetTotal(value);
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
		
		
		public void Write(GetFrozenStockDetailsResponse structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetForzen_inventory_list() != null) {
				
				oprot.WriteFieldBegin("forzen_inventory_list");
				
				oprot.WriteListBegin();
				foreach(vipapis.stock.FrozenInventory _item0 in structs.GetForzen_inventory_list()){
					
					
					vipapis.stock.FrozenInventoryHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetTotal() != null) {
				
				oprot.WriteFieldBegin("total");
				oprot.WriteI32((int)structs.GetTotal()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(GetFrozenStockDetailsResponse bean){
			
			
		}
		
	}
	
}