using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.isv.vreturn{
	
	
	
	public class GetReturnDeliveryGoodsResponseHelper : TBeanSerializer<GetReturnDeliveryGoodsResponse>
	{
		
		public static GetReturnDeliveryGoodsResponseHelper OBJ = new GetReturnDeliveryGoodsResponseHelper();
		
		public static GetReturnDeliveryGoodsResponseHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(GetReturnDeliveryGoodsResponse structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("return_delivery_goods".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<com.vip.isv.vreturn.ReturnDeliveryGoods> value;
						
						value = new List<com.vip.isv.vreturn.ReturnDeliveryGoods>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								com.vip.isv.vreturn.ReturnDeliveryGoods elem0;
								
								elem0 = new com.vip.isv.vreturn.ReturnDeliveryGoods();
								com.vip.isv.vreturn.ReturnDeliveryGoodsHelper.getInstance().Read(elem0, iprot);
								
								value.Add(elem0);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetReturn_delivery_goods(value);
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
		
		
		public void Write(GetReturnDeliveryGoodsResponse structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetReturn_delivery_goods() != null) {
				
				oprot.WriteFieldBegin("return_delivery_goods");
				
				oprot.WriteListBegin();
				foreach(com.vip.isv.vreturn.ReturnDeliveryGoods _item0 in structs.GetReturn_delivery_goods()){
					
					
					com.vip.isv.vreturn.ReturnDeliveryGoodsHelper.getInstance().Write(_item0, oprot);
					
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
		
		
		public void Validate(GetReturnDeliveryGoodsResponse bean){
			
			
		}
		
	}
	
}