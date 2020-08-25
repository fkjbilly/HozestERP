using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.inventory{
	
	
	
	public class GetMpSkuStockResponseHelper : TBeanSerializer<GetMpSkuStockResponse>
	{
		
		public static GetMpSkuStockResponseHelper OBJ = new GetMpSkuStockResponseHelper();
		
		public static GetMpSkuStockResponseHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(GetMpSkuStockResponse structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("sku_stock_result".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<vipapis.inventory.MpSkuStock> value;
						
						value = new List<vipapis.inventory.MpSkuStock>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								vipapis.inventory.MpSkuStock elem1;
								
								elem1 = new vipapis.inventory.MpSkuStock();
								vipapis.inventory.MpSkuStockHelper.getInstance().Read(elem1, iprot);
								
								value.Add(elem1);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetSku_stock_result(value);
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
		
		
		public void Write(GetMpSkuStockResponse structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetSku_stock_result() != null) {
				
				oprot.WriteFieldBegin("sku_stock_result");
				
				oprot.WriteListBegin();
				foreach(vipapis.inventory.MpSkuStock _item0 in structs.GetSku_stock_result()){
					
					
					vipapis.inventory.MpSkuStockHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(GetMpSkuStockResponse bean){
			
			
		}
		
	}
	
}