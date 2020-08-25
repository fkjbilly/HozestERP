using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.inventory{
	
	
	
	public class OccupiedOrderResponseHelper : TBeanSerializer<OccupiedOrderResponse>
	{
		
		public static OccupiedOrderResponseHelper OBJ = new OccupiedOrderResponseHelper();
		
		public static OccupiedOrderResponseHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(OccupiedOrderResponse structs, Protocol iprot){
			
			
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
					
					
					
					
					
					if ("occupied_orders".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<vipapis.inventory.OccupiedOrder> value;
						
						value = new List<vipapis.inventory.OccupiedOrder>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								vipapis.inventory.OccupiedOrder elem0;
								
								elem0 = new vipapis.inventory.OccupiedOrder();
								vipapis.inventory.OccupiedOrderHelper.getInstance().Read(elem0, iprot);
								
								value.Add(elem0);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetOccupied_orders(value);
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
		
		
		public void Write(OccupiedOrderResponse structs, Protocol oprot){
			
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
			
			
			if(structs.GetOccupied_orders() != null) {
				
				oprot.WriteFieldBegin("occupied_orders");
				
				oprot.WriteListBegin();
				foreach(vipapis.inventory.OccupiedOrder _item0 in structs.GetOccupied_orders()){
					
					
					vipapis.inventory.OccupiedOrderHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(OccupiedOrderResponse bean){
			
			
		}
		
	}
	
}