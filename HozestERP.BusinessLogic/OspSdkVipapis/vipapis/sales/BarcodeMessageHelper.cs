using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.sales{
	
	
	
	public class BarcodeMessageHelper : TBeanSerializer<BarcodeMessage>
	{
		
		public static BarcodeMessageHelper OBJ = new BarcodeMessageHelper();
		
		public static BarcodeMessageHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(BarcodeMessage structs, Protocol iprot){
			
			
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
					
					
					
					
					
					if ("quantity".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetQuantity(value);
					}
					
					
					
					
					
					if ("message".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetMessage(value);
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
		
		
		public void Write(BarcodeMessage structs, Protocol oprot){
			
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
			
			
			if(structs.GetQuantity() != null) {
				
				oprot.WriteFieldBegin("quantity");
				oprot.WriteI32((int)structs.GetQuantity()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetMessage() != null) {
				
				oprot.WriteFieldBegin("message");
				oprot.WriteString(structs.GetMessage());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("message can not be null!");
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(BarcodeMessage bean){
			
			
		}
		
	}
	
}