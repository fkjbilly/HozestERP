using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.marketplace.delivery{
	
	
	
	public class ShipResultHelper : TBeanSerializer<ShipResult>
	{
		
		public static ShipResultHelper OBJ = new ShipResultHelper();
		
		public static ShipResultHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(ShipResult structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("ship".Equals(schemeField.Trim())){
						
						needSkip = false;
						vipapis.marketplace.delivery.ShipInfo value;
						
						value = new vipapis.marketplace.delivery.ShipInfo();
						vipapis.marketplace.delivery.ShipInfoHelper.getInstance().Read(value, iprot);
						
						structs.SetShip(value);
					}
					
					
					
					
					
					if ("result_desc".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetResult_desc(value);
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
		
		
		public void Write(ShipResult structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetShip() != null) {
				
				oprot.WriteFieldBegin("ship");
				
				vipapis.marketplace.delivery.ShipInfoHelper.getInstance().Write(structs.GetShip(), oprot);
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetResult_desc() != null) {
				
				oprot.WriteFieldBegin("result_desc");
				oprot.WriteString(structs.GetResult_desc());
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(ShipResult bean){
			
			
		}
		
	}
	
}