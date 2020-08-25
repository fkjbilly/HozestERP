using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.isv.vreturn{
	
	
	
	public class GetReturnOrderResponseHelper : TBeanSerializer<GetReturnOrderResponse>
	{
		
		public static GetReturnOrderResponseHelper OBJ = new GetReturnOrderResponseHelper();
		
		public static GetReturnOrderResponseHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(GetReturnOrderResponse structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("return_orders".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<com.vip.isv.vreturn.ReturnOrder> value;
						
						value = new List<com.vip.isv.vreturn.ReturnOrder>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								com.vip.isv.vreturn.ReturnOrder elem0;
								
								elem0 = new com.vip.isv.vreturn.ReturnOrder();
								com.vip.isv.vreturn.ReturnOrderHelper.getInstance().Read(elem0, iprot);
								
								value.Add(elem0);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetReturn_orders(value);
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
		
		
		public void Write(GetReturnOrderResponse structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetReturn_orders() != null) {
				
				oprot.WriteFieldBegin("return_orders");
				
				oprot.WriteListBegin();
				foreach(com.vip.isv.vreturn.ReturnOrder _item0 in structs.GetReturn_orders()){
					
					
					com.vip.isv.vreturn.ReturnOrderHelper.getInstance().Write(_item0, oprot);
					
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
		
		
		public void Validate(GetReturnOrderResponse bean){
			
			
		}
		
	}
	
}