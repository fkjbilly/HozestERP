using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.stock{
	
	
	
	public class GetOxoShopOrderForJitResponseHelper : BeanSerializer<GetOxoShopOrderForJitResponse>
	{
		
		public static GetOxoShopOrderForJitResponseHelper OBJ = new GetOxoShopOrderForJitResponseHelper();
		
		public static GetOxoShopOrderForJitResponseHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(GetOxoShopOrderForJitResponse structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("oxo_shop_order_for_jit_list".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<vipapis.stock.OxoShopOrderForJitList> value;
						
						value = new List<vipapis.stock.OxoShopOrderForJitList>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								vipapis.stock.OxoShopOrderForJitList elem0;
								
								elem0 = new vipapis.stock.OxoShopOrderForJitList();
								vipapis.stock.OxoShopOrderForJitListHelper.getInstance().Read(elem0, iprot);
								
								value.Add(elem0);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetOxo_shop_order_for_jit_list(value);
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
		
		
		public void Write(GetOxoShopOrderForJitResponse structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetOxo_shop_order_for_jit_list() != null) {
				
				oprot.WriteFieldBegin("oxo_shop_order_for_jit_list");
				
				oprot.WriteListBegin();
				foreach(vipapis.stock.OxoShopOrderForJitList _item0 in structs.GetOxo_shop_order_for_jit_list()){
					
					
					vipapis.stock.OxoShopOrderForJitListHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(GetOxoShopOrderForJitResponse bean){
			
			
		}
		
	}
	
}