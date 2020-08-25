using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.order{
	
	
	
	public class OxoOrderResponseHelper : TBeanSerializer<OxoOrderResponse>
	{
		
		public static OxoOrderResponseHelper OBJ = new OxoOrderResponseHelper();
		
		public static OxoOrderResponseHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(OxoOrderResponse structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("has_next".Equals(schemeField.Trim())){
						
						needSkip = false;
						bool value;
						value = iprot.ReadBool();
						
						structs.SetHas_next(value);
					}
					
					
					
					
					
					if ("oxo_orders".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<vipapis.order.OxoOrder> value;
						
						value = new List<vipapis.order.OxoOrder>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								vipapis.order.OxoOrder elem0;
								
								elem0 = new vipapis.order.OxoOrder();
								vipapis.order.OxoOrderHelper.getInstance().Read(elem0, iprot);
								
								value.Add(elem0);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetOxo_orders(value);
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
		
		
		public void Write(OxoOrderResponse structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetHas_next() != null) {
				
				oprot.WriteFieldBegin("has_next");
				oprot.WriteBool((bool)structs.GetHas_next());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("has_next can not be null!");
			}
			
			
			if(structs.GetOxo_orders() != null) {
				
				oprot.WriteFieldBegin("oxo_orders");
				
				oprot.WriteListBegin();
				foreach(vipapis.order.OxoOrder _item0 in structs.GetOxo_orders()){
					
					
					vipapis.order.OxoOrderHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(OxoOrderResponse bean){
			
			
		}
		
	}
	
}