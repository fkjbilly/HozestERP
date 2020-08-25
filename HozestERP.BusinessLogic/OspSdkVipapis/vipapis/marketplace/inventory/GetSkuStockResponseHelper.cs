using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.marketplace.inventory{
	
	
	
	public class GetSkuStockResponseHelper : TBeanSerializer<GetSkuStockResponse>
	{
		
		public static GetSkuStockResponseHelper OBJ = new GetSkuStockResponseHelper();
		
		public static GetSkuStockResponseHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(GetSkuStockResponse structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("sku_stocks".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<vipapis.marketplace.inventory.SkuStock> value;
						
						value = new List<vipapis.marketplace.inventory.SkuStock>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								vipapis.marketplace.inventory.SkuStock elem0;
								
								elem0 = new vipapis.marketplace.inventory.SkuStock();
								vipapis.marketplace.inventory.SkuStockHelper.getInstance().Read(elem0, iprot);
								
								value.Add(elem0);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetSku_stocks(value);
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
		
		
		public void Write(GetSkuStockResponse structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetSku_stocks() != null) {
				
				oprot.WriteFieldBegin("sku_stocks");
				
				oprot.WriteListBegin();
				foreach(vipapis.marketplace.inventory.SkuStock _item0 in structs.GetSku_stocks()){
					
					
					vipapis.marketplace.inventory.SkuStockHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(GetSkuStockResponse bean){
			
			
		}
		
	}
	
}