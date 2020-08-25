using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.fcs.vei.service{
	
	
	
	public class DownloadElectronicInvoicePictureResModelHelper : TBeanSerializer<DownloadElectronicInvoicePictureResModel>
	{
		
		public static DownloadElectronicInvoicePictureResModelHelper OBJ = new DownloadElectronicInvoicePictureResModelHelper();
		
		public static DownloadElectronicInvoicePictureResModelHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(DownloadElectronicInvoicePictureResModel structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("pictureContent".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetPictureContent(value);
					}
					
					
					
					
					
					if ("restulMesg".Equals(schemeField.Trim())){
						
						needSkip = false;
						com.vip.fcs.vei.service.BaseRetMsg value;
						
						value = new com.vip.fcs.vei.service.BaseRetMsg();
						com.vip.fcs.vei.service.BaseRetMsgHelper.getInstance().Read(value, iprot);
						
						structs.SetRestulMesg(value);
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
		
		
		public void Write(DownloadElectronicInvoicePictureResModel structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetPictureContent() != null) {
				
				oprot.WriteFieldBegin("pictureContent");
				oprot.WriteString(structs.GetPictureContent());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetRestulMesg() != null) {
				
				oprot.WriteFieldBegin("restulMesg");
				
				com.vip.fcs.vei.service.BaseRetMsgHelper.getInstance().Write(structs.GetRestulMesg(), oprot);
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(DownloadElectronicInvoicePictureResModel bean){
			
			
		}
		
	}
	
}