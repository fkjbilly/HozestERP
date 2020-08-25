using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.haitao.base.osp.service.record{
	
	
	
	public class GoodRecordAttachParamHelper : TBeanSerializer<GoodRecordAttachParam>
	{
		
		public static GoodRecordAttachParamHelper OBJ = new GoodRecordAttachParamHelper();
		
		public static GoodRecordAttachParamHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(GoodRecordAttachParam structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("carrierCode".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetCarrierCode(value);
					}
					
					
					
					
					
					if ("customsCode".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetCustomsCode(value);
					}
					
					
					
					
					
					if ("recordType".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetRecordType(value);
					}
					
					
					
					
					
					if ("goodSn".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetGoodSn(value);
					}
					
					
					
					
					
					if ("recordNo".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetRecordNo(value);
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
		
		
		public void Write(GoodRecordAttachParam structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetCarrierCode() != null) {
				
				oprot.WriteFieldBegin("carrierCode");
				oprot.WriteString(structs.GetCarrierCode());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetCustomsCode() != null) {
				
				oprot.WriteFieldBegin("customsCode");
				oprot.WriteString(structs.GetCustomsCode());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetRecordType() != null) {
				
				oprot.WriteFieldBegin("recordType");
				oprot.WriteString(structs.GetRecordType());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetGoodSn() != null) {
				
				oprot.WriteFieldBegin("goodSn");
				oprot.WriteString(structs.GetGoodSn());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetRecordNo() != null) {
				
				oprot.WriteFieldBegin("recordNo");
				oprot.WriteString(structs.GetRecordNo());
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(GoodRecordAttachParam bean){
			
			
		}
		
	}
	
}