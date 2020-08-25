using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.fcs.vei.service{
	
	
	
	public class DownloadElectronicInvoiceReqModelHelper : TBeanSerializer<DownloadElectronicInvoiceReqModel>
	{
		
		public static DownloadElectronicInvoiceReqModelHelper OBJ = new DownloadElectronicInvoiceReqModelHelper();
		
		public static DownloadElectronicInvoiceReqModelHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(DownloadElectronicInvoiceReqModel structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("fpCode".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetFpCode(value);
					}
					
					
					
					
					
					if ("orderId".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetOrderId(value);
					}
					
					
					
					
					
					if ("userId".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetUserId(value);
					}
					
					
					
					
					
					if ("orderSn".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetOrderSn(value);
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
		
		
		public void Write(DownloadElectronicInvoiceReqModel structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetFpCode() != null) {
				
				oprot.WriteFieldBegin("fpCode");
				oprot.WriteString(structs.GetFpCode());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOrderId() != null) {
				
				oprot.WriteFieldBegin("orderId");
				oprot.WriteString(structs.GetOrderId());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetUserId() != null) {
				
				oprot.WriteFieldBegin("userId");
				oprot.WriteString(structs.GetUserId());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOrderSn() != null) {
				
				oprot.WriteFieldBegin("orderSn");
				oprot.WriteString(structs.GetOrderSn());
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(DownloadElectronicInvoiceReqModel bean){
			
			
		}
		
	}
	
}