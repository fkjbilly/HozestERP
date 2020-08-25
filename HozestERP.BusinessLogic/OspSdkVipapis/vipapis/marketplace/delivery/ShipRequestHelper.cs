using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.marketplace.delivery{
	
	
	
	public class ShipRequestHelper : TBeanSerializer<ShipRequest>
	{
		
		public static ShipRequestHelper OBJ = new ShipRequestHelper();
		
		public static ShipRequestHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(ShipRequest structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("ships".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<vipapis.marketplace.delivery.ShipInfo> value;
						
						value = new List<vipapis.marketplace.delivery.ShipInfo>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								vipapis.marketplace.delivery.ShipInfo elem1;
								
								elem1 = new vipapis.marketplace.delivery.ShipInfo();
								vipapis.marketplace.delivery.ShipInfoHelper.getInstance().Read(elem1, iprot);
								
								value.Add(elem1);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetShips(value);
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
		
		
		public void Write(ShipRequest structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetShips() != null) {
				
				oprot.WriteFieldBegin("ships");
				
				oprot.WriteListBegin();
				foreach(vipapis.marketplace.delivery.ShipInfo _item0 in structs.GetShips()){
					
					
					vipapis.marketplace.delivery.ShipInfoHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(ShipRequest bean){
			
			
		}
		
	}
	
}