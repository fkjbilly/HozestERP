using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.normal{
	
	
	
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
					
					
					if ("occupied_orders".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<vipapis.normal.OccupiedOrder> value;
						
						value = new List<vipapis.normal.OccupiedOrder>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								vipapis.normal.OccupiedOrder elem0;
								
								elem0 = new vipapis.normal.OccupiedOrder();
								vipapis.normal.OccupiedOrderHelper.getInstance().Read(elem0, iprot);
								
								value.Add(elem0);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetOccupied_orders(value);
					}
					
					
					
					
					
					if ("has_next".Equals(schemeField.Trim())){
						
						needSkip = false;
						bool value;
						value = iprot.ReadBool();
						
						structs.SetHas_next(value);
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
			
			if(structs.GetOccupied_orders() != null) {
				
				oprot.WriteFieldBegin("occupied_orders");
				
				oprot.WriteListBegin();
				foreach(vipapis.normal.OccupiedOrder _item0 in structs.GetOccupied_orders()){
					
					
					vipapis.normal.OccupiedOrderHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetHas_next() != null) {
				
				oprot.WriteFieldBegin("has_next");
				oprot.WriteBool((bool)structs.GetHas_next());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("has_next can not be null!");
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(OccupiedOrderResponse bean){
			
			
		}
		
	}
	
}