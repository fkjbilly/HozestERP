using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.order{
	
	
	
	public class GetOmniOrdersRespHelper : TBeanSerializer<GetOmniOrdersResp>
	{
		
		public static GetOmniOrdersRespHelper OBJ = new GetOmniOrdersRespHelper();
		
		public static GetOmniOrdersRespHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(GetOmniOrdersResp structs, Protocol iprot){
			
			
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
						List<vipapis.order.OmniOrder> value;
						
						value = new List<vipapis.order.OmniOrder>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								vipapis.order.OmniOrder elem1;
								
								elem1 = new vipapis.order.OmniOrder();
								vipapis.order.OmniOrderHelper.getInstance().Read(elem1, iprot);
								
								value.Add(elem1);
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
		
		
		public void Write(GetOmniOrdersResp structs, Protocol oprot){
			
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
				foreach(vipapis.order.OmniOrder _item0 in structs.GetOxo_orders()){
					
					
					vipapis.order.OmniOrderHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("oxo_orders can not be null!");
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(GetOmniOrdersResp bean){
			
			
		}
		
	}
	
}