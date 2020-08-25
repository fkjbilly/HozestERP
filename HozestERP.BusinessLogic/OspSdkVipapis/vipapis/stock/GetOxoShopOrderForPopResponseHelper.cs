using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.stock{
	
	
	
	public class GetOxoShopOrderForPopResponseHelper : TBeanSerializer<GetOxoShopOrderForPopResponse>
	{
		
		public static GetOxoShopOrderForPopResponseHelper OBJ = new GetOxoShopOrderForPopResponseHelper();
		
		public static GetOxoShopOrderForPopResponseHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(GetOxoShopOrderForPopResponse structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("oxo_shop_order_for_pop_list".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<vipapis.stock.OxoShopOrderForPopList> value;
						
						value = new List<vipapis.stock.OxoShopOrderForPopList>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								vipapis.stock.OxoShopOrderForPopList elem0;
								
								elem0 = new vipapis.stock.OxoShopOrderForPopList();
								vipapis.stock.OxoShopOrderForPopListHelper.getInstance().Read(elem0, iprot);
								
								value.Add(elem0);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetOxo_shop_order_for_pop_list(value);
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
		
		
		public void Write(GetOxoShopOrderForPopResponse structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetOxo_shop_order_for_pop_list() != null) {
				
				oprot.WriteFieldBegin("oxo_shop_order_for_pop_list");
				
				oprot.WriteListBegin();
				foreach(vipapis.stock.OxoShopOrderForPopList _item0 in structs.GetOxo_shop_order_for_pop_list()){
					
					
					vipapis.stock.OxoShopOrderForPopListHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(GetOxoShopOrderForPopResponse bean){
			
			
		}
		
	}
	
}