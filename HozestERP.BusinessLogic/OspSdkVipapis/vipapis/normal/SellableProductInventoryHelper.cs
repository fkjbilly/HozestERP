using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.normal{
	
	
	
	public class SellableProductInventoryHelper : TBeanSerializer<SellableProductInventory>
	{
		
		public static SellableProductInventoryHelper OBJ = new SellableProductInventoryHelper();
		
		public static SellableProductInventoryHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(SellableProductInventory structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("barcode".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetBarcode(value);
					}
					
					
					
					
					
					if ("inventory".Equals(schemeField.Trim())){
						
						needSkip = false;
						int value;
						value = iprot.ReadI32(); 
						
						structs.SetInventory(value);
					}
					
					
					
					
					
					if ("pick_num".Equals(schemeField.Trim())){
						
						needSkip = false;
						int value;
						value = iprot.ReadI32(); 
						
						structs.SetPick_num(value);
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
		
		
		public void Write(SellableProductInventory structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetBarcode() != null) {
				
				oprot.WriteFieldBegin("barcode");
				oprot.WriteString(structs.GetBarcode());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("barcode can not be null!");
			}
			
			
			if(structs.GetInventory() != null) {
				
				oprot.WriteFieldBegin("inventory");
				oprot.WriteI32((int)structs.GetInventory()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("inventory can not be null!");
			}
			
			
			if(structs.GetPick_num() != null) {
				
				oprot.WriteFieldBegin("pick_num");
				oprot.WriteI32((int)structs.GetPick_num()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("pick_num can not be null!");
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(SellableProductInventory bean){
			
			
		}
		
	}
	
}