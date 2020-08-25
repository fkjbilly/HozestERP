using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.fcs.vei.service{
	
	
	
	public class DownloadElectronicInvoiceResModelHelper : TBeanSerializer<DownloadElectronicInvoiceResModel>
	{
		
		public static DownloadElectronicInvoiceResModelHelper OBJ = new DownloadElectronicInvoiceResModelHelper();
		
		public static DownloadElectronicInvoiceResModelHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(DownloadElectronicInvoiceResModel structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("pdfContent".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetPdfContent(value);
					}
					
					
					
					
					
					if ("restulMesg".Equals(schemeField.Trim())){
						
						needSkip = false;
						com.vip.fcs.vei.service.BaseRetMsg value;
						
						value = new com.vip.fcs.vei.service.BaseRetMsg();
						com.vip.fcs.vei.service.BaseRetMsgHelper.getInstance().Read(value, iprot);
						
						structs.SetRestulMesg(value);
					}
					
					
					
					
					
					if ("result".Equals(schemeField.Trim())){
						
						needSkip = false;
						bool? value;
						value = iprot.ReadBool();
						
						structs.SetResult(value);
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
		
		
		public void Write(DownloadElectronicInvoiceResModel structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetPdfContent() != null) {
				
				oprot.WriteFieldBegin("pdfContent");
				oprot.WriteString(structs.GetPdfContent());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetRestulMesg() != null) {
				
				oprot.WriteFieldBegin("restulMesg");
				
				com.vip.fcs.vei.service.BaseRetMsgHelper.getInstance().Write(structs.GetRestulMesg(), oprot);
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetResult() != null) {
				
				oprot.WriteFieldBegin("result");
				oprot.WriteBool((bool)structs.GetResult());
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(DownloadElectronicInvoiceResModel bean){
			
			
		}
		
	}
	
}