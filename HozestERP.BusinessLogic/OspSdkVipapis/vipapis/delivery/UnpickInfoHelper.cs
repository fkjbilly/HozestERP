using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.delivery{
	
	
	
	public class UnpickInfoHelper : TBeanSerializer<UnpickInfo>
	{
		
		public static UnpickInfoHelper OBJ = new UnpickInfoHelper();
		
		public static UnpickInfoHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(UnpickInfo structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("warehouse_not_pick".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetWarehouse_not_pick(value);
					}
					
					
					
					
					
					if ("supply_num".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetSupply_num(value);
					}
					
					
					
					
					
					if ("sub_warehouse".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetSub_warehouse(value);
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
		
		
		public void Write(UnpickInfo structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetWarehouse_not_pick() != null) {
				
				oprot.WriteFieldBegin("warehouse_not_pick");
				oprot.WriteI32((int)structs.GetWarehouse_not_pick()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetSupply_num() != null) {
				
				oprot.WriteFieldBegin("supply_num");
				oprot.WriteI32((int)structs.GetSupply_num()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetSub_warehouse() != null) {
				
				oprot.WriteFieldBegin("sub_warehouse");
				oprot.WriteString(structs.GetSub_warehouse());
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(UnpickInfo bean){
			
			
		}
		
	}
	
}