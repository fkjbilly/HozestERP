using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.delivery{
	
	
	
	public class GetPoOrdersResponseHelper : TBeanSerializer<GetPoOrdersResponse>
	{
		
		public static GetPoOrdersResponseHelper OBJ = new GetPoOrdersResponseHelper();
		
		public static GetPoOrdersResponseHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(GetPoOrdersResponse structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("po_orders".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<vipapis.delivery.PoOrder> value;
						
						value = new List<vipapis.delivery.PoOrder>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								vipapis.delivery.PoOrder elem0;
								
								elem0 = new vipapis.delivery.PoOrder();
								vipapis.delivery.PoOrderHelper.getInstance().Read(elem0, iprot);
								
								value.Add(elem0);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetPo_orders(value);
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
		
		
		public void Write(GetPoOrdersResponse structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetPo_orders() != null) {
				
				oprot.WriteFieldBegin("po_orders");
				
				oprot.WriteListBegin();
				foreach(vipapis.delivery.PoOrder _item0 in structs.GetPo_orders()){
					
					
					vipapis.delivery.PoOrderHelper.getInstance().Write(_item0, oprot);
					
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
		
		
		public void Validate(GetPoOrdersResponse bean){
			
			
		}
		
	}
	
}