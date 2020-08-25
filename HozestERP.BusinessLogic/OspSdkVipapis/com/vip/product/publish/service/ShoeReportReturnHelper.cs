using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.product.publish.service{
	
	
	
	public class ShoeReportReturnHelper : TBeanSerializer<ShoeReportReturn>
	{
		
		public static ShoeReportReturnHelper OBJ = new ShoeReportReturnHelper();
		
		public static ShoeReportReturnHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(ShoeReportReturn structs, Protocol iprot){
			
			
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
					
					
					
					
					
					if ("barcode".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetBarcode(value);
					}
					
					
					
					
					
					if ("returnCodeMsg".Equals(schemeField.Trim())){
						
						needSkip = false;
						com.vip.product.publish.common.model.ReturnCodeMsg value;
						
						value = new com.vip.product.publish.common.model.ReturnCodeMsg();
						com.vip.product.publish.common.model.ReturnCodeMsgHelper.getInstance().Read(value, iprot);
						
						structs.SetReturnCodeMsg(value);
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
		
		
		public void Write(ShoeReportReturn structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetVendorId() != null) {
				
				oprot.WriteFieldBegin("vendorId");
				oprot.WriteI32((int)structs.GetVendorId()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetBarcode() != null) {
				
				oprot.WriteFieldBegin("barcode");
				oprot.WriteString(structs.GetBarcode());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetReturnCodeMsg() != null) {
				
				oprot.WriteFieldBegin("returnCodeMsg");
				
				com.vip.product.publish.common.model.ReturnCodeMsgHelper.getInstance().Write(structs.GetReturnCodeMsg(), oprot);
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(ShoeReportReturn bean){
			
			
		}
		
	}
	
}