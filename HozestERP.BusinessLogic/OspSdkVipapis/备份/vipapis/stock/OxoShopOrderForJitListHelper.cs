using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.stock{
	
	
	
	public class OxoShopOrderForJitListHelper : BeanSerializer<OxoShopOrderForJitList>
	{
		
		public static OxoShopOrderForJitListHelper OBJ = new OxoShopOrderForJitListHelper();
		
		public static OxoShopOrderForJitListHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(OxoShopOrderForJitList structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("order_id".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetOrder_id(value);
					}
					
					
					
					
					
					if ("oxo_order_goods_jit_list".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<vipapis.stock.OxoOrderGoodsJitList> value;
						
						value = new List<vipapis.stock.OxoOrderGoodsJitList>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								vipapis.stock.OxoOrderGoodsJitList elem0;
								
								elem0 = new vipapis.stock.OxoOrderGoodsJitList();
								vipapis.stock.OxoOrderGoodsJitListHelper.getInstance().Read(elem0, iprot);
								
								value.Add(elem0);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetOxo_order_goods_jit_list(value);
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
		
		
		public void Write(OxoShopOrderForJitList structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetOrder_id() != null) {
				
				oprot.WriteFieldBegin("order_id");
				oprot.WriteString(structs.GetOrder_id());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOxo_order_goods_jit_list() != null) {
				
				oprot.WriteFieldBegin("oxo_order_goods_jit_list");
				
				oprot.WriteListBegin();
				foreach(vipapis.stock.OxoOrderGoodsJitList _item0 in structs.GetOxo_order_goods_jit_list()){
					
					
					vipapis.stock.OxoOrderGoodsJitListHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(OxoShopOrderForJitList bean){
			
			
		}
		
	}
	
}