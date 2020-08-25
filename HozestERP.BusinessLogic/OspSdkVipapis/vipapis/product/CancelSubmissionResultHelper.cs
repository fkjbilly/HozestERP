using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.product{
	
	
	
	public class CancelSubmissionResultHelper : TBeanSerializer<CancelSubmissionResult>
	{
		
		public static CancelSubmissionResultHelper OBJ = new CancelSubmissionResultHelper();
		
		public static CancelSubmissionResultHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(CancelSubmissionResult structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("vendorProductSN".Equals(schemeField.Trim())){
						
						needSkip = false;
						vipapis.product.VendorProductSN value;
						
						value = new vipapis.product.VendorProductSN();
						vipapis.product.VendorProductSNHelper.getInstance().Read(value, iprot);
						
						structs.SetVendorProductSN(value);
					}
					
					
					
					
					
					if ("is_success".Equals(schemeField.Trim())){
						
						needSkip = false;
						bool? value;
						value = iprot.ReadBool();
						
						structs.SetIs_success(value);
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
		
		
		public void Write(CancelSubmissionResult structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetVendorProductSN() != null) {
				
				oprot.WriteFieldBegin("vendorProductSN");
				
				vipapis.product.VendorProductSNHelper.getInstance().Write(structs.GetVendorProductSN(), oprot);
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetIs_success() != null) {
				
				oprot.WriteFieldBegin("is_success");
				oprot.WriteBool((bool)structs.GetIs_success());
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(CancelSubmissionResult bean){
			
			
		}
		
	}
	
}