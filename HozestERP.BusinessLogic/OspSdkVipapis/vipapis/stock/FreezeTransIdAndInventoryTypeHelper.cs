using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.stock{
	
	
	
	public class FreezeTransIdAndInventoryTypeHelper : TBeanSerializer<FreezeTransIdAndInventoryType>
	{
		
		public static FreezeTransIdAndInventoryTypeHelper OBJ = new FreezeTransIdAndInventoryTypeHelper();
		
		public static FreezeTransIdAndInventoryTypeHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(FreezeTransIdAndInventoryType structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("frozen_trans_id".Equals(schemeField.Trim())){
						
						needSkip = false;
						int value;
						value = iprot.ReadI32(); 
						
						structs.SetFrozen_trans_id(value);
					}
					
					
					
					
					
					if ("inventory_type".Equals(schemeField.Trim())){
						
						needSkip = false;
						int value;
						value = iprot.ReadI32(); 
						
						structs.SetInventory_type(value);
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
		
		
		public void Write(FreezeTransIdAndInventoryType structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetFrozen_trans_id() != null) {
				
				oprot.WriteFieldBegin("frozen_trans_id");
				oprot.WriteI32((int)structs.GetFrozen_trans_id()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("frozen_trans_id can not be null!");
			}
			
			
			if(structs.GetInventory_type() != null) {
				
				oprot.WriteFieldBegin("inventory_type");
				oprot.WriteI32((int)structs.GetInventory_type()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("inventory_type can not be null!");
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(FreezeTransIdAndInventoryType bean){
			
			
		}
		
	}
	
}