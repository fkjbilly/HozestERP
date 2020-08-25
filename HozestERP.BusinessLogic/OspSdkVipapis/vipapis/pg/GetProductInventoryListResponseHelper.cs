using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.pg{
	
	
	
	public class GetProductInventoryListResponseHelper : TBeanSerializer<GetProductInventoryListResponse>
	{
		
		public static GetProductInventoryListResponseHelper OBJ = new GetProductInventoryListResponseHelper();
		
		public static GetProductInventoryListResponseHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(GetProductInventoryListResponse structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("goodsStock".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<vipapis.pg.Inventory> value;
						
						value = new List<vipapis.pg.Inventory>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								vipapis.pg.Inventory elem0;
								
								elem0 = new vipapis.pg.Inventory();
								vipapis.pg.InventoryHelper.getInstance().Read(elem0, iprot);
								
								value.Add(elem0);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetGoodsStock(value);
					}
					
					
					
					
					
					if ("total".Equals(schemeField.Trim())){
						
						needSkip = false;
						int value;
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
		
		
		public void Write(GetProductInventoryListResponse structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetGoodsStock() != null) {
				
				oprot.WriteFieldBegin("goodsStock");
				
				oprot.WriteListBegin();
				foreach(vipapis.pg.Inventory _item0 in structs.GetGoodsStock()){
					
					
					vipapis.pg.InventoryHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("goodsStock can not be null!");
			}
			
			
			if(structs.GetTotal() != null) {
				
				oprot.WriteFieldBegin("total");
				oprot.WriteI32((int)structs.GetTotal()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("total can not be null!");
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(GetProductInventoryListResponse bean){
			
			
		}
		
	}
	
}