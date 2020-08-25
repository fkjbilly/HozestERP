using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.vop.vcloud.jit{
	
	
	
	public class DeliverySubPickHelper : TBeanSerializer<DeliverySubPick>
	{
		
		public static DeliverySubPickHelper OBJ = new DeliverySubPickHelper();
		
		public static DeliverySubPickHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(DeliverySubPick structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("vendorId".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetVendorId(value);
					}
					
					
					
					
					
					if ("subPickNo".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetSubPickNo(value);
					}
					
					
					
					
					
					if ("poNo".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetPoNo(value);
					}
					
					
					
					
					
					if ("unboxedQuantity".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetUnboxedQuantity(value);
					}
					
					
					
					
					
					if ("leavingUnboxNum".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetLeavingUnboxNum(value);
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
		
		
		public void Write(DeliverySubPick structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetVendorId() != null) {
				
				oprot.WriteFieldBegin("vendorId");
				oprot.WriteI32((int)structs.GetVendorId()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetSubPickNo() != null) {
				
				oprot.WriteFieldBegin("subPickNo");
				oprot.WriteString(structs.GetSubPickNo());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetPoNo() != null) {
				
				oprot.WriteFieldBegin("poNo");
				oprot.WriteString(structs.GetPoNo());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetUnboxedQuantity() != null) {
				
				oprot.WriteFieldBegin("unboxedQuantity");
				oprot.WriteI32((int)structs.GetUnboxedQuantity()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetLeavingUnboxNum() != null) {
				
				oprot.WriteFieldBegin("leavingUnboxNum");
				oprot.WriteI32((int)structs.GetLeavingUnboxNum()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(DeliverySubPick bean){
			
			
		}
		
	}
	
}